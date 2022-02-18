using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiempoEnProcesoUIWeb.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter a valid User Name.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Please enter a valid Password.")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        public bool Error { get; set; }
    }
}