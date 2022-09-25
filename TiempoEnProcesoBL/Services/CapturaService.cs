using System.Collections.Generic;
using System.Linq;
using TiempoEnProcesoBL.Interfaces.Services;
using TiempoEnProcesoBL.Repository;
using TiempoEnProcesoDL;

namespace TiempoEnProcesoBL.Services
{
    public class CapturaService : ICapturaService
    {
        private readonly UnityOfWork uow;

        public CapturaService(UnityOfWork _uow) { uow = _uow; }

        public Dictionary<string, decimal> CalculaTotales(string id_empleado, string id_oficina)
        {
            Dictionary<string, decimal> lst = new Dictionary<string, decimal>();
            decimal dHoras = 0, dGastos = 0, dTotalCargable = 0, dTotalNoCargable = 0;
            tbl_reportes_tiempo_temp _cab = uow.ReportesTiempoRepository.Retorna(id_empleado, id_oficina);

            if (_cab != null)
            {
                if (_cab.tbl_detalle_cargable_temp.Count > 0)
                {
                    dGastos = _cab.tbl_detalle_cargable_temp.Sum(d => d.gastos) ?? 0;
                    dTotalCargable = _cab.tbl_detalle_cargable_temp.Sum(d => d.horas) ?? 0;
                }

                dTotalNoCargable = uow.NoCargableRepository.Listar(id_empleado, id_oficina).Sum(d => d.horas) ?? 0;

                dHoras = dTotalCargable + dTotalNoCargable;
            }

            lst.Add("Horas", dHoras);
            lst.Add("Gastos", dGastos);
            lst.Add("Cargables", dTotalCargable);
            lst.Add("NoCargables", dTotalNoCargable);

            return lst;
        }
    }
}