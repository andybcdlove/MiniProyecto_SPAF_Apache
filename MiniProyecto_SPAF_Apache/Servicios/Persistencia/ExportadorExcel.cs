using ClosedXML.Excel;
using MiniProyecto_SPAF_Apache.Dominio;

namespace MiniProyecto_SPAF_Apache.Servicios.Persistencia;

public class ExportadorExcel
{
    public void Exportar(Lote lote, string rutaDestino)
    {
        ArgumentNullException.ThrowIfNull(lote);
        ArgumentException.ThrowIfNullOrWhiteSpace(rutaDestino);
        using var libro = new XLWorkbook();
        var hoja = libro.AddWorksheet("Envíos");
        hoja.ShowGridLines = false;
        hoja.Style.Font.FontName = "Calibri";
        hoja.Style.Font.FontSize = 11;
        var amarillo = XLColor.FromHtml("FFD700");
        var vino = XLColor.FromHtml("9C1737");
        hoja.Range("A1:L1").Merge().Value = "PAQUETERÍA | Reporte de envíos";
        hoja.Range("A1:L1").Style.Fill.BackgroundColor = amarillo;
        hoja.Range("A1:L1").Style.Font.FontColor = vino;
        hoja.Range("A1:L1").Style.Font.FontSize = 20;
        hoja.Range("A1:L1").Style.Font.Bold = true;
        hoja.Row(1).Height = 38;
        hoja.Range("A2:L2").Merge().Value = "Fecha de procesamiento: "
            + lote.FechaProcesamiento.ToString("dd/MM/yyyy HH:mm")
            + "  |  Lote: " + (lote.Id?.ToString() ?? "Sin guardar");
        hoja.Range("A3:L3").Merge().Value = $"Paquetes válidos: {lote.CantidadValidos}  |  Líneas con error: {lote.CantidadInvalidos}  |  Importes en MXN";
        string[] encabezados = ["Código", "Cliente", "Zona", "Peso (kg)", "Valor declarado",
            "Subtotal por peso", "Recargo por zona", "Penalización por peso", "Seguro", "Costo fijo", "IVA", "Total"];
        for (int i = 0; i < encabezados.Length; i++) hoja.Cell(5, i + 1).Value = encabezados[i];
        for (int i = 0; i < lote.Paquetes.Count; i++)
        {
            Paquete p = lote.Paquetes[i];
            int fila = i + 6;
            hoja.Cell(fila, 1).Value = p.Codigo;
            hoja.Cell(fila, 2).Value = p.Cliente;
            hoja.Cell(fila, 3).Value = p.Zona;
            decimal[] numeros = [p.Peso, p.ValorDeclarado, p.SubtotalPeso, p.RecargoZona,
                p.PenalizacionPeso, p.Seguro, p.CostoFijo, p.Iva, p.Total];
            for (int j = 0; j < numeros.Length; j++) hoja.Cell(fila, j + 4).Value = numeros[j];
            hoja.Range(fila, 1, fila, 12).Style.Fill.BackgroundColor =
                i % 2 == 0 ? XLColor.FromHtml("FFF8DB") : XLColor.White;
            hoja.Range(fila, 1, fila, 12).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            hoja.Row(fila).Height = 30;
        }
        int ultimaFila = lote.Paquetes.Count + 5;
        if (lote.Paquetes.Count > 0)
        {
            var tabla = hoja.Range(5, 1, ultimaFila, 12).CreateTable("Paquetes");
            tabla.Theme = XLTableTheme.None;
            tabla.ShowAutoFilter = true;
            hoja.Range(6, 4, ultimaFila, 4).Style.NumberFormat.Format = "0.###";
            hoja.Range(6, 5, ultimaFila, 12).Style.NumberFormat.Format = "\"$\" #,##0.00";
            hoja.Range(6, 1, ultimaFila, 3).Style.Alignment.WrapText = true;
        }
        var cabecera = hoja.Range("A5:L5");
        cabecera.Style.Fill.BackgroundColor = vino;
        cabecera.Style.Font.FontColor = XLColor.White;
        cabecera.Style.Font.Bold = true;
        cabecera.Style.Alignment.WrapText = true;
        cabecera.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        hoja.Row(5).Height = 36;
        int filaTotal = ultimaFila + 2;
        hoja.Range(filaTotal, 9, filaTotal, 11).Merge().Value = "TOTAL DEL LOTE";
        hoja.Cell(filaTotal, 12).Value = lote.Total;
        hoja.Cell(filaTotal, 12).Style.NumberFormat.Format = "\"$\" #,##0.00";
        hoja.Range(filaTotal, 9, filaTotal, 12).Style.Fill.BackgroundColor = amarillo;
        hoja.Range(filaTotal, 9, filaTotal, 12).Style.Font.Bold = true;
        hoja.Row(filaTotal).Height = 28;
        double[] anchos = [16, 30, 14, 12, 18, 18, 18, 20, 16, 16, 16, 18];
        for (int i = 0; i < anchos.Length; i++) hoja.Column(i + 1).Width = anchos[i];
        hoja.SheetView.FreezeRows(5);
        hoja.PageSetup.PageOrientation = XLPageOrientation.Landscape;
        hoja.PageSetup.PagesWide = 1;
        hoja.PageSetup.PagesTall = 0;
        libro.SaveAs(rutaDestino);
    }
}
