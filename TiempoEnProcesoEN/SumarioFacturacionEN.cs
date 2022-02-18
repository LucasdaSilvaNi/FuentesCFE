using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiempoEnProcesoEN
{
    public class SumarioFacturacionEN
    {
        public string NOMBRE_OFICINA { get; set; }
        public string PERIODO_TEP { get; set; }
        public decimal realizacion_honorarios { get; set; }
        public decimal realizacion_gastos { get; set; }
        public decimal horas { get; set; }
        public decimal honorarios { get; set; }
        public decimal gastos { get; set; }
        public decimal horas_reporte { get; set; }
        public decimal honorarios_reporte { get; set; }
        public decimal gastos_reporte { get; set; }
        public decimal valor { get; set; }
        public decimal valor_docto { get; set; }
        public decimal totalfacturas_aplicadas { get; set; }
        public decimal aplicaciones_honorarios { get; set; }
        public decimal aplicaciones_gastos { get; set; }
        public string ID_CLIENTE { get; set; }
        public string ID_JOB { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public string ID_SOCIO { get; set; }
        public string NOMBRE_SOCIO { get; set; }
        public string NOMBRE_ENCARGADO { get; set; }
        public string ID_ENCARGADO { get; set; }
        public string DESCRIPCION_JOB { get; set; }
        public string ID_SERVICIO { get; set; }
        public string DESCRIPCION_SERVICIO { get; set; }
        public string DESCRIPCION_DEPTO { get; set; }
        public string NOMBRE_LINEA { get; set; }
        public string TipoReporte { get; set; }
    }
}
