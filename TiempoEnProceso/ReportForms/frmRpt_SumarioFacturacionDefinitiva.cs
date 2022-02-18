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
    public partial class frmRpt_SumarioFacturacionDefinitiva : Form
    {
        private TEPEntities db= new TEPEntities(Helper.CadenaConexion);

        public frmRpt_SumarioFacturacionDefinitiva()
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
                MessageBox.Show("Selección de Oficina Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string _periodo = (Helper.OficinaActiva as tbl_oficina).periodo_proceso;
            string[] periodo = _periodo.Split('/');            
            DateTime dtF = new DateTime(Convert.ToInt32(periodo[1]), Convert.ToInt32(periodo[0]), 1);

            tbloficinaBindingSource.DataSource = (new OficinaBL()).ListarTodosS();
            //periodoBindingSource.DataSource = (new PeriodoBL()).ListarTodos(dtF.AddMonths(-1).ToString("MM/yyyy", new System.Globalization.CultureInfo("es-gt")));

            ucOficina.Value = Helper.Oficina;
            utePeriodo.Value = _periodo;
        }


        private bool Grabar()
        {
            if (!ValidataControles())
                return false;

            try
            {
                Cursor = Cursors.WaitCursor;

                DataSet dsData;

                string _oficina = ucOficina.Value.ToString();
                string _periodo = utePeriodo.Value.ToString();
                string _pais = (ucOficina.SelectedRow.ListObject as tbl_oficina).id_pais;

                Cursor = Cursors.WaitCursor;

                List<rpt_sumario_facturacion_Result> lst = db.rpt_sumario_facturacion(_pais, _oficina, _periodo, uceAgrupamiento.Value.ToString().Substring(0, 1), "S", "S", Constantes.S_TODOS, Constantes.S_TODOS).ToList();
                if (lst.Count == 0)
                {
                    MessageBox.Show("No existe Información para los Parámetros Seleccionados");
                    return false;
                }

                dsData = Helper.ToDataSet<rpt_sumario_facturacion_Result>(lst);
                dsData.Tables[0].TableName = "pwcia";

                dsData.Tables.Add(Helper.ToDataSet<rpt_sumario_facturacion_Result>(lst).Tables[0].Copy());
                dsData.Tables[1].TableName = "pwcia_repetido";

                frmViewReport frm = new frmViewReport();
                frm._parameters.Add("Pais", _pais);
                frm._parameters.Add("Oficina", _oficina);
                frm._parameters.Add("Periodo", _periodo);
                frm._parameters.Add("Tipo_Reporte", uceAgrupamiento.Value.ToString().Substring(0, 1));
                frm._parameters.Add("Salta_Socio", "S");
                frm._parameters.Add("Salta_Encargado", "S");
                frm._parameters.Add("Id_socio", Constantes.S_TODOS);
                frm._parameters.Add("Id_encargado", Constantes.S_TODOS);                

                frm._data = dsData;
                frm._reportName = "sumario_facturacion.rdlc";
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
            uceAgrupamiento.Value = "Socio/Gerente";
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

        private void ucPais_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucOficina, true, true, true, true);
        }

        private void uckFacturar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ucPeriodo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(utePeriodo, true, true, true, true);
        }

        private void ucPeriodo_ItemNotInList_1(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }


        
    }
}
