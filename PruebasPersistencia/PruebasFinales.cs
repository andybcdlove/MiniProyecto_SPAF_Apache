using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using MiniProyecto_SPAF_Apache;
using MiniProyecto_SPAF_Apache.Dominio;
using MiniProyecto_SPAF_Apache.Principal;
using MiniProyecto_SPAF_Apache.Servicios.Persistencia;

internal static class PruebasFinales
{
    private const BindingFlags Privados = BindingFlags.Instance | BindingFlags.NonPublic;
    private static T Campo<T>(object objeto, string nombre) =>
        (T)objeto.GetType().GetField(nombre, Privados)!.GetValue(objeto)!;
    private static void Invocar(object objeto, string nombre, params object?[] args) =>
        objeto.GetType().GetMethod(nombre, Privados)!.Invoke(objeto, args);
    private static void Comprobar(bool valor, string mensaje)
    {
        if (!valor) throw new Exception(mensaje);
    }

    public static void Ejecutar(string carpeta)
    {
        Exception? fallo = null;
        Thread hilo = new Thread(() =>
        {
            try { Probar(carpeta); }
            catch (Exception error) { fallo = error; }
        });
        hilo.SetApartmentState(ApartmentState.STA);
        hilo.Start();
        if (!hilo.Join(TimeSpan.FromSeconds(90))) throw new Exception("La prueba excedió el tiempo esperado.");
        if (fallo != null) throw new Exception("Falló la prueba final", fallo);
    }

    private static void Probar(string carpeta)
    {
        //solo cambia la copia del json junto al ejecutable de pruebas
        string rutaJson = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
        string? original = File.Exists(rutaJson) ? File.ReadAllText(rutaJson) : null;
        const string valido = "{\"PrecioBasePorKilogramo\":10,\"TasaIva\":0.16,\"CostoFijoEnvio\":50}";
        string rutaDb = Path.Combine(carpeta, "interfaz.db");
        Comprobar(!File.Exists(rutaDb), "Usar una carpeta de pruebas nueva.");
        var repositorio = new RepositorioEnvios(rutaDb);
        CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("es-MX");
        try
        {
            string?[] casos = [null, "{", "{\"PrecioBasePorKilogramo\":10,\"CostoFijoEnvio\":50}",
                valido.Replace(":10,", ":0,"), valido.Replace(":0.16,", ":1.5,"),
                valido.Replace(":50}", ":-1}"), "[]", valido.Replace(":10,", ":\"abc\",")];
            foreach (string? caso in casos)
            {
                if (caso == null) File.Delete(rutaJson); else File.WriteAllText(rutaJson, caso);
                using var form = new FrmPrincipal(repositorio);
                using var dialogos = new CerrarDialogos();
                Invocar(form, "OnLoad", EventArgs.Empty);
                Comprobar(!Campo<Button>(form, "bProcesar").Enabled, "Se habilitó Procesar con JSON inválido.");
                Comprobar(dialogos.Cantidad == 1, "No se mostró el aviso de configuración.");
            }
            Console.WriteLine("OK: ocho configuraciones inválidas muestran aviso y bloquean Procesar.");
            File.WriteAllText(rutaJson, valido);
            using var principal = new FrmPrincipal(repositorio);
            Invocar(principal, "OnLoad", EventArgs.Empty);
            Comprobar(Campo<Button>(principal, "bProcesar").Enabled, "No se recuperó al restaurar el JSON.");
            TextBox captura = Campo<TextBox>(principal, "tLote");
            DataGridView tabla = Campo<DataGridView>(principal, "dgvPaquetes");
            void Procesar(string texto)
            {
                captura.Text = texto;
                Invocar(principal, "bProcesar_Click", principal, EventArgs.Empty);
            }
            Procesar("PACK-001;Ana;Zona A;12.5;150\r\nPACK-002;Luis;Zona C;25;1500\r\nPACK-003;Error;Zona B;-1;50");
            Comprobar(tabla.Rows.Count == 2 && Campo<DataGridView>(principal,"dgvErrores").Rows.Count == 1, "Tablas incorrectas.");
            Comprobar(Campo<Lote>(principal, "_loteActual").Total == 659.75m, "Cálculo incorrecto.");
            using (var dialogos = new CerrarDialogos())
            {
                Invocar(principal, "bGuardar_Click", principal, EventArgs.Empty);
                Invocar(principal, "bGuardar_Click", principal, EventArgs.Empty);
                Comprobar(dialogos.Cantidad == 1, "El guardado se repitió.");
            }
            Comprobar(repositorio.ObtenerLotes().Length == 1, "El formulario no usó el repositorio indicado.");
            Comprobar(!Campo<Button>(principal,"bGuardar").Enabled, "Guardar quedó habilitado.");
            using var historial = new FrmHistorial(repositorio);
            Invocar(historial, "CargarLotesGuardados");
            DataGridView lotes = Campo<DataGridView>(historial,"dataGridView1");
            lotes.Rows[0].Selected = true;
            Invocar(historial, "MostrarPaquetesDelLoteSeleccionado");
            Comprobar(Campo<DataGridView>(historial,"dgvPaquetes").Rows.Count == 2, "Historial sin paquetes.");
            Lote lote = repositorio.ObtenerLotes()[0];
            using var recepciones = new FrmRecepciones(repositorio, lote, true);
            Button registrar = Controles(recepciones).OfType<Button>().Single(b => b.Text == "Register reception");
            using (var dialogos = new CerrarDialogos())
            {
                foreach (string nombre in new[] { "", "   " })
                {
                    Campo<TextBox>(recepciones, "_recibidoPor").Text = nombre;
                    typeof(Button).GetMethod("OnClick", Privados)!.Invoke(registrar, [EventArgs.Empty]);
                }
                Comprobar(dialogos.Cantidad == 2 && dialogos.Texto.Contains("Enter who received"), "Validación sin traducir.");
            }
            Comprobar(repositorio.ObtenerRecepciones(lote.Id!.Value).Length == 0, "Se guardó una recepción vacía.");
            using (var dialogos = new CerrarDialogos())
            {
                Campo<TextBox>(recepciones, "_recibidoPor").Text = "Andrea";
                typeof(Button).GetMethod("OnClick", Privados)!.Invoke(registrar, [EventArgs.Empty]);
                typeof(Button).GetMethod("OnClick", Privados)!.Invoke(registrar, [EventArgs.Empty]);
                Comprobar(dialogos.Cantidad == 2 && dialogos.Texto.Contains("already has a registered reception"), "Duplicado sin aviso en inglés.");
            }
            Comprobar(repositorio.ObtenerRecepciones(lote.Id.Value).Length == 1, "Recepción duplicada.");
            Invocar(principal,"bLimpiar_Click", principal, EventArgs.Empty);
            Comprobar(captura.Text == "" && tabla.Rows.Count == 0, "Limpiar conserva datos.");
            foreach (string texto in new[] { "", "PACK-001;Ana;Zona A;-5;100" })
            {
                Procesar(texto);
                Comprobar(!Campo<Button>(principal,"bGuardar").Enabled && !Campo<Button>(principal,"bExportar").Enabled, "Lote inválido habilita acciones.");
            }
            Procesar("PACK-001;María, López;Zona A;1;0\r\nPACK-002;José \"Pepe\";Zona B;2;100");
            Comprobar(Campo<Lote>(principal, "_loteActual").Total == 153.70m, "Total con nombres especiales incorrecto.");
            //las etiquetas automaticas pueden ajustar su ancho al texto traducido
            var limites = Controles(principal).Where(c => c is not Label || !c.AutoSize)
                .ToDictionary(c => c, c => c.Bounds);
            Campo<ComboBox>(principal,"cbIdioma").SelectedIndex = 1;
            Comprobar(limites.All(p => p.Key.Bounds == p.Value), "Cambió el diseño al traducir: " +
                string.Join(", ", limites.Where(p => p.Key.Bounds != p.Value).Select(p => p.Key.Name)));
            Comprobar(Campo<Lote>(principal,"_loteActual").Total == 153.70m, "Se perdieron datos al traducir.");
            string salida = Path.Combine(carpeta, "cancelada.xlsx");
            Campo<SaveFileDialog>(principal,"sfdExportar").InitialDirectory = carpeta;
            using (var dialogos = new CerrarDialogos())
            {
                Invocar(principal,"ExportarLote", principal, EventArgs.Empty);
                Comprobar(dialogos.Cantidad == 1, "Cancelar exportación mostró otro mensaje.");
            }
            Comprobar(!File.Exists(salida) && Directory.GetFiles(carpeta,"*.xlsx").Length == 0, "Cancelar creó un archivo.");
            Console.WriteLine("OK: recuperación JSON, eventos actuales, guardado único, historial, recepciones vacías y duplicadas, limpiar, lote vacío, idiomas y cancelar exportación.");
        }
        finally
        {
            if (original == null) File.Delete(rutaJson); else File.WriteAllText(rutaJson, original);
        }
    }

