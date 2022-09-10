using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL.Interfaces
{
    public interface IPeriodoService
    {
        List<PeriodoEN> ListarTodos(string Periodo);

        string ListarPorId(OficinaEN oficina);

        string ListarPeriodoSiguiente(string Periodo);
    }
}