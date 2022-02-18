using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiempoEnProcesoEN
{
    public class catalogo_entes_legalesEN
    {
        public string id_oficina { get; set; }
        public string id_entidad { get; set; }
        public string Razon_social { get; set; }
        public string Direccion { get; set; }
        public string NIT { get; set; }
        public string correlativo_facturas { get; set; }
        public string correlativo_cobranzas { get; set; }
        public string correlativo_notas { get; set; }
        public string correlativo_anulaciones { get; set; }
        public decimal impuesto { get; set; }
        public decimal incluido { get; set; }
        public string formato_facturas { get; set; }
        public bool financiera { get; set; }

        public string nombre { get; set; }
    }
}
