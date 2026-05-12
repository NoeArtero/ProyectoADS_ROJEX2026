
using Bogus;
using ProyectoADS_ROJEX.ConexionDB;
using ProyectoADS_ROJEX.Views.Carrito;
using ProyectoADS_ROJEX.Views.NuevoUsuario;





namespace HerramientasTotal.Views.Productos
{

    public partial class CarritoUC : UserControl
    {
        

        public CarritoUC()
        {
            InitializeComponent();
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.RowTemplate.Height = 60;
            
            ConfigurarColumnas();

            //  Le decimos que cada vez que abrás la pestaña, actualice los datos
            this.VisibleChanged += CarritoUC_VisibleChanged;


            // DATOS PARA LOS COMBOBOx
            cmbCategoriaProducto.DataSource = new List<string>
            {
                "Lujo",
                "Deportes",
                "Causales",
                "Chafas",
                "Todas"
            };
            cmbCategoriaProducto.SelectedIndex = 4;




        }

        private void CarritoUC_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                RefrescarDatosCarrito();
            }
        }
        private void ConfigurarColumnas()
        {
            // Evitamos que se creen columnas duplicadas
            dgvProductos.AutoGenerateColumns = false;

            // Validamos que tengas tus 7 columnas dibujadas
            if (dgvProductos.Columns.Count >= 7)
            {
                // Índice 0: Fotografía
                dgvProductos.Columns[0].DataPropertyName = "Fotografia";
                if (dgvProductos.Columns[0] is DataGridViewImageColumn colFoto)
                {
                    colFoto.ImageLayout = DataGridViewImageCellLayout.Zoom; // Para que la foto se ajuste
                }

                // Índice 1: Cantidad
                dgvProductos.Columns[1].DataPropertyName = "Cantidad";

                // Índice 2: Fecha
                dgvProductos.Columns[2].DataPropertyName = "FechaFormateada";

                // Índice 3: Código
                dgvProductos.Columns[3].DataPropertyName = "Codigo";

                // Índice 4: Nombre
                dgvProductos.Columns[4].DataPropertyName = "Nombre";

                // Índice 5: Categoría
                dgvProductos.Columns[5].DataPropertyName = "Categoria";

                // Índice 6: Total (Esta propiedad ya multiplica Costo * Cantidad solita)
                dgvProductos.Columns[6].DataPropertyName = "TotalProducto";

                // Opcional: Para que el total salga con el signo de dólar y dos decimales
                dgvProductos.Columns[6].DefaultCellStyle.Format = "C2";
            }
        }
        
        public void RefrescarDatosCarrito()
        {
            dgvProductos.DataSource = null;

            if (GestorCarrito.ListaProductos != null)
            {
                dgvProductos.DataSource = GestorCarrito.ListaProductos;
            }
        }


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



        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            PagarTarjetaUC pagarTarjetaUC = new PagarTarjetaUC();
            pagarTarjetaUC.Show();
            this.Controls.Add(pagarTarjetaUC);
            pagarTarjetaUC.BringToFront();
            pagarTarjetaUC.Location = new Point((this.Width - pagarTarjetaUC.Width) / 2, (this.Height - pagarTarjetaUC.Height) / 2);
        }

    }

    public class ProductoCarritoTemp
    {
        public Image Fotografia { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public decimal Costo { get; set; }
    }
}
