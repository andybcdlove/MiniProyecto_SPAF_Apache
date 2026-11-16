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
        Font = new Font("Century Gothic", 12F, FontStyle.Regular);
        BackColor = SystemColors.ControlLightLight;
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(1050, 650);
        MinimumSize = new Size(900, 600);
        Padding = new Padding(12);
        var panel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill, Padding = new Padding(12), BackColor = Color.Cornsilk,
            ColumnCount = 2, RowCount = 7
        };
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170));
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 64));
        panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 44));
        panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 42));
        panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 42));
        panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 85));
        panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 48));
        panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        var titulo = new Label
        {
            Text = "Recepciones del lote " + lote.Id, Dock = DockStyle.Fill,
            BackColor = Color.Gold, ForeColor = Color.Crimson,
            Font = new Font("Century Gothic", 21.75F, FontStyle.Italic),
            TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(10, 0, 0, 0)
        };
        panel.Controls.Add(titulo, 0, 0); panel.SetColumnSpan(titulo, 2);
        var instruccion = new Label
        {
            Text = "Registra la llegada de un paquete guardado. Una recepción por paquete.",
            Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft
        };
        panel.Controls.Add(instruccion, 0, 1); panel.SetColumnSpan(instruccion, 2);
        panel.Controls.Add(new Label { Text = "Paquete", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 2);
        panel.Controls.Add(_paquete, 1, 2);
        panel.Controls.Add(new Label { Text = "Recibido por", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 3);
        panel.Controls.Add(_recibidoPor, 1, 3);
        panel.Controls.Add(new Label { Text = "Observaciones", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 4);
        panel.Controls.Add(_observaciones, 1, 4);
        var guardar = new Button
        {
            Text = "Registrar recepción", AutoSize = true, BackColor = Color.Gold,
            ForeColor = Color.Crimson, Font = new Font("Century Gothic", 13F, FontStyle.Bold),
            UseVisualStyleBackColor = false, Padding = new Padding(8, 2, 8, 2), Anchor = AnchorStyles.Left
        };
        panel.Controls.Add(guardar, 1, 5);
        panel.Controls.Add(_tabla, 0, 6); panel.SetColumnSpan(_tabla, 2);
        _tabla.BackgroundColor = Color.Cornsilk;
        _tabla.RowHeadersVisible = false;
        _tabla.EnableHeadersVisualStyles = true;
        _tabla.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = SystemColors.Control, ForeColor = SystemColors.WindowText,
            Font = new Font("Century Gothic", 13F, FontStyle.Bold),
            Alignment = DataGridViewContentAlignment.MiddleCenter,
            WrapMode = DataGridViewTriState.True,
            SelectionBackColor = SystemColors.Highlight, SelectionForeColor = SystemColors.HighlightText
        };
        _tabla.DefaultCellStyle.BackColor = Color.White;
        _tabla.DefaultCellStyle.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
        _tabla.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
        _tabla.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
        _tabla.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        _tabla.GridColor = SystemColors.ControlDark;
        _tabla.BorderStyle = BorderStyle.FixedSingle;
        _tabla.CellBorderStyle = DataGridViewCellBorderStyle.Single;
        _tabla.RowTemplate.Height = 26;
        _tabla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        _tabla.DataBindingComplete += (_, _) =>
        {
            string[] propiedades = ["Id", "LoteId", "IndicePaquete", "CodigoPaquete", "FechaRecepcion", "RecibidoPor", "Observaciones"];
            string[] encabezados = ["Recepción", "Lote", "Índice del paquete", "Código", "Fecha de recepción", "Recibido por", "Observaciones"];
            for (int i = 0; i < propiedades.Length; i++)
                if (_tabla.Columns[propiedades[i]] is DataGridViewColumn columna)
                    columna.HeaderText = encabezados[i];
        };
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
