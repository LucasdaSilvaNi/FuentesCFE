using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using TiempoEnProcesoDL;
using TiempoEnProcesoHelper;
using TiempoEnProceso.Forms;
using System.IO;
using Infragistics.Win.AppStyling;

namespace TiempoEnProceso
{
    public partial class frmPrincipal : Form
    {
        #region Properties - Forms
        frmCapturaReporteTiempo frmCapturaReporteTiempo;
        frmGastosManuales frmGastosManuales;
        frmGastosAutomaticos frmGastosAutomaticos;
        frmCreditosAplicaciones frmCreditosAplicaciones;
        frmRpt_AutorizacionTiempo frmRpt_AutorizacionTiempo;
        frmRpt_CierreMensual frmRpt_CierreMensual;
        frmRpt_RelacionTEP frmRpt_RelacionTEP;
        frmRpt_CatalogoPaises frmRpt_CatalogoPaises;
        frmRpt_CatalogoOficinas frmRpt_CatalogoOficinas;
        frmRpt_CatalogoEntesLegales frmRpt_CatalogoEntesLegales;
        frmGeneracionFactura frmGeneracionFactura;
        frmCobranzaNC frmCobranzaNC;
        frmCobranzaNC frmNotaCredito;
        frmRpt_CatalogoGrupos frmRpt_CatalogoGrupos;
        frmRpt_CatalogoIndustrias frmRpt_CatalogoIndustrias;
        frmRpt_CatalogoClientes frmRpt_CatalogoClientes;
        frmRpt_CatalogoEmpleados frmRpt_CatalogoEmpleados;
        frmRpt_CatalogoGastosAdmin frmRpt_CatalogoGastosAdmin;
        frmRpt_CatalogoServicios frmRpt_CatalogoServicios;
        frmRpt_CatalogoJob frmRpt_CatalogoJob;
        frmRpt_ValidacionReportesTiempo frmRpt_ValidacionReportesTiempo;
        frmRpt_ValidacionGastosAdmon frmRpt_ValidacionGastosAdmon;
        frmRpt_AuxiliarTEP frmRpt_AuxiliarTEP;
        frmRpt_ValidacionFacturas frmRpt_ValidacionFacturas;
        frmRpt_CobranzaNC frmRpt_CobranzaNC;
        frmRpt_ValidacionFacturasAnuladas frmRpt_ValidacionFacturasAnuladas;
        frmRpt_ValidacionCobranzaNC frmRpt_ValidacionCobranzaNC;
        frmRpt_SolicitudFacturas frmRpt_SolicitudFacturas;

        frmRpt_ValidacionSolicitudAnuladas frmRpt_ValidacionSolicitudAnuladas;
        frmRpt_ValidacionFacturasPorGenerar frmRpt_ValidacionFacturasPorGenerar;
        frmRpt_SolicitudFacturasPorGenerar frmRpt_SolicitudFacturasPorGenerar;
        frmRpt_BalanceAntiguedad frmRpt_BalanceAntiguedad;
        frmRpt_ValidacionCreditosAplicaciones frmRpt_ValidacionCreditosAplicaciones;
        frmRpt_BalanceAntiguedadClientes frmRpt_BalanceAntiguedadClientes;
        frmRpt_BalanceAntiguedadMore frmRpt_BalanceAntiguedadMore;
        frmRpt_SumarioFacturacionDefinitiva frmRpt_SumarioFacturacionDefinitiva;
        frmRpt_IntegracionTEPEmpleado frmRpt_IntegracionTEPEmpleado;
        frmRpt_TrasladoTiempos frmRpt_TrasladoTiempos;
        frmRpt_EstadoCuenta frmRpt_EstadoCuenta;
        frmRpt_HistorialCargosAcumulados frmRpt_HistorialCargosAcumulados;
        frmRpt_ConsultaClientes frmRpt_ConsultaClientes;
        frmRpt_ConsultaFactura frmRpt_ConsultaFactura;
        frmRpt_PolizaVentas frmRpt_PolizaVentas;
        frmRpt_EstadisticaTiempoCargado frmRpt_EstadisticaTiempoCargado;
        frmRpt_EstadisticaTiempoCargadoPorDestino frmRpt_EstadisticaTiempoCargadoPorDestino;
        frmRpt_EstadisticaTiempoNoCargado frmRpt_EstadisticaTiempoNoCargado;
        frmRpt_EstadisticaTiempoCargadoPorPeriodo frmRpt_EstadisticaTiempoCargadoPorPeriodo;
        frmRpt_ClientesSinMovimiento frmRpt_ClientesSinMovimiento;
        frmAnulacionSolicitud frmAnulacionSolicitud;
        frmAnulacionDocumento frmAnulacionDocumento;
        frmTrasladoTiempo frmTrasladoTiempo;
        frmBitacoraCobro frmBitacoraCobro;
        frmImpresionFactura frmImpresionFactura;
        frmRpt_RevenueAcumulado frmRpt_RevenueAcumulado;
        frmRpt_Cumpleanios frmRpt_Cumpleanios;
        frmRpt_CuadreTEP frmRpt_CuadreTEP;
        frmRpt_ReportesPendienteEntregar frmRpt_ReportesPendienteEntregar;
        frmRpt_GestionCobro frmRpt_GestionCobro;
        frmGeneracionFacElecCR frmGeneracionFacElecCR;
        frmConsultaFacElecCR frmConsultaFacElecCR;
        frmNotificacionPagoFacElecCR frmNotificacionPagoFacElecCR;
        frmLogin frmLogin;
        frmCambioClienteJob frmCambioClienteJob;
        frmRpt_ValidacionAnulacionCobranzaNC frmRpt_ValidacionAnulacionCobranzaNC;
        frmSolicitudFactura frmSolicitudFactura;
        frmRpt_ListadoHonorariosCargadosN frmRpt_ListadoHonorariosCargadosN;
        frmRpt_LibroVentasConsES frmRpt_LibroVentasConsES;
        frmRpt_LibroVentasContriES frmRpt_LibroVentasContriES;
        frmGeneracionFacElecGT frmGeneracionFacElecGT;
        frmConsultaFacElecGT frmConsultaFacElecGT;
        frmRpt_ReporteRentabilidad frmRpt_ReporteRentabilidad;
        frmDistribucionFactura frmDistribucionFactura;
        #endregion
        public frmPrincipal()
        {
            InitializeComponent();
        }

