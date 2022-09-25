using System.Web.Mvc;

namespace TiempoEnProcesoUIWeb.Controllers
{
    public class MenuController : Controller
    {
        public PartialViewResult Menu()
        {
            return PartialView("_Menu", null);
        }

    }
}