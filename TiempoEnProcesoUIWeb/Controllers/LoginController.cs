using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using TiempoEnProcesoBL.Interfaces.Services;
using TiempoEnProcesoBL.Repository;
using TiempoEnProcesoEN;
using TiempoEnProcesoUIWeb.Extensions;

namespace TiempoEnProcesoUIWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService loginService;
        private readonly IOficinaService oficinaService;
        private UnityOfWork uow;

        public LoginController(ILoginService _loginService, IOficinaService _oficinaService, UnityOfWork _uow)
        {
            loginService = _loginService;
            oficinaService = _oficinaService;
            uow = _uow;
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

                        AdicionaCookieAlResponse(_empleado, oModel.Login);

                        if (loginService.ValidarCambioChave(oModel.Login))
                            return RedirectToAction("Captura", "CambioClave");

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

        private void AdicionaCookieAlResponse(EmpleadoEN _empleado, string name)
        {
            SessionUserModel sessionUser = new SessionUserModel();
            sessionUser.empleado = _empleado;
            sessionUser.oficina = oficinaService.Retorna(_empleado.id_oficina);
            sessionUser.name = name;

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string userData = serializer.Serialize(sessionUser);

            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                                    1,
                                    name,
                                    System.DateTime.Now,
                                    System.DateTime.Now.AddMinutes(15),
                                    false,
                                    userData);

            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

            Response.Cookies.Add(faCookie);
        }
    }
}