using System.Collections.Generic;
using System.Linq;
using TiempoEnProcesoBL.Interfaces.Repository;
using TiempoEnProcesoDL;

namespace TiempoEnProcesoBL.Repository
{
    public class NoCargableRepository : Repository<tbl_no_cargables_temp>, INoCargableRepository
    {
        public NoCargableRepository(TEPEntities tep) : base(tep)
        {
        }

        public List<tbl_no_cargables_temp> Listar(string id_empleado, string id_oficina)
        {
            return db.tbl_no_cargables_temp.Where(d => d.id_oficina == id_oficina && d.id_empleado == id_empleado).ToList();
        }
    }
}