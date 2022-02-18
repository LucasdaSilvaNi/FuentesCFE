using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoWeb.Models
{
    public class BitacoraCobroModel
    {

        public string SocioBitacora { set; get; }
        public string EncargadoBitacora { set; get; }

        public int EsSocio { get; set; }
        public int EsGerente { get; set; }

        [Display(Name = "Imprimir solo Facturas con Observaciones")]
        public bool Imprime { get; set; }
    }
}