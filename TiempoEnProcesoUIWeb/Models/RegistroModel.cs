using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiempoEnProcesoUIWeb.Models
{
    public class RegistroCargableModel
    {
        public string id_oficina { get; set; }
        public decimal linea { get; set; }
        public decimal horas { get; set; }
        public decimal honorarios { get; set; }
        public decimal gastos { get; set; }
        public decimal cuota_facturacion { get; set; }
        public string id_job { get; set; }
        public string descripcion_cargo { get; set; }
        public string id_oficina0 { get; set; }
        public string id_empleado { get; set; }
        public string id_cliente { get; set; }
        public int tipo { get; set; }

        public string oficina { get; set; }
        public string cliente { get; set; }
        public string job { get; set; }
    }
    public class RegistroNoCargableModel
    {
        public string id_oficina { get; set; }
        public string id_empleado { get; set; }
        public decimal linea { get; set; }
        public string id_concepto { get; set; }
        public decimal horas { get; set; }
        public string descripcion { get; set; }
        public decimal horasporautorizar { get; set; }
        public decimal horasrechazadas { get; set; }

        public string oficina { get; set; }
        public string concepto { get; set; }
    }

    public class RegistroPntModel
    {
        public IEnumerable<RegistroCargableModel> Cargable { get; set; }
        public IEnumerable<RegistroNoCargableModel> NoCargable { get; set; }
    }
}