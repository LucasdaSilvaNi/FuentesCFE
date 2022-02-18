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

namespace TiempoEnProceso.Forms
{
    public partial class frmCobranzaNC : Form
    {
        public tbl_cuenta_corriente Item { get; set; }
        public Helper.Acciones AccionActual { get; set; }
        private bool esGT = Helper.EsGt;
        public bool EsCobranza { get; set; }

        List<tbl_detalle_cobros_anulaciones> lstD = new List<tbl_detalle_cobros_anulaciones>();
        List<tbl_cuenta_corriente> lstC = new List<tbl_cuenta_corriente>();

        private TEPEntities db;

        public frmCobranzaNC()
        {
            InitializeComponent();
            db = new TEPEntities(Helper.CadenaConexion);
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

            if (!uvValidador.Validate("required", false, true).IsValid)
                return false;

            if (Convert.ToDecimal(uneGastos.Value) <= 0)
            {
                MessageBox.Show("Valor Invalido", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (ugData.Rows.Count <= 0)
            {
                MessageBox.Show("Detalle Invalido", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (Convert.ToDecimal(uneSaldoAplicar.Value) != 0)
            {
                MessageBox.Show("Saldo pendiente por Aplicar", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            decimal dDocto = Convert.ToDecimal(uneNumero.Value);
            string tipoSol = ucTipoSolicitud.Value.ToString() == "C" ? "COBRANZA" : "NOTA/CREDITO";
            if (db.tbl_cuenta_corriente.Any(d => d.id_oficina == Helper.Oficina && d.id_entidad == ucEntidad.Value.ToString() && d.numero_documento == dDocto &&
                                                d.tipo_documento == tipoSol))
            {
                MessageBox.Show("Número de documento ya existe", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void LimpiaEspacios()
        {
            if (uteDescripcion.Value != null)
                uteDescripcion.Value = uteDescripcion.Value.ToString().Trim();
        }

        public void CargarItem()
        {
            /*tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;
            Item = db.tbl_cuenta_corriente.FirstOrDefault(d => d.Id_transaccion== _id_transaccion);
            if (Item != null)
            {
                lstD = db.tbl_gts_automaticos_detalle.Where(d => d.Id_transaccion == _id_transaccion).ToList<tbl_gts_automaticos_detalle>();

                CargaCombos();
                AsignaCampos();
            }
            else
            {
                Item = new Tbl_gts_automaticos();
                lstD = new List<tbl_gts_automaticos_detalle>();
                foreach (tbl_servicios _srv in db.tbl_servicios.OrderBy(d => d.id_servicio).ToList<tbl_servicios>())
                    lstD.Add(new tbl_gts_automaticos_detalle()
                    {
                        estado = 0,
                        id_servicio = _srv.id_servicio
                    });

                AsignaCampos();
            }*/
        }

        private void AsignaCampos()
        {
            ugDataT.DataSource = lstC;
            ugData.DataSource = lstD;
        }

        public void CargaCombos()
        {
            tblentidadlegalBindingSource.DataSource = (new EntidadLegalBL()).Listar();
            CargaClientes();
        }

        private void CargaClientes()
        {
            List<ClienteEN> lstCliente = new List<ClienteEN>();
            var query = from c in db.tbl_clientes
                        from p in db.tbl_oficina
                            .Where(p => p.id_pais == c.id_pais && p.id_oficina == Helper.Oficina)
                        from g in db.tbl_grupos
                            .Where(g => g.id_grupo == c.id_grupo).DefaultIfEmpty()
                        from i in db.tbl_industrias
                            .Where(i => i.id_industria == c.id_industria).DefaultIfEmpty()
                        select new { c, g, i };
            foreach (var item in query.OrderBy(d => d.c.id_cliente))
                lstCliente.Add(new ClienteEN() { id_cliente = item.c.id_cliente, razon_social = item.c.Razon_Social.Trim() + (item.g != null ? "; Grupo: " + item.g.nombre.Trim() : "") + "; Industria: " + item.i?.nombre.Trim() });

            ucCliente.DataSource = lstCliente;
        }

        private bool Grabar()
        {
            try
            {
                ugData.PerformAction(UltraGridAction.CommitRow);

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
                return false;
            }

            return true;
        }

        private void ConstruyeItem()
        {
            bool bExiste = false;

            tbl_oficina _tb = Helper.OficinaActiva as tbl_oficina;
            decimal dIDTran = Convert.ToDecimal(uneNumero.Value);
           
            if (!bExiste)
            {
                Item = new tbl_cuenta_corriente();

                Item.concepto = uteDescripcion.Value.ToString();
                Item.estado = 1;
                Item.fecha = Convert.ToDateTime(udteFecha.Value);
                Item.id_cliente = ucCliente.Value.ToString();
                Item.id_entidad = ucEntidad.Value.ToString();
                Item.id_oficina = _tb.id_oficina;
                Item.numero_documento = Convert.ToDecimal( uneNumero.Value);
                Item.periodo_tep = _tb.periodo_proceso;
                Item.tipo_documento = ucTipoSolicitud.Value.ToString() == "C" ? "COBRANZA" : "NOTA/CREDITO";
                Item.valor_total = Convert.ToDecimal(uneGastos.Value);
                Item.Lenguaje_Impresion_spanish1 = uckIdioma.Checked;
                Item.valor_total_moneda_local = Convert.ToDecimal(uneValLocal.Value ?? 0);

                if (uneDocumentoRef.Value != null)
                    Item.Numero_documento_sustituye = uneDocumentoRef.Value.ToString();

                Item.impuesto_porcentaje = 0;
                Item.impuesto_incluido = "S";
                Item.valor_impuesto = 0;
                Item.saldo = 0;
                Item.saldo_impuesto = 0;
                Item.anticipo_aplicar = 0;
                Item.factura_definitiva = 0;
                Item.id_solicitud = 0;
                Item.id_job = string.Empty;
                Item.tasa_cambio = 0;
                Item.linea = 0;
                Item.factura_preliminar = 0;
                Item.flag_impreso = 0;
                Item.tipo_documento_fiscal = null;
                if (uceTipoDoctoFiscal.Value != null && uceTipoDoctoFiscal.SelectedItem != null)
                    Item.tipo_documento_fiscal = uceTipoDoctoFiscal.Value.ToString();

                db.tbl_cuenta_corriente.Add(Item);
            }
            db.SaveChanges();

            foreach (UltraGridRow _detR in ugData.Rows)
            {
                tbl_detalle_cobros_anulaciones _det = _detR.ListObject as tbl_detalle_cobros_anulaciones;
                _det.id_entidad = Item.id_entidad;
                _det.id_oficina = Item.id_oficina;
                _det.numero_documento = Item.numero_documento;
                _det.tipo_documento = Item.tipo_documento;
                _det.aplicado_impuestos = 0;
                _det.aplicado_anticipos = 0;
                _det.tipo_factura = string.Empty;
                db.tbl_detalle_cobros_anulaciones.Add(_det);
            }

            Item.estado = 1;

            tbl_entidad_legal _ent = db.tbl_entidad_legal.FirstOrDefault(d => d.id_entidad == ucEntidad.Value.ToString() && d.id_oficina == Helper.Oficina);
            if (ucTipoSolicitud.Value.ToString() == "C") 
                _ent.correlativo_cobranzas = (dIDTran + 1).ToString();
            else
                _ent.correlativo_notas = (dIDTran + 1).ToString();

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
                    break;
            }
            uteOficina.Enabled = false;
        }

        private void NuevoItem()
        {
            NuevoItemHeader();

        }

        private void NuevoItemHeader()
        {
            uteDescripcion.Value = null;
            ucEntidad.Value = null;
            ucTipoSolicitud.Value = EsCobranza ? "C" : "P";
            uneNumero.Value = null;
            udteFecha.Value = DateTime.Now.Date > udteFecha.MaxDate ? udteFecha.MinDate : DateTime.Now.Date;
            ucCliente.Value = null;
            uneGastos.Value = 0;
            uneSaldoAplicar.Value = 0;
            uckIdioma.Checked = true;
            uneValLocal.Value = 0;

            uceTipoDoctoFiscal.Value = EsCobranza? "NAB" : "NCRE";
            //ucTipoSolicitud.Enabled = false;
            lstC.Clear();
            ugDataT.DataBind();

            lstD.Clear();
            ugData.DataBind();

            ucTipoSolicitud_ValueChanged(null, null);

            ucEntidad.Focus();
        }

        private void SetEnableControls(bool Enable)
        {
            Helper.GetControls<UltraTextEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);

        }
        #endregion

        private void frmRegion_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - {1}", AccionActual.ToString(), EsCobranza?"Cobranza":"Nota de Crédito");
            Helper.SetUltraComboWidth(this);
            uvValidador.NotificationSettings.Caption = Helper.NombreAplicacion;
            EstableceHabilitacion();
            tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;

            CargaCombos();

            if (AccionActual == Helper.Acciones.Agregar)
            {
                uteOficina.Value = string.Format("{0}-{1}", Helper.Oficina, (Helper.OficinaActiva as tbl_oficina).Nombre);

                utePeriodo.Value= _oficina.periodo_proceso;
                utePeriodoB.Value = (new PeriodoBL()).ListarPorId(_oficina.periodo_proceso);

                udteFecha.MaxDate = new DateTime(Convert.ToInt32(_oficina.periodo_proceso.Substring(3)), Convert.ToInt32(_oficina.periodo_proceso.Substring(0, 2)), 1).AddMonths(7).AddDays(-1);
                udteFecha.MinDate = new DateTime(Convert.ToInt32(_oficina.periodo_proceso.Substring(3)), Convert.ToInt32(_oficina.periodo_proceso.Substring(0, 2)), 1).AddMonths(6);

                ugDataT.DataSource = lstC;
                ugData.DataSource = lstD;

                NuevoItem();
                ucEntidad.Focus();
            }
        }



        private void ubAgregar_Click(object sender, EventArgs e)
        {
            ugData.PerformAction(UltraGridAction.CommitRow);

            if (Grabar())
            {
                Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Grabar", "Registro Grabado Satisfactoriamente");
                if (Helper.Continuo && AccionActual == Helper.Acciones.Agregar)
                {
                    NuevoItem();
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
            {
                ugDataT.Focus();
                if (ugDataT.Rows.Count > 0)
                    ugDataT.Rows[0].Activate();
            }
                
        }

        private void ucPeriodo_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void uneNotas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneGastos, true, true, true, true);
        }

        private void ultraPanel1_PaintClient(object sender, PaintEventArgs e)
        {

        }

        private void ubNuevo_Click(object sender, EventArgs e)
        {
        }

        private void ucCliente_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucCliente_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_cliente"].Value.ToString().Trim(), e.Row.Cells["razon_social"].Value.ToString().Trim());
        }

        private void ucOficina_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ultraPanel2_PaintClient(object sender, PaintEventArgs e)
        {

        }

        private void uccFechaNac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
                uteDescripcion.Focus();
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

        private void ucEntidad_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;
            e.Row.Cells["desc"].Value = string.Format("{0}", e.Row.Cells["Razon_social"].Value.ToString().Trim());
        }

        private void ucTipoSolicitud_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucCliente_ItemNotInList_1(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucEntidad_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void uteOficina_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteOficina, true, true, true, true);
        }

        private void ucTipoSolicitud_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucTipoSolicitud, true, true, true, true);
        }

        private void uneNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneNumero, true, true, true, true);
        }

