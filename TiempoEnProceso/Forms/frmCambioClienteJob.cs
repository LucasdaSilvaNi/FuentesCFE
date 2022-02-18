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
using System.IO;
using TiempoEnProcesoEN;

namespace TiempoEnProceso.Forms
{
    public partial class frmCambioClienteJob : Form
    {
        private TEPEntities db = new TEPEntities(Helper.CadenaConexion);
        List<decimal> lstFac = new List<decimal>();
        List<tbl_oficina> lstOf = new List<tbl_oficina>();
        tbl_cuenta_corriente item = new tbl_cuenta_corriente();
        public frmCambioClienteJob()
        {
            InitializeComponent();
            db = new TEPEntities(Helper.CadenaConexion);
            db.Database.CommandTimeout = Helper.TimeOut;
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

            if (!uvValidador.Validate("requiredCambio", false, true).IsValid)
                return false;

            if (ucEntidad.Value != null &&
                ucEntidad.SelectedRow == null)
            {
                MessageBox.Show("Selección Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

           
            return true;
        }

        private void LimpiaEspacios()
        {
        }

        public void CargarItem(string _oficina, string _reporte, string _descripcion)
        {
        }

        private void AsignaCampos()
        {
        }

        public void CargaCombos()
        {
            tbloficinaBindingSource.DataSource = (new OficinaBL(ref db)).ListarTodos();
            clienteENBindingSource.DataSource = (new ClientesBL(ref db)).ListarTodo(Helper.Oficina);
            tblentidadlegalBindingSource.DataSource = (new EntidadLegalBL()).Listar();

            List<ServicioEN> lstA = new List<ServicioEN>();
            db.tbl_servicios.AsQueryable().ToList().ForEach(d => lstA.Add(new ServicioEN() { id_servicio = d.id_servicio, Nombre_largo = d.Nombre_largo }));
            servicioENBindingSource.DataSource = lstA;

            ucOficce.Value = Helper.Oficina;
        }


        private bool Grabar()
        {
            

            if (!ValidataControles())
                return false;

            try
            {
                Cursor = Cursors.WaitCursor;

                item.id_cliente = ucCliente.Value.ToString();
                item.id_job = ucJob.Value.ToString();

                db.Entry<tbl_cuenta_corriente>(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                
                //Close();
            }
            catch (Exception ex)
            {
                Helper.ShowError("Execute", "Error al Ejecutar", ex);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            return true;
        }

        
        private void ConstruyeItem()
        {
        }

        private void EstableceHabilitacion()
        {
        }

        private void NuevoItem()
        {
        }

        private void SetEnableControls(bool Enable)
        {

        }
        #endregion

        private void frmRegion_Load(object sender, EventArgs e)
        {
            uvValidador.NotificationSettings.Caption = Helper.NombreAplicacion;
            Helper.SetUltraComboWidth(this);
            EstableceHabilitacion();
            CargaCombos();
        }

        private void ubAgregar_Click(object sender, EventArgs e)
        {
            if (Grabar())
            {
                Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Grabar", "Registro Grabado Satisfactoriamente");
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

        private void ubCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void ultraPanel4_PaintClient(object sender, PaintEventArgs e)
        {

        }

        private void uceEstado_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ultraPanel3_PaintClient(object sender, PaintEventArgs e)
        {

        }

        private void ucEntidad_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucEntidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucEntidad, true, true, true, true);
        }

        private void ucEntidad_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;
            e.Row.Cells["desc"].Value = string.Format("{0}", e.Row.Cells["Razon_social"].Value.ToString().Trim());
        }

        private void upTipo_ValueChanged(object sender, EventArgs e)
        {
        }


        private void ugData_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            if (e.Row.Cells["select"].Value == null ||
                e.Row.Cells["select"].Value == DBNull.Value)
                e.Row.Cells["select"].Value = false;
        }

        private void ucOficce_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;
            string _oficina = e.Row.Cells["id_oficina"].Value.ToString().Trim();
            tbl_oficina _tbl = lstOf.FirstOrDefault(d => d.id_oficina == _oficina);

            if (_tbl != null)
                e.Row.Cells["desc"].Value = string.Format("{0}-{1}", _tbl.id_oficina, _tbl.Nombre.Trim());
        }

        private void ubConsultar_Click(object sender, EventArgs e)
        {
            if (!uvValidador.Validate("required", false, true).IsValid)
                return;

            if (ucEntidad.Value == null)
            {
                MessageBox.Show("Debe seleccionar una Entidad Valida");
                return;
            }

            if (ucEntidad.Value != null &&
                ucEntidad.SelectedRow == null)
            {
                MessageBox.Show("Debe seleccionar una Entidad Valida");
                return;
            }

            using (frmFacturasPreliminares frm = new frmFacturasPreliminares(ref db))
            {
                frm.id_entidad = ucEntidad.Value.ToString();
                frm.id_oficina = ucOficce.Value.ToString();

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    item = frm.factura;
                    ucCliente.Value = item.id_cliente;

                    tbl_trabajos tbl = db.tbl_trabajos.FirstOrDefault(d => d.id_oficina == frm.id_oficina && d.id_cliente == item.id_cliente && d.id_job == item.id_job);
                    ucProducto.Value = tbl.id_servicio;
                    ucJob.Value = item.id_job;

                    uneHoras.Value = item.numero_documento;
                    uneCuota.Value = (item.saldo ?? 0) + (item.saldo_impuesto ?? 0);

                    ucCliente.Focus();
                }
            }
        }

