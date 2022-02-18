using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiempoEnProcesoEN
{
    public class FacturasPorSGEN
    {
        public string id_cliente { get; set; }
        public string NOMBRECLIENTE { get; set; }
        public string tipo_documento { get; set; }
        public decimal numero_documento { get; set; }
        public string concepto { get; set; }
        public string id_socio { get; set; }
        public string id_encargado { get; set; }
        public Nullable<decimal> saldo { get; set; }
    }
}
