using MiniProyecto_SPAF_Apache.Dominio;
using MiniProyecto_SPAF_Apache.Servicios.Persistencia;

namespace MiniProyecto_SPAF_Apache.Principal;

public partial class FrmHistorial
{
    private RepositorioEnvios _repositorio = new();
    private Lote[] _lotes = [];
    private Lote? _seleccionado;

    private void ConectarPersistencia()
    {
        IntegracionPersistencia.PrepararTabla(dataGridView1);
        IntegracionPersistencia.PrepararTabla(dgvPaquetes);
        Shown += (_, _) => CargarHistorial();
        bActualizar.Click += (_, _) => CargarHistorial();
        var recepciones = new Button
        {
            Name = "bRecepciones", Text = "Recepciones", AutoSize = true,
            Location = new Point(bActualizar.Right + 20, bActualizar.Top), Height = bActualizar.Height
        };
        Controls.Add(recepciones);
        recepciones.Click += (_, _) =>
        {
            if (_seleccionado?.Id == null)
            {
                MessageBox.Show(this, "Selecciona primero un lote guardado.");
                return;
            }
            using var ventana = new FrmRecepciones(_repositorio, _seleccionado);
            ventana.ShowDialog(this);
        };
        dataGridView1.SelectionChanged += (_, _) => SeleccionarLote();
        dgvPaquetes.SelectionChanged += (_, _) =>
        {
            int indice = dgvPaquetes.CurrentRow?.Index ?? -1;
            IntegracionPersistencia.MostrarDetalle(gbDetalle,
                _seleccionado != null && indice >= 0 && indice < _seleccionado.Paquetes.Count
                    ? _seleccionado.Paquetes[indice] : null);
        };
    }

    private void CargarHistorial() => IntegracionPersistencia.Ejecutar(this, cbIdioma.SelectedIndex == 1, () =>
    {
        Lote[] recuperados = _repositorio.ObtenerLotes();
        _lotes = [];
        dataGridView1.Rows.Clear();
        _lotes = recuperados;
        foreach (Lote lote in _lotes)
            dataGridView1.Rows.Add(lote.Id!.Value, lote.FechaProcesamiento, lote.CantidadValidos, lote.Total);
        SeleccionarLote();
    });

    private void SeleccionarLote()
    {
        int indice = dataGridView1.CurrentRow?.Index ?? -1;
        _seleccionado = indice >= 0 && indice < _lotes.Length ? _lotes[indice] : null;
        IntegracionPersistencia.MostrarPaquetes(dgvPaquetes, _seleccionado?.Paquetes ?? Array.Empty<Paquete>());
        if (_seleccionado == null) IntegracionPersistencia.MostrarDetalle(gbDetalle,null);
    }
}
