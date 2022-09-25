using TiempoEnProcesoDL;

namespace TiempoEnProcesoBL.Interfaces.Repository
{
    public interface IParametrosRepository
    {
        tbl_parametros ObterValorNumerico(string id_parametro);
    }
}