namespace sgidam
{
    partial class EditarProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarProveedor));
            btnCancelar = new Button();
            btnGuardar = new Button();
            cmbEstatus = new ComboBox();
            txtDireccion = new TextBox();
            txtTelefono = new TextBox();
            txtCorreo = new TextBox();
            txtNombre = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(288, 209);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(80, 35);
            btnCancelar.TabIndex = 21;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(152, 209);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(91, 35);
            btnGuardar.TabIndex = 20;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // cmbEstatus
            // 
            cmbEstatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstatus.FormattingEnabled = true;
            cmbEstatus.Items.AddRange(new object[] { "J", "G", "V" });
            cmbEstatus.Location = new Point(186, 149);
            cmbEstatus.Name = "cmbEstatus";
            cmbEstatus.Size = new Size(100, 23);
            cmbEstatus.TabIndex = 19;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(186, 120);
            txtDireccion.MaxLength = 255;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(182, 23);
            txtDireccion.TabIndex = 18;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(186, 88);
            txtTelefono.MaxLength = 11;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(182, 23);
            txtTelefono.TabIndex = 17;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(186, 59);
            txtCorreo.MaxLength = 45;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(182, 23);
            txtCorreo.TabIndex = 15;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(186, 30);
            txtNombre.MaxLength = 100;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(182, 23);
            txtNombre.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(136, 152);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 10;
            label6.Text = "Estatus";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(123, 123);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 11;
            label5.Text = "Dirección";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(123, 91);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 12;
            label4.Text = "Teléfono";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(132, 62);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 13;
            label3.Text = "Correo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 33);
            label2.Name = "label2";
            label2.Size = new Size(130, 15);
            label2.TabIndex = 14;
            label2.Text = "Nombre o Razon Social";
            // 
            // EditarProveedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 251, 252);
            ClientSize = new Size(429, 284);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(cmbEstatus);
            Controls.Add(txtDireccion);
            Controls.Add(txtTelefono);
            Controls.Add(txtCorreo);
            Controls.Add(txtNombre);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EditarProveedor";
            Text = "EditarProveedor";
            Load += EditarProveedor_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnGuardar;
        private ComboBox cmbEstatus;
        private TextBox txtDireccion;
        private TextBox txtTelefono;
        private TextBox txtCorreo;
        private TextBox txtNombre;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
    }
}