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
            label5 = new Label();
            dtpFecha = new DateTimePicker();
            btnGuardar = new Button();
            btnCancelar = new Button();
            lblTotal = new Label();
            txtTotal = new TextBox();
            gbCliente = new GroupBox();
            btnLimpiarCliente = new Button();
            txtTelefonoCliente = new TextBox();
            txtDireccionCliente = new TextBox();
            lblTelefono = new Label();
            lblDireccion = new Label();
            txtNombreCliente = new TextBox();
            lblNombreCliente = new Label();
            txtNumDoc = new TextBox();
            cmbTipoDoc = new ComboBox();
            lblTipoDoc = new Label();
            lblNumFactura = new Label();
            txtNumFactura = new TextBox();
            lblNumcontrol = new Label();
            txtNumControl = new TextBox();
            lblImpuestos = new Label();
            txtImpuestos = new TextBox();
            lblSubtotal = new Label();
            txtSubTotal = new TextBox();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            gbCliente.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 310);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 0;
            label1.Text = "Producto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(315, 310);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 0;
            label2.Text = "Cantidad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(432, 310);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 0;
            label3.Text = "Precio Venta";
            // 
            // dgvDetalles
            // 
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(101, 401);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.Size = new Size(444, 150);
            dgvDetalles.TabIndex = 1;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(257, 352);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(72, 33);
            btnAgregar.TabIndex = 11;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(348, 352);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(78, 33);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // cmbProductoAgregar
            // 
            cmbProductoAgregar.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProductoAgregar.FormattingEnabled = true;
            cmbProductoAgregar.Location = new Point(111, 307);
            cmbProductoAgregar.Name = "cmbProductoAgregar";
            cmbProductoAgregar.Size = new Size(196, 23);
            cmbProductoAgregar.TabIndex = 8;
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(377, 308);
            nudCantidad.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(49, 23);
            nudCantidad.TabIndex = 9;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtPrecioVentaUnitario
            // 
            txtPrecioVentaUnitario.Location = new Point(511, 307);
            txtPrecioVentaUnitario.MaxLength = 13;
            txtPrecioVentaUnitario.Name = "txtPrecioVentaUnitario";
            txtPrecioVentaUnitario.Size = new Size(57, 23);
            txtPrecioVentaUnitario.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(432, 160);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 0;
            label5.Text = "Fecha";
            label5.Click += label4_Click;
            // 
            // dtpFecha
            // 
            dtpFecha.Checked = false;
            dtpFecha.CustomFormat = "";
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(501, 154);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(116, 23);
            dtpFecha.TabIndex = 7;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(180, 683);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(91, 35);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(311, 683);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(81, 35);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(235, 633);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(32, 15);
            lblTotal.TabIndex = 11;
            lblTotal.Text = "Total";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(299, 633);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(100, 23);
            txtTotal.TabIndex = 0;
            txtTotal.TabStop = false;
            txtTotal.Text = "0.00";
            // 
            // gbCliente
            // 
            gbCliente.Controls.Add(btnLimpiarCliente);
            gbCliente.Controls.Add(txtTelefonoCliente);
            gbCliente.Controls.Add(txtDireccionCliente);
            gbCliente.Controls.Add(lblTelefono);
            gbCliente.Controls.Add(lblDireccion);
            gbCliente.Controls.Add(txtNombreCliente);
            gbCliente.Controls.Add(lblNombreCliente);
            gbCliente.Controls.Add(txtNumDoc);
            gbCliente.Controls.Add(cmbTipoDoc);
            gbCliente.Controls.Add(lblTipoDoc);
            gbCliente.Location = new Point(33, 61);
            gbCliente.Name = "gbCliente";
            gbCliente.Size = new Size(371, 208);
            gbCliente.TabIndex = 13;
            gbCliente.TabStop = false;
            gbCliente.Text = "Datos del Cliente";
            // 
            // btnLimpiarCliente
            // 
            btnLimpiarCliente.Location = new Point(152, 165);
            btnLimpiarCliente.Name = "btnLimpiarCliente";
            btnLimpiarCliente.Size = new Size(75, 37);
            btnLimpiarCliente.TabIndex = 7;
            btnLimpiarCliente.Text = "Limpiar";
            btnLimpiarCliente.UseVisualStyleBackColor = true;
            btnLimpiarCliente.Click += btnLimpiarCliente_Click;
            // 
            // txtTelefonoCliente
            // 
            txtTelefonoCliente.Location = new Point(156, 120);
            txtTelefonoCliente.MaxLength = 11;
            txtTelefonoCliente.Name = "txtTelefonoCliente";
            txtTelefonoCliente.ReadOnly = true;
            txtTelefonoCliente.Size = new Size(171, 23);
            txtTelefonoCliente.TabIndex = 4;
            txtTelefonoCliente.Leave += txtTelefonoCliente_Leave;
            // 
            // txtDireccionCliente
            // 
            txtDireccionCliente.Location = new Point(156, 90);
            txtDireccionCliente.Name = "txtDireccionCliente";
            txtDireccionCliente.ReadOnly = true;
            txtDireccionCliente.Size = new Size(171, 23);
            txtDireccionCliente.TabIndex = 3;
            txtDireccionCliente.Leave += txtDireccionCliente_Leave;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(20, 123);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(52, 15);
            lblTelefono.TabIndex = 5;
            lblTelefono.Text = "Teléfono";
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(20, 93);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(57, 15);
            lblDireccion.TabIndex = 5;
            lblDireccion.Text = "Dirección";
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Location = new Point(156, 60);
            txtNombreCliente.MaxLength = 255;
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.ReadOnly = true;
            txtNombreCliente.Size = new Size(171, 23);
            txtNombreCliente.TabIndex = 2;
            txtNombreCliente.Leave += txtNombreCliente_Leave;
            // 
            // lblNombreCliente
            // 
            lblNombreCliente.AutoSize = true;
            lblNombreCliente.Location = new Point(20, 63);
            lblNombreCliente.Name = "lblNombreCliente";
            lblNombreCliente.Size = new Size(130, 15);
            lblNombreCliente.TabIndex = 3;
            lblNombreCliente.Text = "Nombre o Razón Social";
            // 
            // txtNumDoc
            // 
            txtNumDoc.Location = new Point(209, 31);
            txtNumDoc.MaxLength = 9;
            txtNumDoc.Name = "txtNumDoc";
            txtNumDoc.Size = new Size(118, 23);
            txtNumDoc.TabIndex = 1;
            txtNumDoc.Leave += txtNumDoc_Leave;
            // 
            // cmbTipoDoc
            // 
            cmbTipoDoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoDoc.FormattingEnabled = true;
            cmbTipoDoc.Items.AddRange(new object[] { "J", "G", "V" });
            cmbTipoDoc.Location = new Point(156, 31);
            cmbTipoDoc.Name = "cmbTipoDoc";
            cmbTipoDoc.Size = new Size(47, 23);
            cmbTipoDoc.TabIndex = 0;
            cmbTipoDoc.SelectedIndexChanged += cmbTipoDoc_SelectedIndexChanged;
            // 
            // lblTipoDoc
            // 
            lblTipoDoc.AutoSize = true;
            lblTipoDoc.Location = new Point(20, 34);
            lblTipoDoc.Name = "lblTipoDoc";
            lblTipoDoc.Size = new Size(71, 15);
            lblTipoDoc.TabIndex = 0;
            lblTipoDoc.Text = "RIF / Cedula";
            // 
            // lblNumFactura
            // 
            lblNumFactura.AutoSize = true;
            lblNumFactura.Location = new Point(432, 95);
            lblNumFactura.Name = "lblNumFactura";
            lblNumFactura.Size = new Size(63, 15);
            lblNumFactura.TabIndex = 14;
            lblNumFactura.Text = "N° Factura";
            // 
            // txtNumFactura
            // 
            txtNumFactura.Location = new Point(501, 92);
            txtNumFactura.Name = "txtNumFactura";
            txtNumFactura.Size = new Size(116, 23);
            txtNumFactura.TabIndex = 5;
            txtNumFactura.Leave += txtNumFactura_Leave;
            // 
            // lblNumcontrol
            // 
            lblNumcontrol.AutoSize = true;
            lblNumcontrol.Location = new Point(432, 124);
            lblNumcontrol.Name = "lblNumcontrol";
            lblNumcontrol.Size = new Size(64, 15);
            lblNumcontrol.TabIndex = 14;
            lblNumcontrol.Text = "N° Control";
            // 
            // txtNumControl
            // 
            txtNumControl.Location = new Point(501, 121);
            txtNumControl.Name = "txtNumControl";
            txtNumControl.Size = new Size(116, 23);
            txtNumControl.TabIndex = 6;
            // 
            // lblImpuestos
            // 
            lblImpuestos.AutoSize = true;
            lblImpuestos.Location = new Point(235, 607);
            lblImpuestos.Name = "lblImpuestos";
            lblImpuestos.Size = new Size(24, 15);
            lblImpuestos.TabIndex = 11;
            lblImpuestos.Text = "IVA";
            // 
            // txtImpuestos
            // 
            txtImpuestos.Location = new Point(299, 604);
            txtImpuestos.Name = "txtImpuestos";
            txtImpuestos.ReadOnly = true;
            txtImpuestos.Size = new Size(100, 23);
            txtImpuestos.TabIndex = 0;
            txtImpuestos.TabStop = false;
            txtImpuestos.Text = "0.00";
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Location = new Point(235, 578);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(58, 15);
            lblSubtotal.TabIndex = 11;
            lblSubtotal.Text = "Sub  Total";
            // 
            // txtSubTotal
            // 
            txtSubTotal.Location = new Point(299, 575);
            txtSubTotal.Name = "txtSubTotal";
            txtSubTotal.ReadOnly = true;
            txtSubTotal.Size = new Size(100, 23);
            txtSubTotal.TabIndex = 0;
            txtSubTotal.TabStop = false;
            txtSubTotal.Text = "0.00";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(237, 10);
            label8.Name = "label8";
            label8.Size = new Size(162, 25);
            label8.TabIndex = 16;
            label8.Text = "Registrar Factura";
            // 
            // Ventas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 251, 252);
            ClientSize = new Size(634, 730);
            Controls.Add(label8);
            Controls.Add(txtNumControl);
            Controls.Add(lblNumcontrol);
            Controls.Add(txtNumFactura);
            Controls.Add(lblNumFactura);
            Controls.Add(gbCliente);
            Controls.Add(txtSubTotal);
            Controls.Add(lblSubtotal);
            Controls.Add(txtImpuestos);
            Controls.Add(lblImpuestos);
            Controls.Add(txtTotal);
            Controls.Add(lblTotal);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(dtpFecha);
            Controls.Add(txtPrecioVentaUnitario);
            Controls.Add(nudCantidad);
            Controls.Add(cmbProductoAgregar);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvDetalles);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Ventas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ventas";
            Load += Ventas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            gbCliente.ResumeLayout(false);
            gbCliente.PerformLayout();
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
        private Label label5;
        private DateTimePicker dtpFecha;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label lblTotal;
        private TextBox txtTotal;
        private GroupBox gbCliente;
        private TextBox txtNumDoc;
        private ComboBox cmbTipoDoc;
        private Label lblTipoDoc;
        private TextBox txtNombreCliente;
        private Label lblNombreCliente;
        private TextBox txtTelefonoCliente;
        private TextBox txtDireccionCliente;
        private Label lblTelefono;
        private Label lblDireccion;
        private Button btnLimpiarCliente;
        private Label lblNumFactura;
        private TextBox txtNumFactura;
        private Label lblNumcontrol;
        private TextBox txtNumControl;
        private Label lblImpuestos;
        private TextBox txtImpuestos;
        private Label lblSubtotal;
        private TextBox txtSubTotal;
        private Label label8;
    }
}