using System;
using System.Web.Mvc;
using TiempoEnProcesoBL;
using TiempoEnProcesoEN;
using TiempoEnProcesoHelper;
using TiempoEnProcesoUIWeb.Models;

namespace TiempoEnProcesoUIWeb.Controllers
{
    public class CambioClaveController : BaseController
    {
        public ActionResult Captura()
        {
            EmpleadoEN _empleado = GetEmpleado();
            return View(new CambioClaveModel() { id_empleado = _empleado.id_empleado });
        }

        public JsonResult Cambiar(Models.CambioClaveModel _model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(_model.PasswordActual) ||
                        string.IsNullOrEmpty(_model.Password) ||
                        string.IsNullOrEmpty(_model.ConfPassword))
                        return Json(new { Resultado = Constantes.S_ADVERTENCIA, MensajeError = "Valores invalidos", Modulo = "GrabarCambioClave" });

                    if (_model.Password != _model.ConfPassword)
                        return Json(new { Resultado = Constantes.S_ADVERTENCIA, MensajeError = "Confirmación de Clave Invalida", Modulo = "GrabarCambioClave" });

                    EmpleadosBL _empBL = new EmpleadosBL();
                    EmpleadoEN _empleado = _empBL.DevuelveDatosClave(_model.id_empleado);

                    if (_empleado.clave.Trim() != _model.PasswordActual.Trim())
                        return Json(new { Resultado = Constantes.S_ADVERTENCIA, MensajeError = "Clave Invalida", Modulo = "GrabarCambioClave" });

                    if (!Helper.IsValidPassword(_model.Password, _model.id_empleado))
                        return Json(new { Resultado = Constantes.S_ADVERTENCIA, MensajeError = "Clave no cumple con reglas definidas de Complejidad", Modulo = "GrabarCambioClave" });

                    /*string sClave = Helper.Encriptar(_model.Password);
                    if (!_empBL.ValidaClaveHistorica(sClave,_model.id_empleado))
                        return Json(new { Resultado = Constantes.S_ADVERTENCIA, MensajeError = "Clave no cumple con reglas definidas de uso Historico", Modulo = "GrabarCambioClave" });
                    */

                    string sClave = _model.Password.Trim();
                    _empBL.CambiaClave(_model.id_empleado, sClave);

                    return Json(new { Resultado = Constantes.S_OK, MensajeError = "Clave ha sido cambiada exitosamente", Modulo = "GrabarCambioClave" });
                }
                return Json(new { Resultado = Constantes.S_ADVERTENCIA, MensajeError = "Algunos campos no han sido llenados apropiadamente" });
            }
            catch (Exception ex)
            {
                return Json(new { Resultado = Constantes.S_ERROR, MensajeError = ex.Message + (ex.InnerException != null ? string.Format(" [{0}]", ex.InnerException.Message) : "") });
            }
        }

    }
}