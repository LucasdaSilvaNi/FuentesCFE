using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoEnProcesoDL;

namespace TiempoEnProcesoBL
{
    public class PermisosBL
    {
        TEPEntities db;

        public PermisosBL()
        {
            db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public PermisosBL(ref TEPEntities _db)
        {
            if (_db == null)
                _db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);

            db = _db;
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public List<tbl_opciones>   ListarPorEmpleado(string id_empleado)
        {
            IQueryable query = from c in db.tbl_opciones_empleado
                        join d in db.tbl_opciones on new { menu = c.menu, opcion = c.opcion } equals new { menu = d.menu, opcion = d.opcion }
                        where c.id_empleado == id_empleado
                        select d;

            return query.Cast<tbl_opciones>().ToList();           
            
        }
    }
}
