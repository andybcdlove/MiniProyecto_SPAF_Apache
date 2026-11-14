using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProyecto_SPAF_Apache.Servicios.Persistencia
{
    using System.Globalization;
    using MiniProyecto_SPAF_Apache.Dominio;

    public class ExportadorCSV
    {
        public void Exportar(Lote lote, string rutaDestino)
        {
            ArgumentNullException.ThrowIfNull(lote);
            ArgumentException.ThrowIfNullOrWhiteSpace(rutaDestino);
            using var escritor = new StreamWriter(rutaDestino, false, new UTF8Encoding(true));
            escritor.NewLine = "\r\n";
            escritor.WriteLine("Codigo,Cliente,Zona,Peso,ValorDeclarado,SubtotalPeso,RecargoZona,PenalizacionPeso,Seguro,CostoFijo,Iva,Total");
            foreach (Paquete p in lote.Paquetes)
            {
                object[] valores = [p.Codigo,p.Cliente,p.Zona,p.Peso,p.ValorDeclarado,p.SubtotalPeso,
                    p.RecargoZona,p.PenalizacionPeso,p.Seguro,p.CostoFijo,p.Iva,p.Total];
                string[] campos = new string[valores.Length];
                for (int i = 0; i < valores.Length; i++)
                {
                    string texto = valores[i] is decimal numero ? numero.ToString(CultureInfo.InvariantCulture) : (string)valores[i];
                    campos[i] = "\"" + texto.Replace("\"", "\"\"") + "\"";
                }
                escritor.WriteLine(string.Join(',', campos));
            }
        }
    }
}
