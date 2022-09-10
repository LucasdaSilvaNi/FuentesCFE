using System.Collections.Generic;

namespace TiempoEnProcesoBL.Interfaces
{
    public interface ICapturaService
    {
        Dictionary<string, decimal> CalculaTotales(string id_empleado, string id_oficina);
    }
}