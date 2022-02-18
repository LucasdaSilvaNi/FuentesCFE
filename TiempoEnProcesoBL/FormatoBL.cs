using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoEnProcesoDL;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL
{
    public class FormatoBL
    {
        TEPEntities db;
        public FormatoBL()
        {
            db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;

        }

        public FormatoBL(ref TEPEntities _db)
        {
            if (_db==null)
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);

            db = _db;
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public List<tbl_factura_oficina> Listar()
        {
            return db.tbl_factura_oficina.Where(d=> d.id_oficina == TiempoEnProcesoHelper.Helper.Oficina).ToList<tbl_factura_oficina>();
        }
    }
}
