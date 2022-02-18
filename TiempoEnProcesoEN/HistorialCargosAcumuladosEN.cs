using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiempoEnProcesoEN
{
    public class HistorialCargosAcumuladosEmpleadoEN
    {
        public string id_oficina { get; set; }
        public int ordenimpresion { get; set; }
        public string id_servicio { get; set; }
        public string nombre_largo { get; set; }
        public string nombrecompleto { get; set; }
        public string cliente { get; set; }
        public string job { get; set; }
        public decimal horas { get; set; }
        public decimal honorarios { get; set; }
        public decimal gastos { get; set; }
        public string periodo { get; set; }
    }

    public class HistorialCargosAcumuladosEmpleadoSubEN
    {
        public int ordenimpresion { get; set; }
        public string id_empleado { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string linea { get; set; }
        public string producto { get; set; }
        public string nombre_largo { get; set; }
        public decimal horas { get; set; }
        public decimal honorarios { get; set; }
        public decimal gastos { get; set; }
        public string periodo { get; set; }
    }

    public class HistorialCargosAcumuladosClienteEN
    {
        public string id_oficina { get; set; }
        public int ordenimpresion { get; set; }
        public string id_servicio { get; set; }
        public string id_job { get; set; }
        public string descripcion { get; set; }
        public string nombre_largo { get; set; }
        public string nombrecompleto { get; set; }
        public string cliente { get; set; }
        public decimal horas { get; set; }
        public decimal honorarios { get; set; }
        public decimal gastos { get; set; }
        public string periodo { get; set; }
    }

    public class HistorialCargosAcumuladosClienteSubEN
    {
        public string id_grupos { get; set; }
        public string linea { get; set; }
        public string id_departamento { get; set; }
        public string producto { get; set; }
        public string id_servicio { get; set; }
        public string nombre_largo { get; set; }
        public decimal horas { get; set; }
        public decimal honorarios { get; set; }
        public decimal gastos { get; set; }
    }
}
