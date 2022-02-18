using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiempoEnProcesoEN
{
    public class SolicitudFacturaEN
    {
        public decimal id_solicitud { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string situacion { get; set; }
        public string id_oficina { get; set; }
        public string id_empleado { get; set; }
        public string id_job { get; set; }
        public string id_cliente { get; set; }
        public Nullable<System.DateTime> fecha_a_emitir { get; set; }
        public string instrucciones { get; set; }
        public string id_entidad { get; set; }
        public string facturar_en_perido { get; set; }
        public Nullable<int> estado { get; set; }
        public string tipo_entrega { get; set; }
        public Nullable<decimal> total_solicitud { get; set; }
        public Nullable<System.DateTime> fecha_tentativa_cobro { get; set; }
        public string elaborado { get; set; }
        public Nullable<decimal> tasa_cambio { get; set; }
        public Nullable<decimal> total_solicitud_moneda_local { get; set; }
        public Nullable<int> Imprime_Moneda_Tep { get; set; }
        public string codigo_moneda_impresion { get; set; }
        public Nullable<bool> Lenguaje_impresion_spanish { get; set; }
        public Nullable<decimal> Tasa_cambio_fiscal { get; set; }
        public string id_servicio { set; get; }
    }
}
