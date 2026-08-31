namespace sgidam
{
    partial class DetalleProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetalleProducto));
            pbImagen = new PictureBox();
            lblNombre = new Label();
            lblCodigo = new Label();
            lblMarca = new Label();
            lblCategoria = new Label();
            lblStock = new Label();
            lblStockMinimo = new Label();
            lblPrecioCompra = new Label();
            lblPrecioVenta = new Label();
            lblEstatus = new Label();
            btnCerrar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)pbImagen).BeginInit();
            SuspendLayout();
            // 
            // pbImagen
            // 
            pbImagen.Location = new Point(118, 243);
            pbImagen.Name = "pbImagen";
            pbImagen.Size = new Size(158, 117);
            pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
            pbImagen.TabIndex = 0;
            pbImagen.TabStop = false;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(192, 15);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(17, 15);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "--";
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(192, 38);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(17, 15);
            lblCodigo.TabIndex = 1;
            lblCodigo.Text = "--";
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(192, 61);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(17, 15);
            lblMarca.TabIndex = 1;
            lblMarca.Text = "--";
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(192, 84);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(17, 15);
            lblCategoria.TabIndex = 1;
            lblCategoria.Text = "--";
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(192, 107);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(17, 15);
            lblStock.TabIndex = 1;
            lblStock.Text = "--";
            // 
            // lblStockMinimo
            // 
            lblStockMinimo.AutoSize = true;
            lblStockMinimo.Location = new Point(192, 130);
            lblStockMinimo.Name = "lblStockMinimo";
            lblStockMinimo.Size = new Size(17, 15);
            lblStockMinimo.TabIndex = 1;
            lblStockMinimo.Text = "--";
            // 
            // lblPrecioCompra
            // 
            lblPrecioCompra.AutoSize = true;
            lblPrecioCompra.Location = new Point(192, 153);
            lblPrecioCompra.Name = "lblPrecioCompra";
            lblPrecioCompra.Size = new Size(17, 15);
            lblPrecioCompra.TabIndex = 1;
            lblPrecioCompra.Text = "--";
            // 
            // lblPrecioVenta
            // 
            lblPrecioVenta.AutoSize = true;
            lblPrecioVenta.Location = new Point(192, 176);
            lblPrecioVenta.Name = "lblPrecioVenta";
            lblPrecioVenta.Size = new Size(17, 15);
            lblPrecioVenta.TabIndex = 1;
            lblPrecioVenta.Text = "--";
            // 
            // lblEstatus
            // 
            lblEstatus.AutoSize = true;
            lblEstatus.Location = new Point(192, 199);
            lblEstatus.Name = "lblEstatus";
            lblEstatus.Size = new Size(17, 15);
            lblEstatus.TabIndex = 1;
            lblEstatus.Text = "--";
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(192, 378);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 32);
            btnCerrar.TabIndex = 2;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // label1
            // 
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(138, 23);
            label1.TabIndex = 1;
            label1.Text = "Nombre Del Producto:";
            // 
            // label2
            // 
            label2.Location = new Point(12, 38);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 1;
            label2.Text = "Codigo de Barras:";
            // 
            // label3
            // 
            label3.Location = new Point(12, 61);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 1;
            label3.Text = "Marca:";
            // 
            // label4
            // 
            label4.Location = new Point(12, 84);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 1;
            label4.Text = "Categoria";
            // 
            // label5
            // 
            label5.Location = new Point(12, 107);
            label5.Name = "label5";
            label5.Size = new Size(138, 23);
            label5.TabIndex = 1;
            label5.Text = "Existencias en inventario";
            // 
            // label6
            // 
            label6.Location = new Point(12, 130);
            label6.Name = "label6";
            label6.Size = new Size(100, 23);
            label6.TabIndex = 1;
            label6.Text = "Stock Minimo";
            // 
            // label7
            // 
            label7.Location = new Point(12, 153);
            label7.Name = "label7";
            label7.Size = new Size(100, 23);
            label7.TabIndex = 1;
            label7.Text = "Precio Compra:";
            // 
            // label8
            // 
            label8.Location = new Point(12, 176);
            label8.Name = "label8";
            label8.Size = new Size(100, 23);
            label8.TabIndex = 1;
            label8.Text = "Precio Venta";
            // 
            // label9
            // 
            label9.Location = new Point(12, 199);
            label9.Name = "label9";
            label9.Size = new Size(100, 23);
            label9.TabIndex = 1;
            label9.Text = "Estatus";
            // 
            // DetalleProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 251, 252);
            ClientSize = new Size(514, 483);
            Controls.Add(btnCerrar);
            Controls.Add(label9);
            Controls.Add(lblEstatus);
            Controls.Add(label8);
            Controls.Add(lblPrecioVenta);
            Controls.Add(label7);
            Controls.Add(lblPrecioCompra);
            Controls.Add(label6);
            Controls.Add(lblStockMinimo);
            Controls.Add(label5);
            Controls.Add(lblStock);
            Controls.Add(label4);
            Controls.Add(lblCategoria);
            Controls.Add(label3);
            Controls.Add(lblMarca);
            Controls.Add(label2);
            Controls.Add(lblCodigo);
            Controls.Add(label1);
            Controls.Add(lblNombre);
            Controls.Add(pbImagen);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DetalleProducto";
            Text = "DetalleProducto";
            Load += DetalleProducto_Load;
            ((System.ComponentModel.ISupportInitialize)pbImagen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbImagen;
        private Label lblNombre;
        private Label lblCodigo;
        private Label lblMarca;
        private Label lblCategoria;
        private Label lblStock;
        private Label lblStockMinimo;
        private Label lblPrecioCompra;
        private Label lblPrecioVenta;
        private Label lblEstatus;
        private Button btnCerrar;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
    }
}