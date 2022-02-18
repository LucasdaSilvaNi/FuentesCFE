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
    public partial class frmRpt_CierreMensual : Form
    {
        private TEPEntities db= new TEPEntities(Helper.CadenaConexion);

        public frmRpt_CierreMensual()
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
            string _periodo = (Helper.OficinaActiva as tbl_oficina).periodo_proceso;
            string[] periodo = _periodo.Split('/');            
            DateTime dtF = new DateTime(Convert.ToInt32(periodo[1]), Convert.ToInt32(periodo[0]), 1);

            periodoBindingSource.DataSource = (new PeriodoBL()).ListarTodos(dtF.AddMonths(-1).ToString("MM/yyyy", new System.Globalization.CultureInfo("es-gt")));

            ucPeriodoActual.Value = _periodo;
            ucPeriodo.Value = dtF.AddMonths(1).ToString("MM/yyyy", new System.Globalization.CultureInfo("es-gt")); ;

        }


        private bool Grabar()
        {
            if (!ValidataControles())
                return false;

            try
            {
                Cursor = Cursors.WaitCursor;
                string _periodoAct = ucPeriodoActual.Value.ToString();
                string _periodo = ucPeriodo.Value.ToString();

                db.PROC_CIERRE(_periodoAct, _periodo);
                db.SaveChanges();

                Helper.OficinaActiva = db.tbl_oficina.FirstOrDefault(d => d.id_oficina == Helper.Oficina);

                Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Ejecución", "Proceso de Cierre ejecutado Satisfactoriamente");
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

            ucPeriodoActual.Focus();
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
            string _oficina = e.Row.Cells["id_oficina"].Value.ToString().Trim();
            tbl_oficina _tbl = db.tbl_oficina.FirstOrDefault(d => d.id_oficina == _oficina);

            if (_tbl != null)
                e.Row.Cells["desc"].Value = string.Format("{0}-{1}", _tbl.id_oficina, _tbl.Nombre.Trim());
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

        private void ucPeriodo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void ultraPanel4_PaintClient(object sender, PaintEventArgs e)
        {

        }

        private void ucPeriodoActual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucPeriodoActual, true, true, true, true);
        }


        
    }
}
