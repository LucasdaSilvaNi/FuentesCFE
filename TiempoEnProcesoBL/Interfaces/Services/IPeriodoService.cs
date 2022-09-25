using System.Collections.Generic;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL.Interfaces.Services
{
    public interface IPeriodoService
    {
        List<PeriodoEN> ListarTodos(string Periodo);

        string ListarPorId(OficinaEN oficina);

        string ListarPeriodoSiguiente(string Periodo);
    }
}