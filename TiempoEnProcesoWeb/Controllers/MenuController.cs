﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiempoEnProcesoWeb.Controllers
{
    public class MenuController : Controller
    {
        public PartialViewResult Menu()
        {
            return PartialView("_Menu", null);
        }

    }
}
