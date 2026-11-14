namespace MiniProyecto_SPAF_Apache.Dominio
{
    public class Paquete
    {
        private readonly string _codigo;
        private readonly string _cliente;
        private readonly string _zona;
        private readonly decimal _peso;
        private readonly decimal _valorDeclarado;
        private decimal _subtotalPeso;
        private decimal _recargoZona;
        private decimal _penalizacionPeso;
        private decimal _seguro;
        private decimal _costoFijo;
        private decimal _iva;
        private decimal _total;

        public string Codigo
        {
            get
            {
                return _codigo;
            }
        }
        public string Cliente
        {
            get
            {
                return _cliente;
            }
        }
        public string Zona
        {
            get
            {
                return _zona;
            }
        }
        public decimal Peso
        {
            get
            {
                return _peso;
            }
        }
        public decimal ValorDeclarado
        {
            get
            {
                return _valorDeclarado;
            }
        }
        public decimal SubtotalPeso
        {
            get
            {
                return _subtotalPeso;
            }
            set
            {
                _subtotalPeso = value;
            }
        }
        public decimal RecargoZona
        {
            get
            {
                return _recargoZona;
            }
            set
            {
                _recargoZona = value;
            }
        }
        public decimal PenalizacionPeso
        {
            get
            {
                return _penalizacionPeso;
            }
            set
            {
                _penalizacionPeso = value;
            }
        }
        public decimal Seguro
        {
            get
            {
                return _seguro;
            }
            set
            {
                _seguro = value;
            }
        }
        public decimal CostoFijo
        {
            get
            {
                return _costoFijo;
            }
            set
            {
                _costoFijo = value;
            }
        }
        public decimal Iva
        {
            get
            {
                return _iva;
            }
            set
            {
                _iva = value;
            }
        }
        public decimal Total
        {
            get
            {
                return _total;
            }
            set
            {
                _total = value;
            }
        }

        public Paquete(string codigo, string cliente, string zona, decimal peso, decimal valorDeclarado)
        {
            _codigo = codigo;
            _cliente = cliente;
            _zona = zona;
            _peso = peso;
            _valorDeclarado = valorDeclarado;
        }
    }
}
