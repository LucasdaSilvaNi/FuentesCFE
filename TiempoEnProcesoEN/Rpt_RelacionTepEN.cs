using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiempoEnProcesoEN
{
    public class Rpt_RelacionTepEN
    {
        public string grupo { get; set; }
        public string id_pais { get; set; }
        public string codigosocio { get; set; }
        public string codigoencargado { get; set; }
        public string periodo { get; set; }
        public string oficina { get; set; }
        public string socio { get; set; }
        public string encargado { get; set; }
        public string id_cliente { get; set; }
        public string nombre_cliente { get; set; }
        public string descripcionlinea { get; set; }
        public string nombre_departamento { get; set; }
        public string servicio { get; set; }
        public string nombre_servicio { get; set; }
        public string id_job { get; set; }
        public string Descripcion_Job { get; set; }
        public string descripcionjob { get; set; }
        public decimal horas { get; set; }
        public decimal honorarios { get; set; }
        public decimal gastos { get; set; }
        public decimal anticipos_por_aplicar { get; set; }
        public decimal valor_neto { get; set; }
        public decimal saldo_cuenta_corriente { get; set; }
        public string OrdenadoPor { get; set; }
        public string Salta { get; set; }
    }
}
