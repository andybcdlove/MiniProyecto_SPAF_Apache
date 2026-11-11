using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MiniProyecto_SPAF_Apache.Principal
{
    public partial class FrmHistorial : Form
    {
        public FrmHistorial()
        {
            InitializeComponent();
            cbIdioma.SelectedIndex = 0;
        }

        private void bCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
