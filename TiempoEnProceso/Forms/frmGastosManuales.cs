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
    public partial class frmGastosManuales : Form
    {
        public tbl_distribucion_gastos Item { get; set; }
        public Helper.Acciones AccionActual { get; set; }


        List<tbl_distribuidos> lstD = new List<tbl_distribuidos>();
        List<tbl_distribuidos> lstE = new List<tbl_distribuidos>();
        List<ClienteEN> lstCl = new List<ClienteEN>();

        ValueList clienteVL;
        ValueList servicioVL;
        ValueList jobVL;
        ValueList conceptoVL;


        private TEPEntities db;

        public frmGastosManuales()
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

            if (!uvValidador.Validate("reqVal", false, true).IsValid)
                return false;

            if (ucEntidad.Value!=null && ucEntidad.SelectedRow.ListObject == null)
            {
                MessageBox.Show("Selección de Entidad Invalido", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (ugData.Rows.Count <= 0)
            {
                MessageBox.Show("Detalle Invalido", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void LimpiaEspacios()
        {
            if (uteReferencia.Value != null)
                uteReferencia.Value = uteReferencia.Value.ToString().Trim();
        }

        public void CargarItem(int _id_transaccion)
        {
            tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;
            Item = db.tbl_distribucion_gastos.FirstOrDefault(d => d.id_transaccion == _id_transaccion);
            if (Item != null)
            {
                lstD = db.tbl_distribuidos.Where(d => d.id_transaccion == _id_transaccion).ToList<tbl_distribuidos>();

                CargaCombos();
                AsignaCampos();
                ubDel.Visible = true;
            }
            else
            {
                Item = new tbl_distribucion_gastos();
                ubDel.Visible = false;
            }
        }

        private void AsignaCampos()
        {
            uteDescripcion.Value = Item.descripcion;
            uteReferencia.Value = Item.Documento_referencia;
            uccFechaNac.Value = Item.fecha;
            uneGastos.Value = Item.valor_total;
            ucEntidad.Value = Item.id_entidad;
            ugData.DataSource = lstD;
        }

        public void CargaCombos()
        {
            clienteVL = new ValueList();
            jobVL = new ValueList();
            conceptoVL = new ValueList();

            lstCl = (new ClientesBL(ref db)).ListarTodo(Helper.Oficina);
            clienteENBindingSource.DataSource = lstCl;
            tblgastosadministrativosBindingSource.DataSource = (new GastosAdmBL(ref db)).Listar();
            tblentidadlegalBindingSource.DataSource = (new EntidadLegalBL()).Listar(true);

            foreach (ClienteEN _cliente in (List<ClienteEN>)clienteENBindingSource.DataSource)
                clienteVL.ValueListItems.Add(new ValueListItem(_cliente.id_cliente, _cliente.razon_social));

            //foreach (OficinaEN _oficina in (List<OficinaEN>)oficinaENBindingSource.DataSource)
            //    oficinaVL.ValueListItems.Add(new ValueListItem(_oficina.id_oficina, string.Format("{0}-{1}", _oficina.id_oficina, _oficina.Nombre)));

            foreach (tbl_gastos_administrativos _concepto in (List<tbl_gastos_administrativos>)tblgastosadministrativosBindingSource.DataSource)
                conceptoVL.ValueListItems.Add(new ValueListItem(_concepto.id_gasto, string.Format("{0}-{1}", _concepto.id_gasto.Trim(), _concepto.Descripcion)));
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
                return false;
            }

            return true;
        }

        private void ConstruyeItem()
        {
            bool bExiste = false;

            tbl_oficina _tb = Helper.OficinaActiva as tbl_oficina;
            decimal dIDTran = 1;
            if (db.tbl_distribucion_gastos.Count() > 1)
                dIDTran = db.tbl_distribucion_gastos.Max(d => d.id_transaccion) + 1;

            if (!bExiste)
            {
                if (AccionActual == Helper.Acciones.Agregar)
                {
                    Item = new tbl_distribucion_gastos();
                    Item.id_transaccion = dIDTran;
                    bExiste = true;
                }

                Item.descripcion = uteDescripcion.Value.ToString();
                Item.Documento_referencia = uteReferencia.Value.ToString();
                Item.forma_distribucion = "M";
                Item.valor_total = Convert.ToDecimal(ugData.Rows.SummaryValues["Sumvalor"].Value);
                Item.fecha = Convert.ToDateTime(uccFechaNac.Value);
                Item.periodo_tep_proceso = (Helper.OficinaActiva as tbl_oficina).periodo_proceso;
                Item.id_oficina = ucEntidad.Value.ToString();
                Item.id_oficina = Helper.Oficina;
                Item.id_entidad = ucEntidad.Value.ToString();

                if (bExiste)
                    db.tbl_distribucion_gastos.Add(Item);
            }


            decimal iLinea = 1;
            if (db.tbl_distribuidos.Count()>0)
                iLinea = db.tbl_distribuidos.Max(d => d.id_linea) + 1;

            foreach (tbl_distribuidos _det in (List<tbl_distribuidos>)ugData.DataSource)
            {
                if (_det.id_transaccion == 0)
                {
                    _det.id_transaccion = Item.id_transaccion;
                    _det.id_linea = iLinea++;
                    db.tbl_distribuidos.Add(_det);
                }
            }

            foreach (tbl_distribuidos _del in lstE)
                if (_del.id_transaccion != 0)
                    db.tbl_distribuidos.Remove(_del);

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
            ucCliente.Value = null;
            ucProducto.Value = null;
            ucJob.Value = null;
            uneGastos.Value = 0;
            ucConcepto.Value = null;

        }

        private void NuevoItemHeader()
        {
            uteDescripcion.Value = null;
            uccFechaNac.Value = DateTime.Now.Date;
            uteReferencia.Value = null;
            lstD.Clear();
            ugData.DataBind();

            lstD = new List<tbl_distribuidos>();
            ugData.DataSource = lstD;
            ugData.DataBind();

            uteReferencia.Focus();
        }

        private void SetEnableControls(bool Enable)
        {
            Helper.GetControls<UltraTextEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);

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

                utePeriodo.Value = _oficina.periodo_proceso;

                ugData.DataSource = lstD;

                NuevoItem();
            }

            uteReferencia.Focus();

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
                ucCliente.Focus();
        }

        private void ucPeriodo_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void uteDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uccFechaNac.Focus();
        }

        private void uckFacturar_CheckedChanged(object sender, EventArgs e)
        {

        }





        private void uneNotas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ubNuevo.Focus();
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

            if (ucCliente.Value != null &&
                ucCliente.SelectedRow == null)
            {
                MessageBox.Show("Selección de Cliente Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ucEntidadCliente.Value != null &&
                ucEntidadCliente.SelectedRow == null)
            {
                MessageBox.Show("Selección de Entidad Cliente Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ucProducto.Value != null &&
                ucProducto.SelectedRow == null)
            {
                MessageBox.Show("Selección de Producto Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ucJob.Value != null &&
                ucJob.SelectedRow == null)
            {
                MessageBox.Show("Selección de Job Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (uneGastos.Value != null &&
                Convert.ToDecimal(uneGastos.Value) == 0)
            {
                MessageBox.Show("Valor Gastos Invalido", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tbl_empleados empleado = db.tbl_empleados.FirstOrDefault(d => d.id_empleado == Helper.usuario);
            tbl_distribuidos _dist = new tbl_distribuidos();
            _dist.valor = Convert.ToDecimal(uneGastos.Value);
            _dist.id_gasto = ucConcepto.Value.ToString();
            _dist.id_pais = Helper.Pais;
            _dist.id_cliente = ucCliente.Value.ToString();
            _dist.id_servicio = ucProducto.Value.ToString();
            _dist.id_job = ucJob.Value.ToString();
            _dist.id_oficina = Helper.Oficina;
            _dist.id_tbl_entes_clientes = Convert.ToDecimal(ucEntidadCliente.Value);

            lstD.Add(_dist);
            ugData.DataBind();

            NuevoItem();

            ucCliente.Focus();

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
            servicioENBindingSource.Clear();
            if (ucCliente.Value != null &&
                ucCliente.SelectedRow != null)
            {
                List<ServicioEN> lst = new List<ServicioEN>();

                db.tbl_servicios.ToList().ForEach(d => lst.Add(new ServicioEN() { id_servicio = d.id_servicio, Nombre_largo = d.Nombre_largo }));

                servicioENBindingSource.DataSource = lst;
                ucProducto.Value = null;

                var cliente = ucCliente.SelectedRow.ListObject as ClienteEN;
                var entes_Clientes = db.tbl_entes_clientes.Where(d => d.id_pais == Helper.Pais && d.id_cliente == cliente.id_cliente).ToList();

                tblentesclientesBindingSource.DataSource = entes_Clientes;
                ucEntidadCliente.Value = null;
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
                List<JobsExtEN> lst = new List<JobsExtEN>();
                string _producto = ucProducto.Value.ToString();
                string _cliente = ucCliente.Value.ToString();
                IQueryable query = from a in db.tbl_trabajos
                                   join b in db.tbl_servicios on a.id_servicio equals b.id_servicio
                                   where a.id_servicio == _producto &&
                                         a.estado == 0 &&
                                         a.id_cliente == _cliente &&
                                         a.id_oficina == Helper.Oficina
                                   select a;
                query.Cast<tbl_trabajos>().ToList().ForEach(d => lst.Add(new JobsExtEN() { id_cliente = d.id_cliente, descripcion = d.descripcion, id_job = d.id_job, id_servicio = d.id_servicio, id_propuesta = d.id_propuesta }));

                jobsENBindingSource.DataSource = lst;
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
            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_gasto"].Value.ToString().Trim(), e.Row.Cells["Descripcion"].Value.ToString().Trim());
        }



        private void ucOficina_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ugData_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            tbl_oficina _ofi = Helper.OficinaActiva as tbl_oficina;
            switch (e.Cell.Column.Key.ToLower())
            {
                case "id_cliente":
                    servicioVL = new ValueList();
                    foreach (ServicioEN _servicio in (new ServicioBL(ref db)).ListarTodos(e.NewValue.ToString().Trim(), Constantes.S_TODOS, Constantes.S_TODOS, Helper.Oficina))
                        servicioVL.ValueListItems.Add(new ValueListItem(_servicio.id_servicio, string.Format("{0}-{1}", _servicio.id_servicio.Trim(), _servicio.Nombre_largo.Trim())));

                    e.Cell.ValueList = servicioVL;
                    break;
                case "id_servicio":
                    jobVL = new ValueList();
                    foreach (JobsEN _job in (new JobsBL(ref db)).ListarTodos(e.Cell.Row.Cells["id_cliente"].Value.ToString().Trim(), Constantes.S_TODOS, Constantes.S_TODOS, e.NewValue.ToString(), _ofi.id_oficina))
                        jobVL.ValueListItems.Add(new ValueListItem(_job.id_job, string.Format("{0}-{1}", _job.id_job.Trim(), _job.descripcion.Trim())));

                    e.Cell.ValueList = jobVL;
                    break;

            }
        }

        private void ugData_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["id_cliente"].ValueList = clienteVL;
            e.Layout.Bands[0].Columns["id_gasto"].ValueList = conceptoVL;

            if (!e.Layout.Bands[0].Summaries.Exists("Sumvalor"))
            {
                UltraGridColumn columnToSummarize = e.Layout.Bands[0].Columns["valor"];

                SummarySettings summary = e.Layout.Bands[0].Summaries.Add("Sumvalor", SummaryType.Sum, columnToSummarize);
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

            tbl_oficina _ofi = Helper.OficinaActiva as tbl_oficina;

            jobVL = new ValueList();
            foreach (JobsEN _job in (new JobsBL(ref db)).ListarTodos(e.Row.Cells["id_cliente"].Value.ToString().Trim(), Constantes.S_TODOS, Constantes.S_TODOS, Constantes.S_TODOS, _ofi.id_oficina))
                jobVL.ValueListItems.Add(new ValueListItem(_job.id_job, string.Format("{0}-{1}", _job.id_job.Trim(), _job.descripcion.Trim())));

            e.Row.Cells["id_job"].ValueList = jobVL;
        }

        private void ugDataNo_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["id_concepto"].ValueList = conceptoVL;
        }

        private void ultraPanel2_PaintClient(object sender, PaintEventArgs e)
        {

        }

        private void uccFechaNac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteDescripcion.Focus();
        }

        private void ubBuscar_Click(object sender, EventArgs e)
        {
            using (frmBusquedaGastosManuales frm = new frmBusquedaGastosManuales())
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CargarItem(frm.ID_Trx);
                    AccionActual = Helper.Acciones.Editar;
                }
            }
        }

        private void ucCliente_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucCliente.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
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

        private void ubDel_Click(object sender, EventArgs e)
        {
            Helper.ShowError("Eliminar", "Imposible eliminar Gastos Manuales.\nDebe ingresar Gasto Negativo para Reversar Operación", null, MessageBoxButtons.OK, "Eliminar Gasto");
        }

        private void ugData_AfterRowActivate(object sender, EventArgs e)
        {
            if (ugData.ActiveRow != null &&
                ugData.ActiveRow.Index >= 0)
            {
                tbl_distribuidos _tbl = ugData.ActiveRow.ListObject as tbl_distribuidos;
                ucCliente.Value = _tbl.id_cliente;
                ucProducto.Value = _tbl.id_servicio;
                ucJob.Value = _tbl.id_job;
                ucConcepto.Value = _tbl.id_gasto;
                uneGastos.Value = _tbl.valor;
                ucEntidadCliente.Value = _tbl.id_tbl_entes_clientes;
            }
        }

        private void ubUpdate_Click(object sender, EventArgs e)
        {
            if (ugData.ActiveRow != null)
            {

                ugData.ActiveRow.Cells["valor"].Value = Convert.ToDecimal(uneGastos.Value);
                NuevoItem();
            }
        }

        private void ugData_CellDataError(object sender, CellDataErrorEventArgs e)
        {

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

        private void ubEliminar_Click(object sender, EventArgs e)
        {
            if (ugData.ActiveRow != null)
            {
                if (MessageBox.Show("¿Seguro desea eliminar el presente registro?", Helper.NombreAplicacion, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    //lstE.Add(ugData.ActiveRow.ListObject as tbl_distribuidos);
                    tbl_distribuidos _det = ugData.ActiveRow.ListObject as tbl_distribuidos;
                    if (_det.id_linea != 0)
                    {
                        db.tbl_distribuidos.Remove(_det);
                        Item.valor_total = Item.valor_total.Value - _det.valor.Value;
                        db.SaveChanges();

                        uneGastos.Value = Item.valor_total;
                    }
                    lstD.Remove(ugData.ActiveRow.ListObject as tbl_distribuidos);

                    ugData.DataBind();

                    NuevoItem();
                }
            }
        }

        private void ucConcepto_KeyUp(object sender, KeyEventArgs e)
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
                int iSelLoc = ucConcepto.Textbox.SelectionStart;
                if (!ucConcepto.IsDroppedDown)
                {
                    if (ucConcepto.Text.Length > 0)
                    {

                        ucConcepto.ToggleDropdown();
                        ucConcepto.Textbox.SelectionLength = 0;
                        ucConcepto.Textbox.SelectionStart = iSelLoc;
                    }
                }
                if (ucConcepto.Text.Trim() != string.Empty)
                {
                    ucConcepto.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    ucConcepto.DisplayLayout.Bands[0].ColumnFilters["desc"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, "*" + ucConcepto.Text + "*");
                }
            }
        }

        private void ucConcepto_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucConcepto.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ucProducto_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucProducto.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ucJob_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucJob.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ubClean_Click(object sender, EventArgs e)
        {
            NuevoItem();

            ucCliente.Focus();
        }

        private void ultraCombo1_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}", e.Row.Cells["nombre"].Value.ToString().Trim());
        }

        private void ucEntidadCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucEntidadCliente, true, true, true, true);
        }

        private void ucEntidad_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;
                e.Row.Cells["desc"].Value = string.Format("{0}", e.Row.Cells["Razon_social"].Value.ToString().Trim());
        }

        private void ucEntidad_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }
    }
}

