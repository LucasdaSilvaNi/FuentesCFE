using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TiempoEnProcesoBL;
using TiempoEnProcesoEN;
using TiempoEnProcesoHelper;
using TiempoEnProcesoUIWeb.Models;

namespace TiempoEnProcesoUIWeb.Controllers
{
    public class SolicitudFacturaController : BaseController
    {
        public ActionResult Captura()
        {
            SolicitudFacturaModel _model = new SolicitudFacturaModel();
            OficinaEN _oficina = GetOficina();
            EmpleadoEN _empleado = GetEmpleado();

            Session[TiempoEnProcesoHelper.Constantes.S_OFICINA0] = _oficina;

            _model.Oficina = _oficina.Nombre;
            _model.id_empleado = _empleado.id_empleado;
            _model.id_oficina = _oficina.id_oficina;
            _model.fecha_a_emitir = DateTime.Now.Date;
            _model.fecha_solicitud = DateTime.Now.Date;
            _model.fecha_tentativa_cobro = DateTime.Now.Date;
            _model.tipo_entrega = "P";
            _model.Imprime_Moneda_Tep = 1;
            _model.Lenguaje_impresion_spanish = 1;
            _model.tasa_cambio = 1;
            _model.Tasa_cambio_fiscal = 1;
            _model.facturar_en_perido = _oficina.periodo_proceso;
            _model.id_solicitud_captura = (new SolicitudFacturaBL()).Pendientes(_empleado.id_empleado);
            _model.Detalle = new SolicitudFacturaDetModel();

            ViewData.Add(Constantes.S_CLIENTE, (new ClientesBL()).ListarTodosxEmpleado(Constantes.S_TODOS, Constantes.S_TODOS, _oficina.id_oficina));

            ViewData.Add(Constantes.S_SERVICIO, (new ServicioBL()).ListarTodos(Constantes.S_TODOS, Constantes.S_TODOS, Constantes.S_TODOS, _oficina.id_oficina));

            ViewData.Add(Constantes.S_JOBS, (new JobsBL()).ListarTodos(Constantes.S_TODOS, Constantes.S_TODOS, Constantes.S_TODOS, TiempoEnProcesoHelper.Constantes.S_TODOS, _oficina.id_oficina));

            ViewData.Add(Constantes.S_ENTIDAD_LEGAL, (new EntidadLegalBL()).Listar(_oficina.id_oficina));

            ViewData.Add(Constantes.S_TIPO_SOL, (new EntidadBL()).ListarTipoSolicitud());

            ViewData.Add(Constantes.S_MONEDA_TEP, (new EntidadBL()).ListarMonedaTEP());

            ViewData.Add(Constantes.S_IDIOMA_IMP, (new EntidadBL()).IdiomaImpSol());

            ViewData.Add(Constantes.S_PERIODO, (new PeriodoBL()).ListarSiguiente(_oficina.periodo_proceso));

            ViewData.Add(Constantes.S_CLIENTE_ENTIDAD, new List<EntidadEN>());

            ViewData.Add(Constantes.S_CONCEPTO, (new EntidadBL()).Conceptos());

            return View(_model);
        }

