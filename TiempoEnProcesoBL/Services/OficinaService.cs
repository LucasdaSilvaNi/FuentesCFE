using TiempoEnProcesoBL.Interfaces.Services;
using TiempoEnProcesoBL.Repository;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL.Services
{
    public class OficinaService : IOficinaService
    {
        private UnityOfWork uow { get; }

        public OficinaService(UnityOfWork _uow)
        {
            uow = _uow;
        }

        public OficinaEN Retorna(string oficina)
        {
            var retorno = uow.OficinaRepository.Retorna(oficina);

            return retorno != null ? AutoMapper.Mapper.Map<OficinaEN>(retorno) : new OficinaEN();
        }
    }
}
