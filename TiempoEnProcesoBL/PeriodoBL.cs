using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoEnProcesoDL;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL
{
    public class PeriodoBL
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

        public List<PeriodoEN> ListarTodos2(string Periodo)
        {

            string[] periodo = Periodo.Split('/');
            List<PeriodoEN> lst = new List<PeriodoEN>();
            DateTime dtF = new DateTime(Convert.ToInt32(periodo[1]), Convert.ToInt32(periodo[0]), 1);
            DateTime dtI = dtF.AddMonths(-24);
            dtF = dtF.AddMonths(6).AddDays(-1);
            for (DateTime dt = dtI; dt <= dtF; dt = dt.AddMonths(1))
            {
                lst.Add(new PeriodoEN() { id_periodo = dt.ToString("MM/yyyy", new CultureInfo("es-gt")), descripcion = dt.AddMonths(6).ToString("MMMM/yyyy", new CultureInfo("es-gt")), fecha = dt.AddMonths(6) });
               
            }
            return lst;
        }
        public List<Periodo> Listar()
        {
            List<Periodo> lst = new List<Periodo>();
            DateTime dtF = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtF = dtF.AddMonths(1).AddDays(-1);
            for (DateTime dt = new DateTime(2014, 01, 01); dt <= dtF; dt = dt.AddMonths(1))
            {
                lst.Add(new Periodo() { id_periodo = dt.ToString("MM/yyyy", new CultureInfo("es-gt")), descripcion = dt.AddMonths(6).ToString("MMMM/yyyy", new CultureInfo("es-gt")) });
            }
            return lst;
        }

        public string ListarPorId(string Periodo)
        {

            string[] periodo = Periodo.Split('/');
            List<PeriodoEN> lst = new List<PeriodoEN>();
            DateTime dtF = new DateTime(Convert.ToInt32(periodo[1]), Convert.ToInt32(periodo[0]), 1);
            dtF = dtF.AddMonths(7).AddDays(-1);
            
            return dtF.ToString("MMMM/yyyy", new CultureInfo("es-gt"));
            

        }

        public DateTime PorId(string Periodo)
        {

            string[] periodo = Periodo.Split('/');
            List<PeriodoEN> lst = new List<PeriodoEN>();
            DateTime dtF = new DateTime(Convert.ToInt32(periodo[1]), Convert.ToInt32(periodo[0]), 1);
            return dtF.AddMonths(7);
        }

        public List<PeriodoEN> ListarSiguiente(string Periodo)
        {
            string[] periodo = Periodo.Split('/');
            DateTime dtF = new DateTime(Convert.ToInt32(periodo[1]), Convert.ToInt32(periodo[0]), 1);
            return ListarTodos(Periodo).Where(d => d.fecha > dtF).ToList<PeriodoEN>();
            
        }

        public PeriodoEN ListarSiguienteUno(string Periodo)
        {
            string[] periodo = Periodo.Split('/');
            DateTime dtF = new DateTime(Convert.ToInt32(periodo[1]), Convert.ToInt32(periodo[0]), 1).AddMonths(1);

            return new PeriodoEN() { id_periodo = dtF.ToString("MM/yyyy") };
        }
    }
}
