using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using TiempoEnProcesoDL;
using TiempoEnProcesoHelper;
using TiempoEnProcesoBL;
using Infragistics.Win.UltraWinGrid;
using TiempoEnProcesoEN;

namespace TiempoEnProceso.Forms
{
    public partial class frmTrasladoTiempo : Form
    {
        public tbl_traslados Item { get; set; }
        public Helper.Acciones AccionActual { get; set; }

        private TEPEntities db;

        public frmTrasladoTiempo()
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
        private void MuestraJobDesde()
        {
            jobsENBindingSource.Clear();
            if (ucProductoDesde.Value != null &&
                ucProductoDesde.SelectedRow != null &&
                ucClienteDesde.Value != null &&
                ucClienteDesde.SelectedRow != null)
            {
                jobsENBindingSource.DataSource = (new JobsBL(ref db)).ListarTodosOficinaExt(ucClienteDesde.Value.ToString(), Constantes.S_TODOS, Constantes.S_TODOS, ucProductoDesde.Value.ToString(), true, Helper.Oficina);
                ucJobDesde.Value = null;
            }
        }

        private void MuestraJobA ()
        {
            jobsENBindingSource1.Clear();
            if (ucProductoA.Value != null &&
                ucProductoA.SelectedRow != null &&
                ucClienteA.Value != null &&
                ucClienteA.SelectedRow != null)
            {
                jobsENBindingSource1.DataSource = (new JobsBL(ref db)).ListarTodosOficinaExt(ucClienteA.Value.ToString(), Constantes.S_TODOS, Constantes.S_TODOS, ucProductoA.Value.ToString(), true, Helper.Oficina);
                ucJobA.Value = null;
            }
        }
        private bool ValidataControles()
        {
            LimpiaEspacios();

            if (!uvValidador.Validate("reqVal", false, true).IsValid)
                return false;


            return true;
        }

        private void LimpiaEspacios()
        {
        }

        public void CargarItem(int _id_transaccion)
        {
            tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;
            Item = db.tbl_traslados.FirstOrDefault(d => d.id_traslado == _id_transaccion);
            if (Item != null)
            {
                CargaCombos();
                AsignaCampos();
            }
            else
                Item = new tbl_traslados();
        }

        private void AsignaCampos()
        {
            
        }

        public void CargaCombos()
        {
            empleadoENBindingSource.DataSource = (new EmpleadosBL()).ListarTodosOficina(Helper.Oficina);
            empleadoENBindingSource1.DataSource = (new EmpleadosBL()).ListarTodosOficina(Helper.Oficina);

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
                lstCliente.Add(new ClienteEN() { id_cliente = item.c.id_cliente, razon_social = item.c.Razon_Social.Trim() + "; Grupo: " + (item?.g?.nombre?.Trim()) + " Industria: " + item?.i?.nombre?.Trim() });

            clienteENBindingSource.DataSource = lstCliente;

            clienteENBindingSource1.DataSource = lstCliente;

            
            var queryS = from s in db.tbl_servicios.OrderBy(d => d.id_servicio)
                        select new ServicioEN()
                        {
                            id_servicio = s.id_servicio,
                            Nombre_largo = s.Nombre_largo
                        };

            servicioENBindingSource.DataSource = queryS.ToList().OrderBy(d=> d.Nombre_largo);
            servicioENBindingSource1.DataSource = queryS.ToList().OrderBy(d => d.Nombre_largo);
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
            tbl_correlativos _correl = db.tbl_correlativos.FirstOrDefault(d => d.tabla == "TBL_TRASLADOS");
            decimal dIDTran = _correl.correlativo.Value + 1;
           
            if (!bExiste)
            {
                Item = new tbl_traslados();
                Item.id_cliente = ucClienteDesde.Value.ToString();
                Item.id_job = ucJobDesde.Value.ToString();
                Item.id_oficina = Helper.Oficina;
                Item.id_empleado = ucEmpleadoDesde.Value.ToString();


                Item.id_cliente_traslado = ucClienteA.Value.ToString();
                Item.id_job_traslado = ucJobA.Value.ToString();
                Item.id_oficina_traslado = Helper.Oficina;
                Item.id_empleado_traslado = ucEmpleadoA.Value.ToString();
                
                Item.honorarios = Convert.ToDecimal(uneHonorarios.Value);
                Item.horas = Convert.ToDecimal(uneHoras.Value);
                Item.gastos = Convert.ToDecimal(uneGastos.Value);
                Item.periodo_tep_proceso = (Helper.OficinaActiva as tbl_oficina).periodo_proceso;
                
                Item.id_traslado = dIDTran;
                db.tbl_traslados.Add(Item);
            }

            _correl.correlativo = dIDTran;

            db.SaveChanges();


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
            ucEmpleadoDesde.Focus();
        }

