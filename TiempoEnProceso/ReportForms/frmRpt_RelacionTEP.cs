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
    public partial class frmRpt_RelacionTEP : Form
    {
        private TEPEntities db= new TEPEntities(Helper.CadenaConexion);

        public frmRpt_RelacionTEP()
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
                string _socio = ucOficina.Value.ToString();
                string _encargado=ucEncargado.Value.ToString();

                List<rpt_relacion_trabajo_proceso_Result> lst = db.rpt_relacion_trabajo_proceso(_oficina.id_pais, _oficina.id_oficina, _oficina.periodo_proceso, Constantes.ORD_SOCIO_GERENTE, "S", _socio, _encargado).ToList();

                if (lst.Count == 0)
                {
                    MessageBox.Show("No existe Información para los Parámetros Seleccionados");
                    return false;
                }

                DataSet dsData = Helper.ToDataSet<rpt_relacion_trabajo_proceso_Result>(lst);
                dsData.Tables[0].TableName = "pwcia";

                DataTable dt = dsData.Tables[0].Copy();
                dt.TableName = "pwcia_repetido";

                dsData.Tables.Add(dt);                

                frmViewReport frm = new frmViewReport();
                frm._parameters.Add("Pais", _oficina.id_pais);
                frm._parameters.Add("Periodo", _oficina.periodo_proceso);
                frm._parameters.Add("Oficina", _oficina.id_oficina);
                frm._parameters.Add("Ordenadopor", Constantes.ORD_SOCIO_GERENTE);
                frm._parameters.Add("Salta", "S");
                frm._parameters.Add("Id_socio", _socio);
                frm._parameters.Add("Id_encargado", _encargado);

                frm._data = dsData;
                frm._reportName = "rpt_relacion_trabajo_proceso.rdlc";
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
            ucOficina.Value = Constantes.S_TODOS;
            ucEncargado.Value = Constantes.S_TODOS;
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
                SelectNextControl(ucOficina, true, true, true, true);
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
                if (!ucOficina.IsDroppedDown)
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

                ucEncargado.DataSource = (new EncargadoBL()).ListarTodosxEmpleadoSinTodos(_socio, Helper.usuario, _oficina.id_oficina, _oficina.id_pais, _empleado.id_puesto);
            }


        }


        
    }
}
