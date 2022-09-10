using System.Collections.Generic;
using TiempoEnProcesoDL;

namespace TiempoEnProcesoBL.Interfaces.Repository
{
    public interface INoCargableRepository
    {
        List<tbl_no_cargables_temp> Listar(string id_empleado, string id_oficina);
    }
}