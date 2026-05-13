using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ProyectoADS_ROJEX;
using ProyectoADS_ROJEX.ConexionDB; 

namespace HerramientasTotal.Views.Productos
{
    public partial class CatalogoUC : UserControl
    {
        public CatalogoUC()
        {
            InitializeComponent();

            // Hace que se actualice cada vez que entramos a la pestaña
            this.VisibleChanged += CatalogoUC_VisibleChanged;

            CargarCatalogoDesdeBD();

            cmbCategoriaProductoMovimientos.DataSource = new List<string>
            {
               "Deportivos", "Lujo", "Casuales", "Todas"
            };
            cmbCategoriaProductoMovimientos.SelectedIndex = 3;
        }
        private void CatalogoUC_VisibleChanged(object sender, EventArgs e)
        {
     
            if (this.Visible)
            {
                CargarCatalogoDesdeBD();
            }
        }

        public void CargarCatalogoDesdeBD()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.AppConnectionString))
                {
                    conn.Open();

                    string query = @"SELECT TOP 8 i.IdProducto, i.Nombre, i.Precio, i.Marca, i.NombreModelo, ip.CantidadDisponible 
                                     FROM dbo.InventarioA i 
                                     INNER JOIN InfoProducto ip ON i.IdProducto = ip.IdProducto 
                                     ORDER BY i.IdProducto DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

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

                        string idProd = reader["IdProducto"].ToString();
                        int existencias = Convert.ToInt32(reader["CantidadDisponible"]);

                        string categoria = reader["NombreModelo"].ToString();

                        Image img = CargarImagenProducto($"{idProd}.jpg");

                        tarjetas[i].Configurar(img, nombreCompleto, precio, existencias, idProd, categoria);
                        tarjetas[i].Visible = true;
                        i++;
                    }

                    for (int j = i; j < tarjetas.Count; j++)
                    {
                        tarjetas[j].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el catálogo: " + ex.Message, "Error de Datos");
            }
        }

        private Image CargarImagenProducto(string nombreArchivo)
        {
            string ruta = Path.Combine(Application.StartupPath, "Resources", "Products", nombreArchivo);
            if (!File.Exists(ruta)) return null;

            try
            {
                using (var fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
                {
                    return Image.FromStream(fs);
                }
            }
            catch { return null; }
        }
    }
}
