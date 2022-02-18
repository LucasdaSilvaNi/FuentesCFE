using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiempoEnProcesoEN
{
    public class CapturaHdrEN
    {
        public string id_oficina { get; set; }
        public string id_empleado { get; set; }
        public string periodo_tep_proceso { get; set; }
        public string periodo_tep_corresponde { get; set; }
        public decimal tasa_cambio { get; set; }
        public decimal de_dia { get; set; }
        public decimal a_dia { get; set; }
        public string captado_por { get; set; }
    }
}
