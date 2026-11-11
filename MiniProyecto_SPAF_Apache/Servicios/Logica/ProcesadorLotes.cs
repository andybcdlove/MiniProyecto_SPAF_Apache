using System.Globalization;
using System.Text.RegularExpressions;
using MiniProyecto_SPAF_Apache.Dominio;

namespace MiniProyecto_SPAF_Apache.Servicios.Logica
{
    public class ProcesadorLotes
    {
        private static readonly Regex _patronCodigo = new(
            @"\A[A-Z]+-[0-9]+\z", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        private readonly List<Lote> _historial = new();

        public IReadOnlyList<Lote> Historial => _historial.AsReadOnly();


        public Lote Procesar(string texto, Func<Paquete, decimal> calcularTotal)
        {
            ArgumentNullException.ThrowIfNull(texto);
            ArgumentNullException.ThrowIfNull(calcularTotal);

            var paquetes = new Paquete[5];
            var errores = new ErrorValidacion[5];
            int cantidadPaquetes = 0;
            int cantidadErrores = 0;
            int numeroLinea = 0;
            decimal totalLote = 0;

            if (texto.Length == 0)
                Agregar(ref errores, ref cantidadErrores, new ErrorValidacion(1, texto, "La línea está vacía."));

            using var lector = new StringReader(texto);
            while (lector.ReadLine() is string linea)
            {
                numeroLinea++;
                string[] campos = linea.Split(';', StringSplitOptions.TrimEntries);
                string? motivo = Validar(campos, out decimal peso, out decimal valor);
                if (motivo != null)
                {
                    Agregar(ref errores, ref cantidadErrores, new ErrorValidacion(numeroLinea, linea, motivo));
                    continue;
                }

                var paquete = new Paquete(campos[0].ToUpperInvariant(), campos[1],
                    campos[2].ToUpperInvariant(), peso, valor);
                try
                {
                    paquete.Total = calcularTotal(paquete);
                    totalLote += paquete.Total;
                }
                catch (ArithmeticException)
                {
                    Agregar(ref errores, ref cantidadErrores,
                        new ErrorValidacion(numeroLinea, linea, "El cálculo del flete excede los límites numéricos o es inválido."));
                    continue;
                }

                Agregar(ref paquetes, ref cantidadPaquetes, paquete);
            }

            OrdenarPorTotal(paquetes, cantidadPaquetes);
            var lote = new Lote(paquetes[..cantidadPaquetes], errores[..cantidadErrores], totalLote);
            _historial.Add(lote);
            return lote;
        }

        private static string? Validar(string[] campos, out decimal peso, out decimal valor)
        {
            peso = 0;
            valor = 0;
            if (campos.Length == 1 && campos[0].Length == 0)
                return "La línea está vacía.";
            if (campos.Length != 5)
                return "Se esperaban cinco campos separados por punto y coma.";
            if (campos[0].Length == 0)
                return "El código es obligatorio.";
            if (!_patronCodigo.IsMatch(campos[0]))
                return "El código debe tener letras, un guion y dígitos, por ejemplo PACK-001.";
            if (campos[1].Length == 0)
                return "El cliente es obligatorio.";
            if (campos[2].ToUpperInvariant() is not ("ZONA A" or "ZONA B" or "ZONA C"))
                return "La zona no es válida.";
            if (!LeerDecimal(campos[3], out peso) || peso <= 0)
                return "El peso debe ser un número mayor que cero.";
            if (!LeerDecimal(campos[4], out valor) || valor < 0)
                return "El valor declarado debe ser un número mayor o igual a cero.";

            return null;
        }

        private static bool LeerDecimal(string texto, out decimal numero)
        {
            const NumberStyles estilo = NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint;
            return decimal.TryParse(texto.Replace(',', '.'), estilo, CultureInfo.InvariantCulture, out numero);
        }

        private static void Agregar<T>(ref T[] arreglo, ref int cantidad, T elemento)
        {
            if (cantidad == arreglo.Length)
            {
                var ampliado = new T[arreglo.Length * 2];
                for (int i = 0; i < cantidad; i++)
                    ampliado[i] = arreglo[i];

                arreglo = ampliado;
            }

            arreglo[cantidad] = elemento;
            cantidad++;
        }

        private static void OrdenarPorTotal(Paquete[] paquetes, int cantidad)
        {
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
