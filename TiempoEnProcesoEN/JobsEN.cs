using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiempoEnProcesoEN
{
    public class JobsEN
    {
        public string id_job { get; set; }
        public string descripcion { get; set; }
        public string  id_cliente { get; set; }
        public string id_servicio { get; set; }
    }

    public class JobsExtEN : JobsEN
    {
        public string id_propuesta { get; set; }
    }
}
