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
    public partial class frmRpt_ValidacionGastosAdmon : Form
    {
        private TEPEntities db= new TEPEntities(Helper.CadenaConexion);

        public frmRpt_ValidacionGastosAdmon()
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
        }


        private bool Grabar()
        {
            if (!ValidataControles())
                return false;

            try
            {
                Cursor = Cursors.WaitCursor;
                int iTipo = Convert.ToInt32(upTipo.Value);
                DataSet dsData = new DataSet();
                if (iTipo == 0)
                {
                    List<rpt_validacion_gastos_distribuidos_socios_Result> lst = db.rpt_validacion_gastos_distribuidos_socios(Helper.Oficina, utePeriodo.Value.ToString()).ToList();

                    if (lst.Count == 0)
                    {
                        MessageBox.Show("No existe Información para los Parámetros Seleccionados");
                        return false;
                    }

                    dsData = Helper.ToDataSet(lst);
                }
                else
                {
                    List<rpt_distribucion_gastos_preview_Result> lst = db.rpt_distribucion_gastos_preview(Helper.Oficina, utePeriodo.Value.ToString()).ToList();

                    if (lst.Count == 0)
                    {
                        MessageBox.Show("No existe Información para los Parámetros Seleccionados");
                        return false;
                    }

                    dsData = Helper.ToDataSet(lst);
                }
                dsData.Tables[0].TableName = "pwcia";                

                frmViewReport frm = new frmViewReport();
                frm._parameters.Add("Periodo", (Helper.OficinaActiva as tbl_oficina).periodo_proceso);
                frm._parameters.Add("Id_Oficina", Helper.Oficina);
                frm._data = dsData;
                frm._reportName = string.Format("{0}.rdlc",iTipo == 0 ? "Rpt_Validacion_Gastos_Distribucion_Socios":"Rpt_Validacion_Gastos");
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
            
        }
        #endregion

        private void frmRegion_Load(object sender, EventArgs e)
        {
            Helper.SetUltraComboWidth(this);
            uvValidador.NotificationSettings.Caption = Helper.NombreAplicacion;
            EstableceHabilitacion();
            utePeriodo.Value = (Helper.OficinaActiva as tbl_oficina).periodo_proceso;
            upTipo.Value = "0";
            CargaCombos();

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
      
    }
}
