using System.Linq;
using TiempoEnProcesoBL.Interfaces;
using TiempoEnProcesoDL;

namespace TiempoEnProcesoBL.Repository
{
    public class ReportesTiempoRepository : Repository<tbl_reportes_tiempo_temp>, IReportesTiempoRepository
    {
        public ReportesTiempoRepository(TEPEntities tep) : base(tep)
        {

        }

        public bool ContemReporteTiempo(string id_empleado)
        {
            return db.tbl_reportes_tiempo_temp.Any(d => d.id_empleado == id_empleado);
        }

        public tbl_reportes_tiempo_temp Retorna(string id_empleado, string id_oficina)
        {
            return db.tbl_reportes_tiempo_temp.Include("tbl_detalle_cargable_temp").FirstOrDefault(d => d.id_oficina == id_oficina && d.id_empleado == id_empleado); ;
        }
    }
}