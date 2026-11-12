namespace MiniProyecto_SPAF_Apache.Dominio
{
    public class ErrorValidacion
    {
        private readonly int _numeroLinea;
        private readonly string _textoOriginal;
        private readonly string _motivo;
        private readonly CodigoErrorValidacion _codigo;

        public int NumeroLinea
        {
            get
            {
                return _numeroLinea;
            }
        }
        public string TextoOriginal
        {
            get
            {
                return _textoOriginal;
            }
        }
        public string Motivo
        {
            get
            {
                return _motivo;
            }
        }
        public CodigoErrorValidacion Codigo
        {
            get
            {
                return _codigo;
            }
        }

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

        private static string ObtenerMotivo(CodigoErrorValidacion codigo)
        {
            switch (codigo)
            {
                case CodigoErrorValidacion.LineaVacia:
                    return "La línea está vacía.";
                case CodigoErrorValidacion.CantidadCamposInvalida:
                    return "Se esperaban cinco campos separados por punto y coma.";
                case CodigoErrorValidacion.CodigoObligatorio:
                    return "El código es obligatorio.";
                case CodigoErrorValidacion.CodigoInvalido:
                    return "El código debe tener letras, un guion y dígitos, por ejemplo PACK-001.";
                case CodigoErrorValidacion.ClienteObligatorio:
                    return "El cliente es obligatorio.";
                case CodigoErrorValidacion.ZonaInvalida:
                    return "La zona no es válida.";
                case CodigoErrorValidacion.PesoInvalido:
                    return "El peso debe ser un número mayor que cero.";
                case CodigoErrorValidacion.ValorDeclaradoInvalido:
                    return "El valor declarado debe ser un número mayor o igual a cero.";
                case CodigoErrorValidacion.CalculoInvalido:
                    return "El cálculo del flete excede los límites numéricos o es inválido.";
                default:
                    return "Error de validación desconocido.";
            }
        }
    }
}
