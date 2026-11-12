using System;
using MiniProyecto_SPAF_Apache.Dominio;

namespace MiniProyecto_SPAF_Apache.Servicios.Logica
{
    public class CalculadoraFlete
    {
        public void CalcularDesglose(
            Paquete paquete,
            ConfiguracionTarifas configuracion)
        {
            //calcula el costo por peso
            paquete.SubtotalPeso =
                paquete.Peso * configuracion.PrecioBasePorKilogramo;

            //obtiene el porcentaje de la zona
            decimal porcentajeZona;

            switch (paquete.Zona.Trim().ToUpperInvariant())
            {
                case "ZONA A":
                    porcentajeZona = 0.05m;
                    break;

                case "ZONA B":
                    porcentajeZona = 0.10m;
                    break;

                case "ZONA C":
                    porcentajeZona = 0.18m;
                    break;

                default:
                    throw new ArgumentException(
                        "La zona del paquete no es válida."
                    );
            }

            //calcula el recargo por zona
            paquete.RecargoZona =
                paquete.SubtotalPeso * porcentajeZona;
            //calcula la penalizacion por exceso de peso
            paquete.PenalizacionPeso = 0m;

            if (paquete.Peso > 20m)
            {
                decimal kilosExtra = paquete.Peso - 20m;

                paquete.PenalizacionPeso =
                    kilosExtra * configuracion.PrecioBasePorKilogramo * 0.25m;
            }

            //calcula el seguro
            paquete.Seguro = 0m;

            if (paquete.ValorDeclarado > 1000m)
            {
                paquete.Seguro = paquete.ValorDeclarado * 0.02m;
            }

            //asigna el costo fijo
            paquete.CostoFijo = configuracion.CostoFijoEnvio;

            //redondea los importes a dos decimales
            paquete.SubtotalPeso = Math.Round(
                paquete.SubtotalPeso, 2, MidpointRounding.AwayFromZero);

            paquete.RecargoZona = Math.Round(
                paquete.RecargoZona, 2, MidpointRounding.AwayFromZero);

            paquete.PenalizacionPeso = Math.Round(
                paquete.PenalizacionPeso, 2, MidpointRounding.AwayFromZero);

            paquete.Seguro = Math.Round(
                paquete.Seguro, 2, MidpointRounding.AwayFromZero);

            paquete.CostoFijo = Math.Round(
                paquete.CostoFijo, 2, MidpointRounding.AwayFromZero);

            //suma los conceptos antes del iva
            decimal subtotal = paquete.SubtotalPeso
                + paquete.RecargoZona
                + paquete.PenalizacionPeso
                + paquete.Seguro
                + paquete.CostoFijo;

            //calcula el iva
            paquete.Iva = Math.Round(
                subtotal * configuracion.TasaIva,
                2,
                MidpointRounding.AwayFromZero);

            //calcula el total del paquete
            paquete.Total = subtotal + paquete.Iva;
        }
    }
}