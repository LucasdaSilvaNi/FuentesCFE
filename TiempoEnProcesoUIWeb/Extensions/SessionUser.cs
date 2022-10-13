using System.Security.Principal;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoUIWeb.Extensions
{
    public class SessionUser : IPrincipal
    {
        public SessionUser(string nome)
        {
            Identity = new GenericIdentity(nome);
        }

        public EmpleadoEN empleado { get; set; }

        public OficinaEN oficina { get; set; }

        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        { return false; }
    }

    public class SessionUserModel
    {
        public string name { get; set; }

        public EmpleadoEN empleado { get; set; }

        public OficinaEN oficina { get; set; }
    }
}