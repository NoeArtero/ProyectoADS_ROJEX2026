using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ProyectoADS_ROJEX;
using ProyectoADS_ROJEX.ConexionDB; // Para usar tu conexión

namespace HerramientasTotal.Views.Productos
{
    public partial class CatalogoUC : UserControl
    {
        public CatalogoUC()
        {
            InitializeComponent();

            // 1. Cargamos datos reales de la BD al iniciar
            CargarCatalogoDesdeBD();

            cmbCategoriaProductoMovimientos.DataSource = new List<string>
            {
               "Deportivos", "Lujo", "Casuales", "Todas"
            };
            cmbCategoriaProductoMovimientos.SelectedIndex = 3;
        }

        private void CargarCatalogoDesdeBD()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.AppConnectionString))
                {
                    conn.Open();
                    // Traemos los datos de tu vista (Nombre, Precio y la Marca para el título)
                    string query = "SELECT TOP 8 Nombre, Precio, Marca FROM dbo.Inventario";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Metemos tus 8 controles en una lista para manejarlos con un ciclo
                    var tarjetas = new List<AgregarProductoCarrito>
                    {
                        agregarProductoCarrito1, agregarProductoCarrito2, agregarProductoCarrito3,
                        agregarProductoCarrito4, agregarProductoCarrito5, agregarProductoCarrito6,
                        agregarProductoCarrito7, agregarProductoCarrito8
                    };

                    int i = 0;
                    while (reader.Read() && i < tarjetas.Count)
                    {
                        string nombreCompleto = $"{reader["Marca"]} {reader["Nombre"]}";
                        decimal precio = Convert.ToDecimal(reader["Precio"]);

                        // Buscamos la imagen. Si no existe, el método devuelve null y no truena.
                        Image img = CargarImagenProducto($"{reader["Nombre"]}.jpg");

                        // Usamos el método de 3 argumentos que arreglamos antes
                        tarjetas[i].Configurar(img, nombreCompleto, precio);
                        tarjetas[i].Visible = true;
                        i++;
                    }

                    // Si hay menos de 8 productos, ocultamos las tarjetas sobrantes
                    for (int j = i; j < tarjetas.Count; j++)
                    {
                        tarjetas[j].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la BD para el catálogo: " + ex.Message, "Error de Datos");
            }
        }

        private Image CargarImagenProducto(string nombreArchivo)
        {
            // Ruta limpia combinando la carpeta de ejecución con Resources
            string ruta = Path.Combine(Application.StartupPath, "Resources", "Products", nombreArchivo);

            if (!File.Exists(ruta)) return null;

            try
            {
                // Usamos FileStream para que la imagen no se quede "bloqueada" por Windows
                using (var fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
                {
                    return Image.FromStream(fs);
                }
            }
            catch { return null; }
        }
    }
}
