namespace sgidam
{
    partial class MenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            panelMenuLateral = new Panel();
            panelSubMenuUsuarios = new Panel();
            btnAdministrarUsuario = new Button();
            btnRegistrarUsuario = new Button();
            btnUsuarios = new Button();
            panelSubMenuReportes = new Panel();
            button2 = new Button();
            btnKardex = new Button();
            btnReportes = new Button();
            panelSubMenuVentas = new Panel();
            btnRegistrarDevolucion = new Button();
            btnRegistrarVenta = new Button();
            btnVentas = new Button();
            panelSubMenuCompras = new Panel();
            btnRegistrarCompra = new Button();
            btnCompras = new Button();
            panelSubMenuProveedores = new Panel();
            btnListaDeProveedores = new Button();
            btnRegistrarProveedorProducto = new Button();
            btnRegistarProveedor = new Button();
            btnProveedores = new Button();
            panelSubMenuProductos = new Panel();
            btnInventario = new Button();
            btnRegistrarProducto = new Button();
            btnRegistrarCategoria = new Button();
            btnRegistrarMarca = new Button();
            btnProductos = new Button();
            panelLogo = new Panel();
            btnCerrarSesion = new Button();
            panelMenuLateral.SuspendLayout();
            panelSubMenuUsuarios.SuspendLayout();
            panelSubMenuReportes.SuspendLayout();
            panelSubMenuVentas.SuspendLayout();
            panelSubMenuCompras.SuspendLayout();
            panelSubMenuProveedores.SuspendLayout();
            panelSubMenuProductos.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenuLateral
            // 
            panelMenuLateral.AutoScroll = true;
            panelMenuLateral.BackColor = Color.FromArgb(61, 90, 128);
            panelMenuLateral.Controls.Add(btnCerrarSesion);
            panelMenuLateral.Controls.Add(panelSubMenuUsuarios);
            panelMenuLateral.Controls.Add(btnUsuarios);
            panelMenuLateral.Controls.Add(panelSubMenuReportes);
            panelMenuLateral.Controls.Add(btnReportes);
            panelMenuLateral.Controls.Add(panelSubMenuVentas);
            panelMenuLateral.Controls.Add(btnVentas);
            panelMenuLateral.Controls.Add(panelSubMenuCompras);
            panelMenuLateral.Controls.Add(btnCompras);
            panelMenuLateral.Controls.Add(panelSubMenuProveedores);
            panelMenuLateral.Controls.Add(btnProveedores);
            panelMenuLateral.Controls.Add(panelSubMenuProductos);
            panelMenuLateral.Controls.Add(btnProductos);
            panelMenuLateral.Controls.Add(panelLogo);
            panelMenuLateral.Dock = DockStyle.Left;
            panelMenuLateral.Location = new Point(0, 0);
            panelMenuLateral.Name = "panelMenuLateral";
            panelMenuLateral.Size = new Size(200, 961);
            panelMenuLateral.TabIndex = 4;
            // 
            // panelSubMenuUsuarios
            // 
            panelSubMenuUsuarios.BackColor = Color.FromArgb(152, 193, 217);
            panelSubMenuUsuarios.Controls.Add(btnAdministrarUsuario);
            panelSubMenuUsuarios.Controls.Add(btnRegistrarUsuario);
            panelSubMenuUsuarios.Dock = DockStyle.Top;
            panelSubMenuUsuarios.Location = new Point(0, 730);
            panelSubMenuUsuarios.Name = "panelSubMenuUsuarios";
            panelSubMenuUsuarios.Size = new Size(200, 69);
            panelSubMenuUsuarios.TabIndex = 12;
            // 
            // btnAdministrarUsuario
            // 
            btnAdministrarUsuario.Dock = DockStyle.Top;
            btnAdministrarUsuario.FlatAppearance.BorderSize = 0;
            btnAdministrarUsuario.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 224, 192);
            btnAdministrarUsuario.FlatStyle = FlatStyle.Flat;
            btnAdministrarUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdministrarUsuario.Location = new Point(0, 28);
            btnAdministrarUsuario.Name = "btnAdministrarUsuario";
            btnAdministrarUsuario.Padding = new Padding(25, 0, 0, 0);
            btnAdministrarUsuario.Size = new Size(200, 28);
            btnAdministrarUsuario.TabIndex = 1;
            btnAdministrarUsuario.Text = "Administrar Usuario";
            btnAdministrarUsuario.TextAlign = ContentAlignment.MiddleLeft;
            btnAdministrarUsuario.UseVisualStyleBackColor = true;
            btnAdministrarUsuario.Click += btnAdministrarUsuario_Click;
            // 
            // btnRegistrarUsuario
            // 
            btnRegistrarUsuario.Dock = DockStyle.Top;
            btnRegistrarUsuario.FlatAppearance.BorderSize = 0;
            btnRegistrarUsuario.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 224, 192);
            btnRegistrarUsuario.FlatStyle = FlatStyle.Flat;
            btnRegistrarUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRegistrarUsuario.Location = new Point(0, 0);
            btnRegistrarUsuario.Name = "btnRegistrarUsuario";
            btnRegistrarUsuario.Padding = new Padding(25, 0, 0, 0);
            btnRegistrarUsuario.Size = new Size(200, 28);
            btnRegistrarUsuario.TabIndex = 0;
            btnRegistrarUsuario.Text = "Registrar Usuario";
            btnRegistrarUsuario.TextAlign = ContentAlignment.MiddleLeft;
            btnRegistrarUsuario.UseVisualStyleBackColor = true;
            btnRegistrarUsuario.Click += btnRegistrarUsuario_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Dock = DockStyle.Top;
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUsuarios.Location = new Point(0, 695);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Padding = new Padding(10, 0, 0, 0);
            btnUsuarios.Size = new Size(200, 35);
            btnUsuarios.TabIndex = 11;
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.TextAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.UseVisualStyleBackColor = true;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // panelSubMenuReportes
            // 
            panelSubMenuReportes.BackColor = Color.FromArgb(152, 193, 217);
            panelSubMenuReportes.Controls.Add(button2);
            panelSubMenuReportes.Controls.Add(btnKardex);
            panelSubMenuReportes.Dock = DockStyle.Top;
            panelSubMenuReportes.Location = new Point(0, 606);
            panelSubMenuReportes.Name = "panelSubMenuReportes";
            panelSubMenuReportes.Size = new Size(200, 89);
            panelSubMenuReportes.TabIndex = 10;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Top;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 224, 192);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button2.Location = new Point(0, 28);
            button2.Name = "button2";
            button2.Padding = new Padding(25, 0, 0, 0);
            button2.Size = new Size(200, 28);
            button2.TabIndex = 2;
            button2.Text = "button2";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = true;
            // 
            // btnKardex
            // 
            btnKardex.Dock = DockStyle.Top;
            btnKardex.FlatAppearance.BorderSize = 0;
            btnKardex.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 224, 192);
            btnKardex.FlatStyle = FlatStyle.Flat;
            btnKardex.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnKardex.Location = new Point(0, 0);
            btnKardex.Name = "btnKardex";
            btnKardex.Padding = new Padding(25, 0, 0, 0);
            btnKardex.Size = new Size(200, 28);
            btnKardex.TabIndex = 1;
            btnKardex.Text = "Kardex";
            btnKardex.TextAlign = ContentAlignment.MiddleLeft;
            btnKardex.UseVisualStyleBackColor = true;
            btnKardex.Click += btnKardex_Click;
            // 
            // btnReportes
            // 
            btnReportes.Dock = DockStyle.Top;
            btnReportes.FlatAppearance.BorderSize = 0;
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReportes.Location = new Point(0, 571);
            btnReportes.Name = "btnReportes";
            btnReportes.Padding = new Padding(10, 0, 0, 0);
            btnReportes.Size = new Size(200, 35);
            btnReportes.TabIndex = 9;
            btnReportes.Text = "Reportes";
            btnReportes.TextAlign = ContentAlignment.MiddleLeft;
            btnReportes.UseVisualStyleBackColor = true;
            btnReportes.Click += btnReportes_Click;
            // 
            // panelSubMenuVentas
            // 
            panelSubMenuVentas.BackColor = Color.FromArgb(152, 193, 217);
            panelSubMenuVentas.Controls.Add(btnRegistrarDevolucion);
            panelSubMenuVentas.Controls.Add(btnRegistrarVenta);
            panelSubMenuVentas.Dock = DockStyle.Top;
            panelSubMenuVentas.Location = new Point(0, 504);
            panelSubMenuVentas.Name = "panelSubMenuVentas";
            panelSubMenuVentas.Size = new Size(200, 67);
            panelSubMenuVentas.TabIndex = 8;
            // 
            // btnRegistrarDevolucion
            // 
            btnRegistrarDevolucion.Dock = DockStyle.Top;
            btnRegistrarDevolucion.FlatAppearance.BorderSize = 0;
            btnRegistrarDevolucion.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 224, 192);
            btnRegistrarDevolucion.FlatStyle = FlatStyle.Flat;
            btnRegistrarDevolucion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRegistrarDevolucion.Location = new Point(0, 28);
            btnRegistrarDevolucion.Name = "btnRegistrarDevolucion";
            btnRegistrarDevolucion.Padding = new Padding(25, 0, 0, 0);
            btnRegistrarDevolucion.Size = new Size(200, 28);
            btnRegistrarDevolucion.TabIndex = 1;
            btnRegistrarDevolucion.Text = "Devolución";
            btnRegistrarDevolucion.TextAlign = ContentAlignment.MiddleLeft;
            btnRegistrarDevolucion.UseVisualStyleBackColor = true;
            btnRegistrarDevolucion.Click += btnRegistrarDevolucion_Click;
            // 
            // btnRegistrarVenta
            // 
            btnRegistrarVenta.Dock = DockStyle.Top;
            btnRegistrarVenta.FlatAppearance.BorderSize = 0;
            btnRegistrarVenta.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 224, 192);
            btnRegistrarVenta.FlatStyle = FlatStyle.Flat;
            btnRegistrarVenta.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRegistrarVenta.Location = new Point(0, 0);
            btnRegistrarVenta.Name = "btnRegistrarVenta";
            btnRegistrarVenta.Padding = new Padding(25, 0, 0, 0);
            btnRegistrarVenta.Size = new Size(200, 28);
            btnRegistrarVenta.TabIndex = 0;
            btnRegistrarVenta.Text = "Registrar Venta";
            btnRegistrarVenta.TextAlign = ContentAlignment.MiddleLeft;
            btnRegistrarVenta.UseVisualStyleBackColor = true;
            btnRegistrarVenta.Click += btnRegistrarVenta_Click;
            // 
            // btnVentas
            // 
            btnVentas.Dock = DockStyle.Top;
            btnVentas.FlatAppearance.BorderSize = 0;
            btnVentas.FlatStyle = FlatStyle.Flat;
            btnVentas.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVentas.Location = new Point(0, 469);
            btnVentas.Name = "btnVentas";
            btnVentas.Padding = new Padding(10, 0, 0, 0);
            btnVentas.Size = new Size(200, 35);
            btnVentas.TabIndex = 7;
            btnVentas.Text = "Ventas";
            btnVentas.TextAlign = ContentAlignment.MiddleLeft;
            btnVentas.UseVisualStyleBackColor = true;
            btnVentas.Click += btnVentas_Click;
            // 
            // panelSubMenuCompras
            // 
            panelSubMenuCompras.BackColor = Color.FromArgb(152, 193, 217);
            panelSubMenuCompras.Controls.Add(btnRegistrarCompra);
            panelSubMenuCompras.Dock = DockStyle.Top;
            panelSubMenuCompras.Location = new Point(0, 432);
            panelSubMenuCompras.Name = "panelSubMenuCompras";
            panelSubMenuCompras.Size = new Size(200, 37);
            panelSubMenuCompras.TabIndex = 6;
            // 
            // btnRegistrarCompra
            // 
            btnRegistrarCompra.Dock = DockStyle.Top;
            btnRegistrarCompra.FlatAppearance.BorderSize = 0;
            btnRegistrarCompra.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 224, 192);
            btnRegistrarCompra.FlatStyle = FlatStyle.Flat;
            btnRegistrarCompra.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRegistrarCompra.Location = new Point(0, 0);
            btnRegistrarCompra.Name = "btnRegistrarCompra";
            btnRegistrarCompra.Padding = new Padding(25, 0, 0, 0);
            btnRegistrarCompra.Size = new Size(200, 28);
            btnRegistrarCompra.TabIndex = 0;
            btnRegistrarCompra.Text = "Registrar Compra";
            btnRegistrarCompra.TextAlign = ContentAlignment.MiddleLeft;
            btnRegistrarCompra.UseVisualStyleBackColor = true;
            btnRegistrarCompra.Click += btnRegistrarCompra_Click;
            // 
            // btnCompras
            // 
            btnCompras.Dock = DockStyle.Top;
            btnCompras.FlatAppearance.BorderSize = 0;
            btnCompras.FlatStyle = FlatStyle.Flat;
            btnCompras.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCompras.Location = new Point(0, 397);
            btnCompras.Name = "btnCompras";
            btnCompras.Padding = new Padding(10, 0, 0, 0);
            btnCompras.Size = new Size(200, 35);
            btnCompras.TabIndex = 5;
            btnCompras.Text = "Compras";
            btnCompras.TextAlign = ContentAlignment.MiddleLeft;
            btnCompras.UseVisualStyleBackColor = true;
            btnCompras.Click += btnCompras_Click;
            // 
            // panelSubMenuProveedores
            // 
            panelSubMenuProveedores.BackColor = Color.FromArgb(152, 193, 217);
            panelSubMenuProveedores.Controls.Add(btnListaDeProveedores);
            panelSubMenuProveedores.Controls.Add(btnRegistrarProveedorProducto);
            panelSubMenuProveedores.Controls.Add(btnRegistarProveedor);
            panelSubMenuProveedores.Dock = DockStyle.Top;
            panelSubMenuProveedores.Location = new Point(0, 294);
            panelSubMenuProveedores.Name = "panelSubMenuProveedores";
            panelSubMenuProveedores.Size = new Size(200, 103);
            panelSubMenuProveedores.TabIndex = 4;
            // 
            // btnListaDeProveedores
            // 
            btnListaDeProveedores.Dock = DockStyle.Top;
            btnListaDeProveedores.FlatAppearance.BorderSize = 0;
            btnListaDeProveedores.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 224, 192);
            btnListaDeProveedores.FlatStyle = FlatStyle.Flat;
            btnListaDeProveedores.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnListaDeProveedores.Location = new Point(0, 68);
            btnListaDeProveedores.Name = "btnListaDeProveedores";
            btnListaDeProveedores.Padding = new Padding(25, 0, 0, 0);
            btnListaDeProveedores.Size = new Size(200, 28);
            btnListaDeProveedores.TabIndex = 2;
            btnListaDeProveedores.Text = "Lista de Proveedores";
            btnListaDeProveedores.TextAlign = ContentAlignment.MiddleLeft;
            btnListaDeProveedores.UseVisualStyleBackColor = true;
            btnListaDeProveedores.Click += btnListaDeProveedores_Click;
            // 
            // btnRegistrarProveedorProducto
            // 
            btnRegistrarProveedorProducto.Dock = DockStyle.Top;
            btnRegistrarProveedorProducto.FlatAppearance.BorderSize = 0;
            btnRegistrarProveedorProducto.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 224, 192);
            btnRegistrarProveedorProducto.FlatStyle = FlatStyle.Flat;
            btnRegistrarProveedorProducto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRegistrarProveedorProducto.Location = new Point(0, 28);
            btnRegistrarProveedorProducto.Name = "btnRegistrarProveedorProducto";
            btnRegistrarProveedorProducto.Padding = new Padding(25, 0, 0, 0);
            btnRegistrarProveedorProducto.Size = new Size(200, 40);
            btnRegistrarProveedorProducto.TabIndex = 1;
            btnRegistrarProveedorProducto.Text = "Registrar Producto de un Proveedor";
            btnRegistrarProveedorProducto.TextAlign = ContentAlignment.MiddleLeft;
            btnRegistrarProveedorProducto.UseVisualStyleBackColor = true;
            btnRegistrarProveedorProducto.Click += btnRegistrarProveedorProducto_Click;
            // 
            // btnRegistarProveedor
            // 
            btnRegistarProveedor.Dock = DockStyle.Top;
            btnRegistarProveedor.FlatAppearance.BorderSize = 0;
            btnRegistarProveedor.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 224, 192);
            btnRegistarProveedor.FlatStyle = FlatStyle.Flat;
            btnRegistarProveedor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRegistarProveedor.Location = new Point(0, 0);
            btnRegistarProveedor.Name = "btnRegistarProveedor";
            btnRegistarProveedor.Padding = new Padding(25, 0, 0, 0);
            btnRegistarProveedor.Size = new Size(200, 28);
            btnRegistarProveedor.TabIndex = 0;
            btnRegistarProveedor.Text = "Registrar Proveedor";
            btnRegistarProveedor.TextAlign = ContentAlignment.MiddleLeft;
            btnRegistarProveedor.UseVisualStyleBackColor = true;
            btnRegistarProveedor.Click += btnRegistarProveedor_Click;
            // 
            // btnProveedores
            // 
            btnProveedores.Dock = DockStyle.Top;
            btnProveedores.FlatAppearance.BorderSize = 0;
            btnProveedores.FlatStyle = FlatStyle.Flat;
            btnProveedores.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProveedores.Location = new Point(0, 259);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Padding = new Padding(10, 0, 0, 0);
            btnProveedores.Size = new Size(200, 35);
            btnProveedores.TabIndex = 3;
            btnProveedores.Text = "Proveedores";
            btnProveedores.TextAlign = ContentAlignment.MiddleLeft;
            btnProveedores.UseVisualStyleBackColor = true;
            btnProveedores.Click += btnProveedores_Click;
            // 
            // panelSubMenuProductos
            // 
            panelSubMenuProductos.BackColor = Color.FromArgb(152, 193, 217);
            panelSubMenuProductos.Controls.Add(btnInventario);
            panelSubMenuProductos.Controls.Add(btnRegistrarProducto);
            panelSubMenuProductos.Controls.Add(btnRegistrarCategoria);
            panelSubMenuProductos.Controls.Add(btnRegistrarMarca);
            panelSubMenuProductos.Dock = DockStyle.Top;
            panelSubMenuProductos.Location = new Point(0, 135);
            panelSubMenuProductos.Name = "panelSubMenuProductos";
            panelSubMenuProductos.Size = new Size(200, 124);
            panelSubMenuProductos.TabIndex = 2;
            // 
            // btnInventario
            // 
            btnInventario.Dock = DockStyle.Top;
            btnInventario.FlatAppearance.BorderSize = 0;
            btnInventario.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 224, 192);
            btnInventario.FlatStyle = FlatStyle.Flat;
            btnInventario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInventario.Location = new Point(0, 84);
            btnInventario.Name = "btnInventario";
            btnInventario.Padding = new Padding(25, 0, 0, 0);
            btnInventario.Size = new Size(200, 28);
            btnInventario.TabIndex = 3;
            btnInventario.Text = "Inventario";
            btnInventario.TextAlign = ContentAlignment.MiddleLeft;
            btnInventario.UseVisualStyleBackColor = true;
            btnInventario.Click += btnInventario_Click_1;
            // 
            // btnRegistrarProducto
            // 
            btnRegistrarProducto.Dock = DockStyle.Top;
            btnRegistrarProducto.FlatAppearance.BorderSize = 0;
            btnRegistrarProducto.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 224, 192);
            btnRegistrarProducto.FlatStyle = FlatStyle.Flat;
            btnRegistrarProducto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRegistrarProducto.Location = new Point(0, 56);
            btnRegistrarProducto.Name = "btnRegistrarProducto";
            btnRegistrarProducto.Padding = new Padding(25, 0, 0, 0);
            btnRegistrarProducto.Size = new Size(200, 28);
            btnRegistrarProducto.TabIndex = 2;
            btnRegistrarProducto.Text = "Registar Producto";
            btnRegistrarProducto.TextAlign = ContentAlignment.MiddleLeft;
            btnRegistrarProducto.UseVisualStyleBackColor = true;
            btnRegistrarProducto.Click += btnRegistrarProducto_Click;
            // 
            // btnRegistrarCategoria
            // 
            btnRegistrarCategoria.Dock = DockStyle.Top;
            btnRegistrarCategoria.FlatAppearance.BorderSize = 0;
            btnRegistrarCategoria.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 224, 192);
            btnRegistrarCategoria.FlatStyle = FlatStyle.Flat;
            btnRegistrarCategoria.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRegistrarCategoria.Location = new Point(0, 28);
            btnRegistrarCategoria.Name = "btnRegistrarCategoria";
            btnRegistrarCategoria.Padding = new Padding(25, 0, 0, 0);
            btnRegistrarCategoria.Size = new Size(200, 28);
            btnRegistrarCategoria.TabIndex = 1;
            btnRegistrarCategoria.Text = "Registrar Categoria";
            btnRegistrarCategoria.TextAlign = ContentAlignment.MiddleLeft;
            btnRegistrarCategoria.UseVisualStyleBackColor = true;
            btnRegistrarCategoria.Click += btnRegistrarCategoria_Click;
            // 
            // btnRegistrarMarca
            // 
            btnRegistrarMarca.Dock = DockStyle.Top;
            btnRegistrarMarca.FlatAppearance.BorderSize = 0;
            btnRegistrarMarca.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 224, 192);
            btnRegistrarMarca.FlatStyle = FlatStyle.Flat;
            btnRegistrarMarca.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRegistrarMarca.Location = new Point(0, 0);
            btnRegistrarMarca.Name = "btnRegistrarMarca";
            btnRegistrarMarca.Padding = new Padding(25, 0, 0, 0);
            btnRegistrarMarca.Size = new Size(200, 28);
            btnRegistrarMarca.TabIndex = 0;
            btnRegistrarMarca.Text = "Registrar Marca";
            btnRegistrarMarca.TextAlign = ContentAlignment.MiddleLeft;
            btnRegistrarMarca.UseVisualStyleBackColor = true;
            btnRegistrarMarca.Click += btnRegistrarMarca_Click;
            // 
            // btnProductos
            // 
            btnProductos.Dock = DockStyle.Top;
            btnProductos.FlatAppearance.BorderSize = 0;
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProductos.Location = new Point(0, 100);
            btnProductos.Name = "btnProductos";
            btnProductos.Padding = new Padding(10, 0, 0, 0);
            btnProductos.Size = new Size(200, 35);
            btnProductos.TabIndex = 1;
            btnProductos.Text = "Productos";
            btnProductos.TextAlign = ContentAlignment.MiddleLeft;
            btnProductos.UseVisualStyleBackColor = true;
            btnProductos.Click += btnProductos_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackgroundImage = Properties.Resources.logo_principal_removebg_preview;
            panelLogo.BackgroundImageLayout = ImageLayout.Stretch;
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(200, 100);
            panelLogo.TabIndex = 0;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.FromArgb(238, 108, 77);
            btnCerrarSesion.Dock = DockStyle.Top;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrarSesion.Location = new Point(0, 799);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Padding = new Padding(10, 0, 0, 0);
            btnCerrarSesion.Size = new Size(200, 35);
            btnCerrarSesion.TabIndex = 13;
            btnCerrarSesion.Text = "Cerrar Sesion";
            btnCerrarSesion.TextAlign = ContentAlignment.MiddleLeft;
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 251, 252);
            ClientSize = new Size(1067, 961);
            Controls.Add(panelMenuLateral);
            ForeColor = Color.Gainsboro;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MenuPrincipal";
            Text = "MenuPrincipal";
            Load += MenuPrincipal_Load_1;
            panelMenuLateral.ResumeLayout(false);
            panelSubMenuUsuarios.ResumeLayout(false);
            panelSubMenuReportes.ResumeLayout(false);
            panelSubMenuVentas.ResumeLayout(false);
            panelSubMenuCompras.ResumeLayout(false);
            panelSubMenuProveedores.ResumeLayout(false);
            panelSubMenuProductos.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panelMenuLateral;
        private Panel panelLogo;
        private Panel panelSubMenuProductos;
        private Button btnProductos;
        private Button btnRegistrarProducto;
        private Button btnRegistrarCategoria;
        private Button btnRegistrarMarca;
        private Panel panelSubMenuVentas;
        private Button button14;
        private Button btnRegistrarDevolucion;
        private Button btnRegistrarVenta;
        private Button btnVentas;
        private Panel panelSubMenuCompras;
        private Button btnRegistrarCompra;
        private Button btnCompras;
        private Panel panelSubMenuProveedores;
        private Button btnListaDeProveedores;
        private Button btnRegistrarProveedorProducto;
        private Button btnRegistarProveedor;
        private Button btnProveedores;
        private Panel panelSubMenuReportes;
        private Button button2;
        private Button btnKardex;
        private Button button9;
        private Button btnReportes;
        private Panel panelSubMenuUsuarios;
        private Button btnAdministrarUsuario;
        private Button button13;
        private Button btnRegistrarUsuario;
        private Button btnUsuarios;
        private Button btnInventario;
        private Button btnCerrarSesion;
    }
}