        private void NuevoItem()
        {
            uneHoras.MinValue = int.MaxValue * -1;
            uneHoras.MaxValue = int.MaxValue;
            uneHoras.Value = 0;
        }

        private void NuevoItemHeader()
        {
            ucClienteA.Value = null;
            ucProductoA.Value = null;
            ucJobA.Value = null;
            uneHonorarios.Value = null;
            ucEmpleadoA.Value = null;
            uneGastos.Value = null;
            uneHoras.Value = null;

            ucClienteDesde.Value = null;
            ucProductoDesde.Value = null;
            ucJobDesde.Value = null;
            ucEmpleadoDesde.Value = null;

            Helper.GetControls<UltraCombo>(ultraGroupBox1).ForEach(d => d.Enabled = true);

            ucEmpleadoDesde.Focus();
        }

        private void SetEnableControls(bool Enable)
        {
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
                NuevoItem();
            }

            ucClienteA.Focus();

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
                    SetEnableControls(true);
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

            NuevoItem();


        }

        

        private void ucOficina_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ugData_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
        }

       

        private void ultraPanel2_PaintClient(object sender, PaintEventArgs e)
        {

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

        
        private void uneTasaCambio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneHoras, true, true, true, true);
        }

        private void uneTotalLocal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneGastos, true, true, true, true);
        }

        private void uneTotalSolicitud_ValueChanged(object sender, EventArgs e)
        {

        }

        private void uneTasaCambio_ValueChanged(object sender, EventArgs e)
        {
            if (uneHoras.Value != null && 
                ucEmpleadoDesde.Value != null && 
                ucEmpleadoDesde.SelectedRow != null)
            {
                decimal dValor = Convert.ToDecimal(uneHoras.Value) * (ucEmpleadoDesde.SelectedRow.ListObject as EmpleadoEN).cuota_facturacion_local;
                uneHonorarios.Value = dValor < 0 ? 0 : dValor;
            }
        }

        private void uneTotalSolicitud_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneHonorarios, true, true, true, true);
        }

        private void ucEmpleadoDesde_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}", e.Row.Cells["nombrecompleto"].Value.ToString().Trim());
        }

        private void ucEmpleadoDesde_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucEmpleadoDesde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucEmpleadoDesde, true, true, true, true);
        }

        private void ucClienteDesde_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}-{1}",e.Row.Cells["id_cliente"].Value.ToString().Trim(), e.Row.Cells["razon_social"].Value.ToString().Trim());
        }

        private void ucClienteDesde_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucClienteDesde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ucClienteDesde.Value != null)
                {
                    string sVal = ucClienteDesde.Value.ToString();
                    ucClienteDesde.Value = null;
                    ucClienteDesde.Value = sVal.PadRight(10);
                }
                
                SelectNextControl(ucClienteDesde, true, true, true, true);
            }
        }

        private void ucClienteDesde_KeyUp(object sender, KeyEventArgs e)
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
                int iSelLoc = ucClienteDesde.Textbox.SelectionStart;
                if (!ucClienteDesde.IsDroppedDown)
                {
                    if (ucClienteDesde.Text.Length > 0)
                    {

                        ucClienteDesde.ToggleDropdown();
                        ucClienteDesde.Textbox.SelectionLength = 0;
                        ucClienteDesde.Textbox.SelectionStart = iSelLoc;
                    }
                }
                if (ucClienteDesde.Text.Trim() != string.Empty)
                {
                    ucClienteDesde.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    ucClienteDesde.DisplayLayout.Bands[0].ColumnFilters["desc"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, "*" + ucClienteDesde.Text + "*");
                }
            }
        }

        private void ucClienteDesde_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucClienteDesde.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ucProductoDesde_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_servicio"].Value.ToString().Trim(), e.Row.Cells["Nombre_largo"].Value.ToString().Trim());
        }

        private void ucProductoDesde_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucProductoDesde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ucProductoDesde.Value != null)
                {
                    string sVal = ucProductoDesde.Value.ToString();
                    ucProductoDesde.Value = null;
                    ucProductoDesde.Value = sVal.PadRight(4, ' ');
                }
                SelectNextControl(ucProductoDesde, true, true, true, true);
            }
        }

        private void ucProductoDesde_KeyUp(object sender, KeyEventArgs e)
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
                int iSelLoc = ucProductoDesde.Textbox.SelectionStart;
                if (!ucProductoDesde.IsDroppedDown)
                {
                    if (ucProductoDesde.Text.Length > 0)
                    {

                        ucProductoDesde.ToggleDropdown();
                        ucProductoDesde.Textbox.SelectionLength = 0;
                        ucProductoDesde.Textbox.SelectionStart = iSelLoc;
                    }
                }
                if (ucProductoDesde.Text.Trim() != string.Empty)
                {
                    ucProductoDesde.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    ucProductoDesde.DisplayLayout.Bands[0].ColumnFilters["desc"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, "*" + ucProductoDesde.Text + "*");
                }
            }
        }

        private void ucProductoDesde_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucProductoDesde.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ucProductoDesde_ValueChanged(object sender, EventArgs e)
        {
            MuestraJobDesde();
        }

        private void ucClienteDesde_ValueChanged(object sender, EventArgs e)
        {
            MuestraJobDesde();
        }

        private void ucJobDesde_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_job"].Value.ToString().Trim(), e.Row.Cells["descripcion"].Value.ToString().Trim());
        }

        private void ucJobDesde_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucJobDesde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ucJobDesde.Value != null)
                {
                    string sVal = ucJobDesde.Value.ToString();
                    ucJobDesde.Value = null;
                    ucJobDesde.Value = sVal.PadRight(10, ' ');
                }
                SelectNextControl(ucJobDesde, true, true, true, true);
            }
        }

        private void ucEmpleadoA_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}", e.Row.Cells["nombrecompleto"].Value.ToString().Trim());
        }

        private void ucEmpleadoA_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucEmpleadoA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucEmpleadoA, true, true, true, true);
        }

        private void ucClienteA_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_cliente"].Value.ToString().Trim(), e.Row.Cells["razon_social"].Value.ToString().Trim());
        }

        private void ucClienteA_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucClienteA.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ucClienteA_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucClienteA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ucClienteA.Value != null)
                {
                    string sVal = ucClienteA.Value.ToString();
                    ucClienteA.Value = null;
                    ucClienteA.Value = sVal.PadRight(10);
                }
                SelectNextControl(ucClienteA, true, true, true, true);
            }
        }

        private void ucClienteA_KeyUp(object sender, KeyEventArgs e)
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
                int iSelLoc = ucClienteA.Textbox.SelectionStart;
                if (!ucClienteA.IsDroppedDown)
                {
                    if (ucClienteA.Text.Length > 0)
                    {

                        ucClienteA.ToggleDropdown();
                        ucClienteA.Textbox.SelectionLength = 0;
                        ucClienteA.Textbox.SelectionStart = iSelLoc;
                    }
                }
                if (ucClienteA.Text.Trim() != string.Empty)
                {
                    ucClienteA.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    ucClienteA.DisplayLayout.Bands[0].ColumnFilters["desc"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, "*" + ucClienteA.Text + "*");
                }
            }
        }

        private void ucClienteA_ValueChanged(object sender, EventArgs e)
        {
            MuestraJobA();
        }

        private void ucProductoA_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucProductoA.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ucProductoA_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_servicio"].Value.ToString().Trim(), e.Row.Cells["Nombre_largo"].Value.ToString().Trim());
        }

        private void ucProductoA_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucProductoA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ucProductoA.Value != null)
                {
                    string sVal = ucProductoA.Value.ToString();
                    ucProductoA.Value = null;
                    ucProductoA.Value = sVal.PadRight(4, ' ');
                }
                SelectNextControl(ucProductoA, true, true, true, true);
            }
        }

        private void ucProductoA_KeyUp(object sender, KeyEventArgs e)
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
                int iSelLoc = ucProductoA.Textbox.SelectionStart;
                if (!ucProductoA.IsDroppedDown)
                {
                    if (ucProductoA.Text.Length > 0)
                    {

                        ucProductoA.ToggleDropdown();
                        ucProductoA.Textbox.SelectionLength = 0;
                        ucProductoA.Textbox.SelectionStart = iSelLoc;
                    }
                }
                if (ucProductoA.Text.Trim() != string.Empty)
                {
                    ucProductoA.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    ucProductoA.DisplayLayout.Bands[0].ColumnFilters["desc"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, "*" + ucProductoA.Text + "*");
                }
            }
        }

        private void ucProductoA_ValueChanged(object sender, EventArgs e)
        {
            MuestraJobA();
        }

        private void ucJobA_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_job"].Value.ToString().Trim(), e.Row.Cells["descripcion"].Value.ToString().Trim());
        }

        private void ucJobA_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucJobA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ucJobA.Value != null)
                {
                    string sVal = ucJobA.Value.ToString();
                    ucJobA.Value = null;
                    ucJobA.Value = sVal.PadRight(10, ' ');
                }
                SelectNextControl(ucJobA, true, true, true, true);
            }
        }

        private void ucEmpleadoA_ValueChanged(object sender, EventArgs e)
        {
            MuestraJobA();
        }

        private void ucJobDesde_ValueChanged(object sender, EventArgs e)
        {
            if (ucJobDesde.Value != null &&
                ucJobDesde.SelectedRow != null)
            {
                string _servicio = ucProductoDesde.Value.ToString();
                string _pais = (Helper.OficinaActiva as tbl_oficina).id_pais;
                string _empleado = ucEmpleadoDesde.Value.ToString();
                string _cliente = ucClienteDesde.Value.ToString();
                string _job = ucJobDesde.Value.ToString();

                var query = from a in db.tbl_trabajos
                            join b in db.tbl_saldo_tep on new { id_pais = a.id_pais, id_cliente = a.id_cliente, id_job = a.id_job, id_oficina = a.id_oficina, id_servicio = a.id_servicio }
                                                   equals new { id_pais = b.id_pais, id_cliente = b.id_cliente, id_job = b.id_job, id_oficina = b.id_oficina, id_servicio = b.id_servicio }
                                into rso
                            from subQ in rso.DefaultIfEmpty()
                            where a.estado == 0 && a.id_servicio == _servicio &&
                                  a.id_pais == _pais && a.id_cliente == _cliente &&
                                  subQ != null && subQ.id_empleado == _empleado &&
                                  a.id_job == _job
                            select new { a, subQ };

                foreach (var item in query.ToList())
                {
                    uneHoras.Value = item.subQ.horas;
                    uneHoras.MaxValue = item.subQ.horas;

                    uneGastos.Value = item.subQ.gastos;
                    uneGastos.MaxValue = item.subQ.gastos;

                    uneHonorarios.Value = item.subQ.honorarios;
                    uneHonorarios.MaxValue = item.subQ.honorarios;
                    break;
                }

                Helper.GetControls<UltraCombo>(ultraGroupBox1).ForEach(d => d.Enabled = false);
            }
        }

        private void ucJobDesde_KeyUp(object sender, KeyEventArgs e)
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
                int iSelLoc = ucJobDesde.Textbox.SelectionStart;
                if (!ucJobDesde.IsDroppedDown)
                {
                    if (ucJobDesde.Text.Length > 0)
                    {

                        ucJobDesde.ToggleDropdown();
                        ucJobDesde.Textbox.SelectionLength = 0;
                        ucJobDesde.Textbox.SelectionStart = iSelLoc;
                    }
                }
                if (ucJobDesde.Text.Trim() != string.Empty)
                {
                    ucJobDesde.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    ucJobDesde.DisplayLayout.Bands[0].ColumnFilters["desc"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, "*" + ucJobDesde.Text + "*");
                }
            }
        }

        private void ucJobA_KeyUp(object sender, KeyEventArgs e)
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
                int iSelLoc = ucJobA.Textbox.SelectionStart;
                if (!ucJobA.IsDroppedDown)
                {
                    if (ucJobA.Text.Length > 0)
                    {

                        ucJobA.ToggleDropdown();
                        ucJobA.Textbox.SelectionLength = 0;
                        ucJobA.Textbox.SelectionStart = iSelLoc;
                    }
                }
                if (ucJobA.Text.Trim() != string.Empty)
                {
                    ucJobA.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    ucJobA.DisplayLayout.Bands[0].ColumnFilters["desc"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, "*" + ucJobA.Text + "*");
                }
            }
        }

        private void ucJobDesde_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucJobDesde.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ucJobA_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucJobA.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ubClean_Click(object sender, EventArgs e)
        {
            Helper.GetControls<UltraCombo>(ultraGroupBox1).ForEach(d => d.Enabled = true);
            Helper.GetControls<UltraCombo>(ultraGroupBox1).ForEach(d => d.Value = null);
        }   
    }
}

