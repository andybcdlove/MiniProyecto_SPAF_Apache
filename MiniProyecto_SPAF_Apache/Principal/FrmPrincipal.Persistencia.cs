using MiniProyecto_SPAF_Apache.Dominio;
using MiniProyecto_SPAF_Apache.Principal;
using MiniProyecto_SPAF_Apache.Servicios.Persistencia;

namespace MiniProyecto_SPAF_Apache;

public partial class FrmPrincipal
{
    private readonly RepositorioEnvios _repositorio = new();
    private Lote? _loteActual;
    private bool Ingles => cbIdioma.SelectedIndex == 1;

    private void ConectarPersistencia()
    {
        //prepara las tablas
        IntegracionPersistencia.PrepararTabla(dgvPaquetes);
        IntegracionPersistencia.PrepararTabla(dgvErrores);

        bGuardar.Enabled = false;
        bExportar.Enabled = false;

        //prepara la base de datos
        Shown += (_, _) => IntegracionPersistencia.Ejecutar(
            this, Ingles, () =>
            {
                _repositorio.Inicializar();
            });

        //conecta la exportacion de excel y csv
        bExportar.Click += ExportarLote;

        //muestra el resumen inicial
        MostrarResumenLote();
    }

    private void GuardarLoteActual()
    {
        if (_loteActual == null || _loteActual.CantidadValidos == 0 || _loteActual.Id.HasValue) return;
        long id = _repositorio.GuardarLote(_loteActual);
        _loteActual = new Lote(_loteActual.Paquetes.ToArray(), _loteActual.Errores.ToArray(),
            _loteActual.Total, _loteActual.FechaProcesamiento, id);
        MostrarResumenLote();
    }

    private void ExportarLote(object? sender, EventArgs e) =>
        IntegracionPersistencia.Ejecutar(this, Ingles, () =>
        {
            if (_loteActual == null || _loteActual.CantidadValidos == 0) return;
            sfdExportar.Title = Ingles ? "Export batch" : "Exportar lote";
            sfdExportar.Filter = Ingles
                ? "Excel - formatted table (*.xlsx)|*.xlsx|CSV - plain text (*.csv)|*.csv"
                : "Excel - tabla con formato (*.xlsx)|*.xlsx|CSV - texto sin formato (*.csv)|*.csv";
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

}
