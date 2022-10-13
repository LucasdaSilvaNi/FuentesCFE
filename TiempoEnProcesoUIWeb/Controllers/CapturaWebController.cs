using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TiempoEnProcesoBL;
using TiempoEnProcesoBL.Interfaces.Services;
using TiempoEnProcesoBL.Repository;
using TiempoEnProcesoEN;
using TiempoEnProcesoHelper;
using TiempoEnProcesoUIWeb.Extensions;
using TiempoEnProcesoUIWeb.Models;

namespace TiempoEnProcesoUIWeb.Controllers
{
    public class CapturaWebController : BaseController
    {
        private UnityOfWork uow { get; }
        private IPeriodoService periodoService { get; }
        private ICapturaService capturaService { get; }
        private IClienteService clienteService { get; }

        public CapturaWebController(UnityOfWork _uow, IPeriodoService _periodoService, ICapturaService _capturaService, IClienteService _clienteService)
        {
            uow = _uow;
            periodoService = _periodoService;
            capturaService = _capturaService;
            clienteService = _clienteService;
        }

        public ActionResult Captura(string id_cliente)
        {
            CapturaWebModel _model = new CapturaWebModel();
            OficinaEN _oficina = GetOficina();
            _model.ClienteC = id_cliente;
            _model.NombreClienteC = string.IsNullOrEmpty(id_cliente) ? string.Empty : (new ClientesBL()).ListarPorId(id_cliente, _oficina.id_pais).razon_social;

            EmpleadoEN _empleado = GetEmpleado();
            Session[TiempoEnProcesoHelper.Constantes.S_OFICINA0] = _oficina;
            //string _puesto = Session[TiempoEnProcesoHelper.Constantes.S_PUESTO].ToString();

            _model.EsAdmin = 0;
            _model.EsGerente = 0;
            _model.EsSocio = 0;

            _model.OficinaEmpleado = _oficina.Nombre;
            _model.Oficina_Busqueda = _oficina.id_oficina;
            _model.id_oficina = _oficina.id_oficina;
            _model.Empleado = string.Format("{0} {1}", _empleado.Nombres, _empleado.apellidos);
            _model.id_empleado = _empleado.id_empleado;

            _model.PeriodoProceso = periodoService.ListarPorId(_oficina);
            _model.PeriodoTEP = _oficina.Status == 2 ? periodoService.ListarPeriodoSiguiente(_oficina.periodo_proceso) : _oficina.periodo_proceso;
            _model.PeriodoTEPInput = _model.PeriodoTEP;
            _model.periodo_tep_proceso = _model.PeriodoTEP;

            _model.DiaAl = DateTime.Now.Day;
            _model.DiaAlInput = DateTime.Now.Day;
            _model.DiaDel = DateTime.Now.Day;
            _model.DiaDelInput = DateTime.Now.Day;

            _model.TipoCapturaWeb = 2;

            List<ServicioEN> lstS = new List<ServicioEN>();
            List<JobsEN> lstJ = new List<JobsEN>();
            List<EntidadEN> lstEnt = new List<EntidadEN>();

            if (!string.IsNullOrEmpty(id_cliente))
            {
                lstS = (new ServicioBL()).ListarTodos(id_cliente, TiempoEnProcesoHelper.Constantes.S_TODOS, TiempoEnProcesoHelper.Constantes.S_TODOS, _oficina.id_oficina, true, _empleado.id_departamento);
                if (lstS.Count > 0)
                    lstJ = (new JobsBL()).ListarTodosOficina(id_cliente, TiempoEnProcesoHelper.Constantes.S_TODOS, TiempoEnProcesoHelper.Constantes.S_TODOS, lstS.FirstOrDefault().id_servicio, true, _oficina.id_oficina);

                lstEnt = new EntidadBL().ListarPorCliente(_oficina.id_pais, id_cliente);
            }

            ViewData.Add(TiempoEnProcesoHelper.Constantes.S_SERVICIO, lstS);

            ViewData.Add(TiempoEnProcesoHelper.Constantes.S_JOBS, lstJ);
            string sPer = "01/" + new DateTime(Convert.ToInt32(_model.PeriodoTEP.Split('/')[1]), 7, 1).ToString("yyyy");


            ViewData.Add(TiempoEnProcesoHelper.Constantes.S_OFICINA, AutoMapper.Mapper.Map<List<OficinaEN>>(uow.OficinaRepository.ListarTodosAtivos()));
            ViewData.Add(TiempoEnProcesoHelper.Constantes.S_CONCEPTO, AutoMapper.Mapper.Map<List<ConceptoEN>>(uow.ConceptosRepository.ListarTodosAtivos()));
            ViewData.Add(TiempoEnProcesoHelper.Constantes.S_MES, periodoService.ListarTodos(sPer));
            ViewData.Add(TiempoEnProcesoHelper.Constantes.S_OFCEMP, AutoMapper.Mapper.Map<List<OficinaEN>>(uow.OficinaRepository.OficinaEmpleado(_empleado.id_empleado)));
            ViewData.Add(Constantes.S_ENTIDAD_CLIENTE, lstEnt);

            //_model.clientes = (new List<ClientesModel>()).AsQueryable<ClientesModel>();
            _model.clientes = new List<ClientesModel>();

            if (uow.ReportesTiempoRepository.ContemReporteTiempo(_empleado.id_empleado))
            {
                _model.VerificaPendientes = string.IsNullOrEmpty(id_cliente) ? 1 : 0;
                _model.VerificaPendientesCliente = !string.IsNullOrEmpty(id_cliente) ? 1 : 0;
            }
            else
            {
                _model.VerificaPendientes = 0;
                _model.VerificaPendientesCliente = 0;
            }

            Dictionary<string, decimal> lst = capturaService.CalculaTotales(_empleado.id_empleado, _empleado.id_oficina);
            _model.TotalCargable = lst["Cargables"];
            _model.TotalNoCargable = lst["NoCargables"];
            _model.TotalHoras = lst["Horas"];
            _model.TotalGastos = lst["Gastos"];
            _model.id_pais = _oficina.id_pais;

            CapturaWebModel _temp = (CapturaWebModel)Session[Constantes.CAPTURA_TEMP];
            if (_temp != null)
            {
                _model.DiaAl = _temp.DiaAl;
                _model.DiaDel = _temp.DiaDel;
            }

            Session[Constantes.CAPTURA_TEMP] = null;

            return View(_model);

        }

