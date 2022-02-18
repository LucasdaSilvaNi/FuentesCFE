using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiempoEnProcesoUIWeb.Models
{
    public class CambioClaveModel
    {
        [Required(ErrorMessage = "Ingrese clave actual")]
        [Display(Name="Clave Actual")]
        public string PasswordActual { get; set; }

        [Required(ErrorMessage = "Ingrese clave Nueva")]
        [Display(Name = "Clave Nueva")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Ingrese clave Nueva")]
        [Display(Name = "Confirmación")]
        public string ConfPassword { get; set; }

        public string id_empleado { get; set; }
        
    }
}