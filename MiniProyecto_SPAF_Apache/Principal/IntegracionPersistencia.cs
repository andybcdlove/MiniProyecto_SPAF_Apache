using System.Text.Json;
using Microsoft.Data.Sqlite;

namespace MiniProyecto_SPAF_Apache.Principal;

// Utilidades de presentación compartidas; no realizan cálculos ni acceso a archivos.
internal static class IntegracionPersistencia
{
    public static void Ejecutar(Form ventana, bool ingles, Action accion)
    {
        try { accion(); }
        catch (Exception error) when (error is SqliteException or IOException or UnauthorizedAccessException
            or JsonException or ArgumentException or InvalidOperationException or ArithmeticException or FormatException)
        {
            string mensaje = ingles
                ? "The operation could not be completed. Check configuration, file access and the selected path."
                : "No se pudo completar la operación. Revisa la configuración, los permisos y la ruta seleccionada.";
            MessageBox.Show(ventana, mensaje + Environment.NewLine + error.Message,
                ingles ? "Error" : "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static void PrepararTabla(DataGridView tabla)
    {
        tabla.ReadOnly = true;
        tabla.AllowUserToAddRows = false;
        tabla.AllowUserToDeleteRows = false;
        tabla.MultiSelect = false;
        tabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        // El índice de fila debe conservar la relación con el arreglo mostrado.
        foreach (DataGridViewColumn columna in tabla.Columns)
            columna.SortMode = DataGridViewColumnSortMode.NotSortable;
    }

}