        public ActionResult Clientes()
        {
            OficinaEN _oficina = GetOficina();
            var lst = AutoMapper.Mapper.Map<List<ClientesModel>>(clienteService.PesquisaPorOficina(_oficina.id_oficina, null, null, 0));
            return PartialView(lst);
        }

        public ActionResult BusquedaClientes(BusquedaClienteModel _model)
        {
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA0];
            _model.clientes = AutoMapper.Mapper.Map<List<ClientesModel>>(clienteService.PesquisaPorOficina(_oficina.id_oficina, _model.id_cliente, _model.nombre, (_model.pageNo ?? 0) * 10));

            return View(_model);
        }

        public JsonResult Grabar(Models.CapturaWebModel _model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string MensajeError = string.Empty;

                    // Validaciones
                    /*if (_model.DiaAl < _model.DiaDel)
                    {
                        return Json(new { Resultado = Constantes.S_ADVERTENCIA, MensajeError = "Rango de Días Invalido" });
                    }*/

                    OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA0];
                    /*if (Convert.ToInt32(_model.PeriodoTEP.Substring(0, 2)) > Convert.ToInt32(_oficina.periodo_proceso.Substring(0, 2)) + (_oficina.Status == 2 ? 1 : 0))
                        return Json(new { Resultado = Constantes.S_ADVERTENCIA, MensajeError = "Periodo TEP Invalido" });*/
                    CapturaBL _cap = new CapturaBL();
                    if (_model.TipoCapturaWeb == 1) // No cargable
                    {

                        if (_model.Horas + _model.Gastos == 0)
                            return Json(new { Resultado = Constantes.S_ADVERTENCIA, MensajeError = "Valor invalido" });

                        if (string.IsNullOrEmpty(_model.NoCargableTrabajo))
                            return Json(new { Resultado = Constantes.S_ADVERTENCIA, MensajeError = "Descripción Invalida" });
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(_model.ClienteC))
                            return Json(new { Resultado = Constantes.S_ADVERTENCIA, MensajeError = "Selección de Cliente Invalido" });

