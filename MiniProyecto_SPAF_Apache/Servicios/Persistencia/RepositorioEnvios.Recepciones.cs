using System.Globalization;
using MiniProyecto_SPAF_Apache.Dominio;

namespace MiniProyecto_SPAF_Apache.Servicios.Persistencia;

public partial class RepositorioEnvios
{
    public long RegistrarRecepcion(long loteId, int indicePaquete, string recibidoPor, string observaciones = "")
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(recibidoPor);
        ArgumentNullException.ThrowIfNull(observaciones);
        if (loteId <= 0 || indicePaquete < 0) throw new ArgumentOutOfRangeException(nameof(indicePaquete));
        Inicializar();
        using var conexion = Abrir();
        using var transaccion = conexion.BeginTransaction();
        using var buscar = conexion.CreateCommand();
        buscar.Transaction = transaccion;
        buscar.CommandText = "SELECT Id FROM Paquetes WHERE LoteId=@lote AND Orden=@orden";
        buscar.Parameters.AddWithValue("@lote", loteId);
        buscar.Parameters.AddWithValue("@orden", indicePaquete);
        object? resultado = buscar.ExecuteScalar();
        if (resultado == null) throw new InvalidOperationException("El paquete no existe en el lote guardado.");
        long paqueteId = (long)resultado;
        using var comprobar = conexion.CreateCommand();
        comprobar.Transaction = transaccion;
        comprobar.CommandText = "SELECT COUNT(*) FROM Recepciones WHERE PaqueteId=@id";
        comprobar.Parameters.AddWithValue("@id", paqueteId);
        if ((long)comprobar.ExecuteScalar()! > 0)
            throw new InvalidOperationException("El paquete ya tiene una recepción registrada.");
        long id = Insertar(conexion, transaccion, "Recepciones", "PaqueteId,Fecha,RecibidoPor,Observaciones",
            paqueteId, DateTimeOffset.UtcNow.ToString("O", CultureInfo.InvariantCulture), recibidoPor.Trim(), observaciones.Trim());
        transaccion.Commit();
        return id;
    }

    public Recepcion[] ObtenerRecepciones(long loteId)
    {
        Inicializar();
        using var conexion = Abrir();
        using var comando = conexion.CreateCommand();
        comando.CommandText = """
            SELECT r.Id,p.Orden,p.Codigo,r.Fecha,r.RecibidoPor,r.Observaciones
            FROM Recepciones r JOIN Paquetes p ON r.PaqueteId=p.Id
            WHERE p.LoteId=@id ORDER BY r.Id
            """;
        comando.Parameters.AddWithValue("@id", loteId);
        using var lector = comando.ExecuteReader();
        Recepcion[] recepciones = new Recepcion[5];
        int cantidad = 0;
        while (lector.Read())
            Agregar(ref recepciones, ref cantidad, new Recepcion(lector.GetInt64(0), loteId,
                lector.GetInt32(1), lector.GetString(2), DateTimeOffset.Parse(lector.GetString(3),
                CultureInfo.InvariantCulture), lector.GetString(4), lector.GetString(5)));
        return Recortar(recepciones,cantidad);
    }
}
