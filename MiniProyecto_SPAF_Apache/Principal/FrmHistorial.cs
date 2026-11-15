using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Data.Sqlite;
using MiniProyecto_SPAF_Apache.Dominio;
using MiniProyecto_SPAF_Apache.Servicios.Persistencia;
using System.Globalization;

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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarLotesGuardados();
        }

        private void CargarLotesGuardados()
        {
            try
            {
                var repositorio = new RepositorioEnvios();
                Lote[] lotes = repositorio.ObtenerLotes();

                dataGridView1.Rows.Clear();

                foreach (Lote lote in lotes)
                {
                    int indiceFila = dataGridView1.Rows.Add(
                        lote.Id,
                        lote.FechaProcesamiento,
                        lote.CantidadValidos,
                        lote.Total);

                    dataGridView1.Rows[indiceFila].Tag = lote;
                }

                MostrarPaquetesDelLoteSeleccionado();
            }
            catch (Exception error) when (
                error is SqliteException or IOException or UnauthorizedAccessException)
            {
                bool ingles = cbIdioma.SelectedIndex == 1;
                string mensaje = ingles
                    ? "The saved batches could not be loaded."
                    : "No se pudieron cargar los lotes guardados.";

                MessageBox.Show(this, mensaje + Environment.NewLine + error.Message,
                    ingles ? "History error" : "Error de historial",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MostrarPaquetesDelLoteSeleccionado()
        {
            dgvPaquetes.Rows.Clear();

            if (dataGridView1.SelectedRows.Count == 0 ||
                dataGridView1.SelectedRows[0].Tag is not Lote lote)
            {
                return;
            }

            foreach (Paquete paquete in lote.Paquetes)
            {
                int indiceFila = dgvPaquetes.Rows.Add(
                    paquete.Codigo,
                    paquete.Cliente,
                    paquete.Zona,
                    paquete.Peso,
                    paquete.ValorDeclarado,
                    paquete.Total);

                dgvPaquetes.Rows[indiceFila].Tag = paquete;
            }

            MostrarDetallePaquete();
        }
        private void MostrarDetallePaquete()
        {
            Paquete? paquete = dgvPaquetes.SelectedRows.Count > 0
                ? dgvPaquetes.SelectedRows[0].Tag as Paquete
                : null;

            CultureInfo cultura = CultureInfo.GetCultureInfo(
                cbIdioma.SelectedIndex == 1 ? "en-US" : "es-MX");
            var recursos = new ComponentResourceManager(typeof(FrmHistorial));

            ActualizarEtiqueta(lCodigo, paquete?.Codigo);
            ActualizarEtiqueta(lCliente, paquete?.Cliente);
            ActualizarEtiqueta(lZona, paquete?.Zona);
            ActualizarEtiqueta(lPeso, paquete?.Peso.ToString("0.##", cultura));
            ActualizarEtiqueta(lValorDeclarado, paquete?.ValorDeclarado.ToString("C2", cultura));
            ActualizarEtiqueta(lSubtotalPeso, paquete?.SubtotalPeso.ToString("C2", cultura));
            ActualizarEtiqueta(lRecargoZona, paquete?.RecargoZona.ToString("C2", cultura));
            ActualizarEtiqueta(lPenalizacion, paquete?.PenalizacionPeso.ToString("C2", cultura));
            ActualizarEtiqueta(lSeguro, paquete?.Seguro.ToString("C2", cultura));
            ActualizarEtiqueta(lCostoFijo, paquete?.CostoFijo.ToString("C2", cultura));
            ActualizarEtiqueta(lIva, paquete?.Iva.ToString("C2", cultura));
            ActualizarEtiqueta(lTotalPaquete, paquete?.Total.ToString("C2", cultura));

            void ActualizarEtiqueta(Label etiqueta, string? valor)
            {
                string? plantilla = recursos.GetString(etiqueta.Name + ".Text", cultura);

                if (plantilla != null)
                {
                    etiqueta.AutoSize = false;
                    etiqueta.Width = gbDetalle.ClientSize.Width - etiqueta.Left - 16;
                    etiqueta.Text = plantilla.Replace("—", valor ?? "—");
                }
            }
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
            MostrarDetallePaquete();

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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            MostrarPaquetesDelLoteSeleccionado();
        }

        private void dgvPaquetes_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDetallePaquete();
        }

        private void bActualizar_Click(object sender, EventArgs e)
        {
            CargarLotesGuardados();
        }
    }
}
