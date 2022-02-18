using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoWeb.Models
{
    public class ReportModel
    {
        public DataTable Data { get; set; }
        public DataTable DataOfi { get; set; }
        public bool EsSocio { get; set; }
    }

   
}