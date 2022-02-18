using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiempoEnProcesoEN
{
    public class Rpt_BalanceAntEN
    {
        public DateTime fecha { get; set; }
        public string nombre_oficina { get; set; }
        public string id_entidad { get; set; }
        public string jobcompleto { get; set; }
        public string nombre_completo_cliente { get; set; }
        public string DOCUMENTO { get; set; }
        public DateTime fecha1 { get; set; }
        public DateTime fecha_tentativa_cobro { get; set; }
        public decimal valor { get; set; }
        public decimal saldo_impuesto { get; set; }
        public decimal total { get; set; }
        public decimal no_vencido { get; set; }
        public decimal dias_0_30 { get; set; }
        public decimal dias_31_60 { get; set; }
        public decimal dias_61_90 { get; set; }
        public decimal mas_90 { get; set; }
        public string status { get; set; }
        public decimal factura_preliminar { get; set; }
        public decimal factura_definitiva { get; set; }
        public string id_servicio { get; set; }
        public string descripcionservicio { get; set; }
        public string socio { get; set; }
        public string encargado { get; set; }
        public string Cliente_hijo { get; set; }
        public string Id_oficina { get; set; }
    }
    public class Rpt_BalanceAntSubEN
    {
        public DateTime fechaal { get; set; }
        public string descripcionlinea { get; set; }
        public string departamento { get; set; }
        public string servicio { get; set; }
        public string Id_job { get; set; }
        public decimal dias_0_30 { get; set; }
        public decimal dias_31_60 { get; set; }
        public decimal dias_61_90 { get; set; }
        public decimal dias_mas_90 { get; set; }
        public decimal factura_preliminar { get; set; }
        public decimal saldo_impuesto { get; set; }
        public string cliente { get; set; }
        public string tipo_documento { get; set; }
        public decimal numero_documento { get; set; }
        public decimal totalantiguedad { get; set; }
    }

    public class Rpt_BalanceAntSubDefEN
    {
        public DateTime fechaal { get; set; }
        public string descripcionlinea { get; set; }
        public string departamento { get; set; }
        public string servicio { get; set; }
        public string Id_job { get; set; }
        public decimal dias_0_30 { get; set; }
        public decimal dias_31_60 { get; set; }
        public decimal dias_61_90 { get; set; }
        public decimal dias_mas_90 { get; set; }
        public decimal factura_definitiva { get; set; }
        public decimal saldo_impuesto { get; set; }
        public string id_cliente { get; set; }
        public string cliente { get; set; }
        public string tipo_documento { get; set; }
        public decimal numero_documento { get; set; }
        public decimal totalantiguedad { get; set; }
    }
}
