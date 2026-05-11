using ProyectoADS_ROJEX.ConexionDB;
using System;
using System.Windows.Forms;

namespace ProyectoADS_ROJEX
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // === PRUEBA DE CONEXIÓN ===
            try
            {
                // 1. Prepara y conecta a la BD usando tu clase y la de Noe
                Conexion.Initialize();

                // 2. Si se conecta bien, salta este mensaje de victoria
                MessageBox.Show("¡Conexión exitosa a la BD Rojex_2!\n" +
                                "Servidor: " + sqlServerLocalizacion.ResolvedServer,
                                "Estado de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Si algo falla, te mostrará este error
                MessageBox.Show("No fue posible conectar con la BD.\n\n" + ex.Message,
                                "Rojex - Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cierra la app si no hay base de datos
            }
            // ==========================

            // 3. Si todo salió bien arriba, arranca la aplicación mostrando el Login
            Application.Run(new LoginInicio());
        }
    }
}