using System.Linq;
using TiempoEnProcesoBL.Interfaces;
using TiempoEnProcesoDL;

namespace TiempoEnProcesoBL.Repository
{
    public class ParametrosRepository : Repository<tbl_empleados>, IParametrosRepository
    {
        public ParametrosRepository(TEPEntities tep) : base(tep)
        {

        }

        public tbl_parametros ObterValorNumerico(string id_parametro)
        {
            return db.tbl_parametros.FirstOrDefault(d => d.id_parametro == id_parametro);
        }
    }
}