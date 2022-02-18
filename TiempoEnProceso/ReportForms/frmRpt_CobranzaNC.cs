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
    public partial class frmRpt_CobranzaNC : Form
    {
        private TEPEntities db= new TEPEntities(Helper.CadenaConexion);

        public frmRpt_CobranzaNC()
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
            tblentidadlegalBindingSource.DataSource = (new EntidadLegalBL()).Listar();
            periodoBindingSource.DataSource = (new PeriodoBL()).Listar();
        }


        private bool Grabar()
        {
            if (!ValidataControles())
                return false;

            try
            {
                Cursor = Cursors.WaitCursor;

                DateTime dtI = Convert.ToDateTime(uccFechaInicial.Value).Date;
                DateTime dtF = Convert.ToDateTime(uccFechaFinal.Value).Date;

                int _entidad = 99;
                if (ucEntidad.Value != null)
                    _entidad = Convert.ToInt32(ucEntidad.Value);

                string report_name = "VALIDACION_COBRANZA_DISTRIBUCION";// "rpt_validacion_cobranzas2";

                List<rpt_validacion_cobranzas_Distribucion_Result> lst = db.rpt_validacion_cobranzas_Distribucion(Helper.Oficina, dtI, dtF, _entidad, upTipo.Value.ToString()).ToList();

                if (lst.Count == 0)
                {
                    MessageBox.Show("No existe Información para los Parámetros Seleccionados");
                    return false;
                }

                //List<rpt_validacion_cobranzas_resumen_Result> lstA = db.rpt_validacion_cobranzas_resumen(Helper.Oficina, dtI, dtF, _entidad, upTipo.Value.ToString()).ToList<rpt_validacion_cobranzas_resumen_Result>();

                DataSet dsData = Helper.ToDataSet<rpt_validacion_cobranzas_Distribucion_Result>(lst);
                dsData.Tables[0].TableName = "pwcia";

                DataTable dt = Helper.ToDataSet<rpt_validacion_cobranzas_Distribucion_Result>(lst).Tables[0].Copy();
                dt.TableName = "pwcia_repetido";

                if (uceAgrupamiento.Value.ToString() != "Defecto")
                    report_name = uceAgrupamiento.Value.ToString() == "Socio/Gerente" ? "rpt_cobranzas_socio_Gerente" : (uceAgrupamiento.Value.ToString() == "Gerente/Socio" ? "rpt_cobranzas_Gerente_socio" : "rpt_cobranzas_Gerente");

                dsData.Tables.Add(dt);                

                frmViewReport frm = new frmViewReport();
                frm._parameters.Add("id_oficina", Helper.Oficina);
                frm._parameters.Add("fecha_inicial", dtI.ToShortDateString());
                frm._parameters.Add("fecha_final", dtF.ToShortDateString());
                frm._parameters.Add("tipo_documento", upTipo.Value.ToString());
                frm._parameters.Add("Id_entidad", _entidad.ToString());

                frm._data = dsData;
                frm._reportName = $"{report_name}.rdlc";
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
            upTipo.Value = "COBRANZA";

            uccFechaInicial.Value = DateTime.Now.AddDays(DateTime.Now.Day * -1).AddDays(1);
            uccFechaFinal.Value = Convert.ToDateTime(uccFechaInicial.Value).AddMonths(1).AddDays(-1);
            uceAgrupamiento.Value = "Defecto";
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

        private void uccFechaInicial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uccFechaInicial, true, true, true, true);
        }

        private void uccFechaFinal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uccFechaFinal, true, true, true, true);
        }

        private void upTipo_ValueChanged(object sender, EventArgs e)
        {
        }

        
      
    }
}
