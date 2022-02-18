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
    public class BalanceAntiguedadController : Controller
    {
        //
        // GET: /AuxiliarTep/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Parameters()
        {
            BalanceAntiguedadModel _model = new BalanceAntiguedadModel();
            _model.Socio = TiempoEnProcesoHelper.Constantes.S_TODOS;
            _model.Encargado = TiempoEnProcesoHelper.Constantes.S_TODOS;
            _model.Fecha = DateTime.Today.ToString("dd/MM/yyyy");

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

        public ActionResult Generate(Models.BalanceAntiguedadModel _model)
        {
            Models.ReportModel _rpt = new ReportModel();
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];
            EmpleadoEN _empleado = (EmpleadoEN)Session[TiempoEnProcesoHelper.Constantes.S_EMPLEADO];

            

            _model.Socio = _model.Socio ?? TiempoEnProcesoHelper.Constantes.S_TODOS;
            _model.Encargado = _model.Encargado ?? TiempoEnProcesoHelper.Constantes.S_TODOS;

            string periodo = _oficina.periodo_proceso;
            string ordenadopor = _model.EsGerente == 1 ? TiempoEnProcesoHelper.Constantes.ORD_GERENTE_SOCIO : TiempoEnProcesoHelper.Constantes.ORD_SOCIO_GERENTE;
            

            if (_model.EsSocio == 1 && _model.Socio == TiempoEnProcesoHelper.Constantes.S_TODOS)
                _model.Socio = _empleado.id_empleado;

            if (_model.EsGerente == 1 && _model.Encargado == TiempoEnProcesoHelper.Constantes.S_TODOS)
            {
                List<SocioEN> lstS = (new SocioBL()).ListarTodosxEmpleado(_empleado.id_empleado, _empleado.id_oficina, _oficina.id_pais, _empleado.id_puesto);
                _model.Encargado = _empleado.id_empleado;
                _model.Socio = lstS.FirstOrDefault<SocioEN>(d => d.id_empleado != TiempoEnProcesoHelper.Constantes.S_TODOS).id_empleado;
            }
            DateTime dt = new DateTime(Convert.ToInt32(_model.Fecha.Substring(6, 4)),Convert.ToInt32(_model.Fecha.Substring(3, 2)), Convert.ToInt32( _model.Fecha.Substring(0, 2)));
            _rpt.Data = (new ReportesBL()).Reporte_Balance_Antiguedad(_oficina.id_pais, dt, ordenadopor, _oficina.id_oficina, _model.Socio, _model.Encargado, TiempoEnProcesoHelper.Constantes.S_TODOS);

            TiempoEnProcesoHelper.Helper.SetData((new ReportesBL()).Reporte_Balance_Antiguedad_SubPre(_oficina.id_pais, dt,ordenadopor,_oficina.id_oficina,_model.Socio,_model.Encargado,TiempoEnProcesoHelper.Constantes.S_TODOS),"_BalAntPrel");
            TiempoEnProcesoHelper.Helper.SetData((new ReportesBL()).Reporte_Balance_Antiguedad_SubDef(_oficina.id_pais, dt, ordenadopor, _oficina.id_oficina, _model.Socio, _model.Encargado, TiempoEnProcesoHelper.Constantes.S_TODOS), "_BalAntDef");            

            return View(_rpt);
        }
    }
}
