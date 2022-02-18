using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiempoEnProcesoUIWeb.Models
{
    public class SolicitudFacturaModel
    {
        public decimal id_solicitud_captura { get; set; }

        [Display(Name = "Oficina")]
        public string id_oficina { get; set; }

        public string id_empleado { get; set; }
        public string Job { get; set; }
        public string Cliente { get; set; }

        [Display(Name="Facturar De")]
        public string id_entidad { get; set; }

        [Display(Name = "Fecha a Emitir")]
        public DateTime fecha_a_emitir { get; set; }

        [Display(Name = "Observaciones")]
        [StringLength(100)]
        [MaxLength(100)]
        public string instrucciones { get; set; }

        [Display(Name = "Facturar")]
        public string facturar_en_perido { get; set; }

        public int estado { get; set; }

        [Display(Name="Tipo Solicitud")]
        public string tipo_entrega { get; set; }

        [Display(Name = "Total Solicitud")]
        public decimal total_solicitud { get; set; }

        [Display(Name = "Fecha Tentativa Cobro")]
        public DateTime fecha_tentativa_cobro { get; set; }

        [Display(Name = "Fecha Solicitud")]
        public DateTime fecha_solicitud { get; set; }

        public string elaborado { get; set; }

        [Display(Name = "Tasa Cambio")]
        public decimal tasa_cambio { get; set; }
        public decimal tasa_cambio_D { get; set; }

        [Display(Name = "Total Local")]
        public Nullable<decimal> total_solicitud_moneda_local { get; set; }

        [Display(Name="Factura en")]
        public Nullable<int> Imprime_Moneda_Tep { get; set; }

        [Display(Name = "Moneda Impresion")]
        public string codigo_moneda_impresion { get; set; }

        [Display(Name = "Idioma Impresion")]
        public int Lenguaje_impresion_spanish { get; set; }

        [Display(Name = "Tasa Cambio Fiscal")]
        public decimal Tasa_cambio_fiscal { get; set; }

        public string Servicio { set; get; }
        public string id_cliente { get; set; }
        public string id_entidad_D { get; set; }

        public string Oficina { get; set; }

        public SolicitudFacturaDetModel Detalle { get; set; }
    }
}