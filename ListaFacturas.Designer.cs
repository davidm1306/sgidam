namespace sgidam
{
    partial class ListaFacturas
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaFacturas));
            dgvFacturas = new DataGridView();
            cmbEstatus = new ComboBox();
            label3 = new Label();
            txtNumFactura = new TextBox();
            label4 = new Label();
            txtNumControl = new TextBox();
            lblDesde = new Label();
            dtpDesde = new DateTimePicker();
            lblHasta = new Label();
            dtpHasta = new DateTimePicker();
            btnBuscar = new Button();
            btnLimpiar = new Button();
            cmbCliente = new ComboBox();
            chkEstatus = new CheckBox();
            chkCliente = new CheckBox();
            chkFecha = new CheckBox();
            lblFiltros = new Label();
            lblBuscarFac = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).BeginInit();
            SuspendLayout();
            // 
            // dgvFacturas
            // 
            dgvFacturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturas.Location = new Point(12, 218);
            dgvFacturas.Name = "dgvFacturas";
            dgvFacturas.Size = new Size(1083, 400);
            dgvFacturas.TabIndex = 0;
            dgvFacturas.CellDoubleClick += dgvFacturas_CellDoubleClick;
            // 
            // cmbEstatus
            // 
            cmbEstatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstatus.Location = new Point(113, 108);
            cmbEstatus.Name = "cmbEstatus";
            cmbEstatus.Size = new Size(145, 23);
            cmbEstatus.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(176, 28);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 5;
            label3.Text = "N° Factura:";
            // 
            // txtNumFactura
            // 
            txtNumFactura.Location = new Point(260, 25);
            txtNumFactura.Name = "txtNumFactura";
            txtNumFactura.Size = new Size(100, 23);
            txtNumFactura.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(376, 28);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 7;
            label4.Text = "N° Control:";
            // 
            // txtNumControl
            // 
            txtNumControl.Location = new Point(462, 25);
            txtNumControl.Name = "txtNumControl";
            txtNumControl.Size = new Size(100, 23);
            txtNumControl.TabIndex = 8;
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(110, 158);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(42, 15);
            lblDesde.TabIndex = 9;
            lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(158, 154);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(100, 23);
            dtpDesde.TabIndex = 10;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(312, 156);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(40, 15);
            lblHasta.TabIndex = 11;
            lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(358, 152);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(180, 23);
            dtpHasta.TabIndex = 12;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(604, 20);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 30);
            btnBuscar.TabIndex = 13;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(604, 125);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 30);
            btnLimpiar.TabIndex = 14;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // cmbCliente
            // 
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.Location = new Point(358, 108);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(180, 23);
            cmbCliente.TabIndex = 4;
            // 
            // chkEstatus
            // 
            chkEstatus.AutoSize = true;
            chkEstatus.Location = new Point(44, 110);
            chkEstatus.Name = "chkEstatus";
            chkEstatus.Size = new Size(63, 19);
            chkEstatus.TabIndex = 15;
            chkEstatus.Text = "Estatus";
            chkEstatus.UseVisualStyleBackColor = true;
            // 
            // chkCliente
            // 
            chkCliente.AutoSize = true;
            chkCliente.Location = new Point(274, 112);
            chkCliente.Name = "chkCliente";
            chkCliente.Size = new Size(63, 19);
            chkCliente.TabIndex = 16;
            chkCliente.Text = "Cliente";
            chkCliente.UseVisualStyleBackColor = true;
            // 
            // chkFecha
            // 
            chkFecha.AutoSize = true;
            chkFecha.Location = new Point(44, 157);
            chkFecha.Name = "chkFecha";
            chkFecha.Size = new Size(57, 19);
            chkFecha.TabIndex = 17;
            chkFecha.Text = "Fecha";
            chkFecha.UseVisualStyleBackColor = true;
            // 
            // lblFiltros
            // 
            lblFiltros.AutoSize = true;
            lblFiltros.Location = new Point(44, 75);
            lblFiltros.Name = "lblFiltros";
            lblFiltros.Size = new Size(39, 15);
            lblFiltros.TabIndex = 18;
            lblFiltros.Text = "Filtros";
            // 
            // lblBuscarFac
            // 
            lblBuscarFac.AutoSize = true;
            lblBuscarFac.Font = new Font("Segoe UI", 10F);
            lblBuscarFac.Location = new Point(44, 25);
            lblBuscarFac.Name = "lblBuscarFac";
            lblBuscarFac.Size = new Size(123, 19);
            lblBuscarFac.TabIndex = 19;
            lblBuscarFac.Text = "Buscar factura por:";
            // 
            // ListaFacturas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 251, 252);
            ClientSize = new Size(1122, 630);
            Controls.Add(lblBuscarFac);
            Controls.Add(lblFiltros);
            Controls.Add(chkFecha);
            Controls.Add(chkCliente);
            Controls.Add(chkEstatus);
            Controls.Add(btnLimpiar);
            Controls.Add(btnBuscar);
            Controls.Add(dtpHasta);
            Controls.Add(lblHasta);
            Controls.Add(dtpDesde);
            Controls.Add(lblDesde);
            Controls.Add(txtNumControl);
            Controls.Add(label4);
            Controls.Add(txtNumFactura);
            Controls.Add(label3);
            Controls.Add(cmbCliente);
            Controls.Add(cmbEstatus);
            Controls.Add(dgvFacturas);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ListaFacturas";
            Text = "Lista de Facturas";
            Load += ListaFacturas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvFacturas;
        private System.Windows.Forms.ComboBox cmbEstatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumFactura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumControl;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private ComboBox cmbCliente;
        private CheckBox chkEstatus;
        private CheckBox chkCliente;
        private CheckBox chkFecha;
        private Label lblFiltros;
        private Label lblBuscarFac;
    }
}