using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoEnProcesoDL;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL
{
    public class JobsBL
    {
        TEPEntities db;
        AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<sp_listado_jobs_Result, JobsEN>());
        public JobsBL()
        {
            db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public JobsBL(ref TEPEntities _db)
        {
            if (_db==null)
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);

            db = _db;
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        /*public List<JobsEN> ListarTodos(string id_cliente, string id_socio, string id_encargado, string id_servicio, string id_pais)
        {
            List<JobsEN> lst = new List<JobsEN>();

            db.TP_lst_Jobs(id_pais, id_cliente, id_servicio, 0).ToList().ForEach(d => lst.Add(new JobsEN { descripcion = d.descripcion, id_cliente = d.id_cliente, id_job = d.id_job, id_servicio = d.id_servicio }));
            return lst;
        }*/

        public List<JobsEN> ListarTodos(string id_cliente, string id_socio, string id_encargado, string id_servicio, string id_pais,bool sinTodos = false)
        {
            List<JobsEN> lst = new List<JobsEN>();

            db.TP_lst_Jobs(id_pais, id_cliente, id_servicio, 0).Where(d => (!sinTodos || (sinTodos && d.id_job != TiempoEnProcesoHelper.Constantes.S_TODOS))).ToList().ForEach(d => lst.Add(new JobsEN { descripcion = d.descripcion, id_cliente = d.id_cliente, id_job = d.id_job, id_servicio = d.id_servicio }));
            return lst;
        }

        public List<JobsExtEN> ListarTodosExt(string id_cliente, string id_socio, string id_encargado, string id_servicio, string id_pais, bool sinTodos = false)
        {
            List<JobsExtEN> lst = new List<JobsExtEN>();
            List<JobsEN> lst1 = new List<JobsEN>();
            db.TP_lst_Jobs(id_pais, id_cliente, id_servicio, 0).Where(d => (!sinTodos || (sinTodos && d.id_job != TiempoEnProcesoHelper.Constantes.S_TODOS))).ToList().ForEach(d => lst1.Add(new JobsEN { descripcion = d.descripcion, id_cliente = d.id_cliente, id_job = d.id_job, id_servicio = d.id_servicio }));

            var query = (from a in lst1
                        join b in db.tbl_trabajos
                        on new { a.id_job, a.id_cliente, a.id_servicio } equals new { b.id_job, b.id_cliente, b.id_servicio }
                        where b.id_oficina == TiempoEnProcesoHelper.Helper.Oficina
                        select new { a, b.id_propuesta }).ToList();

            query.ToList().ForEach(d => lst.Add(new JobsExtEN { descripcion = d.a.descripcion, id_cliente = d.a.id_cliente, id_job = d.a.id_job, id_servicio = d.a.id_servicio, id_propuesta = d.id_propuesta }));

            if (!sinTodos)
                lst.Insert(0, new JobsExtEN { descripcion = lst1[0].descripcion, id_cliente = lst1[0].id_cliente, id_job = lst1[0].id_job, id_propuesta = string.Empty, id_servicio = lst1[0].id_servicio });
            return lst;
        }


        public List<JobsEN> ListarTodos(string id_cliente, string id_socio, string id_encargado, string id_servicio, bool sinTodos, string id_pais)
        {
            List<JobsEN> lst = new List<JobsEN>();

            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<JobsEN>>(db.sp_listado_jobs(id_socio, id_encargado, id_cliente, id_servicio, 1, id_pais).Where(d => (!sinTodos || (sinTodos && d.id_job != TiempoEnProcesoHelper.Constantes.S_TODOS))));

            return lst;
        }

        public List<JobsEN> ListarTodos(string id_cliente, string id_socio, string id_encargado, string id_servicio, string id_departamento, string id_pais)
        {
            List<JobsEN> lst = new List<JobsEN>();
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<sp_listado_jobs_depto_Result, JobsEN>());
            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<JobsEN>>(db.sp_listado_jobs_depto(id_socio, id_encargado, id_cliente, id_servicio, 1, id_departamento).Where(d => d.id_job != TiempoEnProcesoHelper.Constantes.S_TODOS));

            return lst;
        }

        public List<JobsEN> ListarTodos(string id_oficina,  bool sinTodos, bool carga = false)
        {
            List<JobsEN> lst = new List<JobsEN>();
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<tbl_trabajos, JobsEN>()
                                                                                                 .ForMember(dest => dest.id_job, opt => opt.MapFrom(src => src.id_job))
                                                                                                 .ForMember(dest => dest.descripcion, opt => opt.MapFrom(src => src.descripcion.ToString()))
                                                                                                 .ForMember(dest=> dest.id_cliente, opt=> opt.MapFrom(src=> src.id_cliente))
                                                                                                 .ForMember(dest=> dest.id_servicio, opt=> opt.MapFrom(src=> src.id_servicio)));
                                                                                                 
            var mapper = ConfMapper.CreateMapper();
            if (!carga)
            {
                db.Dispose();
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
            }
            lst = mapper.Map<List<JobsEN>>(db.tbl_trabajos.Where(d => d.id_oficina == id_oficina && d.id_pais == TiempoEnProcesoHelper.Helper.Pais && (!sinTodos || (sinTodos && d.id_job != TiempoEnProcesoHelper.Constantes.S_TODOS))));

            return lst;
        }
        public List<JobsEN> ListarTodosOficina(string id_cliente, string id_socio, string id_encargado, string id_servicio, bool sinTodos, string id_oficina)
        {
            List<JobsEN> lst = new List<JobsEN>();

            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<TP_lst_Jobs_Result, JobsEN>()
                                                                                                .ForMember(dest => dest.id_job, opt => opt.MapFrom(src => src.id_job))
                                                                                                .ForMember(dest => dest.descripcion, opt => opt.MapFrom(src => src.descripcion.ToString()))
                                                                                                .ForMember(dest => dest.id_cliente, opt => opt.MapFrom(src => src.id_cliente))
                                                                                                .ForMember(dest => dest.id_servicio, opt => opt.MapFrom(src => src.id_servicio)));

            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<JobsEN>>(db.TP_lst_Jobs(id_oficina, id_cliente, id_servicio, 0).Where(d => (!sinTodos || (sinTodos && d.id_job != TiempoEnProcesoHelper.Constantes.S_TODOS))));

            return lst;
        }

        public List<JobsExtEN> ListarTodosOficinaExt(string id_cliente, string id_socio, string id_encargado, string id_servicio, bool sinTodos, string id_oficina)
        {
            List<JobsExtEN> lst = new List<JobsExtEN>();
            List<JobsExtEN> lst1 = new List<JobsExtEN>();

            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<TP_lst_Jobs_Result, JobsExtEN>()
                                                                                                .ForMember(dest => dest.id_job, opt => opt.MapFrom(src => src.id_job))
                                                                                                .ForMember(dest => dest.descripcion, opt => opt.MapFrom(src => src.descripcion.ToString()))
                                                                                                .ForMember(dest => dest.id_cliente, opt => opt.MapFrom(src => src.id_cliente))
                                                                                                .ForMember(dest => dest.id_servicio, opt => opt.MapFrom(src => src.id_servicio)));

            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<JobsExtEN>>(db.TP_lst_Jobs(id_oficina, id_cliente, id_servicio, 0).Where(d => (!sinTodos || (sinTodos && d.id_job != TiempoEnProcesoHelper.Constantes.S_TODOS))));

            var query = (from a in lst
                         join b in db.tbl_trabajos
                         on new { a.id_job, a.id_cliente, a.id_servicio } equals new { b.id_job, b.id_cliente, b.id_servicio }
                         where b.id_oficina == id_oficina
                         select new { a, b.id_propuesta }).ToList();

            query.ToList().ForEach(d => lst1.Add(new JobsExtEN { descripcion = d.a.descripcion, id_cliente = d.a.id_cliente, id_job = d.a.id_job, id_servicio = d.a.id_servicio, id_propuesta = d.id_propuesta }));

            return lst1;
        }

        public List<JobsEN> ListarClienteJob(string id_cliente, string id_job, string id_oficina)
        {
            List<JobsEN> lst = new List<JobsEN>();
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<tbl_trabajos, JobsEN>()
                                                                                                 .ForMember(dest => dest.id_job, opt => opt.MapFrom(src => src.id_job))
                                                                                                 .ForMember(dest => dest.descripcion, opt => opt.MapFrom(src => src.descripcion.ToString()))
                                                                                                 .ForMember(dest => dest.id_cliente, opt => opt.MapFrom(src => src.id_cliente))
                                                                                                 .ForMember(dest => dest.id_servicio, opt => opt.MapFrom(src => src.id_servicio)));

            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<JobsEN>>(db.tbl_trabajos.Where(d => d.id_oficina == id_oficina && d.id_cliente == id_cliente && d.id_job == id_job));

            return lst;
        }
    }
}
