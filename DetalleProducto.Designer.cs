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
            ((System.ComponentModel.ISupportInitialize)pbImagen).BeginInit();
            SuspendLayout();
            // 
            // pbImagen
            // 
            pbImagen.Location = new Point(12, 12);
            pbImagen.Name = "pbImagen";
            pbImagen.Size = new Size(158, 117);
            pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
            pbImagen.TabIndex = 0;
            pbImagen.TabStop = false;
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(192, 15);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(100, 23);
            lblNombre.TabIndex = 1;
            // 
            // lblCodigo
            // 
            lblCodigo.Location = new Point(192, 38);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(100, 23);
            lblCodigo.TabIndex = 1;
            // 
            // lblMarca
            // 
            lblMarca.Location = new Point(192, 61);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(100, 23);
            lblMarca.TabIndex = 1;
            // 
            // lblCategoria
            // 
            lblCategoria.Location = new Point(192, 84);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(100, 23);
            lblCategoria.TabIndex = 1;
            // 
            // lblStock
            // 
            lblStock.Location = new Point(192, 107);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(100, 23);
            lblStock.TabIndex = 1;
            // 
            // lblStockMinimo
            // 
            lblStockMinimo.Location = new Point(192, 130);
            lblStockMinimo.Name = "lblStockMinimo";
            lblStockMinimo.Size = new Size(100, 23);
            lblStockMinimo.TabIndex = 1;
            // 
            // lblPrecioCompra
            // 
            lblPrecioCompra.Location = new Point(192, 153);
            lblPrecioCompra.Name = "lblPrecioCompra";
            lblPrecioCompra.Size = new Size(100, 23);
            lblPrecioCompra.TabIndex = 1;
            // 
            // lblPrecioVenta
            // 
            lblPrecioVenta.Location = new Point(192, 176);
            lblPrecioVenta.Name = "lblPrecioVenta";
            lblPrecioVenta.Size = new Size(100, 23);
            lblPrecioVenta.TabIndex = 1;
            // 
            // lblEstatus
            // 
            lblEstatus.Location = new Point(192, 199);
            lblEstatus.Name = "lblEstatus";
            lblEstatus.Size = new Size(100, 23);
            lblEstatus.TabIndex = 1;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(192, 275);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 32);
            btnCerrar.TabIndex = 2;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // DetalleProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 251, 252);
            ClientSize = new Size(566, 345);
            Controls.Add(btnCerrar);
            Controls.Add(lblEstatus);
            Controls.Add(lblPrecioVenta);
            Controls.Add(lblPrecioCompra);
            Controls.Add(lblStockMinimo);
            Controls.Add(lblStock);
            Controls.Add(lblCategoria);
            Controls.Add(lblMarca);
            Controls.Add(lblCodigo);
            Controls.Add(lblNombre);
            Controls.Add(pbImagen);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DetalleProducto";
            Text = "DetalleProducto";
            Load += DetalleProducto_Load;
            ((System.ComponentModel.ISupportInitialize)pbImagen).EndInit();
            ResumeLayout(false);
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
    }
}