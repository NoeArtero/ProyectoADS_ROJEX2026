
using System.IO;
using System.ComponentModel;

namespace ProyectoADS_ROJEX
{
    public partial class AgregarProductoCarrito : UserControl
    {

        public AgregarProductoCarrito()
        {
            InitializeComponent();
            guna2HtmlLabel1.Visible = false;
            guna2HtmlLabel3.Visible = false;
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
            get => guna2HtmlLabel2.Text;
            set => guna2HtmlLabel2.Text = value;
        }

        public void Configurar(Image imagen, string nombre, string precio, string resumen)
        {
            picAgregarProdCarrito.Image = imagen;
            lblProductoNombre.Text = nombre;
            btnMostrarPrecio.Text = precio;
            guna2HtmlLabel2.Text = resumen;
        }



        public Image CargarImagenProducto(string nombreArchivo)
        {
            string ruta = Path.Combine(Application.StartupPath, "Resources", "Products", nombreArchivo);

            if (File.Exists(ruta))
                return Image.FromFile(ruta);

            return null;
        }
    }
}
