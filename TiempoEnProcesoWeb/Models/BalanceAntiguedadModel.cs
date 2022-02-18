using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoWeb.Models
{
    public class BalanceAntiguedadModel
    {
        public string Fecha { get; set; }
        public string Socio { set; get; }
        public string Encargado { set; get; }

        public int EsSocio { get; set; }
        public int EsGerente { get; set; }
        public int EsAdmin { get; set; }

        public string ValSocio { get; set; }
        public string ValEncargado { get; set; }
    }
}