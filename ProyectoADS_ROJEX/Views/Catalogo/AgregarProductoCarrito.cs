using HerramientasTotal;
using ProyectoADS_ROJEX.ConexionDB;
using ProyectoADS_ROJEX.Models;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace ProyectoADS_ROJEX
{
    public partial class AgregarProductoCarrito : UserControl
    {
        private int _existenciasTotales = 0;
        private string _idProducto = "";
        private string _categoria = "";
        private decimal precioUnitario = 0;
        private int cantidadLocal = 0;

        public AgregarProductoCarrito()
        {
            InitializeComponent();

            guna2HtmlLabel1.Visible = false;
            guna2HtmlLabel3.Visible = false;
        }

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

        public void Configurar(Image imagen, string nombre, decimal precio, int existencias, string idProducto, string categoria)
        {
            picAgregarProdCarrito.Image = imagen;
            lblProductoNombre.Text = nombre;
            this.precioUnitario = precio;

            this._idProducto = idProducto;
            this._categoria = categoria;
            this._existenciasTotales = existencias; // Guardamos el límite real de la BD

            this.cantidadLocal = ProyectoADS_ROJEX.ConexionDB.GestorCarrito.ObtenerCantidadProducto(idProducto);

            btnMostrarPrecio.Text = $"$ {precio:N2}";

            ActualizarResumenTarjeta();
        }

        public Image CargarImagenProducto(string nombreArchivo)
        {
            string ruta = Path.Combine(Application.StartupPath, "Resources", "Products", nombreArchivo);
            if (File.Exists(ruta))
                return Image.FromFile(ruta);
            return null;
        }

        private void ActualizarResumenTarjeta()
        {
            decimal totalLocal = precioUnitario * cantidadLocal;
            lbltotal.Text = $"Agregados: {cantidadLocal} | tot: ${totalLocal:N2}";

            int inventarioVisual = _existenciasTotales - cantidadLocal;
            lblInventario.Text = $"Disponibles: {inventarioVisual}";
        }
        private void btnAgregarUnoProdCarrito_Click(object sender, EventArgs e)
        {
           // Solo dejamos agregar si todavía quedan en inventario
            if (cantidadLocal < _existenciasTotales)
            {
                cantidadLocal++;
                ActualizarResumenTarjeta();

                ProyectoADS_ROJEX.Models.CarritoItem itemNuevo = new ProyectoADS_ROJEX.Models.CarritoItem
                {
                    Fotografia = picAgregarProdCarrito.Image,
                    Codigo = _idProducto,
                    Nombre = lblProductoNombre.Text,
                    Categoria = _categoria,
                    Costo = precioUnitario,
                    Cantidad = 1
                };

                ProyectoADS_ROJEX.ConexionDB.GestorCarrito.AgregarProducto(itemNuevo);
            }
            else
            {
                MessageBox.Show("No puedes agregar más. Has alcanzado el límite de existencias.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnQuitarUnoProdCarrito_Click(object sender, EventArgs e)
        {
            if (cantidadLocal > 0)
            {
                cantidadLocal--;
                ActualizarResumenTarjeta();

                ProyectoADS_ROJEX.ConexionDB.GestorCarrito.RestarProducto(_idProducto);
            }
        }
    }
}
