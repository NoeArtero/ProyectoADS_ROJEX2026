using Bogus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProyectoADS_ROJEX.Views.Administrador
{
    public partial class AgregarProductoUC : UserControl
    {
        public AgregarProductoUC()
        {
            InitializeComponent();


            cmbCategoriaProd.DataSource = new List<string>
            {
               "Deportivos",
               "Lujo",
               "Casuales",
            };
            cmbCategoriaProd.SelectedIndex = 0;
        }

        // método para validar si los campos para agregar 
        private bool valido()
        {
            if (txtNombreProducto.Text.IsWhiteSpace() || txtMarca.Text.IsWhiteSpace()
                || txtIdProd.Text.IsWhiteSpace())
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
                MessageBox.Show("Debe llenar todos los campos correctamente para agregar un producto", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Producto agregado correctamente", "Producto agregado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Parent?.Controls.Remove(this);
            }
        }

        private void btnCancelarAgregarProveedor_Click(object sender, EventArgs e)
        {
            Parent?.Controls.Remove(this);
        }
    }
}
