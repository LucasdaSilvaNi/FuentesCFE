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
    public partial class frmConcepto : Form
    {
        public tbl_concepto_no_cargable Item { get; set; }
        public Helper.Acciones AccionActual { get; set; }

        private TEPEntities db;
        public frmConceptos frmConceptos { get; set; }

        public frmConcepto()
        {
            InitializeComponent();
            db = new TEPEntities(Helper.CadenaConexion);
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

            string _id = uteIdBanco.Value.ToString();
            if (AccionActual == Helper.Acciones.Agregar)
            {
                if (db.tbl_concepto_no_cargable.Any(d => d.id_concepto == _id))
                {
                    MessageBox.Show("Concepto ya Existe", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else if (AccionActual == Helper.Acciones.Editar)
            {
            }


            return true;
        }

        private void LimpiaEspacios()
        {
            if (uteDescripcion.Value != null)
                uteDescripcion.Value = uteDescripcion.Value.ToString().Trim();

            if (uteIdBanco.Value != null)
                uteIdBanco.Value = uteIdBanco.Value.ToString().Trim();

        }

        public void CargarItem(string _concepto)
        {
            Item = db.tbl_concepto_no_cargable.FirstOrDefault(d => d.id_concepto == _concepto);

            CargaCombos();
            AsignaCampos();
        }

        private void AsignaCampos()
        {
            uteIdBanco.Value = Item.id_concepto;
            uteDescripcion.Value = Item.descripcion.Trim();
            uckSolicita.Checked = Item.solicita_descripcion == Helper.SI;
            uckInactiva.Checked = Item.inactivar == Helper.SI;
            uckDistribucion.Checked = Item.Distribucion_Proporcional_socios ?? false;
        }

        public void CargaCombos()
        {
        }


        private bool Grabar()
        {
            if (AccionActual == Helper.Acciones.Consultar)
                return true;

            if (!ValidataControles())
                return false;

            try
            {
                ConstruyeItem();

                if (AccionActual == Helper.Acciones.Agregar)
                    db.tbl_concepto_no_cargable.Add(Item);

                db.SaveChanges();

                frmConceptos.CargaGrid(false);
            }
            catch (Exception ex)
            {
                Helper.ShowError("Save", "Error al guardar", ex);
                return false;
            }

            return true;
        }

        private void ConstruyeItem()
        {

            if (AccionActual == Helper.Acciones.Agregar)
                Item.id_concepto = uteIdBanco.Value.ToString();

            Item.descripcion = uteDescripcion.Value.ToString();
            Item.Distribucion_Proporcional_socios = uckDistribucion.Checked;

            Item.solicita_descripcion = uckSolicita.Checked ? Helper.SI : 0M;
            Item.inactivar = uckInactiva.Checked ? Helper.SI : 0M;
        }

        private void EstableceHabilitacion()
        {
            switch (AccionActual)
            {
                case Helper.Acciones.Agregar:
                    break;
                case Helper.Acciones.Consultar:
                    SetEnableControls(false);
                    break;
                case Helper.Acciones.Editar:
                    uteIdBanco.Enabled = false;

                    break;
            }
        }

        private void NuevoItem()
        {
            Item = new tbl_concepto_no_cargable();
            uteIdBanco.Value = null;
            uteDescripcion.Value = null;
            uckSolicita.Checked = false;
            uckDistribucion.Checked = false;
            uckInactiva.Checked = false;
            uteIdBanco.Focus();

        }

        private void SetEnableControls(bool Enable)
        {
            Helper.GetControls<UltraTextEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);

        }
        #endregion

        private void frmRegion_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - {1}", AccionActual.ToString(), this.Text);
            Helper.SetUltraComboWidth(this);
            uvValidador.NotificationSettings.Caption = Helper.NombreAplicacion;
            EstableceHabilitacion();

            CargaCombos();

            if (AccionActual == Helper.Acciones.Agregar)
            {
                NuevoItem();
            }

            uteIdBanco.Focus();

        }



        private void ubAgregar_Click(object sender, EventArgs e)
        {
            if (Grabar())
            {
                Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Grabar", "Registro Grabado Satisfactoriamente");
                if (Helper.Continuo && AccionActual == Helper.Acciones.Agregar)
                    NuevoItem();
                else
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
        }

        private void ubCerrar_Click(object sender, EventArgs e)
        {
            if (Helper.Continuo)
                DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                DialogResult = System.Windows.Forms.DialogResult.Cancel;

            Close();
        }

        private void uteDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteDescripcion, true, true, true, true);
        }

        private void uteIdBanco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteIdBanco, true, true, true, true);
        }
        private void uckFacturar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uckSolicita, true, true, true, true);
        }

        private void uckFacturar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void uckInactiva_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uckInactiva, true, true, true, true);
        }


        
    }
}
