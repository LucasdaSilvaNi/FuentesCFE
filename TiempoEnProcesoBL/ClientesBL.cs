using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoEnProcesoDL;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL
{
    public class ClientesBL
    {
        TEPEntities db;
        AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<sp_listado_clientes_Result, ClienteEN>());
        public ClientesBL()
        {
            db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public ClientesBL(ref TEPEntities _db)
        {
            if (_db==null)
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);

            db = _db;
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public List<ClienteEN> ListarTodosxEmpleado(string id_socio, string id_encargado, string id_oficina)
        {
            List<ClienteEN> lst = new List<ClienteEN>();

            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<ClienteEN>>(db.sp_listado_clientes(id_socio, id_encargado, id_oficina));

            return lst;
        }

        public List<ClienteEN> ListarTodo(string id_oficina)
        {
            List<ClienteEN> lst = new List<ClienteEN>();
            AutoMapper.MapperConfiguration _map = new AutoMapper.MapperConfiguration(cfg=> cfg.CreateMap<TP_lst_Clientes_Result,ClienteEN>()
                                                                                    .ForMember(dest=> dest.id_cliente, opt=> opt.MapFrom(src=> src.Clave))
                                                                                    .ForMember(dest=> dest.razon_social, opt=> opt.MapFrom(src=> src.Clave.Trim()+ " " + src.Nombre.Trim())));

            var mapper = _map.CreateMapper();
            lst = mapper.Map<List<ClienteEN>>(db.TP_lst_Clientes(id_oficina).OrderBy(d=> d.Nombre));

            return lst;
        }

        public List<ClienteEN> ListarTodo(string id_oficina,string id_empleado, string nombre, int offset)
        {
            List<ClienteEN> lst = new List<ClienteEN>();
            AutoMapper.MapperConfiguration _map = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<TP_lst_Clientes_Result, ClienteEN>()
                                                                                    .ForMember(dest => dest.id_cliente, opt => opt.MapFrom(src => src.Clave))
                                                                                    .ForMember(dest => dest.razon_social, opt => opt.MapFrom(src => src.Nombre)));

            var mapper = _map.CreateMapper();
            lst = mapper.Map<List<ClienteEN>>(db.TP_lst_Clientes(id_oficina).Where(d =>
                                                                                        (string.IsNullOrEmpty(id_empleado) || (!string.IsNullOrEmpty(id_empleado) && d.Clave.Contains(id_empleado))) &&
                                                                                        (string.IsNullOrEmpty(nombre) || (!string.IsNullOrEmpty(nombre) && d.Nombre.ToUpper().Contains(nombre.ToUpper())))
                                                                                        ).Skip(offset));

            return lst;
        }

        public ClienteEN ListarPorId(string id_cliente, string id_pais)
        {
            ClienteEN _cliente = new ClienteEN();
            
            AutoMapper.MapperConfiguration _map = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<tbl_clientes, ClienteEN>());

            var mapper = _map.CreateMapper();
            _cliente = mapper.Map<ClienteEN>(db.tbl_clientes.FirstOrDefault(d => d.id_cliente == id_cliente && d.id_pais == id_pais));

            return _cliente;
        }

        public List<ClienteEN> ListarTodoLight(string id_oficina)
        {
            List<ClienteEN> lst =new List<ClienteEN>();
            /*AutoMapper.MapperConfiguration _map = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<tbl_clientes, ClienteEN>()
                                                                                    .ForMember(dest => dest.id_cliente, opt => opt.MapFrom(src => src.id_cliente))
                                                                                    .ForMember(dest => dest.razon_social, opt => opt.MapFrom(src => src.Razon_Social.Trim()))
                                                                                    .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.estado == 1)));

            */
            IQueryable query = from c in db.tbl_clientes
                               join d in db.tbl_oficina on c.id_pais equals d.id_pais
                               where d.id_oficina == id_oficina
                               orderby c.Razon_Social
                               select new ClienteEN
                               {
                                   id_cliente = c.id_cliente,
                                   razon_social = c.Razon_Social,
                                   status = c.estado==TiempoEnProcesoHelper.Helper.SI
                               };

            foreach (ClienteEN item in query)
                lst.Add(new ClienteEN { id_cliente = item.id_cliente, razon_social = item.razon_social, status = item.status });

            return lst;
        }
        public List<ClienteEN> ListarTodosxEmpleadoSinTodos(string id_socio, string id_encargado, string id_oficina)
        {
            List<ClienteEN> lst = new List<ClienteEN>();

            AutoMapper.MapperConfiguration _ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<sp_listado_clientes_Result, ClienteEN>()
                                                                                                   .ForMember(dest => dest.razon_social, opt => opt.MapFrom(src => src.id_cliente.Trim() + "-" + src.razon_social.Trim())));

            var mapper = _ConfMapper.CreateMapper();
            lst = mapper.Map<List<ClienteEN>>(db.sp_listado_clientes(id_socio, id_encargado, id_oficina));

            return lst;
        }

        
        public List<ClienteEN> ListarTodoOficinaEncargadoSocio(string id_socio, string id_encargado, string id_oficina)
        {
            List<ClienteEN> lst = new List<ClienteEN>();
            AutoMapper.MapperConfiguration _map = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<tbl_clientes, ClienteEN>()
                                                                                    .ForMember(dest => dest.id_cliente, opt => opt.MapFrom(src => src.id_cliente))
                                                                                    .ForMember(dest => dest.razon_social, opt => opt.MapFrom(src =>  src.Razon_Social.Trim())));

            var mapper = _map.CreateMapper();

            var query = from c in db.tbl_clientes
                        join d in db.tbl_trabajos on new { id_cliente = c.id_cliente, id_pais = c.id_pais } equals new { id_cliente = d.id_cliente, id_pais = d.id_pais }
                        where d.id_oficina == id_oficina &&
                               d.id_socio == id_socio &&
                               d.id_encargado == id_encargado

                        select c;

            List<tbl_clientes> lstC = new List<tbl_clientes>();
            query.Distinct().ToList().ForEach(d => {
                if (!lstC.Any(e => e.id_cliente == d.id_cliente))
                    lstC.Add(d);
            });


            lst = mapper.Map<List<ClienteEN>>(lstC.OrderBy(d => d.Razon_Social));

            return lst;
        }

        public List<ClienteEN> ListarTodoOficina( string id_oficina)
        {
            List<ClienteEN> lst = new List<ClienteEN>();
            AutoMapper.MapperConfiguration _map = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<tbl_clientes, ClienteEN>()
                                                                                    .ForMember(dest => dest.id_cliente, opt => opt.MapFrom(src => src.id_cliente))
                                                                                    .ForMember(dest => dest.razon_social, opt => opt.MapFrom(src => src.Razon_Social.Trim())));

            var mapper = _map.CreateMapper();

            var query = from c in db.tbl_clientes
                        join d in db.tbl_trabajos on new { id_cliente = c.id_cliente, id_pais = c.id_pais } equals new { id_cliente = d.id_cliente, id_pais = d.id_pais }
                        where d.id_oficina == id_oficina 

                        select c;

            List<tbl_clientes> lstC = new List<tbl_clientes>();
            query.Distinct().ToList().ForEach(d =>
            {
                if (!lstC.Any(e => e.id_cliente == d.id_cliente))
                    lstC.Add(d);
            });


            lst = mapper.Map<List<ClienteEN>>(lstC.OrderBy(d => d.Razon_Social));

            return lst;
        }

        public List<ClienteEN> ListaTodosxServicio(string id_oficina, string id_pais, string id_servicio)
        {
            List<ClienteEN> lst = new List<ClienteEN>();

            db.sp_lista_cliente_x_servicio(TiempoEnProcesoHelper.Helper.usuario, id_oficina, id_pais, "", id_servicio).ToList().ForEach(d =>
                lst.Add(new ClienteEN { id_cliente = d.id_cliente, razon_social = d.Razon_Social, status = true }));
            return lst;
        }

        public List<EntidadEN> ListarEntidades(string id_pais, string id_cliente)
        {
            List<EntidadEN> lst = new List<EntidadEN>();
            IQueryable qry = from d in db.tbl_entes_clientes
                             where d.id_pais == id_pais
                             && d.id_cliente == id_cliente
                             && d.estado == 0
                             select d;

            qry.Cast<tbl_entes_clientes>().ToList().ForEach(d => lst.Add(new EntidadEN { id = d.linea.ToString(), id_numerico = d.linea, descripcion = d.nombre, atencion_a = d.atencion_a, nit = d.nit }));
            return lst;
        }
    }
}
