using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoEnProcesoDL;

namespace TiempoEnProcesoBL
{
    public class PuestosBL
    {
        TEPEntities db;

        public PuestosBL()
        {
            db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public PuestosBL(ref TEPEntities _db)
        {
            if (_db==null)
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);

            db = _db;
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public List<TiempoEnProcesoEN.PuestoEN> ListarTodos()
        {
            List<TiempoEnProcesoEN.PuestoEN> lst = new List<TiempoEnProcesoEN.PuestoEN>();

            db.tbl_puestos.ToList().ForEach(d => lst.Add(new TiempoEnProcesoEN.PuestoEN() { descripcion = d.descripcion, id_nivel = d.id_nivel.Value, id_puesto = d.id_puesto }));

            return lst;
        }

        public string PuestoWeb(string _puesto)
        {
            return db.tbl_puestos.FirstOrDefault(d => d.id_puesto == _puesto).tbl_puestos1.FirstOrDefault().id_puesto.Trim();
        }
    }
}