        private void ugData_ClickCellButton(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.Key == "edit")
            {
                decimal no_solicitud = Convert.ToDecimal(e.Cell.Row.Cells["id_solicitud"].Value);
                using (frmSolicitudFactura frm = new frmSolicitudFactura())
                {
                    frm.AccionActual = Helper.Acciones.Editar;
                    frm.EdicionLimitada = true;
                    frm.CargarItem(no_solicitud);
                    frm.ShowDialog();
                }
            }
        }

        private void ucProducto_ValueChanged(object sender, EventArgs e)
        {
            jobsENBindingSource.Clear();
            if (ucProducto.Value != null &&
                ucProducto.SelectedRow != null &&
                ucCliente.Value != null &&
                ucCliente.SelectedRow != null)
            {
                List<JobsEN> lst = new List<JobsEN>();
                string id_servicio = ucProducto.Value.ToString();
                string id_cliente = ucCliente.Value.ToString();
                var query = from a in db.tbl_trabajos
                            join b in db.tbl_servicios on a.id_servicio equals b.id_servicio
                            where b.id_servicio == id_servicio && a.id_cliente == id_cliente && a.estado == 0 && (a.Inactivo_Cargo_Horas ?? false) == false &&
                            a.id_oficina == Helper.Oficina
                            select new JobsEN()
                            {
                                id_job = a.id_job,
                                descripcion = a.descripcion,
                                id_cliente = a.id_cliente,
                                id_servicio = a.id_servicio
                            };

                jobsENBindingSource.DataSource = query.AsQueryable().ToList();
                ucJob.Value = null;
            }
        }



        private void ucCliente_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucCliente.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ucCliente_AfterCloseUp(object sender, EventArgs e)
        {
            ucCliente.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ucCliente_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}", e.Row.Cells["razon_social"].Value.ToString().Trim());
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

        private void ucCliente_TextChanged(object sender, EventArgs e)
        {
            if (ucProducto.Value != null) ucProducto.Value = null;
            if (ucJob.Value != null) ucJob.Value = null;
        }

        private void ucProducto_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucProducto.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ucProducto_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucProducto_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_servicio"].Value.ToString().Trim(), e.Row.Cells["Nombre_largo"].Value.ToString().Trim());
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

        private void ucJob_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_job"].Value.ToString().Trim(), e.Row.Cells["descripcion"].Value.ToString().Trim());
        }

        private void ucJob_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
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

                //SelectNextControl(ucJob, true, true, true, true);
                ubAgregar.Focus();
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
    }
}