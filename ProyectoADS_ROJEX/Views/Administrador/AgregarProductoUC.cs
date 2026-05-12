using Bogus;
using ProyectoADS_ROJEX.ConexionDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProyectoADS_ROJEX.Views.Administrador
{
    public partial class AgregarProductoUC : UserControl
    {
        private string rutaImagenSeleccionada = "";

        public AgregarProductoUC()
        {
            InitializeComponent();

            this.Load += AgregarProductoUC_Load;
            this.cmbIdProd.SelectedIndexChanged += CmbIdProd_SelectedIndexChanged;

        }

        private void AgregarProductoUC_Load(object sender, EventArgs e)
        {
            cmbCategoriaProd.DataSource = new List<string> { "Deportivos", "Lujo", "Casuales" };
            CargarProductosEnComboBox();
        }

        private void CargarProductosEnComboBox()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.AppConnectionString))
                {
                    conn.Open();
                    // Traemos el ID y armamos un nombre bonito (Ej: Casio F91)
                    string sql = @"SELECT ip.IdProducto, m.Marca + ' - ' + ip.Nombre AS NombreCompleto 
                                   FROM InfoProducto ip
                                   INNER JOIN Modelo mod ON ip.IdModelo = mod.IdModelo
                                   INNER JOIN Marca m ON mod.IdMarca = m.IdMarca";

                    SqlDataAdapter da = new SqlDataAdapter(new SqlCommand(sql, conn));
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Insertamos la opción de crear uno nuevo de primero
                    DataRow filaNuevo = dt.NewRow();
                    filaNuevo["IdProducto"] = 0;
                    filaNuevo["NombreCompleto"] = "--- CREAR NUEVO PRODUCTO ---";
                    dt.Rows.InsertAt(filaNuevo, 0);

                    cmbIdProd.DataSource = dt;
                    cmbIdProd.DisplayMember = "NombreCompleto";
                    cmbIdProd.ValueMember = "IdProducto";
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar la lista de productos: " + ex.Message); }
        }

        private void CmbIdProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIdProd.SelectedValue != null && cmbIdProd.SelectedValue is int)
            {
                int idSeleccionado = (int)cmbIdProd.SelectedValue;

                if (idSeleccionado == 0) // MODO: CREAR RELOJ NUEVO
                {
                    // Limpiamos todo
                    txtNombreProducto.Clear();
                    txtMarca.Clear();
                    mtbPrecioVentaProducto.Clear();
                    numExistenciasProductos.Value = 1;
                    imgAgregarUsuario.Image = null;
                    rutaImagenSeleccionada = "";
                    dtpFechaIngresoProd.Value = DateTime.Now;

                    // Desbloqueamos todo para que el Admin escriba
                    txtNombreProducto.Enabled = true;
                    txtMarca.Enabled = true;
                    cmbCategoriaProd.Enabled = true;
                    mtbPrecioVentaProducto.Enabled = true;
                    btnElegirImagenProveedor.Enabled = true;
                    dtpFechaIngresoProd.Enabled = true;
                }
                else // MODO: REABASTECER EXISTENTE
                {
                    CargarDatosDeProducto(idSeleccionado);
                }
            }
        }

        private void CargarDatosDeProducto(int idProducto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.AppConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT ip.Nombre, m.Marca, mod.NombreModelo as Categoria, ip.Precio, ip.CantidadDisponible 
                                   FROM InfoProducto ip
                                   INNER JOIN Modelo mod ON ip.IdModelo = mod.IdModelo
                                   INNER JOIN Marca m ON mod.IdMarca = m.IdMarca
                                   WHERE ip.IdProducto = @id";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", idProducto);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtNombreProducto.Text = reader["Nombre"].ToString();
                            txtMarca.Text = reader["Marca"].ToString();
                            cmbCategoriaProd.Text = reader["Categoria"].ToString();
                            mtbPrecioVentaProducto.Text = reader["Precio"].ToString();

                            // Lo ponemos a 1 para que el Admin sume desde ahí
                            numExistenciasProductos.Value = 1;
                            // La fecha se actualiza a hoy para el nuevo lote
                            dtpFechaIngresoProd.Value = DateTime.Now;

                            // BLOQUEAMOS DATOS FIJOS (Para evitar errores de dedo)
                            txtNombreProducto.Enabled = false;
                            txtMarca.Enabled = false;
                            cmbCategoriaProd.Enabled = false;
                            mtbPrecioVentaProducto.Enabled = false;
                            btnElegirImagenProveedor.Enabled = false;

                            // Dejamos libres solo Existencias y Fecha
                            dtpFechaIngresoProd.Enabled = true;

                            MessageBox.Show($"Actualmente tenés {reader["CantidadDisponible"]} de este reloj en inventario.\n\nEscribí en 'N° de existencias' cuántos nuevos entraron hoy y revisá la fecha.", "Aviso de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    // Cargar su foto automática
                    string rutaImagen = Path.Combine(Application.StartupPath, "Resources", "Products", idProducto + ".jpg");
                    if (File.Exists(rutaImagen))
                    {
                        using (var fs = new FileStream(rutaImagen, FileMode.Open, FileAccess.Read))
                        {
                            imgAgregarUsuario.Image = Image.FromStream(fs);
                        }
                    }
                    else { imgAgregarUsuario.Image = null; }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al traer datos del reloj: " + ex.Message); }
        }

        // método para validar si los campos para agregar 
        private bool valido()
        {
            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text) ||
                string.IsNullOrWhiteSpace(txtMarca.Text) ||
                string.IsNullOrWhiteSpace(mtbPrecioVentaProducto.Text))
            {
                return false;
            }
            return true;
        }
        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            if (numExistenciasProductos.Value <= 0)
            {
                MessageBox.Show("Debes agregar al menos 1 existencia.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbIdProd.SelectedValue == null) return;
            int idSeleccionado = (int)cmbIdProd.SelectedValue;

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.AppConnectionString))
                {
                    conn.Open();

                    if (idSeleccionado > 0)
                    {
                        // ----- ACTUALIZAR EXISTENCIAS DE UN PRODUCTO VIEJO -----
                        string sqlUpdate = "UPDATE InfoProducto SET CantidadDisponible = CantidadDisponible + @cant WHERE IdProducto = @id";
                        using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conn))
                        {
                            cmdUpdate.Parameters.AddWithValue("@cant", (int)numExistenciasProductos.Value);
                            cmdUpdate.Parameters.AddWithValue("@id", idSeleccionado);
                            cmdUpdate.ExecuteNonQuery();

                            MessageBox.Show("¡Inventario actualizado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // AQUI ESTÁ EL CAMBIO MÁGICO
                            CargarProductosEnComboBox(); // Refrescamos la lista
                            LimpiarPantalla(); // Limpiamos los cuadros
                        }
                    }
                    else
                    {
                        // ----- INSERTAR UN RELOJ TOTALMENTE NUEVO -----
                        if (!valido())
                        {
                            MessageBox.Show("Llena todos los datos obligatorios para crear el producto.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        SqlCommand cmdEmpresa = new SqlCommand("IF NOT EXISTS (SELECT 1 FROM Relojeria WHERE IdEmpresa = 1) INSERT INTO Relojeria (NombreEmpresa) VALUES ('Rojex')", conn);
                        cmdEmpresa.ExecuteNonQuery();

                        SqlTransaction transaction = conn.BeginTransaction();
                        try
                        {
                            int idMarca = ObtenerOCrearMarca(txtMarca.Text.Trim(), conn, transaction);
                            int idModelo = ObtenerOCrearModelo(cmbCategoriaProd.Text, idMarca, conn, transaction);

                            SqlCommand cmdProd = new SqlCommand("INSERT INTO producto (IdEmpresa) OUTPUT INSERTED.IdProducto VALUES (1)", conn, transaction);
                            int nuevoIdProducto = (int)cmdProd.ExecuteScalar();

                            string sqlInfo = @"INSERT INTO InfoProducto (IdProducto, Nombre, IdModelo, CantidadDisponible, Precio) 
                                               VALUES (@idp, @nom, @idm, @cant, @prec)";
                            SqlCommand cmdInfo = new SqlCommand(sqlInfo, conn, transaction);
                            cmdInfo.Parameters.AddWithValue("@idp", nuevoIdProducto);
                            cmdInfo.Parameters.AddWithValue("@nom", txtNombreProducto.Text.Trim());
                            cmdInfo.Parameters.AddWithValue("@idm", idModelo);
                            cmdInfo.Parameters.AddWithValue("@cant", (int)numExistenciasProductos.Value);

                            decimal precioValidado = 0;
                            decimal.TryParse(mtbPrecioVentaProducto.Text.Replace("$", "").Replace(",", "").Trim(), out precioValidado);
                            cmdInfo.Parameters.AddWithValue("@prec", precioValidado);

                            cmdInfo.ExecuteNonQuery();

                            if (!string.IsNullOrEmpty(rutaImagenSeleccionada))
                            {
                                GuardarImagenProducto(nuevoIdProducto);
                            }

                            transaction.Commit();
                            MessageBox.Show("Producto nuevo guardado en el inventario con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // AQUI ESTÁ EL CAMBIO MÁGICO
                            CargarProductosEnComboBox(); // Refrescamos la lista para que aparezca el nuevo
                            LimpiarPantalla(); // Limpiamos los cuadros
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error al guardar el producto nuevo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error de red o base de datos: " + ex.Message); }
        }


        private void btnCancelarAgregarProveedor_Click(object sender, EventArgs e)
        {
            LimpiarPantalla();
        }

        private void btnElegirImagenProveedor_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imágenes|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rutaImagenSeleccionada = ofd.FileName;
                // Cargamos la imagen temporalmente para que no se bloquee
                using (var fs = new FileStream(rutaImagenSeleccionada, FileMode.Open, FileAccess.Read))
                {
                    imgAgregarUsuario.Image = Image.FromStream(fs);
                }
            }
        }

        private int ObtenerOCrearMarca(string nombreMarca, SqlConnection conn, SqlTransaction trans)
        {
            SqlCommand cmd = new SqlCommand("SELECT IdMarca FROM Marca WHERE Marca = @m", conn, trans);
            cmd.Parameters.AddWithValue("@m", nombreMarca);
            object res = cmd.ExecuteScalar();
            if (res != null) return (int)res;

            SqlCommand ins = new SqlCommand("INSERT INTO Marca (Marca) OUTPUT INSERTED.IdMarca VALUES (@m)", conn, trans);
            ins.Parameters.AddWithValue("@m", nombreMarca);
            return (int)ins.ExecuteScalar();
        }

        private int ObtenerOCrearModelo(string nombreModelo, int idMarca, SqlConnection conn, SqlTransaction trans)
        {
            SqlCommand cmd = new SqlCommand("SELECT IdModelo FROM Modelo WHERE NombreModelo = @n AND IdMarca = @idm", conn, trans);
            cmd.Parameters.AddWithValue("@n", nombreModelo);
            cmd.Parameters.AddWithValue("@idm", idMarca);
            object res = cmd.ExecuteScalar();
            if (res != null) return (int)res;

            SqlCommand ins = new SqlCommand("INSERT INTO Modelo (IdMarca, NombreModelo, Marca) OUTPUT INSERTED.IdModelo VALUES (@idm, @n, @m)", conn, trans);
            ins.Parameters.AddWithValue("@idm", idMarca);
            ins.Parameters.AddWithValue("@n", nombreModelo);
            ins.Parameters.AddWithValue("@m", txtMarca.Text.Trim());
            return (int)ins.ExecuteScalar();
        }

        private void GuardarImagenProducto(int idProducto)
        {
            try
            {
                string carpeta = Path.Combine(Application.StartupPath, "Resources", "Products");
                if (!Directory.Exists(carpeta)) Directory.CreateDirectory(carpeta);

                string rutaDestino = Path.Combine(carpeta, idProducto + ".jpg");

                using (Image imagenTemporal = Image.FromFile(rutaImagenSeleccionada))
                {
                    imagenTemporal.Save(rutaDestino, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la foto física: " + ex.Message);
            }
        }

        private void LimpiarPantalla()
        {
            // Quitamos el manejador de eventos un ratito para que no se cicle
            this.cmbIdProd.SelectedIndexChanged -= CmbIdProd_SelectedIndexChanged;

            if (cmbIdProd.Items.Count > 0)
            {
                cmbIdProd.SelectedIndex = 0; // Lo regresamos a "CREAR NUEVO"
            }

            txtNombreProducto.Clear();
            txtMarca.Clear();
            mtbPrecioVentaProducto.Clear();
            numExistenciasProductos.Value = 1;
            imgAgregarUsuario.Image = null;
            rutaImagenSeleccionada = "";
            dtpFechaIngresoProd.Value = DateTime.Now;

            // Volvemos a conectar el manejador
            this.cmbIdProd.SelectedIndexChanged += CmbIdProd_SelectedIndexChanged;
        }
    }
}
