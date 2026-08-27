namespace sgidam
{
    partial class DetalleFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetalleFactura));
            txtNumControl = new TextBox();
            lblNumcontrol = new Label();
            txtNumFactura = new TextBox();
            lblNumFactura = new Label();
            gbCliente = new GroupBox();
            txtTelefonoCliente = new TextBox();
            txtDireccionCliente = new TextBox();
            lblTelefono = new Label();
            lblDireccion = new Label();
            txtNombreCliente = new TextBox();
            lblNombreCliente = new Label();
            txtNumDoc = new TextBox();
            cmbTipoDoc = new ComboBox();
            lblTipoDoc = new Label();
            txtSubTotal = new TextBox();
            lblSubtotal = new Label();
            txtImpuestos = new TextBox();
            lblImpuestos = new Label();
            txtTotal = new TextBox();
            lblTotal = new Label();
            btnCancelar = new Button();
            btnGuardar = new Button();
            dgvDetalles = new DataGridView();
            label5 = new Label();
            txtFecha = new TextBox();
            label1 = new Label();
            cmbEstatus = new ComboBox();
            gbCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();
            // 
            // txtNumControl
            // 
            txtNumControl.Location = new Point(515, 86);
            txtNumControl.Name = "txtNumControl";
            txtNumControl.ReadOnly = true;
            txtNumControl.Size = new Size(116, 23);
            txtNumControl.TabIndex = 26;
            // 
            // lblNumcontrol
            // 
            lblNumcontrol.AutoSize = true;
            lblNumcontrol.Location = new Point(446, 89);
            lblNumcontrol.Name = "lblNumcontrol";
            lblNumcontrol.Size = new Size(64, 15);
            lblNumcontrol.TabIndex = 40;
            lblNumcontrol.Text = "N° Control";
            // 
            // txtNumFactura
            // 
            txtNumFactura.Location = new Point(515, 57);
            txtNumFactura.Name = "txtNumFactura";
            txtNumFactura.ReadOnly = true;
            txtNumFactura.Size = new Size(116, 23);
            txtNumFactura.TabIndex = 25;
            // 
            // lblNumFactura
            // 
            lblNumFactura.AutoSize = true;
            lblNumFactura.Location = new Point(446, 60);
            lblNumFactura.Name = "lblNumFactura";
            lblNumFactura.Size = new Size(63, 15);
            lblNumFactura.TabIndex = 39;
            lblNumFactura.Text = "N° Factura";
            // 
            // gbCliente
            // 
            gbCliente.Controls.Add(txtTelefonoCliente);
            gbCliente.Controls.Add(txtDireccionCliente);
            gbCliente.Controls.Add(lblTelefono);
            gbCliente.Controls.Add(lblDireccion);
            gbCliente.Controls.Add(txtNombreCliente);
            gbCliente.Controls.Add(lblNombreCliente);
            gbCliente.Controls.Add(txtNumDoc);
            gbCliente.Controls.Add(cmbTipoDoc);
            gbCliente.Controls.Add(lblTipoDoc);
            gbCliente.Location = new Point(47, 26);
            gbCliente.Name = "gbCliente";
            gbCliente.Size = new Size(371, 156);
            gbCliente.TabIndex = 38;
            gbCliente.TabStop = false;
            gbCliente.Text = "Datos del Cliente";
            // 
            // txtTelefonoCliente
            // 
            txtTelefonoCliente.Location = new Point(156, 120);
            txtTelefonoCliente.MaxLength = 11;
            txtTelefonoCliente.Name = "txtTelefonoCliente";
            txtTelefonoCliente.ReadOnly = true;
            txtTelefonoCliente.Size = new Size(171, 23);
            txtTelefonoCliente.TabIndex = 4;
            // 
            // txtDireccionCliente
            // 
            txtDireccionCliente.Location = new Point(156, 90);
            txtDireccionCliente.Name = "txtDireccionCliente";
            txtDireccionCliente.ReadOnly = true;
            txtDireccionCliente.Size = new Size(171, 23);
            txtDireccionCliente.TabIndex = 3;
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
            txtNumDoc.ReadOnly = true;
            txtNumDoc.Size = new Size(118, 23);
            txtNumDoc.TabIndex = 1;
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
            // txtSubTotal
            // 
            txtSubTotal.Location = new Point(318, 388);
            txtSubTotal.Name = "txtSubTotal";
            txtSubTotal.ReadOnly = true;
            txtSubTotal.Size = new Size(100, 23);
            txtSubTotal.TabIndex = 20;
            txtSubTotal.TabStop = false;
            txtSubTotal.Text = "0.00";
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Location = new Point(254, 391);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(58, 15);
            lblSubtotal.TabIndex = 34;
            lblSubtotal.Text = "Sub  Total";
            // 
            // txtImpuestos
            // 
            txtImpuestos.Location = new Point(318, 417);
            txtImpuestos.Name = "txtImpuestos";
            txtImpuestos.ReadOnly = true;
            txtImpuestos.Size = new Size(100, 23);
            txtImpuestos.TabIndex = 21;
            txtImpuestos.TabStop = false;
            txtImpuestos.Text = "0.00";
            // 
            // lblImpuestos
            // 
            lblImpuestos.AutoSize = true;
            lblImpuestos.Location = new Point(254, 420);
            lblImpuestos.Name = "lblImpuestos";
            lblImpuestos.Size = new Size(24, 15);
            lblImpuestos.TabIndex = 33;
            lblImpuestos.Text = "IVA";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(318, 446);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(100, 23);
            txtTotal.TabIndex = 22;
            txtTotal.TabStop = false;
            txtTotal.Text = "0.00";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(254, 446);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(32, 15);
            lblTotal.TabIndex = 36;
            lblTotal.Text = "Total";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(330, 496);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(81, 35);
            btnCancelar.TabIndex = 32;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(199, 496);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(91, 35);
            btnGuardar.TabIndex = 30;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // dgvDetalles
            // 
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(120, 214);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.Size = new Size(444, 150);
            dgvDetalles.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(446, 125);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 19;
            label5.Text = "Fecha";
            // 
            // txtFecha
            // 
            txtFecha.Location = new Point(515, 119);
            txtFecha.Name = "txtFecha";
            txtFecha.ReadOnly = true;
            txtFecha.Size = new Size(116, 23);
            txtFecha.TabIndex = 26;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(446, 152);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 41;
            label1.Text = "Estatus";
            // 
            // cmbEstatus
            // 
            cmbEstatus.FormattingEnabled = true;
            cmbEstatus.Location = new Point(515, 149);
            cmbEstatus.Name = "cmbEstatus";
            cmbEstatus.Size = new Size(116, 23);
            cmbEstatus.TabIndex = 42;
            // 
            // DetalleFactura
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 251, 252);
            ClientSize = new Size(655, 568);
            Controls.Add(cmbEstatus);
            Controls.Add(label1);
            Controls.Add(txtFecha);
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
            Controls.Add(dgvDetalles);
            Controls.Add(label5);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DetalleFactura";
            Text = "DetalleFactura";
            Load += DetalleFactura_Load;
            gbCliente.ResumeLayout(false);
            gbCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNumControl;
        private Label lblNumcontrol;
        private TextBox txtNumFactura;
        private Label lblNumFactura;
        private GroupBox gbCliente;
        private TextBox txtTelefonoCliente;
        private TextBox txtDireccionCliente;
        private Label lblTelefono;
        private Label lblDireccion;
        private TextBox txtNombreCliente;
        private Label lblNombreCliente;
        private TextBox txtNumDoc;
        private ComboBox cmbTipoDoc;
        private Label lblTipoDoc;
        private TextBox txtSubTotal;
        private Label lblSubtotal;
        private TextBox txtImpuestos;
        private Label lblImpuestos;
        private TextBox txtTotal;
        private Label lblTotal;
        private Button btnCancelar;
        private Button btnGuardar;
        private DataGridView dgvDetalles;
        private Label label5;
        private TextBox txtFecha;
        private Label label1;
        private ComboBox cmbEstatus;
    }
}