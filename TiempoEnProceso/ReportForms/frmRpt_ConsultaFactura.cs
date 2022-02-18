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
    public partial class frmRpt_ConsultaFactura : Form
    {
        private TEPEntities db= new TEPEntities(Helper.CadenaConexion);
        public bool impresion { get; set; }

        public frmRpt_ConsultaFactura()
        {
            InitializeComponent();
            db = new TEPEntities(Helper.CadenaConexion);
            db.Database.CommandTimeout = Helper.TimeOut;
            impresion = false;
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

            if (ucEntidad.Value != null &&
                ucEntidad.SelectedRow == null)
            {
                MessageBox.Show("Selección Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty((ucEntidad.SelectedRow.ListObject as tbl_entidad_legal)?.formato_facturas?.Trim()))
            {
                MessageBox.Show("Entidad no tiene configurado formato de Factura", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            tblentidadlegalBindingSource.DataSource = (new EntidadLegalBL()).Listar();
        }


        private bool Grabar()
        {
            if (!ValidataControles())
                return false;

            try
            {
                Cursor = Cursors.WaitCursor;

                string _entidad = ucEntidad.Value.ToString();
                string _numero = uneFactura.Value.ToString();

                List<rpt_consulta_factura_Result> lst = db.rpt_consulta_factura(Helper.Oficina, _entidad, "FAC", _numero).ToList<rpt_consulta_factura_Result>();

                if (lst.Count == 0)
                {
                    MessageBox.Show("No existe Información para los Parámetros Seleccionados");
                    return false;
                }

                List<rpt_consulta_cobros_factura_Result> lst0 = db.rpt_consulta_cobros_factura(Helper.Oficina, _entidad, "FAC", _numero).ToList<rpt_consulta_cobros_factura_Result>();


                DataSet dsData = Helper.ToDataSet<rpt_consulta_factura_Result>(lst);
                dsData.Tables[0].TableName = "pwcia";

                dsData.Tables.Add((Helper.ToDataSet<rpt_consulta_cobros_factura_Result>(lst0)).Tables[0].Copy());
                dsData.Tables[1].TableName = "pwcia_repetido";

                frmViewReport frm = new frmViewReport();
                frm._parameters.Add("Oficina", Helper.Oficina);
                frm._parameters.Add("Entidad", _entidad.ToString());
                frm._parameters.Add("Tipo_documento", "FAC");
                frm._parameters.Add("Numero_documento", _numero);

                frm._data = dsData;
                frm._reportName = "rpt_consulta_factura.rdlc";
                frm._showStatus = false;
                frm._exportButton = true;
                frm.ShowDialog();
                /*
                string _entidad = ucEntidad.Value.ToString();
                decimal _numero = Convert.ToDecimal( uneFactura.Value);

                List<rpt_imprime_factura_Net_Result> lst = db.rpt_imprime_factura_Net(_entidad, _numero,_numero, Helper.Oficina).ToList<rpt_imprime_factura_Net_Result>();
                if (lst.Count == 0)
                {
                    MessageBox.Show("No existe Información para los Parámetros Seleccionados");
                    return false;
                }

                DataSet dsData = Helper.ToDataSet<rpt_imprime_factura_Net_Result>(lst);
                dsData.Tables[0].TableName = "rpt_imprime_factura_Net;1";
                frmViewReportC frm = new frmViewReportC();
                frm._data = dsData;
                frm._exportFormat = CrystalDecisions.Shared.ViewerExportFormats.PdfFormat;
                frm._exportButton = true;
                frm._groupButton = false;
                frm._reportName = (ucEntidad.SelectedRow.ListObject as tbl_entidad_legal).formato_facturas.Trim();
                frm._reportFileName = string.Format("Factura_{0}", _numero);
                frm.Show();*/
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
            if (impresion)
                this.Text = "Impresión de Factura";

            uvValidador.NotificationSettings.Caption = Helper.NombreAplicacion;
            EstableceHabilitacion();
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

        private void uneFactura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneFactura, true, true, true, true);
        }

        
      
    }
}
