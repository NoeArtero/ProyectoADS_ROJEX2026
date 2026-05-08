using Bogus;
using ProyectoADS_ROJEX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HerramientasTotal.Views.Productos
{
    public partial class CatalogoUC : UserControl
    {
        //conector con la clase ProductoRow
        public CatalogoUC()
        {
            InitializeComponent();
            CargarCatalogo();
            

            cmbCategoriaProductoMovimientos.DataSource = new List<string>
            {

               "Deportivos",
               "Lujo",
               "Casuales",
                "Todas"
            };
            cmbCategoriaProductoMovimientos.SelectedIndex = 4;

        }

        private void CargarCatalogo()
        {
            agregarProductoCarrito1.Configurar(
                CargarImagenProducto("appleWatchS9.jpg"),
                "Apple Watch S9 45MM",
                "$ 499.00",
                "Agregados: 2 | tot: $999"
            );

            agregarProductoCarrito2.Configurar(
                CargarImagenProducto("CasioDBC301.jpg"),
                "Casio DBC-301",
                "$ 89.00",
                "Agregados: 1 | tot: $89"
            );

            agregarProductoCarrito3.Configurar(
                CargarImagenProducto("CasioGShock.jpg"),
                "Casio G-Shock",
                "$ 129.00",
                "Agregados: 3 | tot: $387"
            );

            agregarProductoCarrito4.Configurar(
                CargarImagenProducto("CasioVingatePlateado.jpg"),
                "Casio Vintage Plateado",
                "$ 75.00",
                "Agregados: 1 | tot: $75"
            );

            agregarProductoCarrito5.Configurar(
                CargarImagenProducto("GalaxyWatch8.jpg"),
                "Galaxy Watch 8",
                "$ 399.00",
                "Agregados: 2 | tot: $798"
            );

            agregarProductoCarrito6.Configurar(
                CargarImagenProducto("HamiltonKhakiFieldMurph.jpg"),
                "Hamilton Khaki Field",
                "$ 649.00",
                "Agregados: 1 | tot: $649"
            );

            agregarProductoCarrito7.Configurar(
                CargarImagenProducto("omnitrix.jpg"),
                "Omnitrix Clásico",
                "$ 59.00",
                "Agregados: 4 | tot: $236"
            );

            agregarProductoCarrito8.Configurar(
                CargarImagenProducto("RolexTime4Diamonds.jpg"),
                "Rolex Time Diamond",
                "$ 999.00",
                "Agregados: 1 | tot: $999"
            );
        }

        private Image CargarImagenProducto(string nombreArchivo)
        {
            string ruta = Path.Combine(Application.StartupPath, "Resources", "Products", nombreArchivo);

            if (!File.Exists(ruta))
            {
                MessageBox.Show("No se encontró la imagen:\n" + ruta);
                return null;
            }

            try
            {
                using (var fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
                {
                    return Image.FromStream(fs);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen:\n" + ex.Message);
                return null;
            }
        }




    }
}
