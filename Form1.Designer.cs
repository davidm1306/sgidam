namespace sgidam
{
    partial class FormInicioDeSesion
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicioDeSesion));
            btnIngresar = new Button();
            btnLimpiar = new Button();
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            label1 = new Label();
            pbUsuario = new PictureBox();
            pbPassword = new PictureBox();
            pbShow = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbUsuario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbShow).BeginInit();
            SuspendLayout();
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(248, 215);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(75, 30);
            btnIngresar.TabIndex = 3;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(341, 215);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 30);
            btnLimpiar.TabIndex = 0;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.FromArgb(224, 251, 252);
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.ForeColor = Color.DimGray;
            txtUsuario.Location = new Point(246, 75);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(170, 16);
            txtUsuario.TabIndex = 1;
            txtUsuario.Text = "USUARIO";
            txtUsuario.Enter += txtUsuario_Enter;
            txtUsuario.Leave += txtUsuario_Leave;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(224, 251, 252);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.ForeColor = Color.DimGray;
            txtPassword.Location = new Point(246, 134);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(170, 16);
            txtPassword.TabIndex = 2;
            txtPassword.Text = "CONTRASEÑA";
            txtPassword.Enter += txtPassword_Enter;
            txtPassword.KeyDown += txtPassword_KeyDown;
            txtPassword.Leave += txtPassword_Leave;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_principal_removebg_preview;
            pictureBox1.ImageLocation = "";
            pictureBox1.InitialImage = Properties.Resources.logo_principal_removebg_preview;
            pictureBox1.Location = new Point(-3, 75);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(152, 193, 217);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 281);
            panel1.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(301, 19);
            label1.Name = "label1";
            label1.Size = new Size(71, 25);
            label1.TabIndex = 8;
            label1.Text = "LOGIN";
            // 
            // pbUsuario
            // 
            pbUsuario.BackgroundImage = Properties.Resources.usuario;
            pbUsuario.Image = Properties.Resources.usuario;
            pbUsuario.InitialImage = null;
            pbUsuario.Location = new Point(210, 70);
            pbUsuario.Name = "pbUsuario";
            pbUsuario.Size = new Size(30, 25);
            pbUsuario.SizeMode = PictureBoxSizeMode.StretchImage;
            pbUsuario.TabIndex = 9;
            pbUsuario.TabStop = false;
            // 
            // pbPassword
            // 
            pbPassword.BackgroundImage = Properties.Resources.usuario;
            pbPassword.Image = Properties.Resources.pass;
            pbPassword.InitialImage = null;
            pbPassword.Location = new Point(210, 130);
            pbPassword.Name = "pbPassword";
            pbPassword.Size = new Size(30, 25);
            pbPassword.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPassword.TabIndex = 10;
            pbPassword.TabStop = false;
            // 
            // pbShow
            // 
            pbShow.BackgroundImage = Properties.Resources.usuario;
            pbShow.Image = Properties.Resources.ver_password;
            pbShow.InitialImage = null;
            pbShow.Location = new Point(418, 130);
            pbShow.Name = "pbShow";
            pbShow.Size = new Size(30, 25);
            pbShow.SizeMode = PictureBoxSizeMode.StretchImage;
            pbShow.TabIndex = 11;
            pbShow.TabStop = false;
            pbShow.Click += pbShow_Click;
            // 
            // FormInicioDeSesion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(224, 251, 252);
            ClientSize = new Size(456, 281);
            Controls.Add(pbShow);
            Controls.Add(pbPassword);
            Controls.Add(pbUsuario);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(txtPassword);
            Controls.Add(txtUsuario);
            Controls.Add(btnLimpiar);
            Controls.Add(btnIngresar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormInicioDeSesion";
            Opacity = 0.95D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio de sesión";
            Load += Form1_Load;
            Paint += FormInicioDeSesion_Paint;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbUsuario).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbShow).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnIngresar;
        private Button btnLimpiar;
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Label label1;
        private PictureBox pbUsuario;
        private PictureBox pbPassword;
        private PictureBox pbShow;
    }
}
