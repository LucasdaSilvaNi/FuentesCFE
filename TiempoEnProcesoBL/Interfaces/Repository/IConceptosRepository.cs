﻿using System.Collections.Generic;
using TiempoEnProcesoDL;

namespace TiempoEnProcesoBL.Interfaces.Repository
{
    public interface IConceptosRepository
    {
        List<tbl_concepto_no_cargable> ListarTodosAtivos();
    }
}