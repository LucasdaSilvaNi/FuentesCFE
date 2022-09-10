using System.Collections.Generic;
using TiempoEnProcesoDL;

namespace TiempoEnProcesoBL.Interfaces
{
    public interface IOficinaRepository
    {
        List<tbl_oficina> ListarTodosAtivos();
    }
}