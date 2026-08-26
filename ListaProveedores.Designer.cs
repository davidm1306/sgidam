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
            label4 = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            cmbProveedor = new ComboBox();
            cmbProducto = new ComboBox();
            txtPrecio = new TextBox();
            cmbEstatus = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 26);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 0;
            label1.Text = "Proveedor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 56);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 0;
            label2.Text = "Producto";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 92);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 0;
            label3.Text = "Precio";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(46, 128);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 0;
            label4.Text = "Estatus";
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
            cmbProveedor.Location = new Point(96, 23);
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
            cmbProducto.Location = new Point(95, 56);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(218, 23);
            cmbProducto.TabIndex = 4;
            cmbProducto.ValueMember = "id_producto";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(95, 89);
            txtPrecio.MaxLength = 12;
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(47, 23);
            txtPrecio.TabIndex = 3;
            // 
            // cmbEstatus
            // 
            cmbEstatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstatus.FormattingEnabled = true;
            cmbEstatus.Location = new Point(95, 125);
            cmbEstatus.Name = "cmbEstatus";
            cmbEstatus.Size = new Size(95, 23);
            cmbEstatus.TabIndex = 5;
            // 
            // ListaProveedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 251, 252);
            ClientSize = new Size(325, 239);
            Controls.Add(cmbEstatus);
            Controls.Add(txtPrecio);
            Controls.Add(cmbProducto);
            Controls.Add(cmbProveedor);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ListaProveedores";
            Text = "ListaProveedores";
            Load += ListaProveedores_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnGuardar;
        private Button btnCancelar;
        private ComboBox cmbProveedor;
        private ComboBox cmbProducto;
        private TextBox txtPrecio;
        private ComboBox cmbEstatus;
    }
}