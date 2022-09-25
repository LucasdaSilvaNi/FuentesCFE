using System.Collections.Generic;

namespace TiempoEnProcesoBL.Interfaces.Services
{
    public interface ICapturaService
    {
        Dictionary<string, decimal> CalculaTotales(string id_empleado, string id_oficina);
    }
}