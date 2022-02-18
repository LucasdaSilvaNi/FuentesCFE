using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoEnProcesoDL;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL
{
    public class IndustriasBL
    {
        TEPEntities db;
        

        public IndustriasBL()
        {
            db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public IndustriasBL(ref TEPEntities _db)
        {
            if (_db==null)
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);

            db = _db;
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public List<tbl_industrias> Listar(bool cargar = false)
        {
            if (cargar)
            {
                db.Dispose();
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
                db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
            }
            return db.tbl_industrias.ToList<tbl_industrias>();

        }

    }
}
