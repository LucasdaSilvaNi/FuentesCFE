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
    public partial class frmRpt_BalanceAntiguedadClientes : Form
    {
        private TEPEntities db= new TEPEntities(Helper.CadenaConexion);

        public frmRpt_BalanceAntiguedadClientes()
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

            if (!uvValidador.Validate("requiredEnc", false, true).IsValid)
                return false;

            if (ucSocio.Value != null &&
                ucSocio.SelectedRow == null)
            {
                MessageBox.Show("Selección de Socio Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (ucEncargado.Value != null &&
                ucEncargado.SelectedRow == null)
            {
                MessageBox.Show("Selección de Encargado Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;
            tbl_empleados _empleado = Helper.UsuarioActivo as tbl_empleados;

            var query = from emp in db.tbl_empleados
                        join niv in db.tbl_niveles_empleado on emp.id_empleado equals niv.id_empleado
                        join ofi in db.tbl_oficina on niv.id_oficina equals ofi.id_oficina
                        where emp.id_empleado == Helper.usuario
                        select ofi;

            tbloficinaBindingSource.DataSource = query.ToList<tbl_oficina>(); 
            ucSocio.DataSource= (new SocioBL()).ListarTodosxEmpleadoSinTodos(_empleado.id_empleado, _empleado.id_oficina, _oficina.id_pais, _empleado.id_puesto);


        }


        private bool Grabar()
        {
            if (!ValidataControles())
                return false;

            try
            {
               
                Cursor = Cursors.WaitCursor;

                
                string _oficina = ucOficce.Value.ToString();
                tbl_empleados _empleado = Helper.UsuarioActivo as tbl_empleados;
                string _socio = uckTodosSocio.Checked ? "TODOS" : ucSocio.Value.ToString();
                string _encargado = uckTodosEncargado.Checked ? "TODOS" : ucEncargado.Value.ToString();
                DateTime dtFecha = Convert.ToDateTime(udteFecha.Value);
                string report = string.Empty;

                List<rpt_balance_antiguedad_saldos_anticipos_por_aplicar_Result> lst = db.rpt_balance_antiguedad_saldos_anticipos_por_aplicar(_oficina, dtFecha, _socio, _encargado).ToList();
                if (lst.Count == 0)
                {
                    MessageBox.Show("No existe Información para los Parámetros Seleccionados");
                    return false;
                }
                //rpt_balance_antiguedad_saldos_anticipos_por_aplicar
                
                /*List<rpt_balance_antiguedad_saldo_Result> lst = new List<rpt_balance_antiguedad_saldo_Result>();
                List<rpt_balance_antiguedad_saldos_resumen_preliminar_Result> lst0 = new List<rpt_balance_antiguedad_saldos_resumen_preliminar_Result>();
                List<rpt_balance_antiguedad_saldos_resumen_definitiva_Result> lst1 = new List<rpt_balance_antiguedad_saldos_resumen_definitiva_Result>();

                lst = db.rpt_balance_antiguedad_saldo(_oficina, dtFecha, uceAgrupamiento.Value.ToString(), uckTodosSocio.Checked ? Constantes.S_TODOS : _socio, uckTodosEncargado.Checked ? Constantes.S_TODOS : _encargado, Constantes.S_TODOS).ToList();

                

                lst0 = db.rpt_balance_antiguedad_saldos_resumen_preliminar(_oficina, dtFecha, uckTodosSocio.Checked ? Constantes.S_TODOS : _socio, uckTodosEncargado.Checked ? Constantes.S_TODOS : _encargado, Constantes.S_TODOS).ToList();
                lst1 = db.rpt_balance_antiguedad_saldos_resumen_definitiva(_oficina, dtFecha, uckTodosSocio.Checked ? Constantes.S_TODOS : _socio, uckTodosEncargado.Checked ? Constantes.S_TODOS : _encargado, Constantes.S_TODOS).ToList();

                dsData = Helper.ToDataSet<rpt_balance_antiguedad_saldo_Result>(lst);
                dsData.Tables[0].TableName = "pwcia";
                
                DataTable dt = Helper.ToDataSet<rpt_balance_antiguedad_saldos_resumen_preliminar_Result>(lst0).Tables[0].Copy();
                dt.TableName = "pwcia_repetido1";
                dsData.Tables.Add(dt);

                DataTable dt1 = Helper.ToDataSet<rpt_balance_antiguedad_saldos_resumen_definitiva_Result>(lst1).Tables[0].Copy();
                dt1.TableName = "pwcia_repetido2";
                dsData.Tables.Add(dt1);
                 */

                DataSet dsData = lst.ToDataSet<rpt_balance_antiguedad_saldos_anticipos_por_aplicar_Result>();
                dsData.Tables[0].TableName = "pwcia";

                frmViewReport frm = new frmViewReport();
                frm._parameters.Add("ala_fecha", dtFecha.ToString("dd/MM/yyyy"));
                frm._parameters.Add("Oficina", _oficina);
                frm._parameters.Add("Socio", uckTodosSocio.Checked ? Constantes.S_TODOS : _socio);
                frm._parameters.Add("Encargado", uckTodosEncargado.Checked ? Constantes.S_TODOS : _encargado);
                //frm._parameters.Add("Id_cliente", Constantes.S_TODOS);
                frm._parameters.Add("Agrupado_por", uceAgrupamiento.Value.ToString());
                frm._data = dsData;
                frm._reportName = "rpt_balance_antiguedad_saldos_anticipos.rdlc";
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

            udteFecha.Value = DateTime.Now.Date;
            uceAgrupamiento.Value = "Socio/Gerente";
            CargaCombos();
            ucSocio.Value = null;
            ucEncargado.Value = null;
            ucOficce.Value = Helper.Oficina;
            ucSocio.Focus();
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

            e.Row.Cells["desc"].Value = string.Format("{0}",e.Row.Cells["nombrecompleto"].Value.ToString().Trim());
        }

        private void ucPeriodo_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void uteDireccion_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void ucPais_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucSocio, true, true, true, true);
        }

        private void uckFacturar_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void ucOficina_KeyUp(object sender, KeyEventArgs e)
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
                int iSelLoc = ucSocio.Textbox.SelectionStart;
                if (!ucSocio.IsDroppedDown)
                {
                    if (ucSocio.Text.Length > 0)
                    {

                        ucSocio.ToggleDropdown();
                        ucSocio.Textbox.SelectionLength = 0;
                        ucSocio.Textbox.SelectionStart = iSelLoc;
                    }
                }
                if (ucSocio.Text.Trim() != string.Empty)
                {
                    ucSocio.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    ucSocio.DisplayLayout.Bands[0].ColumnFilters["desc"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, "*" + ucSocio.Text + "*");
                }
            }
        }

        private void ucOficina_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucSocio.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ucOficina_AfterCloseUp(object sender, EventArgs e)
        {
            ucSocio.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ucEncargado_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}", e.Row.Cells["nombrecompleto"].Value.ToString().Trim());
        }

        private void ucEncargado_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucEncargado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucEncargado, true, true, true, true);
        }

        private void ucEncargado_KeyUp(object sender, KeyEventArgs e)
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
                int iSelLoc = ucEncargado.Textbox.SelectionStart;
                if (!ucSocio.IsDroppedDown)
                {
                    if (ucEncargado.Text.Length > 0)
                    {

                        ucEncargado.ToggleDropdown();
                        ucEncargado.Textbox.SelectionLength = 0;
                        ucEncargado.Textbox.SelectionStart = iSelLoc;
                    }
                }
                if (ucEncargado.Text.Trim() != string.Empty)
                {
                    ucEncargado.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    ucEncargado.DisplayLayout.Bands[0].ColumnFilters["desc"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, "*" + ucEncargado.Text + "*");
                }
            }
        }

        private void ucEncargado_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucEncargado.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ucOficina_ValueChanged(object sender, EventArgs e)
        {
            if (ucSocio.Value != null &&
                ucSocio.SelectedRow != null)
            {
                string _socio = ucSocio.Value.ToString();
                tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;

                tbl_empleados _empleado = Helper.UsuarioActivo as tbl_empleados;

                ucEncargado.DataSource = (new EncargadoBL()).ListarTodosxEmpleadoSinTodos(_socio, Helper.usuario, _oficina.id_oficina, _oficina.id_pais, _empleado.id_puesto);
            }


        }

        private void ucOficce_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;
            string _oficina = e.Row.Cells["id_oficina"].Value.ToString().Trim();
            tbl_oficina _tbl = db.tbl_oficina.FirstOrDefault(d => d.id_oficina == _oficina);

            if (_tbl != null)
                e.Row.Cells["desc"].Value = string.Format("{0}-{1}", _tbl.id_oficina, _tbl.Nombre.Trim());
        }

        private void uckTodosSocio_CheckedChanged(object sender, EventArgs e)
        {
            uvValidador.ValidationGroups["required"].Enabled = !uckTodosSocio.Checked;
        }

        private void uckTodosEncargado_CheckedChanged(object sender, EventArgs e)
        {
            uvValidador.ValidationGroups["requiredEnc"].Enabled = !uckTodosEncargado.Checked;
        }


        
    }
}
