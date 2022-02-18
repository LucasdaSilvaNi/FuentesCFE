using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoEnProcesoDL;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL
{
    public class EmpleadosBL
    {
        TEPEntities db;
        AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<tbl_empleados, EmpleadoEN>());
        public EmpleadosBL()
        {
            db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public EmpleadosBL(ref TEPEntities _db)
        {
            if (_db==null)
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);

            db = _db;
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public List<EmpleadoEN> ListarTodos(string _empresa)
        {
            List<EmpleadoEN> lst = new List<EmpleadoEN>();

            IQueryable qry = db.tbl_empleados.Where(d => d.id_oficina == _empresa && d.situacion_actual == "A");

            AutoMapper.MapperConfiguration _ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<tbl_empleados, EmpleadoEN>()
                                                                                                   .ForMember(dest => dest.nombrecompleto, opt => opt.MapFrom( src => src.id_empleado.Trim() + "-" + src.Nombres.Trim() + " " + src.apellidos.Trim())));
            var mapper = _ConfMapper.CreateMapper();
            lst = mapper.Map<List<EmpleadoEN>>(qry);

            return lst;
        }

        public bool ValidarIngreso(string usr, string pwd, ref EmpleadoEN _empleado)
        {
            return ValidarIngresoAdmin(usr, pwd, ref _empleado);
        }

        public bool ValidarIngresoAdmin(string usr, string pwd, ref EmpleadoEN _empleado)
        {
            bool autorizado = false;

            try
            {
                
                //string sClave = TiempoEnProcesoHelper.Helper.Encriptar(pwd);

                //if (db.vw_Empleados_Datos.Any(d => d.id_empleado == usr && d.clave == sClave && d.situacion_actual == "A"))
                //{
                    //tbl_empleados _emp = db.tbl_empleados.FirstOrDefault(d => d.id_empleado == usr && d.situacion_actual == "A");
                    tbl_empleados _emp = db.tbl_empleados.FirstOrDefault(d => d.id_empleado == usr && d.clave == pwd && d.situacion_actual == "A");
                    if (_emp != null)
                    {
                        var mapper = ConfMapper.CreateMapper();
                        _empleado = mapper.Map<EmpleadoEN>(_emp);
                        autorizado = true;
                    }
                //}
                
            }
            catch (Exception ex)
            {

            }

            return autorizado;
        }

        public EmpleadoEN DevuelveDatos(string usr)
        {
            EmpleadoEN _empleado = new EmpleadoEN();
            try
            {
                tbl_empleados _emp = db.tbl_empleados.FirstOrDefault(d => d.id_empleado == usr);
                if (_emp != null)
                {
                    var mapper = ConfMapper.CreateMapper();
                    _empleado = mapper.Map<EmpleadoEN>(_emp);
                }
            }
            catch
            {

            }
            return _empleado;
        }

        public EmpleadoEN DevuelveDatosClave(string usr)
        {
            EmpleadoEN _empleado = new EmpleadoEN();
            try
            {
                tbl_empleados _emp = db.tbl_empleados.FirstOrDefault(d => d.id_empleado == usr);
                if (_emp != null)
                {
                    var mapper = ConfMapper.CreateMapper();
                    _empleado = mapper.Map<EmpleadoEN>(_emp);
                }

                vw_Empleados_Datos tbl = db.vw_Empleados_Datos.FirstOrDefault(d => d.id_empleado == usr);
                if (tbl != null)
                    _empleado.clave = tbl.clave;

            }
            catch
            {

            }
            return _empleado;
        }

        public void CambiaClave(string usr, string clave)
        {
            //vw_Empleados_Datos tblID = db.vw_Empleados_Datos.FirstOrDefault(d => d.id_empleado == usr);
            var tblID = db.tbl_empleados.FirstOrDefault(d => d.id_empleado == usr);


            if (tblID != null)
            {
                /*int id = tblID.tbl_claves_empleado_id;
                tbl_claves_empleado old = db.tbl_claves_empleado.FirstOrDefault(d => d.tbl_claves_empleado_id == id);
                if (old != null)
                    old.activo = false;

                tbl_parametros param = db.tbl_parametros.FirstOrDefault(d => d.id_parametro == "expiracion_clave");
                if (param == null)
                    throw new Exception("No existe el parámetro para vencimiento de clave");                    
                
                double dVenc = (double)param.valor_numerico;

                tbl_claves_empleado tbl = new tbl_claves_empleado()
                {
                    activo = true,
                    cambia_clave = false,
                    clave = clave,
                    fecha_clave = DateTime.Now.Date,
                    fecha_expiracion = DateTime.Now.Date.AddDays(dVenc),
                    id_empleado = usr
                };


                db.tbl_claves_empleado.Add(tbl);*/

                tblID.clave = clave;

                db.SaveChanges();
            }
        }

        public bool TipoValidacion()
        {
            bool ValidaAntigua = false;
            tbl_parametros param = db.tbl_parametros.FirstOrDefault(d => d.id_parametro == "Modo_clave");
            if (param == null)
                ValidaAntigua = true;
            else if (param.valor_numerico == 0)
                ValidaAntigua = true;

            return ValidaAntigua;
        }
        public tbl_empleados ValidarIngreso(string usr, string clave)
        {
            if (TipoValidacion())
                return db.tbl_empleados.FirstOrDefault(d => d.id_empleado == usr && d.clave == clave && d.situacion_actual == "A" && d.usuario_administrativo == 1);

            string sClave = TiempoEnProcesoHelper.Helper.Encriptar(clave);
            vw_Empleados_Datos tbl = db.vw_Empleados_Datos.FirstOrDefault(d => d.id_empleado == usr && d.clave == sClave && d.situacion_actual == "A" && d.usuario_administrativo == 1);

            if (tbl != null &&
                sClave == tbl.clave)
                return db.tbl_empleados.FirstOrDefault(d => d.id_empleado == usr && d.situacion_actual == "A" && d.usuario_administrativo == 1);

            return null;
        }
        public bool CambiaClave(string usr)
        {
            vw_Empleados_Datos tbl = db.vw_Empleados_Datos.FirstOrDefault(d => d.id_empleado == usr);
            if (tbl != null)
                return tbl.cambia_clave ?? false || tbl.fecha_expiracion < DateTime.Now.Date.AddDays(1);
            return false;
        }
        public List<tbl_empleados> Listar(bool Todos, bool cargar = false)
        {
            if (cargar)
            {
                db.Dispose();
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
                db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
            }
            IQueryable qry =db.tbl_empleados.Where(d => d.id_oficina == TiempoEnProcesoHelper.Helper.Oficina && (Todos || (!Todos && d.situacion_actual=="A")) );
            return qry.Cast<tbl_empleados>().ToList();
        }

        public List<EmpleadoEN> ListarSocios()
        {
            List<EmpleadoEN> lst = new List<EmpleadoEN>();
            AutoMapper.MapperConfiguration _ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<tbl_empleados, EmpleadoEN>()
                                                                                                   .ForMember(dest=> dest.id_empleado, opt=> opt.MapFrom(src=> src.id_empleado.Trim()))
                                                                                                   .ForMember(dest => dest.nombrecompleto, opt => opt.MapFrom(src => src.id_empleado.Trim() + "-" + src.Nombres.Trim() + " " + src.apellidos.Trim())));
            var mapper = _ConfMapper.CreateMapper();
            List<string> puestos = new List<string>() { "151", "152" };

            lst = mapper.Map<List<EmpleadoEN>>(db.tbl_empleados.Where(d => d.id_oficina == TiempoEnProcesoHelper.Helper.Oficina && d.situacion_actual == "A" && puestos.Contains(d.id_puesto)));
            return lst;
        }

        public List<EmpleadoEN> ListarTodos()
        {
            List<EmpleadoEN> lst = new List<EmpleadoEN>();
            AutoMapper.MapperConfiguration _ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<tbl_empleados, EmpleadoEN>()
                                                                                                   .ForMember(dest => dest.id_empleado, opt => opt.MapFrom(src => src.id_empleado.Trim()))
                                                                                                   .ForMember(dest => dest.nombrecompleto, opt => opt.MapFrom(src => src.id_empleado.Trim() + "-" + src.Nombres.Trim() + " " + src.apellidos.Trim())));
            var mapper = _ConfMapper.CreateMapper();

            IQueryable qry = db.tbl_empleados.Where(d => d.situacion_actual == "A");

            lst = mapper.Map<List<EmpleadoEN>>(qry.Cast<tbl_empleados>());

            return lst;
        }

        public List<EmpleadoEN> ListarTodosOficina(string oficina)
        {
            List<EmpleadoEN> lst = new List<EmpleadoEN>();
            AutoMapper.MapperConfiguration _ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<tbl_empleados, EmpleadoEN>()
                                                                                                   .ForMember(dest => dest.id_empleado, opt => opt.MapFrom(src => src.id_empleado.Trim()))
                                                                                                   .ForMember(dest => dest.nombrecompleto, opt => opt.MapFrom(src => src.id_empleado.Trim() + "-" + src.Nombres.Trim() + " " + src.apellidos.Trim())));
            var mapper = _ConfMapper.CreateMapper();

            IQueryable qry = db.tbl_empleados.Where(d => d.situacion_actual == "A" && d.id_oficina==oficina);

            lst = mapper.Map<List<EmpleadoEN>>(qry.Cast<tbl_empleados>());

            return lst;
        }

        public bool AccesoMenusTeam(string usr, string oficina)
        {

            return db.tbl_teams.Any(d => d.id_oficina == oficina &&
                                 db.tbl_empleados.Any(x => x.id_empleado == usr && x.situacion_actual == "A") &&
                                 d.Lider == usr);
            
        }

        public List<tbl_empleados> ListarxPais(bool Todos)
        {
            tbl_oficina _ofi = TiempoEnProcesoHelper.Helper.OficinaActiva as tbl_oficina;

            IQueryable qry = from c in db.tbl_empleados
                             join o in db.tbl_oficina on c.id_oficina equals o.id_oficina
                             where o.id_pais == _ofi.id_pais &&
                             (Todos || (!Todos && c.situacion_actual == "A"))
                             select c;

            return qry.Cast<tbl_empleados>().ToList();
        }

        public bool ValidaClaveHistorica(string clave, string id_empleado)
        {

            List<Get_Claves_Historicas_Result> lst = db.Get_Claves_Historicas(id_empleado).ToList();
            if (lst.Count == 0)
                return true;

            long i = lst.Max(d => d.orden)??1;
            Get_Claves_Historicas_Result item = lst.FirstOrDefault(d => d.clave == clave);
            if (item == null)
                return true;

            if (item.orden >= i - 8 &&
                item.orden <= i)
                return false;

            return true;
        }
    }
}
