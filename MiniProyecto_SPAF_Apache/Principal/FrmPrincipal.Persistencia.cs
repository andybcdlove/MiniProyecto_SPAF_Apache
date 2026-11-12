using MiniProyecto_SPAF_Apache.Dominio;
using MiniProyecto_SPAF_Apache.Principal;
using MiniProyecto_SPAF_Apache.Servicios.Logica;
using MiniProyecto_SPAF_Apache.Servicios.Persistencia;

namespace MiniProyecto_SPAF_Apache;

public partial class FrmPrincipal
{
    private readonly RepositorioEnvios _repositorio = new();
    private readonly ProcesadorLotes _procesador = new();
    private Lote? _loteActual;
    private ConfiguracionTarifas? _tarifas;
    private bool Ingles => cbIdioma.SelectedIndex == 1;

    private void ConectarPersistencia()
    {
        IntegracionPersistencia.PrepararTabla(dgvPaquetes);
        IntegracionPersistencia.PrepararTabla(dgvErrores);
        bGuardar.Enabled = bExportar.Enabled = false;
        Shown += (_, _) => IntegracionPersistencia.Ejecutar(this, Ingles, () =>
        {
            _tarifas = new ConfiguracionServicio().CargarConfiguracion();
            _repositorio.Inicializar();
        });
        bProcesar.Click += ProcesarLote;
        bGuardar.Click += GuardarLote;
        bExportar.Click += ExportarLote;
        bLimpiar.Click += (_, _) =>
        {
            _loteActual = null;
            tLote.Clear();
            dgvPaquetes.Rows.Clear();
            dgvErrores.Rows.Clear();
            MostrarResumen();
        };
        dgvPaquetes.SelectionChanged += (_, _) =>
        {
            int indice = dgvPaquetes.CurrentRow?.Index ?? -1;
            IntegracionPersistencia.MostrarDetalle(gbDetalle,
                _loteActual != null && indice >= 0 && indice < _loteActual.Paquetes.Count
                    ? _loteActual.Paquetes[indice] : null);
        };
        MostrarResumen();
    }

    private void ProcesarLote(object? sender, EventArgs e) =>
        IntegracionPersistencia.Ejecutar(this, Ingles, () =>
        {
            // Reintentar la lectura permite corregir un JSON ausente o inválido sin reiniciar.
            _tarifas = new ConfiguracionServicio().CargarConfiguracion();
            var calculadora = new CalculadoraFlete();
            _loteActual = _procesador.Procesar(tLote.Text, paquete =>
            {
                calculadora.CalcularDesglose(paquete, _tarifas);
                return paquete.Total;
            });
            IntegracionPersistencia.MostrarPaquetes(dgvPaquetes, _loteActual.Paquetes);
            dgvErrores.Rows.Clear();
            foreach (ErrorValidacion error in _loteActual.Errores)
                dgvErrores.Rows.Add(error.NumeroLinea, error.TextoOriginal, error.Motivo);
            MostrarResumen();
        });

    private void GuardarLote(object? sender, EventArgs e) =>
        IntegracionPersistencia.Ejecutar(this, Ingles, () =>
        {
            if (_loteActual == null || _loteActual.Id.HasValue) return;
            GuardarLoteActual();
            MessageBox.Show(this, Ingles ? "Batch saved." : "Lote guardado.");
        });

    private void GuardarLoteActual()
    {
        if (_loteActual == null || _loteActual.Id.HasValue) return;
        long id = _repositorio.GuardarLote(_loteActual);
        _loteActual = new Lote(_loteActual.Paquetes.ToArray(), _loteActual.Errores.ToArray(),
            _loteActual.Total, _loteActual.FechaProcesamiento, id);
        MostrarResumen();
    }

    private void ExportarLote(object? sender, EventArgs e) =>
        IntegracionPersistencia.Ejecutar(this, Ingles, () =>
        {
            if (_loteActual == null) return;
            sfdExportar.Filter = "Excel - tabla con formato (*.xlsx)|*.xlsx|CSV - texto sin formato (*.csv)|*.csv";
            sfdExportar.FilterIndex = 1;
            sfdExportar.FileName = "ReporteEnvios";
            sfdExportar.DefaultExt = "xlsx";
            sfdExportar.AddExtension = true;
            sfdExportar.OverwritePrompt = true;
            if (sfdExportar.ShowDialog(this) != DialogResult.OK) return;
            string extension = Path.GetExtension(sfdExportar.FileName);
            if (extension.Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
                new ExportadorExcel().Exportar(_loteActual, sfdExportar.FileName);
            else if (extension.Equals(".csv", StringComparison.OrdinalIgnoreCase))
                new ExportadorCSV().Exportar(_loteActual, sfdExportar.FileName);
            else throw new ArgumentException(Ingles ? "Choose an .xlsx or .csv file." : "Elige un archivo .xlsx o .csv.");
            bool esExcel = extension.Equals(".xlsx", StringComparison.OrdinalIgnoreCase);
            string mensaje = esExcel
                ? (Ingles ? "Formatted Excel report exported." : "Reporte de Excel con formato exportado.")
                : (Ingles ? "CSV exported. Choose Excel (.xlsx) for a formatted table."
                    : "CSV exportado. Para obtener una tabla con colores y bordes, elige Excel (.xlsx).");
            MessageBox.Show(this, mensaje);
        });

    private void MostrarResumen()
    {
        lValidos.Text = (Ingles ? "Valid: " : "Válidos: ") + (_loteActual?.CantidadValidos ?? 0);
        lInvalidos.Text = (Ingles ? "Invalid: " : "Inválidos: ") + (_loteActual?.CantidadInvalidos ?? 0);
        lTotalLote.Text = "Total: " + (_loteActual?.Total ?? 0).ToString("N2");
        bGuardar.Enabled = _loteActual is { Id: null, CantidadValidos: > 0 };
        bExportar.Enabled = _loteActual is { CantidadValidos: > 0 };
        if (_loteActual == null) IntegracionPersistencia.MostrarDetalle(gbDetalle,null);
    }
}
