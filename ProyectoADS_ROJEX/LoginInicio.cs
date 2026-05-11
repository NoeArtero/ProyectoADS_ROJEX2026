using HerramientasTotal;
using ProyectoADS_ROJEX.ConexionDB;
using ProyectoADS_ROJEX.Views.NuevoUsuario;
using ProyectoADS_ROJEX.Views.Perfil;
using System.Data.SqlClient;

namespace ProyectoADS_ROJEX
{
   

    public partial class LoginInicio : Form
    {
        public LoginInicio()
        {
            InitializeComponent();
        }
        // apartado para métodos
        private void CentrarControl(Control control, Control contenedor)
        {
            control.Left = (contenedor.Width - control.Width) / 2;
            control.Top = (contenedor.Height - control.Height) / 2;
        }
        

        private void CentrarBotones()
        {
            int espacioEntreBotones = 15;
            int anchoTotal = btnIngresar.Width + btnCancelar.Width + btnNuevoUsuario.Width + espacioEntreBotones;
            int xInicial = (PanelInferiorBotonesCentro.Width - anchoTotal) / 2;
            int y = (PanelInferiorBotonesCentro.Height - btnIngresar.Height) / 2;

            btnIngresar.Left = xInicial;
            btnIngresar.Top = y;
            btnCancelar.Left = btnIngresar.Right + espacioEntreBotones;
            btnCancelar.Top = y;
            btnNuevoUsuario.Left = btnCancelar.Right + espacioEntreBotones;
            btnNuevoUsuario.Top = y;
        }

        private bool valido()
        {
            // Cambié .IsWhiteSpace() por string.IsNullOrWhiteSpace para que no te dé error
            if (string.IsNullOrWhiteSpace(txtNombreIngreso.Text) || string.IsNullOrWhiteSpace(txtContra.Text))
            {
                return false;
            }
            return true;
        }

        // --- EVENTOS DEL FORMULARIO ---

        private void Login_Load(object sender, EventArgs e)
        {
            CentrarControl(lblTitulo, panelCentro);
            CentrarControl(lblInicioDeSesion, panelInicioSesionFinal);
            CentrarBotones();
        }

        private void Login_Resize(object sender, EventArgs e)
        {
            CentrarControl(lblTitulo, panelCentro);
            CentrarControl(lblInicioDeSesion, panelInicioSesionFinal);
            CentrarBotones();
        }

        private void panelCentro_Resize(object sender, EventArgs e)
        {
            CentrarControl(lblTitulo, panelCentro);
            CentrarControl(lblInicioDeSesion, panelInicioSesionFinal);
            CentrarBotones();
        }
        // fin parte para centrar elementos
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (!valido())
            {
                MessageBox.Show("Uno de los espacios está vacío, ingrese sus credenciales completas", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.AppConnectionString))
                {
                    conn.Open();
                    // Buscamos al usuario. Asegúrate que los nombres de columnas coincidan con tu BD
                    string sql = "SELECT IdUsuario, NombreUsuario, EsAdmin FROM Usuario WHERE NombreUsuario = @user AND Contraseña = @pass";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", txtNombreIngreso.Text.Trim());
                        cmd.Parameters.AddWithValue("@pass", txtContra.Text.Trim());

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // ¡ÉXITO! Llenamos el carnet de la sesión
                                SesionUsuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                                SesionUsuario.Nombre = reader["NombreUsuario"].ToString();
                                SesionUsuario.EsAdmin = Convert.ToBoolean(reader["EsAdmin"]);

                                MessageBox.Show($"Bienvenido {SesionUsuario.Nombre}", "Acceso concedido");

                                // Abrimos la vista principal
                                InicioView inicioView = new InicioView();
                                inicioView.Show();
                                this.Hide(); // Escondemos el login
                            }
                            else
                            {
                                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de acceso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }

        }

        //el boton va a abrir el NuevoUsuarioUC, que está en la carpeta de UserControls, y ese UserControl
        //va a tener un formulario para registrar un nuevo usuario,
        //con sus respectivos campos, y un botón para guardar el nuevo usuario en la base de datos
        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            NuevoUsuarioAgregarUC nuevoUsuarioAgregarUC = new NuevoUsuarioAgregarUC();
            nuevoUsuarioAgregarUC.Show();
            this.Controls.Add(nuevoUsuarioAgregarUC);
            nuevoUsuarioAgregarUC.BringToFront();
            nuevoUsuarioAgregarUC.Location = new Point((this.Width - nuevoUsuarioAgregarUC.Width) / 2
                                                   , (this.Height - nuevoUsuarioAgregarUC.Height) / 2);

        }
    }
}
