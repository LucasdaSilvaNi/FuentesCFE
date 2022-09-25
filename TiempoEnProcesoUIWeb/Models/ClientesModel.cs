using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiempoEnProcesoUIWeb.Models
{

    public class ClientesModel
    {
        public string id_cliente { get; set; }
        public string razon_social { get; set; }
        public bool status { get; set; }
    }

    public class BusquedaClienteModel
    {
        [Display(Name = "ID Cliente")]
        public string id_cliente { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        public string id_oficina { get; set; }
        public string id_cliente_sel { get; set; }
        public int? pageNo { get; set; }

        public IEnumerable<ClientesModel> clientes { get; set; }

    }
}