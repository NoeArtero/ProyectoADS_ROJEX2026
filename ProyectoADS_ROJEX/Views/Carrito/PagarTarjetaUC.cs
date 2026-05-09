using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProyectoADS_ROJEX.Views.Carrito
{
    public partial class PagarTarjetaUC : UserControl
    {

        public PagarTarjetaUC()
        {
            InitializeComponent();


        }


        //método para validar que los campos estén llenos
        private bool Valido()
        {
            if (txtNtarjeta.Text.IsWhiteSpace() || txtNomTit.Text.IsWhiteSpace()
                || mtbFechaExpiracionTarjeta.Text.IsWhiteSpace() || txtCVV.Text.IsWhiteSpace())
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private async void btnGuardarTargeta_Click(object sender, EventArgs e)
        {
            if (!Valido())
            {
                MessageBox.Show("Ingrese todos los datos correctamenta para pagar.", "Error de pago",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Preparar progress bar
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            progressBar1.Step = 5;
            progressBar1.Visible = true;

            // Deshabilitar controles durante el "procesamiento"
            btnGuardarTargeta.Enabled = false;
            txtNtarjeta.Enabled = false;
            txtNomTit.Enabled = false;
            mtbFechaExpiracionTarjeta.Enabled = false;
            txtCVV.Enabled = false;

            try
            {
                // Simular proceso de ~2 segundos actualizando la progress bar gradualmente
                const int step = 5;
                const int delayMs = 100; // 20 steps * 100ms = 2000ms
                for (int v = 0; v <= 100; v += step)
                {
                    progressBar1.Value = Math.Min(v, progressBar1.Maximum);
                    await Task.Delay(delayMs);
                }

                // Asegurar que quede llena
                progressBar1.Value = progressBar1.Maximum;

                // Mostrar mensaje de éxito
                MessageBox.Show("El pago ha sido realizado exitosamente.", "Pago exitoso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar los campos validados
                txtNtarjeta.Clear();
                txtNomTit.Clear();
                mtbFechaExpiracionTarjeta.Clear();
                txtCVV.Clear();

            }
            finally
            {
                // Rehabilitar controles
                btnGuardarTargeta.Enabled = true;
                txtNtarjeta.Enabled = true;
                txtNomTit.Enabled = true;
                mtbFechaExpiracionTarjeta.Enabled = true;
                txtCVV.Enabled = true;
                Parent?.Controls.Remove(this);
            }

        }

        private void btnCancelarTargeta_Click(object sender, EventArgs e)
        {
            Parent?.Controls.Remove(this);
        }
    }
}
