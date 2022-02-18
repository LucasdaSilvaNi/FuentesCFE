using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL
{
    public class MesBL
    {
        public List<MesEN> ListarTodos()
        {
            return new List<MesEN>() {new MesEN { Mes = "ENERO" }, new MesEN { Mes = "FEBRERO" },
                                                 new MesEN { Mes = "MARZO" }, new MesEN { Mes = "ABRIL" },
                                                 new MesEN { Mes = "MAYO" }, new MesEN { Mes = "JUNIO" },
                                                 new MesEN { Mes = "JULIO" }, new MesEN { Mes = "AGOSTO" },
                                                 new MesEN { Mes = "SEPTIEMBRE" }, new MesEN { Mes = "OCTUBRE" },
                                                 new MesEN { Mes = "NOVIEMBRE" }, new MesEN { Mes = "DICIEMBRE" }};
        }
    }
}
