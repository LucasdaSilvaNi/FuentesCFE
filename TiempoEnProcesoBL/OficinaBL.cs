using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoEnProcesoDL;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL
{
    public class OficinaBL
    {
        TEPEntities db;
        AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<tbl_oficina, OficinaEN>());
        public OficinaBL()
        {
            db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public OficinaBL(ref TEPEntities _db)
        {
            if (_db==null)
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);

            db = _db;
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public List<OficinaEN> ListarTodos()
        {
            List<OficinaEN> lst = new List<OficinaEN>();

            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<OficinaEN>>(db.tbl_oficina.Where(d => d.Status == 1));
            
            
            return lst;
        }

        public OficinaEN DevuelveDatos(string oficina)
        {
            OficinaEN _oficina = new OficinaEN();
            try
            {
                tbl_oficina _ofi = db.tbl_oficina.FirstOrDefault(d => d.id_oficina == oficina);
                if (_ofi != null)
                {
                    var mapper = ConfMapper.CreateMapper();
                    _oficina = mapper.Map<OficinaEN>(_ofi);
                }
            }
            catch
            {

            }
            return _oficina;
        }


        public tbl_oficina DevuelveDatosOficina(string _oficina)
        {
            return db.tbl_oficina.FirstOrDefault(d => d.id_oficina == _oficina);
        }

        public List<tbl_oficina> Listar()
        {
            IQueryable qry = db.tbl_oficina.Where(d => d.Status == TiempoEnProcesoHelper.Helper.SI);
            return qry.Cast<tbl_oficina>().ToList();
        }
        public List<tbl_oficina> ListarTodosS(bool cargar=false)
        {
            if (cargar)
            {
                db.Dispose();
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
                db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
            }
            return db.tbl_oficina.ToList<tbl_oficina>();
        }

        public List<OficinaEN> OficinaEmpleado(string id_empleado)
        {
            IQueryable query = from emp in db.tbl_empleados
                               join niv in db.tbl_niveles_empleado on emp.id_empleado equals niv.id_empleado
                               join ofi in db.tbl_oficina on niv.id_oficina equals ofi.id_oficina
                               where emp.id_empleado == id_empleado
                               select ofi;
            List<OficinaEN> lO = new List<OficinaEN>();
            query.Cast<tbl_oficina>().ToList().ForEach(d => lO.Add(new OficinaEN()
            {
                id_oficina = d.id_oficina,
                id_pais = d.id_pais,
                Nombre = d.Nombre,
                periodo_proceso = d.periodo_proceso,
                Status = d.Status
            }));

            return lO;
        }
    }
}
