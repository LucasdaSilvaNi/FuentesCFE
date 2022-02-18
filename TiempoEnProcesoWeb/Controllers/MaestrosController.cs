using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiempoEnProcesoBL;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoWeb.Controllers
{
    public class MaestrosController : Controller
    {
        //
        // GET: /Maestros/

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult EncargadosGet(string id_socio)
        {
            EmpleadoEN _empleado = (EmpleadoEN)Session[TiempoEnProcesoHelper.Constantes.S_EMPLEADO];
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];

            return Json((new EncargadoBL()).ListarTodosxEmpleado(id_socio, _empleado.id_empleado, _empleado.id_oficina, _oficina.id_pais, _empleado.id_puesto), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ClientesGet(string id_socio, string id_encargado)
        {
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];

            return Json((new ClientesBL()).ListarTodosxEmpleado(id_socio, id_encargado, _oficina.id_oficina), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ServiciosGet(string id_cliente, string id_socio, string id_encargado)
        {
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];

            return Json((new ServicioBL()).ListarTodos(id_cliente, id_socio, id_encargado, _oficina.id_oficina), JsonRequestBehavior.AllowGet);
        }

        public ActionResult JobsGet(string id_cliente, string id_socio, string id_encargado, string id_servicio, string id_pais)
        {
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];
            return Json((new JobsBL()).ListarTodos(id_cliente, id_socio, id_encargado, id_servicio, _oficina.id_oficina, false), JsonRequestBehavior.AllowGet);
        }

        /*CASCADA INVERSA*/
        public ActionResult Socios_Encargado(string id_encargado)
        {
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];
            EmpleadoEN _empleado = (EmpleadoEN)Session[TiempoEnProcesoHelper.Constantes.S_EMPLEADO];
            return Json((new SocioBL()).ListaTodosxEncargado(_empleado.id_empleado,  _oficina.id_oficina, _oficina.id_pais, id_encargado, _empleado.id_puesto), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Encargado_Cliente(string id_cliente)
        {
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];
            EmpleadoEN _empleado = (EmpleadoEN)Session[TiempoEnProcesoHelper.Constantes.S_EMPLEADO];
            return Json((new EncargadoBL()).ListaTodosxCliente(_empleado.id_empleado, _oficina.id_oficina, _oficina.id_pais, _empleado.id_puesto, id_cliente), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Cliente_Servicio(string id_servicio)
        {
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];
            EmpleadoEN _empleado = (EmpleadoEN)Session[TiempoEnProcesoHelper.Constantes.S_EMPLEADO];
            return Json((new ClientesBL()).ListaTodosxServicio(_oficina.id_oficina, _oficina.id_pais, id_servicio), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Servicio_Job(string id_job)
        {
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];
            EmpleadoEN _empleado = (EmpleadoEN)Session[TiempoEnProcesoHelper.Constantes.S_EMPLEADO];
            return Json((new ServicioBL()).ListaTodosxJob(_empleado.id_empleado, _oficina.id_oficina, _oficina.id_pais, id_job), JsonRequestBehavior.AllowGet);
        }
    }
}
