using System;
using System.Data.SqlClient;

namespace ProyectoADS_ROJEX.ConexionDB
{
    internal class Conexion
    {
        // Tu base de datos principal
        public const string DatabaseName = "Rojex_2";

        public static string? AppConnectionString { get; private set; }

        public static void Initialize()
        {
            // 1. Buscar el servidor con el nuevo orden corregido
            if (!sqlServerLocalizacion.TryResolve(out var server, out var masterCs))
            {
                throw new InvalidOperationException(
                    "No se encontró una instancia de SQL Server disponible. " +
                    "Asegúrate de que SQL Server esté encendido.");
            }

            // 2. Verificar que la base de datos exista
            AsegurarBaseCreada(DatabaseName, masterCs);

            // 3. Cadena de conexión final para toda la aplicación
            AppConnectionString = $"Server={server};Initial Catalog={DatabaseName};Integrated Security=True;TrustServerCertificate=True;";
        }

        // ======================= CREACIÓN / VERIFICACIÓN BD =======================

        private static bool AsegurarBaseCreada(string dbName, string masterConnectionString)
        {
            using var cn = new SqlConnection(masterConnectionString);
            cn.Open();

            object? idBefore;
            using (var checkBefore = new SqlCommand("SELECT DB_ID(@db)", cn))
            {
                checkBefore.Parameters.AddWithValue("@db", dbName);
                idBefore = checkBefore.ExecuteScalar();
            }

            bool existedBefore = (idBefore != null && idBefore != DBNull.Value);

            // Si por algún milagro no existe, intenta crearla vacía (esto ya no debería pasar porque tienes tu script de SQL)
            if (!existedBefore)
            {
                var createSql = @"
                DECLARE @sql nvarchar(max) = N'CREATE DATABASE ' + QUOTENAME(@db) + N';';
                EXEC (@sql);";
                using var create = new SqlCommand(createSql, cn);
                create.Parameters.AddWithValue("@db", dbName);
                create.ExecuteNonQuery();
            }

            return !existedBefore;
        }
    }
}