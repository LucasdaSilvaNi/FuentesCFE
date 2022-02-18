using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiempoEnProcesoEN
{
    public class AnulacionDoctoEN
    {
        public string id_entidad { get; set; }
        public decimal total { get; set; }
        public string razon_social { get; set; }
        public string tipo_docto       { get; set; }
        public decimal documento { get; set; }
        public string tipo_docto_descripcion { get; set; }
        public string id_oficina { get; set; }
        public string documento_electronico { get; set; }

        public DateTime Fecha { get; set; }
    }
}
