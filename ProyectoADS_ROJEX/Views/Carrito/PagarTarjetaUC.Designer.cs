namespace ProyectoADS_ROJEX.Views.Carrito
{
    partial class PagarTarjetaUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            panelTitulo = new Guna.UI2.WinForms.Guna2GradientPanel();
            label6 = new Label();
            groupBox2 = new GroupBox();
            mtbFechaExpiracionTarjeta = new MaskedTextBox();
            txtNomTit = new TextBox();
            label5 = new Label();
            txtCVV = new TextBox();
            label1 = new Label();
            txtNtarjeta = new TextBox();
            label7 = new Label();
            label8 = new Label();
            groupBox1 = new GroupBox();
            txtCliente = new TextBox();
            txtId = new TextBox();
            txtFecha = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            progressBar1 = new ProgressBar();
            btnCancelarTargeta = new Guna.UI2.WinForms.Guna2GradientButton();
            btnGuardarTargeta = new Guna.UI2.WinForms.Guna2GradientButton();
            dgvCarrito = new Guna.UI2.WinForms.Guna2DataGridView();
            txtTotal = new TextBox();
            label9 = new Label();
            groupBox3 = new GroupBox();
            label11 = new Label();
            txtEnvio = new TextBox();
            label10 = new Label();
            txtSubtotal = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            panelTitulo.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // panelTitulo
            // 
            panelTitulo.Controls.Add(label6);
            panelTitulo.CustomizableEdges = customizableEdges5;
            panelTitulo.Dock = DockStyle.Top;
            panelTitulo.FillColor = Color.FromArgb(28, 30, 68);
            panelTitulo.FillColor2 = Color.FromArgb(16, 15, 38);
            panelTitulo.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panelTitulo.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            panelTitulo.Location = new Point(0, 0);
            panelTitulo.Name = "panelTitulo";
            panelTitulo.ShadowDecoration.CustomizableEdges = customizableEdges6;
            panelTitulo.Size = new Size(870, 61);
            panelTitulo.TabIndex = 7;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Bahnschrift SemiBold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.WhiteSmoke;
            label6.Location = new Point(315, 12);
            label6.Name = "label6";
            label6.Size = new Size(263, 34);
            label6.TabIndex = 5;
            label6.Text = "PAGO CON TARJETA";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(mtbFechaExpiracionTarjeta);
            groupBox2.Controls.Add(txtNomTit);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtCVV);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(txtNtarjeta);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label8);
            groupBox2.Location = new Point(30, 148);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(810, 107);
            groupBox2.TabIndex = 26;
            groupBox2.TabStop = false;
            // 
            // mtbFechaExpiracionTarjeta
            // 
            mtbFechaExpiracionTarjeta.Font = new Font("Bahnschrift Condensed", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mtbFechaExpiracionTarjeta.Location = new Point(177, 65);
            mtbFechaExpiracionTarjeta.Mask = "00/00";
            mtbFechaExpiracionTarjeta.Name = "mtbFechaExpiracionTarjeta";
            mtbFechaExpiracionTarjeta.Size = new Size(125, 28);
            mtbFechaExpiracionTarjeta.TabIndex = 15;
            mtbFechaExpiracionTarjeta.ValidatingType = typeof(DateTime);
            // 
            // txtNomTit
            // 
            txtNomTit.Font = new Font("Bahnschrift Condensed", 10.2F);
            txtNomTit.Location = new Point(558, 19);
            txtNomTit.Name = "txtNomTit";
            txtNomTit.Size = new Size(220, 28);
            txtNomTit.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Bahnschrift SemiCondensed", 12F);
            label5.ForeColor = Color.FromArgb(64, 64, 64);
            label5.Location = new Point(402, 22);
            label5.Name = "label5";
            label5.Size = new Size(150, 24);
            label5.TabIndex = 13;
            label5.Text = "NOMBRE TITULAR:";
            // 
            // txtCVV
            // 
            txtCVV.Font = new Font("Bahnschrift Condensed", 10.2F);
            txtCVV.Location = new Point(558, 62);
            txtCVV.MaxLength = 3;
            txtCVV.Name = "txtCVV";
            txtCVV.Size = new Size(113, 28);
            txtCVV.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiCondensed", 12F);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(402, 66);
            label1.Name = "label1";
            label1.Size = new Size(44, 24);
            label1.TabIndex = 11;
            label1.Text = "CVV:";
            // 
            // txtNtarjeta
            // 
            txtNtarjeta.Font = new Font("Bahnschrift Condensed", 10.2F);
            txtNtarjeta.Location = new Point(165, 19);
            txtNtarjeta.MaxLength = 16;
            txtNtarjeta.Name = "txtNtarjeta";
            txtNtarjeta.Size = new Size(203, 28);
            txtNtarjeta.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Bahnschrift SemiCondensed", 12F);
            label7.ForeColor = Color.FromArgb(64, 64, 64);
            label7.Location = new Point(7, 66);
            label7.Name = "label7";
            label7.Size = new Size(164, 24);
            label7.TabIndex = 7;
            label7.Text = "FECHA EXPIRACIÓN:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Bahnschrift SemiCondensed", 12F);
            label8.ForeColor = Color.FromArgb(64, 64, 64);
            label8.Location = new Point(7, 22);
            label8.Name = "label8";
            label8.Size = new Size(104, 24);
            label8.TabIndex = 6;
            label8.Text = "N° TARJETA:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtCliente);
            groupBox1.Controls.Add(txtId);
            groupBox1.Controls.Add(txtFecha);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(30, 77);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(810, 65);
            groupBox1.TabIndex = 25;
            groupBox1.TabStop = false;
            // 
            // txtCliente
            // 
            txtCliente.Font = new Font("Bahnschrift Condensed", 10.2F);
            txtCliente.Location = new Point(575, 23);
            txtCliente.Name = "txtCliente";
            txtCliente.ReadOnly = true;
            txtCliente.Size = new Size(217, 28);
            txtCliente.TabIndex = 17;
            // 
            // txtId
            // 
            txtId.Font = new Font("Bahnschrift Condensed", 10.2F);
            txtId.Location = new Point(349, 23);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(125, 28);
            txtId.TabIndex = 16;
            // 
            // txtFecha
            // 
            txtFecha.Font = new Font("Bahnschrift Condensed", 10.2F);
            txtFecha.Location = new Point(75, 23);
            txtFecha.Name = "txtFecha";
            txtFecha.ReadOnly = true;
            txtFecha.Size = new Size(217, 28);
            txtFecha.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Bahnschrift SemiCondensed", 12F);
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Location = new Point(505, 29);
            label4.Name = "label4";
            label4.Size = new Size(78, 24);
            label4.TabIndex = 14;
            label4.Text = "CLIENTE:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bahnschrift SemiCondensed", 12F);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(315, 29);
            label3.Name = "label3";
            label3.Size = new Size(29, 24);
            label3.TabIndex = 13;
            label3.Text = "ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift SemiCondensed", 12F);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(15, 29);
            label2.Name = "label2";
            label2.Size = new Size(65, 24);
            label2.TabIndex = 12;
            label2.Text = "FECHA:";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(570, 519);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(270, 37);
            progressBar1.TabIndex = 24;
            // 
            // btnCancelarTargeta
            // 
            btnCancelarTargeta.BorderRadius = 10;
            btnCancelarTargeta.CustomizableEdges = customizableEdges1;
            btnCancelarTargeta.DisabledState.BorderColor = Color.DarkGray;
            btnCancelarTargeta.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancelarTargeta.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancelarTargeta.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnCancelarTargeta.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancelarTargeta.FillColor = Color.FromArgb(29, 32, 69);
            btnCancelarTargeta.FillColor2 = Color.FromArgb(29, 32, 69);
            btnCancelarTargeta.Font = new Font("Bahnschrift Condensed", 12F);
            btnCancelarTargeta.ForeColor = Color.White;
            btnCancelarTargeta.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnCancelarTargeta.Location = new Point(305, 519);
            btnCancelarTargeta.Name = "btnCancelarTargeta";
            btnCancelarTargeta.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnCancelarTargeta.Size = new Size(171, 37);
            btnCancelarTargeta.TabIndex = 23;
            btnCancelarTargeta.Text = "CANCELAR";
            btnCancelarTargeta.Click += btnCancelarTargeta_Click;
            // 
            // btnGuardarTargeta
            // 
            btnGuardarTargeta.BorderRadius = 10;
            btnGuardarTargeta.CustomizableEdges = customizableEdges3;
            btnGuardarTargeta.DisabledState.BorderColor = Color.DarkGray;
            btnGuardarTargeta.DisabledState.CustomBorderColor = Color.DarkGray;
            btnGuardarTargeta.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnGuardarTargeta.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnGuardarTargeta.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnGuardarTargeta.FillColor = Color.FromArgb(29, 32, 69);
            btnGuardarTargeta.FillColor2 = Color.FromArgb(29, 32, 69);
            btnGuardarTargeta.Font = new Font("Bahnschrift Condensed", 12F);
            btnGuardarTargeta.ForeColor = Color.White;
            btnGuardarTargeta.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnGuardarTargeta.Location = new Point(108, 519);
            btnGuardarTargeta.Name = "btnGuardarTargeta";
            btnGuardarTargeta.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnGuardarTargeta.Size = new Size(171, 37);
            btnGuardarTargeta.TabIndex = 22;
            btnGuardarTargeta.Text = "PAGAR";
            btnGuardarTargeta.Click += btnGuardarTargeta_Click;
            // 
            // dgvCarrito
            // 
            dgvCarrito.AllowUserToAddRows = false;
            dgvCarrito.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(247, 216, 189);
            dgvCarrito.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvCarrito.BorderStyle = BorderStyle.FixedSingle;
            dgvCarrito.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(230, 126, 34);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(225, 94, 64);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.Control;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCarrito.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCarrito.ColumnHeadersHeight = 32;
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(249, 229, 211);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(238, 169, 107);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvCarrito.DefaultCellStyle = dataGridViewCellStyle3;
            dgvCarrito.GridColor = SystemColors.ControlLight;
            dgvCarrito.Location = new Point(30, 344);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.ReadOnly = true;
            dgvCarrito.RowHeadersVisible = false;
            dgvCarrito.RowHeadersWidth = 51;
            dgvCarrito.Size = new Size(810, 157);
            dgvCarrito.TabIndex = 20;
            dgvCarrito.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Carrot;
            dgvCarrito.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(247, 216, 189);
            dgvCarrito.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvCarrito.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvCarrito.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvCarrito.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvCarrito.ThemeStyle.BackColor = Color.White;
            dgvCarrito.ThemeStyle.GridColor = SystemColors.ControlLight;
            dgvCarrito.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(230, 126, 34);
            dgvCarrito.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvCarrito.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvCarrito.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvCarrito.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvCarrito.ThemeStyle.HeaderStyle.Height = 32;
            dgvCarrito.ThemeStyle.ReadOnly = true;
            dgvCarrito.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(249, 229, 211);
            dgvCarrito.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCarrito.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvCarrito.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            dgvCarrito.ThemeStyle.RowsStyle.Height = 29;
            dgvCarrito.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(238, 169, 107);
            dgvCarrito.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;
            // 
            // txtTotal
            // 
            txtTotal.Font = new Font("Bahnschrift Condensed", 10.2F);
            txtTotal.Location = new Point(621, 26);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(171, 28);
            txtTotal.TabIndex = 16;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Bahnschrift SemiCondensed", 12F);
            label9.ForeColor = Color.FromArgb(64, 64, 64);
            label9.Location = new Point(554, 29);
            label9.Name = "label9";
            label9.Size = new Size(61, 24);
            label9.TabIndex = 15;
            label9.Text = "TOTAL:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(txtEnvio);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(txtSubtotal);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(txtTotal);
            groupBox3.Location = new Point(30, 260);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(810, 65);
            groupBox3.TabIndex = 26;
            groupBox3.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Bahnschrift SemiCondensed", 12F);
            label11.ForeColor = Color.FromArgb(64, 64, 64);
            label11.Location = new Point(306, 31);
            label11.Name = "label11";
            label11.Size = new Size(60, 24);
            label11.TabIndex = 19;
            label11.Text = "ENVIO:";
            // 
            // txtEnvio
            // 
            txtEnvio.Font = new Font("Bahnschrift Condensed", 10.2F);
            txtEnvio.Location = new Point(377, 28);
            txtEnvio.Name = "txtEnvio";
            txtEnvio.ReadOnly = true;
            txtEnvio.Size = new Size(171, 28);
            txtEnvio.TabIndex = 20;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Bahnschrift SemiCondensed", 12F);
            label10.ForeColor = Color.FromArgb(64, 64, 64);
            label10.Location = new Point(8, 29);
            label10.Name = "label10";
            label10.Size = new Size(93, 24);
            label10.TabIndex = 17;
            label10.Text = "SUBTOTAL:";
            // 
            // txtSubtotal
            // 
            txtSubtotal.Font = new Font("Bahnschrift Condensed", 10.2F);
            txtSubtotal.Location = new Point(105, 26);
            txtSubtotal.Name = "txtSubtotal";
            txtSubtotal.ReadOnly = true;
            txtSubtotal.Size = new Size(171, 28);
            txtSubtotal.TabIndex = 18;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // PagarTarjetaUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(progressBar1);
            Controls.Add(btnCancelarTargeta);
            Controls.Add(btnGuardarTargeta);
            Controls.Add(dgvCarrito);
            Controls.Add(panelTitulo);
            Name = "PagarTarjetaUC";
            Size = new Size(870, 579);
            panelTitulo.ResumeLayout(false);
            panelTitulo.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2GradientPanel panelTitulo;
        private Label label6;
        private GroupBox groupBox2;
        private TextBox txtNtarjeta;
        private Label label7;
        private Label label8;
        private GroupBox groupBox1;
        private TextBox txtCliente;
        private TextBox txtId;
        private TextBox txtFecha;
        private Label label4;
        private Label label3;
        private Label label2;
        private ProgressBar progressBar1;
        private Guna.UI2.WinForms.Guna2GradientButton btnCancelarTargeta;
        private Guna.UI2.WinForms.Guna2GradientButton btnGuardarTargeta;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCarrito;
        private TextBox txtNomTit;
        private Label label5;
        private TextBox txtCVV;
        private Label label1;
        private GroupBox groupBox3;
        private TextBox txtTotal;
        private Label label9;
        private ErrorProvider errorProvider1;
        private Label label11;
        private TextBox txtEnvio;
        private Label label10;
        private TextBox txtSubtotal;
        private MaskedTextBox mtbFechaExpiracionTarjeta;
    }
}
