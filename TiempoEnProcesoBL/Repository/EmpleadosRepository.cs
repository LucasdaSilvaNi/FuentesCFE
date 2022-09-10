using System.Linq;
using TiempoEnProcesoBL.Interfaces;
using TiempoEnProcesoDL;

namespace TiempoEnProcesoBL.Repository
{
    public class EmpleadosRepository : Repository<tbl_empleados> ,IEmpleadosRepository
    {
        public EmpleadosRepository(TEPEntities tep) : base(tep) {

        }

        public tbl_empleados ObterEmpleadoAtivo(string usr, string pwd)
        {
            return db.tbl_empleados.FirstOrDefault(d => d.id_empleado == usr && d.clave == pwd && d.situacion_actual == "A");
        }

        public vw_Empleados_Datos ObterDadosView(string id_empleado)
        {
            return db.vw_Empleados_Datos.FirstOrDefault(d => d.id_empleado == id_empleado);
        }
    }
}
