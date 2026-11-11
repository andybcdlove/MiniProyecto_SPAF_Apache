using MiniProyecto_SPAF_Apache.Principal;

namespace MiniProyecto_SPAF_Apache
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            cbIdioma.SelectedIndex = 0;
        }

        private void bHistorial_Click(object sender, EventArgs e)
        {
            FrmHistorial historial = new FrmHistorial();
            historial.ShowDialog();
        }
    }
}
