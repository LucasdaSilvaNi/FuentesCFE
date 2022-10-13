using System.Web.Mvc;

namespace TiempoEnProcesoUIWeb.Controllers
{
    public class DashBoardController : BaseController
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
