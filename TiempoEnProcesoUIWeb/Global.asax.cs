using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TiempoEnProcesoUIWeb
{
    // Nota: para obtener instrucciones sobre cómo habilitar el modo clásico de IIS6 o IIS7, 
    // visite http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Bootstrapper.Initialise();

            MapeoModel.Run();

        }

        protected void Session_Start()
        {
            TiempoEnProcesoHelper.Helper.Inicializa();

            if (User.Identity.IsAuthenticated &&
                Session[TiempoEnProcesoHelper.Constantes.S_EMPLEADO] == null)
            {
                TiempoEnProcesoBL.EmpleadosBL _empBL = new TiempoEnProcesoBL.EmpleadosBL();
                TiempoEnProcesoEN.EmpleadoEN _empleado = _empBL.DevuelveDatos(User.Identity.Name);

                TiempoEnProcesoHelper.Helper.empleado = _empleado.id_empleado;


                if (_empleado != null)
                {
                     Session.Add(TiempoEnProcesoHelper.Constantes.S_EMPLEADO, _empleado);
                     Session.Add(TiempoEnProcesoHelper.Constantes.S_OFICINA, (new TiempoEnProcesoBL.OficinaBL()).DevuelveDatos(_empleado.id_oficina));
                     //Session.Add(TiempoEnProcesoHelper.Constantes.S_PUESTO, (new TiempoEnProcesoBL.PuestosBL()).PuestoWeb(_empleado.id_puesto));
                }
            }
        }
    }
}