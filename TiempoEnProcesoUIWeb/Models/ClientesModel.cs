using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GridMvc;
using GridMvc.DataAnnotations;

namespace TiempoEnProcesoUIWeb.Models
{
    public class ClientesModel
    {
        public string id_cliente { get; set; }
        public string nombre { get; set; }
    }

    public class BusquedaClienteModel
    {
        [Display(Name="ID Cliente")]
        public string id_cliente { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        public string id_oficina { get; set; }
        public string id_cliente_sel { get; set; }
        public int? pageNo { get; set; }

        public IEnumerable<ClientesModel> clientes { get; set; }

    }
}