        #region Metodos
        private void Inicializa()
        {
            StyleManager.Load(AsignarEstilo(Helper.Style));

            ultraStatusBar1.Panels[0].Text = Helper.servidor;
            ultraStatusBar1.Panels[1].Text = Helper.db;
            ultraStatusBar1.Panels[3].Text = string.Format("{0} {1}", (Helper.UsuarioActivo as tbl_empleados).Nombres.Trim(), (Helper.UsuarioActivo as tbl_empleados).apellidos.Trim());
            //ultraStatusBar1.Panels[3].Text = (Helper.EmpresaActiva as empresas).Nombre_Empresa;
            //ultraStatusBar1.Panels[4].Text = $"{System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern}^{System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern}";
            ultraStatusBar1.Panels[5].Text = (Helper.OficinaActiva as tbl_oficina).periodo_proceso;
            ultraStatusBar1.Panels[6].Text = Application.ProductVersion;

            ultraToolbarsManager1.Style = ToolbarStyle.Office2013;
            this.Text = Helper.NombreAplicacion;
        }

        public Stream AsignarEstilo(string StyleName)
        {
            byte[] EstiloPorAplicar = Properties.Resources.Nautilus;
            switch (StyleName)
            {
                case "Nautilus":
                    EstiloPorAplicar = Properties.Resources.Nautilus;
                    break;
                case "VS2010":
                    EstiloPorAplicar = Properties.Resources.VS2010;
                    break;
                case "Metro":
                    EstiloPorAplicar = Properties.Resources.Metro;
                    break;
                case "IG":
                    EstiloPorAplicar = Properties.Resources.IG;
                    break;
                case "LucidDream":
                    EstiloPorAplicar = Properties.Resources.LucidDream;
                    break;
                case "ModClay":
                    EstiloPorAplicar = Properties.Resources.ModClay;
                    break;
                case "NoirModerne":
                    EstiloPorAplicar = Properties.Resources.NoirModerne;
                    break;
                case "Office2013DarkGray":
                    EstiloPorAplicar = Properties.Resources.Office2013DarkGray;
                    break;
                case "Office2013LightGray":
                    EstiloPorAplicar = Properties.Resources.Office2013LightGray;
                    break;
                case "Office2013White":
                    EstiloPorAplicar = Properties.Resources.Office2013White;
                    break;
                case "RedPlanet":
                    EstiloPorAplicar = Properties.Resources.RedPlanet;
                    break;
                case "Trendy":
                    EstiloPorAplicar = Properties.Resources.Trendy;
                    break;
                case "Windows8-DarkGray-Blue":
                    EstiloPorAplicar = Properties.Resources.Windows8_DarkGray_Blue;
                    break;
                case "TheBlue":
                    EstiloPorAplicar = Properties.Resources.TheBlues;
                    break;

            }
            MemoryStream MStream = new MemoryStream(EstiloPorAplicar);

            return MStream;
        }

