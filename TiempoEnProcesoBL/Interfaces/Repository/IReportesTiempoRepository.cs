using TiempoEnProcesoDL;

namespace TiempoEnProcesoBL.Interfaces
{
    public interface IReportesTiempoRepository
    {
        bool ContemReporteTiempo(string id_empleado);

        tbl_reportes_tiempo_temp Retorna(string id_empleado, string id_oficina);
    }
}