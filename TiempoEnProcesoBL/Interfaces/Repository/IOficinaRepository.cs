using System.Collections.Generic;
using TiempoEnProcesoDL;

namespace TiempoEnProcesoBL.Interfaces
{
    public interface IOficinaRepository
    {
        IList<tbl_oficina> ListarTodosAtivos();

        IList<tbl_oficina> OficinaEmpleado(string id_empleado);

        tbl_oficina Retorna(string oficina);
    }
}