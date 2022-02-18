using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiempoEnProceso
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        protected override void OnActivated(EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                c.GotFocus += c_GotFocus;
            }
            base.OnActivated(e);
        }

        void c_GotFocus(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        
    }
}