        public void ConstruirMenu()
        {
            List<tbl_opciones> lstO=(List<tbl_opciones>) Helper.Permisos;

            //Oculto todos los tools
            foreach (RibbonTab tab in ultraToolbarsManager1.Ribbon.Tabs)
            {
                tab.Visible = false;

                foreach (RibbonGroup grup in tab.Groups)
                {
                    grup.Visible = false;
                    foreach (ToolBase tool in grup.Tools)
                        tool.SharedProps.Visible = false;
                }
            }

            foreach (RibbonTab rt in ultraToolbarsManager1.Ribbon.Tabs)
            {
                foreach (RibbonGroup grup in rt.Groups)
                {
                    foreach (ToolBase tool in grup.Tools)
                    {
                        if (tool.Tag != null)
                        {
                            tool.SharedProps.Visible = lstO.Any(d => d.pantalla.Trim() == tool.Tag.ToString()) || tool.Tag.ToString() == "CambiaClave" || tool.Tag.ToString() == "CambiarValores" || tool.Tag.ToString() == "formatos" || tool.Tag.ToString() == "Cumpleaños" || tool.Tag.ToString()=="AccesoalSistema";
                            grup.Visible = grup.Visible || tool.SharedProps.Visible;
                            rt.Visible = rt.Visible || grup.Visible;
                        }
                    }
                }
            }
        }

        private bool EstaAbierta(Int64 TagID, int iTask)
        {
            if (ultraTabbedMdiManager1.TabGroups.Count < 1)
                return false;

            foreach (Infragistics.Win.UltraWinTabbedMdi.MdiTab Tab in ultraTabbedMdiManager1.TabGroups[0].Tabs)
            {

                if (Tab.Form.Tag != null && Tab.Form.Tag.ToString() == iTask.ToString() + "," + TagID.ToString())
                {
                    Tab.Activate();
                    Tab.Show();
                    return true;
                }
            }
            return false;
        }

        private bool EstaAbierta(string name)
        {
            if (ultraTabbedMdiManager1.TabGroups.Count < 1)
                return false;

            foreach (Infragistics.Win.UltraWinTabbedMdi.MdiTab Tab in ultraTabbedMdiManager1.TabGroups[0].Tabs)
            {
                if (Tab.Form.Name.ToLower() == name.ToLower())
                {
                    Tab.Activate();
                    Tab.Show();
                    return true;
                }
            }
            return false;
        }
        #endregion

        private void ultraToolbarsManager1_BeforeApplicationMenuDropDown(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            Inicializa();
            ConstruirMenu();
        }

