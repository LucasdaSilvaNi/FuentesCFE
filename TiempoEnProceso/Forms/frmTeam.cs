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
    public partial class frmTeam : Form
    {
        public tbl_teams Item { get; set; }
        public Helper.Acciones AccionActual { get; set; }

        private TEPEntities db;
        public frmTeams frmTeams { get; set; }

        public frmTeam()
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

            if (ucDepto.Value != null &&
                ucDepto.SelectedRow == null)
            {
                MessageBox.Show("Selección de Lider Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            string _id = uteIdBanco.Value.ToString();
            if (AccionActual == Helper.Acciones.Agregar)
            {
                if (db.tbl_teams.Any(d => d.id_team == _id))
                {
                    MessageBox.Show("Team ya Existe", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void CargarItem(string _team)
        {
            Item = db.tbl_teams.FirstOrDefault(d => d.id_team == _team && d.id_oficina == Helper.Oficina);

            CargaCombos();
            AsignaCampos();
        }

        private void AsignaCampos()
        {
            uteOficina.Value = string.Format("{0}-{1}", Helper.Oficina, (Helper.OficinaActiva as tbl_oficina).Nombre);

            uteIdBanco.Value = Item.id_team;
            uteDescripcion.Value = Item.nombre.Trim();
            ucDepto.Value = Item.Lider.PadRight(10, ' ');

        }

        public void CargaCombos()
        {
            empleadoENBindingSource.DataSource = (new EmpleadosBL(ref db)).ListarTodos(Helper.Oficina);
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
                    db.tbl_teams.Add(Item);

                db.SaveChanges();

                frmTeams.CargaGrid(false);
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
                Item.id_team = uteIdBanco.Value.ToString();
                Item.id_oficina = Helper.Oficina;
                Item.id_pais = (Helper.OficinaActiva as tbl_oficina).id_pais;
            }

            Item.nombre = uteDescripcion.Value.ToString();

            Item.Lider = string.Empty;
            if (ucDepto.Value != null)
                Item.Lider = ucDepto.Value.ToString().Trim();
            
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
            Item = new tbl_teams();
            uteIdBanco.Value = null;
            uteDescripcion.Value = null;
            ucDepto.Value = null;
            uteIdBanco.Focus();

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
                uteOficina.Value = string.Format("{0}-{1}", Helper.Oficina, (Helper.OficinaActiva as tbl_oficina).Nombre);
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

        private void ucDepto_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucDepto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucDepto, true, true, true, true);
        }
    }
}
