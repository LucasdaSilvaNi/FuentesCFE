using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoWeb.Models
{
    public class HistorialCargosAcumuladosModel
    {

        [Display(Name="Tipo Reporte")]
        public int Tipo_HistorialCargosAcumulados { get; set; }

        [Display(Name = "Empleado")]
        public string Empleado_HistorialCargosAcumulados { get; set; }

        [Display(Name = "Cliente")]
        public string Cliente_HistorialCargosAcumulados { get; set; }
        [Display(Name = "Período TEP")]
        public string Periodo { get; set; }

        public string valEmpleado_HistorialCargosAcumulados { get; set; }
        public string valCliente_HistorialCargosAcumulados { get; set; }

    }
}