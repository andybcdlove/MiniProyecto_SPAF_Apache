using MiniProyecto_SPAF_Apache.Principal;
using System.Threading;
using System.Globalization;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using MiniProyecto_SPAF_Apache.Servicios.Logica;
using MiniProyecto_SPAF_Apache.Dominio;
using Microsoft.Data.Sqlite;
using MiniProyecto_SPAF_Apache.Servicios.Persistencia;

namespace MiniProyecto_SPAF_Apache
{
    public partial class FrmPrincipal : Form
    {
        private ServicioEnvios? _servicioEnvios;
        private Dictionary<string, string> _erroresEnIngles = new();

        public FrmPrincipal() : this(new RepositorioEnvios())
        {
        }

        public FrmPrincipal(RepositorioEnvios repositorio)
        {
            _repositorio = repositorio;
            InitializeComponent();
            cbIdioma.SelectedIndex = 0;
            ConectarPersistencia();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            bProcesar.Enabled = false;
            CargarTraduccionesDeErrores();

            try
            {
                _servicioEnvios = new ServicioEnvios();
                bProcesar.Enabled = true;
            }
            catch (Exception error) when (
                error is IOException
                    or UnauthorizedAccessException
                    or InvalidDataException
                    or JsonException)
            {
                MessageBox.Show(
                    this,
                    "No se pudieron cargar las tarifas." + Environment.NewLine + error.Message,
                    "Error de configuración",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void bHistorial_Click(object sender, EventArgs e)
        {
            using FrmHistorial historial = new FrmHistorial(_repositorio);
            NavegacionFormularios.Abrir(this, historial);
            if (!NavegacionFormularios.Saliendo && !IsDisposed)
                cbIdioma.SelectedIndex = historial.IndiceIdiomaSeleccionado;
        }

        private void CambiarIdioma(string cultura)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultura);
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmPrincipal));

            AplicarIdiomaAControles(this);
            AplicarTexto(this, "$this");
            TraducirEncabezados(dgvPaquetes);
            TraducirEncabezados(dgvErrores);

            void AplicarIdiomaAControles(Control contenedor)
            {
                foreach (Control control in contenedor.Controls)
                {
                    if (control != tLote)
                    {
                        AplicarTexto(control, control.Name);
                    }

                    AplicarIdiomaAControles(control);
                }
            }

            //cambia el texto sin mover los controles
            void AplicarTexto(Control control, string nombre)
            {
                string? texto = resources.GetString(nombre + ".Text");
                if (texto != null)
                {
                    control.Text = texto;
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
            else
            {
                return;
            }

            MostrarResumenLote();
            MostrarDetallePaquete();
            MostrarErroresDelLote();
        }
        private void MostrarDetallePaquete()
        {
            Paquete? paquete = dgvPaquetes.SelectedRows.Count > 0
                ? dgvPaquetes.SelectedRows[0].Tag as Paquete
                : null;

            var recursos = new ComponentResourceManager(typeof(FrmPrincipal));
            CultureInfo cultura = CultureInfo.CurrentUICulture;

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
        private void MostrarResumenLote()
        {
            int validos = _loteActual?.CantidadValidos ?? 0;
            int invalidos = _loteActual?.CantidadInvalidos ?? 0;
            decimal total = _loteActual?.Total ?? 0m;

            CultureInfo cultura = CultureInfo.CurrentUICulture;
            string importe = total.ToString("C2", cultura);

            if (cultura.TwoLetterISOLanguageName == "en")
            {
                lValidos.Text = $"Valid Packages: {validos}";
                lInvalidos.Text = $"Invalid Packages: {invalidos}";
                lTotalLote.Text = $"Batch Total: {importe}";
            }
            else
            {
                lValidos.Text = $"Paquetes válidos: {validos}";
                lInvalidos.Text = $"Paquetes inválidos: {invalidos}";
                lTotalLote.Text = $"Total del lote: {importe}";
            }

            bGuardar.Enabled = _loteActual is { CantidadValidos: > 0, Id: null };
            bExportar.Enabled = _loteActual is { CantidadValidos: > 0 };
        }
        private void CargarTraduccionesDeErrores()
        {
            string ruta = Path.Combine(
                AppContext.BaseDirectory, "Recursos", "EtiquetasErrores.json");

            try
            {
                using var documento = JsonDocument.Parse(File.ReadAllText(ruta));

                foreach (JsonElement pantalla in documento.RootElement
                             .GetProperty("pantallas").EnumerateArray())
                {
                    if (pantalla.GetProperty("Idioma").GetString() == "English")
                    {
                        _erroresEnIngles =
                            pantalla.GetProperty("Errores")
                                .Deserialize<Dictionary<string, string>>() ?? new();

                        break;
                    }
                }
            }
            catch (Exception error) when (
                error is IOException or UnauthorizedAccessException or JsonException
                    or KeyNotFoundException or InvalidOperationException)
            {
                _erroresEnIngles.Clear();
            }
        }
        private void MostrarErroresDelLote()
        {
            dgvErrores.Rows.Clear();

            if (_loteActual == null)
            {
                return;
            }

            bool ingles = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "en";

            foreach (ErrorValidacion error in _loteActual.Errores)
            {
                string motivo = error.Motivo;

                if (ingles && _erroresEnIngles.TryGetValue(
                        error.Codigo.ToString(), out string? traduccion))
                {
                    motivo = traduccion;
                }

                dgvErrores.Rows.Add(error.NumeroLinea, error.TextoOriginal, motivo);
            }
        }
        private void bProcesar_Click(object sender, EventArgs e)
        {
            if (_servicioEnvios == null)
            {
                return;
            }

            _loteActual = _servicioEnvios.ProcesarLote(tLote.Text);

            dgvPaquetes.Rows.Clear();

            foreach (Paquete paquete in _loteActual.Paquetes)
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

            MostrarErroresDelLote();
            MostrarResumenLote();
            MostrarDetallePaquete();

        }

        private void bLimpiar_Click(object sender, EventArgs e)
        {
            _loteActual = null;
            tLote.Clear();
            dgvPaquetes.Rows.Clear();
            dgvErrores.Rows.Clear();
            MostrarResumenLote();
            MostrarDetallePaquete();
            tLote.Focus();
        }

        private void dgvPaquetes_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDetallePaquete();
        }

        private void bGuardar_Click(object sender, EventArgs e)
        {
            Lote? lote = _loteActual;

            if (lote == null || lote.CantidadValidos == 0 || lote.Id.HasValue)
            {
                return;
            }

            bool ingles = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "en";
            long id;

            try
            {
                GuardarLoteActual();
                id = _loteActual!.Id!.Value;
            }
            catch (Exception error) when (
                error is SqliteException or IOException or UnauthorizedAccessException)
            {
                string mensaje = ingles
                    ? "The batch could not be saved."
                    : "No se pudo guardar el lote.";

                MessageBox.Show(this, mensaje + Environment.NewLine + error.Message,
                    ingles ? "Save error" : "Error al guardar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(this,
                ingles ? $"Batch {id} saved." : $"Lote {id} guardado.",
                ingles ? "Save batch" : "Guardar lote",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
