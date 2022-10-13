using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiempoEnProcesoBL;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoUIWeb.Controllers
{
    public class MaestrosController : BaseController
    {
        //
        // GET: /Maestros/

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult EncargadosGet(string id_socio)
        {
            EmpleadoEN _empleado = GetEmpleado();
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA0];

            return Json((new EncargadoBL()).ListarTodosxEmpleado(id_socio, _empleado.id_empleado, _empleado.id_oficina, _oficina.id_pais, _empleado.id_puesto), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ClientesGet(string id_socio, string id_encargado)
        {
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA0];

            return Json((new ClientesBL()).ListarTodosxEmpleado(id_socio, id_encargado, _oficina.id_oficina), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ServiciosGet(string id_cliente, string id_socio, string id_encargado)
        {
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA0];

            return Json((new ServicioBL()).ListarTodos(id_cliente, id_socio, id_encargado, _oficina.id_oficina), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ServiciosGetDepto(string id_cliente, string id_socio, string id_encargado)
        {
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA0];
            EmpleadoEN _empleado = GetEmpleado();
            List<ServicioEN> lst = (new ServicioBL()).ListarTodos(id_cliente, id_socio, id_encargado, _oficina.id_oficina, _empleado.id_departamento);
            lst.ForEach(d => d.Nombre_largo = string.Format("{0}-{1}", d.id_servicio.Trim(), d.Nombre_largo.Trim()));

            lst.Insert(0, (new ServicioEN()
            {
                id_servicio = "-1",
                Nombre_largo = ""
            }));

            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JobsGetDepto(string id_cliente, string id_socio, string id_encargado, string id_servicio, string todos)
        {
            EmpleadoEN _empleado = GetEmpleado();
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA0];
            List<JobsEN> lst = (new JobsBL()).ListarTodosOficina(id_cliente, id_socio, id_encargado, id_servicio, todos != TiempoEnProcesoHelper.Constantes.S_TODOS, _oficina.id_oficina);
            lst.ForEach(d => d.descripcion = string.Format("{0}-{1}", d.id_job.Trim(), d.descripcion.Trim()));
            lst.Insert(0, (new JobsEN()
            {
                id_servicio = "-1",
                descripcion = "",
                id_job = "-1"
            }));

            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JobsGet(string id_cliente, string id_socio, string id_encargado, string id_servicio, string id_pais)
        {
            OficinaEN _oficina = GetOficina();
            return Json((new JobsBL()).ListarTodos(id_cliente, id_socio, id_encargado, id_servicio, _oficina.id_oficina), JsonRequestBehavior.AllowGet);
        }

        public ActionResult JobsTodosGet(string id_cliente, string id_socio, string id_encargado, string id_servicio, string todos, string id_pais)
        {
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA0];
            return Json((new JobsBL()).ListarTodos(id_cliente, id_socio, id_encargado, id_servicio, _oficina.id_oficina, todos != TiempoEnProcesoHelper.Constantes.S_TODOS), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ServiciosTodosGet(string id_cliente, string id_socio, string id_encargado, string todos)
        {
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA0];
            List<ServicioEN> lst = (new ServicioBL()).ListarTodos(id_cliente, id_socio ?? TiempoEnProcesoHelper.Constantes.S_TODOS, id_encargado ?? TiempoEnProcesoHelper.Constantes.S_TODOS, _oficina.id_oficina, todos != TiempoEnProcesoHelper.Constantes.S_TODOS);
            lst.ForEach(d => d.Nombre_largo = string.Format("{0}-{1}", d.id_servicio.Trim(), d.Nombre_largo.Trim()));
            lst.Insert(0, (new ServicioEN()
            {
                id_servicio = "-1",
                Nombre_largo = ""
            }));
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        /*CASCADA INVERSA*/
        public ActionResult Socios_Encargado(string id_encargado)
        {
            OficinaEN _oficina = GetOficina();
            EmpleadoEN _empleado = GetEmpleado();
            return Json((new SocioBL()).ListaTodosxEncargado(_empleado.id_empleado, _oficina.id_oficina, _oficina.id_pais, id_encargado, _empleado.id_puesto), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Encargado_Cliente(string id_cliente)
        {
            OficinaEN _oficina = GetOficina();
            EmpleadoEN _empleado = GetEmpleado();
            return Json((new EncargadoBL()).ListaTodosxCliente(_empleado.id_empleado, _oficina.id_oficina, _oficina.id_pais, _empleado.id_puesto, id_cliente), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Cliente_Servicio(string id_servicio)
        {
            OficinaEN _oficina = GetOficina();
            EmpleadoEN _empleado = GetEmpleado();
            return Json((new ClientesBL()).ListaTodosxServicio(_oficina.id_oficina, _oficina.id_pais, id_servicio), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Servicio_Job(string id_job)
        {
            OficinaEN _oficina = GetOficina();
            EmpleadoEN _empleado = GetEmpleado();
            return Json((new ServicioBL()).ListaTodosxJob(_empleado.id_empleado, _oficina.id_oficina, _oficina.id_pais, id_job), JsonRequestBehavior.AllowGet);
        }

        public ActionResult EntidadesClienteGet(string id_cliente)
        {
            OficinaEN _oficina = GetOficina();
            return Json((new ClientesBL()).ListarEntidades(_oficina.id_pais, id_cliente), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DatosEntidadCliente(string id_cliente, string id_entidad)
        {
            OficinaEN _oficina = GetOficina();
            EntidadEN _entidad = (new ClientesBL()).ListarEntidades(_oficina.id_pais, id_cliente).FirstOrDefault(d => d.id == id_entidad);
            return Json(_entidad, JsonRequestBehavior.AllowGet);

        }
        public ActionResult DatosEntidadLegal(string id_entidad)
        {
            OficinaEN _oficina = GetOficina();
            EntidadLegalEN _ent = (new EntidadLegalBL()).Listar(_oficina.id_oficina).FirstOrDefault(d => d.id_entidad == id_entidad);

            return Json(_ent, JsonRequestBehavior.AllowGet);
        }
    }
}