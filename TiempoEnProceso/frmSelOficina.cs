using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TiempoEnProcesoBL;
using TiempoEnProcesoDL;
using TiempoEnProcesoHelper;
using System.IO;

namespace TiempoEnProceso
{
    public partial class frmSelOficina : Form
    {
        private TEPEntities db = new TEPEntities(Helper.CadenaConexion);

        public frmSelOficina()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

            var query = from emp in db.tbl_empleados
                        join niv in db.tbl_niveles_empleado on emp.id_empleado equals niv.id_empleado
                        join ofi in db.tbl_oficina on niv.id_oficina equals  ofi.id_oficina
                        where emp.id_empleado == Helper.usuario
                        select ofi;

            ucDepto.DataSource = query.ToList<tbl_oficina>();

        }

        private void ubAceptar_Click(object sender, EventArgs e)
        {
            if (!ultraValidator1.Validate("required", false, true).IsValid)
                return;

            try
            {
                Cursor = Cursors.WaitCursor;

                Helper.Oficina = ucDepto.Value.ToString();
                Helper.OficinaActiva = (new OficinaBL()).DevuelveDatosOficina(Helper.Oficina);                

                if (Helper.OficinaActiva == null)
                {
                    DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    return;
                }
                Helper.Pais = (Helper.OficinaActiva as tbl_oficina).id_pais;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                Helper.ShowError("Seleccion", "Oficina", ex);
                //MessageBox.Show("Usuario/clave Invalida", Helper.NombreAplicacion,  MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }
        }


        private void ucDepto_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_oficina"].Value.ToString().Trim(), e.Row.Cells["Nombre"].Value.ToString().Trim());
        }

        private void ucDepto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucDepto, true, true, true, true);
        }
    }
}
