using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiempoEnProcesoUIWeb.Models
{
    public class TeamAcumuladoModel
    {
        [Display(Name = "Clave Actual")]
        public string id_team { get; set; }
    }
}