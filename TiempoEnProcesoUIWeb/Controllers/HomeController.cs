using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TiempoEnProcesoEN;


namespace TiempoEnProcesoUIWeb.Controllers
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
            OficinaEN _oficina = GetOficina();
             

             @ViewData.Add("pais", string.Format("{0}.png",_oficina.id_pais.Trim()));
             @ViewData.Add(TiempoEnProcesoHelper.Constantes.S_TEAM, (new TiempoEnProcesoBL.EmpleadosBL()).AccesoMenusTeam(TiempoEnProcesoHelper.Helper.empleado, _oficina.id_oficina));
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
