using MiniProyecto_SPAF_Apache.Principal;
using System.Threading;
using System.Globalization;
using System.ComponentModel;

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
            using FrmHistorial historial = new FrmHistorial();
            historial.ShowDialog();
            cbIdioma.SelectedIndex = historial.IndiceIdiomaSeleccionado;
        }

        private void CambiarIdioma(string cultura)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultura);
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmPrincipal));

            AplicarIdiomaAControles(this);
            resources.ApplyResources(this, "$this");
            TraducirEncabezados(dgvPaquetes);
            TraducirEncabezados(dgvErrores);

            void AplicarIdiomaAControles(Control contenedor)
            {
                foreach (Control control in contenedor.Controls)
                {
                    if (control != tLote)
                    {
                        resources.ApplyResources(control, control.Name);
                    }

                    AplicarIdiomaAControles(control);
                }
            }

            void TraducirEncabezados(DataGridView tabla)
            {
                foreach (DataGridViewColumn columna in tabla.Columns)
                {
                    string? encabezado = resources.GetString(columna.Name + ".HeaderText");

                    if (encabezado != null)
                    {
                        columna.HeaderText = encabezado;
                    }
                }
            }
        }

        private void dgvPaquetes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIdioma.SelectedIndex == 0) 
            {
                CambiarIdioma("es-MX");
            }
            else if (cbIdioma.SelectedIndex == 1) 
            {
                CambiarIdioma("en-US");
            }
        }
    }
}
