using MiniProyecto_SPAF_Apache.Principal;

namespace MiniProyecto_SPAF_Apache
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal() : this(new Servicios.Persistencia.RepositorioEnvios())
        {
        }

        public FrmPrincipal(Servicios.Persistencia.RepositorioEnvios repositorio)
        {
            _repositorio = repositorio;
            InitializeComponent();
            cbIdioma.SelectedIndex = 0;
            ConectarPersistencia();
        }

        private void bHistorial_Click(object sender, EventArgs e)
        {
            using FrmHistorial historial = new FrmHistorial(_repositorio);
            historial.ShowDialog(this);
        }
    }
}
