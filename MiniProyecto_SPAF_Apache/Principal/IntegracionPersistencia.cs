using System.Text.Json;
using Microsoft.Data.Sqlite;
using MiniProyecto_SPAF_Apache.Dominio;

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

    public static void MostrarPaquetes(DataGridView tabla, IReadOnlyList<Paquete> paquetes)
    {
        tabla.Rows.Clear();
        foreach (Paquete p in paquetes)
            tabla.Rows.Add(p.Codigo, p.Cliente, p.Zona, p.Peso, p.ValorDeclarado, p.Total);
    }

    public static void MostrarDetalle(GroupBox panel, Paquete? p)
    {
        string[] nombres = ["lCodigo", "lCliente", "lZona", "lPeso", "lValorDeclarado", "lSubtotalPeso",
            "lRecargoZona", "lPenalizacion", "lSeguro", "lCostoFijo", "lIva", "lTotalPaquete"];
        object?[] valores = [p?.Codigo,p?.Cliente,p?.Zona,p?.Peso,p?.ValorDeclarado,p?.SubtotalPeso,
            p?.RecargoZona,p?.PenalizacionPeso,p?.Seguro,p?.CostoFijo,p?.Iva,p?.Total];
        for (int i = 0; i < nombres.Length; i++)
        {
            var etiqueta = (Label)panel.Controls[nombres[i]]!;
            etiqueta.Tag ??= etiqueta.Text.Split(':')[0];
            etiqueta.Text = etiqueta.Tag + ": " + (valores[i]?.ToString() ?? "—");
        }
    }
}
