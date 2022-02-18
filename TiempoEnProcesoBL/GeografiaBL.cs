using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoEnProcesoDL;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL
{
    public class GeografiaBL
    {
        TEPEntities db;
        public GeografiaBL()
        {
            db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public GeografiaBL(ref TEPEntities _db)
        {
            if (_db==null)
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);

            db = _db;
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public List<Tbl_geografia> ListarTodos()
        {
            return db.Tbl_geografia.Where(d=> d.Nivel_jerarquico==2).OrderBy(d=> d.Codigo_iso_alpha).ToList<Tbl_geografia>();
        }
    }
}
