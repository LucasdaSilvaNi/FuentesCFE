using System.Web.Mvc;
using TiempoEnProcesoUIWeb.Models;
using TiempoEnProcesoEN;
using TiempoEnProcesoBL;

namespace TiempoEnProcesoUIWeb.Controllers
{
    public class ReporteController : BaseController
    {
        //
        // GET: /AuxiliarTep/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ParametersTeamAcumulado()
        {
            OficinaEN _oficina = GetOficina();

            TeamAcumuladoModel _model = new TeamAcumuladoModel();

            _model.id_team = string.Empty;

            ViewData.Add(TiempoEnProcesoHelper.Constantes.S_TEAM, (new TeamsBL()).ListarTodos(_oficina.id_oficina));
            return View(_model);
        }

        public ActionResult ParametersTeamAcumuladoTep()
        {
            OficinaEN _oficina = GetOficina();

            TeamAcumuladoModel _model = new TeamAcumuladoModel();

            _model.id_team = string.Empty;
            ViewData.Add(TiempoEnProcesoHelper.Constantes.S_TEAM, (new TeamsBL()).ListarTodos(_oficina.id_oficina));
            return View(_model);
        }

        public ActionResult PorCliente()
        {
            ReportModel _rpt = new ReportModel();
            OficinaEN _oficina = GetOficina();
            EmpleadoEN _empleado = GetEmpleado();


            _rpt.Data = (new ReportesBL()).Reporte_Por_Empleado(_empleado.id_empleado, _oficina.periodo_proceso);

            return View(_rpt);
        }

        public ActionResult PorDia()
        {
            ReportModel _rpt = new ReportModel();
            OficinaEN _oficina = GetOficina();
            EmpleadoEN _empleado = GetEmpleado();

            _rpt.Data = (new ReportesBL()).Reporte_Por_Dia(_empleado.id_empleado, _oficina.periodo_proceso);

            return View(_rpt);
        }

        public ActionResult PorTeamAcumulado(TeamAcumuladoModel _report)
        {
            ReportModel _rpt = new ReportModel();
            OficinaEN _oficina = GetOficina();

            _rpt.Data = (new ReportesBL()).Reporte_Team_Acumulado(_oficina.id_oficina, _report.id_team, _oficina.periodo_proceso.Substring(3));

            return View(_rpt);
        }

        public ActionResult PorTeamPeriodoTep(TeamAcumuladoModel _report)
        {
            ReportModel _rpt = new ReportModel();
            OficinaEN _oficina = GetOficina();

            _rpt.Data = (new ReportesBL()).Reporte_Team_Periodo(_oficina.id_oficina, _report.id_team, _oficina.periodo_proceso);

            return View(_rpt);
        }
    }
}
