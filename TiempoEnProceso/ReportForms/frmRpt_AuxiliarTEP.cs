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
    public partial class frmRpt_AuxiliarTEP : Form
    {
        private TEPEntities db= new TEPEntities(Helper.CadenaConexion);

        public frmRpt_AuxiliarTEP()
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

            if (ucOficina.Value != null &&
                ucOficina.SelectedRow == null)
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

            if (ucCliente.Value != null &&
                ucCliente.SelectedRow == null)
            {
                MessageBox.Show("Selección de Cliente Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (ucOficina.Value == null &&
                !uckSocio.Checked)
            {
                MessageBox.Show("Selección de Socio Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (ucEncargado.Value == null &&
                !uckEncargado.Checked)
            {
                MessageBox.Show("Selección de Encargado Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (ucCliente.Value == null &&
                !uckCliente.Checked)
            {
                MessageBox.Show("Selección de Cliente Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!uckSrv.Checked &&
                uteServicio.Value == null)
            {
                MessageBox.Show("Selección de Servicio Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!uckJob.Checked &&
                uteJob.Value==null)
            {
                MessageBox.Show("Selección de Job Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            ucOficina.DataSource= (new SocioBL()).ListarTodosxEmpleado(_empleado.id_empleado, _empleado.id_oficina, _oficina.id_pais, _empleado.id_puesto);

            ucCliente.DataSource = (new ClientesBL()).ListarTodoLight(_oficina.id_oficina);

        }

        private bool Grabar()
        {
            if (!ValidataControles())
                return false;

            try
            {
               
                Cursor = Cursors.WaitCursor;

                tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;
                tbl_empleados _empleado = Helper.UsuarioActivo as tbl_empleados;
                string _socio = uckSocio.Checked ? Constantes.S_TODOS : ucOficina.Value.ToString();
                string _encargado = uckEncargado.Checked ? Constantes.S_TODOS : ucEncargado.Value.ToString();
                string _cliente = uckCliente.Checked ? Constantes.S_TODOS : ucCliente.Value.ToString();
                string _servicio = uckSrv.Checked ? Constantes.S_TODOS : uteServicio.Value.ToString();
                string _job = uckJob.Checked ? Constantes.S_TODOS : uteJob.Value.ToString();

                List<rpt_auxiliar_trabajo_proceso_Result> lst = db.rpt_auxiliar_trabajo_proceso(Helper.Oficina, _socio, _encargado, _cliente, _servicio, _job).ToList<rpt_auxiliar_trabajo_proceso_Result>();

                if (lst.Count == 0)
                {
                    MessageBox.Show("No existe Información para los Parámetros Seleccionados");
                    return false;
                }

                //List<rpt_auxiliar_trabajo_proceso_sub_reporte_Result> lstS = db.rpt_auxiliar_trabajo_proceso_sub_reporte(Helper.Oficina, _cliente, _servicio, _job, _socio, _encargado).ToList<rpt_auxiliar_trabajo_proceso_sub_reporte_Result>();

                DataSet dsData = Helper.ToDataSet<rpt_auxiliar_trabajo_proceso_Result>(lst);
                dsData.Tables[0].TableName = "pwcia";

                //DataTable dt = Helper.ToDataSet<rpt_auxiliar_trabajo_proceso_sub_reporte_Result>(lstS).Tables[0].Copy();
                //dt.TableName = "pwcia_repetido";

                //dsData.Tables.Add(dt);                

                frmViewReport frm = new frmViewReport();
                frm._data = dsData;
                frm._reportName = "rpt_auxiliar_trabajo_en_proceso.rdlc";
                frm._showStatus = false;
                frm._exportButton = true;
                frm._DynamicSubReport = true;
                frm._DynamicType = ",rpt_auxiliar_trabajo_proceso_subreporte,rpt_auxiliar_trabajo_en_proceso_facturas_anticipos,";
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
            ucOficina.Value = null;
            uckSrv.Checked = true;
            uckJob.Checked = true;
            ucOficina.Focus();
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

            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_empleado"].Value.ToString().Trim(), e.Row.Cells["nombrecompleto"].Value.ToString().Trim());
        }

        private void ucPeriodo_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucPais_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ucOficina.Value != null)
                {
                    string sVal = ucOficina.Value.ToString();
                    ucOficina.Value = null;
                    ucOficina.Value = sVal.PadRight(10);
                }
                SelectNextControl(ucOficina, true, true, true, true);
            }
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
                int iSelLoc = ucOficina.Textbox.SelectionStart;
                if (!ucOficina.IsDroppedDown)
                {
                    if (ucOficina.Text.Length > 0)
                    {

                        ucOficina.ToggleDropdown();
                        ucOficina.Textbox.SelectionLength = 0;
                        ucOficina.Textbox.SelectionStart = iSelLoc;
                    }
                }
                if (ucOficina.Text.Trim() != string.Empty)
                {
                    ucOficina.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    ucOficina.DisplayLayout.Bands[0].ColumnFilters["desc"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, "*" + ucOficina.Text + "*");
                }
            }
        }

        private void ucOficina_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucOficina.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ucOficina_AfterCloseUp(object sender, EventArgs e)
        {
            ucOficina.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ucEncargado_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}-{1}",e.Row.Cells["id_empleado"].Value.ToString().Trim(), e.Row.Cells["nombrecompleto"].Value.ToString().Trim());
        }

        private void ucEncargado_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucEncargado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ucEncargado.Value != null)
                {
                    string sVal = ucEncargado.Value.ToString();
                    ucEncargado.Value = null;
                    ucEncargado.Value = sVal.PadRight(10);
                }
                SelectNextControl(ucEncargado, true, true, true, true);
            }
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
                if (!ucEncargado.IsDroppedDown)
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
            if (ucOficina.Value != null &&
                ucOficina.SelectedRow != null)
            {
                string _socio = ucOficina.Value.ToString();
                tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;

                tbl_empleados _empleado = Helper.UsuarioActivo as tbl_empleados;

                ucEncargado.DataSource = (new EncargadoBL()).ListarTodosxEmpleado(_socio, Helper.usuario, _oficina.id_oficina, _oficina.id_pais, _empleado.id_puesto);
            }


        }

        private void ucEncargado_ValueChanged(object sender, EventArgs e)
        {
            /*if (ucEncargado.Value != null &&
                ucEncargado.SelectedRow != null)
            {
                string _socio = ucOficina.Value.ToString();
                string _encargado = ucEncargado.Value.ToString();
                tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;

                tbl_empleados _empleado = Helper.UsuarioActivo as tbl_empleados;

                //ucCliente.DataSource = (new ClientesBL()).ListarTodoOficinaEncargadoSocio(_socio, _encargado, _oficina.id_oficina);
                
                
                //ucCliente.Value = Constantes.S_TODOS;
            }*/
        }

        private void ucCliente_ValueChanged(object sender, EventArgs e)
        {
            /*if (ucCliente.Value != null &&
               ucCliente.SelectedRow != null)
            {
                string _socio = ucOficina.Value.ToString();
                string _encargado = ucEncargado.Value.ToString();
                string _cliente = ucCliente.Value.ToString();
                tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;

                tbl_empleados _empleado = Helper.UsuarioActivo as tbl_empleados;

                ucServicio.DataSource = (new ServicioBL()).ListarTodos(_cliente, _socio, _encargado, _oficina.id_oficina);
                ucServicio.Value = Constantes.S_TODOS;
            }*/
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

        private void ucCliente_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucCliente_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Cells["desc"].Value = string.Format("{0}-{1}",e.Row.Cells["id_cliente"].Value.ToString().Trim(), e.Row.Cells["razon_social"].Value.ToString().Trim());
        }

        private void ucServicio_InitializeRow(object sender, InitializeRowEventArgs e)
        {

            e.Row.Cells["desc"].Value = string.Format("{0}-{1}",e.Row.Cells["id_servicio"].Value.ToString().Trim(), e.Row.Cells["Nombre_largo"].Value.ToString().Trim());
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

        private void uckSrv_CheckedChanged(object sender, EventArgs e)
        {
            uteServicio.Enabled = uckSrv.Checked == false;
        }

        private void uckJob_CheckedChanged(object sender, EventArgs e)
        {
            uteJob.Enabled = uckJob.Checked == false;
        }

        private void uckSocio_CheckedChanged(object sender, EventArgs e)
        {
            ucOficina.Enabled = !uckSocio.Checked;
        }

        private void uckEncargado_CheckedChanged(object sender, EventArgs e)
        {
            ucEncargado.Enabled = !uckEncargado.Checked;
        }

        private void uckCliente_CheckedChanged(object sender, EventArgs e)
        {
            ucCliente.Enabled = !uckCliente.Checked;
        }

        private void ucOficina_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }


        
    }
}
