﻿using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL.Interfaces.Services
{
    public interface ILoginService
    {
        bool ValidarIngresoAdmin(string usr, string pwd, ref EmpleadoEN _empleado);

        bool ValidarCambioChave(string id_empleado);
    }
}