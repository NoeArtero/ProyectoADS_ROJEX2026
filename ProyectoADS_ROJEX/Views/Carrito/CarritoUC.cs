using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bogus;





namespace HerramientasTotal.Views.Productos
{

    public class ProductoCarritoTemp
    {
        public Image Fotografia { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public decimal Costo { get; set; }
    }
    public partial class CarritoUC : UserControl
    {
        //conector con la clase ProductoRow
        
        public CarritoUC()
        {
            InitializeComponent();
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.RowTemplate.Height = 60;
            CargarDatosProvisionales();



            // DATOS PROVICIONALES PARA LOS COMBOBOX
            cmbCategoriaProducto.DataSource = new List<string>
            {
                "Lujo",
                "Deportes",
                "Causales",
                "Chafas",
                "Todas"
            };
            cmbCategoriaProducto.SelectedIndex = 4;


           

            // FIN DATOS PROVICIONALES PARA LOS COMBOBOX
        }

        // valores provisionales para la tabla usando Bogus

        private Image CrearImagenProvisional(int ancho, int alto)
        {
            Bitmap bmp = new Bitmap(ancho, alto);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.LightBlue);
                using (Pen pen = new Pen(Color.Gray, 2))
                {
                    g.DrawRectangle(pen, 1, 1, ancho - 2, alto - 2);
                    g.DrawLine(pen, 0, 0, ancho, alto);
                    g.DrawLine(pen, ancho, 0, 0, alto);
                }
            }

            return bmp;
        }

        private void CargarDatosProvisionales()
        {
            var categorias = new List<string>
    {
        "Lujo",
        "Deportes",
        "Causales",
        "Chafas"
    };

            var faker = new Faker<ProductoCarritoTemp>()
                .RuleFor(p => p.Fotografia, f => CrearImagenProvisional(50, 50))
                .RuleFor(p => p.Codigo, f => $"PRD-{f.Random.Number(1000, 9999)}")
                .RuleFor(p => p.Nombre, f => f.Commerce.ProductName())
                .RuleFor(p => p.Categoria, f => f.PickRandom(categorias))
                .RuleFor(p => p.Costo, f => Math.Round(f.Random.Decimal(15, 999), 2));

            var listaProductos = faker.Generate(10);

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = listaProductos;
        }



        // fin valores provisionales para la tabla usando Bogus

        
    }
}