        private void udteFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(udteFecha, true, true, true, true);
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

        private void ucCliente_ValueChanged(object sender, EventArgs e)
        {
            ActualizaGrid();
        }

        private void ActualizaGrid()
        {
            if (ucCliente.Value != null &&
                ucCliente.SelectedRow != null &&
                ucEntidad.Value!= null &&
                ucEntidad.SelectedRow !=null)
            {
                lstC.Clear();
                ugDataT.DataBind();

                db.tbl_cuenta_corriente.Where(item => item.id_oficina == Helper.Oficina &&
                                  item.id_entidad == ucEntidad.Value.ToString() &&
                                  item.id_cliente == ucCliente.Value.ToString() &&
                                  item.estado== 1 &&
                                  (item.saldo ?? 0) > 0).OrderBy(d=> d.numero_documento).ToList().ForEach(d => lstC.Add(d));

                ugDataT.DataBind();
            }
        }

        private void ugDataT_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["saldo_total"].Value = Convert.ToDecimal(e.Row.Cells["saldo"].Value) + Convert.ToDecimal(e.Row.Cells["saldo_impuesto"].Value);
        }

        private void ubAgregarData_Click(object sender, EventArgs e)
        {

            if (ugDataT.ActiveRow != null)
            {
                tbl_cuenta_corriente _tbl = ugDataT.ActiveRow.ListObject as tbl_cuenta_corriente;

                if (lstD.Any(d => d.numero_documento_aplicado == _tbl.numero_documento &&
                                 d.tipo_documento_aplicado == _tbl.tipo_documento))
                    return;

                decimal saldo = Convert.ToDecimal(uneSaldoAplicar.Value);

                if (saldo == 0) return;

                lstD.Add(new tbl_detalle_cobros_anulaciones()
                {
                    numero_documento_aplicado = _tbl.numero_documento,
                    tipo_documento_aplicado = _tbl.tipo_documento,
                    valor_aplicado = _tbl.saldo + _tbl.saldo_impuesto > saldo ? saldo : _tbl.saldo + _tbl.saldo_impuesto
                });

                ugData.DataBind();

                CalculaSaldoPendiente();
            }

        }

        private void CalculaSaldoPendiente()
        {
            uneSaldoAplicar.Value = 0;
            if (uneGastos.Value != null)
                uneSaldoAplicar.Value = uneGastos.Value;

            uneSaldoAplicar.Value = Convert.ToDecimal(uneSaldoAplicar.Value) - Convert.ToDecimal(ugData.Rows.SummaryValues["Sumsaldo_total"].Value);
        }

        private void ugData_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            if (!e.Layout.Bands[0].Summaries.Exists("Sumsaldo_total"))
            {
                UltraGridColumn columnToSummarize = e.Layout.Bands[0].Columns["valor_aplicado"];

                SummarySettings summary = e.Layout.Bands[0].Summaries.Add("Sumsaldo_total", SummaryType.Sum, columnToSummarize);
                summary.DisplayFormat = "{0:N2}";
                summary.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed | SummaryDisplayAreas.GroupByRowsFooter;
                summary.Appearance.TextHAlign = HAlign.Right;
            }
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
            e.Layout.Override.GroupBySummaryDisplayStyle = GroupBySummaryDisplayStyle.SummaryCells;
            e.Layout.Override.SummaryFooterAppearance.FontData.Bold = DefaultableBoolean.True;
            e.Layout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
        }

        private void uneGastos_ValueChanged(object sender, EventArgs e)
        {
            CalculaSaldoPendiente();
        }

        private void ubEliminaData_Click(object sender, EventArgs e)
        {
            if (ugData.ActiveRow != null)
            {
                lstD.Remove(ugData.ActiveRow.ListObject as tbl_detalle_cobros_anulaciones);
                ugData.DataBind();

                CalculaSaldoPendiente();
            }
        }

        private void ucEntidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucEntidad, true, true, true, true);
        }

        private void ugData_AfterRowUpdate(object sender, RowEventArgs e)
        {
            CalculaSaldoPendiente();
        }

        private void ugData_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            if (e.Cell.Column.Key == "valor_aplicado")
            {
                if (e.NewValue != null)
                {
                    tbl_cuenta_corriente _tbl = ugDataT.ActiveRow.ListObject as tbl_cuenta_corriente;
                    if (Convert.ToDecimal(e.NewValue) > _tbl.saldo + _tbl.saldo_impuesto)
                    {
                        MessageBox.Show("Valor acreditado Invalido", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                    }
                }
            }
        }

        private void ucTipoSolicitud_ValueChanged(object sender, EventArgs e)
        {
            if (ucTipoSolicitud.Value != null &&
                ucTipoSolicitud.SelectedItem != null)
            {
                if (ucEntidad.SelectedRow != null)
                {
                    tbl_entidad_legal _ent = ucEntidad.SelectedRow.ListObject as tbl_entidad_legal;
                    uneNumero.Value = ucTipoSolicitud.Value.ToString() == "C" ? _ent.correlativo_cobranzas : _ent.correlativo_notas;
                }

                uceTipoDoctoFiscal.Enabled = false;
                if (ucTipoSolicitud.Value.ToString().Trim()!= "C")
                    uceTipoDoctoFiscal.Enabled = true;
            }
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

        private void uneDocumentoRef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneDocumentoRef, true, true, true, true);
        }

        private void ugDataT_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            
        }

        private void uceTipoDoctoFiscal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uceTipoDoctoFiscal, true, true, true, true);
        }

        private void ucEntidad_ValueChanged(object sender, EventArgs e)
        {
            if (ucTipoSolicitud.Value != null &&
                ucTipoSolicitud.SelectedItem != null)
            {
                if (ucEntidad.SelectedRow != null)
                {
                    tbl_entidad_legal _ent = ucEntidad.SelectedRow.ListObject as tbl_entidad_legal;
                    uneNumero.Value = ucTipoSolicitud.Value.ToString() == "C" ? _ent.correlativo_cobranzas : _ent.correlativo_notas;
                }
            }
        }
    }
}

