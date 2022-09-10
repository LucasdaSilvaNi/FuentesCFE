using System.Collections.Generic;
using TiempoEnProcesoDL;

namespace TiempoEnProcesoBL.Interfaces
{
    public interface IConceptosRepository
    {
        List<tbl_concepto_no_cargable> ListarTodosAtivos();
    }
}