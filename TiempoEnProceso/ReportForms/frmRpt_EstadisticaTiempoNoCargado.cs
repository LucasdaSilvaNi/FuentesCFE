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
    public partial class frmRpt_EstadisticaTiempoNoCargado : Form
    {
        private TEPEntities db= new TEPEntities(Helper.CadenaConexion);

        public frmRpt_EstadisticaTiempoNoCargado()
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
        }


        private bool Grabar()
        {
            if (!ValidataControles())
                return false; 

            try
            {
                Cursor = Cursors.WaitCursor;

                DataSet dsData = new DataSet();
                EmpleadosBL _em =new EmpleadosBL();
                EmpleadoEN _emp=  _em.DevuelveDatos(Helper.usuario);
                tbl_departamento _dept = (new DeptoBL()).ListarTodos().FirstOrDefault(d => d.id_departamento == _emp.id_departamento);
                List<rpt_tiempo_no_cargado_Result> lst = db.rpt_tiempo_no_cargado(Helper.Oficina, (Helper.OficinaActiva as tbl_oficina).periodo_proceso, Convert.ToInt32(_dept.id_grupos), _emp.id_departamento).ToList<rpt_tiempo_no_cargado_Result>();

                if (lst.Count == 0)
                {
                    MessageBox.Show("No existe Información para los Parámetros Seleccionados");
                    return false;
                }
                dsData = Helper.ToDataSet<rpt_tiempo_no_cargado_Result>(lst);

                dsData.Tables[0].TableName = "DS_Pwcia";

                frmViewReport frm = new frmViewReport();
                frm._parameters.Add("oficina", Helper.Oficina);
                frm._parameters.Add("año", (Helper.OficinaActiva as tbl_oficina).periodo_proceso);
                frm._parameters.Add("grupo", _dept.id_grupos);
                frm._parameters.Add("departamento", _dept.id_departamento);                

                frm._data = dsData;
                frm._reportName = "Tiempo_NO_Cargado_-_Acumulado.rdlc";
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
    }
}
