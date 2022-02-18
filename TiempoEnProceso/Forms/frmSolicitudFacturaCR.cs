using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TiempoEnProcesoDL;
using TiempoEnProcesoHelper;
using TiempoEnProcesoBL;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.Misc;
using TiempoEnProcesoEN;
using Infragistics.Win.UltraWinSchedule;

namespace TiempoEnProceso.Forms
{
    public partial class frmSolicitudFacturaCR : Form
    {
        public tbl_solicitud_facturas Item { get; set; }
        public Helper.Acciones AccionActual { get; set; }
        public bool EdicionLimitada { get; set; }

        List<tbl_det_Solicitud> lstD = new List<tbl_det_Solicitud>();
        List<tbl_det_Solicitud> lst2Del = new List<tbl_det_Solicitud>();

        ValueList clienteVL;

        private TEPEntities db;

        public frmSolicitudFacturaCR()
        {
            InitializeComponent();
            db = new TEPEntities(Helper.CadenaConexion);
            
            EdicionLimitada = false;
        }

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Grabar":    // ButtonTool
                    if (Grabar())
                    {
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    break;

                case "Cancelar":    // ButtonTool
                    DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    break;

            }

        }

        #region Metodos
        private bool ValidataControles()
        {
            LimpiaEspacios();

            if (!uvValidador.Validate("reqVal", false, true).IsValid)
                return false;

            if (ugData.Rows.Count <= 0)
            {
                MessageBox.Show("Detalle Invalido", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            decimal Ts = 0, Tl = 0;
            Ts = Convert.ToDecimal(uneTotalLocal.Value);
            Tl = Convert.ToDecimal(ugData.Rows.SummaryValues["SumValor_local"].Value);

            if (Ts != Tl)
            {
                MessageBox.Show("Total monto Local es diferente al Total Local Solicitud", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void LimpiaEspacios()
        {
            if (uteReferencia.Value != null)
                uteReferencia.Value = uteReferencia.Value.ToString().Trim();
        }

        public void CargarItem(decimal _id_transaccion)
        {
            tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;
            Item = db.tbl_solicitud_facturas.FirstOrDefault(d => d.id_solicitud== _id_transaccion);
            if (Item != null)
            {
                lstD = db.tbl_det_Solicitud.Where(d=> d.id_solicitud== _id_transaccion).ToList<tbl_det_Solicitud>();

                CargaCombos();
                AsignaCampos();
            }
            else
                Item = new tbl_solicitud_facturas();
        }

        private void AsignaCampos()
        {
            ucCliente.Value = Item.id_cliente;

            string _srv = (new JobsBL()).ListarClienteJob(Item.id_cliente, Item.id_job, Helper.Oficina) .FirstOrDefault().id_servicio;

            ucProducto.Value = _srv;
            ucJob.Value = Item.id_job;
            ucConcepto.Value = Item.id_entidad;
            ucTipoSolicitud.Value = Item.tipo_entrega;
            uneTotalSolicitud.Value = Item.total_solicitud;
            uneTasaCambio.Value = Item.tasa_cambio;
            uneTasaFiscal.Value = Item.Tasa_cambio_Fiscal;
            uneTotalLocal.Value = Item.total_solicitud_moneda_local;
            uccFecha.Value = Item.fecha;
            uccFechaEmitir.Value = Item.fecha_a_emitir;
            uccFechaNac.Value = Item.fecha_tentativa_cobro;
            ucPeriodo.Value = Item.facturar_en_perido;
            uteMonedaImpresion.Value = Item.codigo_moneda_impresion;
            uckIdioma.Checked = Item.Lenguaje_Impresion_spanish ?? true;
            ucCondVenta.Value = Item.Condicion_Venta;

            ucFacturaEn.Value = Item.Imprime_moneda_Tep;
            uteDescripcion.Value = Item.instrucciones;
            ucActEconomica.Value = Item.Id_Actividad_Economica_CR;
            uckEsExportacion.Checked = Item.es_exportacion??false;
            uneMontoExoneracion.Value = Item.monto_exoneracion??0;
            udtFechaAnula.Value = Item.fecha_documento_referencia;
            uneDoctoAnula.Value = Item.numero_documento_referencia;
            uneTasaImpuesto.Value = Item.tasa_impuesto;

            ugData.DataSource = lstD;
            ugData.DataBind();
        }

        public void CargaCombos()
        {
            clienteENBindingSource.DataSource = (new ClientesBL(ref db)).ListarTodo(Helper.Oficina);
            tblentidadlegalBindingSource.DataSource = (new EntidadLegalBL()).Listar();
            periodoENBindingSource.DataSource = (new PeriodoBL()).ListarSiguiente((Helper.OficinaActiva as tbl_oficina).periodo_proceso);

            var query = from s in db.tbl_servicios.OrderBy(d => d.Nombre_largo)
                        select new ServicioEN()
                        {
                            id_servicio = s.id_servicio,
                            Nombre_largo = s.Nombre_largo
                        };

            servicioENBindingSource.DataSource = query.ToList().OrderBy(d=> d.id_servicio);
            tblactEconomicaBindingSource.DataSource = db.Tbl_Actividad_Economica_CR.ToList();
        }


        private bool Grabar()
        {
            try
            {
                if (!ValidataControles())
                    return false;

                using (var dbTran = db.Database.BeginTransaction())
                {
                    ConstruyeItem();

                    /*if (AccionActual == Helper.Acciones.Agregar)
                        db.tbl_entidad_legal.Add(Item);*/

                    db.SaveChanges();
                    dbTran.Commit();
                }
            }
            catch (Exception ex)
            {
                Helper.ShowError("Save", "Error al guardar", ex);
                db.tbl_solicitud_facturas.Local.Clear();
                return false;

            }

            return true;
        }

        private void ConstruyeItem()
        {
            //bool bExiste = false;
            if (AccionActual == Helper.Acciones.Agregar)
            {
                tbl_oficina _tb = Helper.OficinaActiva as tbl_oficina;
                tbl_correlativos _correl = db.tbl_correlativos.FirstOrDefault(d => d.tabla == "tbl_solicitud_facturas");
                decimal dIDTran = _correl.correlativo.Value + 1;
                _correl.correlativo = dIDTran;
                db.SaveChanges();

                Item = new tbl_solicitud_facturas();
                Item.id_solicitud = dIDTran;
                /*}

                if (!bExiste)
                {*/

                Item.id_cliente = ucCliente.Value.ToString();
                Item.id_job = ucJob.Value.ToString();
                Item.id_entidad = ucConcepto.Value.ToString();
                Item.tipo_entrega = ucTipoSolicitud.Value.ToString();
                Item.total_solicitud = Convert.ToDecimal(uneTotalSolicitud.Value);
                Item.tasa_cambio = Convert.ToDecimal(uneTasaCambio.Value);
                Item.Tasa_cambio_Fiscal = Convert.ToDecimal(uneTasaFiscal.Value);
                Item.total_solicitud_moneda_local = Convert.ToDecimal(uneTotalLocal.Value);
                Item.fecha = Convert.ToDateTime(uccFecha.Value);
                Item.fecha_a_emitir = Convert.ToDateTime(uccFechaEmitir.Value);
                Item.fecha_tentativa_cobro = Convert.ToDateTime(uccFechaNac.Value);
                Item.facturar_en_perido = ucPeriodo.Value.ToString();
                Item.Condicion_Venta = ucCondVenta.Value.ToString();
                Item.tasa_impuesto = Convert.ToInt32(uneTasaImpuesto.Value);

                Item.Imprime_moneda_Tep = Convert.ToInt32(ucFacturaEn.Value);
                Item.elaborado = string.Format("{0} {1}", (Helper.UsuarioActivo as tbl_empleados).Nombres.Trim(), (Helper.UsuarioActivo as tbl_empleados).apellidos);
                Item.estado = 0;
                Item.id_empleado = Helper.usuario;
                Item.instrucciones = uteDescripcion.Value.ToString();
                Item.situacion = "N";
                Item.id_oficina = Helper.Oficina;
                Item.Lenguaje_Impresion_spanish = uckIdioma.Checked;
                Item.es_exportacion = uckEsExportacion.Checked;

                Item.fecha_documento_referencia = null;
                if (udtFechaAnula.Value != null)
                    Item.fecha_documento_referencia = Convert.ToDateTime(udtFechaAnula.Value);

                Item.numero_documento_referencia = null;
                if (uneDoctoAnula.Value != null)
                    Item.numero_documento_referencia = uneDoctoAnula.Value.ToString();

                if (ucActEconomica.Value != null)
                    Item.Id_Actividad_Economica_CR = ucActEconomica.Value.ToString();

                Item.monto_exoneracion = 0;
                if (uneMontoExoneracion.Value != null)
                    Item.monto_exoneracion = Convert.ToDecimal(uneMontoExoneracion.Value);

                Item.codigo_moneda_impresion = string.Empty;
                if (uteMonedaImpresion.Value != null)
                    Item.codigo_moneda_impresion = uteMonedaImpresion.Value.ToString();

                if (AccionActual == Helper.Acciones.Agregar)
                    db.tbl_solicitud_facturas.Add(Item);
            }
            db.SaveChanges();
            //Item = db.tbl_solicitud_facturas.OrderByDescending(d => d.id_solicitud).FirstOrDefault();

            if (lst2Del.Count > 0)
                db.tbl_det_Solicitud.RemoveRange(lst2Del.AsEnumerable());

            decimal iLinea = 1;
            iLinea = db.tbl_det_Solicitud.Max(d => d.line_detalle) + 1;

            foreach (tbl_det_Solicitud _det in (List<tbl_det_Solicitud>)ugData.DataSource)
            {
                if (_det.id_solicitud == 0)
                {
                    _det.id_solicitud = Item.id_solicitud;
                    _det.Impuesto_por = (ucConcepto.SelectedRow.ListObject as tbl_entidad_legal).impuesto;
                    _det.line_detalle = iLinea++;
                    db.tbl_det_Solicitud.Add(_det);
                }
            }
            
            //Item.valor_total = db.tbl_distribuidos.Sum(d => d.valor);
        }

        private void EstableceHabilitacion()
        {
            switch (AccionActual)
            {
                case Helper.Acciones.Agregar:
                    break;
                case Helper.Acciones.Consultar:
                    SetEnableControls(false);
                    break;
                case Helper.Acciones.Editar:
                    if (EdicionLimitada)
                    {
                        SetEnableControls(false);
                    }

                    break;
            }
            uteOficina.Enabled = false;
        }

        private void NuevoItem()
        {

            ucEnteClientes.Value = null;
            uteReferencia.Value = null;
            uteDescDet.Value = null;
            uceDesc.Value = null;
            uneValorImp.Value = 0;
            uneValorSImp.Value = 0;
            uneDescuento.Value = 0;
            uneValLocal.Value = 0;
            uckTipoFactura.Checked = false;
            uteNationalID.Value = null;
            uccFecha.Value = DateTime.Now.Date;
            uccFechaEmitir.Value = DateTime.Now.Date;
            uccFechaNac.Value = DateTime.Now.Date;
            uneImpuestoLocal.Value = 0;
        }

        private void NuevoItemHeader()
        {
            ucCliente.Value = null;
            ucProducto.Value = null;
            ucJob.Value = null;
            uneTotalSolicitud.Value = 0;
            ucConcepto.Value = null;
            ucTipoSolicitud.Value = "P";
            uneTotalLocal.Value = 0;
            uneTasaCambio.Value = 1;
            ucFacturaEn.Value = 1;
            ucPeriodo.Value = (Helper.OficinaActiva as tbl_oficina).periodo_proceso;
            uccFechaNac.Value = DateTime.Now.Date;
            uccFechaEmitir.Value = DateTime.Now.Date;
            uccFecha.Value = DateTime.Now.Date;
            uteDescripcion.Value = null;
            uckIdioma.Checked = true;
            ucCondVenta.Value = "01";
            uckEsExportacion.Checked = false;
            ucActEconomica.Value = null;
            uteMonedaImpresion.Value = "USD";
            uneDoctoAnula.Value = null;
            udtFechaAnula.Value = null;
            uneTasaImpuesto.Value = null;
            lstD.Clear();
            ugData.DataBind();

            ucCliente.Focus();
        }

        private void SetEnableControls(bool Enable)
        {
            Helper.GetControls<UltraTextEditor>(this.ultraPanel2).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraCombo>(this.ultraPanel2).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraCalendarCombo>(this.ultraPanel2).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraNumericEditor>(this.ultraPanel2).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraComboEditor>(this.ultraPanel2).ForEach(p => p.Enabled = Enable);

        }
        #endregion

        private void frmRegion_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - {1}", AccionActual.ToString(), this.Text);
            Helper.SetUltraComboWidth(this);
            uvValidador.NotificationSettings.Caption = Helper.NombreAplicacion;
            EstableceHabilitacion();
            tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;

            CargaCombos();

            if (AccionActual == Helper.Acciones.Agregar)
            {
                uteOficina.Value = string.Format("{0}-{1}", Helper.Oficina, (Helper.OficinaActiva as tbl_oficina).Nombre);

                ugData.DataSource = lstD;
                ucPeriodo.Value = _oficina.periodo_proceso;
                NuevoItem();
                ucTipoSolicitud.Value = "P";
                ucFacturaEn.Value = 1;
                uckIdioma.Checked = true;
            }

            ucCliente.Focus();

        }



        private void ubAgregar_Click(object sender, EventArgs e)
        {
            if (Grabar())
            {
                Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Grabar", "Registro Grabado Satisfactoriamente");
                if (Helper.Continuo && AccionActual == Helper.Acciones.Agregar)
                {
                    NuevoItemHeader();
                    NuevoItem();
                    ucFacturaEn.Value = 1;
                }
                else
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
        }

        private void ubCerrar_Click(object sender, EventArgs e)
        {
            if (Helper.Continuo)
                DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                DialogResult = System.Windows.Forms.DialogResult.Cancel;

            Close();
        }

        private void uteDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteDescripcion, true, true, true, true);
        }

        private void ucPeriodo_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void uteDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteReferencia, true, true, true, true);
        }

        private void uckFacturar_CheckedChanged(object sender, EventArgs e)
        {

        }

        

        

        private void uneNotas_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void ultraPanel1_PaintClient(object sender, PaintEventArgs e)
        {

        }

        private void ubNuevo_Click(object sender, EventArgs e)
        {
            LimpiaEspacios();

            uvValidador.ValidationGroups["required"].Enabled = true;

            if (!uvValidador.Validate("required", false, true).IsValid)
                return;

            if (ucEnteClientes.Value != null &&
                ucEnteClientes.SelectedRow == null)
            {
                MessageBox.Show("Selección de Facturar A Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            if (uneValorSImp.Value != null &&
                Convert.ToDecimal(uneValorSImp.Value) < 0)
            {
                MessageBox.Show("Valor Invalido", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (uneValorImp.Value != null &&
                Convert.ToDecimal(uneValorImp.Value) < 0)
            {
                MessageBox.Show("Valor Invalido", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal dVal = Convert.ToDecimal(ucEnteClientes.Value);

            if (lstD.Count > 0)
            {
                if (!lstD.Any(d => d.linea == dVal))
                {
                    MessageBox.Show("No puede seleccionar dos entes diferentes", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            //tbl_entes_clientes empleado = db.tbl_entes_clientes.FirstOrDefault(d => d.linea == dVal);
            tbl_det_Solicitud _dist = new tbl_det_Solicitud();
            _dist.valor = Convert.ToDecimal(uneValorSImp.Value);
            _dist.Impuesto = Convert.ToDecimal(uneValorImp.Value);
            _dist.Descuento_linea = Convert.ToDecimal(uneDescuento.Value);
            _dist.Total = _dist.valor + _dist.Impuesto - _dist.Descuento_linea;
            _dist.Atencion_a = uteReferencia.Value.ToString();
            _dist.concepto = uteDescDet.Value.ToString();
            _dist.descripcion_comercial = uteDescripcionComercial.Value.ToString();
            _dist.Es_linea_fiscal = uckTipoFactura.Checked;
            _dist.Valor_local = Convert.ToDecimal(uneValLocal.Value);
            _dist.valor_local_impuesto = Convert.ToDecimal(uneImpuestoLocal.Value);
            //_dist.Valor_local = _dist.Total * Convert.ToDecimal(uneTasaCambio.Value);
            _dist.linea = dVal;

            lstD.Add(_dist);
            ugData.DataBind();

            /*if (uneTotalSolicitud.Value != null &&
                Convert.ToDecimal(uneTotalSolicitud.Value) != Convert.ToDecimal(ugData.Rows.SummaryValues["SumTotal"].Value))
            {
                uneTotalSolicitud.Value = ugData.Rows.SummaryValues["SumTotal"].Value;
                if (uneTotalLocal.Value == null ||
                    Convert.ToDecimal(uneTotalLocal.Value) == 0)
                    uneTotalLocal.Value = Convert.ToDecimal(ugData.Rows.SummaryValues["SumTotal"].Value) * Convert.ToDecimal(uneTasaCambio.Value) ;
            }*/

            NuevoItem();

            ucEnteClientes.Focus();

        }

        private void ucCliente_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ucCliente.Value != null)
                {
                    string sVal = ucCliente.Value.ToString();
                    ucCliente.Value = null;
                    ucCliente.Value = sVal.PadRight(10);
                }
                SelectNextControl(ucCliente, true, true, true, true);
            }
        }

        private void ucCliente_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}", e.Row.Cells["razon_social"].Value.ToString().Trim());
        }

        private void ucCliente_ValueChanged(object sender, EventArgs e)
        {
            tblentesclientesBindingSource.Clear();
            clienteVL = new ValueList();
            if (ucCliente.Value != null &&
                ucCliente.SelectedRow != null)
            {
                string _cliente = ucCliente.Value.ToString();
                
                tblentesclientesBindingSource.DataSource = db.tbl_entes_clientes.Where(d => d.id_pais == Helper.Pais && d.id_cliente == _cliente && d.estado == 0).ToList<tbl_entes_clientes>();

                foreach (tbl_entes_clientes _entes in (List<tbl_entes_clientes>)tblentesclientesBindingSource.DataSource)
                    clienteVL.ValueListItems.Add(new ValueListItem(_entes.linea, _entes.nombre.Trim()));

                ugData.DisplayLayout.Bands[0].Columns["linea"].ValueList = clienteVL;
                ucProducto.Value = null;
                ucConcepto.Value = null;
            }
        }

        private void ucProducto_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ucProducto.Value != null)
                {
                    string sVal = ucProducto.Value.ToString();
                    ucProducto.Value = null;
                    ucProducto.Value = sVal.PadRight(4, ' ');
                }
                SelectNextControl(ucProducto, true, true, true, true);
            }
        }

        private void ucProducto_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_servicio"].Value.ToString().Trim(), e.Row.Cells["Nombre_largo"].Value.ToString().Trim());
        }

