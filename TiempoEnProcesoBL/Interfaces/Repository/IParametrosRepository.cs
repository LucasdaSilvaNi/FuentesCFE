using TiempoEnProcesoDL;

namespace TiempoEnProcesoBL.Interfaces
{
    public interface IParametrosRepository
    {
        tbl_parametros ObterValorNumerico(string id_parametro);
    }
}