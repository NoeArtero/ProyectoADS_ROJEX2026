using Guna.UI2.WinForms;
using HerramientasTotal.Views;
using HerramientasTotal.Views.Productos;
using ProyectoADS_ROJEX.Views;
using ProyectoADS_ROJEX.Views.Administrador;
using ProyectoADS_ROJEX.Views.Perfil;




namespace HerramientasTotal
{
    public partial class InicioView : Form
    {




        private readonly Dictionary<Type, UserControl> _views = new();

        private T EnsureView<T>() where T : UserControl, new()
        {
            if (!_views.TryGetValue(typeof(T), out var view))
            {
                view = new T
                {
                    Dock = DockStyle.Fill
                };
                _views.Add(typeof(T), view);
                ViewHost.Controls.Add(view);
            }
            return (T)view;
        }

        private void ShowView<T>() where T : UserControl, new()
        {
            var targetView = EnsureView<T>();
            foreach (Control c in ViewHost.Controls)
            {
                c.Visible = false;
            }

            targetView.Visible = true;
            targetView.BringToFront();
        }

        public InicioView()
        {
            InitializeComponent();
            ShowView<InicioUC>();
            BotonSeleccionado(btnInicio);
        }

        private Guna2GradientButton _actBtn;
        private void BotonSeleccionado(Guna2GradientButton btnColor)
        {
            if (_actBtn != null)
            {
                _actBtn.FillColor = Color.FromArgb(29, 27, 52);
                _actBtn.FillColor2 = Color.FromArgb(26, 18, 39);
            }

            _actBtn = btnColor;
            _actBtn.FillColor = Color.FromArgb(73, 75, 201);
            _actBtn.FillColor2 = Color.FromArgb(73, 75, 201);
        }

        //private void AbrircerrarPanel(Panel panel)
        //{
        //    if (panel.Visible)
        //    {
        //        panel.Visible = false;
        //    }
        //    else if (!panel.Visible)
        //    {
        //        panel.Visible = true;
        //    }

        //}


        private void btnInicio_Click(object sender, EventArgs e)
        {

            ShowView<InicioUC>();
            BotonSeleccionado(btnInicio);

        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            BotonSeleccionado(btnCatalogo);
            ShowView<CatalogoUC>();
        }

        private void btnCarrito_Click(object sender, EventArgs e)
        {
            BotonSeleccionado(btnCarrito);
            ShowView<CarritoUC>();
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            BotonSeleccionado(btnFacturas);
            ShowView<FacturasUC>();
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            BotonSeleccionado(btnPerfil);
            ShowView<UsuarioPerfil>();

        }

        private void btnAgregarProd_Click(object sender, EventArgs e)
        {
            BotonSeleccionado(btnAgregarProd);
            ShowView<AgregarProductoUC>();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
        }

        public void ActualizarNotificacionCarrito()
        {
            foreach (Control c in ViewHost.Controls)
            {
                // Si la pantalla del carrito está abierta, la refresca
                if (c is CarritoUC carritoVista && c.Visible)
                {
                    carritoVista.RefrescarDatosCarrito();
                }
            }
        }

    }
}
