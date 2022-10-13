using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using TiempoEnProcesoUIWeb.Extensions;

namespace TiempoEnProcesoUIWeb
{
    // Nota: para obtener instrucciones sobre cómo habilitar el modo clásico de IIS6 o IIS7, 
    // visite http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                SessionUserModel serializeModel = serializer.Deserialize<SessionUserModel>(authTicket.UserData);

                SessionUser newUser = new SessionUser(authTicket.Name);
                newUser.empleado = serializeModel.empleado;
                newUser.oficina = serializeModel.oficina;

                HttpContext.Current.User = newUser;
            }
        }

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
        }
    }
}