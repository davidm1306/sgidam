namespace sgidam
{
    partial class ListaProveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaProveedores));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            cmbProveedor = new ComboBox();
            cmbProducto = new ComboBox();
            txtPrecio = new TextBox();
            lblTitulo = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 57);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 0;
            label1.Text = "Proveedor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 87);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 0;
            label2.Text = "Producto";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 123);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 0;
            label3.Text = "Precio";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(74, 179);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(80, 33);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(179, 179);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(80, 33);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // cmbProveedor
            // 
            cmbProveedor.DisplayMember = "nombre_proveedor";
            cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(96, 54);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(217, 23);
            cmbProveedor.TabIndex = 3;
            cmbProveedor.ValueMember = "id_proveedor";
            // 
            // cmbProducto
            // 
            cmbProducto.DisplayMember = "nombre_producto";
            cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducto.FormattingEnabled = true;
            cmbProducto.Location = new Point(95, 87);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(218, 23);
            cmbProducto.TabIndex = 4;
            cmbProducto.ValueMember = "id_producto";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(95, 120);
            txtPrecio.MaxLength = 12;
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(86, 23);
            txtPrecio.TabIndex = 3;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.Location = new Point(29, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(288, 21);
            lblTitulo.TabIndex = 5;
            lblTitulo.Text = "Registrar productos por proveedores";
            // 
            // ListaProveedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 251, 252);
            ClientSize = new Size(340, 239);
            Controls.Add(lblTitulo);
            Controls.Add(txtPrecio);
            Controls.Add(cmbProducto);
            Controls.Add(cmbProveedor);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ListaProveedores";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ListaProveedores";
            Load += ListaProveedores_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnGuardar;
        private Button btnCancelar;
        private ComboBox cmbProveedor;
        private ComboBox cmbProducto;
        private TextBox txtPrecio;
        private Label lblTitulo;
    }
}