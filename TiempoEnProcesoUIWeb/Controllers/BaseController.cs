using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiempoEnProcesoUIWeb.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.IsDebuggingEnabled)
                ViewBag.Environment = "staging";

            base.OnAuthorization(filterContext);
        }
    }
}
