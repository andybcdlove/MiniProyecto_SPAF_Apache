using System;
using System.IO;
using System.Text.Json;
using MiniProyecto_SPAF_Apache.Dominio;

namespace MiniProyecto_SPAF_Apache.Servicios.Persistencia
{
    public class ConfiguracionServicio
    {
        public ConfiguracionTarifas CargarConfiguracion()
        {
            //ubica el archivo
            string ruta = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "appsettings.json"
            );

            //comprueba que exista
            if (!File.Exists(ruta))
            {
                throw new FileNotFoundException(
                    "No se encontró el archivo de tarifas.",
                    ruta
                );
            }

            //lee el archivo
            string contenido = File.ReadAllText(ruta);

            //comprueba la estructura y los tres campos
            using (JsonDocument documento = JsonDocument.Parse(contenido))
            {
                JsonElement raiz = documento.RootElement;

                if (raiz.ValueKind != JsonValueKind.Object)
                {
                    throw new InvalidDataException(
                        "La configuración debe estar dentro de llaves { }."
                    );
                }

                JsonElement campo;

                if (!raiz.TryGetProperty("PrecioBasePorKilogramo", out campo))
                {
                    throw new InvalidDataException(
                        "Falta el precio base por kilogramo."
                    );
                }

                if (!raiz.TryGetProperty("TasaIva", out campo))
                {
                    throw new InvalidDataException(
                        "Falta la tasa de IVA."
                    );
                }

                if (!raiz.TryGetProperty("CostoFijoEnvio", out campo))
                {
                    throw new InvalidDataException(
                        "Falta el costo fijo de envío."
                    );
                }
            }

            //convierte el texto en un objeto de tarifas
            ConfiguracionTarifas? configuracion =
                JsonSerializer.Deserialize<ConfiguracionTarifas>(contenido);

            if (configuracion == null)
            {
                throw new InvalidDataException(
                    "El archivo no contiene una configuración válida."
                );
            }

            //valida los valores de las tarifas
            if (configuracion.PrecioBasePorKilogramo <= 0)
            {
                throw new InvalidDataException(
                    "El precio por kilogramo debe ser mayor que cero."
                );
            }

            if (configuracion.TasaIva < 0 || configuracion.TasaIva > 1)
            {
                throw new InvalidDataException(
                    "La tasa de IVA debe estar entre 0 y 1."
                );
            }

            if (configuracion.CostoFijoEnvio < 0)
            {
                throw new InvalidDataException(
                    "El costo fijo de envío no puede ser negativo."
                );
            }

            //devuelve las tarifas
            return configuracion;
        }
    }
}