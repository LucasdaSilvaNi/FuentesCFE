using System.Collections.Generic;
using System.Linq;
using TiempoEnProcesoBL.Interfaces.Services;
using TiempoEnProcesoBL.Repository;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL.Services
{
    public class ClienteService : IClienteService
    {
        private UnityOfWork uow { get; }

        public ClienteService(UnityOfWork _uow)
        {
            uow = _uow;
        }

        public List<ClienteEN> PesquisaPorOficina(string id_oficina, string id_empleado, string nombre, int offset)
        {
            if (id_oficina == null || id_oficina == null)
                return new List<ClienteEN>();

            var lista = uow.ClienteRepository.ListarTodo(id_oficina);

            if (!string.IsNullOrEmpty(id_empleado) && !string.IsNullOrWhiteSpace(id_empleado))
                lista.Where(i => i.Clave.Contains(id_empleado));

            if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrWhiteSpace(nombre))
                lista.Where(i => i.Nombre.ToUpper().Contains(nombre.ToUpper()));

            return AutoMapper.Mapper.Map<List<ClienteEN>>(lista.OrderBy(i => i.Nombre).Skip(offset));
        }
    }
}