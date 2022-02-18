using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoWeb.Models
{
    public class InformeFacturacionModel
    {

        public string Socio { set; get; }
        public string Encargado { set; get; }

        [Display(Name = "Del Mes")]
        public string Mes { get; set; }

        [Display(Name = "Al Mes")]
        public string Mes1 { get; set; }

        [Required]
        [Display(Name = "Período TEP")]
        [StringLength(4)]
        public string Anio { get; set; }

        public int EsSocio { get; set; }
        public int EsGerente { get; set; }
        public int EsAdmin { get; set; }

        public string ValSocio { get; set; }
        public string ValEncargado { get; set; }
    }
}