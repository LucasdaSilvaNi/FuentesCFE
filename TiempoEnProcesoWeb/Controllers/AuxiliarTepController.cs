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
    public class AuxiliarTepController : Controller
    {
        //
        // GET: /AuxiliarTep/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Parameters()
        {
            AuxiliarTepModel _model = new AuxiliarTepModel();
            _model.Socio = TiempoEnProcesoHelper.Constantes.S_TODOS;
            _model.Encargado = TiempoEnProcesoHelper.Constantes.S_TODOS;
            _model.Cliente = TiempoEnProcesoHelper.Constantes.S_TODOS;
            _model.Job = TiempoEnProcesoHelper.Constantes.S_TODOS;
            _model.Servicio = TiempoEnProcesoHelper.Constantes.S_TODOS;

            EmpleadoEN _empleado = (EmpleadoEN)Session[TiempoEnProcesoHelper.Constantes.S_EMPLEADO];
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];
            string _puesto = Session[TiempoEnProcesoHelper.Constantes.S_PUESTO].ToString();

            _model.EsAdmin = _puesto == TiempoEnProcesoHelper.Constantes.ADMIN ? 1 : 0;
            _model.EsGerente = _puesto == TiempoEnProcesoHelper.Constantes.GERENTE ? 1 : 0; 
            _model.EsSocio = _puesto == TiempoEnProcesoHelper.Constantes.SOCIO ? 1 : 0;

            if (_model.EsSocio==1)
            {
                _model.Socio = _empleado.id_empleado;
                _model.ValSocio = _empleado.id_empleado;
                _model.ValEncargado = TiempoEnProcesoHelper.Constantes.S_TODOS;
            }

            List<SocioEN> lstS = (new SocioBL()).ListarTodosxEmpleado(_empleado.id_empleado, _empleado.id_oficina, _oficina.id_pais, _empleado.id_puesto);
            if (_model.EsGerente==1)
            {
                _model.Encargado = _empleado.id_empleado;
                _model.ValEncargado = _empleado.id_empleado;
                _model.ValSocio = lstS.FirstOrDefault<SocioEN>(d=> d.id_empleado!= TiempoEnProcesoHelper.Constantes.S_TODOS).id_empleado;
            }

            if (_model.EsAdmin == 1)
            {
                _model.ValSocio = TiempoEnProcesoHelper.Constantes.S_TODOS;
                _model.ValEncargado = TiempoEnProcesoHelper.Constantes.S_TODOS;
            }

            ViewData.Add(TiempoEnProcesoHelper.Constantes.S_SOCIO, lstS);

            ViewData.Add(TiempoEnProcesoHelper.Constantes.S_ENCARGADO, (new EncargadoBL()).ListarTodosxEmpleado(_model.ValSocio, _empleado.id_empleado, _oficina.id_oficina, _oficina.id_pais, _empleado.id_puesto));

            ViewData.Add(TiempoEnProcesoHelper.Constantes.S_CLIENTE, (new ClientesBL()).ListarTodosxEmpleado(_model.ValSocio, _model.ValEncargado, _oficina.id_oficina));

            ViewData.Add(TiempoEnProcesoHelper.Constantes.S_SERVICIO, (new ServicioBL()).ListarTodos(TiempoEnProcesoHelper.Constantes.S_TODOS, _model.ValSocio, _model.ValEncargado, _oficina.id_oficina));

            ViewData.Add(TiempoEnProcesoHelper.Constantes.S_JOBS, (new JobsBL()).ListarTodos(TiempoEnProcesoHelper.Constantes.S_TODOS, _model.ValSocio, _model.ValEncargado, TiempoEnProcesoHelper.Constantes.S_TODOS,_oficina.id_oficina));

            _model.id_pais = _oficina.id_oficina;
            return View(_model);
        }

        public ActionResult Generate(Models.AuxiliarTepModel _model)
        {
            Models.ReportModel _rpt = new ReportModel();
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];
            EmpleadoEN _empleado = (EmpleadoEN)Session[TiempoEnProcesoHelper.Constantes.S_EMPLEADO];
            TiempoEnProcesoHelper.Helper.Oficina = _oficina.id_oficina;

            _model.Socio = _model.Socio ?? TiempoEnProcesoHelper.Constantes.S_TODOS;
            _model.Encargado = _model.Encargado ?? TiempoEnProcesoHelper.Constantes.S_TODOS;
            _model.Cliente = _model.Cliente ?? TiempoEnProcesoHelper.Constantes.S_TODOS;
            _model.Servicio = _model.Servicio ?? TiempoEnProcesoHelper.Constantes.S_TODOS;
            _model.Job = _model.Job ?? TiempoEnProcesoHelper.Constantes.S_TODOS;

            if (_model.EsSocio == 1 && _model.Socio == TiempoEnProcesoHelper.Constantes.S_TODOS)
                _model.Socio = _empleado.id_empleado;

            if (_model.EsGerente == 1 && _model.Encargado == TiempoEnProcesoHelper.Constantes.S_TODOS)
            {
                List<SocioEN> lstS = (new SocioBL()).ListarTodosxEmpleado(_empleado.id_empleado, _empleado.id_oficina, _oficina.id_pais, _empleado.id_puesto);
                _model.Encargado = _empleado.id_empleado;
                _model.Socio = lstS.FirstOrDefault<SocioEN>(d => d.id_empleado != TiempoEnProcesoHelper.Constantes.S_TODOS).id_empleado;
            }

            _rpt.Data = (new ReportesBL()).Reporte_Auxiliar_Tep(_oficina.id_oficina, _model.Socio, _model.Encargado, _model.Cliente, _model.Servicio, _model.Job);

            //TiempoEnProcesoHelper.Helper.SetData((new ReportesBL()).Reporte_Auxiliar_Tep_Sub(_oficina.id_oficina, _model.Socio, _model.Encargado, _model.Cliente, _model.Servicio, _model.Job),"_Auxiliar");
            

            return View(_rpt);
        }
    }
}
