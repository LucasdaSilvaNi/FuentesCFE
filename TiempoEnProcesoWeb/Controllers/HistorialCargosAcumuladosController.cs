using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiempoEnProcesoWeb.Models;
using TiempoEnProcesoEN;
using TiempoEnProcesoBL;
using System.Globalization;

namespace TiempoEnProcesoWeb.Controllers
{
    public class HistorialCargosAcumuladosController : Controller
    {
        //
        // GET: /AuxiliarTep/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Parameters()
        {
            HistorialCargosAcumuladosModel _model = new HistorialCargosAcumuladosModel();
            _model.Tipo_HistorialCargosAcumulados = 1;
            

            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];
            _model.Periodo = _oficina.periodo_proceso.Substring(3, 4);

            List<EmpleadoEN> lstE = (new EmpleadosBL()).ListarTodos(_oficina.id_oficina);
            List<ClienteEN> lstC = (new ClientesBL()).ListarTodo(_oficina.id_oficina);

            if (lstE.Count > 0)
                _model.valEmpleado_HistorialCargosAcumulados = lstE.FirstOrDefault().id_empleado;

            if (lstC.Count > 0)
                _model.valCliente_HistorialCargosAcumulados = lstC.FirstOrDefault().id_cliente;

            ViewData.Add(TiempoEnProcesoHelper.Constantes.S_EMPLEADO, lstE);

            ViewData.Add(TiempoEnProcesoHelper.Constantes.S_CLIENTE, lstC);

            return View(_model);
        }

        public ActionResult Generate(Models.HistorialCargosAcumuladosModel _model)
        {
            Models.ReportModel _rpt = new ReportModel();
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];

            if (_model.Tipo_HistorialCargosAcumulados == 1)
            {
                _rpt.Data = (new ReportesBL()).Reporte_Historial_Cargos_Acumulados_Empleado(_oficina.id_oficina, _model.Empleado_HistorialCargosAcumulados, _model.Periodo);
                TiempoEnProcesoHelper.Helper.SetData((new ReportesBL()).Reporte_Historial_Cargos_Acumulados_Empleados_Sub(_oficina.id_oficina, _model.Empleado_HistorialCargosAcumulados, _model.Periodo), "_HistorialCargos");
            }
            else
            {
                _rpt.Data = (new ReportesBL()).Reporte_Historial_Cargos_Acumulados_Cliente(_oficina.id_oficina, _model.Cliente_HistorialCargosAcumulados, _model.Periodo);
                TiempoEnProcesoHelper.Helper.SetData((new ReportesBL()).Reporte_Historial_Cargos_Acumulados_Cliente_Sub(_oficina.id_oficina, _model.Cliente_HistorialCargosAcumulados, _model.Periodo), "_HistorialCargos");
            }
            _rpt.EsSocio = _model.Tipo_HistorialCargosAcumulados == 1;
            return View(_rpt);
        }
    }
}
