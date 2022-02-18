using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoEnProcesoDL;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL
{
    public class SocioBL
    {
        TEPEntities db;
        AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<sp_lista_socios_Result, SocioEN>());
        public SocioBL()
        {
            db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public SocioBL(ref TEPEntities _db)
        {
            if (_db==null)
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);

            db = _db;
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public List<SocioEN> ListarTodosxEmpleado(string id_empleado, string id_oficina, string id_pais, string id_puesto)
        {
            List<SocioEN> lst = new List<SocioEN>();

            //AutoMapper.Mapper.Map(db.sp_lista_socios(id_empleado, id_oficina, id_pais, id_puesto),lst);
            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<SocioEN>>(db.sp_lista_socios(id_empleado, id_oficina, id_pais, id_puesto));

            return lst;
        }

        public List<SocioEN> ListarTodosxEmpleadoSinTodos(string id_empleado, string id_oficina, string id_pais, string id_puesto)
        {
            List<SocioEN> lst = new List<SocioEN>();

            AutoMapper.MapperConfiguration _ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<sp_lista_socios_Result, SocioEN>()
                                                                                                   .ForMember(dest => dest.nombrecompleto, opt => opt.MapFrom(src => src.id_empleado.Trim() + "-" + src.nombrecompleto.Trim())));
            var mapper = _ConfMapper.CreateMapper();
            lst = mapper.Map<List<SocioEN>>(db.sp_lista_socios(id_empleado, id_oficina, id_pais, id_puesto).Where(d=> d.id_empleado!=TiempoEnProcesoHelper.Constantes.S_TODOS));

            return lst;
        }

        public object ListaTodosxEncargado(string id_empleado, string id_oficina, string id_pais, string id_encargado, string id_puesto)
        {
            List<SocioEN> lst = new List<SocioEN>();

            db.sp_lista_socios_x_encargado(id_empleado, id_oficina, id_pais, id_puesto, id_encargado).ToList().ForEach(d => lst.Add(new SocioEN { id_empleado = d.id_empleado, nombrecompleto = d.nombrecompleto }));
            return lst;
        }
    }
}
