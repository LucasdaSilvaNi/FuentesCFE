using System;
using System.Collections.Generic;
using System.Globalization;
using TiempoEnProcesoBL.Interfaces;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL.Services
{
    public class PeriodoService : IPeriodoService
    {
        public List<PeriodoEN> ListarTodos(string Periodo)
        {
            string[] periodo = Periodo.Split('/');
            List<PeriodoEN> lst = new List<PeriodoEN>();
            DateTime dtF = new DateTime(Convert.ToInt32(periodo[1]), Convert.ToInt32(periodo[0]), 1);
            DateTime dtI = dtF;
            dtF = dtF.AddMonths(19).AddDays(-1);
            for (DateTime dt = dtI; dt <= dtF; dt = dt.AddMonths(1))
            {
                lst.Add(new PeriodoEN() { id_periodo = dt.ToString("MM/yyyy", new CultureInfo("es-gt")), descripcion = dt.AddMonths(6).ToString("MMMM/yyyy", new CultureInfo("es-gt")), fecha = dt.AddMonths(6) });
                if (dt.AddMonths(6).Month == 6)
                    break;
            }
            return lst;
        }

        public string ListarPorId(OficinaEN oficina)
        {
            if (oficina.Status != 2)
                return oficina.periodo_proceso;

            string[] periodo = oficina.periodo_proceso.Split('/');
            List<PeriodoEN> lst = new List<PeriodoEN>();
            //Listando por Periodo siguiente
            DateTime dtF = new DateTime(Convert.ToInt32(periodo[1]), Convert.ToInt32(periodo[0]), 1).AddMonths(1);
            dtF = dtF.AddMonths(7).AddDays(-1);

            return dtF.ToString("MMMM/yyyy", new CultureInfo("es-gt"));
        }

        public string ListarPeriodoSiguiente(string Periodo)
        {
            string[] periodo = Periodo.Split('/');
            DateTime dtF = new DateTime(Convert.ToInt32(periodo[1]), Convert.ToInt32(periodo[0]), 1).AddMonths(1);

            return dtF.ToString("MM/yyyy");
        }
    }
}