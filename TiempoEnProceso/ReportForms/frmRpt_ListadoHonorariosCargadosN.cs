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
    public partial class frmRpt_ListadoHonorariosCargadosN : Form
    {
        private TEPEntities db= new TEPEntities(Helper.CadenaConexion);

        public frmRpt_ListadoHonorariosCargadosN()
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

            tbloficinaBindingSource.DataSource = (new OficinaBL()).ListarTodosS();
            utePeriodo.Value = _periodo;
        }


        private bool Grabar()
        {
            if (!ValidataControles())
                return false;

            try
            {
                Cursor = Cursors.WaitCursor;
                string _periodo = utePeriodo.Value.ToString();

                List<rpt_listado_honorarios_cargados_Result> lst = db.rpt_listado_honorarios_cargados(Helper.Pais, _periodo).ToList();

                if (lst.Count == 0)
                {
                    MessageBox.Show("No existe Información para los Parámetros Seleccionados");
                    return false;
                }

                DataSet dsData = Helper.ToDataSet<rpt_listado_honorarios_cargados_Result>(lst);
                dsData.Tables[0].TableName = "pwcia";

                frmViewReport frm = new frmViewReport();
                frm._parameters.Add("Id_Pais", Helper.Pais);
                frm._parameters.Add("Periodo_TEP", _periodo);
                frm._data = dsData;
                frm._reportName = "Listado_Honorarios_Cargados_en_periodo_tep.rdlc";
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

            tbl_oficina _tbl = e.Row.ListObject as tbl_oficina;

            if (_tbl != null)
                e.Row.Cells["desc"].Value = string.Format("{0}-{1}", _tbl.id_oficina, _tbl.Nombre.Trim());
        }

        private void utePeriodo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(utePeriodo, true, true, true, true);
        }
      
    }
}
