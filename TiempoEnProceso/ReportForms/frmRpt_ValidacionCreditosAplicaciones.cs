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
    public partial class frmRpt_ValidacionCreditosAplicaciones : Form
    {
        private TEPEntities db= new TEPEntities(Helper.CadenaConexion);

        public frmRpt_ValidacionCreditosAplicaciones()
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

            if (ucPeriodo.Value != null &&
                ucPeriodo.SelectedRow == null)
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
            periodoBindingSource.DataSource = (new PeriodoBL()).Listar();
        }


        private bool Grabar()
        {
            if (!ValidataControles())
                return false;

            try
            {
                Cursor = Cursors.WaitCursor;

                DataSet dsData;
                if (upTipo.Value.ToString() == "1")
                {
                    List<rpt_validacion_creditos_aplicaciones_Result> lst = db.rpt_validacion_creditos_aplicaciones(Helper.Oficina, ucPeriodo.Value.ToString()).ToList<rpt_validacion_creditos_aplicaciones_Result>();
                    if (lst.Count == 0)
                    {
                        MessageBox.Show("No existe Información para los Parámetros Seleccionados");
                        return false;
                    }
                    dsData = Helper.ToDataSet<rpt_validacion_creditos_aplicaciones_Result>(lst);
                    dsData.Tables[0].TableName = "pwcia";

                    List<rpt_validacion_creditos_aplicaciones_Result> lst0 = db.rpt_validacion_creditos_aplicaciones(Helper.Oficina, ucPeriodo.Value.ToString()).ToList();
                    DataSet _ds = Helper.ToDataSet<rpt_validacion_creditos_aplicaciones_Result>(lst0);
                    dsData.Tables.Add(_ds.Tables[0].Copy());
                    dsData.Tables[1].TableName = "pwcia_repetido1";

                    List<rpt_validacion_credito_aplicaciones_aplicaciones_resumen_Result> lst1 = db.rpt_validacion_credito_aplicaciones_aplicaciones_resumen(Helper.Oficina, ucPeriodo.Value.ToString()).ToList();
                    _ds = Helper.ToDataSet<rpt_validacion_credito_aplicaciones_aplicaciones_resumen_Result>(lst1);
                    dsData.Tables.Add(_ds.Tables[0].Copy());
                    dsData.Tables[2].TableName = "pwcia_repetido2";
                    //List<rpt_validacion_credito_aplicaciones_aplicaciones_Result> lst1 = db.rpt_validacion_credito_aplicaciones_aplicaciones(
                }
                else
                {
                    List<rpt_validacion_creditos_aplicaciones_listado_Result> lst = db.rpt_validacion_creditos_aplicaciones_listado(Helper.Oficina, ucPeriodo.Value.ToString()).ToList<rpt_validacion_creditos_aplicaciones_listado_Result>();
                    if (lst.Count == 0)
                    {
                        MessageBox.Show("No existe Información para los Parámetros Seleccionados");
                        return false;
                    }
                    dsData = Helper.ToDataSet<rpt_validacion_creditos_aplicaciones_listado_Result>(lst);
                    dsData.Tables[0].TableName = "pwcia";

                    DataTable dt = dsData.Tables[0].Copy();
                    dt.TableName = "pwcia_repetido";
                    dsData.Tables.Add(dt);                   
                }
                
                frmViewReport frm = new frmViewReport();
                frm._parameters.Add("Periodo", ucPeriodo.Value.ToString());
                frm._parameters.Add("Oficina", Helper.Oficina);
                if (upTipo.Value.ToString() == "1")
                {
                    frm._DynamicSubReport = true;
                    frm._DynamicType = ",rpt_validacion_creditos_aplicaciones_aplicaciones,";
                    frm._reportName = "rpt_validacion_creditos_aplicaciones.rdlc";
                }
                else
                    frm._reportName = "rpt_validacion_creditos_aplicaciones_listado.rdlc";
                frm._data = dsData;
                
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
            CargaCombos();
            upTipo.Value = "1";

            ucPeriodo.Value = (Helper.OficinaActiva as tbl_oficina).periodo_proceso;
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

        private void ucEntidad_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

       

        private void upTipo_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void ucPeriodo_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }
      
    }
}
