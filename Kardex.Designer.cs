namespace sgidam
{
    partial class Kardex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kardex));
            cmbProducto = new ComboBox();
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            btnConsultar = new Button();
            dgvKardex = new DataGridView();
            txtStockActual = new TextBox();
            txtCostoPromedio = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvKardex).BeginInit();
            SuspendLayout();
            // 
            // cmbProducto
            // 
            cmbProducto.FormattingEnabled = true;
            cmbProducto.Location = new Point(125, 12);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(121, 23);
            cmbProducto.TabIndex = 0;
            // 
            // dtpDesde
            // 
            dtpDesde.CustomFormat = "yyyy-MM-dd";
            dtpDesde.Location = new Point(125, 45);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(212, 23);
            dtpDesde.TabIndex = 1;
            // 
            // dtpHasta
            // 
            dtpHasta.CustomFormat = "yyyy-MM-dd";
            dtpHasta.Location = new Point(411, 41);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(218, 23);
            dtpHasta.TabIndex = 2;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(309, 84);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(75, 32);
            btnConsultar.TabIndex = 3;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // dgvKardex
            // 
            dgvKardex.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKardex.Location = new Point(51, 136);
            dgvKardex.Name = "dgvKardex";
            dgvKardex.Size = new Size(767, 150);
            dgvKardex.TabIndex = 4;
            // 
            // txtStockActual
            // 
            txtStockActual.Location = new Point(233, 334);
            txtStockActual.Name = "txtStockActual";
            txtStockActual.ReadOnly = true;
            txtStockActual.Size = new Size(100, 23);
            txtStockActual.TabIndex = 5;
            // 
            // txtCostoPromedio
            // 
            txtCostoPromedio.Location = new Point(469, 334);
            txtCostoPromedio.Name = "txtCostoPromedio";
            txtCostoPromedio.ReadOnly = true;
            txtCostoPromedio.Size = new Size(100, 23);
            txtCostoPromedio.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(63, 15);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 7;
            label1.Text = "Producto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(80, 51);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 8;
            label2.Text = "Desde";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(368, 47);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 9;
            label3.Text = "Hasta";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(154, 337);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 10;
            label4.Text = "Stock Actual";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(370, 337);
            label5.Name = "label5";
            label5.Size = new Size(93, 15);
            label5.TabIndex = 11;
            label5.Text = "Costo Promedio";
            // 
            // Kardex
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 251, 252);
            ClientSize = new Size(844, 389);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtCostoPromedio);
            Controls.Add(txtStockActual);
            Controls.Add(dgvKardex);
            Controls.Add(btnConsultar);
            Controls.Add(dtpHasta);
            Controls.Add(dtpDesde);
            Controls.Add(cmbProducto);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Kardex";
            Text = "Kardex";
            Load += Kardex_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKardex).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbProducto;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Button btnConsultar;
        private DataGridView dgvKardex;
        private TextBox txtStockActual;
        private TextBox txtCostoPromedio;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}