namespace MiniProyecto_SPAF_Apache.Dominio
{
    public class Lote
    {
        private readonly IReadOnlyList<Paquete> _paquetes;
        private readonly IReadOnlyList<ErrorValidacion> _errores;
        private readonly DateTime _fechaProcesamiento;
        private readonly decimal _total;
        private readonly long? _id;

        public IReadOnlyList<Paquete> Paquetes => _paquetes;
        public IReadOnlyList<ErrorValidacion> Errores => _errores;
        public DateTime FechaProcesamiento => _fechaProcesamiento;
        public int CantidadValidos => _paquetes.Count;
        public int CantidadInvalidos => _errores.Count;
        public long? Id => _id;
        public decimal Total => _total;

        internal Lote(Paquete[] paquetes, ErrorValidacion[] errores, decimal total)
            : this(paquetes, errores, total, DateTime.Now, null)
        {
        }

        public Lote(Paquete[] paquetes, ErrorValidacion[] errores, decimal total,
            DateTime fechaProcesamiento, long? id)
        {
            _paquetes = Array.AsReadOnly(paquetes);
            _errores = Array.AsReadOnly(errores);
            _fechaProcesamiento = fechaProcesamiento;
            _total = total;
            _id = id;
        }
    }
}
