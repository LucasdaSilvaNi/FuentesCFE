using System.Web.Mvc;
using System.Web.Security;
using TiempoEnProcesoBL;
using TiempoEnProcesoBL.Interfaces;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoUIWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService loginService;

        public LoginController(ILoginService _loginService)
        {
            loginService = _loginService;
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

                        Session.Add(TiempoEnProcesoHelper.Constantes.S_EMPLEADO, _empleado);
                        Session.Add(TiempoEnProcesoHelper.Constantes.S_OFICINA, (new OficinaBL()).DevuelveDatos(_empleado.id_oficina));

                        //Session.Add(TiempoEnProcesoHelper.Constantes.S_PUESTO, (new PuestosBL()).PuestoWeb(_empleado.id_puesto));
                        FormsAuthentication.SetAuthCookie(oModel.Login, false);

                        EmpleadosBL _empBL = new EmpleadosBL();

                        if (loginService.ValidarCambioChave(oModel.Login))
                            return RedirectToAction("Captura", "CambioClave");

                        return RedirectToAction("Main", "Dashboard");
                    }
                    else
                    {
                        oModel.Error = true;
                    }
                }
                catch
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