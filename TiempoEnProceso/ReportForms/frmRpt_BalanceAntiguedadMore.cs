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
    public partial class frmRpt_BalanceAntiguedadMore : Form
    {
        private TEPEntities db= new TEPEntities(Helper.CadenaConexion);

        public frmRpt_BalanceAntiguedadMore()
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

                DataSet dsData;
                string _oficina = Helper.Oficina;
                string tipo = uceAgrupamiento.Value.ToString();
                
                List<rpt_balance_antiguedad_saldo_rangos_Result> lst = db.rpt_balance_antiguedad_saldo_rangos(_oficina, Convert.ToDateTime(udteFecha.Value), ute30.Value.ToString(),ute60.Value.ToString(), ute90.Value.ToString(), ute120.Value.ToString(), ute180.Value.ToString(), ute250.Value.ToString(), ute250Mas.Value.ToString(), tipo ).ToList();

                if (lst.Count == 0)
                {
                    MessageBox.Show("No existe Información para los Parámetros Seleccionados");
                    return false;
                }


                dsData = Helper.ToDataSet<rpt_balance_antiguedad_saldo_rangos_Result>(lst);
                dsData.Tables[0].TableName = "pwcia";
                
                frmViewReport frm = new frmViewReport();
                frm._parameters.Add("Oficina", _oficina);
                frm._parameters.Add("Fecha", Convert.ToDateTime(udteFecha.Value).ToString("dd/MM/yyyy"));
                frm._parameters.Add("Rango1", ute30.Value.ToString());
                frm._parameters.Add("Rango2", ute60.Value.ToString());
                frm._parameters.Add("Rango3", ute90.Value.ToString());
                frm._parameters.Add("Rango4", ute120.Value.ToString());
                frm._parameters.Add("Rango5", ute180.Value.ToString());
                frm._parameters.Add("Rango6", ute250.Value.ToString());
                frm._parameters.Add("Rango7", ute250Mas.Value.ToString());
                frm._parameters.Add("tipo_factura", uceAgrupamiento.Value.ToString());

                frm._data = dsData;
                frm._reportName = "rpt_balance_antiguedad_saldos_rangosmore.rdlc";
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

            udteFecha.Value = DateTime.Now.Date;
            uceAgrupamiento.Value = "DEFINITIVA";
            CargaCombos();
            ute30.Focus();

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

     
        private void ucOficce_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;
            string _oficina = e.Row.Cells["id_oficina"].Value.ToString().Trim();
            tbl_oficina _tbl = db.tbl_oficina.FirstOrDefault(d => d.id_oficina == _oficina);

            if (_tbl != null)
                e.Row.Cells["desc"].Value = string.Format("{0}-{1}", _tbl.id_oficina, _tbl.Nombre.Trim());
        }

        private void ute30_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ute30, true, true, true, true);
        }

        private void ute60_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ute60, true, true, true, true);
        }

        private void ute90_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ute90, true, true, true, true);
        }

        private void ute120_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ute120, true, true, true, true);
        }

        private void ute180_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ute180, true, true, true, true);
        }

        private void ute250_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ute250, true, true, true, true);
        }

        private void ute250Mas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ute250Mas,true, true, true, true);
        }

    }
}
