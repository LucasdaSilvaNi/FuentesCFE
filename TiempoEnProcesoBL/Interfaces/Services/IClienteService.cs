using System.Collections.Generic;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL.Interfaces.Services
{
    public interface IClienteService
    {
        List<ClienteEN> PesquisaPorOficina(string id_oficina, string id_empleado, string nombre, int offset);
    }
}