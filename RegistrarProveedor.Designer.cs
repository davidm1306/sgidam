namespace sgidam
{
    partial class RegistrarProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarProveedor));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtRifNumero = new TextBox();
            cmbTipoRif = new ComboBox();
            cmbEstatus = new ComboBox();
            txtNombre = new TextBox();
            txtCorreo = new TextBox();
            txtTelefono = new TextBox();
            txtDireccion = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(128, 19);
            label1.Name = "label1";
            label1.Size = new Size(23, 15);
            label1.TabIndex = 0;
            label1.Text = "RIF";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 46);
            label2.Name = "label2";
            label2.Size = new Size(130, 15);
            label2.TabIndex = 0;
            label2.Text = "Nombre o Razon Social";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(108, 75);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 0;
            label3.Text = "Correo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(99, 104);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 0;
            label4.Text = "Teléfono";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(99, 136);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 0;
            label5.Text = "Dirección";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(112, 165);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 0;
            label6.Text = "Estatus";
            // 
            // txtRifNumero
            // 
            txtRifNumero.Location = new Point(201, 16);
            txtRifNumero.MaxLength = 11;
            txtRifNumero.Name = "txtRifNumero";
            txtRifNumero.Size = new Size(100, 23);
            txtRifNumero.TabIndex = 2;
            // 
            // cmbTipoRif
            // 
            cmbTipoRif.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoRif.FormattingEnabled = true;
            cmbTipoRif.Items.AddRange(new object[] { "J", "G", "V" });
            cmbTipoRif.Location = new Point(162, 16);
            cmbTipoRif.Name = "cmbTipoRif";
            cmbTipoRif.Size = new Size(33, 23);
            cmbTipoRif.TabIndex = 1;
            // 
            // cmbEstatus
            // 
            cmbEstatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstatus.FormattingEnabled = true;
            cmbEstatus.Items.AddRange(new object[] { "J", "G", "V" });
            cmbEstatus.Location = new Point(162, 162);
            cmbEstatus.Name = "cmbEstatus";
            cmbEstatus.Size = new Size(100, 23);
            cmbEstatus.TabIndex = 7;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(162, 43);
            txtNombre.MaxLength = 100;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(277, 23);
            txtNombre.TabIndex = 3;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(162, 72);
            txtCorreo.MaxLength = 45;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(277, 23);
            txtCorreo.TabIndex = 1;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(162, 101);
            txtTelefono.MaxLength = 11;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(100, 23);
            txtTelefono.TabIndex = 5;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(162, 133);
            txtDireccion.MaxLength = 255;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(277, 23);
            txtDireccion.TabIndex = 6;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(128, 222);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(91, 35);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(264, 222);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(80, 35);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // RegistrarProveedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 251, 252);
            ClientSize = new Size(464, 286);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(cmbEstatus);
            Controls.Add(cmbTipoRif);
            Controls.Add(txtDireccion);
            Controls.Add(txtTelefono);
            Controls.Add(txtCorreo);
            Controls.Add(txtNombre);
            Controls.Add(txtRifNumero);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RegistrarProveedor";
            Text = "RegistrarProveedor";
            Load += RegistrarProveedor_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtRifNumero;
        private ComboBox cmbTipoRif;
        private ComboBox cmbEstatus;
        private TextBox txtNombre;
        private TextBox txtCorreo;
        private TextBox txtTelefono;
        private TextBox txtDireccion;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}