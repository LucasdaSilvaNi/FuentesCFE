using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoEnProcesoDL;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL
{
    public class EntidadBL
    {
        TEPEntities db;

        public EntidadBL()
        {
            db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
        }

        public List<EntidadEN> ListarTipoSolicitud()
        {
            List<EntidadEN> lst = new List<EntidadEN>();
            lst.Add(new EntidadEN { id = "P", descripcion = "Personal" });
            lst.Add(new EntidadEN { id= "C", descripcion = "Envio Carta" });

            return lst;
        }
        public List<EntidadEN> ListarMonedaTEP()
        {
            List<EntidadEN> lst = new List<EntidadEN>();
            lst.Add(new EntidadEN { id = "1", descripcion = "Moneda TEP" });
            lst.Add(new EntidadEN { id = "2", descripcion = "Otra Moneda" });

            return lst;
        }

        public List<EntidadEN> IdiomaImpSol()
        {
            List<EntidadEN> lst = new List<EntidadEN>();
            lst.Add(new EntidadEN { id = "1", descripcion = "Español" });
            lst.Add(new EntidadEN { id = "0", descripcion = "Ingles" });

            return lst;
        }
        public List<EntidadEN> Conceptos()
        {
            List<EntidadEN> lst = new List<EntidadEN>();
            lst.Add(new EntidadEN { id = "Servicios Profesionales", descripcion = "Servicios Profesionales" });
            lst.Add(new EntidadEN { id = "Gastos", descripcion = "Gastos" });

            return lst;
        }

        public List<EntidadEN> ListarPorCliente(string id_pais, string id_cliente)
        {
            List<EntidadEN> lst = new List<EntidadEN>();
            db.tbl_entes_clientes.Where(d=> d.id_pais == id_pais && d.id_cliente == id_cliente).ToList().ForEach(d=> {
                lst.Add(new EntidadEN { id = d.linea.ToString(), id_numerico = d.linea, atencion_a = d.atencion_a, nit = d.nit, descripcion=d.nombre });
            });

            return lst;
        }
    }
}
