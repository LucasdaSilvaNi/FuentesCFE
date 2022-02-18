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
    public partial class frmIndustria : Form
    {
        public tbl_industrias Item { get; set; }
        public Helper.Acciones AccionActual { get; set; }

        private TEPEntities db;
        public frmIndustrias frmIndustrias { get; set; }

        public frmIndustria()
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

            decimal _id = Convert.ToDecimal(uneID.Value);
            if (AccionActual == Helper.Acciones.Agregar)
            {
                if (db.tbl_industrias.Any(d => d.id_industria == _id))
                {
                    MessageBox.Show("Industria ya Existe", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        public void CargarItem(decimal _industria)
        {
            Item = db.tbl_industrias.FirstOrDefault(d => d.id_industria == _industria);

            CargaCombos();
            AsignaCampos();
        }

        private void AsignaCampos()
        {
            uneID.Value = Item.id_industria;
            uteDescripcion.Value = Item.nombre.Trim();
            uteGlobal.Value = Item.id_industria_pwcglobal;
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
                    db.tbl_industrias.Add(Item);

                db.SaveChanges();

                frmIndustrias.CargaGrid(false);
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
                Item.id_industria = Convert.ToDecimal(uneID.Value);

            Item.nombre = uteDescripcion.Value.ToString();
            Item.id_industria_pwcglobal = string.Empty;
            if (uteGlobal.Value != null)
                Item.id_industria_pwcglobal = uteGlobal.Value.ToString();

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
                    uneID.Enabled = false;

                    break;
            }
        }

        private void NuevoItem()
        {
            Item = new tbl_industrias();
            uneID.Value = null;
            uteDescripcion.Value = null;
            uneID.Focus();

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

            uneID.Focus();

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

        private void uneID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneID, true, true, true, true);
        }

        private void uteGlobal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteGlobal, true, true, true, true);
        }
       
    }
}
