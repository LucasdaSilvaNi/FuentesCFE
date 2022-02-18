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
    public class TiempoCargadoPorTeamController : Controller
    {
        //
        // GET: /AuxiliarTep/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Parameters()
        {
            TiempoCargadoPorTeamModel _model = new TiempoCargadoPorTeamModel();

            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];
            _model.Periodo = (new PeriodoBL()).ListarPorId(_oficina.periodo_proceso);
            _model.Oficina = _oficina.id_oficina;

            List<TeamEN> lstC = (new TeamsBL()).ListarTodos(_oficina.id_oficina);

            ViewData.Add(TiempoEnProcesoHelper.Constantes.S_TEAM, lstC);

            return View(_model);
        }

        public ActionResult Generate(Models.TiempoCargadoPorTeamModel _model)
        {
            Models.ReportModel _rpt = new ReportModel();
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];            
            _rpt.Data = (new ReportesBL()).Reporte_TiempoCargado_Team(_oficina.id_oficina, _model.Team, _oficina.periodo_proceso);
            return View(_rpt);
        }
    }
}
