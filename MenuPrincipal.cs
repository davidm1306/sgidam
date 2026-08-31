using sgidam.Data;
using sgidam.Helpers;
using sgidam.Models;
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
        private System.Windows.Forms.Timer _timerActualizacion;
        // 5 minutos en milisegundos 5 * 60 * 1000 (300,000 ms)
        private const int TIEMPO_EXPIRACION_MS = 30 * 60 * 1000;



        public MenuPrincipal()
        {
            InitializeComponent();
            this.KeyPreview = true;
            InicializarTimer();
            TimerActualizacion();
            personalizarMenuLateral();

            comboPeriodo.Items.Clear();
            comboPeriodo.Items.Add("Últimos 7 días");
            comboPeriodo.Items.Add("Últimos 30 días");
            comboPeriodo.Items.Add("Últimos 90 días");
            comboPeriodo.SelectedIndex = 1;
            comboPeriodo.SelectedIndexChanged += comboPeriodo_SelectedIndexChanged;


            CargarDashboard(30);
        }

        private void comboPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int dias = 30;
            switch (comboPeriodo.SelectedIndex)
            {
                case 0: dias = 7; break;
                case 1: dias = 30; break;
                case 2: dias = 90; break;
            }
            CargarDashboard(dias);
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

        private void TimerActualizacion()
        {
            _timerActualizacion = new System.Windows.Forms.Timer();
            _timerActualizacion.Interval = 60000;
            _timerActualizacion.Tick += (s, e) =>
            {
                int dias = 30;
                switch (comboPeriodo.SelectedIndex)
                {
                    case 0: dias = 7; break;
                    case 1: dias = 30; break;
                    case 2: dias = 90; break;
                }
                CargarDashboard(dias);
            };
            _timerActualizacion.Start();
        }

        private void CargarDashboard(int dias = 30)
        {
            try
            {

                DataTable dtResumen = DashboardHelper.GetResumenGeneral();
                if (dtResumen != null && dtResumen.Rows.Count > 0)
                {
                    DataRow row = dtResumen.Rows[0];

                    lblTotalProductos.Text = row["TotalProductos"]?.ToString() ?? "0";
                    lblStockCritico.Text = row["StockCritico"]?.ToString() ?? "0";


                    if (row["ValorInventario"] != DBNull.Value)
                    {
                        decimal valor = Convert.ToDecimal(row["ValorInventario"]);
                        lblValorInventario.Text = valor.ToString();
                    }
                    else
                    {
                        lblValorInventario.Text = "$0.00";
                    }
                }

                DataTable dtVentasHoy = DashboardHelper.GetVentasHoy();
                if (dtVentasHoy != null && dtVentasHoy.Rows.Count > 0)
                {
                    DataRow row = dtVentasHoy.Rows[0];
                    int numVentas = Convert.ToInt32(row["NumVentas"]);
                    decimal monto = row["MontoTotal"] != DBNull.Value ? Convert.ToDecimal(row["MontoTotal"]) : 0;
                    lblVentasHoy.Text = $"{numVentas} ventas - Total: ${monto}";
                }
                else
                {
                    lblVentasHoy.Text = "0 ventas - Total: $0.00";
                }

                DataTable dtCriticos = DashboardHelper.GetProductosStockCritico();
                dgvStockCritico.DataSource = dtCriticos;
                if (dgvStockCritico.Columns.Contains("codigo_barras"))
                    dgvStockCritico.Columns["codigo_barras"].HeaderText = "Código de barras";
                if (dgvStockCritico.Columns.Contains("nombre_producto"))
                    dgvStockCritico.Columns["nombre_producto"].HeaderText = "Nombre del Producto";
                if (dgvStockCritico.Columns.Contains("stock"))
                    dgvStockCritico.Columns["stock"].HeaderText = "Stock";
                if (dgvStockCritico.Columns.Contains("stock_minimo"))
                    dgvStockCritico.Columns["stock_minimo"].HeaderText = "Stock Mínimo";
                if (dgvStockCritico.Columns.Contains("Estado"))
                    dgvStockCritico.Columns["Estado"].HeaderText = "Estado";
                dgvStockCritico.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgvStockCritico.AutoResizeColumns();
                dgvStockCritico.ClearSelection();
                dgvStockCritico.CurrentCell = null;


                foreach (DataGridViewRow row in dgvStockCritico.Rows)
                {
                    if (row.Cells["Estado"].Value?.ToString() == "Crítico")
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else if (row.Cells["Estado"].Value?.ToString() == "Alerta")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightYellow;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }


                DataTable dtTopProd = DashboardHelper.GetTopProductosVendidos(dias);
                dgvTopProductos.DataSource = dtTopProd;
                if (dgvTopProductos.Columns.Contains("nombre_producto"))
                    dgvTopProductos.Columns["nombre_producto"].HeaderText = "Nombre del Producto";
                if (dgvTopProductos.Columns.Contains("UnidadesVendidas"))
                    dgvTopProductos.Columns["UnidadesVendidas"].HeaderText = "Unidades Vendidas";
                if (dgvTopProductos.Columns.Contains("MontoTotal"))
                    dgvTopProductos.Columns["MontoTotal"].HeaderText = "Monto Total";
                dgvTopProductos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgvTopProductos.AutoResizeColumns();
                dgvTopProductos.ClearSelection();
                dgvTopProductos.CurrentCell = null;



                DataTable dtTopCli = DashboardHelper.GetTopClientes(dias);
                dgvTopClientes.DataSource = dtTopCli;
                if (dgvTopClientes.Columns.Contains("nombre_cliente"))
                    dgvTopClientes.Columns["nombre_cliente"].HeaderText = "Nombre del Cliente";
                if (dgvTopClientes.Columns.Contains("NumCompras"))
                    dgvTopClientes.Columns["NumCompras"].HeaderText = "Número de compras";
                if (dgvTopClientes.Columns.Contains("TotalGastado"))
                    dgvTopClientes.Columns["TotalGastado"].HeaderText = "Total Gastado";
                dgvTopClientes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgvTopClientes.AutoResizeColumns();
                dgvTopClientes.ClearSelection();
                dgvTopClientes.CurrentCell = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el Dashboard: {ex.Message}",
                                "Error de carga",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
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


            if (rol == "Vendedor" || rol == "VENDEDOR")
            {
                btnProveedores.Visible = false;
                btnReportes.Visible = false;
                btnUsuarios.Visible = false;

            }

            CargarDashboard(30);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timerInactividad?.Stop();
            _timerInactividad?.Dispose();
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
