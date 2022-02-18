using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiempoEnProcesoEN
{
    public class IntegracionEmpleadoGastoEN
    {
        public string id_servicio { get; set; }
        public string nombreservicio { get; set; }
        public string cliente { get; set; }
        public string razon_social { get; set; }
        public string descripcion { get; set; }
        public string explicacion { get; set; }
        public string periodo { get; set; }
        public int tipo { get; set; }
        public string orden { get; set; }
        public string codigo { get; set; }
        public decimal ID_JOB { get; set; }
        public string descripcionjob { get; set; }
        public decimal HORAS { get; set; }
        public decimal HONORARIOS { get; set; }
        public decimal gastos { get; set; }
        public string id_oficina { get; set; }
        public string anio { get; set; }
        public string periodoPar { get; set; }
    }
}
