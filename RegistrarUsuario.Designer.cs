namespace sgidam
{
    partial class RegistrarUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarUsuario));
            lblNombreEmpleado = new Label();
            lblApellidoEmpleado = new Label();
            lblNombreUsuario = new Label();
            lblContraseña = new Label();
            lblConfirmarContra = new Label();
            lblRol = new Label();
            lblEstatus = new Label();
            lblCedula = new Label();
            txtNombreEmpleado = new TextBox();
            txtApellido = new TextBox();
            txtCedula = new TextBox();
            txtNombreUsuario = new TextBox();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            cmbRol = new ComboBox();
            cmbEstatus = new ComboBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblNombreEmpleado
            // 
            lblNombreEmpleado.AutoSize = true;
            lblNombreEmpleado.Location = new Point(36, 18);
            lblNombreEmpleado.Name = "lblNombreEmpleado";
            lblNombreEmpleado.Size = new Size(126, 15);
            lblNombreEmpleado.TabIndex = 0;
            lblNombreEmpleado.Text = "Nombre del Empleado";
            // 
            // lblApellidoEmpleado
            // 
            lblApellidoEmpleado.AutoSize = true;
            lblApellidoEmpleado.Location = new Point(55, 50);
            lblApellidoEmpleado.Name = "lblApellidoEmpleado";
            lblApellidoEmpleado.Size = new Size(107, 15);
            lblApellidoEmpleado.TabIndex = 1;
            lblApellidoEmpleado.Text = "Apellido Empleado";
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Location = new Point(55, 116);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(110, 15);
            lblNombreUsuario.TabIndex = 2;
            lblNombreUsuario.Text = "Nombre de Usuario";
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Location = new Point(98, 150);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(67, 15);
            lblContraseña.TabIndex = 3;
            lblContraseña.Text = "Contraseña";
            // 
            // lblConfirmarContra
            // 
            lblConfirmarContra.AutoSize = true;
            lblConfirmarContra.Location = new Point(39, 184);
            lblConfirmarContra.Name = "lblConfirmarContra";
            lblConfirmarContra.Size = new Size(124, 15);
            lblConfirmarContra.TabIndex = 4;
            lblConfirmarContra.Text = "Confirmar Contraseña";
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Location = new Point(138, 216);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(24, 15);
            lblRol.TabIndex = 5;
            lblRol.Text = "Rol";
            // 
            // lblEstatus
            // 
            lblEstatus.AutoSize = true;
            lblEstatus.Location = new Point(119, 251);
            lblEstatus.Name = "lblEstatus";
            lblEstatus.Size = new Size(44, 15);
            lblEstatus.TabIndex = 6;
            lblEstatus.Text = "Estatus";
            // 
            // lblCedula
            // 
            lblCedula.AutoSize = true;
            lblCedula.Location = new Point(118, 83);
            lblCedula.Name = "lblCedula";
            lblCedula.Size = new Size(44, 15);
            lblCedula.TabIndex = 7;
            lblCedula.Text = "Cédula";
            // 
            // txtNombreEmpleado
            // 
            txtNombreEmpleado.Location = new Point(175, 15);
            txtNombreEmpleado.MaxLength = 45;
            txtNombreEmpleado.Name = "txtNombreEmpleado";
            txtNombreEmpleado.Size = new Size(121, 23);
            txtNombreEmpleado.TabIndex = 1;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(175, 47);
            txtApellido.MaxLength = 100;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(121, 23);
            txtApellido.TabIndex = 2;
            // 
            // txtCedula
            // 
            txtCedula.Location = new Point(175, 80);
            txtCedula.MaxLength = 20;
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(121, 23);
            txtCedula.TabIndex = 3;
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(175, 113);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(121, 23);
            txtNombreUsuario.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(175, 147);
            txtPassword.MaxLength = 50;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(121, 23);
            txtPassword.TabIndex = 5;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(175, 181);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(121, 23);
            txtConfirmPassword.TabIndex = 6;
            txtConfirmPassword.TextChanged += txtConfirmPassword_TextChanged;
            // 
            // cmbRol
            // 
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(175, 213);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(121, 23);
            cmbRol.TabIndex = 7;
            // 
            // cmbEstatus
            // 
            cmbEstatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstatus.FormattingEnabled = true;
            cmbEstatus.Location = new Point(175, 243);
            cmbEstatus.Name = "cmbEstatus";
            cmbEstatus.Size = new Size(121, 23);
            cmbEstatus.TabIndex = 8;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.Control;
            btnGuardar.Location = new Point(66, 305);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(81, 36);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(175, 305);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(76, 36);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // RegistrarUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 251, 252);
            ClientSize = new Size(326, 366);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(cmbEstatus);
            Controls.Add(cmbRol);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(txtNombreUsuario);
            Controls.Add(txtCedula);
            Controls.Add(txtApellido);
            Controls.Add(txtNombreEmpleado);
            Controls.Add(lblCedula);
            Controls.Add(lblEstatus);
            Controls.Add(lblRol);
            Controls.Add(lblConfirmarContra);
            Controls.Add(lblContraseña);
            Controls.Add(lblNombreUsuario);
            Controls.Add(lblApellidoEmpleado);
            Controls.Add(lblNombreEmpleado);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RegistrarUsuario";
            Text = "RegistrarUsuario";
            Load += RegistrarUsuario_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombreEmpleado;
        private Label lblApellidoEmpleado;
        private Label lblNombreUsuario;
        private Label lblContraseña;
        private Label lblConfirmarContra;
        private Label lblRol;
        private Label lblEstatus;
        private Label lblCedula;
        private TextBox txtNombreEmpleado;
        private TextBox txtApellido;
        private TextBox txtCedula;
        private TextBox txtNombreUsuario;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private ComboBox cmbRol;
        private ComboBox cmbEstatus;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}