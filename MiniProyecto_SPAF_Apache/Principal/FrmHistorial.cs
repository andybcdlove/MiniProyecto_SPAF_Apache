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

            var culturaActual = System.Globalization.CultureInfo.CurrentUICulture;

            if (culturaActual.TwoLetterISOLanguageName == "en")
            {
                cbIdioma.SelectedIndex = 1;
            }
            else
            {
                cbIdioma.SelectedIndex = 0;
            }
        }
        public int IndiceIdiomaSeleccionado
        {
            get { return cbIdioma.SelectedIndex; }
        }

        private void bCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cultura;

            if (cbIdioma.SelectedIndex == 0)
            {
                cultura = "es-MX";
            }
            else if (cbIdioma.SelectedIndex == 1)
            {
                cultura = "en-US";
            }
            else
            {
                return;
            }

            ComponentResourceManager resources =
                new ComponentResourceManager(typeof(FrmHistorial));

            var culturaSeleccionada = new System.Globalization.CultureInfo(cultura);

            AplicarTexto(this, "$this");
            TraducirControles(this);
            TraducirEncabezados(dataGridView1);
            TraducirEncabezados(dgvPaquetes);

            void AplicarTexto(Control control, string nombreRecurso)
            {
                string? texto = resources.GetString(
                    nombreRecurso + ".Text", culturaSeleccionada);

                if (texto != null)
                {
                    control.Text = texto;
                }
            }

            void TraducirControles(Control contenedor)
            {
                foreach (Control control in contenedor.Controls)
                {
                    AplicarTexto(control, control.Name);
                    TraducirControles(control);
                }
            }

            void TraducirEncabezados(DataGridView tabla)
            {
                foreach (DataGridViewColumn columna in tabla.Columns)
                {
                    string? encabezado = resources.GetString(
                        columna.Name + ".HeaderText", culturaSeleccionada);

                    if (encabezado != null)
                    {
                        columna.HeaderText = encabezado;
                    }
                }
            }
        }
    }
}