                        if (string.IsNullOrEmpty(_model.ServicioCaptura))
                            return Json(new { Resultado = Constantes.S_ADVERTENCIA, MensajeError = "Selección de Servicio Invalido" });

                        if (_model.ServicioCaptura == "-1")
                            return Json(new { Resultado = Constantes.S_ADVERTENCIA, MensajeError = "Selección de Servicio Invalido" });

                        if (string.IsNullOrEmpty(_model.JobCaptura))
                            return Json(new { Resultado = Constantes.S_ADVERTENCIA, MensajeError = "Selección de Proyecto Invalido" });

                        if (_model.JobCaptura == "-1")
                            return Json(new { Resultado = Constantes.S_ADVERTENCIA, MensajeError = "Selección de Proyecto Invalido" });

                        if (_model.Horas + _model.Gastos == 0)
                            return Json(new { Resultado = Constantes.S_ADVERTENCIA, MensajeError = "Valor invalido" });
                    }

                    if (_model.Horas > 9)
                        return Json(new { Resultado = Constantes.S_ADVERTENCIA, MensajeError = "Cantidad de Horas no puede ser mayor a 9" });

                    decimal totalH = _cap.CalculaTotalesPorDia(_model.id_empleado, _model.id_oficina, _model.DiaDel, _oficina.periodo_proceso);
                    if (totalH + _model.Horas > 9)
                        return Json(new { Resultado = Constantes.S_ADVERTENCIA, MensajeError = "Cantidad de Horas del día no puede ser mayor a 9" });

                    AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<CapturaWebModel, CapturaHdrEN>()
                        .ForMember(dest => dest.a_dia, opt => opt.MapFrom(src => src.DiaDel.ToString()))
                        .ForMember(dest => dest.de_dia, opt => opt.MapFrom(src => src.DiaDel.ToString()))
                        .ForMember(dest => dest.id_empleado, opt => opt.MapFrom(src => src.id_empleado))
                        .ForMember(dest => dest.id_oficina, opt => opt.MapFrom(src => src.Oficina_Busqueda))
                        .ForMember(dest => dest.periodo_tep_corresponde, opt => opt.MapFrom(src => src.PeriodoTEP))
                        .ForMember(dest => dest.periodo_tep_proceso, opt => opt.MapFrom(src => src.periodo_tep_proceso))
                        );

                    var mapper = ConfMapper.CreateMapper();

                    CapturaHdrEN _cab = mapper.Map<CapturaHdrEN>(_model);

                    AutoMapper.MapperConfiguration ConfMapperDet = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<CapturaWebModel, CapturaDtEN>()
                       .ForMember(dest => dest.descripcion_cargo, opt => opt.MapFrom(src => _model.TipoCapturaWeb != 1 ? src.Trabajo : src.NoCargableTrabajo))
                       .ForMember(dest => dest.gastos, opt => opt.MapFrom(src => src.Gastos))
                       .ForMember(dest => dest.horas, opt => opt.MapFrom(src => src.Horas))
                       .ForMember(dest => dest.id_cliente, opt => opt.MapFrom(src => src.ClienteC))
                       .ForMember(dest => dest.id_empleado, opt => opt.MapFrom(src => src.id_empleado))
                       .ForMember(dest => dest.id_job, opt => opt.MapFrom(src => src.JobCaptura))
                       .ForMember(dest => dest.id_oficina, opt => opt.MapFrom(src => src.id_oficina))
                       .ForMember(dest => dest.id_oficina0, opt => opt.MapFrom(src => src.id_oficina0))
                       .ForMember(dest => dest.tipo, opt => opt.MapFrom(src => src.TipoCapturaWeb))
                       .ForMember(dest => dest.id_concepto, opt => opt.MapFrom(src => src.Concepto))
                       .ForMember(dest => dest.id_tbl_entes_clientes, opt => opt.MapFrom(src => src.Id_EntidadCaptura))
                       );

                    mapper = ConfMapperDet.CreateMapper();
                    CapturaDtEN _det = mapper.Map<CapturaDtEN>(_model);


                    _cap.GrabarEntidad(_cab, _det);

                    Dictionary<string, decimal> lst = capturaService.CalculaTotales(_model.id_empleado, _model.id_oficina);

                    return Json(new { Resultado = Constantes.S_OK, MensajeError = "Registro Agregado!!!", Modulo = "GrabarCaptura", Cargable = lst["Cargables"].ToString("###,###,##0.00"), NoCargable = lst["NoCargables"].ToString("###,###,##0.00"), Horas = lst["Horas"].ToString("###,###,##0.00"), Gastos = lst["Gastos"].ToString("###,###,##0.00") });
                }
                return Json(new { Resultado = Constantes.S_ADVERTENCIA, MensajeError = "Algunos campos no han sido llenados apropiadamente" });
            }
            catch (Exception ex)
            {
                return Json(new { Resultado = Constantes.S_ERROR, MensajeError = ex.Message + (ex.InnerException != null ? string.Format(" [{0}]", ex.InnerException.Message) : "") });
            }
        }

        public JsonResult ConsultarCliente(string id_cliente)
        {
            try
            {
                ClientesBL _cl = new ClientesBL();
                OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA0];
                ClienteEN _cliente = _cl.ListarPorId(id_cliente, _oficina.id_pais);
                List<EntidadEN> lst = new EntidadBL().ListarPorCliente(_oficina.id_pais, id_cliente);
                if (_cliente != null)
                    return Json(new { NombreCliente = _cliente.razon_social, Entidades = lst });

                return Json(new { NombreCliente = string.Empty });
            }
            catch (Exception ex)
            {
                return Json(new { Resultado = Constantes.S_ERROR, MensajeError = ex.Message + (ex.InnerException != null ? string.Format(" [{0}]", ex.InnerException.Message) : "") });
            }
        }

        public JsonResult GrabarTodos(string id_empleado, string id_oficina)
        {
            try
            {

                decimal dVal = 0;

                CapturaBL _cap = new CapturaBL();
                _cap.GrabarFinal(id_empleado, id_oficina);
                return Json(new { Resultado = Constantes.S_OK, MensajeError = "There is no values for filters selected", Cargable = dVal.ToString("###,###,##0"), NoCargable = dVal.ToString("###,###,##0"), Horas = dVal.ToString("###,###,##0"), Gastos = dVal.ToString("###,###,##0.00") });
            }
            catch (Exception ex)
            {
                return Json(new { Resultado = Constantes.S_ERROR, MensajeError = ex.Message + (ex.InnerException != null ? string.Format(" [{0}]", ex.InnerException.Message) : "") });
            }
        }

        public JsonResult EliminarTodos(string id_empleado, string id_oficina)
        {
            try
            {
                decimal dVal = 0;
                CapturaBL _cap = new CapturaBL();
                _cap.Eliminar(id_empleado, id_oficina);

                return Json(new { Resultado = Constantes.S_OK, MensajeError = "There is no values for filters selected", Cargable = dVal.ToString("###,###,##0"), NoCargable = dVal.ToString("###,###,##0"), Horas = dVal.ToString("###,###,##0"), Gastos = dVal.ToString("###,###,##0.00") });
            }
            catch (Exception ex)
            {
                return Json(new { Resultado = Constantes.S_ERROR, MensajeError = ex.Message + (ex.InnerException != null ? string.Format(" [{0}]", ex.InnerException.Message) : "") });
            }
        }

        public ActionResult RegistroCargable(string id_empleado, string id_oficina)
        {
            List<CapturaDtEN> lst = (new CapturaBL()).Detalle(id_empleado, id_oficina, true);

            AutoMapper.MapperConfiguration ConfMapperDet = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<CapturaDtEN, RegistroCargableModel>()
                       .ForMember(dest => dest.descripcion_cargo, opt => opt.MapFrom(src => src.descripcion_cargo))
                       .ForMember(dest => dest.gastos, opt => opt.MapFrom(src => src.gastos))
                       .ForMember(dest => dest.horas, opt => opt.MapFrom(src => src.horas))
                       .ForMember(dest => dest.id_cliente, opt => opt.MapFrom(src => src.id_cliente))
                       .ForMember(dest => dest.id_empleado, opt => opt.MapFrom(src => src.id_empleado))
                       .ForMember(dest => dest.id_job, opt => opt.MapFrom(src => src.id_job))
                       .ForMember(dest => dest.id_oficina, opt => opt.MapFrom(src => src.id_oficina))
                       .ForMember(dest => dest.oficina, opt => opt.MapFrom(src => src.oficina))
                       .ForMember(dest => dest.job, opt => opt.MapFrom(src => src.job))
                       .ForMember(dest => dest.cliente, opt => opt.MapFrom(src => src.cliente))
                       .ForMember(dest => dest.linea, opt => opt.MapFrom(src => src.linea))
                       );

            var mapper = ConfMapperDet.CreateMapper();
            List<RegistroCargableModel> _det = new List<RegistroCargableModel>();
            _det = mapper.Map<List<RegistroCargableModel>>(lst);


            return PartialView("_RegistroCargable", _det.AsEnumerable<RegistroCargableModel>());
        }

        public ActionResult RegistroNoCargable(string id_empleado, string id_oficina)
        {
            List<CapturaDtEN> lst = (new CapturaBL()).Detalle(id_empleado, id_oficina, false);

            AutoMapper.MapperConfiguration ConfMapperDet = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<CapturaDtEN, RegistroNoCargableModel>()
                       .ForMember(dest => dest.descripcion, opt => opt.MapFrom(src => src.descripcion_cargo))
                       .ForMember(dest => dest.horas, opt => opt.MapFrom(src => src.horas))
                       .ForMember(dest => dest.id_empleado, opt => opt.MapFrom(src => src.id_empleado))
                       .ForMember(dest => dest.id_oficina, opt => opt.MapFrom(src => src.id_oficina))
                       .ForMember(dest => dest.oficina, opt => opt.MapFrom(src => src.oficina))
                       .ForMember(dest => dest.concepto, opt => opt.MapFrom(src => src.concepto))
                       .ForMember(dest => dest.linea, opt => opt.MapFrom(src => src.linea))
                       );

            var mapper = ConfMapperDet.CreateMapper();
            List<RegistroNoCargableModel> _det = new List<RegistroNoCargableModel>();
            _det = mapper.Map<List<RegistroNoCargableModel>>(lst);

            return PartialView("_RegistroNoCargable", _det.AsEnumerable<RegistroNoCargableModel>());
        }

        public ActionResult ServiciosCliente(string id_cliente)
        {
            OficinaEN _oficina = (OficinaEN)Session[TiempoEnProcesoHelper.Constantes.S_OFICINA];

            return Json((new ServicioBL()).ListarTodos(id_cliente, TiempoEnProcesoHelper.Constantes.S_TODOS, TiempoEnProcesoHelper.Constantes.S_TODOS, _oficina.id_oficina, true), JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult EliminaCargable(int id)
        {
            List<CapturaDtEN> lst = (new CapturaBL()).EliminaCargable(id);

            AutoMapper.MapperConfiguration ConfMapperDet = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<CapturaDtEN, RegistroCargableModel>()
                       .ForMember(dest => dest.descripcion_cargo, opt => opt.MapFrom(src => src.descripcion_cargo))
                       .ForMember(dest => dest.gastos, opt => opt.MapFrom(src => src.gastos))
                       .ForMember(dest => dest.horas, opt => opt.MapFrom(src => src.horas))
                       .ForMember(dest => dest.id_cliente, opt => opt.MapFrom(src => src.id_cliente))
                       .ForMember(dest => dest.id_empleado, opt => opt.MapFrom(src => src.id_empleado))
                       .ForMember(dest => dest.id_job, opt => opt.MapFrom(src => src.id_job))
                       .ForMember(dest => dest.id_oficina, opt => opt.MapFrom(src => src.id_oficina))
                       .ForMember(dest => dest.oficina, opt => opt.MapFrom(src => src.oficina))
                       .ForMember(dest => dest.job, opt => opt.MapFrom(src => src.job))
                       .ForMember(dest => dest.cliente, opt => opt.MapFrom(src => src.cliente))
                       .ForMember(dest => dest.linea, opt => opt.MapFrom(src => src.linea))
                       );

            var mapper = ConfMapperDet.CreateMapper();
            List<RegistroCargableModel> _det = new List<RegistroCargableModel>();
            _det = mapper.Map<List<RegistroCargableModel>>(lst);


            return PartialView("_RegistroCargable", _det.AsEnumerable<RegistroCargableModel>());
        }

        public PartialViewResult EliminaNoCargable(int id)
        {
            List<CapturaDtEN> lst = (new CapturaBL()).EliminaNoCargable(id);

            AutoMapper.MapperConfiguration ConfMapperDet = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<CapturaDtEN, RegistroNoCargableModel>()
                       .ForMember(dest => dest.descripcion, opt => opt.MapFrom(src => src.descripcion_cargo))
                       .ForMember(dest => dest.horas, opt => opt.MapFrom(src => src.horas))
                       .ForMember(dest => dest.id_empleado, opt => opt.MapFrom(src => src.id_empleado))
                       .ForMember(dest => dest.id_oficina, opt => opt.MapFrom(src => src.id_oficina))
                       .ForMember(dest => dest.oficina, opt => opt.MapFrom(src => src.oficina))
                       .ForMember(dest => dest.concepto, opt => opt.MapFrom(src => src.concepto))
                       .ForMember(dest => dest.linea, opt => opt.MapFrom(src => src.linea))
                       );

            var mapper = ConfMapperDet.CreateMapper();
            List<RegistroNoCargableModel> _det = new List<RegistroNoCargableModel>();
            _det = mapper.Map<List<RegistroNoCargableModel>>(lst);

            return PartialView("_RegistroNoCargable", _det.AsEnumerable<RegistroNoCargableModel>());
        }

        public JsonResult RefrescaTotales(string id_empleado, string id_oficina)
        {
            Dictionary<string, decimal> lst = capturaService.CalculaTotales(id_empleado, id_oficina);

            return Json(new { Resultado = Constantes.S_OK, Cargable = lst["Cargables"].ToString("###,###,##0.00"), NoCargable = lst["NoCargables"].ToString("###,###,##0.00"), Horas = lst["Horas"].ToString("###,###,##0.00"), Gastos = lst["Gastos"].ToString("###,###,##0.00") });
        }

        public JsonResult AsignaOficinaCaptura(string id_oficina)
        {
            try
            {
                OficinaEN _oficina = (new OficinaBL()).DevuelveDatos(id_oficina);

                Session[TiempoEnProcesoHelper.Constantes.S_OFICINA0] = _oficina;

                if (_oficina != null)
                    return Json(new { Resultado = Constantes.S_OK });

                return Json(new { Resultado = Constantes.S_ERROR });
            }
            catch (Exception ex)
            {
                return Json(new { Resultado = Constantes.S_ERROR, MensajeError = ex.Message + (ex.InnerException != null ? string.Format(" [{0}]", ex.InnerException.Message) : "") });
            }
        }

        public JsonResult GrabaPantalla(Models.CapturaWebModel _model)
        {
            Session[Constantes.CAPTURA_TEMP] = _model;
            return Json(new { Resultado = Constantes.S_OK });
        }
    }
}