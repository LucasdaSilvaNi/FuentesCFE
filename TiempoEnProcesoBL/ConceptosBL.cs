using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoEnProcesoDL;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL
{
    public class ConceptosBL
    {
        TEPEntities db;
        AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<tbl_concepto_no_cargable, ConceptoEN>());

        public ConceptosBL()
        {
            db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public ConceptosBL(ref TEPEntities _db)
        {
            if (_db==null)
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);

            db = _db;
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public List<ConceptoEN> ListarTodos()
        {
            List<ConceptoEN> lst = new List<ConceptoEN>();
            var mapper = ConfMapper.CreateMapper();
            IQueryable qry = db.tbl_concepto_no_cargable.Where(d => d.inactivar == 0);
            lst= mapper.Map<List<ConceptoEN>>(qry);

            return lst;
        }

        public List<tbl_concepto_no_cargable> Listar(bool cargar = false)
        {
            if (cargar)
            {
                db.Dispose();
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
                db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
            }
            return db.tbl_concepto_no_cargable.OrderBy(d=> d.id_concepto).ToList<tbl_concepto_no_cargable>();

        }

    }
}
