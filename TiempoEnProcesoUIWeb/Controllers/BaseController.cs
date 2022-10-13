using System;
using System.Web.Mvc;
using TiempoEnProcesoEN;
using TiempoEnProcesoUIWeb.Extensions;

namespace TiempoEnProcesoUIWeb.Controllers
{
    public class BaseController : Controller
    {
        private SessionUser user;

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            if (User.Identity.IsAuthenticated)
            {
                user = (User as SessionUser);
                Session.Add(TiempoEnProcesoHelper.Constantes.S_EMPLEADO, user.empleado);
                Session.Add(TiempoEnProcesoHelper.Constantes.S_OFICINA, user.oficina);
            }

            return base.BeginExecuteCore(callback, state);
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.IsDebuggingEnabled)
                ViewBag.Environment = "staging";

            base.OnAuthorization(filterContext);
        }

        protected EmpleadoEN GetEmpleado()
        {
            return user.empleado;
        }

        protected OficinaEN GetOficina()
        {
            return user.oficina;
        }
    }
}
