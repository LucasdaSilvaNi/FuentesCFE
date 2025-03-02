﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiempoEnProcesoEN
{
    public class Rpt_Tiempo_Por_Team
    {
        public string ORDEN { get; set; }
        public string OFICINA_EMPLEADO { get; set; }
        public string ID_EMPLEADO { get; set; }
        public string OFICINA_CARGO { get; set; }
        public string NOMBRES { get; set; }
        public string periodo_tep_proceso { get; set; }
        public string PERIODO_TEP_CORRESPONDE { get; set; }
        public string DIAS { get; set; }
        public Nullable<decimal> de_dia { get; set; }
        public string ID_CLIENTE { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public string JOB { get; set; }
        public string DESCRIPCION_CARGO { get; set; }
        public decimal horas { get; set; }
        public Nullable<decimal> gastos { get; set; }
        public decimal horasxautencargado { get; set; }
        public decimal horasxautorizar { get; set; }
        public decimal gastoscaptadosweb { get; set; }
        public string Team { get; set; }
    }
}
