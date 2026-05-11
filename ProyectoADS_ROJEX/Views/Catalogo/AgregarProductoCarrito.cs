using System.IO;
using System.ComponentModel;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoADS_ROJEX
{
    public partial class AgregarProductoCarrito : UserControl
    {
        private decimal precioUnitario = 0;
        private int cantidad = 0;

        public AgregarProductoCarrito()
        {
            InitializeComponent();
            guna2HtmlLabel1.Visible = false;
            guna2HtmlLabel3.Visible = false;
        }

        // ESTO ARREGLA EL ERROR DE SERIALIZACIÓN
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal Precio
        {
            get => precioUnitario;
            set => precioUnitario = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Image ImagenProducto
        {
            get => picAgregarProdCarrito.Image;
            set => picAgregarProdCarrito.Image = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NombreProducto
        {
            get => lblProductoNombre.Text;
            set => lblProductoNombre.Text = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PrecioProducto
        {
            get => btnMostrarPrecio.Text;
            set => btnMostrarPrecio.Text = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TextoResumen
        {
            get => lbltotal.Text;
            set => lbltotal.Text = value;
        }

        // USAMOS SOLO ESTA VERSIÓN DE CONFIGURAR (LA QUE USA DECIMAL)
        public void Configurar(Image imagen, string nombre, decimal precio)
        {
            picAgregarProdCarrito.Image = imagen;
            lblProductoNombre.Text = nombre;
            this.precioUnitario = precio;
            this.cantidad = 0;

            btnMostrarPrecio.Text = $"$ {precio:N2}";
            ActualizarResumen();
        }

        public Image CargarImagenProducto(string nombreArchivo)
        {
            string ruta = Path.Combine(Application.StartupPath, "Resources", "Products", nombreArchivo);
            if (File.Exists(ruta))
                return Image.FromFile(ruta);
            return null;
        }

        private void ActualizarResumen()
        {
            decimal total = precioUnitario * cantidad;
            lbltotal.Text = $"Agregados: {cantidad} | tot: ${total:N2}";
        }

        private void btnAgregarUnoProdCarrito_Click(object sender, EventArgs e)
        {
            cantidad++;
            ActualizarResumen();
        }

        private void btnQuitarUnoProdCarrito_Click(object sender, EventArgs e)
        {
            if (cantidad > 0)
            {
                cantidad--;
                ActualizarResumen();
            }
        }
    }
}
