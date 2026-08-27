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
            label4 = new Label();
            label5 = new Label();
            cmbProveedor = new ComboBox();
            dtpFecha = new DateTimePicker();
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
            lblLote = new Label();
            txtCodigoLote = new TextBox();
            btnLimpiar = new Button();
            lblStockActual = new Label();
            btnVerLotes = new Button();
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
            label2.Location = new Point(363, 30);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 0;
            label2.Text = "Fecha";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 574);
            label4.Name = "label4";
            label4.Size = new Size(32, 15);
            label4.TabIndex = 0;
            label4.Text = "Total";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 241);
            label5.Name = "label5";
            label5.Size = new Size(677, 15);
            label5.TabIndex = 1;
            label5.Text = "--------------------------------------------------------------------------------------------------------------------------------------";
            // 
            // cmbProveedor
            // 
            cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(117, 27);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(217, 23);
            cmbProveedor.TabIndex = 2;
            cmbProveedor.SelectedIndexChanged += cmbProveedor_SelectedIndexChanged;
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(444, 24);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(107, 23);
            dtpFecha.TabIndex = 3;
            // 
            // txtTotal
            // 
            txtTotal.BackColor = SystemColors.ControlLight;
            txtTotal.Location = new Point(117, 571);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(161, 23);
            txtTotal.TabIndex = 5;
            txtTotal.TextAlign = HorizontalAlignment.Right;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(312, 264);
            label6.Name = "label6";
            label6.Size = new Size(79, 25);
            label6.TabIndex = 6;
            label6.Text = "Detalles";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(29, 69);
            label7.Name = "label7";
            label7.Size = new Size(56, 15);
            label7.TabIndex = 7;
            label7.Text = "Producto";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(28, 106);
            label8.Name = "label8";
            label8.Size = new Size(55, 15);
            label8.TabIndex = 7;
            label8.Text = "Cantidad";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(29, 138);
            label9.Name = "label9";
            label9.Size = new Size(82, 15);
            label9.TabIndex = 7;
            label9.Text = "Costo unitario";
            // 
            // cmbProductoAgregar
            // 
            cmbProductoAgregar.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProductoAgregar.FormattingEnabled = true;
            cmbProductoAgregar.Location = new Point(117, 66);
            cmbProductoAgregar.Name = "cmbProductoAgregar";
            cmbProductoAgregar.Size = new Size(217, 23);
            cmbProductoAgregar.TabIndex = 8;
            cmbProductoAgregar.SelectedIndexChanged += cmbProductoAgregar_SelectedIndexChanged;
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(117, 106);
            nudCantidad.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(56, 23);
            nudCantidad.TabIndex = 9;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtCostoUnitario
            // 
            txtCostoUnitario.Location = new Point(117, 135);
            txtCostoUnitario.MaxLength = 13;
            txtCostoUnitario.Name = "txtCostoUnitario";
            txtCostoUnitario.Size = new Size(161, 23);
            txtCostoUnitario.TabIndex = 10;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(312, 183);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 37);
            btnAgregar.TabIndex = 11;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dgvDetalles
            // 
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(134, 309);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.Size = new Size(417, 214);
            dgvDetalles.TabIndex = 12;
            dgvDetalles.CellContentClick += dgvDetalles_CellContentClick;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(577, 405);
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
            label10.Location = new Point(29, 541);
            label10.Name = "label10";
            label10.Size = new Size(687, 15);
            label10.TabIndex = 14;
            label10.Text = "----------------------------------------------------------------------------------------------------------------------------------------";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(166, 614);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(96, 37);
            btnGuardar.TabIndex = 15;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(444, 614);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(96, 37);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblLote
            // 
            lblLote.AutoSize = true;
            lblLote.Location = new Point(364, 69);
            lblLote.Name = "lblLote";
            lblLote.Size = new Size(47, 15);
            lblLote.TabIndex = 16;
            lblLote.Text = "N° Lote";
            // 
            // txtCodigoLote
            // 
            txtCodigoLote.Location = new Point(444, 66);
            txtCodigoLote.Name = "txtCodigoLote";
            txtCodigoLote.Size = new Size(107, 23);
            txtCodigoLote.TabIndex = 17;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(312, 614);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(90, 37);
            btnLimpiar.TabIndex = 18;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // lblStockActual
            // 
            lblStockActual.AutoSize = true;
            lblStockActual.Location = new Point(179, 108);
            lblStockActual.Name = "lblStockActual";
            lblStockActual.Size = new Size(73, 15);
            lblStockActual.TabIndex = 19;
            lblStockActual.Text = "Stock Actual";
            // 
            // btnVerLotes
            // 
            btnVerLotes.Location = new Point(444, 116);
            btnVerLotes.Name = "btnVerLotes";
            btnVerLotes.Size = new Size(79, 37);
            btnVerLotes.TabIndex = 20;
            btnVerLotes.Text = "Ver lotes";
            btnVerLotes.UseVisualStyleBackColor = true;
            btnVerLotes.Click += btnVerLotes_Click;
            // 
            // Compras
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 251, 252);
            ClientSize = new Size(735, 681);
            Controls.Add(btnVerLotes);
            Controls.Add(lblStockActual);
            Controls.Add(btnLimpiar);
            Controls.Add(txtCodigoLote);
            Controls.Add(lblLote);
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
            Controls.Add(dtpFecha);
            Controls.Add(cmbProveedor);
            Controls.Add(label5);
            Controls.Add(label4);
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
        private Label label4;
        private Label label5;
        private ComboBox cmbProveedor;
        private DateTimePicker dtpFecha;
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
        private Label lblLote;
        private TextBox txtCodigoLote;
        private Button btnLimpiar;
        private Label lblStockActual;
        private Button btnVerLotes;
    }
}