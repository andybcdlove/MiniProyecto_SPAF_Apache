namespace MiniProyecto_SPAF_Apache.Dominio
{
    public class ErrorValidacion
    {
        private readonly int _numeroLinea;
        private readonly string _textoOriginal;
        private readonly string _motivo;
        private readonly CodigoErrorValidacion _codigo;

        public int NumeroLinea => _numeroLinea;
        public string TextoOriginal => _textoOriginal;
        public string Motivo => _motivo;
        public CodigoErrorValidacion Codigo => _codigo;

        public ErrorValidacion(int numeroLinea, string textoOriginal, string motivo)
            : this(numeroLinea, textoOriginal, CodigoErrorValidacion.Desconocido, motivo)
        {
        }

        public ErrorValidacion(int numeroLinea, string textoOriginal, CodigoErrorValidacion codigo)
            : this(numeroLinea, textoOriginal, codigo, ObtenerMotivo(codigo))
        {
        }

        private ErrorValidacion(int numeroLinea, string textoOriginal, CodigoErrorValidacion codigo, string motivo)
        {
            _numeroLinea = numeroLinea;
            _textoOriginal = textoOriginal;
            _codigo = codigo;
            _motivo = motivo;
        }

        private static string ObtenerMotivo(CodigoErrorValidacion codigo) => codigo switch
        {
            CodigoErrorValidacion.LineaVacia => "La línea está vacía.",
            CodigoErrorValidacion.CantidadCamposInvalida => "Se esperaban cinco campos separados por punto y coma.",
            CodigoErrorValidacion.CodigoObligatorio => "El código es obligatorio.",
            CodigoErrorValidacion.CodigoInvalido => "El código debe tener letras, un guion y dígitos, por ejemplo PACK-001.",
            CodigoErrorValidacion.ClienteObligatorio => "El cliente es obligatorio.",
            CodigoErrorValidacion.ZonaInvalida => "La zona no es válida.",
            CodigoErrorValidacion.PesoInvalido => "El peso debe ser un número mayor que cero.",
            CodigoErrorValidacion.ValorDeclaradoInvalido => "El valor declarado debe ser un número mayor o igual a cero.",
            CodigoErrorValidacion.CalculoInvalido => "El cálculo del flete excede los límites numéricos o es inválido.",
            _ => "Error de validación desconocido."
        };
    }
}
