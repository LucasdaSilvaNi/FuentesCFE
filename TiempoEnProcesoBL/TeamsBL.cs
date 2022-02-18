using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoEnProcesoDL;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL
{
    public class TeamsBL
    {
        TEPEntities db;
        public TeamsBL()
        {
            db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public TeamsBL(ref TEPEntities _db)
        {
            if (_db==null)
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);

            db = _db;
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public List<tbl_teams> ListarTodos(bool cargar = false)
        {
            if (cargar)
            {
                db.Dispose();
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
                db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
            }
            IQueryable qry =db.tbl_teams.Where(d=> d.id_oficina ==TiempoEnProcesoHelper.Helper.Oficina);
            return qry.Cast<tbl_teams>().ToList();
        }

        public List<TeamEN> ListarTodos(string id_oficina)
        {
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<tbl_teams, TeamEN>());
            List<TeamEN> lst = new List<TeamEN>();
            IQueryable qry = db.tbl_teams.Where(d => d.id_oficina == id_oficina);
            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<TeamEN>>(qry);

            return lst;
        }
    }
}
