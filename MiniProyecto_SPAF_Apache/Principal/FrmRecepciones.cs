using MiniProyecto_SPAF_Apache.Dominio;
using MiniProyecto_SPAF_Apache.Servicios.Persistencia;

namespace MiniProyecto_SPAF_Apache.Principal;

public class FrmRecepciones : Form
{
    private readonly RepositorioEnvios _repositorio;
    private readonly Lote _lote;
    private readonly ComboBox _paquete = new() { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill };
    private readonly TextBox _recibidoPor = new() { Dock = DockStyle.Fill, MaxLength = 200 };
    private readonly TextBox _observaciones = new() { Dock = DockStyle.Fill, Multiline = true, MaxLength = 2000 };
    private readonly DataGridView _tabla = new() { Dock = DockStyle.Fill, AutoGenerateColumns = true,
        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells };

    public FrmRecepciones(RepositorioEnvios repositorio, Lote lote)
    {
        _repositorio = repositorio;
        _lote = lote;
        Text = "Recepciones del lote " + lote.Id;
        StartPosition = FormStartPosition.CenterParent;
        ClientSize = new Size(850, 500);
        MinimumSize = new Size(650, 420);
        var panel = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(12), ColumnCount = 2, RowCount = 6 };
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140));
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
        panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
        panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
        panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 65));
        panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
        panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        var titulo = new Label { Text = "Registra la llegada de un paquete guardado. Una recepción por paquete.", Dock = DockStyle.Fill };
        panel.Controls.Add(titulo, 0, 0); panel.SetColumnSpan(titulo, 2);
        panel.Controls.Add(new Label { Text = "Paquete", AutoSize = true }, 0, 1);
        panel.Controls.Add(_paquete, 1, 1);
        panel.Controls.Add(new Label { Text = "Recibido por", AutoSize = true }, 0, 2);
        panel.Controls.Add(_recibidoPor, 1, 2);
        panel.Controls.Add(new Label { Text = "Observaciones", AutoSize = true }, 0, 3);
        panel.Controls.Add(_observaciones, 1, 3);
        var guardar = new Button { Text = "Registrar recepción", AutoSize = true };
        panel.Controls.Add(guardar, 1, 4);
        panel.Controls.Add(_tabla, 0, 5); panel.SetColumnSpan(_tabla, 2);
        Controls.Add(panel);
        for (int i = 0; i < lote.Paquetes.Count; i++)
            _paquete.Items.Add($"{i + 1}. {lote.Paquetes[i].Codigo} — {lote.Paquetes[i].Cliente}");
        if (_paquete.Items.Count > 0) _paquete.SelectedIndex = 0;
        IntegracionPersistencia.PrepararTabla(_tabla);
        Shown += (_, _) => IntegracionPersistencia.Ejecutar(this, false, Actualizar);
        guardar.Click += (_, _) => IntegracionPersistencia.Ejecutar(this, false, () =>
        {
            _repositorio.RegistrarRecepcion(_lote.Id!.Value, _paquete.SelectedIndex,
                _recibidoPor.Text, _observaciones.Text);
            Actualizar();
            MessageBox.Show(this, "Recepción registrada.");
        });
    }

    private void Actualizar() => _tabla.DataSource = _repositorio.ObtenerRecepciones(_lote.Id!.Value);
}
