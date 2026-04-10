
using ProyectoADS_ROJEX.ConexionDB;

namespace ProyectoADS_ROJEX
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                Conexion.Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No fue posible preparar la BD.\n\n" + ex.Message, "Rojex - Error");
                return;
            }

            using (var login = new LoginInicio())
            {
                if (login.ShowDialog() != DialogResult.OK)
                    return;
            }

            Application.Run(new LoginInicio());
        }
    }
}