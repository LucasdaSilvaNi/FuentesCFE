using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoEnProcesoDL;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL
{
    public class MunicipioBL
    {
        TEPEntities db;
        public MunicipioBL()
        {
            db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public MunicipioBL(ref TEPEntities _db)
        {
            if (_db==null)
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);

            db = _db;
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public List<tbl_municipio> ListarTodos(string _pais, string _provincia)
        {
            return db.tbl_municipio.Where(d => d.Codigo_iso_alpha == _pais && d.codigo_provincia == _provincia).OrderBy(d => d.Codigo_municipio).ToList<tbl_municipio>();
        }
    }
}
