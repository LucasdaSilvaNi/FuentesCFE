using System.Web.Mvc;
using System.Web.Security;
using TiempoEnProcesoBL.Interfaces.Services;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService loginService;
        private readonly IOficinaService oficinaService;
        private readonly IPuestoService puestoService;

        public LoginController(ILoginService _loginService, IOficinaService _oficinaService, IPuestoService _puestoService)
        {
            loginService = _loginService;
            oficinaService = _oficinaService;
            puestoService = _puestoService;
        }

        public ActionResult Login(Models.LoginModel oModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    EmpleadoEN _empleado = new EmpleadoEN();

                    if (loginService.ValidarIngresoAdmin(oModel.Login, oModel.Password, ref _empleado))
                    {
                        TiempoEnProcesoHelper.Helper.empleado = _empleado.id_empleado;
                        TiempoEnProcesoHelper.Helper.Oficina = _empleado.id_oficina;

                        Session.Add(TiempoEnProcesoHelper.Constantes.S_EMPLEADO, _empleado);
                        Session.Add(TiempoEnProcesoHelper.Constantes.S_OFICINA, oficinaService.Retorna(_empleado.id_oficina));

                        Session.Add(TiempoEnProcesoHelper.Constantes.S_PUESTO, puestoService.RetornaIdDeConversionWeb(_empleado.id_puesto));
                        Session.Add(TiempoEnProcesoHelper.Constantes.S_NOMBREEMP, _empleado.Nombres + " " + _empleado.apellidos);
                        FormsAuthentication.SetAuthCookie(oModel.Login, false);

                        return RedirectToAction("Main", "Dashboard");
                    }
                    else
                    {
                        oModel.Error = true;
                    }
                }
                catch (System.Exception e)
                {
                    oModel.Login = string.Empty;
                    oModel.Password = string.Empty;
                    oModel.Error = true;
                }
            }
            return View(oModel);
        }

        public ActionResult Validar(Models.LoginModel oModel)
        {
            /*if (ModelState.IsValid)
            {
                try
                {
                    UsuarioBL _user = new UsuarioBL();

                    if (_user.IsAuthenticated(ConfigurationManager.AppSettings["ADServer"], oModel.Login, oModel.Password))
                    {
                        Session.Add(Constantes.S_USUARIO, oModel.Login);
                        FormsAuthentication.SetAuthCookie(oModel.Login, false);

                        RedirectToAction("Main", "Dashboard");
                    }
                }
                catch (Exception ex)
                {
                    oModel.Login = string.Empty;
                    oModel.Password = string.Empty;
                    oModel.Error = true;
                }
            }*/
            return View(oModel);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login");
        }

    }
}