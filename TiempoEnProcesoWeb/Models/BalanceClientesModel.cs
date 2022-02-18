using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoWeb.Models
{
    public class BalanceClientesModel
    {
        public string Pais { set; get; }
        public string Socio { set; get; }
        public string Encargado { set; get; }
        public string Cliente { set; get; }
        public string Fecha { get; set; }

        public int EsSocio { get; set; }
        public int EsGerente { get; set; }
        public int EsAdmin { get; set; }

        public string ValSocio { get; set; }
        public string ValEncargado { get; set; }
        
    }
}