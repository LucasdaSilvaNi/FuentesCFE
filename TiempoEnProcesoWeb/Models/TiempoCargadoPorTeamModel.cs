using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoWeb.Models
{
    public class TiempoCargadoPorTeamModel
    {

       
        [Display(Name = "Período TEP")]
        public string Periodo { get; set; }

        [Display(Name = "Team")]
        public string Team { get; set; }

        [Display(Name = "Oficina")]
        public string Oficina { get; set; }
    }
}