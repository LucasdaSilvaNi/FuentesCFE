using System.Collections.Generic;
using TiempoEnProcesoDL;

namespace TiempoEnProcesoBL.Interfaces.Repository
{
    public interface IClienteRepository
    {
        IEnumerable<TP_lst_Clientes_Result> ListarTodo(string id_oficina);
    }
}