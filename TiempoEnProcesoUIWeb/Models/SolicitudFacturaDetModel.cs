using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiempoEnProcesoUIWeb.Models
{
    public class SolicitudFacturaDetModel
    {
        public int id_solicitud { get; set; }

        [Display(Name="Facturar A")]
        public int linea { get; set; }

        public int line_detalle { get; set; }

        [Display(Name = "Concepto")]
        public string conceptoS { get; set; }
        public string concepto { get; set; }

        [Display(Name="Valor (S/Imp)")]
        public decimal valor { get; set; }

        [Display(Name = "Impuesto")]
        public decimal Impuesto { get; set; }

        public decimal Impuesto_por { get; set; }

        public decimal Total { get; set; }

        [Display(Name = "Atencion A")]
        public string Atencion_a { get; set; }

        public bool Es_linea_fiscal { get; set; }

        [Display(Name="Descripcion Comercial")]
        [StringLength(1000)]
        [MaxLength(1000)]
        public string descripcion_comercial { get; set; }

        [Display(Name = "Descripcion")]
        [StringLength(1000)]
        [MaxLength(1000)]
        public string descripcion { get; set; }

        [Display(Name = "Descuento")]
        public decimal Descuento_linea { get; set; }

        [Display(Name = "Local")]
        public decimal Valor_local { get; set; }

        [Display(Name="National ID")]
        public string NationalID { get; set; }


    }
}