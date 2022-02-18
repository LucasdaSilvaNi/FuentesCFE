using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoEnProcesoDL;

namespace TiempoEnProcesoBL
{
    public class PaisBL
    {
        TEPEntities db;

        public PaisBL()
        {
            db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public PaisBL(ref TEPEntities _db)
        {
            if (_db == null)
                _db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);

            db = _db;
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public List<tbl_paises> Listar(bool Cargar=false)
        {
            if (Cargar)
            {
                db.Dispose();
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
            }

            return db.tbl_paises.ToList<tbl_paises>();
        }

        public bool EsGt(string id_pais)
        {
            return db.tbl_paises.Any(d => d.id_pais == id_pais && d.iso_char2 == "GT");
        }
    }
}
