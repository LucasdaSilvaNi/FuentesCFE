using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiempoEnProcesoUIWeb.Models;
using TiempoEnProcesoEN;
using TiempoEnProcesoBL;

namespace TiempoEnProcesoWeb.Controllers
{
    public class ReporteController : Controller
    {
        //
        // GET: /AuxiliarTep/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ParametersTeamAcumulado()
        {
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];

            TeamAcumuladoModel _model = new TeamAcumuladoModel();

            _model.id_team = string.Empty;

            ViewData.Add(TiempoEnProcesoHelper.Constantes.S_TEAM, (new TeamsBL()).ListarTodos(_oficina.id_oficina));
            return View(_model);
        }

        public ActionResult ParametersTeamAcumuladoTep()
        {
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];

            TeamAcumuladoModel _model = new TeamAcumuladoModel();

            _model.id_team = string.Empty;
            ViewData.Add(TiempoEnProcesoHelper.Constantes.S_TEAM, (new TeamsBL()).ListarTodos(_oficina.id_oficina));
            return View(_model);
        }

        public ActionResult PorCliente()
        {
            ReportModel _rpt = new ReportModel();
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];
            EmpleadoEN _empleado = (EmpleadoEN)Session[TiempoEnProcesoHelper.Constantes.S_EMPLEADO];


            _rpt.Data = (new ReportesBL()).Reporte_Por_Empleado(_empleado.id_empleado, _oficina.periodo_proceso);

            return View(_rpt);
        }

        public ActionResult PorDia()
        {
            ReportModel _rpt = new ReportModel();
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];
            EmpleadoEN _empleado = (EmpleadoEN)Session[TiempoEnProcesoHelper.Constantes.S_EMPLEADO];

            _rpt.Data = (new ReportesBL()).Reporte_Por_Dia(_empleado.id_empleado, _oficina.periodo_proceso);

            return View(_rpt);
        }

        public ActionResult PorTeamAcumulado(TeamAcumuladoModel _report)
        {
            ReportModel _rpt = new ReportModel();
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];

            _rpt.Data = (new ReportesBL()).Reporte_Team_Acumulado(_oficina.id_oficina, _report.id_team, _oficina.periodo_proceso.Substring(3));

            return View(_rpt);
        }

        public ActionResult PorTeamPeriodoTep(TeamAcumuladoModel _report)
        {
            ReportModel _rpt = new ReportModel();
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];

            _rpt.Data = (new ReportesBL()).Reporte_Team_Periodo(_oficina.id_oficina, _report.id_team, _oficina.periodo_proceso);

            return View(_rpt);
        }
    }
}
