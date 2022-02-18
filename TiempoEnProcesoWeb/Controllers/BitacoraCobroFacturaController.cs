using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiempoEnProcesoWeb.Models;
using TiempoEnProcesoEN;
using TiempoEnProcesoBL;
using TiempoEnProcesoHelper;

namespace TiempoEnProcesoWeb.Controllers
{
    public class BitacoraCobroFacturaController : Controller
    {
        //
        // GET: /AuxiliarTep/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Parameters()
        {
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];

            BitacoraCobroFacturaModel _model = new BitacoraCobroFacturaModel();
            ViewData.Add(Constantes.S_ENTIDAD_LEGAL, (new EntidadLegalBL()).Listar(_oficina.id_oficina));

            return View(_model);
        }

        public ActionResult ParametersAdv()
        {
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];

            BitacoraCobroFacturaModel _model = new BitacoraCobroFacturaModel();

            EmpleadoEN _empleado = (EmpleadoEN)Session[TiempoEnProcesoHelper.Constantes.S_EMPLEADO];
            string _puesto = Session[TiempoEnProcesoHelper.Constantes.S_PUESTO].ToString();

            _model.EsGerente = _puesto == TiempoEnProcesoHelper.Constantes.GERENTE;
            _model.EsSocio = _puesto == TiempoEnProcesoHelper.Constantes.SOCIO ;

            ViewData.Add(Constantes.S_ENTIDAD_LEGAL, (new EntidadLegalBL()).Listar(_oficina.id_oficina));

            return View(_model);
        }

        public ActionResult Generate(Models.BitacoraCobroFacturaModel _model)
        {
            Models.ReportModel _rpt = new ReportModel();
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];
            EmpleadoEN _empleado = (EmpleadoEN)Session[TiempoEnProcesoHelper.Constantes.S_EMPLEADO];
            TiempoEnProcesoHelper.Helper.Oficina = _oficina.id_oficina;

            _rpt.Data = (new ReportesBL()).Reporte_BitacoraCobroFactura(_model.id_entidad.PadLeft(2,'0'), _model.NoFactura);         

            return View(_rpt);
        }

        public ActionResult DatosFiltrados( bool EsSocio, bool EsGerente, string id_entidad)
        {
            EmpleadoEN _empleado = (EmpleadoEN)Session[TiempoEnProcesoHelper.Constantes.S_EMPLEADO];
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];

            string id_socio = EsSocio? _empleado.id_empleado: Constantes.S_TODOS;
            string id_gerente = EsGerente ? _empleado.id_empleado : Constantes.S_TODOS;
            
            List<FacturasPorSGEN> lst = (new ReportesBL()).ObtieneFacturasSocio(id_socio, id_gerente, id_entidad, _oficina.id_oficina);

            return PartialView("_DatosFiltrados", lst.AsEnumerable<FacturasPorSGEN>());
        }
    }
}
