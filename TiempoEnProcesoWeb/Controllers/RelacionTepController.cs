using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiempoEnProcesoWeb.Models;
using TiempoEnProcesoEN;
using TiempoEnProcesoBL;

namespace TiempoEnProcesoWeb.Controllers
{
    public class RelacionTepController : Controller
    {
        //
        // GET: /AuxiliarTep/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Parameters()
        {
            RelacionTepModel _model = new RelacionTepModel();
            _model.Socio = TiempoEnProcesoHelper.Constantes.S_TODOS;
            _model.Encargado = TiempoEnProcesoHelper.Constantes.S_TODOS;            

            EmpleadoEN _empleado = (EmpleadoEN)Session[TiempoEnProcesoHelper.Constantes.S_EMPLEADO];
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];
            string _puesto = Session[TiempoEnProcesoHelper.Constantes.S_PUESTO].ToString();

            _model.EsAdmin = _puesto == TiempoEnProcesoHelper.Constantes.ADMIN ? 1 : 0;
            _model.EsGerente = _puesto == TiempoEnProcesoHelper.Constantes.GERENTE ? 1 : 0; ;
            _model.EsSocio = _puesto == TiempoEnProcesoHelper.Constantes.SOCIO ? 1 : 0; ;

            if (_model.EsSocio == 1)
            {
                _model.Socio = _empleado.id_empleado;
                _model.ValSocio = _empleado.id_empleado;
                _model.ValEncargado = TiempoEnProcesoHelper.Constantes.S_TODOS;
            }

            List<SocioEN> lstS = (new SocioBL()).ListarTodosxEmpleado(_empleado.id_empleado, _empleado.id_oficina, _oficina.id_pais, _empleado.id_puesto);
            if (_model.EsGerente == 1)
            {
                _model.Encargado = _empleado.id_empleado;
                _model.ValEncargado = _empleado.id_empleado;
                _model.ValSocio = lstS.FirstOrDefault<SocioEN>(d => d.id_empleado != TiempoEnProcesoHelper.Constantes.S_TODOS).id_empleado;
            }

            if (_model.EsAdmin == 1)
            {
                _model.ValSocio = TiempoEnProcesoHelper.Constantes.S_TODOS;
                _model.ValEncargado = TiempoEnProcesoHelper.Constantes.S_TODOS;
            }

            ViewData.Add(TiempoEnProcesoHelper.Constantes.S_SOCIO, lstS);

            ViewData.Add(TiempoEnProcesoHelper.Constantes.S_ENCARGADO, (new EncargadoBL()).ListarTodosxEmpleado(_model.ValSocio, _empleado.id_empleado, _oficina.id_oficina, _oficina.id_pais, _empleado.id_puesto));
            
            return View(_model);
        }

        public ActionResult Generate(Models.RelacionTepModel _model)
        {
            Models.ReportModel _rpt = new ReportModel();
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];
            EmpleadoEN _empleado = (EmpleadoEN)Session[TiempoEnProcesoHelper.Constantes.S_EMPLEADO];

            _model.Socio = _model.Socio ?? TiempoEnProcesoHelper.Constantes.S_TODOS;
            _model.Encargado = _model.Encargado ?? TiempoEnProcesoHelper.Constantes.S_TODOS;

            string periodo = _oficina.periodo_proceso;
            string ordenadopor = _model.EsGerente == 1 ? TiempoEnProcesoHelper.Constantes.ORD_GERENTE_SOCIO : TiempoEnProcesoHelper.Constantes.ORD_SOCIO_GERENTE;
            string salta = "S";

            if (_model.EsSocio == 1 && _model.Socio == TiempoEnProcesoHelper.Constantes.S_TODOS)
                _model.Socio = _empleado.id_empleado;

            if (_model.EsGerente == 1 && _model.Encargado == TiempoEnProcesoHelper.Constantes.S_TODOS)
            {
                List<SocioEN> lstS = (new SocioBL()).ListarTodosxEmpleado(_empleado.id_empleado, _empleado.id_oficina, _oficina.id_pais, _empleado.id_puesto);
                _model.Encargado = _empleado.id_empleado;
                _model.Socio = lstS.FirstOrDefault<SocioEN>(d => d.id_empleado != TiempoEnProcesoHelper.Constantes.S_TODOS).id_empleado;
            }

            _rpt.Data = (new ReportesBL()).Reporte_Relacion_Tep(_oficina.id_pais, periodo, ordenadopor, salta,  _oficina.id_oficina, _model.Socio, _model.Encargado);

            TiempoEnProcesoHelper.Helper.SetData(_rpt.Data,"_Relacion");            

            return View(_rpt);
        }
    }
}
