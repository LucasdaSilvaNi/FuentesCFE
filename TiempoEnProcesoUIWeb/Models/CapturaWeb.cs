using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiempoEnProcesoUIWeb.Models
{
    public class CapturaWebModel
    {
        [Display(Name = "Oficina")]
        public string OficinaEmpleado { get; set; }

        [Display(Name = "Colaborador de Proyecto")]
        public string Empleado { get; set; }

        [Display(Name = "Período Proceso")]
        public string PeriodoProceso { get; set; }

        [Display(Name = "Período")]
        public string PeriodoTEP { get; set; }

        [Display(Name = "Del *")]
        public int DiaDel { get; set; }

        [Display(Name = "Al *")]
        public int DiaAl { get; set; }

        public int TipoCapturaWeb { get; set; }

        [Display(Name = "Oficina")]
        public string Oficina_Busqueda { get; set; }

        [Display(Name = "Cliente")]
        public string ClienteC { get; set; }

        public string NombreClienteC { get; set; }

        [Display(Name = "Servicio")]
        public string ServicioCaptura { get; set; }

        [Display(Name = "Proyecto")]
        public string JobCaptura { set; get; }

        public decimal Horas { get; set; }
        public decimal Gastos { get; set; }

        [Display(Name = "Descripción")]
        public string Trabajo { get; set; }

        [Display(Name = "Descripción *")]
        public string NoCargableTrabajo { get; set; }

        public string Concepto { get; set; }

        public int EsSocio { get; set; }
        public int EsGerente { get; set; }
        public int EsAdmin { get; set; }

        public string ValSocio { get; set; }
        public string ValEncargado { get; set; }

        public IEnumerable<ClientesModel> clientes { get; set; }

        [Display(Name = "Cargable")]
        public decimal TotalCargable { get; set; }

        [Display(Name = "No Cargable")]
        public decimal TotalNoCargable { get; set; }

        [Display(Name = "Suma")]
        public decimal TotalHoras { get; set; }

        [Display(Name = "Gastos")]
        public decimal TotalGastos { get; set; }

         [Display(Name = "Período")]
        public string PeriodoTEPInput { get; set; }

        [Display(Name = "Del")]
        public int DiaDelInput { get; set; }

        [Display(Name = "Al")]
        public int DiaAlInput { get; set; }

        public int VerificaPendientes { get; set; }
        public int VerificaPendientesCliente { get; set; }
        public string id_empleado { get; set; }
        public string id_oficina { get; set; }
        public string  id_pais { get; set; }
        public string periodo_tep_proceso { get; set; }

        [Display(Name="Oficina Captura")]
        public string id_oficina0 { get; set; }

        [Display(Name ="Entidad")]
        public decimal Id_EntidadCaptura { get; set; }

        public IEnumerable<RegistroCargableModel> Cargable { get; set; }
        public IEnumerable<RegistroNoCargableModel> NoCargable { get; set; }
    }
}