        private void ultraToolbarsManager1_ToolClick(object sender, ToolClickEventArgs e)
        {
            Helper.Continuo = false;
            ultraPictureBox1.Visible = false;
            if (e.Tool.Tag != null)
            {
                TEPEntities db = new TEPEntities(Helper.CadenaConexion);
                string _op = e.Tool.Tag.ToString();
                Helper.Continuo = true;
            }
            switch (e.Tool.Key)
            {
                case "paises":    // ButtonTool
                    if (!EstaAbierta("frmPaises"))
                    {
                        frmPaises frm = new frmPaises();
                        frm.MdiParent = this;
                        frm.Show();
                    }

                    break;

                case "Usuarios":    // ButtonTool
                    // Place code here
                    break;

                case "CambiarValores":    // ButtonTool
                    // Place code here
                    break;

                case "CambiaClave":    // ButtonTool
                    // Place code here
                    break;

                case "Oficinas":    // ButtonTool
                    if (!EstaAbierta("frmOficinas"))
                    {
                        frmOficinas frm = new frmOficinas();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    break;

                case "FormatosFacturas":    // ButtonTool
                    if (!EstaAbierta("frmFormatos"))
                    {
                        frmFormatos frm = new frmFormatos();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    break;

                case "EntidadLegal":    // ButtonTool

                    if (!EstaAbierta("frmEntidades"))
                    {
                        frmEntidades frm = new frmEntidades();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    break;

                case "Jerarquias":    // ButtonTool
                    if (!EstaAbierta("frmJerarquias"))
                    {
                        frmJerarquias frm = new frmJerarquias();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    break;

                case "Puestos":    // ButtonTool
                    if (!EstaAbierta("frmJerarquiasOpciones"))
                    {
                        frmJerarquiasOpciones frm = new frmJerarquiasOpciones();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    break;
                case "OpcionesEmpleado":
                    if (!EstaAbierta("frmEmpleadosOpciones"))
                    {
                        frmEmpleadosOpciones frm = new frmEmpleadosOpciones();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    break;
                case "Lineas":    // ButtonTool
                    if (!EstaAbierta("frmLineas"))
                    {
                        frmLineas frm = new frmLineas();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    break;

                case "Servicios":    // ButtonTool
                    if (!EstaAbierta("frmServicios"))
                    {
                        frmServicios frm = new frmServicios();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    break;

                case "Productos":    // ButtonTool
                    if (!EstaAbierta("frmProductos"))
                    {
                        frmProductos frm = new frmProductos();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    break;

                case "NoCargables":    // ButtonTool
                    if (!EstaAbierta("frmConceptos"))
                    {
                        frmConceptos frm = new frmConceptos();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    break;

                case "GastosAdministrativos":    // ButtonTool
                    if (!EstaAbierta("frmGastosAdmon"))
                    {
                        frmGastosAdmon frm = new frmGastosAdmon();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    break;

                case "Teams":    // ButtonTool
                    if (!EstaAbierta("frmTeams"))
                    {
                        frmTeams frm = new frmTeams();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    break;

                case "Empleados":    // ButtonTool
                    if (!EstaAbierta("frmEmpleados"))
                    {
                        frmEmpleados frm = new frmEmpleados();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    break;

                case "Grupos":    // ButtonTool
                    if (!EstaAbierta("frmGrupos"))
                    {
                        frmGrupos frm = new frmGrupos();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    break;

                case "Industrias":    // ComboBoxTool
                    if (!EstaAbierta("frmIndustrias"))
                    {
                        frmIndustrias frm = new frmIndustrias();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    break;

                case "Clientes":    // ButtonTool
                    if (!EstaAbierta("frmClientes"))
                    {
                        frmCliente frm = new frmCliente();
                        //frm.MdiParent = this;
                        frm.ShowDialog();
                    }
                    break;


                case "Trabajos":    // ButtonTool
                    if (!EstaAbierta("frmJobs"))
                    {
                        frmJobs frm = new frmJobs();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    
                    break;
                case "CapturaTiempoGastos":
                    if (!EstaAbierta("frmCapturaReporteTiempo"))
                    {
                        frmCapturaReporteTiempo = new frmCapturaReporteTiempo();
                        //frm.MdiParent = this;
                        frmCapturaReporteTiempo.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "GastosManuales":
                    if (!EstaAbierta("frmGastosManuales"))
                    {
                        frmGastosManuales = new frmGastosManuales();
                        //frm.MdiParent = this;
                        frmGastosManuales.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "GastosAutomaticos":
                    if (!EstaAbierta("frmGastosAutomaticos"))
                    {
                        frmGastosAutomaticos = new frmGastosAutomaticos();
                        //frm.MdiParent = this;
                        frmGastosAutomaticos.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "CreditosyAplicaciones":
                    if (!EstaAbierta("frmCreditosAplicaciones"))
                    {
                        frmCreditosAplicaciones = new frmCreditosAplicaciones();
                        //frm.MdiParent = this;
                        frmCreditosAplicaciones.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "AutorizaTiempo":
                    if (!EstaAbierta("frmRpt_AutorizacionTiempo"))
                    {
                        frmRpt_AutorizacionTiempo = new frmRpt_AutorizacionTiempo();
                        //frm.MdiParent = this;
                        frmRpt_AutorizacionTiempo.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "CierreTep":
                    if (!EstaAbierta("frmRpt_CierreMensual"))
                    {
                        frmRpt_CierreMensual = new frmRpt_CierreMensual();
                        //frm.MdiParent = this;
                        frmRpt_CierreMensual.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Relacion TEP":
                    if (!EstaAbierta("frmRpt_RelacionTEP"))
                    {
                        frmRpt_RelacionTEP = new frmRpt_RelacionTEP();
                        //frm.MdiParent = this;
                        frmRpt_RelacionTEP.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;

                case "Catalogo Paises":

                    if (!EstaAbierta("frmRpt_CatalogoPaises"))
                    {
                        frmRpt_CatalogoPaises = new frmRpt_CatalogoPaises();
                        //frm.MdiParent = this;
                        frmRpt_CatalogoPaises.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Catalogo Oficinas":

                    if (!EstaAbierta("frmRpt_CatalogoOficinas"))
                    {
                        frmRpt_CatalogoOficinas = new frmRpt_CatalogoOficinas();
                        //frm.MdiParent = this;
                        frmRpt_CatalogoOficinas.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Entidades Legales":
                    if (!EstaAbierta("frmRpt_CatalogoEntesLegales"))
                    {
                        frmRpt_CatalogoEntesLegales = new frmRpt_CatalogoEntesLegales();
                        //frm.MdiParent = this;
                        frmRpt_CatalogoEntesLegales.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Solicitud de Factura":
                    if (!EstaAbierta("frmSolicitudFactura"))
                    {
                        if (Helper.Oficina == Helper.CR)
                        {
                            frmSolicitudFacturaCR frm = new frmSolicitudFacturaCR();
                            frm.ShowDialog();
                        }
                        else if (Helper.HN.Contains(Helper.Oficina))
                        {
                            frmSolicitudFacturaHN frm = new frmSolicitudFacturaHN();
                            frm.ShowDialog();
                        }
                        else
                        {
                            frmSolicitudFactura = new frmSolicitudFactura();
                            frmSolicitudFactura.ShowDialog();
                            //ultraPictureBox1.Visible = true;
                        }
                    }
                    break;
                case "Generación de Factura":
                    if (!EstaAbierta("frmGeneracionFactura"))
                    {
                        frmGeneracionFactura = new frmGeneracionFactura();

                        frmGeneracionFactura.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Generacion Factura Electrónica":
                    if (!EstaAbierta("frmGeneracionFacElecCR"))
                    {
                        frmGeneracionFacElecCR = new frmGeneracionFacElecCR();

                        frmGeneracionFacElecCR.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;

                case "Consulta Documento Electrónico":
                    if (!EstaAbierta("frmConsultaFacElecCR"))
                    {
                        frmConsultaFacElecCR = new frmConsultaFacElecCR();

                        frmConsultaFacElecCR.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Notificacion Pago Factura de Gobierno":
                    if (!EstaAbierta("frmNotificacionPagoFacElecCR"))
                    {
                        frmNotificacionPagoFacElecCR = new  frmNotificacionPagoFacElecCR();

                        frmNotificacionPagoFacElecCR.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Generacion Documento Electrónico GT":
                    if (!EstaAbierta("frmGeneracionFacElecGT"))
                    {
                        frmGeneracionFacElecGT = new frmGeneracionFacElecGT();

                        frmGeneracionFacElecGT.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;

                case "Consulta Documento Electrónico GT":
                    if (!EstaAbierta("frmConsultaFacElecCR"))
                    {
                        frmConsultaFacElecGT = new frmConsultaFacElecGT();

                        frmConsultaFacElecGT.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Cobranza":
                    if (!EstaAbierta("frmCobranzaNC"))
                    {
                        frmCobranzaNC = new frmCobranzaNC();
                        frmCobranzaNC.EsCobranza = true;

                        frmCobranzaNC.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Nota Crédito":
                    if (!EstaAbierta("frmCobranzaNC"))
                    {
                        frmNotaCredito = new frmCobranzaNC();
                        frmNotaCredito.EsCobranza = false;
                        frmNotaCredito.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "rptGrupos":
                    if (!EstaAbierta("frmRpt_CatalogoGrupos"))
                    {
                        frmRpt_CatalogoGrupos = new frmRpt_CatalogoGrupos();
                        //frm.MdiParent = this;
                        frmRpt_CatalogoGrupos.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "RptIndustrias":
                    if (!EstaAbierta("frmRpt_CatalogoIndustrias"))
                    {
                        frmRpt_CatalogoIndustrias = new frmRpt_CatalogoIndustrias();
                        //frm.MdiParent = this;
                        frmRpt_CatalogoIndustrias.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "RptClientes":
                    if (!EstaAbierta("frmRpt_CatalogoClientes"))
                    {
                        frmRpt_CatalogoClientes = new frmRpt_CatalogoClientes();
                        //frm.MdiParent = this;
                        frmRpt_CatalogoClientes.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "RptEmpleados":
                    if (!EstaAbierta("frmRpt_CatalogoEmpleados"))
                    {
                        frmRpt_CatalogoEmpleados = new frmRpt_CatalogoEmpleados();
                        //frm.MdiParent = this;
                        frmRpt_CatalogoEmpleados.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "RptGastosAdministrativo":
                    if (!EstaAbierta("frmRpt_CatalogoGastosAdmin"))
                    {
                        frmRpt_CatalogoGastosAdmin = new frmRpt_CatalogoGastosAdmin();
                        //frm.MdiParent = this;
                        frmRpt_CatalogoGastosAdmin.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "RptServicios":
                    if (!EstaAbierta("frmRpt_CatalogoServicios"))
                    {
                        frmRpt_CatalogoServicios = new frmRpt_CatalogoServicios();
                        //frm.MdiParent = this;
                        frmRpt_CatalogoServicios.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "RptJob":
                    if (!EstaAbierta("frmRpt_CatalogoJob"))
                    {
                        frmRpt_CatalogoJob = new frmRpt_CatalogoJob();
                        //frm.MdiParent = this;
                        frmRpt_CatalogoJob.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Reportes Tiempo":
                    if (!EstaAbierta("frmRpt_ValidacionReportesTiempo"))
                    {
                        frmRpt_ValidacionReportesTiempo = new frmRpt_ValidacionReportesTiempo();
                        frmRpt_ValidacionReportesTiempo.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Validacion Gastos Administrativos":
                    if (!EstaAbierta("frmRpt_ValidacionGastosAdmon"))
                    {
                        frmRpt_ValidacionGastosAdmon = new frmRpt_ValidacionGastosAdmon();
                        frmRpt_ValidacionGastosAdmon.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Auxiliar Tep":
                    if (!EstaAbierta("frmRpt_ValidacionGastosAdmon"))
                    {
                        frmRpt_AuxiliarTEP = new frmRpt_AuxiliarTEP();
                        frmRpt_AuxiliarTEP.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Validacion Facturas":
                    if (!EstaAbierta("frmRpt_ValidacionFacturas"))
                    {
                        frmRpt_ValidacionFacturas = new frmRpt_ValidacionFacturas();
                        frmRpt_ValidacionFacturas.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Validacion Cobranza":
                    if (!EstaAbierta("frmRpt_CobranzaNC"))
                    {
                        frmRpt_CobranzaNC = new frmRpt_CobranzaNC();
                        frmRpt_CobranzaNC.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Validacion Anulación Facturas":
                    if (!EstaAbierta("frmRpt_ValidacionFacturasAnuladas"))
                    {
                        frmRpt_ValidacionFacturasAnuladas = new frmRpt_ValidacionFacturasAnuladas();
                        frmRpt_ValidacionFacturasAnuladas.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Cobranzas / Notas Credito":
                    if (!EstaAbierta("frmRpt_ValidacionCobranzaNC"))
                    {
                        frmRpt_ValidacionAnulacionCobranzaNC = new frmRpt_ValidacionAnulacionCobranzaNC();
                        frmRpt_ValidacionAnulacionCobranzaNC.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Reporte Solicitud Factura":
                    if (!EstaAbierta("frmRpt_SolicitudFacturas"))
                    {
                        frmRpt_SolicitudFacturas = new frmRpt_SolicitudFacturas();
                        frmRpt_SolicitudFacturas.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Reporte Anulación de Solicitudes":
                    if (!EstaAbierta("frmRpt_ValidacionSolicitudAnuladas"))
                    {
                        frmRpt_ValidacionSolicitudAnuladas = new frmRpt_ValidacionSolicitudAnuladas();
                        frmRpt_ValidacionSolicitudAnuladas.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Facturas por Generar":
                    if (!EstaAbierta("frmRpt_ValidacionFacturasPorGenerar"))
                    {
                        frmRpt_ValidacionFacturasPorGenerar = new frmRpt_ValidacionFacturasPorGenerar();
                        frmRpt_ValidacionFacturasPorGenerar.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Solicitudes Facturas por Generar":
                    if (!EstaAbierta("frmRpt_SolicitudFacturasPorGenerar"))
                    {
                        frmRpt_SolicitudFacturasPorGenerar = new frmRpt_SolicitudFacturasPorGenerar();
                        frmRpt_SolicitudFacturasPorGenerar.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "De Antigüedad":
                    if (!EstaAbierta("frmRpt_BalanceAntiguedad"))
                    {
                        frmRpt_BalanceAntiguedad = new frmRpt_BalanceAntiguedad();
                        frmRpt_BalanceAntiguedad.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Validacion Créditos y Aplicaciones":
                    if (!EstaAbierta("frmRpt_ValidacionCreditosAplicaciones"))
                    {
                        frmRpt_ValidacionCreditosAplicaciones = new frmRpt_ValidacionCreditosAplicaciones();
                        frmRpt_ValidacionCreditosAplicaciones.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Balance de Antigüedad Anticipos por Aplicar":
                    if (!EstaAbierta("frmRpt_BalanceAntiguedadClientes"))
                    {
                        frmRpt_BalanceAntiguedadClientes = new frmRpt_BalanceAntiguedadClientes();
                        frmRpt_BalanceAntiguedadClientes.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Balance Antigüedad More":
                    if (!EstaAbierta("frmRpt_BalanceAntiguedadMore"))
                    {
                        frmRpt_BalanceAntiguedadMore = new frmRpt_BalanceAntiguedadMore();
                        frmRpt_BalanceAntiguedadMore.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Sumario de Facturación Definitiva":
                    if (!EstaAbierta("frmRpt_SumarioFacturacionDefinitiva"))
                    {
                        frmRpt_SumarioFacturacionDefinitiva = new frmRpt_SumarioFacturacionDefinitiva();
                        frmRpt_SumarioFacturacionDefinitiva.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Integracion TEP Empleado Gasto":
                    if (!EstaAbierta("frmRpt_IntegracionTEPEmpleado"))
                    {
                        frmRpt_IntegracionTEPEmpleado = new frmRpt_IntegracionTEPEmpleado();
                        frmRpt_IntegracionTEPEmpleado.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Traslado de Tiempos":
                    if (!EstaAbierta("frmRpt_TrasladoTiempos"))
                    {
                        frmRpt_TrasladoTiempos = new frmRpt_TrasladoTiempos();
                        frmRpt_TrasladoTiempos.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Estado de Cuenta":
                    if (!EstaAbierta("frmRpt_EstadoCuenta"))
                    {
                        frmRpt_EstadoCuenta = new frmRpt_EstadoCuenta();
                        frmRpt_EstadoCuenta.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Historial de Cargos Acumulados":
                    if (!EstaAbierta("frmRpt_HistorialCargosAcumulados"))
                    {
                        frmRpt_HistorialCargosAcumulados = new frmRpt_HistorialCargosAcumulados();
                        frmRpt_HistorialCargosAcumulados.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Reporte Consulta de Clientes":
                    if (!EstaAbierta("frmRpt_ConsultaClientes"))
                    {
                        frmRpt_ConsultaClientes = new frmRpt_ConsultaClientes();
                        frmRpt_ConsultaClientes.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Reporte Consulta de Facturas":
                    if (!EstaAbierta("frmRpt_ConsultaFactura"))
                    {
                        frmRpt_ConsultaFactura = new frmRpt_ConsultaFactura();
                        frmRpt_ConsultaFactura.impresion = false;
                        frmRpt_ConsultaFactura.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Poliza Ventas":
                    if (!EstaAbierta("frmRpt_PolizaVentas"))
                    {
                        frmRpt_PolizaVentas = new frmRpt_PolizaVentas();
                        frmRpt_PolizaVentas.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Tiempo Cargado":
                    if (!EstaAbierta("frmRpt_EstadisticaTiempoCargado"))
                    {
                        frmRpt_EstadisticaTiempoCargado = new frmRpt_EstadisticaTiempoCargado();
                        frmRpt_EstadisticaTiempoCargado.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Tiempo Cargado por Destino":
                    if (!EstaAbierta("frmRpt_EstadisticaTiempoCargadoPorDestino"))
                    {
                        frmRpt_EstadisticaTiempoCargadoPorDestino = new frmRpt_EstadisticaTiempoCargadoPorDestino();
                        frmRpt_EstadisticaTiempoCargadoPorDestino.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Tiempo No Cargado":
                    if (!EstaAbierta("frmRpt_EstadisticaTiempoNoCargado"))
                    {
                        frmRpt_EstadisticaTiempoNoCargado = new frmRpt_EstadisticaTiempoNoCargado();
                        frmRpt_EstadisticaTiempoNoCargado.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Tiempo Cargado Por Periodo":
                    if (!EstaAbierta("frmRpt_EstadisticaTiempoCargadoPorPeriodo"))
                    {
                        frmRpt_EstadisticaTiempoCargadoPorPeriodo = new frmRpt_EstadisticaTiempoCargadoPorPeriodo();
                        frmRpt_EstadisticaTiempoCargadoPorPeriodo.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case"Clientes Sin Movimiento":
                    if (!EstaAbierta("frmRpt_ClientesSinMovimiento"))
                    {
                        frmRpt_ClientesSinMovimiento = new frmRpt_ClientesSinMovimiento();
                        frmRpt_ClientesSinMovimiento.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Anulación de Solicitud de Factura":
                    if (!EstaAbierta("frmAnulacionSolicitud"))
                    {
                        frmAnulacionSolicitud = new frmAnulacionSolicitud();
                        frmAnulacionSolicitud.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Anulación de Documento":
                    if (!EstaAbierta("frmAnulacionDocumento"))
                    {
                        frmAnulacionDocumento = new frmAnulacionDocumento();
                        frmAnulacionDocumento.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Traslado de Tiempo":
                    if (!EstaAbierta("frmTrasladoTiempo"))
                    {
                        frmTrasladoTiempo = new frmTrasladoTiempo();
                        frmTrasladoTiempo.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Modificación de Porcentajes":
                    if (!EstaAbierta("frmDistribucionFactura"))
                    {
                        frmDistribucionFactura = new frmDistribucionFactura();
                        frmDistribucionFactura.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Impresion de Facturas":
                    if (!EstaAbierta("frmRpt_ConsultaFactura"))
                    {
                        /*frmRpt_ConsultaFactura = new frmRpt_ConsultaFactura();
                        frmRpt_ConsultaFactura.impresion = true;
                        frmRpt_ConsultaFactura.Show();*/
                        frmImpresionFactura = new Forms.frmImpresionFactura();
                        frmImpresionFactura.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Bitacora de Cobros":
                    if (!EstaAbierta("frmBitacoraCobro"))
                    {
                        frmBitacoraCobro frmBitacoraCobro = new frmBitacoraCobro();
                        frmBitacoraCobro.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Revenues Acumulado":

                    if (!EstaAbierta("frmRpt_RevenueAcumulado"))
                    {
                        frmRpt_RevenueAcumulado = new Forms.frmRpt_RevenueAcumulado();
                        frmRpt_RevenueAcumulado.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Lista Cumpleaños":
                    if (!EstaAbierta("frmRpt_Cumpleanios"))
                    {
                        frmRpt_Cumpleanios = new Forms.frmRpt_Cumpleanios();
                        frmRpt_Cumpleanios.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Cuadre TEP":
                    if (!EstaAbierta("frmRpt_CuadreTEP"))
                    {
                        frmRpt_CuadreTEP = new Forms.frmRpt_CuadreTEP();
                        frmRpt_CuadreTEP.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Pendientes de Entregar":
                    if (!EstaAbierta("frmRpt_ReportesPendienteEntregar"))
                    {
                        frmRpt_ReportesPendienteEntregar = new Forms.frmRpt_ReportesPendienteEntregar();
                        frmRpt_ReportesPendienteEntregar.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Tiempo Cargado Acumulado":
                    if (!EstaAbierta("frmRpt_ReportesPendienteEntregar"))
                    {
                        frmRpt_EstadisticaTiempoCargado = new Forms.frmRpt_EstadisticaTiempoCargado();
                        frmRpt_EstadisticaTiempoCargado.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;

                case "Rpt Bitacora de Cobros":
                    if (!EstaAbierta("frmRpt_GestionCobro"))
                    {
                        frmRpt_GestionCobro = new Forms.frmRpt_GestionCobro();
                        frmRpt_GestionCobro.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Acceso al Sistema":
                     if (!EstaAbierta("frmLogin"))
                    {
                        frmLogin =new  frmLogin();
                        if (frmLogin.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            ConstruirMenu();
                        }
                    }
                    break;

                case "Cambio de Cliente y Job - Factura Preliminar":
                    if (!EstaAbierta("frmCambioClienteJob"))
                    {
                        frmCambioClienteJob = new frmCambioClienteJob();
                        frmCambioClienteJob.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Encripcion Claves":
                    if (!EstaAbierta("frmCambioClienteJob"))
                    {
                        frmEncriptaClaves frm = new  frmEncriptaClaves();
                        frm.ShowDialog();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Bitacora por Factura":
                    if (!EstaAbierta("frmRpt_ConsultaGestionCobro"))
                    {
                        frmRpt_ConsultaGestionCobro frm = new frmRpt_ConsultaGestionCobro();
                        frm.ShowDialog();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
                case "Listado Honorarios Cargados en periodo TE":
                    frmRpt_ListadoHonorariosCargadosN = new frmRpt_ListadoHonorariosCargadosN();
                    frmRpt_ListadoHonorariosCargadosN.Show();
                    ultraPictureBox1.Visible = true;
                    break;
                case "Libro de Ventas El Salvador(CONSUMIDORES)":
                    frmRpt_LibroVentasConsES = new frmRpt_LibroVentasConsES();
                    frmRpt_LibroVentasConsES.Show();
                    ultraPictureBox1.Visible = true;
                    break;
                case "Libro de Ventas Salvador(Contribuyentes)":
                    frmRpt_LibroVentasContriES = new frmRpt_LibroVentasContriES();
                    frmRpt_LibroVentasContriES.Show();
                    ultraPictureBox1.Visible = true;
                    break;

                case "Reporte Rentabilidad":
                    if (!EstaAbierta("frmRpt_ReportesPendienteEntregar"))
                    {
                        frmRpt_ReporteRentabilidad = new frmRpt_ReporteRentabilidad();
                        frmRpt_ReporteRentabilidad.Show();
                        ultraPictureBox1.Visible = true;
                    }
                    break;
            }

            
            //ultraPictureBox1.Visible = true;
        }

        private void ultraTabbedMdiManager1_TabClosed(object sender, Infragistics.Win.UltraWinTabbedMdi.MdiTabEventArgs e)
        {
            if (ultraTabbedMdiManager1.ActiveTab == null)
                ultraPictureBox1.Visible = true;
        }

        private void ultraTabbedMdiManager1_TabActivated(object sender, Infragistics.Win.UltraWinTabbedMdi.MdiTabEventArgs e)
        {
            e.Tab.Form.Activate();
        }
    }
}
