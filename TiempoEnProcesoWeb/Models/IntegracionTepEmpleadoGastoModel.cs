using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoWeb.Models
{
    public class IntegracionTepEmpleadoGastoModel
    {
        public string Pais { set; get; }
        public string Socio { set; get; }
        public string Encargado { set; get; }
        public string Cliente { set; get; }
        public string Servicio { set; get; }

        [Range(1,12, ErrorMessage="Periodo Invalido")]
        public string Periodo { set; get; }

        [Display(Name="Año TEP")]
        public string Anio { set; get; }

        public string Job { set; get; }

        public int EsSocio { get; set; }
        public int EsGerente { get; set; }
        public int EsAdmin { get; set; }

        public string ValSocio { get; set; }
        public string ValEncargado { get; set; }
        public string id_pais { get; set; }
        
    }
}