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
    public partial class frmLinea : Form
    {
        public tbl_lineas Item { get; set; }
        public Helper.Acciones AccionActual { get; set; }

        private TEPEntities db;
        public frmLineas frmLineas { get; set; }

        public frmLinea()
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

            if (ucSocio.Value != null &&
                ucSocio.SelectedRow == null)
            {
                MessageBox.Show("Selección de Socio Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string _id = uteID.Value.ToString();

            if (AccionActual == Helper.Acciones.Agregar)
            {
                if (db.tbl_lineas.Any(d => d.id_grupos == _id))
                {
                    MessageBox.Show("Linea ya Existe", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (uteID.Value != null)
                uteID.Value = uteID.Value.ToString().Trim();

            if (uteDescripcion.Value != null)
                uteDescripcion.Value = uteDescripcion.Value.ToString().Trim();

            if (uteLineaGlobal.Value != null)
                uteLineaGlobal.Value = uteLineaGlobal.Value.ToString().Trim();
        }

        public void CargarItem(string _linea)
        {
            Item = db.tbl_lineas.FirstOrDefault(d => d.id_grupos == _linea );

            CargaCombos();
            AsignaCampos();
        }

        private void AsignaCampos()
        {
            uteID.Value = Item.id_grupos;
            uteDescripcion.Value = Item.descripcion;
            ucSocio.Value = Item.Socio_encargado.Trim();
            uteLineaGlobal.Value = Item.id_linea_pwcglobal;
        }

        public void CargaCombos()
        {
            empleadoENBindingSource.DataSource = (new EmpleadosBL()).ListarSocios();
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
                    db.tbl_lineas.Add(Item);

                db.SaveChanges();

                frmLineas.CargaGrid(false);
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
            {
                Item.id_grupos = uteID.Value.ToString();
                Item.id_oficina = Helper.Oficina;
            }

            Item.descripcion = string.Empty;
            if (uteDescripcion.Value != null)
                Item.descripcion = uteDescripcion.Value.ToString();

            Item.Socio_encargado = null;
            if (ucSocio.Value != null)
                Item.Socio_encargado = ucSocio.Value.ToString().Trim();

            Item.id_linea_pwcglobal = null;
            if (uteLineaGlobal.Value != null)
                Item.id_linea_pwcglobal = uteLineaGlobal.Value.ToString();
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
                    uteID.Enabled = false;
                    break;
            }
        }

        private void NuevoItem()
        {
            Item = new  tbl_lineas();
            uteID.Value = null;
            uteDescripcion.Value = null;
            ucSocio.Value = null;
            uteLineaGlobal.Value = null;
            uteID.Focus();

        }

        private void SetEnableControls(bool Enable)
        {
            Helper.GetControls<UltraTextEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraCombo>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);

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

            uteID.Focus();

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
                SelectNextControl(uteID, true, true, true, true);
        }

        private void ucPais_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucPais_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Cells["desc"].Value = string.Format("{0}", e.Row.Cells["nombrecompleto"].Value.ToString().Trim());
        }

        private void ucPeriodo_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void uteDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteDescripcion, true, true, true, true);
        }

        private void ucPais_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucSocio, true, true, true, true);
        }

        private void uckFacturar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void uteLineaGlobal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteLineaGlobal, true, true, true, true);
        }

        private void ucSocio_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }


        
    }
}
