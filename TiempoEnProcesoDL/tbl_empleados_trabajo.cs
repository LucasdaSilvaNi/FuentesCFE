//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TiempoEnProcesoDL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_empleados_trabajo
    {
        public string id_cliente { get; set; }
        public string id_job { get; set; }
        public string id_team { get; set; }
        public string id_pais { get; set; }
        public string id_oficina { get; set; }
        public string id_empleado { get; set; }
        public decimal id { get; set; }
        public Nullable<System.DateTime> fecha_alta_job { get; set; }
        public string fecha_baja_job { get; set; }
        public Nullable<decimal> status { get; set; }
    }
}
