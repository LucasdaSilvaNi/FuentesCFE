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
    public partial class DialogProcess : Form
    {
        public DialogProcess()
        {
            InitializeComponent();
        }

        public DialogProcess(string _caption)
        {
            InitializeComponent();
            this.Text = _caption;
        }
    }
}
