using ProyectoADS_ROJEX.ConexionDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace ProyectoADS_ROJEX.Views.NuevoUsuario
{
    public partial class NuevoUsuarioAgregarUC : UserControl
    {
        // Ruta para guardar la imagen localmente
        private string rutaImagenTemporal = "";
        private const string LLAVE_MAESTRA = "ROJEX2026";

        public NuevoUsuarioAgregarUC()
        {
            InitializeComponent();

            // Llenar combo
            cmbGeneroUsuarioAgregar.Items.Clear();
            cmbGeneroUsuarioAgregar.Items.AddRange(new string[] { "Masculino", "Femenino", "Prefiero no decir" });
            cmbGeneroUsuarioAgregar.SelectedIndex = 0;

            // OCULTAR controles de admin al iniciar
            lblLlaveAdmin.Visible = false;
            txtLlaveAdmin.Visible = false;
        }
        //validar espacios vacíos
        private bool valido()
        {
            if (string.IsNullOrWhiteSpace(txtContra.Text) ||
                            string.IsNullOrWhiteSpace(txtAgregarNumeroUsuario.Text) ||
                            string.IsNullOrWhiteSpace(txtAgregarNombreUsuario.Text) ||
                            string.IsNullOrWhiteSpace(txtAgregarCorreo.Text) ||
                            string.IsNullOrWhiteSpace(txtDireccionAgregarUsuario.Text))
            {
                return false;
            }
            return true;
        }

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            if (!valido())
            {
                MessageBox.Show("Por favor, llene todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool esAdmin = false;

            // VALIDACIÓN DE LLAVE ADMIN
            if (rbEsAdmin.Checked)
            {
                if (txtLlaveAdmin.Text != LLAVE_MAESTRA)
                {
                    MessageBox.Show("La llave de administrador es incorrecta.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                esAdmin = true;
            }

            if (MessageBox.Show("¿Seguro que quiere guardar este usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RegistrarEnBaseDatos(esAdmin);
            }
        }
        private void RegistrarEnBaseDatos(bool esAdmin)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.AppConnectionString))
                {
                    conn.Open();
                    string sql = @"INSERT INTO Usuario (NombreUsuario, Correo, Contraseña, Telefono, Genero, Direccion, EsAdmin) 
                                   VALUES (@user, @correo, @pass, @tel, @gen, @dir, @admin)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", txtAgregarNombreUsuario.Text.Trim());
                        cmd.Parameters.AddWithValue("@correo", txtAgregarCorreo.Text.Trim());
                        cmd.Parameters.AddWithValue("@pass", txtContra.Text.Trim()); // Lo ideal sería encriptarla, pero para el proyecto está bien así
                        cmd.Parameters.AddWithValue("@tel", txtAgregarNumeroUsuario.Text.Trim());
                        cmd.Parameters.AddWithValue("@gen", cmbGeneroUsuarioAgregar.Text);
                        cmd.Parameters.AddWithValue("@dir", txtDireccionAgregarUsuario.Text.Trim());
                        cmd.Parameters.AddWithValue("@admin", esAdmin);

                        cmd.ExecuteNonQuery();
                    }
                }


                // Guardar imagen si seleccionó una
                if (!string.IsNullOrEmpty(rutaImagenTemporal))
                {
                    GuardarImagenLocal(txtAgregarNombreUsuario.Text.Trim());
                }

                MessageBox.Show("Usuario registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Parent?.Controls.Remove(this); // Cerrar vista
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en la BD: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarImagenLocal(string nombreUsuario)
        {
            try
            {
                string carpeta = Path.Combine(Application.StartupPath, "Resources", "Profiles");
                if (!Directory.Exists(carpeta)) Directory.CreateDirectory(carpeta);

                string destino = Path.Combine(carpeta, nombreUsuario + ".jpg");
                File.Copy(rutaImagenTemporal, destino, true);
            }
            catch { /* Ignorar errores de imagen para no trabar el registro */ }
        }

        private void btnCancelarAgregarProveedor_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que quiere no guardar este usuario?", "Agregar usuario",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Parent?.Controls.Remove(this);
            }

        }

        private void btnElegirImagenProveedor_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imagenes|*.jpg;*.png;*.jpeg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rutaImagenTemporal = ofd.FileName;
                imgAgregarUsuabtnElegirImagenProveedorrio.Image = Image.FromFile(rutaImagenTemporal);
            }
        }

        private void txtAgregarNumeroUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbEsAdmin_CheckedChanged(object sender, EventArgs e)
        {
            lblLlaveAdmin.Visible = rbEsAdmin.Checked;
            txtLlaveAdmin.Visible = rbEsAdmin.Checked;

            if (rbEsAdmin.Checked)
            {
                txtLlaveAdmin.Focus();
            }
            else
            {
                txtLlaveAdmin.Clear();
            }
        }
    }
}
