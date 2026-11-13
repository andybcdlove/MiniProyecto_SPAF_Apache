using System.Globalization;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic.FileIO;
using MiniProyecto_SPAF_Apache.Dominio;
using MiniProyecto_SPAF_Apache.Servicios.Persistencia;

// Ejecutar primero "guardar carpeta" y después "recuperar carpeta", en procesos separados.
string modo = args[0];
string carpeta = Path.GetFullPath(args[1]);
Directory.CreateDirectory(carpeta);
string ruta = Path.Combine(carpeta, "prueba.db");
var repositorio = new RepositorioEnvios(ruta);
const string cliente = "María, \"López\"\r\nSucursal norte";
CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("es-MX");
void Comprobar(bool condicion, string mensaje)
{
    if (!condicion) throw new Exception(mensaje);
}

if (modo == "guardar")
{
    Comprobar(!File.Exists(ruta), "Usar una carpeta nueva para no modificar pruebas previas.");
    Paquete[] paquetes = new Paquete[7];
    for (int i = 0; i < paquetes.Length; i++)
        paquetes[i] = new Paquete("PACK-" + i, cliente, "Zona A", 12.345m, 1500m)
        {
            SubtotalPeso = 123.45m, RecargoZona = 6.17m, PenalizacionPeso = 0m,
            Seguro = 30m, CostoFijo = 50m, Iva = 33.54m, Total = 243.16m
        };
    ErrorValidacion[] errores = [new(8, "incorrecto", CodigoErrorValidacion.PesoInvalido),
        new(9, "otro", "Motivo personalizado")];
    var lote = new Lote(paquetes, errores, 1702.12m, new DateTime(2026, 11, 12, 10, 30, 0), null);
    long id = repositorio.GuardarLote(lote);
    Comprobar(id > 0, "Id inválido");
    new ExportadorCSV().Exportar(lote, Path.Combine(carpeta, "reporte.csv"));
    long recepcionId = repositorio.RegistrarRecepcion(id, 0, "Dana", "Llegó sin daños");
    Comprobar(recepcionId > 0, "No se guardó la recepción");
    bool recepcionDuplicada = false;
    try { repositorio.RegistrarRecepcion(id, 0, "Dana"); }
    catch (InvalidOperationException) { recepcionDuplicada = true; }
    Comprobar(recepcionDuplicada, "Se permitió duplicar una recepción");
    bool paqueteInexistente = false;
    try { repositorio.RegistrarRecepcion(id, 999, "Dana"); }
    catch (InvalidOperationException) { paqueteInexistente = true; }
    Comprobar(paqueteInexistente, "Se recibió un paquete inexistente");

    using (var conexion = new SqliteConnection(new SqliteConnectionStringBuilder { DataSource = ruta }.ToString()))
    {
        conexion.Open();
        using var comando = conexion.CreateCommand();
        comando.CommandText = "CREATE TRIGGER Fallar BEFORE INSERT ON Desgloses BEGIN SELECT RAISE(ABORT,'Fallo simulado'); END";
        comando.ExecuteNonQuery();
    }
    bool fallo = false;
    try { repositorio.GuardarLote(lote); }
    catch (SqliteException) { fallo = true; }
    Comprobar(fallo, "No se provocó el fallo transaccional");
    using (var conexion = new SqliteConnection(new SqliteConnectionStringBuilder { DataSource = ruta }.ToString()))
    {
        conexion.Open();
        using var comando = conexion.CreateCommand();
        comando.CommandText = "SELECT (SELECT COUNT(*) FROM Lotes)=1 AND (SELECT COUNT(*) FROM Paquetes)=7 AND (SELECT COUNT(*) FROM Desgloses)=7";
        Comprobar((long)comando.ExecuteScalar()! == 1, "Quedaron registros parciales");
        comando.CommandText = "DROP TRIGGER Fallar";
        comando.ExecuteNonQuery();
    }
    bool errorRuta = false;
    try { new ExportadorCSV().Exportar(lote, carpeta); }
    catch (UnauthorizedAccessException) { errorRuta = true; }
    catch (IOException) { errorRuta = true; }
    Comprobar(errorRuta, "La ruta inválida no informó un error");
    Console.WriteLine("OK: guardado, CSV, rollback y ruta inválida.");
}
else if (modo == "recuperar")
{
    Lote[] lotes = repositorio.ObtenerLotes();
    Comprobar(lotes.Length == 1, "Cantidad de lotes incorrecta");
    Lote lote = lotes[0];
    Recepcion[] recepciones = repositorio.ObtenerRecepciones(lote.Id!.Value);
    Comprobar(recepciones.Length == 1 && recepciones[0].RecibidoPor == "Dana"
        && recepciones[0].Observaciones == "Llegó sin daños" && recepciones[0].IndicePaquete == 0,
        "No se recuperó la recepción");
    Comprobar(lote.Total == 1702.12m && lote.Paquetes.Count == 7, "Importes o cantidad incorrectos");
    Comprobar(lote.FechaProcesamiento == new DateTime(2026,11,12,10,30,0), "Fecha alterada");
    foreach (Paquete p in lote.Paquetes)
        Comprobar(p.Cliente == cliente && p.Peso == 12.345m && p.ValorDeclarado == 1500m
            && p.SubtotalPeso == 123.45m && p.RecargoZona == 6.17m && p.PenalizacionPeso == 0m
            && p.Seguro == 30m && p.CostoFijo == 50m && p.Iva == 33.54m && p.Total == 243.16m,
            "Se alteró un dato del paquete");
    Comprobar(lote.Errores.Count == 2 && lote.Errores[0].Codigo == CodigoErrorValidacion.PesoInvalido
        && lote.Errores[1].Motivo == "Motivo personalizado", "Errores alterados");
    Comprobar(repositorio.ObtenerPaquetes(lote.Id!.Value).Length == 7, "Consulta de paquetes incorrecta");
    bool duplicado = false;
    try { repositorio.GuardarLote(lote); }
    catch (InvalidOperationException) { duplicado = true; }
    Comprobar(duplicado, "Se permitió guardar un lote ya recuperado");
    using var lector = new TextFieldParser(Path.Combine(carpeta, "reporte.csv"));
    lector.SetDelimiters(",");
    lector.HasFieldsEnclosedInQuotes = true;
    Comprobar(lector.ReadFields()!.Length == 12, "Encabezados incorrectos");
    int cantidad = 0;
    while (!lector.EndOfData)
    {
        string[] campos = lector.ReadFields()!;
        Comprobar(campos.Length == 12 && campos[1] == cliente && campos[3] == "12.345"
            && campos[11] == "243.16", "CSV inválido");
        cantidad++;
    }
    Comprobar(cantidad == 7, "Filas CSV incorrectas");
    Console.WriteLine("OK: recuperación en otro proceso, importes originales, errores y lectura CSV.");
}
else if (modo == "interfaz")
{
    Comprobar(!File.Exists(ruta), "Usar carpeta nueva para la prueba de interfaz.");
    Exception? fallo = null;
    var hilo = new Thread(() =>
    {
        try
        {
            const System.Reflection.BindingFlags privados = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic;
            T Campo<T>(object objeto, string nombre) => (T)objeto.GetType().GetField(nombre, privados)!.GetValue(objeto)!;
            void Invocar(object objeto, string nombre, params object?[] parametros) =>
                objeto.GetType().GetMethod(nombre, privados)!.Invoke(objeto, parametros);
            using var principal = new MiniProyecto_SPAF_Apache.FrmPrincipal(repositorio);
            Campo<TextBox>(principal, "tLote").Text = "PACK-001;Ana;Zona A;12.5;150\r\nPACK-002;Luis;Zona C;25;1500\r\nPACK-003;Error;Zona B;-1;50";
            Invocar(principal, "ProcesarLote", null, EventArgs.Empty);
            var tabla = Campo<DataGridView>(principal, "dgvPaquetes");
            Comprobar(tabla.Rows.Count == 2 && Campo<DataGridView>(principal,"dgvErrores").Rows.Count == 1,
                "Las tablas no muestran el procesamiento");
            Comprobar(Campo<Button>(principal,"bGuardar").Enabled, "Guardar no se habilitó");
            Invocar(principal,"GuardarLoteActual");
            Comprobar(!Campo<Button>(principal,"bGuardar").Enabled, "Guardar no se deshabilitó");
            Invocar(principal,"GuardarLoteActual");
            Comprobar(repositorio.ObtenerLotes().Length == 1, "La interfaz permitió duplicar el guardado");
            using var historial = new MiniProyecto_SPAF_Apache.Principal.FrmHistorial(repositorio);
            Invocar(historial,"CargarHistorial");
            var lotes = Campo<DataGridView>(historial,"dataGridView1");
            Comprobar(lotes.Rows.Count == 1, "El historial no cargó el lote");
            lotes.CurrentCell = lotes.Rows[0].Cells[0];
            Invocar(historial,"SeleccionarLote");
            Comprobar(Campo<DataGridView>(historial,"dgvPaquetes").Rows.Count == 2,
                "El historial no muestra los paquetes");
            Comprobar(repositorio.ObtenerLotes()[0].Total == 659.75m, "Total financiero inesperado");
            Lote recuperado = repositorio.ObtenerLotes()[0];
            repositorio.RegistrarRecepcion(recuperado.Id!.Value, 0, "Dana");
            using var recepciones = new MiniProyecto_SPAF_Apache.Principal.FrmRecepciones(repositorio, recuperado);
            Invocar(recepciones, "Actualizar");
            Comprobar(Campo<DataGridView>(recepciones,"_tabla").Rows.Count == 1,
                "La ventana de recepciones no muestra el registro");
        }
        catch (Exception error) { fallo = error; }
    });
    hilo.SetApartmentState(ApartmentState.STA);
    hilo.Start();
    hilo.Join();
    if (fallo != null) throw new Exception("Falló la integración WinForms", fallo);
    Console.WriteLine("OK: controles WinForms, procesamiento, guardado único e historial.");
}
else if (modo == "excel")
{
    var p = new Paquete("PACK-004", "Samuel, \"Pérez\"\nSucursal norte", "Zona A", 14.5m, 120m)
        { SubtotalPeso = 145m, RecargoZona = 7.25m, CostoFijo = 50m, Iva = 32.36m, Total = 234.61m };
    var lote = new Lote([p], [], p.Total, new DateTime(2026,11,12,12,0,0), null);
    string archivo = Path.Combine(carpeta,"ReporteEnvios.xlsx");
    new ExportadorExcel().Exportar(lote,archivo);
    using (var libro = new ClosedXML.Excel.XLWorkbook(archivo))
    {
        var hoja = libro.Worksheet("Envíos");
        Comprobar(hoja.Cell("B6").GetString() == p.Cliente, "Nombre alterado");
        Comprobar(hoja.Cell("D6").GetValue<decimal>() == 14.5m && hoja.Cell("L6").GetValue<decimal>() == 234.61m,
            "Importes Excel incorrectos");
        Comprobar(hoja.Cell("L8").GetValue<decimal>() == lote.Total, "Total incorrecto");
        Comprobar(hoja.Tables.Count() == 1 && hoja.Table("Paquetes").ShowAutoFilter, "Falta tabla o filtros");
        Comprobar(hoja.Cell("L6").Style.NumberFormat.Format.Contains("0.00"), "Falta formato monetario");
    }
    using (var documento = DocumentFormat.OpenXml.Packaging.SpreadsheetDocument.Open(archivo, false))
    {
        var errores = new DocumentFormat.OpenXml.Validation.OpenXmlValidator().Validate(documento).ToArray();
        Comprobar(errores.Length == 0, string.Join(Environment.NewLine, errores.Select(e => e.Description)));
    }
    // El archivo debe seguir siendo válido aun si se llama al servicio con un lote vacío.
    new ExportadorExcel().Exportar(new Lote([], [], 0, DateTime.Now, null), Path.Combine(carpeta,"Vacio.xlsx"));
    Console.WriteLine("OK: XLSX válido, tabla, filtros, texto, valores numéricos y formato monetario.");
}
else throw new ArgumentException("Modo esperado: guardar, recuperar, interfaz o excel");
