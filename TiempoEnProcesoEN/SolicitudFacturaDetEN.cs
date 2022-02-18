using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiempoEnProcesoEN
{
    public class SolicitudFacturaDetEN
    {
        public int id_solicitud { get; set; }
        public int linea { get; set; }
        public int line_detalle { get; set; }
        public string concepto { get; set; }
        public decimal valor { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Impuesto_por { get; set; }
        public decimal Total { get; set; }
        public string Atencion_a { get; set; }
        public bool Es_linea_fiscal { get; set; }
        public string descripcion_comercial { get; set; }
        public decimal Descuento_linea { get; set; }
        public decimal Valor_local { get; set; }
    }
}
