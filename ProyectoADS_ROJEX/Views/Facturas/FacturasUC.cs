using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProyectoADS_ROJEX.Views.Perfil
{
    public partial class FacturasUC : UserControl
    {
        public FacturasUC()
        {
            InitializeComponent();
            cmbEstadoFacturas.Items.Add("Todas");
            cmbEstadoFacturas.Items.Add("Pagadas");
            cmbEstadoFacturas.Items.Add("Pendientes");
            cmbEstadoFacturas.SelectedIndex = 0;


        }

      
    }
}
