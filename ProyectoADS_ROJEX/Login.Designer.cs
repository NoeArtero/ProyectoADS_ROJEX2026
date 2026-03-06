namespace ProyectoADS_ROJEX
{
    partial class Login
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            loginView = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            panelHeader = new Guna.UI2.WinForms.Guna2Panel();
            lblTitulo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblInicioSesion = new Guna.UI2.WinForms.Guna2HtmlLabel();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // loginView
            // 
            loginView.ContainerControl = this;
            loginView.DockIndicatorTransparencyValue = 0.6D;
            loginView.TransparentWhileDrag = true;
            // 
            // panelHeader
            // 
            panelHeader.AutoScroll = true;
            panelHeader.Controls.Add(lblInicioSesion);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.CustomizableEdges = customizableEdges1;
            panelHeader.Dock = DockStyle.Top;
            panelHeader.FillColor = Color.FromArgb(28, 30, 68);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(18, 16, 18, 16);
            panelHeader.ShadowDecoration.BorderRadius = 5;
            panelHeader.ShadowDecoration.Color = Color.FromArgb(29, 27, 52);
            panelHeader.ShadowDecoration.CustomizableEdges = customizableEdges2;
            panelHeader.ShadowDecoration.Depth = 5;
            panelHeader.Size = new Size(970, 93);
            panelHeader.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Bahnschrift SemiCondensed", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.Gainsboro;
            lblTitulo.Location = new Point(434, 30);
            lblTitulo.Margin = new Padding(3, 4, 3, 4);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(77, 43);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Rojex";
            lblTitulo.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // lblInicioSesion
            // 
            lblInicioSesion.BackColor = Color.Transparent;
            lblInicioSesion.Font = new Font("Bahnschrift SemiCondensed", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInicioSesion.ForeColor = Color.Gainsboro;
            lblInicioSesion.Location = new Point(12, 30);
            lblInicioSesion.Margin = new Padding(3, 4, 3, 4);
            lblInicioSesion.Name = "lblInicioSesion";
            lblInicioSesion.Size = new Size(208, 43);
            lblInicioSesion.TabIndex = 1;
            lblInicioSesion.Text = "Inicio de sesión";
            lblInicioSesion.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(970, 477);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            Text = "Login";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm loginView;
        private Guna.UI2.WinForms.Guna2Panel panelHeader;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitulo;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblInicioSesion;
    }
}