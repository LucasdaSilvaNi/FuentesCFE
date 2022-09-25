using TiempoEnProcesoDL;

namespace TiempoEnProcesoBL.Interfaces.Repository
{
    public interface IEmpleadosRepository
    {
        tbl_empleados ObterEmpleadoAtivo(string usr, string pwd);

        vw_Empleados_Datos ObterDadosView(string id_empleado);
    }
}