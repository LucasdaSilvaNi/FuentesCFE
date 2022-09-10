using System.Collections.Generic;
using System.Linq;
using TiempoEnProcesoBL.Interfaces;
using TiempoEnProcesoDL;

namespace TiempoEnProcesoBL.Repository
{
    public class ConceptosRepository : Repository<tbl_concepto_no_cargable>, IConceptosRepository
    {
        public ConceptosRepository(TEPEntities tep) : base(tep)
        {

        }

        public List<tbl_concepto_no_cargable> ListarTodosAtivos()
        {
            return db.tbl_concepto_no_cargable.Where(d => d.inactivar == 0).ToList();
        }

    }
}