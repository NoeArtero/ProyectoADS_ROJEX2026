
using System.Data;
using System.Data.SqlClient;



namespace ProyectoADS_ROJEX.ConexionDB
{
   internal class Conexion
    {

        /// Provee: 1) Detección de instancia SQL local; 2) Verificación/creación de la BD 
        /// 3) ConnectionString lista para usar en el resto de la app.
        /// Mantiene la lógica de la Guía 9: ADO.NET + T-SQL idempotente.

      
            public const string DatabaseName = "Rojex";

            public static string? ServerName { get; private set; }
            public static string? MasterConnectionString { get; private set; }
            public static string? AppConnectionString { get; private set; }

            public static void Initialize()
            {
                if (!TryBuscarServer(out var server, out var masterCs))
                    throw new InvalidOperationException(
                        "No se encontró una instancia de SQL Server disponible. " +
                        "Instala LocalDB o habilita SQLEXPRESS/local.");

                ServerName = server;
                MasterConnectionString = masterCs;

                bool creadaAhora = AsegurarBaseCreada(DatabaseName);
                AppConnectionString = BuildDbConnectionString(server, DatabaseName);

                //System.Windows.Forms.MessageBox.Show(
                //    $"Instancia: {ServerName}\nBD: {DatabaseName}\n" +
                //    (creadaAhora ? "Resultado: BD creada" : "Resultado: BD ya existía"),
                //    "DermaCenter - Inicialización de BD");
            }


            private static bool TryBuscarServer(out string serverName, out string masterCs)
            {
                foreach (var server in BuscarCandidatosServidor())
                {
                    var cs = CrearConexionConServidor(server);
                    if (CanOpen(cs))
                    {
                        serverName = server;
                        masterCs = cs;
                        return true;
                    }
                }
                serverName = string.Empty;
                masterCs = string.Empty;
                return false;
            }

        private static IEnumerable<string> BuscarCandidatosServidor()
        {
            var list = new List<string>
    {
        @"(localdb)\MSSQLLocalDB",
        @".\SQLEXPRESS",
        $@"{Environment.MachineName}\SQLEXPRESS",
        @"localhost\SQLEXPRESS",
        "localhost",
        ".",
        Environment.MachineName
    };

            return list.Where(s => !string.IsNullOrWhiteSpace(s))
                       .Select(s => s.Trim())
                       .Distinct(StringComparer.OrdinalIgnoreCase);
        }

        private static string CrearConexionConServidor(string server) =>
                $"Server={server};Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True;Connect Timeout=3;";

            private static string BuildDbConnectionString(string server, string database) =>
                $"Server={server};Initial Catalog={database};Integrated Security=True;TrustServerCertificate=True;";

            private static bool CanOpen(string cs)
            {
                try
                {
                    using var cn = new SqlConnection(cs);
                    cn.Open();
                    using var cmd = new SqlCommand("SELECT 1", cn);
                    _ = cmd.ExecuteScalar();
                    return true;
                }
                catch { return false; }
            }

            // =======================  CREACIÓN / VERIFICACIÓN BD  =======================


            private static bool AsegurarBaseCreada(string dbName)
            {
                if (MasterConnectionString is null)
                    throw new InvalidOperationException("MasterConnectionString no está inicializada.");

                using var cn = new SqlConnection(MasterConnectionString);
                cn.Open();

                // 1) ¿Existía antes?
                object? idBefore;
                using (var checkBefore = new SqlCommand("SELECT DB_ID(@db)", cn))
                {
                    checkBefore.Parameters.AddWithValue("@db", dbName);
                    idBefore = checkBefore.ExecuteScalar();
                }
                bool existedBefore = (idBefore != null && idBefore != DBNull.Value);

                // 2) Si no existía, crearla (idempotente)
                if (!existedBefore)
                {
                    var createSql = @"
DECLARE @sql nvarchar(max) = N'CREATE DATABASE ' + QUOTENAME(@db) + N';';
EXEC (@sql);";
                    using var create = new SqlCommand(createSql, cn);
                    create.Parameters.AddWithValue("@db", dbName);
                    create.ExecuteNonQuery();
                }

                // 3) Devolver si la acabamos de crear
                return !existedBefore; // true => la creó ahora; false => ya existía
            }
        
    }
}
