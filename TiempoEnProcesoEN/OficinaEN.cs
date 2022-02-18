using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiempoEnProcesoEN
{
    public class OficinaEN
    {
        public string id_oficina { get; set; }
        public string Nombre { get; set; }
        public string direccion { get; set; }
        public string periodo_proceso { get; set; }
        public string id_pais { get; set; }
        public decimal parametro_reportes { get; set; }
        public int Status { get; set; }
        public int permite_facturar_en_periodo { get; set; }
    }
}
