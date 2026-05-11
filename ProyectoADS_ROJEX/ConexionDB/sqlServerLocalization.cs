using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ProyectoADS_ROJEX.ConexionDB
{
    internal class sqlServerLocalizacion
    {
        public static string? ResolvedServer { get; private set; }
        public static string? MasterConnectionString { get; private set; }

        public static bool TryResolve(out string serverName, out string masterCs)
        {
            foreach (var server in GetCandidateServers())
            {
                var cs = BuildMasterConnectionString(server);
                if (CanOpen(cs))
                {
                    ResolvedServer = server;
                    MasterConnectionString = cs;
                    serverName = server;
                    masterCs = cs;
                    return true;
                }
            }

            serverName = string.Empty;
            masterCs = string.Empty;
            return false;
        }

        private static IEnumerable<string> GetCandidateServers()
        {
            var list = new List<string>
            {
                // 1. LOS SERVIDORES REALES PRIMERO (Donde sí existen las tablas)
                @".\SQLEXPRESS",
                ".",
                "localhost",
                $@"{Environment.MachineName}\SQLEXPRESS",
                Environment.MachineName,
                
                // 2. EL LOCALDB AL FINAL (Para que no cree bases de datos falsas)
                @"(localdb)\MSSQLLocalDB"
            };

            return list.Where(s => !string.IsNullOrWhiteSpace(s))
                       .Select(s => s.Trim())
                       .Distinct(StringComparer.OrdinalIgnoreCase);
        }

        private static string BuildMasterConnectionString(string server) =>
            $"Server={server};Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True;Connect Timeout=3;";

        private static bool CanOpen(string connectionString)
        {
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    using var cmd = new SqlCommand("SELECT 1", cn);
                    cmd.ExecuteScalar();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}