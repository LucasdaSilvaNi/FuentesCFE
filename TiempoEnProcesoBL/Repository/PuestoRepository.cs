using System.Linq;
using TiempoEnProcesoBL.Interfaces.Repository;
using TiempoEnProcesoDL;

namespace TiempoEnProcesoBL.Repository
{
    public class PuestoRepository : Repository<tbl_puestos>, IPuestoRepository
    {
        public PuestoRepository(TEPEntities tep) : base(tep)
        {

        }

        public tbl_puestos RetornaPuestoEnConversionWeb(string _puesto)
        {
            return db.tbl_puestos.FirstOrDefault(d => d.id_puesto == _puesto).tbl_puestos1.FirstOrDefault();
        }
    }
}