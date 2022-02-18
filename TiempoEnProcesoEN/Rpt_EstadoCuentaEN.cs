using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiempoEnProcesoEN
{
    public class Rpt_EstadoCuentaEN
    {
        public string ID_OFICINA { get; set; }
        public string id_cliente { get; set; }
        public string razon_social { get; set; }
        public string ID_ENTIDAD { get; set; }
        public string TIPO_DOCUMENTO { get; set; }
        public decimal NUMERO_DOCUMENTO { get; set; }
        public string id_job { get; set; }
        public string descripcion { get; set; }
        public string documento_aplicado { get; set; }
        public string id_servicio { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public int orden { get; set; }
        public string concepto { get; set; }
        public string DOCUMENTO_COBRO { get; set; }
        public Nullable<decimal> cargos { get; set; }
        public Nullable<decimal> abonos { get; set; }
        public Nullable<decimal> saldo { get; set; }
        public Nullable<decimal> id_solicitud { get; set; }
        public string ente_cliente { get; set; }
        public string nombre_servicio { get; set; }
    }
}
