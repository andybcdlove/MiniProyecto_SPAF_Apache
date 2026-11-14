using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProyecto_SPAF_Apache.Servicios.Persistencia
{
    using System.Globalization;
    using Microsoft.Data.Sqlite;
    using MiniProyecto_SPAF_Apache.Dominio;

    public partial class RepositorioEnvios
    {
        private readonly string _ruta;
        private static readonly string[] _campos = ["SubtotalPeso", "RecargoZona", "PenalizacionPeso", "Seguro", "CostoFijo", "Iva", "Total"];

        public RepositorioEnvios(string? ruta = null)
        {
            _ruta = Path.GetFullPath(ruta ?? Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData), "MiniProyecto_SPAF_Apache", "envios.db"));
        }

        private SqliteConnection Abrir()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_ruta)!);
            var conexion = new SqliteConnection(new SqliteConnectionStringBuilder
                { DataSource = _ruta, ForeignKeys = true }.ToString());
            try { conexion.Open(); return conexion; }
            catch { conexion.Dispose(); throw; }
        }

        public void Inicializar()
        {
            using var conexion = Abrir();
            using var comando = conexion.CreateCommand();
            comando.CommandText = """
                CREATE TABLE IF NOT EXISTS Lotes(Id INTEGER PRIMARY KEY,Fecha TEXT NOT NULL,Total TEXT NOT NULL);
                CREATE TABLE IF NOT EXISTS Paquetes(Id INTEGER PRIMARY KEY,LoteId INTEGER NOT NULL REFERENCES Lotes(Id),
                    Orden INTEGER NOT NULL,Codigo TEXT NOT NULL,Cliente TEXT NOT NULL,Zona TEXT NOT NULL,
                    Peso TEXT NOT NULL,ValorDeclarado TEXT NOT NULL,UNIQUE(LoteId,Orden));
                CREATE TABLE IF NOT EXISTS Desgloses(PaqueteId INTEGER PRIMARY KEY REFERENCES Paquetes(Id),
                    SubtotalPeso TEXT NOT NULL,RecargoZona TEXT NOT NULL,PenalizacionPeso TEXT NOT NULL,
                    Seguro TEXT NOT NULL,CostoFijo TEXT NOT NULL,Iva TEXT NOT NULL,Total TEXT NOT NULL);
                CREATE TABLE IF NOT EXISTS Errores(LoteId INTEGER NOT NULL REFERENCES Lotes(Id),Orden INTEGER NOT NULL,
                    NumeroLinea INTEGER NOT NULL,TextoOriginal TEXT NOT NULL,Codigo INTEGER NOT NULL,Motivo TEXT NOT NULL,
                    PRIMARY KEY(LoteId,Orden));
                CREATE TABLE IF NOT EXISTS Recepciones(Id INTEGER PRIMARY KEY,
                    PaqueteId INTEGER NOT NULL UNIQUE REFERENCES Paquetes(Id),
                    Fecha TEXT NOT NULL,RecibidoPor TEXT NOT NULL,Observaciones TEXT NOT NULL);
                """;
            comando.ExecuteNonQuery();
        }

        private static long Insertar(SqliteConnection conexion, SqliteTransaction transaccion,
            string tabla, string columnas, params object[] valores)
        {
            using var comando = conexion.CreateCommand();
            comando.Transaction = transaccion;
            string[] parametros = new string[valores.Length];
            for (int i = 0; i < valores.Length; i++)
            {
                parametros[i] = "@p" + i;
                comando.Parameters.AddWithValue(parametros[i], valores[i] is decimal numero
                    ? numero.ToString(CultureInfo.InvariantCulture) : valores[i]);
            }
            // Los nombres de tabla y columnas son constantes internas.
            comando.CommandText = $"INSERT INTO {tabla} ({columnas}) VALUES ({string.Join(',', parametros)}); SELECT last_insert_rowid();";
            return (long)comando.ExecuteScalar()!;
        }

        public long GuardarLote(Lote lote)
        {
            ArgumentNullException.ThrowIfNull(lote);
            if (lote.Id.HasValue) throw new InvalidOperationException("El lote ya está guardado.");
            Inicializar();
            using var conexion = Abrir();
            using var transaccion = conexion.BeginTransaction();
            long id = Insertar(conexion, transaccion, "Lotes", "Fecha,Total",
                lote.FechaProcesamiento.ToString("O", CultureInfo.InvariantCulture), lote.Total);
            for (int i = 0; i < lote.Paquetes.Count; i++)
            {
                Paquete p = lote.Paquetes[i];
                long paqueteId = Insertar(conexion, transaccion, "Paquetes",
                    "LoteId,Orden,Codigo,Cliente,Zona,Peso,ValorDeclarado",
                    id, i, p.Codigo, p.Cliente, p.Zona, p.Peso, p.ValorDeclarado);
                Insertar(conexion, transaccion, "Desgloses", "PaqueteId," + string.Join(',', _campos),
                    paqueteId, p.SubtotalPeso, p.RecargoZona, p.PenalizacionPeso, p.Seguro, p.CostoFijo, p.Iva, p.Total);
            }
            for (int i = 0; i < lote.Errores.Count; i++)
            {
                ErrorValidacion e = lote.Errores[i];
                Insertar(conexion, transaccion, "Errores", "LoteId,Orden,NumeroLinea,TextoOriginal,Codigo,Motivo",
                    id, i, e.NumeroLinea, e.TextoOriginal, (int)e.Codigo, e.Motivo);
            }
            transaccion.Commit();
            return id;
        }

        private static decimal Numero(SqliteDataReader lector, int indice) =>
            decimal.Parse(lector.GetString(indice), CultureInfo.InvariantCulture);

        public Paquete[] ObtenerPaquetes(long loteId)
        {
            Inicializar();
            using var conexion = Abrir();
            return LeerPaquetes(conexion, loteId);
        }

        private static Paquete[] LeerPaquetes(SqliteConnection conexion, long id)
        {
            using var comando = conexion.CreateCommand();
            comando.CommandText = """
                SELECT p.Codigo,p.Cliente,p.Zona,p.Peso,p.ValorDeclarado,
                    d.SubtotalPeso,d.RecargoZona,d.PenalizacionPeso,d.Seguro,d.CostoFijo,d.Iva,d.Total
                FROM Paquetes p JOIN Desgloses d ON d.PaqueteId=p.Id WHERE p.LoteId=@id ORDER BY p.Orden
                """;
            comando.Parameters.AddWithValue("@id", id);
            using var lector = comando.ExecuteReader();
            Paquete[] resultado = new Paquete[5];
            int cantidad = 0;
            while (lector.Read())
            {
                var paquete = new Paquete(lector.GetString(0), lector.GetString(1), lector.GetString(2), Numero(lector,3), Numero(lector,4))
                {
                    SubtotalPeso = Numero(lector,5), RecargoZona = Numero(lector,6), PenalizacionPeso = Numero(lector,7),
                    Seguro = Numero(lector,8), CostoFijo = Numero(lector,9), Iva = Numero(lector,10), Total = Numero(lector,11)
                };
                Agregar(ref resultado, ref cantidad, paquete);
            }
            return Recortar(resultado, cantidad);
        }

        public Lote[] ObtenerLotes()
        {
            Inicializar();
            using var conexion = Abrir();
            using var comando = conexion.CreateCommand();
            comando.CommandText = "SELECT Id,Fecha,Total FROM Lotes ORDER BY Id DESC";
            using var lector = comando.ExecuteReader();
            Lote[] resultado = new Lote[5];
            int cantidad = 0;
            while (lector.Read())
            {
                long id = lector.GetInt64(0);
                var lote = new Lote(LeerPaquetes(conexion,id), LeerErrores(conexion,id), Numero(lector,2),
                    DateTime.Parse(lector.GetString(1), CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind), id);
                Agregar(ref resultado, ref cantidad, lote);
            }
            return Recortar(resultado,cantidad);
        }

        private static ErrorValidacion[] LeerErrores(SqliteConnection conexion, long id)
        {
            using var comando = conexion.CreateCommand();
            comando.CommandText = "SELECT NumeroLinea,TextoOriginal,Codigo,Motivo FROM Errores WHERE LoteId=@id ORDER BY Orden";
            comando.Parameters.AddWithValue("@id",id);
            using var lector = comando.ExecuteReader();
            ErrorValidacion[] resultado = new ErrorValidacion[5];
            int cantidad = 0;
            while (lector.Read())
            {
                var codigo = (CodigoErrorValidacion)lector.GetInt32(2);
                var error = codigo == CodigoErrorValidacion.Desconocido
                    ? new ErrorValidacion(lector.GetInt32(0),lector.GetString(1),lector.GetString(3))
                    : new ErrorValidacion(lector.GetInt32(0),lector.GetString(1),codigo);
                Agregar(ref resultado,ref cantidad,error);
            }
            return Recortar(resultado,cantidad);
        }

        private static void Agregar<T>(ref T[] arreglo, ref int cantidad, T elemento)
        {
            if (cantidad == arreglo.Length)
            {
                T[] nuevo = new T[arreglo.Length * 2];
                for (int i = 0; i < cantidad; i++) nuevo[i] = arreglo[i];
                arreglo = nuevo;
            }
            arreglo[cantidad++] = elemento;
        }

        private static T[] Recortar<T>(T[] arreglo, int cantidad)
        {
            T[] resultado = new T[cantidad];
            for (int i = 0; i < cantidad; i++) resultado[i] = arreglo[i];
            return resultado;
        }
    }
}
