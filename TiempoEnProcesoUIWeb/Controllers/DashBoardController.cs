using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiempoEnProcesoUIWeb.Controllers
{
    public class DashBoardController : Controller
    {
        //
        // GET: /DashBoard/

        public ActionResult Main()
        {
            return RedirectToAction("Captura", "CapturaWeb");
        }

        public ActionResult Inicio()
        {
            return View();
        }

    }
}
