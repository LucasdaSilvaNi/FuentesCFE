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
    public partial class frmRpt_IntegracionTEPEmpleado : Form
    {
        private TEPEntities db= new TEPEntities(Helper.CadenaConexion);

        public frmRpt_IntegracionTEPEmpleado()
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

            if (ucCliente.Value != null &&
                ucCliente.SelectedRow == null)
            {
                MessageBox.Show("Selección de Cliente Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (ucServicio.Value != null &&
                ucServicio.SelectedRow == null)
            {
                MessageBox.Show("Selección de Servicio Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            string _periodo = _oficina.periodo_proceso;
            string[] periodo = _periodo.Split('/');
            DateTime dtF = new DateTime(Convert.ToInt32(periodo[1]) ,1, 1);

            List<TiempoEnProcesoEN.ClienteEN> lstCliente = new List<TiempoEnProcesoEN.ClienteEN>();
            var query = from c in db.tbl_clientes
                        from p in db.tbl_oficina
                            .Where(p => p.id_pais == c.id_pais && p.id_oficina == Helper.Oficina)
                        from g in db.tbl_grupos
                            .Where(g => g.id_grupo == c.id_grupo).DefaultIfEmpty()
                        from i in db.tbl_industrias
                            .Where(i => i.id_industria == c.id_industria).DefaultIfEmpty()
                        select new { c, g, i };
            foreach (var item in query.OrderBy(d => d.c.id_cliente))
                lstCliente.Add(new TiempoEnProcesoEN.ClienteEN() { id_cliente = item.c.id_cliente, razon_social = item.c.Razon_Social.Trim() + "; Grupo: " + (item.g==null?"":item.g.nombre.Trim()) + " Industria: " + item.i.nombre.Trim() });

            ucCliente.DataSource = lstCliente;

            List<PeriodoEN>lstPer = (new PeriodoBL()).ListarTodos(dtF.ToString("MM/yyyy", new System.Globalization.CultureInfo("es-gt")));
            lstPer.ForEach(d => d.descripcion = d.descripcion.Remove(d.descripcion.IndexOf("/")));
            periodoENBindingSource.DataSource = lstPer;

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
                string _cliente = ucCliente.Value.ToString();
                string _servicio = "TOD";

                if (ucServicio.Value != null)
                    _servicio = ucServicio.Value.ToString();

                string _job = "TOD";

                if (uteJob.Value != null)
                    _job = uteJob.Value.ToString();

                string _periodo=ucPeriodo.Value.ToString().Substring(0,2).PadLeft(2,'0');

                List<rpt_integracion_tep_empleado_gasto_Result> lst = db.rpt_integracion_tep_empleado_gasto(_oficina.id_oficina, _cliente, _servicio, uneAnioTep.Value.ToString(), _periodo, _job).ToList<rpt_integracion_tep_empleado_gasto_Result>();

                if (lst.Count == 0)
                {
                    MessageBox.Show("No existe Información para los Parámetros Seleccionados");
                    return false;
                }

                DataSet dsData = Helper.ToDataSet<rpt_integracion_tep_empleado_gasto_Result>(lst);
                dsData.Tables[0].TableName = "pwcia";

                frmViewReport frm = new frmViewReport();
                frm._data = dsData;
                frm._parameters.Add("Oficina", _oficina.id_oficina);
                frm._parameters.Add("Cliente", _cliente);
                frm._parameters.Add("Servicio", _servicio);
                frm._parameters.Add("Anio", uneAnioTep.Value.ToString());
                frm._parameters.Add("Periodo", _periodo);
                frm._parameters.Add("Id_job", _job);
                frm._reportName = "rpt_integracion_tep_empleado.rdlc";
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
            ucPeriodo.Value = (Helper.OficinaActiva as tbl_oficina).periodo_proceso;
            uneAnioTep.Value = (Helper.OficinaActiva as tbl_oficina).periodo_proceso.Substring(3, 4);
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
            if (ucCliente.Value != null &&
               ucCliente.SelectedRow != null)
            {
                string _socio = Constantes.S_TODOS;
                string _encargado = Constantes.S_TODOS;
                string _cliente = ucCliente.Value.ToString();
                tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;

                tbl_empleados _empleado = Helper.UsuarioActivo as tbl_empleados;

                //ucServicio.DataSource = (new ServicioBL()).ListarTodos(_cliente, _socio, _encargado, _oficina.id_oficina);
                List<ServicioEN> lstServ = new List<ServicioEN>();
                foreach (tbl_servicios _srv in db.tbl_servicios.OrderBy(d => d.id_servicio).ToList<tbl_servicios>())
                    lstServ.Add(new ServicioEN()
                    {
                        id_servicio = _srv.id_servicio,
                        Nombre_largo = _srv.Nombre_largo
                    });

                ucServicio.DataSource = lstServ;
            }
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
            e.Row.Cells["desc"].Value = string.Format("{0} {1}",e.Row.Cells["id_cliente"].Value.ToString().Trim(), e.Row.Cells["razon_social"].Value.ToString().Trim());
        }

        private void ucServicio_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_servicio"].Value.ToString().Trim(), e.Row.Cells["nombre_largo"].Value.ToString().Trim());
        }

        private void ucJob_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Cells["desc"].Value = string.Format("{0}", e.Row.Cells["descripcion"].Value.ToString().Trim());
        }

        private void ucJob_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucJob_KeyDown(object sender, KeyEventArgs e)
        {
           
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
            {
                if (ucServicio.Value != null)
                {
                    string sVal = ucServicio.Value.ToString();
                    ucServicio.Value = null;
                    ucServicio.Value = sVal.PadRight(4, ' ');
                }
                SelectNextControl(ucServicio, true, true, true, true);
            }
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
                int iSelLoc = ucServicio.Textbox.SelectionStart;
                if (!ucServicio.IsDroppedDown)
                {
                    if (ucServicio.Text.Length > 0)
                    {

                        ucServicio.ToggleDropdown();
                        ucServicio.Textbox.SelectionLength = 0;
                        ucServicio.Textbox.SelectionStart = iSelLoc;
                    }
                }
                if (ucServicio.Text.Trim() != string.Empty)
                {
                    ucServicio.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    ucServicio.DisplayLayout.Bands[0].ColumnFilters["desc"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, "*" + ucServicio.Text + "*");
                }
            }
        }

        private void ucJob_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void uneAnioTep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneAnioTep, true, true, true, true);
        }

        private void ucPeriodo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucPeriodo, true, true, true, true);
        }

        private void ucCliente_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucCliente.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ucPeriodo_ValueChanged(object sender, EventArgs e)
        {
            uneAnioTep.Value = ucPeriodo.Value.ToString().Substring(3);
        }

        private void uteJob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteJob, true, true, true, true);
        }


        
    }
}
