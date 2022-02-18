using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TiempoEnProcesoBL;
using TiempoEnProcesoHelper;
using TiempoEnProcesoDL;

namespace TiempoEnProceso
{
    public partial class frmCambiaClave : Form
    {
        public bool mandatorio { get; set; }

        public frmCambiaClave()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            uteUsuario.Value = Helper.usuario;
            uteClave.Value = Helper.claveUsuario;

            if (mandatorio)
            {
                ubCancel.Enabled = false;
            }
        }

        private void ubAceptar_Click(object sender, EventArgs e)
        {
            if (!ultraValidator1.Validate("required", false, true).IsValid)
                return;

            if (uteClave.Value.ToString().Trim() == uteClaveNueva.Value.ToString().Trim())
            {
                MessageBox.Show("Clave actual y Nueva no pueden ser iguales", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (uteClaveNueva.Value.ToString().Trim() != uteClaveConf.Value.ToString().Trim())
            {
                MessageBox.Show("Confirmación de clave Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!Helper.IsValidPassword(uteClaveNueva.Value.ToString().Trim(), Helper.usuario))
            {
                MessageBox.Show("Clave no cumple con reglas definidas de Complejidad", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                EmpleadosBL _empBL = new EmpleadosBL();

                string sClave = Helper.Encriptar(uteClaveNueva.Value.ToString());
                if (!_empBL.ValidaClaveHistorica(sClave, Helper.usuario))
                {
                    MessageBox.Show("Clave no cumple con reglas definidas de uso Historico", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            
                Cursor = Cursors.WaitCursor;

                _empBL.CambiaClave(Helper.usuario, sClave);

                Helper.claveUsuario = uteClaveNueva.Value.ToString().Trim();

                Cursor = Cursors.Default;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                Helper.ShowError("CambiaClave", Helper.NombreAplicacion, ex);
                Cursor = Cursors.Default;
            }
        }

        private void uteUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteClave.Focus();
        }

        private void uteClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ubAceptar.Focus();
        }

        private void uteClaveNueva_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteClaveNueva, true, true, true, true);
        }

        private void uteClaveConf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteClaveConf, true, true, true, true);
        }

        private void ubCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
               
    }
}