        private void ucJob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ucJob.Value != null)
                {
                    string sVal = ucJob.Value.ToString();
                    ucJob.Value = null;
                    ucJob.Value = sVal.PadRight(10, ' ');
                }
                SelectNextControl(ucJob, true, true, true, true);
            }
        }

        private void ucJob_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucJob_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_job"].Value.ToString().Trim(), e.Row.Cells["descripcion"].Value.ToString().Trim());
        }

        private void ucProducto_ValueChanged(object sender, EventArgs e)
        {
            jobsENBindingSource.Clear();
            if (ucProducto.Value != null &&
                ucProducto.SelectedRow != null)
            {
                jobsENBindingSource.DataSource = (new JobsBL(ref db)).ListarTodosOficina(ucCliente.Value.ToString(), Constantes.S_TODOS, Constantes.S_TODOS, ucProducto.Value.ToString(), true, Helper.Oficina);
                ucJob.Value = null;
            }
        }

        private void ucConcepto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucConcepto, true, true, true, true);
        }

        private void ucConcepto_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucConcepto_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}", e.Row.Cells["Razon_social"].Value.ToString().Trim());
        }

        

        private void ucOficina_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ugData_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
        }

        private void ugData_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["linea"].ValueList = clienteVL;

            if (!e.Layout.Bands[0].Summaries.Exists("Sumvalor"))
            {
                UltraGridColumn columnToSummarize = e.Layout.Bands[0].Columns["valor"];

                SummarySettings summary = e.Layout.Bands[0].Summaries.Add("Sumvalor", SummaryType.Sum, columnToSummarize);
                summary.DisplayFormat = "{0:N2}";
                summary.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed | SummaryDisplayAreas.GroupByRowsFooter;
                summary.Appearance.TextHAlign = HAlign.Right;
            }

            if (!e.Layout.Bands[0].Summaries.Exists("SumImpuesto"))
            {
                UltraGridColumn columnToSummarize = e.Layout.Bands[0].Columns["Impuesto"];

                SummarySettings summary = e.Layout.Bands[0].Summaries.Add("SumImpuesto", SummaryType.Sum, columnToSummarize);
                summary.DisplayFormat = "{0:N2}";
                summary.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed | SummaryDisplayAreas.GroupByRowsFooter;
                summary.Appearance.TextHAlign = HAlign.Right;
            }

            if (!e.Layout.Bands[0].Summaries.Exists("SumTotal"))
            {
                UltraGridColumn columnToSummarize = e.Layout.Bands[0].Columns["Total"];

                SummarySettings summary = e.Layout.Bands[0].Summaries.Add("SumTotal", SummaryType.Sum, columnToSummarize);
                summary.DisplayFormat = "{0:N2}";
                summary.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed | SummaryDisplayAreas.GroupByRowsFooter;
                summary.Appearance.TextHAlign = HAlign.Right;
            }

            if (!e.Layout.Bands[0].Summaries.Exists("SumValor_local"))
            {
                UltraGridColumn columnToSummarize = e.Layout.Bands[0].Columns["Valor_local"];

                SummarySettings summary = e.Layout.Bands[0].Summaries.Add("SumValor_local", SummaryType.Sum, columnToSummarize);
                summary.DisplayFormat = "{0:N2}";
                summary.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed | SummaryDisplayAreas.GroupByRowsFooter;
                summary.Appearance.TextHAlign = HAlign.Right;
            }

            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
            e.Layout.Override.GroupBySummaryDisplayStyle = GroupBySummaryDisplayStyle.SummaryCells;
            e.Layout.Override.SummaryFooterAppearance.FontData.Bold = DefaultableBoolean.True;
            e.Layout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
        }

        private void ugData_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;
      
        }

        private void ultraPanel2_PaintClient(object sender, PaintEventArgs e)
        {

        }

        private void uccFechaNac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uccFechaNac, true, true, true, true);
        }

        private void ucEnteClientes_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Cells["desc"].Value = string.Format("{0} Direc.: {1} Tel: {2} ", e.Row.Cells["nombre"].Value.ToString().Trim(), string.Format("{0} {1} {2}", e.Row.Cells["direccion1"].Value.ToString().Trim(), e.Row.Cells["direccion2"].Value.ToString().Trim(), e.Row.Cells["direccion3"].Value.ToString().Trim()), e.Row.Cells["atencion_a"].Value.ToString().Trim());
        }

        private void ucEnteClientes_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucFacturaEn_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucPeriodo_ItemNotInList_1(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucEnteClientes_ValueChanged(object sender, EventArgs e)
        {
            if (ucEnteClientes.Value != null &&
                ucEnteClientes.SelectedRow != null)
            {
                tbl_entes_clientes _tbl = ucEnteClientes.SelectedRow.ListObject as tbl_entes_clientes;
                uteReferencia.Value = _tbl.atencion_a;
                uteNationalID.Value = _tbl.nit;
            }
        }

        private void ucTipoSolicitud_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucTipoSolicitud, true, true, true, true);
        }

        private void ucFacturaEn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucFacturaEn, true, true, true, true);
        }

        private void uneTasaCambio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneTasaCambio, true, true, true, true);
        }

        private void uneTotalLocal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneTotalLocal, true, true, true, true);
        }

        private void ucPeriodo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucPeriodo, true, true, true, true);
        }

        private void uccFechaEmitir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uccFechaEmitir, true, true, true, true);
        }

        private void uccFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uccFecha, true, true, true, true);
        }

        private void ucEnteClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucEnteClientes, true, true, true, true);
        }

        private void uteDescDet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteDescDet, true, true, true, true);
        }

        private void uneValorSImp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneValorSImp, true, true, true, true);
        }

        private void uneValorImp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneValorImp, true, true, true, true);
        }

        private void ucCliente_KeyUp(object sender, KeyEventArgs e)
        {
            List<int> IgnoreKeys = new List<int>();
            IgnoreKeys.Add((int)Keys.Left);
            IgnoreKeys.Add((int)Keys.Right);
            IgnoreKeys.Add((int)Keys.Up);
            IgnoreKeys.Add((int)Keys.Down);
            IgnoreKeys.Add((int)Keys.Escape);
            IgnoreKeys.Add((int)Keys.Enter);

            if (!IgnoreKeys.Contains((int)e.KeyCode))
            {
                int iSelLoc = ucCliente.Textbox.SelectionStart;
                if (!ucCliente.IsDroppedDown)
                {
                    if (ucCliente.Text.Length > 0)
                    {

                        ucCliente.ToggleDropdown();
                        ucCliente.Textbox.SelectionLength = 0;
                        ucCliente.Textbox.SelectionStart = iSelLoc;
                    }
                }
                if (ucCliente.Text.Trim() != string.Empty)
                {
                    ucCliente.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    ucCliente.DisplayLayout.Bands[0].ColumnFilters["desc"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, "*" + ucCliente.Text + "*");
                }
            }
        }

        private void ucCliente_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucCliente.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ubEliminaData_Click(object sender, EventArgs e)
        {
            if (ugData.ActiveRow != null)
            {
                if ((ugData.ActiveRow.ListObject as tbl_det_Solicitud).id_solicitud > 0)
                    lst2Del.Add(ugData.ActiveRow.ListObject as tbl_det_Solicitud);

                lstD.Remove(ugData.ActiveRow.ListObject as tbl_det_Solicitud);
                ugData.DataBind();

                /*uneTotalSolicitud.Value = ugData.Rows.SummaryValues["SumTotal"].Value;
                if (uneTotalLocal.Value == null ||
                    Convert.ToDecimal(uneTotalLocal.Value) == 0)
                uneTotalLocal.Value = Convert.ToDecimal(ugData.Rows.SummaryValues["SumTotal"].Value) * Convert.ToDecimal(uneTasaCambio.Value) ;*/
            }
        }

        private void uneTotalSolicitud_ValueChanged(object sender, EventArgs e)
        {
            if (uneTotalSolicitud.Value != null &&
                uneTasaCambio.Value != null)
                uneTotalLocal.Value = Convert.ToDecimal(uneTotalSolicitud.Value) * Convert.ToDecimal(uneTasaCambio.Value);
        }

        private void uneTasaCambio_ValueChanged(object sender, EventArgs e)
        {
            if (uneTotalSolicitud.Value != null &&
                uneTasaCambio.Value != null)
                uneTotalLocal.Value = Convert.ToDecimal(uneTotalSolicitud.Value) * Convert.ToDecimal(uneTasaCambio.Value);
        }

        private void uneValorSImp_ValueChanged(object sender, EventArgs e)
        {
            bool bExonera = false;
            if (ucEnteClientes.SelectedRow != null)
                bExonera = (ucEnteClientes.SelectedRow.ListObject as tbl_entes_clientes).Cliente_Exonerado??false;

            uneValorImp.Value = 0;

            if (uneValorSImp.Value != null &&
                ucConcepto.SelectedRow != null &&
                !bExonera)
            {
                uneValorImp.Value = Convert.ToDecimal(uneValorSImp.Value) * (ucConcepto.SelectedRow.ListObject as tbl_entidad_legal).impuesto / 100;
            }

            CalculaValorLocal();
        }

        private void CalculaValorLocal()
        {
            decimal val = 0, valImp = 0, valDesc = 0;
            if (uneValorSImp.Value != null)
                val = Convert.ToDecimal(uneValorSImp.Value);

            if (uneValorImp.Value != null)
                valImp = Convert.ToDecimal(uneValorImp.Value);

            if (uneDescuento.Value != null)
                valDesc = Convert.ToDecimal(uneDescuento.Value);

            uneValLocal.Value = (val + valImp - valDesc) * Convert.ToDecimal(uneTasaCambio.Value ?? 1);
        }

        private void uneTotalSolicitud_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneTotalSolicitud, true, true, true, true);
        }

        private void ucProducto_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucProducto.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ucProducto_KeyUp(object sender, KeyEventArgs e)
        {
            List<int> IgnoreKeys = new List<int>();
            IgnoreKeys.Add((int)Keys.Left);
            IgnoreKeys.Add((int)Keys.Right);
            IgnoreKeys.Add((int)Keys.Up);
            IgnoreKeys.Add((int)Keys.Down);
            IgnoreKeys.Add((int)Keys.Escape);
            IgnoreKeys.Add((int)Keys.Enter);

            if (!IgnoreKeys.Contains((int)e.KeyCode))
            {
                int iSelLoc = ucProducto.Textbox.SelectionStart;
                if (!ucProducto.IsDroppedDown)
                {
                    if (ucProducto.Text.Length > 0)
                    {

                        ucProducto.ToggleDropdown();
                        ucProducto.Textbox.SelectionLength = 0;
                        ucProducto.Textbox.SelectionStart = iSelLoc;
                    }
                }
                if (ucProducto.Text.Trim() != string.Empty)
                {
                    ucProducto.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    ucProducto.DisplayLayout.Bands[0].ColumnFilters["desc"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, "*" + ucProducto.Text + "*");
                }
            }
        }

        private void ucJob_KeyUp(object sender, KeyEventArgs e)
        {
            List<int> IgnoreKeys = new List<int>();
            IgnoreKeys.Add((int)Keys.Left);
            IgnoreKeys.Add((int)Keys.Right);
            IgnoreKeys.Add((int)Keys.Up);
            IgnoreKeys.Add((int)Keys.Down);
            IgnoreKeys.Add((int)Keys.Escape);
            IgnoreKeys.Add((int)Keys.Enter);

            if (!IgnoreKeys.Contains((int)e.KeyCode))
            {
                int iSelLoc = ucJob.Textbox.SelectionStart;
                if (!ucJob.IsDroppedDown)
                {
                    if (ucJob.Text.Length > 0)
                    {

                        ucJob.ToggleDropdown();
                        ucJob.Textbox.SelectionLength = 0;
                        ucJob.Textbox.SelectionStart = iSelLoc;
                    }
                }
                if (ucJob.Text.Trim() != string.Empty)
                {
                    ucJob.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    ucJob.DisplayLayout.Bands[0].ColumnFilters["desc"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, "*" + ucJob.Text + "*");
                }
            }
        }

        private void ubBuscar_Click(object sender, EventArgs e)
        {
            using (frmSolicitudFacturas frm = new frmSolicitudFacturas())
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    NuevoItemHeader();
                    NuevoItem();

                    ubDel.Visible = true;
                    ubImprimir.Visible = true;
                    AccionActual = Helper.Acciones.Editar;
                    CargarItem(frm.id_solicitud);
                }
            }
        }

        private void ubDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Seguro desea eliminar el presente registro?", Helper.NombreAplicacion, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) != System.Windows.Forms.DialogResult.Yes)
                    return;

                db.tbl_solicitud_facturas.Remove(Item);

                List<tbl_det_Solicitud> lst = db.tbl_det_Solicitud.Where(d => d.id_solicitud == Item.id_solicitud).ToList();
                db.tbl_det_Solicitud.RemoveRange(lst.AsEnumerable());

                //item.Status = Helper.NO;
                db.SaveChanges();

                Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Grabar", "Registro Eliminado Satisfactoriamente");

                NuevoItemHeader();
                NuevoItem();
            }
            catch (Exception)
            {

                throw;
            }       
        }

        private void ubLimpiar_Click(object sender, EventArgs e)
        {
            NuevoItem();

            ucEnteClientes.Focus();

        }

        private void ubImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                decimal _no_factura = Item.id_solicitud;

                List<rpt_solicitud_factura_Result> lst = db.rpt_solicitud_factura(_no_factura).ToList<rpt_solicitud_factura_Result>();

                if (lst.Count == 0)
                {
                    MessageBox.Show("No existe Información para los Parámetros Seleccionados");
                    return ;
                }

                DataSet dsData = Helper.ToDataSet<rpt_solicitud_factura_Result>(lst);
                dsData.Tables[0].TableName = "pwcia";

                frmViewReport frm = new frmViewReport();
                frm._data = dsData;
                frm._reportName = "rpt_solicitud_factura.rdlc";
                frm._parameters.Add("Id_solicitud", _no_factura.ToString());
                frm._showStatus = false;
                frm._exportButton = true;
                frm.Show();
                //Close();
            }
            catch (Exception ex)
            {
                Helper.ShowError("Execute", "Error al Ejecutar", ex);
                return ;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ucCliente_TextChanged(object sender, EventArgs e)
        {
            if (ucProducto.Value != null) ucProducto.Value = null;
            if (ucJob.Value != null) ucJob.Value = null;
        }

        private void uckTipoFactura_CheckedChanged(object sender, EventArgs e)
        {
            /*uckTipoFactura.Text = uckTipoFactura.Checked ? "Factura Fiscal" : "Factura Comercial";
            if (uckTipoFactura.Checked)
            {
                if (uteDescDet.Value != null)
                    uteDescDet.Value = uteDescDet.Value.ToString().Substring(0, 160);
                uteDescDet.MaxLength = 160;
            }
            else
                uteDescDet.MaxLength = int.MaxValue;*/
            
        }

        private void uckTipoFactura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uckTipoFactura, true, true, true, true);
                    
        }

        private void uteMonedaImpresion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteMonedaImpresion, true, true, true, true);
        }

        private void uckIdioma_CheckedChanged(object sender, EventArgs e)
        {
            uckIdioma.Text = "Impresión " + (uckIdioma.Checked ? "Español" : "Inglés");
        }

        private void uckIdioma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uckIdioma, true, true, true, true);
        }

        private void uceDesc_ValueChanged(object sender, EventArgs e)
        {
            uteDescDet.Value = uceDesc.Value;
        }

        private void uceDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uceDesc, true, true, true, true);
        }

        private void uteDescripcionComercial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteDescripcionComercial, true, true, true, true);
        }

        private void uneTasaFiscal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneTasaFiscal, true, true, true, true);
        }

        private void uneValLocal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneValLocal, true, true, true, true);
        }

        private void uneValorImp_ValueChanged(object sender, EventArgs e)
        {
            CalculaValorLocal();
        }

        private void uneDescuento_ValueChanged(object sender, EventArgs e)
        {
            CalculaValorLocal();
        }

        private void ucCliente_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }

        private void ucCondVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucCondVenta, true, true, true, true);
        }

        private void ucActEconomica_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucActEconomica, true, true, true, true);
        }

        private void ucActEconomica_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}", e.Row.Cells["Descripcion_Actividad_Economica_CR"].Value.ToString().Trim());
        }

        private void uckEsExportacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uckEsExportacion, true, true, true, true);
        }

        private void uneImpuestoLocal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneImpuestoLocal, true, true, true, true);
        }

        private void uneDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneDescuento, true, true, true, true);
        }

        private void uneMontoExoneracion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneMontoExoneracion, true, true, true, true);
                ucEnteClientes.Focus();
        }

        private void ultraLabel29_Click(object sender, EventArgs e)
        {

        }

        private void ubAnula_Click(object sender, EventArgs e)
        {
            using(frmDatosAnulacion frm = new frmDatosAnulacion())
            {
                frm.FechaDocto = null;
                if (udtFechaAnula.Value != null)
                    frm.FechaDocto = Convert.ToDateTime(udtFechaAnula.Value);

                frm.NoDocto = null;
                if (uneDoctoAnula.Value != null)
                    frm.NoDocto = uneDoctoAnula.Value.ToString();

                if (frm.ShowDialog()== DialogResult.OK)
                {
                    udtFechaAnula.Value = frm.FechaDocto;
                    uneDoctoAnula.Value = frm.NoDocto;
                }

                ucEnteClientes.Focus();
            }
        }

        private void ucConcepto_ValueChanged(object sender, EventArgs e)
        {
            if (ucConcepto.Value!=null &&
                ucConcepto.SelectedRow != null)
            {
                uneTasaImpuesto.Value = (ucConcepto.SelectedRow.ListObject as tbl_entidad_legal).impuesto;
            }
        }

        private void uneTasaImpuesto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ucEnteClientes.Focus();
        }
    }
}

