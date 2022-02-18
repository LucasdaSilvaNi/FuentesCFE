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

namespace TiempoEnProceso.Forms
{
    public partial class frmRpt_HistorialCargosAcumulados : Form
    {
        private TEPEntities db= new TEPEntities(Helper.CadenaConexion);
        private bool IsLoad = false;

        public frmRpt_HistorialCargosAcumulados()
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

            if (!uvValidador.Validate("reqcliente", false, true).IsValid &&
                upTipo.Value.ToString()!="1")
                return false;

            if (!uvValidador.Validate("reqempleado", false, true).IsValid &&
                upTipo.Value.ToString() == "1")
                return false;

            if (upTipo.Value.ToString() != "1")
            {
                if (ucCliente.Value != null &&
                    ucCliente.SelectedRow == null)
                {
                    MessageBox.Show("Selección de Cliente Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {

                if (ucEmpleado.Value != null &&
                    ucEmpleado.SelectedRow == null)
                {
                    MessageBox.Show("Selección de Empleado Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
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
            
            ucEmpleado.DataSource = (new EmpleadosBL()).ListarTodos(Helper.Oficina);
            IsLoad = true;
        }


        private bool Grabar()
        {
            if (!ValidataControles())
                return false;

            try
            {
               
                Cursor = Cursors.WaitCursor;
                string report = string.Empty;
                tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;
                string _cliente = upTipo.Value.ToString() != "1" ? ucCliente.Value.ToString() : "";
                string _empleado = upTipo.Value.ToString() == "1" ? ucEmpleado.Value.ToString() : "";

                DataSet dsData;
                if (upTipo.Value.ToString() == "1")
                {
                    List<rpt_historial_cargos_acumulados_Result> lst = db.rpt_historial_cargos_acumulados(_oficina.id_oficina, _empleado, unePeriodo.Value.ToString()).ToList<rpt_historial_cargos_acumulados_Result>();

                    if (lst.Count == 0)
                    {
                        MessageBox.Show("No existe Información para los Parámetros Seleccionados");
                        return false;
                    }
                    dsData = Helper.ToDataSet<rpt_historial_cargos_acumulados_Result>(lst);

                    List<rpt_historial_cargos_acumulados_empleado_resumen_Result> lst0 = db.rpt_historial_cargos_acumulados_empleado_resumen(_oficina.id_oficina, _empleado, unePeriodo.Value.ToString()).ToList<rpt_historial_cargos_acumulados_empleado_resumen_Result>();
                    dsData.Tables.Add(Helper.ToDataSet<rpt_historial_cargos_acumulados_empleado_resumen_Result>(lst0).Tables[0].Copy());

                    report = "rpt_historial_cargos_acumulados";
                }
                else
                {
                    List<rpt_historial_cargos_acumulados_cliente_Result> lst = db.rpt_historial_cargos_acumulados_cliente(_oficina.id_oficina, _cliente, unePeriodo.Value.ToString()).ToList<rpt_historial_cargos_acumulados_cliente_Result>();
                    if (lst.Count == 0)
                    {
                        MessageBox.Show("No existe Información para los Parámetros Seleccionados");
                        return false;
                    }
                    dsData = Helper.ToDataSet<rpt_historial_cargos_acumulados_cliente_Result>(lst);
                    List<rpt_historial_cargos_acumulados_cliente_resumen_Result> lst0 = db.rpt_historial_cargos_acumulados_cliente_resumen(_oficina.id_oficina, _empleado, unePeriodo.Value.ToString()).ToList<rpt_historial_cargos_acumulados_cliente_resumen_Result>();
                    dsData.Tables.Add(Helper.ToDataSet<rpt_historial_cargos_acumulados_cliente_resumen_Result>(lst0).Tables[0].Copy());

                    report = "rpt_historial_cargos_acumulados_cliente";
                }

                dsData.Tables[0].TableName = "pwcia";
                dsData.Tables[1].TableName = "pwcia_repetido";

                frmViewReport frm = new frmViewReport();
                frm._parameters.Add("Id_oficina", Helper.Oficina);
                if (upTipo.Value.ToString() == "1")
                    frm._parameters.Add("Id_empleado", _cliente);
                else
                    frm._parameters.Add("Id_cliente", _cliente);
                frm._parameters.Add("Periodo", unePeriodo.Value.ToString());

                frm._data = dsData;
                frm._reportName = report+".rdlc";
                frm._showStatus = false;
                frm._exportButton = true;
                frm.Show();
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
            Helper.GetControls<UltraTextEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);

        }
        #endregion

        private void frmRegion_Load(object sender, EventArgs e)
        {
            Helper.SetUltraComboWidth(this);
            uvValidador.NotificationSettings.Caption = Helper.NombreAplicacion;
            EstableceHabilitacion();

            CargaCombos();
            upTipo.Value = 1;
            
        }

        private void ubAgregar_Click(object sender, EventArgs e)
        {
            if (Grabar())
            {
                //DialogResult = System.Windows.Forms.DialogResult.OK;
                //Close();
            }
        }

        private void ubCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void uteDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void ucPais_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucPais_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}", e.Row.Cells["nombrecompleto"].Value.ToString().Trim());
        }

        private void ucPeriodo_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void uteDireccion_KeyDown(object sender, KeyEventArgs e)
        {
        }

        
        private void uckFacturar_CheckedChanged(object sender, EventArgs e)
        {

        }
        
          private void ucCliente_ValueChanged(object sender, EventArgs e)
        {
        }

        private void ucServicio_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucServicio_ValueChanged(object sender, EventArgs e)
        {
        }

        private void ucCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucCliente, true, true, true, true);
        }

