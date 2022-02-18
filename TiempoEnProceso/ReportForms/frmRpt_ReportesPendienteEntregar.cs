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
    public partial class frmRpt_ReportesPendienteEntregar : Form
    {
        private TEPEntities db= new TEPEntities(Helper.CadenaConexion);

        public frmRpt_ReportesPendienteEntregar()
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

            tbllineasBindingSource.DataSource = db.tbl_lineas.OrderBy(d => d.descripcion).ToList();
            periodoENBindingSource.DataSource = (new PeriodoBL()).ListarTodos(dtF.AddMonths(-1).ToString("MM/yyyy", new System.Globalization.CultureInfo("es-gt")));

            ucPeriodo.Value = _periodo;
        }


        private bool Grabar()
        {
            if (!ValidataControles())
                return false;

            try
            {
                Cursor = Cursors.WaitCursor;
                string _periodo = ucPeriodo.Value.ToString();

                DataSet dsData = new DataSet();

                List<rpt_empleados_sin_captar_tiempo_Result> lst = db.rpt_empleados_sin_captar_tiempo(Helper.Oficina, _periodo, ucOficina.Value.ToString().Trim(), uckIncluir.Checked).ToList<rpt_empleados_sin_captar_tiempo_Result>();

                if (lst.Count == 0)
                {
                    MessageBox.Show("No existe Información para los Parámetros Seleccionados");
                    return false;
                }
                dsData = Helper.ToDataSet<rpt_empleados_sin_captar_tiempo_Result>(lst);
               
                dsData.Tables[0].TableName = "pwcia";

                frmViewReport frm = new frmViewReport();
                frm._parameters.Add("Periodo_tep", _periodo);
                frm._parameters.Add("Linea_servicio", ucOficina.Value.ToString().Trim());
                frm._parameters.Add("Id_oficina", Helper.Oficina);
                frm._parameters.Add("Incluye_administrativo", uckIncluir.Checked.ToString());

                frm._data = dsData;
                frm._reportName = "rpt_tiempo_no_cargado.rdlc";
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

        private void ucOficina_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;
            e.Row.Cells["desc"].Value = string.Format("{0}", e.Row.Cells["descripcion"].Value.ToString().Trim());
        }

        private void ucOficina_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }
    }
}
