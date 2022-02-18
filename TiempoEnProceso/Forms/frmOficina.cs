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
    public partial class frmOficina : Form
    {
        public tbl_oficina Item { get; set; }
        public Helper.Acciones AccionActual { get; set; }

        private TEPEntities db;
        public frmOficinas frmOficinas { get; set; }

        public frmOficina()
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

            if (ucPais.Value != null &&
                ucPais.SelectedRow == null)
            {
                MessageBox.Show("Selección de País Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            /*if (ucPeriodo.Value != null &&
                ucPeriodo.SelectedItem == null)
            {
                MessageBox.Show("Selección de Periodo Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }*/

            if (uteCodigoFiscal.Value != null)
            {
                if (uteIdBanco.Value.ToString() == Helper.CR)
                {
                    decimal dVal = 0;
                    if (!decimal.TryParse(uteCodigoFiscal.Value.ToString(), out dVal))
                    {
                        MessageBox.Show("Código Fiscal Invalido", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
            }


            string _id = uteIdBanco.Value.ToString();
            if (AccionActual == Helper.Acciones.Agregar)
            {
                if (db.tbl_oficina.Any(d => d.id_oficina==_id))
                {
                    MessageBox.Show("Oficina ya Existe", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (uteDireccion.Value != null)
                uteDireccion.Value = uteDireccion.Value.ToString().Trim();
        }

        public void CargarItem(string _oficina)
        {
            Item = db.tbl_oficina.FirstOrDefault(d => d.id_oficina == _oficina);

            CargaCombos();
            AsignaCampos();
        }

        private void AsignaCampos()
        {
            uteIdBanco.Value = Item.id_oficina;
            uteDescripcion.Value = Item.Nombre;
            uteDireccion.Value = Item.direccion;
            ucPais.Value = Item.id_pais;
            ucPeriodo.Value = Item.periodo_proceso;
            uckCaptar.Checked = Item.Status == Helper.SI;
            uckFacturar.Checked = Item.permite_facturar_en_periodo == Helper.SI;
            uneFax.Value = Item.Numero_Fax;
            uneTelefono.Value = Item.Numero_Telefono;
            uteCorreo.Value = Item.correo_electronico;
            uteCodigoFiscal.Value = Item.codigo_fiscal;
        }

        public void CargaCombos()
        {
            periodoBindingSource.DataSource = (new PeriodoBL()).Listar();
            tblpaisesBindingSource.DataSource = (new PaisBL(ref db)).Listar();
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
                    db.tbl_oficina.Add(Item);

                db.SaveChanges();

                frmOficinas.CargaGrid(false);
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
                Item.id_oficina = uteIdBanco.Value.ToString();
                Item.Status = Helper.SI;
            }

            Item.Nombre = uteDescripcion.Value.ToString();

            Item.direccion = string.Empty;
            if (uteDireccion.Value != null)
                Item.direccion = uteDireccion.Value.ToString();

            Item.id_pais = ucPais.Value.ToString();

            Item.periodo_proceso = string.Empty;
            if (ucPeriodo.Value != null)
                Item.periodo_proceso = ucPeriodo.Value.ToString();

            Item.permite_facturar_en_periodo = uckFacturar.Checked ? Helper.SI : Helper.NO;
            Item.Status = uckCaptar.Checked ? Helper.SI : Helper.NO;

            Item.correo_electronico = string.Empty;
            if (uteCorreo.Value != null)
                Item.correo_electronico = uteCorreo.Value.ToString();

            Item.Numero_Telefono = 0;
            if (uneTelefono.Value != null)
                Item.Numero_Telefono = Convert.ToDecimal(uneTelefono.Value);

            Item.Numero_Fax = 0;
            if (uneFax.Value != null)
                Item.Numero_Fax = Convert.ToDecimal(uneFax.Value);

            Item.codigo_fiscal = string.Empty;
            if (uteCodigoFiscal.Value != null)
                Item.codigo_fiscal = uteCodigoFiscal.Value.ToString();
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
            Item = new  tbl_oficina();
            uteIdBanco.Value = null;
            uteDescripcion.Value = null;
            uteDireccion.Value = null;
            ucPais.Value = null;
            ucPeriodo.Value = null;
            uckFacturar.Checked = false;
            uckCaptar.Checked = false;

            uteIdBanco.Focus();

        }

        private void SetEnableControls(bool Enable)
        {
            Helper.GetControls<UltraTextEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraCombo>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraComboEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraCheckEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
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

        private void ucPais_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucPais_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["pais"].Value = string.Format("{0}-{1}", e.Row.Cells["id_pais"].Value.ToString().Trim(), e.Row.Cells["nombre"].Value.ToString().Trim());
        }

        private void ucPeriodo_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void uteDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteDireccion, true, true, true, true);
        }

        private void ucPais_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucPais, true, true, true, true);
        }

        private void ucPeriodo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucPeriodo, true, true, true, true);
        }

        private void uckCaptar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uckCaptar, true, true, true, true);
        }

        private void uckFacturar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uckFacturar, true, true, true, true);
        }

        private void uckFacturar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ultraPanel4_PaintClient(object sender, PaintEventArgs e)
        {

        }

        private void uneTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneTelefono, true, true, true, true);
        }

        private void uneFax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneFax, true, true, true, true);
        }

        private void uteCorreo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteCorreo, true, true, true, true);
        }

        private void uteCodigoFiscal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteCodigoFiscal, true, true, true, true);
        }


        
    }
}
