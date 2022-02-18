using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoEnProcesoDL;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL
{
    public class CapturaBL
    {
        TEPEntities db;
        AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<sp_lista_gerente_Result, EncargadoEN>());
        public CapturaBL()
        {
            db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
            db.Configuration.ValidateOnSaveEnabled = true;
        }

        public CapturaBL(ref TEPEntities _db)
        {
            if (_db==null)
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);

            db = _db;
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
            db.Configuration.ValidateOnSaveEnabled = true;
        }

        public bool Verifica(string id_empleado, string id_oficina)
        {
            return db.tbl_reportes_tiempo_temp.Any(d => d.id_empleado == id_empleado);
        }

        public void Eliminar(string id_empleado, string id_oficina)
        {
            db.tbl_detalle_cargable_temp.Where(d => d.id_empleado == id_empleado && d.id_oficina == id_oficina).ToList().ForEach(d => db.tbl_detalle_cargable_temp.Remove(d));

            db.tbl_no_cargables_temp.Where(d => d.id_empleado == id_empleado && d.id_oficina == id_oficina).ToList().ForEach(d => db.tbl_no_cargables_temp.Remove(d));

            db.tbl_reportes_tiempo_temp.Where(d => d.id_empleado == id_empleado && d.id_oficina == id_oficina).ToList().ForEach(d => db.tbl_reportes_tiempo_temp.Remove(d));

            db.SaveChanges();
        }

        public void GrabarFinal(string id_empleado, string id_oficina)
        {
            //tbl_empleados empleado = db.tbl_empleados.FirstOrDefault(d => d.id_empleado == id_empleado);
            /*decimal id_reporte = db.tbl_reportes_tiempo.Max(d => d.id_reporte) + 1;
            

            db.tbl_reportes_tiempo_temp.Where(d => d.id_empleado == id_empleado && d.id_oficina == id_oficina).ToList()
                                            .ForEach(d => db.tbl_reportes_tiempo.Add(new tbl_reportes_tiempo()
                                            {
                                                a_dia = d.a_dia,
                                                captado_por = d.captado_por,
                                                de_dia = d.a_dia,
                                                id_empleado = d.id_empleado,
                                                id_oficina = d.id_oficina,
                                                id_reporte = id_reporte,
                                                periodo_tep_corresponde = d.periodo_tep_corresponde,
                                                periodo_tep_proceso = d.periodo_tep_proceso,
                                                tasa_cambio = 1
                                            }));

            db.tbl_detalle_cargable_temp.Where(d => d.id_empleado == id_empleado && d.id_oficina == id_oficina).OrderBy(d => d.linea).ToList()
                                            .ForEach(d => db.tbl_detalle_cargable.Add(new tbl_detalle_cargable()
                                            {
                                                descripcion_cargo = d.descripcion_cargo,
                                                gastoscaptadosweb = d.gastos ?? 0,
                                                horascaptadasweb = d.horas ?? 0,
                                                honorarioscaptadosweb = d.honorarios ?? 0,
                                                id_cliente = d.id_cliente,
                                                id_empleado = d.id_empleado,
                                                id_job = d.id_job,
                                                id_oficina0 = d.id_oficina0,
                                                id_reporte = id_reporte,
                                                linea = d.linea,
                                                horasxautencargado = 0,
                                                horasxautorizar = d.horas ?? 0,
                                                autorizotl = string.Empty,
                                                autorizoenc = string.Empty,
                                                horasrechazadas = 0,
                                                horasrechazadas_enc = 0,
                                                horas = 0,
                                                honorarios = 0,
                                                gastos = 0,
                                                cuota_facturacion = empleado.cuota_facturacion_local,
                                            }));

            db.tbl_no_cargables_temp.Where(d => d.id_empleado == id_empleado && d.id_oficina == id_oficina).OrderBy(d => d.linea).ToList()
                                            .ForEach(d => db.tbl_no_cargables.Add(new tbl_no_cargables()
                                            {
                                                descripcion = d.descripcion,
                                                horascaptadasweb = d.horas ?? 0,
                                                horasporautorizar = 0,
                                                horasrechazadas = 0,
                                                id_reporte = id_reporte,
                                                id_concepto = d.id_concepto,
                                                linea = d.linea
                                            }));

            db.tbl_detalle_cargable_temp.Where(d => d.id_empleado == id_empleado && d.id_oficina == id_oficina).ToList().ForEach(d => db.tbl_detalle_cargable_temp.Remove(d));

            db.tbl_no_cargables_temp.Where(d => d.id_empleado == id_empleado && d.id_oficina == id_oficina).ToList().ForEach(d => db.tbl_no_cargables_temp.Remove(d));

            db.tbl_reportes_tiempo_temp.Where(d => d.id_empleado == id_empleado && d.id_oficina == id_oficina).ToList().ForEach(d => db.tbl_reportes_tiempo_temp.Remove(d));

            db.SaveChanges(); */

            db.tep_insertahoras_web(id_oficina,id_empleado);
            
        }

        public void GrabarEntidad(CapturaHdrEN _encabezado, CapturaDtEN _detalle)
        {
            bool bExiste = false;
            tbl_reportes_tiempo_temp _cab = new tbl_reportes_tiempo_temp();
            if (bExiste = db.tbl_reportes_tiempo_temp.Any(d => d.id_oficina == _encabezado.id_oficina && d.id_empleado == _encabezado.id_empleado))
                _cab = db.tbl_reportes_tiempo_temp.FirstOrDefault(d => d.id_oficina == _encabezado.id_oficina && d.id_empleado == _encabezado.id_empleado);

            tbl_oficina _oficina = db.tbl_oficina.FirstOrDefault(d => d.id_oficina == _encabezado.id_oficina);
            if (db.tbl_trabajos.Any(d => d.id_job == _detalle.id_job && d.id_cliente == _detalle.id_cliente && d.id_oficina == _detalle.id_oficina && d.Inactivo_Cargo_Horas == true))
                throw new Exception("Job no permite captura de Horas");

            decimal iLinea = 1;
            if (_cab.tbl_detalle_cargable_temp.Count > 0)
                iLinea = _cab.tbl_detalle_cargable_temp.Max(d => d.linea) + 1;

            if (!bExiste)
            {
                _cab.a_dia = _encabezado.a_dia;
                _cab.captado_por = _encabezado.captado_por;
                _cab.de_dia = _encabezado.de_dia;
                _cab.id_empleado = _encabezado.id_empleado;
                _cab.id_oficina = _encabezado.id_oficina;
                _cab.periodo_tep_corresponde = _encabezado.periodo_tep_corresponde; //switch
                _cab.periodo_tep_proceso = _encabezado.periodo_tep_proceso;   //(_oficina.permite_facturar_en_periodo ?? 0) == 0 ? (new PeriodoBL()).ListarSiguienteUno(_encabezado.periodo_tep_proceso).id_periodo : _encabezado.periodo_tep_proceso;
                _cab.tasa_cambio = 1;
            
                db.tbl_reportes_tiempo_temp.Add(_cab);
            }

            if (_detalle.tipo == 2)
            {

                tbl_detalle_cargable_temp _det = new tbl_detalle_cargable_temp();
                _det.descripcion_cargo = _detalle.descripcion_cargo;
                _det.gastos = _detalle.gastos;
                _det.honorarios = _detalle.honorarios;
                _det.horas = _detalle.horas;
                _det.id_cliente = _detalle.id_cliente;
                _det.id_empleado = _detalle.id_empleado;
                _det.id_job = _detalle.id_job;
                _det.id_oficina = _detalle.id_oficina;
                _det.id_oficina0 = _detalle.id_oficina0;
                _det.linea = iLinea;
                _det.fecha_hora_captura = DateTime.Now;
                _det.id_tbl_entes_clientes = _detalle.id_tbl_entes_clientes;
                _det.tbl_reportes_tiempo_temp = _cab;
                _cab.tbl_detalle_cargable_temp.Add(_det);
            }
            else
            {
                tbl_no_cargables_temp _det = new tbl_no_cargables_temp();
                _det.descripcion = _detalle.descripcion_cargo;
                _det.horas = _detalle.horas;
                _det.id_concepto = _detalle.id_concepto;
                _det.id_empleado = _detalle.id_empleado;
                _det.id_oficina = _detalle.id_oficina;
                _det.linea = iLinea;
                db.tbl_no_cargables_temp.Add(_det);
            }

            db.SaveChanges();
        }

        public Dictionary<string, decimal> CalculaTotales(string id_empleado, string id_oficina)
        {
            Dictionary<string, decimal> lst = new Dictionary<string, decimal>();
            decimal dHoras = 0, dGastos = 0, dTotalCargable = 0, dTotalNoCargable = 0;
            if (db.tbl_reportes_tiempo_temp.Any(d => d.id_oficina == id_oficina && d.id_empleado == id_empleado))
            {
                tbl_reportes_tiempo_temp _cab = db.tbl_reportes_tiempo_temp.Include("tbl_detalle_cargable_temp").FirstOrDefault(d => d.id_oficina == id_oficina && d.id_empleado == id_empleado);

                if (_cab != null && _cab.tbl_detalle_cargable_temp.Count > 0)
                {
                    dGastos = _cab.tbl_detalle_cargable_temp.Sum(d => d.gastos) ?? 0;
                    dTotalCargable = _cab.tbl_detalle_cargable_temp.Sum(d => d.horas) ?? 0;
                }

                dTotalNoCargable = db.tbl_no_cargables_temp.Where(d => d.id_oficina == id_oficina && d.id_empleado == id_empleado).Sum(d => d.horas) ?? 0;

                dHoras = dTotalCargable + dTotalNoCargable;
            }

            lst.Add("Horas", dHoras);
            lst.Add("Gastos", dGastos);
            lst.Add("Cargables", dTotalCargable);
            lst.Add("NoCargables", dTotalNoCargable);

            return lst;
        }

        public decimal CalculaTotalesPorDia(string id_empleado, string id_oficina, decimal dia, string periodo)
        {
            Dictionary<string, decimal> lst = new Dictionary<string, decimal>();
            decimal dHoras = 0, dGastos = 0, dTotalCargable = 0, dTotalNoCargable = 0;
            if (db.tbl_reportes_tiempo_temp.Any(d => d.id_oficina == id_oficina && d.id_empleado == id_empleado && d.de_dia == dia))
            {
                tbl_reportes_tiempo_temp _cab = db.tbl_reportes_tiempo_temp.Include("tbl_detalle_cargable_temp").Include("tbl_no_cargables_temp").FirstOrDefault(d => d.id_oficina == id_oficina && d.id_empleado == id_empleado && d.de_dia == dia);

                if (_cab != null && _cab.tbl_detalle_cargable_temp.Count > 0)
                {
                    dGastos = _cab.tbl_detalle_cargable_temp.Sum(d => d.gastos) ?? 0;
                    dTotalCargable = _cab.tbl_detalle_cargable_temp.Sum(d => d.horas) ?? 0;
                    dTotalNoCargable = _cab.tbl_no_cargables_temp.Sum(d => d.horas) ?? 0;
                }               

                
            }

            if (db.tbl_reportes_tiempo.Any(d => d.id_oficina == id_oficina && d.id_empleado == id_empleado && d.de_dia == dia && d.periodo_tep_proceso == periodo))
            {
                var _cab1 = db.tbl_reportes_tiempo.FirstOrDefault(d => d.id_oficina == id_oficina && d.id_empleado == id_empleado && d.de_dia == dia && d.periodo_tep_proceso == periodo);
                            
                if (_cab1 != null )
                {
                    dGastos +=  db.tbl_detalle_cargable.Where(d=> d.id_reporte == _cab1.id_reporte).Sum(d => d.gastos) ?? 0;
                    dTotalCargable += db.tbl_detalle_cargable.Where(d => d.id_reporte == _cab1.id_reporte).Sum(d => d.horascaptadasweb) ?? 0;
                    dTotalNoCargable += db.tbl_no_cargables.Where(d => d.id_reporte == _cab1.id_reporte).Sum(d => d.horascaptadasweb) ?? 0;
                }

            }
            dHoras = dTotalCargable + dTotalNoCargable;
            return dHoras;
        }

        public List<CapturaDtEN> Detalle(string id_empleado, string id_oficina, bool Cargable)
        {
            List<CapturaDtEN> lst;

            AutoMapper.MapperConfiguration _map;
            if (Cargable)
            {
                _map = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<vw_detalle_captura_temp_cargable, CapturaDtEN>()
                                                                                    .ForMember(dest => dest.descripcion_cargo, opt => opt.MapFrom(src => src.descripcion_cargo))
                                                                                   .ForMember(dest => dest.gastos, opt => opt.MapFrom(src => src.gastos))
                                                                                   .ForMember(dest => dest.horas, opt => opt.MapFrom(src => src.horas))
                                                                                   .ForMember(dest => dest.id_cliente, opt => opt.MapFrom(src => src.id_cliente))
                                                                                   .ForMember(dest => dest.id_empleado, opt => opt.MapFrom(src => src.id_empleado))
                                                                                   .ForMember(dest => dest.id_job, opt => opt.MapFrom(src => src.id_job))
                                                                                   .ForMember(dest => dest.id_oficina, opt => opt.MapFrom(src => src.id_oficina))
                                                                                   .ForMember(dest => dest.cliente, opt => opt.MapFrom(src => src.Razon_Social))
                                                                                   .ForMember(dest => dest.job, opt => opt.MapFrom(src => src.descripcion))
                                                                                   .ForMember(dest => dest.oficina, opt => opt.MapFrom(src => src.Nombre))
                                                                                   .ForMember(dest => dest.linea, opt => opt.MapFrom(src => src.linea))
                                                                                   );

                var mapper = _map.CreateMapper();

                lst = mapper.Map<List<CapturaDtEN>>(db.vw_detalle_captura_temp_cargable.Where(d => d.id_empleado == id_empleado && d.id_oficina == id_oficina));

                

            }
            else
            {
                _map = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<vw_detalle_captura_temp_Nocargable, CapturaDtEN>()
                                                                                    .ForMember(dest => dest.id_empleado, opt => opt.MapFrom(src => src.id_empleado))
                                                                                    .ForMember(dest => dest.descripcion_cargo, opt => opt.MapFrom(src => src.descripcion))
                                                                                    .ForMember(dest => dest.horas, opt => opt.MapFrom(src => src.horas))
                                                                                    .ForMember(dest => dest.id_concepto, opt => opt.MapFrom(src => src.id_concepto))
                                                                                    .ForMember(dest => dest.id_oficina, opt => opt.MapFrom(src => src.id_oficina))
                                                                                    .ForMember(dest => dest.oficina, opt => opt.MapFrom(src => src.Nombre))
                                                                                    .ForMember(dest => dest.concepto, opt => opt.MapFrom(src => src.descConcepto))
                                                                                    .ForMember(dest => dest.linea, opt => opt.MapFrom(src => src.linea))
                                                                                    );

                var mapper = _map.CreateMapper();
                lst = mapper.Map<List<CapturaDtEN>>(db.vw_detalle_captura_temp_Nocargable.Where(d => d.id_empleado == id_empleado && d.id_oficina == id_oficina));
            }
            return lst;
        }

        public List<CapturaDtEN> EliminaCargable(decimal id)
        {
            List<CapturaDtEN> lst;

            tbl_detalle_cargable_temp _temp = db.tbl_detalle_cargable_temp.FirstOrDefault(d => d.linea == id);

            string id_empleado = _temp.id_empleado;
            string id_oficina = _temp.id_oficina;

            db.tbl_detalle_cargable_temp.Remove(_temp);
            db.SaveChanges();

            AutoMapper.MapperConfiguration _map;
            _map = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<vw_detalle_captura_temp_cargable, CapturaDtEN>()
                                                                                .ForMember(dest => dest.descripcion_cargo, opt => opt.MapFrom(src => src.descripcion_cargo))
                                                                                .ForMember(dest => dest.gastos, opt => opt.MapFrom(src => src.gastos))
                                                                                .ForMember(dest => dest.horas, opt => opt.MapFrom(src => src.horas))
                                                                                .ForMember(dest => dest.id_cliente, opt => opt.MapFrom(src => src.id_cliente))
                                                                                .ForMember(dest => dest.id_empleado, opt => opt.MapFrom(src => src.id_empleado))
                                                                                .ForMember(dest => dest.id_job, opt => opt.MapFrom(src => src.id_job))
                                                                                .ForMember(dest => dest.id_oficina, opt => opt.MapFrom(src => src.id_oficina))
                                                                                .ForMember(dest => dest.cliente, opt => opt.MapFrom(src => src.Razon_Social))
                                                                                .ForMember(dest => dest.job, opt => opt.MapFrom(src => src.descripcion))
                                                                                .ForMember(dest => dest.oficina, opt => opt.MapFrom(src => src.Nombre))
                                                                                .ForMember(dest => dest.linea, opt => opt.MapFrom(src => src.linea))
                                                                                );

            var mapper = _map.CreateMapper();

            lst = mapper.Map<List<CapturaDtEN>>(db.vw_detalle_captura_temp_cargable.Where(d => d.id_empleado == id_empleado && d.id_oficina == id_oficina));           
           
            return lst;
        }

        public List<CapturaDtEN> EliminaNoCargable(decimal id)
        {
            List<CapturaDtEN> lst;

            tbl_no_cargables_temp _temp = db.tbl_no_cargables_temp.FirstOrDefault(d => d.linea == id);

            string id_empleado = _temp.id_empleado;
            string id_oficina = _temp.id_oficina;

            db.tbl_no_cargables_temp.Remove(_temp);
            db.SaveChanges();

            AutoMapper.MapperConfiguration _map;
            _map = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<vw_detalle_captura_temp_Nocargable, CapturaDtEN>()
                                                                                    .ForMember(dest => dest.id_empleado, opt => opt.MapFrom(src => src.id_empleado))
                                                                                    .ForMember(dest => dest.descripcion_cargo, opt => opt.MapFrom(src => src.descripcion))
                                                                                    .ForMember(dest => dest.horas, opt => opt.MapFrom(src => src.horas))
                                                                                    .ForMember(dest => dest.id_concepto, opt => opt.MapFrom(src => src.id_concepto))
                                                                                    .ForMember(dest => dest.id_oficina, opt => opt.MapFrom(src => src.id_oficina))
                                                                                    .ForMember(dest => dest.oficina, opt => opt.MapFrom(src => src.Nombre))
                                                                                    .ForMember(dest => dest.concepto, opt => opt.MapFrom(src => src.descConcepto))
                                                                                    .ForMember(dest => dest.linea, opt => opt.MapFrom(src => src.linea))
                                                                                    );

            var mapper = _map.CreateMapper();
            lst = mapper.Map<List<CapturaDtEN>>(db.vw_detalle_captura_temp_Nocargable.Where(d => d.id_empleado == id_empleado && d.id_oficina == id_oficina));

            return lst;
        }
    }
}
//http://www.c-sharpcorner.com/UploadFile/d551d3/how-to-load-partial-views-in-Asp-Net-mvc-using-jquery-ajax/
//http://www.codeguru.com/csharp/.net/net_asp/mvc/article.php/c20139/Confirming-Delete-Operations-in-ASPNET-MVC.htm