namespace sgidam
{
    partial class Devoluciones
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Devoluciones));
            label1 = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvDetalles = new DataGridView();
            btnProcesar = new Button();
            btnCancelar = new Button();
            label2 = new Label();
            lblFacturaInfo = new Label();
            txtMotivo = new TextBox();
            lblMotivo = new Label();
            btnLimpiarFiltros = new Button();
            gbFiltros = new GroupBox();
            label3 = new Label();
            dtpHasta = new DateTimePicker();
            dtpDesde = new DateTimePicker();
            cmbUsuario = new ComboBox();
            chkUsuario = new CheckBox();
            chkFechas = new CheckBox();
            txtNumControl = new TextBox();
            chkNumControl = new CheckBox();
            dgvFacturas = new DataGridView();
            lblListFactura = new Label();
            lblFacturaSeleccionada = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            gbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(114, 15);
            label1.TabIndex = 0;
            label1.Text = "N° Factura / Cliente:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(132, 17);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(200, 23);
            txtBuscar.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(338, 10);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 35);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dgvDetalles
            // 
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(12, 445);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.Size = new Size(641, 176);
            dgvDetalles.TabIndex = 3;
            // 
            // btnProcesar
            // 
            btnProcesar.Location = new Point(237, 716);
            btnProcesar.Name = "btnProcesar";
            btnProcesar.Size = new Size(136, 35);
            btnProcesar.TabIndex = 4;
            btnProcesar.Text = "Procesar Devolución";
            btnProcesar.UseVisualStyleBackColor = true;
            btnProcesar.Click += btnProcesar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(393, 716);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 35);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 427);
            label2.Name = "label2";
            label2.Size = new Size(107, 15);
            label2.TabIndex = 6;
            label2.Text = "Detalles de factura:";
            // 
            // lblFacturaInfo
            // 
            lblFacturaInfo.AutoSize = true;
            lblFacturaInfo.Location = new Point(16, 636);
            lblFacturaInfo.Name = "lblFacturaInfo";
            lblFacturaInfo.Size = new Size(17, 15);
            lblFacturaInfo.TabIndex = 7;
            lblFacturaInfo.Text = "--";
            // 
            // txtMotivo
            // 
            txtMotivo.Location = new Point(141, 667);
            txtMotivo.Name = "txtMotivo";
            txtMotivo.Size = new Size(174, 23);
            txtMotivo.TabIndex = 8;
            // 
            // lblMotivo
            // 
            lblMotivo.AutoSize = true;
            lblMotivo.Location = new Point(12, 670);
            lblMotivo.Name = "lblMotivo";
            lblMotivo.Size = new Size(123, 15);
            lblMotivo.TabIndex = 9;
            lblMotivo.Text = "Motivo de devolución";
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.Location = new Point(434, 10);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(75, 35);
            btnLimpiarFiltros.TabIndex = 2;
            btnLimpiarFiltros.Text = "Limpiar";
            btnLimpiarFiltros.UseVisualStyleBackColor = true;
            btnLimpiarFiltros.Click += btnBuscar_Click;
            // 
            // gbFiltros
            // 
            gbFiltros.Controls.Add(label3);
            gbFiltros.Controls.Add(dtpHasta);
            gbFiltros.Controls.Add(dtpDesde);
            gbFiltros.Controls.Add(cmbUsuario);
            gbFiltros.Controls.Add(chkUsuario);
            gbFiltros.Controls.Add(chkFechas);
            gbFiltros.Controls.Add(txtNumControl);
            gbFiltros.Controls.Add(chkNumControl);
            gbFiltros.Location = new Point(16, 52);
            gbFiltros.Name = "gbFiltros";
            gbFiltros.Size = new Size(357, 114);
            gbFiltros.TabIndex = 10;
            gbFiltros.TabStop = false;
            gbFiltros.Text = "Filtros";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(200, 58);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 5;
            label3.Text = "Hasta";
            // 
            // dtpHasta
            // 
            dtpHasta.Location = new Point(243, 52);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(73, 23);
            dtpHasta.TabIndex = 4;
            // 
            // dtpDesde
            // 
            dtpDesde.Location = new Point(116, 52);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(78, 23);
            dtpDesde.TabIndex = 3;
            // 
            // cmbUsuario
            // 
            cmbUsuario.FormattingEnabled = true;
            cmbUsuario.Location = new Point(116, 81);
            cmbUsuario.Name = "cmbUsuario";
            cmbUsuario.Size = new Size(200, 23);
            cmbUsuario.TabIndex = 2;
            // 
            // chkUsuario
            // 
            chkUsuario.AutoSize = true;
            chkUsuario.Location = new Point(13, 83);
            chkUsuario.Name = "chkUsuario";
            chkUsuario.Size = new Size(66, 19);
            chkUsuario.TabIndex = 0;
            chkUsuario.Text = "Usuario";
            chkUsuario.UseVisualStyleBackColor = true;
            // 
            // chkFechas
            // 
            chkFechas.AutoSize = true;
            chkFechas.Location = new Point(13, 54);
            chkFechas.Name = "chkFechas";
            chkFechas.Size = new Size(100, 19);
            chkFechas.TabIndex = 0;
            chkFechas.Text = "Fechas Desde:";
            chkFechas.UseVisualStyleBackColor = true;
            // 
            // txtNumControl
            // 
            txtNumControl.Location = new Point(116, 21);
            txtNumControl.Name = "txtNumControl";
            txtNumControl.Size = new Size(200, 23);
            txtNumControl.TabIndex = 1;
            // 
            // chkNumControl
            // 
            chkNumControl.AutoSize = true;
            chkNumControl.Location = new Point(13, 25);
            chkNumControl.Name = "chkNumControl";
            chkNumControl.Size = new Size(94, 19);
            chkNumControl.TabIndex = 0;
            chkNumControl.Text = "N de Control";
            chkNumControl.UseVisualStyleBackColor = true;
            // 
            // dgvFacturas
            // 
            dgvFacturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturas.Location = new Point(12, 216);
            dgvFacturas.Name = "dgvFacturas";
            dgvFacturas.Size = new Size(784, 150);
            dgvFacturas.TabIndex = 11;
            // 
            // lblListFactura
            // 
            lblListFactura.AutoSize = true;
            lblListFactura.Location = new Point(16, 187);
            lblListFactura.Name = "lblListFactura";
            lblListFactura.Size = new Size(95, 15);
            lblListFactura.TabIndex = 12;
            lblListFactura.Text = "Lista De Facturas";
            // 
            // lblFacturaSeleccionada
            // 
            lblFacturaSeleccionada.AutoSize = true;
            lblFacturaSeleccionada.Location = new Point(16, 390);
            lblFacturaSeleccionada.Name = "lblFacturaSeleccionada";
            lblFacturaSeleccionada.Size = new Size(17, 15);
            lblFacturaSeleccionada.TabIndex = 13;
            lblFacturaSeleccionada.Text = "**";
            // 
            // Devoluciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 251, 252);
            ClientSize = new Size(808, 777);
            Controls.Add(lblFacturaSeleccionada);
            Controls.Add(lblListFactura);
            Controls.Add(dgvFacturas);
            Controls.Add(gbFiltros);
            Controls.Add(lblMotivo);
            Controls.Add(txtMotivo);
            Controls.Add(lblFacturaInfo);
            Controls.Add(label2);
            Controls.Add(btnCancelar);
            Controls.Add(btnProcesar);
            Controls.Add(dgvDetalles);
            Controls.Add(btnLimpiarFiltros);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Devoluciones";
            Text = "Devoluciones";
            Load += Devoluciones_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            gbFiltros.ResumeLayout(false);
            gbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFacturaInfo;
        private TextBox txtMotivo;
        private Label lblMotivo;
        private Button btnLimpiarFiltros;
        private GroupBox gbFiltros;
        private CheckBox chkUsuario;
        private CheckBox chkFechas;
        private TextBox txtNumControl;
        private CheckBox chkNumControl;
        private Label label3;
        private DateTimePicker dtpHasta;
        private DateTimePicker dtpDesde;
        private ComboBox cmbUsuario;
        private DataGridView dgvFacturas;
        private Label lblListFactura;
        private Label lblFacturaSeleccionada;
    }
}