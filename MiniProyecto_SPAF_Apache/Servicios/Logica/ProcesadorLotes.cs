using System.Globalization;
using System.Text.RegularExpressions;
using MiniProyecto_SPAF_Apache.Dominio;

namespace MiniProyecto_SPAF_Apache.Servicios.Logica
{
    public class ProcesadorLotes
    {
        private static readonly Regex _patronCodigo = new Regex(
            @"\A[A-Z]+-[0-9]+\z", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        private readonly List<Lote> _historial = new List<Lote>();

        public IReadOnlyList<Lote> Historial
        {
            get
            {
                return _historial.AsReadOnly();
            }
        }

        public Lote Procesar(string texto, Func<Paquete, decimal> calcularTotal)
        {
            ArgumentNullException.ThrowIfNull(texto);
            ArgumentNullException.ThrowIfNull(calcularTotal);

            Paquete[] paquetes = new Paquete[5];
            ErrorValidacion[] errores = new ErrorValidacion[5];
            int cantidadPaquetes = 0;
            int cantidadErrores = 0;
            int numeroLinea = 0;
            decimal totalLote = 0;

            if (texto.Length == 0)
            {
                AgregarError(ref errores, ref cantidadErrores, 1, texto, CodigoErrorValidacion.LineaVacia);
            }

            using (StringReader lector = new StringReader(texto))
            {
                string? linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    numeroLinea++;
                    string[] campos = linea.Split(';');
                    for (int i = 0; i < campos.Length; i++)
                    {
                        campos[i] = campos[i].Trim();
                    }

                    decimal peso;
                    decimal valor;
                    CodigoErrorValidacion? codigoError = ValidarCampos(campos, out peso, out valor);
                    if (codigoError.HasValue)
                    {
                        AgregarError(ref errores, ref cantidadErrores, numeroLinea, linea, codigoError.Value);
                        continue;
                    }

                    Paquete paquete = new Paquete(campos[0].ToUpperInvariant(), campos[1],
                        campos[2].ToUpperInvariant(), peso, valor);
                    try
                    {
                        paquete.Total = calcularTotal(paquete);
                        totalLote += paquete.Total;
                    }
                    catch (ArithmeticException)
                    {
                        AgregarError(ref errores, ref cantidadErrores, numeroLinea, linea,
                            CodigoErrorValidacion.CalculoInvalido);
                        continue;
                    }

                    AgregarPaquete(ref paquetes, ref cantidadPaquetes, paquete);
                }
            }

            OrdenarPorTotal(paquetes, cantidadPaquetes);

            // El lote solo conserva las posiciones ocupadas.
            Paquete[] paquetesDelLote = CopiarPaquetes(paquetes, cantidadPaquetes, cantidadPaquetes);
            ErrorValidacion[] erroresDelLote = CopiarErrores(errores, cantidadErrores, cantidadErrores);
            Lote lote = new Lote(paquetesDelLote, erroresDelLote, totalLote);
            _historial.Add(lote);
            return lote;
        }

        private static CodigoErrorValidacion? ValidarCampos(string[] campos, out decimal peso, out decimal valor)
        {
            peso = 0;
            valor = 0;

            if (campos.Length == 1 && campos[0].Length == 0)
            {
                return CodigoErrorValidacion.LineaVacia;
            }

            if (campos.Length != 5)
            {
                return CodigoErrorValidacion.CantidadCamposInvalida;
            }

            if (campos[0].Length == 0)
            {
                return CodigoErrorValidacion.CodigoObligatorio;
            }

            if (!_patronCodigo.IsMatch(campos[0]))
            {
                return CodigoErrorValidacion.CodigoInvalido;
            }

            if (campos[1].Length == 0)
            {
                return CodigoErrorValidacion.ClienteObligatorio;
            }

            string zona = campos[2].ToUpperInvariant();
            if (zona != "ZONA A" && zona != "ZONA B" && zona != "ZONA C")
            {
                return CodigoErrorValidacion.ZonaInvalida;
            }

            if (!LeerDecimal(campos[3], out peso) || peso <= 0)
            {
                return CodigoErrorValidacion.PesoInvalido;
            }

            if (!LeerDecimal(campos[4], out valor) || valor < 0)
            {
                return CodigoErrorValidacion.ValorDeclaradoInvalido;
            }

            return null;
        }

        private static bool LeerDecimal(string texto, out decimal numero)
        {
            string textoNormalizado = texto.Replace(',', '.');
            const NumberStyles estilo = NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint;
            return decimal.TryParse(textoNormalizado, estilo, CultureInfo.InvariantCulture, out numero);
        }

        private static void AgregarPaquete(ref Paquete[] paquetes, ref int cantidad, Paquete paquete)
        {
            if (cantidad == paquetes.Length)
            {
                paquetes = CopiarPaquetes(paquetes, cantidad, paquetes.Length * 2);
            }

            paquetes[cantidad] = paquete;
            cantidad++;
        }

        private static void AgregarError(ref ErrorValidacion[] errores, ref int cantidad,
            int numeroLinea, string textoOriginal, CodigoErrorValidacion codigo)
        {
            if (cantidad == errores.Length)
            {
                errores = CopiarErrores(errores, cantidad, errores.Length * 2);
            }

            errores[cantidad] = new ErrorValidacion(numeroLinea, textoOriginal, codigo);
            cantidad++;
        }

        private static Paquete[] CopiarPaquetes(Paquete[] origen, int cantidad, int capacidad)
        {
            Paquete[] copia = new Paquete[capacidad];
            for (int i = 0; i < cantidad; i++)
            {
                copia[i] = origen[i];
            }

            return copia;
        }

        private static ErrorValidacion[] CopiarErrores(ErrorValidacion[] origen, int cantidad, int capacidad)
        {
            ErrorValidacion[] copia = new ErrorValidacion[capacidad];
            for (int i = 0; i < cantidad; i++)
            {
                copia[i] = origen[i];
            }

            return copia;
        }

        private static void OrdenarPorTotal(Paquete[] paquetes, int cantidad)
        {
            // Inserta cada paquete en la parte que ya está ordenada.
            for (int i = 1; i < cantidad; i++)
            {
                Paquete actual = paquetes[i];
                int anterior = i - 1;
                while (anterior >= 0 && paquetes[anterior].Total < actual.Total)
                {
                    paquetes[anterior + 1] = paquetes[anterior];
                    anterior--;
                }

                paquetes[anterior + 1] = actual;
            }
        }
    }
}
