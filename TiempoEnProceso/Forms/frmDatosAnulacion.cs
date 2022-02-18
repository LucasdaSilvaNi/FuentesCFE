using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiempoEnProceso.Forms
{
    public partial class frmDatosAnulacion : Form
    {
        public string NoDocto { get; set; }
        public DateTime? FechaDocto { get; set; }
        public frmDatosAnulacion()
        {
            InitializeComponent();
        }

        private void frmDatosAnulacion_Load(object sender, EventArgs e)
        {
            uneDoctoAnula.Value = NoDocto;
            udtFechaAnula.Value = FechaDocto;
        }

        private void ubAgregar_Click(object sender, EventArgs e)
        {
            NoDocto = uneDoctoAnula.Value.ToString();
            FechaDocto = Convert.ToDateTime(udtFechaAnula.Value);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ubCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