        private void ucCliente_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucCliente_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Cells["desc"].Value = string.Format("{0} {1}", e.Row.Cells["id_cliente"].Value.ToString().Trim(), e.Row.Cells["razon_social"].Value.ToString().Trim());
        }

        private void ucServicio_InitializeRow(object sender, InitializeRowEventArgs e)
        {

            e.Row.Cells["desc"].Value = string.Format("{0}", e.Row.Cells["nombrecompleto"].Value.ToString().Trim());
        }

        private void ucJob_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Cells["desc"].Value = string.Format("{0}", e.Row.Cells["descripcion"].Value.ToString().Trim());
        }

        private void ucJob_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
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

        private void ucServicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucEmpleado, true, true, true, true);
        }

        private void ucServicio_KeyUp(object sender, KeyEventArgs e)
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
                int iSelLoc = ucEmpleado.Textbox.SelectionStart;
                if (!ucEmpleado.IsDroppedDown)
                {
                    if (ucEmpleado.Text.Length > 0)
                    {

                        ucEmpleado.ToggleDropdown();
                        ucEmpleado.Textbox.SelectionLength = 0;
                        ucEmpleado.Textbox.SelectionStart = iSelLoc;
                    }
                }
                if (ucEmpleado.Text.Trim() != string.Empty)
                {
                    ucEmpleado.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    ucEmpleado.DisplayLayout.Bands[0].ColumnFilters["desc"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, "*" + ucEmpleado.Text + "*");
                }
            }
        }

         private void ucCliente_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }

        private void ultraLabel4_Click(object sender, EventArgs e)
        {

        }

        private void upTipo_ValueChanged(object sender, EventArgs e)
        {
            ucEmpleado.Enabled = false;
            ucCliente.Enabled = false;
            uvValidador.ValidationGroups["reqempleado"].Enabled = false;
            uvValidador.ValidationGroups["reqcliente"].Enabled = false;
            if (upTipo.Value.ToString() == "1")
            {
               
                ucEmpleado.Enabled = true;
                uvValidador.ValidationGroups["reqempleado"].Enabled = true;
            }
            else
            {
                if (IsLoad)
                {
                    tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;
                    List<TiempoEnProcesoEN.ClienteEN> lstCliente = new List<TiempoEnProcesoEN.ClienteEN>();
                    IQueryable query = from c in db.tbl_clientes
                                       where c.id_pais == _oficina.id_pais
                                       orderby c.id_cliente
                                       select c;

                    query.Cast<tbl_clientes>().ToList().ForEach(d => lstCliente.Add(new TiempoEnProcesoEN.ClienteEN() { id_cliente = d.id_cliente, razon_social = d.Razon_Social.Trim() }));

                    ucCliente.DataSource = lstCliente;
                }

                IsLoad = false;

                ucCliente.Enabled = true;
                uvValidador.ValidationGroups["reqcliente"].Enabled = true;
            }
        }

        private void ucEmpleado_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucEmpleado.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ucCliente_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucCliente.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }


        
    }
}
