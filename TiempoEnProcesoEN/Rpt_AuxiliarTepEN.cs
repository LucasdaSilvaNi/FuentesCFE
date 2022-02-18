using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiempoEnProcesoEN
{
    public class Rpt_AuxiliarTepEN
    {
        public string nombreoficina { get; set; }
        public string id_cliente { get; set; }
        public string razon_social { get; set; }
        public string id_servicio { get; set; }
        public string nombreservicio { get; set; }
        public string id_job { get; set; }
        public string descripcionjob { get; set; }
        public string id_empleado { get; set; }
        public string nombreempleado { get; set; }
        public string id_socio { get; set; }
        public string nombresocio { get; set; }
        public string id_encargado { get; set; }
        public string nombreencargado { get; set; }
        public decimal horas { get; set; }
        public decimal honorarios { get; set; }
        public decimal gastos { get; set; }
        public decimal horas_no_autorizadas { get; set; }
        public decimal honorarios_no_autorizadas { get; set; }
        public decimal gastos_no_autorizadas { get; set; }
    }

    public class Rpt_AuxiliarTepSubRepEN
    {
        public string GRUPO { get; set; }
        public Nullable<int> realizacion_esperada { get; set; }
        public Nullable<decimal> horas_contratadas { get; set; }
        public Nullable<decimal> honorarios_contratados { get; set; }
        public Nullable<decimal> gastos_contratados { get; set; }
        public decimal anticipo_aplicar { get; set; }
        public decimal factura_preliminar { get; set; }
        public decimal credito_horas { get; set; }
        public decimal credito_honorarios { get; set; }
        public Nullable<decimal> credito_gastos { get; set; }
        public decimal anticipos_aplicados { get; set; }
        public decimal factura_preliminar_aplicada { get; set; }
    }
}
