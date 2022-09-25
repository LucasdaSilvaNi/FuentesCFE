using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoEnProcesoBL.Interfaces.Repository;
using TiempoEnProcesoDL;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL.Repository
{
    public class ClienteRepository : Repository<tbl_clientes>, IClienteRepository
    {
        public ClienteRepository(TEPEntities tep) : base(tep)
        {

        }

        public IEnumerable<TP_lst_Clientes_Result> ListarTodo(string id_oficina)
        {
            return db.TP_lst_Clientes(id_oficina);
        }
    }
}