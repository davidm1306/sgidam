namespace sgidam
{
    partial class RegistrarProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarProducto));
            lblCodigoBarras = new Label();
            lblNombreProducto = new Label();
            lblMarca = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label1 = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            txtCodigoBarras = new TextBox();
            txtNombreProducto = new TextBox();
            txtPrecioCompra = new TextBox();
            txtPrecioVenta = new TextBox();
            cmbMarca = new ComboBox();
            cmbCategoria = new ComboBox();
            nudStock = new NumericUpDown();
            nudStockMinimo = new NumericUpDown();
            pbImagen = new PictureBox();
            btnCargarImagen = new Button();
            nudPorcentajeUtilidad = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStockMinimo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbImagen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPorcentajeUtilidad).BeginInit();
            SuspendLayout();
            // 
            // lblCodigoBarras
            // 
            lblCodigoBarras.AutoSize = true;
            lblCodigoBarras.Location = new Point(79, 36);
            lblCodigoBarras.Name = "lblCodigoBarras";
            lblCodigoBarras.Size = new Size(97, 15);
            lblCodigoBarras.TabIndex = 0;
            lblCodigoBarras.Text = "Código de Barras";
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.AutoSize = true;
            lblNombreProducto.Location = new Point(54, 65);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(122, 15);
            lblNombreProducto.TabIndex = 0;
            lblNombreProducto.Text = "Nombre del producto";
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(132, 94);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(40, 15);
            lblMarca.TabIndex = 0;
            lblMarca.Text = "Marca";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(118, 123);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 0;
            label4.Text = "Categoría";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(74, 152);
            label5.Name = "label5";
            label5.Size = new Size(102, 15);
            label5.TabIndex = 0;
            label5.Text = "Precio de Compra";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(88, 210);
            label6.Name = "label6";
            label6.Size = new Size(88, 15);
            label6.TabIndex = 0;
            label6.Text = "Precio de Venta";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(106, 241);
            label7.Name = "label7";
            label7.Size = new Size(70, 15);
            label7.TabIndex = 0;
            label7.Text = "Stock Inicial";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(103, 270);
            label8.Name = "label8";
            label8.Size = new Size(81, 15);
            label8.TabIndex = 0;
            label8.Text = "Stock Minimo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(66, 348);
            label1.Name = "label1";
            label1.Size = new Size(118, 15);
            label1.TabIndex = 0;
            label1.Text = "Imagen del Producto";
            label1.Click += label9_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(108, 449);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(111, 36);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar producto";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(251, 449);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(89, 36);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtCodigoBarras
            // 
            txtCodigoBarras.Location = new Point(190, 33);
            txtCodigoBarras.MaxLength = 45;
            txtCodigoBarras.Name = "txtCodigoBarras";
            txtCodigoBarras.Size = new Size(121, 23);
            txtCodigoBarras.TabIndex = 1;
            // 
            // txtNombreProducto
            // 
            txtNombreProducto.Location = new Point(190, 62);
            txtNombreProducto.MaxLength = 45;
            txtNombreProducto.Name = "txtNombreProducto";
            txtNombreProducto.Size = new Size(121, 23);
            txtNombreProducto.TabIndex = 2;
            // 
            // txtPrecioCompra
            // 
            txtPrecioCompra.Location = new Point(190, 149);
            txtPrecioCompra.MaxLength = 13;
            txtPrecioCompra.Name = "txtPrecioCompra";
            txtPrecioCompra.Size = new Size(121, 23);
            txtPrecioCompra.TabIndex = 5;
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(190, 207);
            txtPrecioVenta.MaxLength = 13;
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(121, 23);
            txtPrecioVenta.TabIndex = 7;
            // 
            // cmbMarca
            // 
            cmbMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMarca.FormattingEnabled = true;
            cmbMarca.Location = new Point(190, 91);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(121, 23);
            cmbMarca.TabIndex = 3;
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(190, 120);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(121, 23);
            cmbCategoria.TabIndex = 4;
            // 
            // nudStock
            // 
            nudStock.Location = new Point(190, 239);
            nudStock.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(121, 23);
            nudStock.TabIndex = 8;
            // 
            // nudStockMinimo
            // 
            nudStockMinimo.Location = new Point(190, 268);
            nudStockMinimo.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            nudStockMinimo.Name = "nudStockMinimo";
            nudStockMinimo.Size = new Size(121, 23);
            nudStockMinimo.TabIndex = 9;
            // 
            // pbImagen
            // 
            pbImagen.BackgroundImageLayout = ImageLayout.Stretch;
            pbImagen.BorderStyle = BorderStyle.FixedSingle;
            pbImagen.Location = new Point(190, 310);
            pbImagen.Name = "pbImagen";
            pbImagen.Size = new Size(121, 112);
            pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            pbImagen.TabIndex = 10;
            pbImagen.TabStop = false;
            // 
            // btnCargarImagen
            // 
            btnCargarImagen.Location = new Point(339, 357);
            btnCargarImagen.Name = "btnCargarImagen";
            btnCargarImagen.Size = new Size(98, 32);
            btnCargarImagen.TabIndex = 11;
            btnCargarImagen.Text = "Cargar imagen";
            btnCargarImagen.UseVisualStyleBackColor = true;
            btnCargarImagen.Click += btnCargarImagen_Click_1;
            // 
            // nudPorcentajeUtilidad
            // 
            nudPorcentajeUtilidad.DecimalPlaces = 2;
            nudPorcentajeUtilidad.Location = new Point(190, 178);
            nudPorcentajeUtilidad.Name = "nudPorcentajeUtilidad";
            nudPorcentajeUtilidad.Size = new Size(51, 23);
            nudPorcentajeUtilidad.TabIndex = 6;
            nudPorcentajeUtilidad.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(62, 180);
            label2.Name = "label2";
            label2.Size = new Size(122, 15);
            label2.TabIndex = 14;
            label2.Text = "Porcentaje de utilidad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(247, 180);
            label3.Name = "label3";
            label3.Size = new Size(17, 15);
            label3.TabIndex = 15;
            label3.Text = "%";
            // 
            // RegistrarProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 251, 252);
            ClientSize = new Size(463, 513);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(nudPorcentajeUtilidad);
            Controls.Add(btnCargarImagen);
            Controls.Add(pbImagen);
            Controls.Add(nudStockMinimo);
            Controls.Add(nudStock);
            Controls.Add(cmbCategoria);
            Controls.Add(cmbMarca);
            Controls.Add(txtPrecioVenta);
            Controls.Add(txtPrecioCompra);
            Controls.Add(txtNombreProducto);
            Controls.Add(txtCodigoBarras);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(label1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(lblMarca);
            Controls.Add(lblNombreProducto);
            Controls.Add(lblCodigoBarras);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RegistrarProducto";
            Text = "RegistrarProducto";
            Load += RegistrarProducto_Load;
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStockMinimo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbImagen).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPorcentajeUtilidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCodigoBarras;
        private Label lblNombreProducto;
        private Label lblMarca;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label1;
        private Button btnGuardar;
        private Button btnCancelar;
        private TextBox txtCodigoBarras;
        private TextBox txtNombreProducto;
        private TextBox txtPrecioCompra;
        private TextBox txtPrecioVenta;
        private ComboBox cmbMarca;
        private ComboBox cmbCategoria;
        private NumericUpDown nudStock;
        private NumericUpDown nudStockMinimo;
        private PictureBox pbImagen;
        private Button btnCargarImagen;
        private NumericUpDown nudPorcentajeUtilidad;
        private Label label2;
        private Label label3;
    }
}