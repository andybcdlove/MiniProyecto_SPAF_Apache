using System;
using System.Collections.Generic;
using System.Text;
using MiniProyecto_SPAF_Apache.Dominio;
using MiniProyecto_SPAF_Apache.Servicios.Persistencia;

namespace MiniProyecto_SPAF_Apache.Servicios.Logica
{
    public class ServicioEnvios
    {
        private ConfiguracionTarifas _configuracion;
        private CalculadoraFlete _calculadora;
        private ProcesadorLotes _procesador;

        public ServicioEnvios()
        {
            //carga las tarifas
            ConfiguracionServicio servicioConfiguracion =
                new ConfiguracionServicio();

            _configuracion = servicioConfiguracion.CargarConfiguracion();

            //prepara los servicios
            _calculadora = new CalculadoraFlete();
            _procesador = new ProcesadorLotes();
        }

        public Lote ProcesarLote(string texto)
        {
            //procesa el texto utilizando el calculo del flete
            return _procesador.Procesar(texto, CalcularPaquete);
        }

        private decimal CalcularPaquete(Paquete paquete)
        {
            //calcula el desglose y devuelve el total
            _calculadora.CalcularDesglose(paquete, _configuracion);

            return paquete.Total;
        }
    }
}
