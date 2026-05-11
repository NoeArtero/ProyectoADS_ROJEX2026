

using ProyectoADS_ROJEX.ConexionDB;
using ProyectoADS_ROJEX.Views.Perfil;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;

namespace ProyectoADS_ROJEX.Views
{
    public partial class UsuarioPerfil : UserControl
    {
        private string usuarioOriginal = "";
        private string contraOriginal = "";
        private string correoOriginal = "";
        private string telOriginal = "";
        private string dirOriginal = "";

        public UsuarioPerfil()
        {
            InitializeComponent();
            this.Load += new EventHandler(UsuarioPerfil_Load);
        }



        private void UsuarioPerfil_Load(object sender, EventArgs e)
        {
           

            MessageBox.Show("Cargando perfil... El ID del usuario es: " + SesionUsuario.IdUsuario);

            CargarInformacionCompleta();

        }

        public void CargarInformacionCompleta()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.AppConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT NombreUsuario, Contraseña, Correo, Telefono, Direccion 
                                   FROM Usuario WHERE IdUsuario = @id";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Buscamos al usuario usando el Carnet (SesionUsuario)
                        cmd.Parameters.AddWithValue("@id", SesionUsuario.IdUsuario);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // 1. Llenamos los TextBox visuales
                                txtNombreIngreso.Text = reader["NombreUsuario"].ToString();
                                txtContra.Text = reader["Contraseña"].ToString();
                                txtPerfilCorreo.Text = reader["Correo"].ToString();
                                txtPerfilTelefono.Text = reader["Telefono"].ToString();
                                txtPerfilDireccion.Text = reader["Direccion"].ToString();

                                // 2. Guardamos las copias de seguridad (memoria fantasma)
                                usuarioOriginal = txtNombreIngreso.Text;
                                contraOriginal = txtContra.Text;
                                correoOriginal = txtPerfilCorreo.Text;
                                telOriginal = txtPerfilTelefono.Text;
                                dirOriginal = txtPerfilDireccion.Text;

                                // 3. Cargamos la foto
                                CargarFoto(usuarioOriginal);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar perfil: " + ex.Message, "Rojex Error");
            }
        }

        private void CargarFoto(string nombreUsuario)
        {
            string ruta = Path.Combine(Application.StartupPath, "Resources", "Profiles", nombreUsuario + ".jpg");
            if (File.Exists(ruta))
            {
                // Usamos FileStream para que la imagen no se bloquee y deje cambiarla
                using (var fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
                {
                    // Asumo que tu cuadrito de foto se llama imgPerfil
                    imgPerfil.Image = Image.FromStream(fs);
                }
            }
            else
            {
                imgPerfil.Image = null;
            }
        }
        private void btnCambiarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imágenes|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string rutaOrigen = ofd.FileName;
                    string carpetaDestino = Path.Combine(Application.StartupPath, "Resources", "Profiles");
                    if (!Directory.Exists(carpetaDestino)) Directory.CreateDirectory(carpetaDestino);

                    string rutaDestino = Path.Combine(carpetaDestino, txtNombreIngreso.Text.Trim() + ".jpg");

                    // Copiamos la imagen y reemplazamos si ya hay una
                    File.Copy(rutaOrigen, rutaDestino, true);

                    // Refrescamos la vista visual
                    using (var fs = new FileStream(rutaDestino, FileMode.Open, FileAccess.Read))
                    {
                        imgPerfil.Image = Image.FromStream(fs);
                    }

                    MessageBox.Show("¡Foto de perfil actualizada!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show("Error al cambiar foto: " + ex.Message); }
            }

        }

        private void RenombrarFoto(string nombreViejo, string nombreNuevo)
        {
            if (nombreViejo == nombreNuevo) return; // No hace nada si es el mismo nombre

            try
            {
                string carpeta = Path.Combine(Application.StartupPath, "Resources", "Profiles");
                string archivoViejo = Path.Combine(carpeta, nombreViejo + ".jpg");
                string archivoNuevo = Path.Combine(carpeta, nombreNuevo + ".jpg");

                if (File.Exists(archivoViejo))
                {
                    File.Move(archivoViejo, archivoNuevo);
                }
            }
            catch { /* Ignoramos si da error para no trabar el guardado principal */ }
        }



        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void btnCambiarUsContra_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreIngreso.Text) || string.IsNullOrWhiteSpace(txtContra.Text))
            {
                MessageBox.Show("No puedes dejar el usuario o la contraseña en blanco.", "Acción denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // RESTAURACIÓN: Le devolvemos lo que tenía antes de que tocara
                txtNombreIngreso.Text = usuarioOriginal;
                txtContra.Text = contraOriginal;
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.AppConnectionString))
                {
                    conn.Open();
                    string sql = "UPDATE Usuario SET NombreUsuario = @user, Contraseña = @pass WHERE IdUsuario = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", txtNombreIngreso.Text.Trim());
                        cmd.Parameters.AddWithValue("@pass", txtContra.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", SesionUsuario.IdUsuario);

                        cmd.ExecuteNonQuery();

                        // Si cambiaron el nombre, renombramos la foto para que no se pierda
                        RenombrarFoto(usuarioOriginal, txtNombreIngreso.Text.Trim());

                        MessageBox.Show("¡Credenciales actualizadas correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // ACTUALIZAMOS NUESTRA COPIA DE SEGURIDAD
                        usuarioOriginal = txtNombreIngreso.Text.Trim();
                        contraOriginal = txtContra.Text.Trim();
                        SesionUsuario.Nombre = usuarioOriginal; // Actualizamos la sesión global
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al guardar credenciales: " + ex.Message); }
        }
        

    

        private void btnCambiarCorreoTelefonoDireccion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPerfilCorreo.Text) || string.IsNullOrWhiteSpace(txtPerfilTelefono.Text) || string.IsNullOrWhiteSpace(txtPerfilDireccion.Text))
            {
                MessageBox.Show("Por favor, llena todos los datos de contacto.", "Acción denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // RESTAURACIÓN
                txtPerfilCorreo.Text = correoOriginal;
                txtPerfilTelefono.Text = telOriginal;
                txtPerfilDireccion.Text = dirOriginal;
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.AppConnectionString))
                {
                    conn.Open();
                    string sql = "UPDATE Usuario SET Correo = @correo, Telefono = @tel, Direccion = @dir WHERE IdUsuario = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@correo", txtPerfilCorreo.Text.Trim());
                        cmd.Parameters.AddWithValue("@tel", txtPerfilTelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("@dir", txtPerfilDireccion.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", SesionUsuario.IdUsuario);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("¡Datos de contacto actualizados!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // ACTUALIZAMOS LA COPIA DE SEGURIDAD
                        correoOriginal = txtPerfilCorreo.Text.Trim();
                        telOriginal = txtPerfilTelefono.Text.Trim();
                        dirOriginal = txtPerfilDireccion.Text.Trim();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al guardar contacto: " + ex.Message); }
        }

       

    }
 }
