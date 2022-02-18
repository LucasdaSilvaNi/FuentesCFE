using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoEnProcesoDL;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL
{
    public class ServicioBL
    {
        TEPEntities db;
        AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<sp_listado_servicios_Result, ServicioEN>());
        public ServicioBL()
        {
            db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public ServicioBL(ref TEPEntities _db)
        {
            if (_db==null)
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);

            db = _db;
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public List<ServicioEN> ListarTodos(string id_cliente, string id_socio, string id_encargado, string id_oficina)
        {
            List<ServicioEN> lst = new List<ServicioEN>();

            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<ServicioEN>>(db.sp_listado_servicios(id_cliente, id_oficina, id_encargado, id_socio, 1));

            return lst;
        }

        public List<ServicioEN> ListarTodosSin(string id_cliente, string id_socio, string id_encargado, string id_oficina)
        {
            List<ServicioEN> lst = new List<ServicioEN>();

            AutoMapper.MapperConfiguration _ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<sp_listado_servicios_Result, ServicioEN>()
                                                                                                   .ForMember(dest => dest.Nombre_largo, opt => opt.MapFrom(src => src.id_servicio.Trim() + "-" + src.Nombre_largo.Trim())));
            var mapper = _ConfMapper.CreateMapper();
            lst = mapper.Map<List<ServicioEN>>(db.sp_listado_servicios(id_cliente, id_oficina, id_encargado, id_socio, 1));

            return lst;
        }

        public List<ServicioEN> ListarTodos(string id_cliente, string id_socio, string id_encargado, string id_oficina, string id_depto)
        {
            List<ServicioEN> lst = new List<ServicioEN>();
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<sp_listado_servicios_depto_Result, ServicioEN>());
            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<ServicioEN>>(db.sp_listado_servicios_depto(id_cliente, id_oficina, id_encargado, id_socio, 1, id_depto).Where(d=> d.id_servicio!= TiempoEnProcesoHelper.Constantes.S_TODOS));

            return lst;
        }

        public List<ServicioEN> ListarTodos(string id_cliente, string id_socio, string id_encargado, string id_oficina, bool sinTodos)
        {
            List<ServicioEN> lst = new List<ServicioEN>();

            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<ServicioEN>>(db.sp_listado_servicios(id_cliente, id_oficina, id_encargado, id_socio, 1).Where(d=> (!sinTodos || (sinTodos && d.id_servicio!= TiempoEnProcesoHelper.Constantes.S_TODOS))));

            return lst;
        }

        public List<ServicioEN> ListarTodos(string id_cliente, string id_socio, string id_encargado, string id_oficina, bool sinTodos, string id_depto)
        {
            List<ServicioEN> lst = new List<ServicioEN>();
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<sp_listado_servicios_depto_Result, ServicioEN>());
            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<ServicioEN>>(db.sp_listado_servicios_depto(id_cliente, id_oficina, id_encargado, id_socio, 1, id_depto).Where(d => (!sinTodos || (sinTodos && d.id_servicio != TiempoEnProcesoHelper.Constantes.S_TODOS))));

            return lst;
        }

        public List<tbl_servicios> ListarTodos(bool cargar = false)
        {
            if (cargar)
            {
                db.Dispose();
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
                db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
            }

            return db.tbl_servicios.ToList<tbl_servicios>();
        }

        public tbl_servicios ListarPorId(string id_servicio)
        {
            return db.tbl_servicios.FirstOrDefault(d => d.id_servicio == id_servicio);
        }

        public object ListaTodosxJob(string id_empleado,string id_oficina, string id_pais, string id_job)
        {
            List<ServicioEN> lst = new List<ServicioEN>();
            db.sp_lista_servicio_x_job(id_empleado, id_oficina, id_pais, id_job).ToList().ForEach(d => lst.Add(new ServicioEN { id_servicio = d.id_servicio, Nombre_largo = d.Nombre_largo }));

            return lst;
        }
    }
}
