using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiempoEnProcesoEN
{
    public class InformeFacturacionEN
    {
        public string id_socio { get; set; }
        public string id_encargado { get; set; }
        public string id_servicio { get; set; }
        public string nombreservicio { get; set; }
        public string Id_oficina { get; set; }
        public string nombreoficina { get; set; }
        public string Id_entidad { get; set; }
        public string tipo_documento { get; set; }
        public decimal numero_documento { get; set; }
        public DateTime FECHA { get; set; }
        public string id_cliente { get; set; }
        public string razon_social { get; set; }
        public string id_job { get; set; }
        public string descripcionjob { get; set; }
        public decimal honorarios { get; set; }
        public decimal valor_impuesto { get; set; }
        public decimal totalfactura { get; set; }
        public decimal totalcobrado { get; set; }
        public string Mes { get; set; }
        public string Mes1 { get; set; }
        public string Anio { get; set; }
    }
}
