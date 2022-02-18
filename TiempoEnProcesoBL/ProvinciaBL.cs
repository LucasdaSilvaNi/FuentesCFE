using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoEnProcesoDL;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL
{
    public class ProvinciaBL
    {
        TEPEntities db;
        public ProvinciaBL()
        {
            db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public ProvinciaBL(ref TEPEntities _db)
        {
            if (_db==null)
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);

            db = _db;
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public List<Tbl_provincia_depto> ListarTodos(string _pais)
        {
            return db.Tbl_provincia_depto.Where(d => d.Codigo_iso_alpha == _pais ).OrderBy(d => d.Codigo_provincia).ToList<Tbl_provincia_depto>();
        }
    }
}
