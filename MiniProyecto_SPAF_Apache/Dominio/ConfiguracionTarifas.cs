namespace MiniProyecto_SPAF_Apache.Dominio
{
    public class ConfiguracionTarifas
    {
        private decimal _precioBasePorKilogramo;
        private decimal _tasaIva;
        private decimal _costoFijoEnvio;

        public decimal PrecioBasePorKilogramo
        {
            get => _precioBasePorKilogramo;
            set => _precioBasePorKilogramo = value;
        }

        public decimal TasaIva { get => _tasaIva; set => _tasaIva = value; }
        public decimal CostoFijoEnvio { get => _costoFijoEnvio; set => _costoFijoEnvio = value; }
    }
}
