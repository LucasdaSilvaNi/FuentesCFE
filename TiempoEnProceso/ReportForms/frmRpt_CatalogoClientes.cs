﻿using System;
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
    public partial class frmRpt_CatalogoClientes : Form
    {
        private TEPEntities db= new TEPEntities(Helper.CadenaConexion);

        public frmRpt_CatalogoClientes()
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

            if (uceEstado.Value != null &&
                uceEstado.SelectedItem == null)
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
        }


        private bool Grabar()
        {
            if (!ValidataControles())
                return false;

            try
            {
                Cursor = Cursors.WaitCursor;
                decimal _estado = 99;
                if (uceEstado.Value != null)
                    _estado = Convert.ToDecimal(uceEstado.Value);


                List<rpt_catalogo_clientes_Result> lst = db.rpt_catalogo_clientes((Helper.OficinaActiva as tbl_oficina).id_pais, _estado).ToList<rpt_catalogo_clientes_Result>();

                if (lst.Count == 0)
                {
                    MessageBox.Show("No existe Información para los Parámetros Seleccionados");
                    return false;
                }

                DataSet dsData = Helper.ToDataSet<rpt_catalogo_clientes_Result>(lst);
                dsData.Tables[0].TableName = "pwcia";

                frmViewReport frm = new frmViewReport();
                frm._parameters.Add("Pais", (Helper.OficinaActiva as tbl_oficina).id_pais);
                frm._parameters.Add("estado", _estado.ToString());
                frm._data = dsData;
                frm._reportName = "catalogo_clientes.rdlc";
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
            uceEstado.Value = 99;
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
      
    }
}
