namespace MiniProyecto_SPAF_Apache.Dominio;

public class Recepcion
{
    private readonly long _id;
    private readonly long _loteId;
    private readonly int _indicePaquete;
    private readonly string _codigoPaquete;
    private readonly DateTimeOffset _fechaRecepcion;
    private readonly string _recibidoPor;
    private readonly string _observaciones;
    public long Id => _id;
    public long LoteId => _loteId;
    public int IndicePaquete => _indicePaquete;
    public string CodigoPaquete => _codigoPaquete;
    public DateTimeOffset FechaRecepcion => _fechaRecepcion;
    public string RecibidoPor => _recibidoPor;
    public string Observaciones => _observaciones;

    public Recepcion(long id, long loteId, int indicePaquete, string codigoPaquete,
        DateTimeOffset fechaRecepcion, string recibidoPor, string observaciones)
    {
        _id = id;
        _loteId = loteId;
        _indicePaquete = indicePaquete;
        _codigoPaquete = codigoPaquete;
        _fechaRecepcion = fechaRecepcion;
        _recibidoPor = recibidoPor;
        _observaciones = observaciones;
    }
}
