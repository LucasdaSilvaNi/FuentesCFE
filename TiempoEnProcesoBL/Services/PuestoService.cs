using TiempoEnProcesoBL.Interfaces.Services;
using TiempoEnProcesoBL.Repository;

namespace TiempoEnProcesoBL.Services
{
    public class PuestoService : IPuestoService
    {
        private UnityOfWork uow { get; }

        public PuestoService(UnityOfWork _uow)
        {
            uow = _uow;
        }

        public string RetornaIdDeConversionWeb(string _puestos)
        {
            return uow.PuestoRepository.RetornaPuestoEnConversionWeb(_puestos).id_puesto.Trim();
        }
    }
}