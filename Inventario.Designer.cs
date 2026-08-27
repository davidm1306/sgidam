namespace sgidam
{
    partial class Inventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventario));
            label1 = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvInventario = new DataGridView();
            gbFiltros = new GroupBox();
            lblRango = new Label();
            nudStockMax = new NumericUpDown();
            btnLimpiarFiltros = new Button();
            nudStockMin = new NumericUpDown();
            cmbMarca = new ComboBox();
            chkFiltrarStock = new CheckBox();
            chkFiltrarMarca = new CheckBox();
            cmbEstado = new ComboBox();
            chkFiltrarEstado = new CheckBox();
            cmbCategoria = new ComboBox();
            chkFiltrarCategoria = new CheckBox();
            lblResultados = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
            gbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudStockMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStockMin).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(71, 45);
            label1.Name = "label1";
            label1.Size = new Size(320, 19);
            label1.TabIndex = 0;
            label1.Text = "Introduzca nombre del producto o codigo de barra";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(393, 44);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(129, 23);
            txtBuscar.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(561, 37);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 35);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // dgvInventario
            // 
            dgvInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventario.Location = new Point(39, 228);
            dgvInventario.Name = "dgvInventario";
            dgvInventario.Size = new Size(943, 389);
            dgvInventario.TabIndex = 3;
            // 
            // gbFiltros
            // 
            gbFiltros.Controls.Add(lblRango);
            gbFiltros.Controls.Add(nudStockMax);
            gbFiltros.Controls.Add(btnLimpiarFiltros);
            gbFiltros.Controls.Add(nudStockMin);
            gbFiltros.Controls.Add(cmbMarca);
            gbFiltros.Controls.Add(chkFiltrarStock);
            gbFiltros.Controls.Add(chkFiltrarMarca);
            gbFiltros.Controls.Add(cmbEstado);
            gbFiltros.Controls.Add(chkFiltrarEstado);
            gbFiltros.Controls.Add(cmbCategoria);
            gbFiltros.Controls.Add(chkFiltrarCategoria);
            gbFiltros.Location = new Point(71, 78);
            gbFiltros.Name = "gbFiltros";
            gbFiltros.Size = new Size(671, 113);
            gbFiltros.TabIndex = 4;
            gbFiltros.TabStop = false;
            gbFiltros.Text = "Filtros";
            // 
            // lblRango
            // 
            lblRango.AutoSize = true;
            lblRango.Location = new Point(406, 72);
            lblRango.Name = "lblRango";
            lblRango.Size = new Size(13, 15);
            lblRango.TabIndex = 4;
            lblRango.Text = "a";
            // 
            // nudStockMax
            // 
            nudStockMax.Location = new Point(429, 69);
            nudStockMax.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudStockMax.Name = "nudStockMax";
            nudStockMax.Size = new Size(54, 23);
            nudStockMax.TabIndex = 3;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.Location = new Point(547, 38);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(96, 49);
            btnLimpiarFiltros.TabIndex = 2;
            btnLimpiarFiltros.Text = "Limpiar Filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = true;
            // 
            // nudStockMin
            // 
            nudStockMin.Location = new Point(346, 69);
            nudStockMin.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudStockMin.Name = "nudStockMin";
            nudStockMin.Size = new Size(52, 23);
            nudStockMin.TabIndex = 2;
            // 
            // cmbMarca
            // 
            cmbMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMarca.FormattingEnabled = true;
            cmbMarca.Location = new Point(101, 69);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(121, 23);
            cmbMarca.TabIndex = 1;
            // 
            // chkFiltrarStock
            // 
            chkFiltrarStock.AutoSize = true;
            chkFiltrarStock.Location = new Point(262, 71);
            chkFiltrarStock.Name = "chkFiltrarStock";
            chkFiltrarStock.Size = new Size(78, 19);
            chkFiltrarStock.TabIndex = 0;
            chkFiltrarStock.Text = "Existencia";
            chkFiltrarStock.UseVisualStyleBackColor = true;
            // 
            // chkFiltrarMarca
            // 
            chkFiltrarMarca.AutoSize = true;
            chkFiltrarMarca.Location = new Point(13, 71);
            chkFiltrarMarca.Name = "chkFiltrarMarca";
            chkFiltrarMarca.Size = new Size(59, 19);
            chkFiltrarMarca.TabIndex = 0;
            chkFiltrarMarca.Text = "Marca";
            chkFiltrarMarca.UseVisualStyleBackColor = true;
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(350, 23);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(133, 23);
            cmbEstado.TabIndex = 1;
            // 
            // chkFiltrarEstado
            // 
            chkFiltrarEstado.AutoSize = true;
            chkFiltrarEstado.Location = new Point(262, 25);
            chkFiltrarEstado.Name = "chkFiltrarEstado";
            chkFiltrarEstado.Size = new Size(61, 19);
            chkFiltrarEstado.TabIndex = 0;
            chkFiltrarEstado.Text = "Estado";
            chkFiltrarEstado.UseVisualStyleBackColor = true;
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(101, 23);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(121, 23);
            cmbCategoria.TabIndex = 1;
            // 
            // chkFiltrarCategoria
            // 
            chkFiltrarCategoria.AutoSize = true;
            chkFiltrarCategoria.Location = new Point(13, 25);
            chkFiltrarCategoria.Name = "chkFiltrarCategoria";
            chkFiltrarCategoria.Size = new Size(77, 19);
            chkFiltrarCategoria.TabIndex = 0;
            chkFiltrarCategoria.Text = "Categoría";
            chkFiltrarCategoria.UseVisualStyleBackColor = true;
            // 
            // lblResultados
            // 
            lblResultados.AutoSize = true;
            lblResultados.Location = new Point(80, 201);
            lblResultados.Name = "lblResultados";
            lblResultados.Size = new Size(141, 15);
            lblResultados.TabIndex = 5;
            lblResultados.Text = "Resultados: 0 producto(s)";
            // 
            // Inventario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 251, 252);
            ClientSize = new Size(1018, 644);
            Controls.Add(lblResultados);
            Controls.Add(gbFiltros);
            Controls.Add(dgvInventario);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Inventario";
            Text = "Inventario";
            Load += Inventario_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            gbFiltros.ResumeLayout(false);
            gbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudStockMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStockMin).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvInventario;
        private GroupBox gbFiltros;
        private ComboBox cmbCategoria;
        private CheckBox chkFiltrarCategoria;
        private Label lblRango;
        private NumericUpDown nudStockMax;
        private NumericUpDown nudStockMin;
        private ComboBox cmbMarca;
        private CheckBox chkFiltrarStock;
        private CheckBox chkFiltrarMarca;
        private ComboBox cmbEstado;
        private CheckBox chkFiltrarEstado;
        private Button btnLimpiarFiltros;
        private Label lblResultados;
    }
}