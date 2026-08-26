namespace sgidam
{
    partial class Ventas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ventas));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dgvDetalles = new DataGridView();
            btnAgregar = new Button();
            btnEliminar = new Button();
            cmbProductoAgregar = new ComboBox();
            nudCantidad = new NumericUpDown();
            txtPrecioVentaUnitario = new TextBox();
            label4 = new Label();
            label5 = new Label();
            cmbEstatus = new ComboBox();
            dtpFecha = new DateTimePicker();
            btnGuardar = new Button();
            btnCancelar = new Button();
            label6 = new Label();
            txtTotal = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 23);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 0;
            label1.Text = "Producto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 54);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 0;
            label2.Text = "Cantidad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 91);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 0;
            label3.Text = "Precio Venta";
            // 
            // dgvDetalles
            // 
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(344, 12);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.Size = new Size(444, 150);
            dgvDetalles.TabIndex = 1;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(484, 170);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(72, 33);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(575, 170);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(78, 33);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // cmbProductoAgregar
            // 
            cmbProductoAgregar.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProductoAgregar.FormattingEnabled = true;
            cmbProductoAgregar.Location = new Point(108, 20);
            cmbProductoAgregar.Name = "cmbProductoAgregar";
            cmbProductoAgregar.Size = new Size(196, 23);
            cmbProductoAgregar.TabIndex = 4;
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(109, 52);
            nudCantidad.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(49, 23);
            nudCantidad.TabIndex = 5;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtPrecioVentaUnitario
            // 
            txtPrecioVentaUnitario.Location = new Point(109, 88);
            txtPrecioVentaUnitario.MaxLength = 13;
            txtPrecioVentaUnitario.Name = "txtPrecioVentaUnitario";
            txtPrecioVentaUnitario.Size = new Size(57, 23);
            txtPrecioVentaUnitario.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(58, 130);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 0;
            label4.Text = "Estatus";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(58, 170);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 0;
            label5.Text = "Fecha";
            label5.Click += label4_Click;
            // 
            // cmbEstatus
            // 
            cmbEstatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstatus.FormattingEnabled = true;
            cmbEstatus.Location = new Point(110, 127);
            cmbEstatus.Name = "cmbEstatus";
            cmbEstatus.Size = new Size(121, 23);
            cmbEstatus.TabIndex = 7;
            // 
            // dtpFecha
            // 
            dtpFecha.Checked = false;
            dtpFecha.Location = new Point(111, 164);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(120, 23);
            dtpFecha.TabIndex = 8;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(213, 269);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(91, 35);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(344, 269);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(81, 35);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(64, 207);
            label6.Name = "label6";
            label6.Size = new Size(32, 15);
            label6.TabIndex = 11;
            label6.Text = "Total";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(112, 205);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(100, 23);
            txtTotal.TabIndex = 12;
            txtTotal.Text = "0.00";
            // 
            // Ventas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 251, 252);
            ClientSize = new Size(800, 337);
            Controls.Add(txtTotal);
            Controls.Add(label6);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(dtpFecha);
            Controls.Add(cmbEstatus);
            Controls.Add(txtPrecioVentaUnitario);
            Controls.Add(nudCantidad);
            Controls.Add(cmbProductoAgregar);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvDetalles);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Ventas";
            Text = "Ventas";
            Load += Ventas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dgvDetalles;
        private Button btnAgregar;
        private Button btnEliminar;
        private ComboBox cmbProductoAgregar;
        private NumericUpDown nudCantidad;
        private TextBox txtPrecioVentaUnitario;
        private Label label4;
        private Label label5;
        private ComboBox cmbEstatus;
        private DateTimePicker dtpFecha;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label label6;
        private TextBox txtTotal;
    }
}