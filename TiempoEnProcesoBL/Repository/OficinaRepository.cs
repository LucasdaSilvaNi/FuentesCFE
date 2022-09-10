using System.Collections.Generic;
using System.Linq;
using TiempoEnProcesoBL.Interfaces;
using TiempoEnProcesoDL;

namespace TiempoEnProcesoBL.Repository
{
    public class OficinaRepository : Repository<tbl_oficina>, IOficinaRepository
    {
        public OficinaRepository(TEPEntities tep) : base(tep)
        {

        }

        public List<tbl_oficina> ListarTodosAtivos()
        {
            return db.tbl_oficina.Where(d => d.Status == 1).ToList();
        }

        public List<tbl_oficina> OficinaEmpleado(string id_empleado)
        {
            return (from emp in db.tbl_empleados
                    join niv in db.tbl_niveles_empleado on emp.id_empleado equals niv.id_empleado
                    join ofi in db.tbl_oficina on niv.id_oficina equals ofi.id_oficina
                    where emp.id_empleado == id_empleado
                    select ofi).ToList();
        }
    }
}