        public JsonResult CabeceraDetalle(int id_solicitud)
        {
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<SolicitudFacturaEN, SolicitudFacturaModel>()
                                                                                            .ForMember(dest => dest.Lenguaje_impresion_spanish, opt => opt.MapFrom(src => src.Lenguaje_impresion_spanish.Value ? 1 : 0))
                                                                                            .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.id_cliente ?? "TODOS"))
                                                                                            .ForMember(dest => dest.Servicio, opt => opt.MapFrom(src => src.id_servicio ?? "TODOS"))
                                                                                            .ForMember(dest => dest.codigo_moneda_impresion, opt => opt.MapFrom(src => src.codigo_moneda_impresion ?? ""))
                                                                                            .ForMember(dest => dest.Job, opt => opt.MapFrom(src => src.id_job))
                                                                                            .ForMember(dest => dest.fecha_solicitud, opt => opt.MapFrom(src => src.fecha ?? DateTime.Now.Date))
                                                                                          );
            var mapper = ConfMapper.CreateMapper();

            SolicitudFacturaModel solicitud = mapper.Map<SolicitudFacturaModel>((new SolicitudFacturaBL()).CabeceraDetalle(id_solicitud));
            List<SolicitudFacturaDetEN> lst = ((new SolicitudFacturaBL()).Detalle(id_solicitud));
            return Json(new { Resultado = Constantes.S_OK, Solicitud = solicitud, Detalles = lst.Count });
        }

        public ActionResult Detalle(int id_solicitud)
        {
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<SolicitudFacturaDetEN, SolicitudFacturaDetModel>());
            var mapper = ConfMapper.CreateMapper();

            List<SolicitudFacturaDetModel> lst = mapper.Map<List<SolicitudFacturaDetModel>>((new SolicitudFacturaBL()).Detalle(id_solicitud));
            return PartialView("_Detalle", lst.AsEnumerable<SolicitudFacturaDetModel>());
        }

        public JsonResult GrabaDetalle(SolicitudFacturaModel _model)
        {
            OficinaEN _oficina = GetOficina();
            EmpleadoEN _empleado = GetEmpleado();

            try
            {
                if (_model.Detalle.linea == 0)
                    return Json(new { Resultado = Constantes.S_ADVERTENCIA, MensajeError = "Selección de Facturar A Invalida" });

                if (_oficina.id_oficina == "60")
                {
                    if (string.IsNullOrEmpty(_model.Detalle.conceptoS))
                        return Json(new { Resultado = Constantes.S_ADVERTENCIA, MensajeError = "Selección de Concepto Invalido" });

                    if (string.IsNullOrEmpty(_model.Detalle.descripcion_comercial))
                        return Json(new { Resultado = Constantes.S_ADVERTENCIA, MensajeError = "Selección de Descripción Comercial Invalida" });

                    _model.Detalle.concepto = _model.Detalle.conceptoS;
                }
                else
                {
                    _model.Detalle.concepto = _model.Detalle.descripcion;
                }
                if (_model.Detalle.valor <= 0)
                    return Json(new { Resultado = Constantes.S_ADVERTENCIA, MensajeError = "Valor Invalido" });

                _model.Detalle.Total = _model.Detalle.valor + _model.Detalle.Impuesto - _model.Detalle.Descuento_linea;

                AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<SolicitudFacturaDetModel, SolicitudFacturaDetEN>());
                var mapper = ConfMapper.CreateMapper();

                SolicitudFacturaDetEN _det = mapper.Map<SolicitudFacturaDetEN>(_model.Detalle);

                SolicitudFacturaBL _solFac = new SolicitudFacturaBL();
                decimal id_solicitud = _solFac.GrabaDetalle(_det);
                decimal total = _solFac.Detalle((int)id_solicitud).Sum(d => d.Total);

                return Json(new { Resultado = Constantes.S_OK, MensajeError = "Registro Agregado!!!", Modulo = "GrabarSolDetalle", id_solicitud = id_solicitud, total_solicitud = total });
            }
            catch (Exception ex)
            {
                return Json(new { Resultado = Constantes.S_ERROR, MensajeError = ex.Message + (ex.InnerException != null ? string.Format(" [{0}]", ex.InnerException.Message) : "") });
            }
        }

        public ActionResult EliminaDetalle(int id)
        {
            List<SolicitudFacturaDetEN> lstA = (new SolicitudFacturaBL()).EliminaDetalle(id);

            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<SolicitudFacturaDetEN, SolicitudFacturaDetModel>());
            var mapper = ConfMapper.CreateMapper();

            List<SolicitudFacturaDetModel> lst = mapper.Map<List<SolicitudFacturaDetModel>>(lstA);
            return PartialView("_Detalle", lst.AsEnumerable<SolicitudFacturaDetModel>());
        }

        public JsonResult GrabaCabecera(SolicitudFacturaModel _model)
        {
            OficinaEN _oficina = GetOficina();
            EmpleadoEN _empleado = GetEmpleado();

            try
            {
                if (string.IsNullOrEmpty(_model.Cliente))
                    _model.Cliente = _model.id_cliente;

                if (string.IsNullOrEmpty(_model.id_entidad))
                    _model.id_entidad = _model.id_entidad_D;

                if (_model.tasa_cambio == 0 && _model.tasa_cambio_D != 0)
                    _model.tasa_cambio = _model.tasa_cambio_D;

                AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<SolicitudFacturaModel, SolicitudFacturaEN>()
                                                                                                      .ForMember(dest => dest.fecha, opt => opt.MapFrom(src => src.fecha_solicitud))
                                                                                                      .ForMember(dest => dest.id_cliente, opt => opt.MapFrom(src => src.Cliente))
                                                                                                      .ForMember(dest => dest.id_servicio, opt => opt.MapFrom(src => src.Servicio))
                                                                                                      .ForMember(dest => dest.id_solicitud, opt => opt.MapFrom(src => src.id_solicitud_captura))
                                                                                                      .ForMember(dest => dest.id_job, opt => opt.MapFrom(src => src.Job))
                                                                                                      .ForMember(dest => dest.Lenguaje_impresion_spanish, opt => opt.MapFrom(src => src.Lenguaje_impresion_spanish == 1))
                                                                                                      );
                var mapper = ConfMapper.CreateMapper();

                SolicitudFacturaEN _det = mapper.Map<SolicitudFacturaEN>(_model);

                SolicitudFacturaBL _solFac = new SolicitudFacturaBL();
                decimal id_solicitud = _solFac.GrabaCabecera(_det);

                return Json(new { Resultado = Constantes.S_OK, MensajeError = "Solicitud de Factura Grabada!!!", Modulo = "GrabarSolicitud", id_solicitud = id_solicitud });
            }
            catch (Exception ex)
            {
                return Json(new { Resultado = Constantes.S_ERROR, MensajeError = ex.Message + (ex.InnerException != null ? string.Format(" [{0}]", ex.InnerException.Message) : "") });
            }
        }

        public JsonResult EliminarCabecera(int id_solicitud)
        {
            try
            {
                (new SolicitudFacturaBL()).EliminaSolicitud(id_solicitud);


                return Json(new { Resultado = Constantes.S_OK, MensajeError = "Solicitud de Factura Eliminada!!!", Modulo = "GrabarSolicitud", id_solicitud = id_solicitud });
            }
            catch (Exception ex)
            {
                return Json(new { Resultado = Constantes.S_ERROR, MensajeError = ex.Message + (ex.InnerException != null ? string.Format(" [{0}]", ex.InnerException.Message) : "") });
            }
        }

        public JsonResult FinalizarCabecera(int id_solicitud)
        {
            try
            {
                (new SolicitudFacturaBL()).FinalizaSolicitud(id_solicitud);


                return Json(new { Resultado = Constantes.S_OK, MensajeError = "Solicitud de Factura Finalizada!!!", Modulo = "GrabarSolicitud", id_solicitud = id_solicitud });
            }
            catch (Exception ex)
            {
                return Json(new { Resultado = Constantes.S_ERROR, MensajeError = ex.Message + (ex.InnerException != null ? string.Format(" [{0}]", ex.InnerException.Message) : "") });
            }
        }
    }
}