    private static IEnumerable<Control> Controles(Control padre)
    {
        foreach (Control hijo in padre.Controls)
        {
            yield return hijo;
            foreach (Control control in Controles(hijo)) yield return control;
        }
    }

    //cierra solo los dialogos del hilo de esta prueba
    private sealed class CerrarDialogos : IDisposable
    {
        private readonly System.Windows.Forms.Timer timer = new() { Interval = 100 };
        public int Cantidad { get; private set; }
        public string Texto { get; private set; } = "";
        public CerrarDialogos()
        {
            timer.Tick += (_, _) => EnumThreadWindows(GetCurrentThreadId(), (ventana, _) =>
            {
                var clase = new StringBuilder(256);
                GetClassName(ventana, clase, clase.Capacity);
                if (clase.ToString() != "#32770" || !IsWindowVisible(ventana)) return true;
                Cantidad++;
                EnumChildWindows(ventana, (hijo, _) =>
                {
                    var texto = new StringBuilder(2048);
                    GetWindowText(hijo, texto, texto.Capacity);
                    Texto += texto.ToString() + "\n";
                    return true;
                }, IntPtr.Zero);
                SendMessage(ventana, 0x0010, IntPtr.Zero, IntPtr.Zero);
                return true;
            }, IntPtr.Zero);
            timer.Start();
        }
        public void Dispose() { timer.Stop(); timer.Dispose(); }
    }
    private delegate bool Enumerar(IntPtr ventana, IntPtr parametro);
    [DllImport("kernel32.dll")] private static extern uint GetCurrentThreadId();
    [DllImport("user32.dll")] private static extern bool EnumThreadWindows(uint hilo, Enumerar callback, IntPtr parametro);
    [DllImport("user32.dll")] private static extern bool EnumChildWindows(IntPtr ventana, Enumerar callback, IntPtr parametro);
    [DllImport("user32.dll")] private static extern bool IsWindowVisible(IntPtr ventana);
    [DllImport("user32.dll", CharSet = CharSet.Unicode)] private static extern int GetClassName(IntPtr ventana, StringBuilder texto, int longitud);
    [DllImport("user32.dll", CharSet = CharSet.Unicode)] private static extern int GetWindowText(IntPtr ventana, StringBuilder texto, int longitud);
    [DllImport("user32.dll")] private static extern IntPtr SendMessage(IntPtr ventana, uint mensaje, IntPtr wParam, IntPtr lParam);
}
