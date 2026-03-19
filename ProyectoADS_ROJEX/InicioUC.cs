using Guna.Charts.Interfaces;
using Guna.Charts.WinForms;
using HerramientasTotal.Views.Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HerramientasTotal.Views
{
    public partial class InicioUC : UserControl
    {
        private readonly System.Windows.Forms.Timer clockTimer;
        public InicioUC()
        {
            InitializeComponent();

            clockTimer = new System.Windows.Forms.Timer();
            clockTimer.Interval = 1000;
            clockTimer.Tick += (_, __) => UpdateClock();
            clockTimer.Start();

            components?.Add(clockTimer);



            //SOLO SIGNIFICATIVO (AÚN NO ES OFICIAL QUE ESTE ES EL CÓDIGO)
            //// Dataset de línea de compras según fecha
            var ds = new GunaLineDataset
            {
                Label = "Pagado",
            };

            ds.DataPoints.Add("20/1/26", 120);
            ds.DataPoints.Add("2/2/26", 240);
            ds.DataPoints.Add("6/2/26", 380);
            ds.DataPoints.Add("19/3/26", 450);

            ChartVentasDia.Datasets.Clear();
            ChartVentasDia.Datasets.Add(ds);
            ChartVentasDia.Update();

            // Dataset de barras para articulos recientes
            var dsInv = new GunaBarDataset
            {
                Label = "Articulo más reciente",

            };
            dsInv.DataPoints.Add("Rolex", 300);
            dsInv.DataPoints.Add("Apple Watch S9", 499);
            dsInv.DataPoints.Add("Casio Mlvn", 250);

            dsInv.YFormat = "C";
            ChartInvDia.Datasets.Clear();
            ChartInvDia.Datasets.Add(dsInv);
            ChartInvDia.Update();


            // dataset de pagos
            var dsCat = new GunaPieDataset
            {
                Label = "Estado de pagos",

            };
            dsCat.DataPoints.Add("Pagados: 40", 40);
            dsCat.DataPoints.Add("Pendientes: 4", 4);
            dsCat.DataPoints.Add("Cancelados: 10", 10);
            dsCat.DataPoints.Add("Parciales: 30", 30);

            ChartCreAlDia.Datasets.Clear();
            ChartCreAlDia.Datasets.Add(dsCat);
            ChartCreAlDia.Update();


            //datos para el grid PROVISIONALES
            dgvResumen.Rows.Add("001", "Pagado", "$15.00", "2026-06-01", "2026-06-01");
            dgvResumen.Rows.Add("002", "Pendiente", "$15.00", "2026-06-01", "2026-06-01");
            dgvResumen.Rows.Add("003", "Parcial", "$15.00", "2026-06-01", "2026-06-01");
            dgvResumen.Rows.Add("004", "Pagado", "$15.00", "2025-06-01", "2026-06-01");
            dgvResumen.Rows.Add("005", "Cancelado", "$15.00", "2025-06-01", "2026-06-01");
            dgvResumen.Rows.Add("006", "Pendiente", "$15.00", "2024-06-01", "2026-06-01");
            dgvResumen.Rows.Add("007", "Pagado", "$15.00", "2024-06-01", "2026-06-01");
            dgvResumen.Rows.Add("008", "Parcial", "$15.00", "2024-06-01", "2026-06-01");

            /////////////////////SOLO SIGNIFICATIVO ///////////////////////
        }

        //////////////////////METODOS Y EVENTOS ///////////////////////

        private void UpdateClock()
        {
            var now = DateTime.Now;

            lblFecha.Text = now.ToString("dddd dd 'de' MMMM yyyy", new CultureInfo("es-ES"));
            lblHora.Text = now.ToString("HH:mm:ss");
        }

       

        ////////////////////////FIN METODOS Y EVENTOS ///////////////////////
    }
}
