namespace MiniProyecto_SPAF_Apache.Dominio
{
    public class ErrorValidacion
    {
        private readonly int _numeroLinea;
        private readonly string _textoOriginal;
        private readonly string _motivo;

        public int NumeroLinea => _numeroLinea;
        public string TextoOriginal => _textoOriginal;
        public string Motivo => _motivo;

        public ErrorValidacion(int numeroLinea, string textoOriginal, string motivo)
        {
            _numeroLinea = numeroLinea;
            _textoOriginal = textoOriginal;
            _motivo = motivo;
        }
    }
}
