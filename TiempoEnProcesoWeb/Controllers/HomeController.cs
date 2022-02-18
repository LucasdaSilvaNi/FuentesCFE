using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TiempoEnProcesoEN;


namespace TiempoEnProcesoWeb.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Home()
        {
            return View();

        }

         public PartialViewResult Menu()
         {
             OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];
             

             @ViewData.Add("pais", string.Format("{0}.png",_oficina.id_pais.Trim()));
             return PartialView("_Menu", null);
         }

         public ActionResult Logout()
         {
             FormsAuthentication.SignOut();
             Session.Clear();
             Session.Abandon();
             return RedirectToAction("Login", "Login");
         }
    }
}
