using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoEnProcesoDL;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL
{
    public class ReportesBL
    {
        TEPEntities db;
        
        

        public ReportesBL()
        {
            db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public ReportesBL(ref TEPEntities _db)
        {
            if (_db==null)
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);

            db = _db;
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
            
        }

        public DataTable Reporte_Auxiliar_Tep(string id_Oficina, string id_Socio, string id_Encargado, string id_cliente, string id_servicio, string id_Job)
        {
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<rpt_auxiliar_trabajo_proceso_Result, Rpt_AuxiliarTepEN>());
            List<Rpt_AuxiliarTepEN> lst = new List<Rpt_AuxiliarTepEN>();
            DataTable dt = new DataTable();

            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<Rpt_AuxiliarTepEN>>(db.rpt_auxiliar_trabajo_proceso(id_Oficina, id_Socio, id_Encargado, id_cliente, id_servicio, id_Job));
            dt = TiempoEnProcesoHelper.Helper.ToDataSet(lst).Tables[0];

            return dt;

        }
        public DataTable Reporte_Auxiliar_Tep_Sub(string id_Oficina, string id_Socio, string id_Encargado, string id_cliente, string id_servicio, string id_Job)
        {
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<rpt_auxiliar_trabajo_proceso_sub_reporte_Result, Rpt_AuxiliarTepSubRepEN>());
            List<Rpt_AuxiliarTepSubRepEN> lst = new List<Rpt_AuxiliarTepSubRepEN>();
            DataTable dt = new DataTable();

            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<Rpt_AuxiliarTepSubRepEN>>(db.rpt_auxiliar_trabajo_proceso_sub_reporte(id_Oficina, id_cliente, id_servicio, id_Job, id_Socio, id_Encargado));
            dt = TiempoEnProcesoHelper.Helper.ToDataSet(lst).Tables[0];
            return dt;
        }

        public DataTable Reporte_Auxiliar_Tep_Sub_Facturas(string id_Oficina, string id_cliente, string id_servicio, string id_Job)
        {
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<rpt_auxiliar_trabajo_proceso_facturas_anticipos_Result, Rpt_AuxiliarTepSubRepFactEN>());
            List<Rpt_AuxiliarTepSubRepFactEN> lst = new List<Rpt_AuxiliarTepSubRepFactEN>();
            DataTable dt = new DataTable();

            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<Rpt_AuxiliarTepSubRepFactEN>>(db.rpt_auxiliar_trabajo_proceso_facturas_anticipos(id_Oficina, id_cliente, id_servicio, id_Job));
            dt = TiempoEnProcesoHelper.Helper.ToDataSet(lst).Tables[0];
            return dt;
        }

        public DataTable Reporte_Relacion_Tep(string id_pais, string periodo, string ordenadopor, string salta, string id_Oficina, string id_Socio, string id_Encargado)
        {
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<rpt_relacion_trabajo_proceso_Result, Rpt_RelacionTepEN>());
            List<Rpt_RelacionTepEN> lst = new List<Rpt_RelacionTepEN>();
            DataTable dt = new DataTable();

            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<Rpt_RelacionTepEN>>(db.rpt_relacion_trabajo_proceso(id_pais, id_Oficina, periodo, ordenadopor, salta, id_Socio, id_Encargado));
            dt = TiempoEnProcesoHelper.Helper.ToDataSet(lst).Tables[0];

            return dt;
        }

        public DataTable Reporte_Balance_Antiguedad(string id_pais, DateTime fecha, string ordenadopor, string id_Oficina, string id_Socio, string id_Encargado, string id_cliente)
        {
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<rpt_balance_antiguedad_saldo_Result, Rpt_BalanceAntEN>());
            List<Rpt_BalanceAntEN> lst = new List<Rpt_BalanceAntEN>();
            DataTable dt = new DataTable();

            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<Rpt_BalanceAntEN>>(db.rpt_balance_antiguedad_saldo(id_Oficina, fecha, ordenadopor, id_Socio, id_Encargado, id_cliente));
            dt = TiempoEnProcesoHelper.Helper.ToDataSet(lst).Tables[0];

            return dt;

        }

        public DataTable Reporte_Balance_Antiguedad_SubPre(string id_pais, DateTime fecha, string ordenadopor, string id_Oficina, string id_Socio, string id_Encargado, string id_cliente)
        {
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<rpt_balance_antiguedad_saldos_resumen_preliminar_Result, Rpt_BalanceAntSubEN>());
            List<Rpt_BalanceAntSubEN> lst = new List<Rpt_BalanceAntSubEN>();
            DataTable dt = new DataTable();

            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<Rpt_BalanceAntSubEN>>(db.rpt_balance_antiguedad_saldos_resumen_preliminar(id_Oficina, fecha, id_Socio, id_Encargado, id_cliente));
            dt = TiempoEnProcesoHelper.Helper.ToDataSet(lst).Tables[0];

            return dt;
        }

        public DataTable Reporte_Balance_Antiguedad_SubDef(string id_pais, DateTime fecha, string ordenadopor, string id_Oficina, string id_Socio, string id_Encargado, string id_cliente)
        {
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<rpt_balance_antiguedad_saldos_resumen_definitiva_Result, Rpt_BalanceAntSubDefEN>());
            List<Rpt_BalanceAntSubDefEN> lst = new List<Rpt_BalanceAntSubDefEN>();
            DataTable dt = new DataTable();

            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<Rpt_BalanceAntSubDefEN>>(db.rpt_balance_antiguedad_saldos_resumen_definitiva(id_Oficina, fecha, id_Socio, id_Encargado, id_cliente));
            dt = TiempoEnProcesoHelper.Helper.ToDataSet(lst).Tables[0];

            return dt;
        }

        public DataTable Reporte_Sumario_Facturacion(string id_pais, string periodo, string tiporeporte, string salta, string id_Oficina, string id_Socio, string id_Encargado)
        {
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<rpt_sumario_facturacion_Result, SumarioFacturacionEN>());
            List<SumarioFacturacionEN> lst = new List<SumarioFacturacionEN>();
            DataTable dt = new DataTable();

            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<SumarioFacturacionEN>>(db.rpt_sumario_facturacion(id_pais, id_Oficina, periodo, tiporeporte, salta, salta, id_Socio, id_Encargado));
            dt = TiempoEnProcesoHelper.Helper.ToDataSet(lst).Tables[0];

            return dt;
        }

        public DataTable Reporte_Informe_Facturacion(string id_Oficina, string id_Socio, string id_Encargado, string mes, string mes1, string anio)
        {
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<rpt_informe_facturacion_Result, InformeFacturacionEN>());
            List<InformeFacturacionEN> lst = new List<InformeFacturacionEN>();
            DataTable dt = new DataTable();

            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<InformeFacturacionEN>>(db.rpt_informe_facturacion(id_Oficina, id_Socio, id_Encargado, mes, mes1, anio));
            dt = TiempoEnProcesoHelper.Helper.ToDataSet(lst).Tables[0];

            return dt;
        }

        public DataTable Reporte_Estado_Cuenta(string id_Oficina, string id_cliente, string id_servicio, string id_Job, string con_saldo)
        {
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<rpt_estado_cuenta_Result, Rpt_EstadoCuentaEN>());
            List<Rpt_EstadoCuentaEN> lst = new List<Rpt_EstadoCuentaEN>();
            DataTable dt = new DataTable();

            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<Rpt_EstadoCuentaEN>>(db.rpt_estado_cuenta(id_Oficina, id_cliente, id_servicio, id_Job, con_saldo));
            dt = TiempoEnProcesoHelper.Helper.ToDataSet(lst).Tables[0];

            return dt;

        }

        public DataTable Reporte_Historial_Cargos_Acumulados_Empleado(string id_Oficina, string id_empleado, string periodo)
        {
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<rpt_historial_cargos_acumulados_Result, HistorialCargosAcumuladosEmpleadoEN>());
            List<HistorialCargosAcumuladosEmpleadoEN> lst = new List<HistorialCargosAcumuladosEmpleadoEN>();
            DataTable dt = new DataTable();

            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<HistorialCargosAcumuladosEmpleadoEN>>(db.rpt_historial_cargos_acumulados(id_Oficina, id_empleado, periodo));
            dt = TiempoEnProcesoHelper.Helper.ToDataSet(lst).Tables[0];

            return dt;
        }
        public DataTable Reporte_Historial_Cargos_Acumulados_Empleados_Sub(string id_Oficina, string id_empleado, string periodo)
        {
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<rpt_historial_cargos_acumulados_empleado_resumen_Result, HistorialCargosAcumuladosEmpleadoSubEN>());
            List<HistorialCargosAcumuladosEmpleadoSubEN> lst = new List<HistorialCargosAcumuladosEmpleadoSubEN>();
            DataTable dt = new DataTable();

            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<HistorialCargosAcumuladosEmpleadoSubEN>>(db.rpt_historial_cargos_acumulados_empleado_resumen(id_Oficina, id_empleado, periodo));
            dt = TiempoEnProcesoHelper.Helper.ToDataSet(lst).Tables[0];

            return dt;
        }

        public DataTable Reporte_Historial_Cargos_Acumulados_Cliente(string id_Oficina, string id_cliente, string periodo)
        {
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<rpt_historial_cargos_acumulados_cliente_Result, HistorialCargosAcumuladosClienteEN>());
            List<HistorialCargosAcumuladosClienteEN> lst = new List<HistorialCargosAcumuladosClienteEN>();
            DataTable dt = new DataTable();

            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<HistorialCargosAcumuladosClienteEN>>(db.rpt_historial_cargos_acumulados_cliente(id_Oficina, id_cliente, periodo));
            dt = TiempoEnProcesoHelper.Helper.ToDataSet(lst).Tables[0];

            return dt;
        }
        public DataTable Reporte_Historial_Cargos_Acumulados_Cliente_Sub(string id_Oficina, string id_cliente, string periodo)
        {
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<rpt_historial_cargos_acumulados_cliente_resumen_Result, HistorialCargosAcumuladosClienteSubEN>());
            List<HistorialCargosAcumuladosClienteSubEN> lst = new List<HistorialCargosAcumuladosClienteSubEN>();
            DataTable dt = new DataTable();

            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<HistorialCargosAcumuladosClienteSubEN>>(db.rpt_historial_cargos_acumulados_cliente_resumen(id_Oficina, id_cliente, periodo));
            dt = TiempoEnProcesoHelper.Helper.ToDataSet(lst).Tables[0];

            return dt;
        }

        public DataTable Reporte_Integracion_Tep_Empleado_Gasto(string id_Oficina, string id_cliente, string id_servicio, string id_Job, string anio, string periodo)
        {
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<rpt_integracion_tep_empleado_gasto_Result, IntegracionEmpleadoGastoEN>());
            List<IntegracionEmpleadoGastoEN> lst = new List<IntegracionEmpleadoGastoEN>();
            DataTable dt = new DataTable();

            if (id_Job == TiempoEnProcesoHelper.Constantes.S_TODOS)
                id_Job = id_Job.Substring(0, 3);

            if (id_cliente == TiempoEnProcesoHelper.Constantes.S_TODOS)
                id_cliente = id_cliente.Substring(0, 3);

            if (id_servicio == TiempoEnProcesoHelper.Constantes.S_TODOS)
                id_servicio = id_servicio.Substring(0, 3);


            var mapper = ConfMapper.CreateMapper();
            lst = mapper.Map<List<IntegracionEmpleadoGastoEN>>(db.rpt_integracion_tep_empleado_gasto(id_Oficina, id_cliente, id_servicio, anio, periodo, id_Job));
            dt = TiempoEnProcesoHelper.Helper.ToDataSet(lst).Tables[0];

            return dt;
        }

        public DataTable Reporte_Por_Empleado(string id_empleado, string id_periodo)
        {
            List<RPT_REPORTESXEMPLEADO_Result> lst = new List<RPT_REPORTESXEMPLEADO_Result>();
            DataTable dt = new DataTable();

            lst = db.RPT_REPORTESXEMPLEADO(id_empleado, id_periodo).ToList<RPT_REPORTESXEMPLEADO_Result>();

            dt = TiempoEnProcesoHelper.Helper.ToDataSet(lst).Tables[0];

            return dt;
        }

        public DataTable Reporte_Por_Dia(string id_empleado, string id_periodo)
        {
            List<RPT_REPORTESXEMPLEADO_Diario_Result> lst = new List<RPT_REPORTESXEMPLEADO_Diario_Result>();
            DataTable dt = new DataTable();

            lst = db.RPT_REPORTESXEMPLEADO_Diario(id_empleado, id_periodo).ToList<RPT_REPORTESXEMPLEADO_Diario_Result>();

            dt = TiempoEnProcesoHelper.Helper.ToDataSet(lst).Tables[0];

            return dt;
        }

        public DataTable Reporte_Team_Acumulado(string id_oficina, string id_team, string anio_tep)
        {
            List<rpt_tiempo_cargado_team_acumulado_Result> lst = new List<rpt_tiempo_cargado_team_acumulado_Result>();
            DataTable dt = new DataTable();

            lst = db.rpt_tiempo_cargado_team_acumulado(id_oficina, id_team, anio_tep).ToList<rpt_tiempo_cargado_team_acumulado_Result>();

            dt = TiempoEnProcesoHelper.Helper.ToDataSet(lst).Tables[0];

            return dt;
        }

        public DataTable Reporte_Team_Periodo(string id_oficina, string id_team, string Periodo_tep)
        {
            List<rpt_tiempo_cargado_team_periodo_tep_Result> lst = new List<rpt_tiempo_cargado_team_periodo_tep_Result>();
            DataTable dt = new DataTable();

            lst = db.rpt_tiempo_cargado_team_periodo_tep(id_oficina, id_team, Periodo_tep).ToList<rpt_tiempo_cargado_team_periodo_tep_Result>();

            dt = TiempoEnProcesoHelper.Helper.ToDataSet(lst).Tables[0];

            return dt;
        }

        public DataTable Reporte_TiempoCargado_Team(string id_Oficina, string id_Team, string id_periodo)
        {
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<RPT_REPORTESXTEAM_Result, Rpt_BalanceAntEN>());
            List<Rpt_BalanceAntEN> lst = new List<Rpt_BalanceAntEN>();
            DataTable dt = new DataTable();

            var mapper = ConfMapper.CreateMapper();
            
            dt = TiempoEnProcesoHelper.Helper.ToDataSet(lst).Tables[0];

            return dt;

        }

        public DataTable Reporte_BitacoraCobro(string socio, string encargado, bool incluye)
        {
            DataTable dt = new DataTable();

            List<rpt_gestion_cobro_Result> lst = db.rpt_gestion_cobro(TiempoEnProcesoHelper.Helper.Oficina, socio, encargado, incluye).ToList();
            dt = TiempoEnProcesoHelper.Helper.ToDataSet(lst).Tables[0];

            return dt;
        }

        public DataTable Reporte_BitacoraCobroFactura(string id_entidad, decimal no_factura)
        {
            DataTable dt = new DataTable();

            List<rpt_gestion_cobro_detallado_Result> lst = db.rpt_gestion_cobro_detallado(TiempoEnProcesoHelper.Helper.Oficina,id_entidad,"FAC",no_factura).ToList();
            dt = TiempoEnProcesoHelper.Helper.ToDataSet(lst).Tables[0];

            return dt;
        }

        public List<FacturasPorSGEN> ObtieneFacturasSocio(string id_socio, string id_gerente, string id_entidad, string id_oficina)
        {
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<sp_obtiene_facturas_socio_gerente_Result, FacturasPorSGEN>());
            var mapper = ConfMapper.CreateMapper();
            List<FacturasPorSGEN> lst = mapper.Map<List<FacturasPorSGEN>>(db.sp_obtiene_facturas_socio_gerente(id_socio, id_gerente, id_oficina, id_entidad));

            return lst;
        }
    }
}
