using System;
using TiempoEnProcesoBL.Interfaces.Services;
using TiempoEnProcesoBL.Repository;
using TiempoEnProcesoDL;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL.Services
{
    public class LoginService : ILoginService
    {
        private readonly UnityOfWork uow;

        public LoginService(UnityOfWork _uow) { uow = _uow; }

        public bool ValidarIngresoAdmin(string usr, string pwd, ref EmpleadoEN _empleado)
        {
            tbl_empleados _emp = uow.EmpleadosRepository.ObterEmpleadoAtivo(usr, pwd);

            if (_emp != null)
            {
                //AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<tbl_empleados, EmpleadoEN>());

                //var mapper = ConfMapper.CreateMapper();
                _empleado = AutoMapper.Mapper.Map<EmpleadoEN>(_emp);
                return true;
            }

            return false;
        }

        public bool ValidarCambioChave(string id_empleado)
        {
            var param = uow.ParametrosRepository.ObterValorNumerico("Modo_clave");

            if (param == null || param.valor_numerico == 0)
                return false;

            EmpleadosBL _empBL = new EmpleadosBL();

            vw_Empleados_Datos datosEmpleados = uow.EmpleadosRepository.ObterDadosView(id_empleado);

            return datosEmpleados != null && (datosEmpleados.cambia_clave ?? false || datosEmpleados.fecha_expiracion < DateTime.Now.Date.AddDays(1));
        }

    }
}