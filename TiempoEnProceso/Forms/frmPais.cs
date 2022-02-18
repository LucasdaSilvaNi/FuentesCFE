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
    public partial class frmPais : Form
    {
        public tbl_paises Item { get; set; }
        public Helper.Acciones AccionActual { get; set; }
        public frmPaises frmPaises { get; set; }

        private TEPEntities db;

        public frmPais()
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
                if (db.tbl_paises.Any(d => d.id_pais == _id))
                {
                    MessageBox.Show("Pais ya Existe", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (uteTerritorio.Value != null)
                uteTerritorio.Value = uteTerritorio.Value.ToString().Trim();
        }

        public void CargarItem(string _pais)
        {
            Item = db.tbl_paises.FirstOrDefault(d => d.id_pais == _pais);

            CargaCombos();
            AsignaCampos();
        }

        private void AsignaCampos()
        {
            uteIdBanco.Value = Item.id_pais;

            uteDescripcion.Value = Item.Nombre;
            uceMoneda.Value = Item.Moneda;
            uneTasa.Value = Item.Tasa_Cambio;
            uteTerritorio.Value = Item.id_territory;
            ucPeriodo.Value = Item.Periodo_Proceso;
            uneInicio.Value = Item.inicia_periodo;
            uneFinal.Value = Item.finaliza_periodo;
            uckInactiva.Checked = Item.Situacion == Helper.ACTIVO;
            uteCodigoPais.Value = Item.codigo_pais;
            utePartyId.Value = Item.paisSynId;
        }

        public void CargaCombos()
        {
            periodoBindingSource.DataSource = (new PeriodoBL()).Listar();
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
                    db.tbl_paises.Add(Item);

                db.SaveChanges();

                frmPaises.CargaGrid(false);
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
                Item.id_pais = uteIdBanco.Value.ToString();
            }

            Item.Nombre = uteDescripcion.Value.ToString();

            Item.id_territory = string.Empty;
            if (uteTerritorio.Value != null)
                Item.id_territory = uteTerritorio.Value.ToString();

            Item.Tasa_Cambio = 0;
            if (uneTasa.Value != null)
                Item.Tasa_Cambio = Convert.ToDecimal(uneTasa.Value);

            Item.Periodo_Proceso = string.Empty;
            if (ucPeriodo.Value != null)
                Item.Periodo_Proceso = ucPeriodo.Value.ToString();

            Item.Moneda = string.Empty;
            if (uceMoneda.Value != null)
                Item.Moneda = uceMoneda.Value.ToString();

            Item.codigo_pais = string.Empty;
            if (uteCodigoPais.Value != null)
                Item.codigo_pais = uteCodigoPais.Value.ToString();

            Item.paisSynId = string.Empty;
            if (utePartyId.Value != null)
                Item.paisSynId = utePartyId.Value.ToString();

            Item.inicia_periodo = Convert.ToInt32(uneInicio.Value);
            Item.finaliza_periodo = Convert.ToInt32(uneFinal.Value);
            Item.Situacion = uckInactiva.Checked ? Helper.ACTIVO : string.Empty;
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
                    ucPeriodo.Enabled = false;
                    break;
            }
        }

        private void NuevoItem()
        {
            Item = new tbl_paises();
            uteIdBanco.Value = null;
            uteDescripcion.Value = null;
            uteTerritorio.Value = null;
            uceMoneda.Value = null;
            ucPeriodo.Value = null;
            uneInicio.Value = 21;
            uneFinal.Value = 20;
            uneTasa.Value = 1;
            uckInactiva.Checked = true;
            uteIdBanco.Focus();

        }

        private void SetEnableControls(bool Enable)
        {
            Helper.GetControls<UltraTextEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraCombo>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraNumericEditor>(ultraPanel4).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraCheckEditor>(ultraPanel4).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraComboEditor>(ultraPanel4).ForEach(p => p.Enabled = Enable);

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

        private void uceMoneda_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucPeriodo_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void uneTasa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneTasa, true, true, true, true);
        }

        private void uceMoneda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uceMoneda, true, true, true, true);
        }

        private void uteTerritorio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteTerritorio, true, true, true, true);
        }

        private void ucPeriodo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucPeriodo, true, true, true, true);
        }

        private void uneInicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneInicio, true, true, true, true);
        }

        private void uneFinal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneFinal, true, true, true, true);
        }

        private void uckInactiva_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ubAgregar.Focus();
        }

        private void uteCodigoPais_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteCodigoPais, true, true, true, true);
        }

        private void utePartyId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(utePartyId, true, true, true,
                    true);
        }
    }
}
