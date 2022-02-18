using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiempoEnProcesoEN
{
    public class AnulacionSolicitudEN
    {
        public decimal id_solicitud { get; set; }
        public decimal total_solicitud { get; set; }
        public string razon_social { get; set; }
        public string descripcion { get; set; }
        public string id_oficina { get; set; }

        public DateTime Fecha { get; set; }
    }
}
