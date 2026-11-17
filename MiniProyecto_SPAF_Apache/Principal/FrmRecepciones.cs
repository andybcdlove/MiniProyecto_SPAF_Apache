using MiniProyecto_SPAF_Apache.Dominio;
using MiniProyecto_SPAF_Apache.Servicios.Persistencia;

namespace MiniProyecto_SPAF_Apache.Principal;

public class FrmRecepciones : Form
{
    private readonly RepositorioEnvios _repositorio;
    private readonly Lote _lote;
    private readonly bool _ingles;
    private readonly ComboBox _paquete = new() { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill };
    private readonly TextBox _recibidoPor = new() { Dock = DockStyle.Fill, MaxLength = 200 };
    private readonly TextBox _observaciones = new() { Dock = DockStyle.Fill, Multiline = true, MaxLength = 2000 };
    private readonly DataGridView _tabla = new() { Dock = DockStyle.Fill, AutoGenerateColumns = true,
        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells };

    public FrmRecepciones(RepositorioEnvios repositorio, Lote lote, bool ingles = false)
    {
        _ingles = ingles;
        _repositorio = repositorio;
        _lote = lote;
        Text = Traducir("Recepciones del lote ", "Receptions for batch ") + lote.Id;
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
            ColumnCount = 2, RowCount = 8
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
        panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 48));
        var titulo = new Label
        {
            Text = Text, Dock = DockStyle.Fill,
            BackColor = Color.Gold, ForeColor = Color.Crimson,
            Font = new Font("Century Gothic", 21.75F, FontStyle.Italic),
            TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(10, 0, 0, 0)
        };
        panel.Controls.Add(titulo, 0, 0); panel.SetColumnSpan(titulo, 2);
        var instruccion = new Label
        {
            Text = Traducir("Registra la llegada de un paquete guardado. Una recepción por paquete.",
                "Register the arrival of a saved package. One reception per package."),
            Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft
        };
        panel.Controls.Add(instruccion, 0, 1); panel.SetColumnSpan(instruccion, 2);
        panel.Controls.Add(new Label { Text = Traducir("Paquete", "Package"), AutoSize = true, Anchor = AnchorStyles.Left }, 0, 2);
        panel.Controls.Add(_paquete, 1, 2);
        panel.Controls.Add(new Label { Text = Traducir("Recibido por", "Received by"), AutoSize = true, Anchor = AnchorStyles.Left }, 0, 3);
        panel.Controls.Add(_recibidoPor, 1, 3);
        panel.Controls.Add(new Label { Text = Traducir("Observaciones", "Notes"), AutoSize = true, Anchor = AnchorStyles.Left }, 0, 4);
        panel.Controls.Add(_observaciones, 1, 4);
        var guardar = new Button
        {
            Text = Traducir("Registrar recepción", "Register reception"), AutoSize = true, BackColor = Color.Gold,
            ForeColor = Color.Crimson, Font = new Font("Century Gothic", 13F, FontStyle.Bold),
            UseVisualStyleBackColor = false, Padding = new Padding(8, 2, 8, 2), Anchor = AnchorStyles.Left
        };
        panel.Controls.Add(guardar, 1, 5);
        panel.Controls.Add(_tabla, 0, 6); panel.SetColumnSpan(_tabla, 2);
        //agrega el regreso y la salida sin cambiar el tamano de la ventana
        var navegacion = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill, FlowDirection = FlowDirection.RightToLeft,
            WrapContents = false
        };
        var regresar = new Button
        {
            Name = "bRegresar", Text = Traducir("Regresar", "Back"),
            Size = new Size(130, 36), BackColor = guardar.BackColor,
            ForeColor = guardar.ForeColor, Font = guardar.Font,
            UseVisualStyleBackColor = false
        };
        regresar.Click += (_, _) => Close();
        Button salir = NavegacionFormularios.CrearBotonSalir(regresar);
        salir.Text = Traducir("Salir", "Exit");
        navegacion.Controls.Add(salir);
        navegacion.Controls.Add(regresar);
        panel.Controls.Add(navegacion, 0, 7);
        panel.SetColumnSpan(navegacion, 2);
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
            if (_ingles)
            {
                encabezados = ["Reception", "Batch", "Package index", "Code", "Reception date", "Received by", "Notes"];
            }
            for (int i = 0; i < propiedades.Length; i++)
                if (_tabla.Columns[propiedades[i]] is DataGridViewColumn columna)
                    columna.HeaderText = encabezados[i];
        };
        Controls.Add(panel);
        for (int i = 0; i < lote.Paquetes.Count; i++)
            _paquete.Items.Add($"{i + 1}. {lote.Paquetes[i].Codigo} — {lote.Paquetes[i].Cliente}");
        if (_paquete.Items.Count > 0) _paquete.SelectedIndex = 0;
        IntegracionPersistencia.PrepararTabla(_tabla);
        Shown += (_, _) => EjecutarRecepcion(Actualizar);
        guardar.Click += (_, _) => EjecutarRecepcion(() =>
        {
            //comprueba los datos de captura
            if (_paquete.SelectedIndex < 0)
            {
                MessageBox.Show(this, Traducir("Selecciona un paquete.", "Select a package."), Text);
                return;
            }
            if (string.IsNullOrWhiteSpace(_recibidoPor.Text))
            {
                MessageBox.Show(this, Traducir("Escribe quién recibió el paquete.", "Enter who received the package."), Text);
                return;
            }
            _repositorio.RegistrarRecepcion(_lote.Id!.Value, _paquete.SelectedIndex,
                _recibidoPor.Text, _observaciones.Text);
            Actualizar();
            MessageBox.Show(this, Traducir("Recepción registrada.", "Reception registered."), Text);
        });
    }

    //elige el texto segun el idioma del historial
    private string Traducir(string espanol, string ingles)
    {
        if (_ingles) return ingles;
        return espanol;
    }

    //muestra los errores de recepcion en el idioma seleccionado
    private void EjecutarRecepcion(Action accion)
    {
        try
        {
            accion();
        }
        catch (InvalidOperationException error) when (
            error.Message == "El paquete ya tiene una recepción registrada." ||
            error.Message == "El paquete no existe en el lote guardado.")
        {
            string mensaje;
            if (error.Message == "El paquete ya tiene una recepción registrada.")
                mensaje = Traducir(error.Message, "The package already has a registered reception.");
            else
                mensaje = Traducir(error.Message, "The package does not exist in the saved batch.");
            MessageBox.Show(this, mensaje, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception error) when (error is Microsoft.Data.Sqlite.SqliteException
            or IOException or UnauthorizedAccessException or ArgumentException
            or InvalidOperationException or FormatException)
        {
            System.Diagnostics.Debug.WriteLine(error);
            MessageBox.Show(this,
                Traducir("No se pudo completar la operación de recepciones. Comprueba el acceso a la base de datos.",
                    "The reception operation could not be completed. Check access to the database."),
                Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void Actualizar() => _tabla.DataSource = _repositorio.ObtenerRecepciones(_lote.Id!.Value);
}
