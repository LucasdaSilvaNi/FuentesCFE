using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiempoEnProcesoEN
{
    public class EmpleadoEN
    {
        public string id_oficina { get; set; }
        public string id_empleado { get; set; }
        public string iniciales { get; set; }
        public string id_puesto { get; set; }
        public string id_departamento { get; set; }
        public string Nombres { get; set; }
        public string apellidos { get; set; }
        public decimal cuota_facturacion_local { get; set; }
        public decimal cuota_facturacion_interamerica { get; set; }
        public string situacion_actual { get; set; }
        public string ultimo_reporte_entregado { get; set; }
        public string clave { get; set; }
        public decimal presupuesto_horas { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public decimal usuario_administrativo { get; set; }
        public string id_team { get; set; }
        public string cem_costo { get; set; }
        public DateTime ultima_fecha_pass { get; set; }
        public bool logged { get; set; }
        public List<PuestoEN> Puestos { get; set; }

        public string nombrecompleto { get; set; }
        public string  FE_Token { get; set; }
        public DateTime? Fecha_Hora_Expira_Token { get; set; }
    }
}
