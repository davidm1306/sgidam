using sgidam.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sgidam
{
    public partial class MenuPrincipal : Form
    {
        private System.Windows.Forms.Timer _timerInactividad;
        // 5 minutos en milisegundos (300,000 ms)
        private const int TIEMPO_EXPIRACION_MS = 30 * 60 * 1000;



        public MenuPrincipal()
        {
            InitializeComponent();
            this.KeyPreview = true;
            InicializarTimer();
            personalizarMenuLateral();
        }
        private void InicializarTimer()
        {
            _timerInactividad = new System.Windows.Forms.Timer();
            _timerInactividad.Interval = TIEMPO_EXPIRACION_MS;
            _timerInactividad.Tick += TimerInactividad_Tick;


            this.Load += MenuPrincipal_Load;
            this.KeyDown += ReiniciarTimer;
            this.MouseClick += ReiniciarTimer;
            this.MouseMove += ReiniciarTimer;


            foreach (Control ctrl in this.Controls)
            {
                ctrl.KeyDown += ReiniciarTimer;
                ctrl.MouseClick += ReiniciarTimer;
                ctrl.MouseMove += ReiniciarTimer;
            }
        }


        private void ReiniciarTimer(object sender, EventArgs e)
        {
            _timerInactividad.Stop();
            _timerInactividad.Start();
        }

        private void TimerInactividad_Tick(object sender, EventArgs e)
        {
            _timerInactividad.Stop();

            Global.UsuarioSesion = null;

            MessageBox.Show("Tu sesión ha expirado por inactividad (5 minutos). Por favor, inicia sesión nuevamente.",
                            "Sesión expirada",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

            this.Close();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

            this.Text = $"Sistema de Inventario - {Global.UsuarioSesion.nombre_empleado} ({Global.UsuarioSesion.rol})";


            _timerInactividad.Start();

            string rol = Global.UsuarioSesion.rol;


            if (rol == "Vendedor")
            {
                btnProveedores.Visible = false;
                btnReportes.Visible = false;
                btnUsuarios.Visible = false;

            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timerInactividad?.Stop();
            _timerInactividad?.Dispose();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (RegistrarProducto frm = new RegistrarProducto())
            {
                frm.ShowDialog(this);

            }
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (RegistrarUsuario frm = new RegistrarUsuario())
            {
                frm.ShowDialog(this);
            }
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (RegistrarMarca frm = new RegistrarMarca())
            {
                frm.ShowDialog(this);
            }
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (RegistrarCategoria frm = new RegistrarCategoria())
            {
                frm.ShowDialog(this);
            }
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (RegistrarProveedor frm = new RegistrarProveedor())
            {
                frm.ShowDialog(this);
            }
        }

        private void listaDeProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ListaProveedores frm = new ListaProveedores())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            using (Compras frm = new Compras())
            {
                frm.ShowDialog(this);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Ventas frm = new Ventas())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            using (RegistrarProducto frm = new RegistrarProducto())
            {
                frm.ShowDialog(this);

            }
        }

        private void MenuPrincipal_Load_1(object sender, EventArgs e)
        {
        }

        public void personalizarMenuLateral()
        {
            panelSubMenuProductos.Visible = false;
            panelSubMenuProveedores.Visible = false;
            panelSubMenuCompras.Visible = false;
            panelSubMenuVentas.Visible = false;
            panelSubMenuReportes.Visible = false;
            panelSubMenuUsuarios.Visible = false;
        }

        public void ocultarSubMenu()
        {
            if (panelSubMenuProductos.Visible == true)
                panelSubMenuProductos.Visible = false;

            if (panelSubMenuProveedores.Visible == true)
                panelSubMenuProveedores.Visible = false;

            if (panelSubMenuCompras.Visible == true)
                panelSubMenuCompras.Visible = false;

            if (panelSubMenuVentas.Visible == true)
                panelSubMenuVentas.Visible = false;

            if (panelSubMenuReportes.Visible == true)
                panelSubMenuReportes.Visible = false;

            if (panelSubMenuUsuarios.Visible == true)
                panelSubMenuUsuarios.Visible = false;

        }

        private void mostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                ocultarSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registrarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            using (RegistrarUsuario frm = new RegistrarUsuario())
            {
                frm.ShowDialog(this);
            }
        }

        private void registrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (RegistrarProveedor frm = new RegistrarProveedor())
            {
                frm.ShowDialog(this);
            }
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ListaProveedores frm = new ListaProveedores())
            {
                frm.ShowDialog(this);
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kardexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Kardex frm = new Kardex())
            {
                frm.ShowDialog(this);
            }
        }


        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AdministrarUsuarios frm = new AdministrarUsuarios())
            {
                frm.ShowDialog(this);
            }
        }

        private void listaDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new MostrarProveedores())
            {
                frm.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelSubMenuProductos);
        }

        private void btnRegistrarMarca_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();

            using (RegistrarMarca frm = new RegistrarMarca())
            {
                frm.ShowDialog(this);
            }

        }

        private void btnRegistrarCategoria_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();

            using (RegistrarCategoria frm = new RegistrarCategoria())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();

            using (RegistrarProducto frm = new RegistrarProducto())
            {
                frm.ShowDialog(this);

            }

        }

        private void btnInventario_Click_1(object sender, EventArgs e)
        {
            ocultarSubMenu();

            using (Inventario frm = new Inventario())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelSubMenuProveedores);
        }

        private void btnRegistarProveedor_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();

            using (RegistrarProveedor frm = new RegistrarProveedor())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnRegistrarProveedorProducto_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();

            using (ListaProveedores frm = new ListaProveedores())
            {
                frm.ShowDialog(this);
            }

        }

        private void btnListaDeProveedores_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();

            using (var frm = new MostrarProveedores())
            {
                frm.ShowDialog();
            }
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelSubMenuCompras);
        }
        private void btnRegistrarCompra_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();

            using (Compras frm = new Compras())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelSubMenuVentas);
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();

            using (Ventas frm = new Ventas())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnRegistrarDevolucion_Click(object sender, EventArgs e)
        {
            using (var frm = new Devoluciones())
            {
                frm.ShowDialog();
            }
        }
        

        private void btnListaFacturas_Click(object sender, EventArgs e)
        {
            using (var frm = new ListaFacturas())
            {
                frm.ShowDialog();
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelSubMenuReportes);
        }

        private void btnKardex_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();

            using (Kardex frm = new Kardex())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelSubMenuUsuarios);
        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();

            using (RegistrarUsuario frm = new RegistrarUsuario())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnAdministrarUsuario_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();

            using (AdministrarUsuarios frm = new AdministrarUsuarios())
            {
                frm.ShowDialog(this);
            }
        }


        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Global.UsuarioSesion = null;
            this.Close();
        }

        private void btnDevoluciones_Click(object sender, EventArgs e)
        {
            using (var frm = new Devoluciones())
            {
                frm.ShowDialog();
            }
        }
    }
}
