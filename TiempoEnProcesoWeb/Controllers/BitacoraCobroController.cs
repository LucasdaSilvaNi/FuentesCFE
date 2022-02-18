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
    public class BitacoraCobroController : Controller
    {
        //
        // GET: /AuxiliarTep/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Parameters()
        {
            BitacoraCobroModel _model = new BitacoraCobroModel();
            _model.SocioBitacora = TiempoEnProcesoHelper.Constantes.S_TODOS;
            _model.EncargadoBitacora = TiempoEnProcesoHelper.Constantes.S_TODOS;

            EmpleadoEN _empleado = (EmpleadoEN)Session[TiempoEnProcesoHelper.Constantes.S_EMPLEADO];
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];
            string _puesto = Session[TiempoEnProcesoHelper.Constantes.S_PUESTO].ToString();

            _model.EsGerente = _puesto == TiempoEnProcesoHelper.Constantes.GERENTE ? 1 : 0; 
            _model.EsSocio = _puesto == TiempoEnProcesoHelper.Constantes.SOCIO ? 1 : 0;

            if (_model.EsSocio==1)
            {
                _model.SocioBitacora = _empleado.id_empleado;
                _model.EncargadoBitacora = TiempoEnProcesoHelper.Constantes.S_TODOS;
            }

            if (_model.EsGerente==1)
            {
                _model.EncargadoBitacora = _empleado.id_empleado;
                _model.SocioBitacora = TiempoEnProcesoHelper.Constantes.S_TODOS;
            }

            return View(_model);
        }

        public ActionResult Generate(Models.BitacoraCobroModel _model)
        {
            Models.ReportModel _rpt = new ReportModel();
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];
            EmpleadoEN _empleado = (EmpleadoEN)Session[TiempoEnProcesoHelper.Constantes.S_EMPLEADO];
            TiempoEnProcesoHelper.Helper.Oficina = _oficina.id_oficina;

            _rpt.Data = (new ReportesBL()).Reporte_BitacoraCobro(_model.SocioBitacora, _model.EncargadoBitacora, _model.Imprime);         

            return View(_rpt);
        }
    }
}
