namespace sgidam
{
    partial class Compras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Compras));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            cmbProveedor = new ComboBox();
            dtpFecha = new DateTimePicker();
            cmbEstatus = new ComboBox();
            txtTotal = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            cmbProductoAgregar = new ComboBox();
            nudCantidad = new NumericUpDown();
            txtCostoUnitario = new TextBox();
            btnAgregar = new Button();
            dgvDetalles = new DataGridView();
            btnEliminar = new Button();
            label10 = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 30);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 0;
            label1.Text = "Proveedor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 60);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 0;
            label2.Text = "Fecha";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 89);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 0;
            label3.Text = "Estatus";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(57, 138);
            label4.Name = "label4";
            label4.Size = new Size(32, 15);
            label4.TabIndex = 0;
            label4.Text = "Total";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 174);
            label5.Name = "label5";
            label5.Size = new Size(742, 15);
            label5.TabIndex = 1;
            label5.Text = "---------------------------------------------------------------------------------------------------------------------------------------------------";
            // 
            // cmbProveedor
            // 
            cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(110, 26);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(217, 23);
            cmbProveedor.TabIndex = 2;
            cmbProveedor.SelectedIndexChanged += cmbProveedor_SelectedIndexChanged;
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(109, 57);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(100, 23);
            dtpFecha.TabIndex = 3;
            // 
            // cmbEstatus
            // 
            cmbEstatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstatus.FormattingEnabled = true;
            cmbEstatus.Location = new Point(109, 89);
            cmbEstatus.Name = "cmbEstatus";
            cmbEstatus.Size = new Size(121, 23);
            cmbEstatus.TabIndex = 4;
            // 
            // txtTotal
            // 
            txtTotal.BackColor = SystemColors.ControlLight;
            txtTotal.Location = new Point(109, 135);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(100, 23);
            txtTotal.TabIndex = 5;
            txtTotal.TextAlign = HorizontalAlignment.Right;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(332, 199);
            label6.Name = "label6";
            label6.Size = new Size(79, 25);
            label6.TabIndex = 6;
            label6.Text = "Detalles";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(60, 242);
            label7.Name = "label7";
            label7.Size = new Size(56, 15);
            label7.TabIndex = 7;
            label7.Text = "Producto";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(60, 274);
            label8.Name = "label8";
            label8.Size = new Size(55, 15);
            label8.TabIndex = 7;
            label8.Text = "Cantidad";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(34, 309);
            label9.Name = "label9";
            label9.Size = new Size(82, 15);
            label9.TabIndex = 7;
            label9.Text = "Costo unitario";
            // 
            // cmbProductoAgregar
            // 
            cmbProductoAgregar.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProductoAgregar.FormattingEnabled = true;
            cmbProductoAgregar.Location = new Point(122, 239);
            cmbProductoAgregar.Name = "cmbProductoAgregar";
            cmbProductoAgregar.Size = new Size(152, 23);
            cmbProductoAgregar.TabIndex = 8;
            cmbProductoAgregar.SelectedIndexChanged += cmbProductoAgregar_SelectedIndexChanged;
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(122, 272);
            nudCantidad.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(56, 23);
            nudCantidad.TabIndex = 9;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtCostoUnitario
            // 
            txtCostoUnitario.Location = new Point(121, 303);
            txtCostoUnitario.MaxLength = 13;
            txtCostoUnitario.Name = "txtCostoUnitario";
            txtCostoUnitario.Size = new Size(161, 23);
            txtCostoUnitario.TabIndex = 10;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(332, 266);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 30);
            btnAgregar.TabIndex = 11;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dgvDetalles
            // 
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(212, 345);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.Size = new Size(417, 150);
            dgvDetalles.TabIndex = 12;
            dgvDetalles.CellContentClick += dgvDetalles_CellContentClick;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(308, 501);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(116, 32);
            btnEliminar.TabIndex = 13;
            btnEliminar.Text = "Eliminar Producto";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(28, 536);
            label10.Name = "label10";
            label10.Size = new Size(742, 15);
            label10.TabIndex = 14;
            label10.Text = "---------------------------------------------------------------------------------------------------------------------------------------------------";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(291, 580);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(96, 37);
            btnGuardar.TabIndex = 15;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(411, 580);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(96, 37);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // Compras
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 251, 252);
            ClientSize = new Size(800, 656);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(label10);
            Controls.Add(btnEliminar);
            Controls.Add(dgvDetalles);
            Controls.Add(btnAgregar);
            Controls.Add(txtCostoUnitario);
            Controls.Add(nudCantidad);
            Controls.Add(cmbProductoAgregar);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(txtTotal);
            Controls.Add(cmbEstatus);
            Controls.Add(dtpFecha);
            Controls.Add(cmbProveedor);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Compras";
            Text = "Compras";
            Load += Compras_Load;
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox cmbProveedor;
        private DateTimePicker dtpFecha;
        private ComboBox cmbEstatus;
        private TextBox txtTotal;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private ComboBox cmbProductoAgregar;
        private NumericUpDown nudCantidad;
        private TextBox txtCostoUnitario;
        private Button btnAgregar;
        private DataGridView dgvDetalles;
        private Button btnEliminar;
        private Label label10;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}