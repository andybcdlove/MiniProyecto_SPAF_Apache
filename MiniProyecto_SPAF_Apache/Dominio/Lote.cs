namespace MiniProyecto_SPAF_Apache.Dominio
{
    public class Lote
    {
        private readonly IReadOnlyList<Paquete> _paquetes;
        private readonly IReadOnlyList<ErrorValidacion> _errores;
        private readonly DateTime _fechaProcesamiento;
        private readonly decimal _total;

        public IReadOnlyList<Paquete> Paquetes => _paquetes;
        public IReadOnlyList<ErrorValidacion> Errores => _errores;
        public DateTime FechaProcesamiento => _fechaProcesamiento;
        public int CantidadValidos => _paquetes.Count;
        public int CantidadInvalidos => _errores.Count;
        public decimal Total => _total;

        internal Lote(Paquete[] paquetes, ErrorValidacion[] errores, decimal total)
        {
            _paquetes = Array.AsReadOnly(paquetes);
            _errores = Array.AsReadOnly(errores);
            _fechaProcesamiento = DateTime.Now;
            _total = total;
        }
    }
}
