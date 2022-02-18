using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoEnProcesoDL;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL
{
    public class EncargadoBL
    {
        TEPEntities db;
        AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<sp_lista_gerente_Result, EncargadoEN>());
        public EncargadoBL()
        {
            db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public EncargadoBL(ref TEPEntities _db)
        {
            if (_db==null)
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);

            db = _db;
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public List<EncargadoEN> ListarTodosxEmpleado(string id_socio, string id_empleado, string id_oficina, string id_pais, string id_puesto)
        {
            List<EncargadoEN> lst = new List<EncargadoEN>();

            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<EncargadoEN>>(db.sp_lista_gerente(id_socio, id_oficina, id_pais, id_empleado, id_puesto));

            return lst;
        }

        public List<EncargadoEN> ListarTodosxEmpleadoSinTodos(string id_socio, string id_empleado, string id_oficina, string id_pais, string id_puesto)
        {
            List<EncargadoEN> lst = new List<EncargadoEN>();

            AutoMapper.MapperConfiguration _ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<sp_lista_gerente_Result, EncargadoEN>()
                                                                                                   .ForMember(dest => dest.nombrecompleto, opt => opt.MapFrom(src => src.id_empleado.Trim() + "-" + src.nombrecompleto.Trim())));
            var mapper = _ConfMapper.CreateMapper();
            lst = mapper.Map<List<EncargadoEN>>(db.sp_lista_gerente(id_socio, id_oficina, id_pais, id_empleado, id_puesto));

            return lst;
        }


        public List<EncargadoEN> ListaTodosxCliente(string id_empleado, string id_oficina, string id_pais, string id_puesto, string id_cliente)
        {
            List<EncargadoEN> lst = new List<EncargadoEN>();

            db.sp_lista_encargado_x_cliente(id_empleado, id_oficina, id_pais, id_puesto, id_cliente).ToList().ForEach(d => lst.Add(new EncargadoEN { id_empleado = d.id_empleado, nombrecompleto = d.nombrecompleto }));

            return lst;
        }
    }
}
