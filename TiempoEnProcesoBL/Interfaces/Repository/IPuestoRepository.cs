using TiempoEnProcesoDL;

namespace TiempoEnProcesoBL.Interfaces.Repository
{
    public interface IPuestoRepository
    {
        tbl_puestos RetornaPuestoEnConversionWeb(string _puesto);
    }
}