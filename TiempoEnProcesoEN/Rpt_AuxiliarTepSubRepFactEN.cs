using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiempoEnProcesoEN
{
    public class Rpt_AuxiliarTepSubRepFactEN
    {
        public decimal numero_documento { get; set; }
        public string facturar_en_perido { get; set; }
        public Nullable<System.DateTime> fecha_a_emitir { get; set; }
        public Nullable<int> antiguedad1 { get; set; }
        public Nullable<decimal> factura_preliminar { get; set; }
        public Nullable<decimal> anticipo_aplicar { get; set; }
        public Nullable<decimal> valor_impuesto { get; set; }
        public Nullable<decimal> saldo_impuesto { get; set; }
    }
}
