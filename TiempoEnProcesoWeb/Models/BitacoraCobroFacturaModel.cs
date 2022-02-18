using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoWeb.Models
{
    public class BitacoraCobroFacturaModel
    {

        [Display(Name="Entidad")]
        public string id_entidad { get; set; }

        [Display(Name = "Factura")]
        public int NoFactura { get; set; }

        public bool EsSocio { get; set; }
        public bool EsGerente { get; set; }
    }
}