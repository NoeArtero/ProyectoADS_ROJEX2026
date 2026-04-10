using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace ProyectoADS_ROJEX.Views.NuevoUsuario
{
    public partial class NuevoUsuarioAgregarUC : UserControl
    {
        public NuevoUsuarioAgregarUC()
        {
            InitializeComponent();
            cmbGeneroUsuarioAgregar.Items.Add("Masculino");
            cmbGeneroUsuarioAgregar.Items.Add("Femenino");
            cmbGeneroUsuarioAgregar.Items.Add("Prefiero no decir");
            cmbGeneroUsuarioAgregar.SelectedIndex = 0;
        }
        //validar espacios vacíos
        private bool valido()
        {
            bool valido = false;
            if (txtContra.Text.IsWhiteSpace() || txtAgregarNumeroUsuario.Text.IsWhiteSpace() || txtAgregarNombreUsuario.Text.IsWhiteSpace() ||
                txtAgregarCorreo.Text.IsWhiteSpace() || txtDireccionAgregarUsuario.Text.IsWhiteSpace())
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            if (!valido())
            {
                MessageBox.Show("Verifique que los espacios estén correctamente llenados", "Error de agregado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("¿Seguro que quiere guardar este usuario?", "Agregar usuario",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Parent.Controls.Remove(this);
                    MessageBox.Show("Usuario agregado con éxito.", "Usuario agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaImagen = openFileDialog.FileName;
                imgAgregarUsuario.Image = Image.FromFile(rutaImagen);
                imgAgregarUsuario.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
