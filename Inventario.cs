using sgidam.Data;
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
    public partial class Inventario : Form
    {
        public Inventario()
        {
            InitializeComponent();
            ConfigurarEventos();
            CargarCombosFiltros();
            CargarInventario("");
        }

        private void ConfigurarEventos()
        {
            
            chkFiltrarCategoria.CheckedChanged += (s, e) => { cmbCategoria.Enabled = chkFiltrarCategoria.Checked; if (!chkFiltrarCategoria.Checked) cmbCategoria.SelectedIndex = -1; AplicarFiltros(); };
            chkFiltrarMarca.CheckedChanged += (s, e) => { cmbMarca.Enabled = chkFiltrarMarca.Checked; if (!chkFiltrarMarca.Checked) cmbMarca.SelectedIndex = -1; AplicarFiltros(); };
            chkFiltrarEstado.CheckedChanged += (s, e) => { cmbEstado.Enabled = chkFiltrarEstado.Checked; if (!chkFiltrarEstado.Checked) cmbEstado.SelectedIndex = -1; AplicarFiltros(); };
            chkFiltrarStock.CheckedChanged += (s, e) => { nudStockMin.Enabled = chkFiltrarStock.Checked; nudStockMax.Enabled = chkFiltrarStock.Checked; AplicarFiltros(); };

            
            cmbCategoria.SelectedIndexChanged += (s, e) => AplicarFiltros();
            cmbMarca.SelectedIndexChanged += (s, e) => AplicarFiltros();
            cmbEstado.SelectedIndexChanged += (s, e) => AplicarFiltros();
            nudStockMin.ValueChanged += (s, e) => AplicarFiltros();
            nudStockMax.ValueChanged += (s, e) => AplicarFiltros();

            
            txtBuscar.KeyPress += (s, e) => { if (e.KeyChar == (char)Keys.Enter) AplicarFiltros(); };

            
            btnBuscar.Click += (s, e) => AplicarFiltros();

            
            btnLimpiarFiltros.Click += (s, e) => LimpiarFiltros();

            
            dgvInventario.CellDoubleClick += DgvInventario_CellDoubleClick;

            
            dgvInventario.CellFormatting += DgvInventario_CellFormatting;
            dgvInventario.AllowUserToAddRows = false;
        }

        private void CargarCombosFiltros()
        {
            // Cargar categorías
            DataTable dtCategorias = Producto.ObtenerCategorias();
            cmbCategoria.DataSource = dtCategorias;
            cmbCategoria.DisplayMember = "nombre_categoria";
            cmbCategoria.ValueMember = "id_categoria";
            cmbCategoria.SelectedIndex = -1;

            // Cargar marcas
            DataTable dtMarcas = Producto.ObtenerMarcas();
            cmbMarca.DataSource = dtMarcas;
            cmbMarca.DisplayMember = "nombre_marca";
            cmbMarca.ValueMember = "id_marca";
            cmbMarca.SelectedIndex = -1;

            // Cargar estados
            DataTable dtEstatus = Producto.ObtenerEstatus();
            cmbEstado.DataSource = dtEstatus;
            cmbEstado.DisplayMember = "tipo_status";
            cmbEstado.ValueMember = "id_estatus";
            cmbEstado.SelectedIndex = -1;

            // Inicializar rangos
            nudStockMin.Value = 0;
            nudStockMax.Value = 999999;
            nudStockMin.Enabled = false;
            nudStockMax.Enabled = false;
            cmbCategoria.Enabled = false;
            cmbMarca.Enabled = false;
            cmbEstado.Enabled = false;
        }

        private void AplicarFiltros()
        {
            CargarInventario(txtBuscar.Text.Trim());
        }

        private void LimpiarFiltros()
        {
            txtBuscar.Clear();
            chkFiltrarCategoria.Checked = false;
            chkFiltrarMarca.Checked = false;
            chkFiltrarEstado.Checked = false;
            chkFiltrarStock.Checked = false;
            cmbCategoria.SelectedIndex = -1;
            cmbMarca.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            nudStockMin.Value = 0;
            nudStockMax.Value = 999999;
            AplicarFiltros();
        }

        private void CargarInventario(string filtroTexto)
        {
            // Construir la consulta base
            string query = @"
                SELECT 
                    p.id_producto,
                    p.nombre_producto,
                    p.codigo_barras,
                    m.nombre_marca AS marca,
                    c.nombre_categoria AS categoria,
                    p.stock,
                    p.stock_minimo,
                    p.precio_compra,
                    p.precio_venta,
                    e.tipo_status AS estatus
                FROM productos p
                LEFT JOIN marcas m ON p.id_marca = m.id_marca
                LEFT JOIN categorias c ON p.id_categoria = c.id_categoria
                LEFT JOIN estatus e ON p.estatus = e.id_estatus
                WHERE 1=1
            ";

            var parametros = new Dictionary<string, object>();
            int contador = 0;

            // Filtro de texto (nombre o código)
            if (!string.IsNullOrWhiteSpace(filtroTexto))
            {
                query += " AND (p.nombre_producto LIKE @texto OR p.codigo_barras LIKE @texto)";
                parametros.Add("texto", $"%{filtroTexto}%");
            }

            // Filtro por categoría
            if (chkFiltrarCategoria.Checked && cmbCategoria.SelectedIndex != -1)
            {
                query += " AND p.id_categoria = @categoria";
                parametros.Add("categoria", cmbCategoria.SelectedValue);
            }

            // Filtro por marca
            if (chkFiltrarMarca.Checked && cmbMarca.SelectedIndex != -1)
            {
                query += " AND p.id_marca = @marca";
                parametros.Add("marca", cmbMarca.SelectedValue);
            }

            // Filtro por estado
            if (chkFiltrarEstado.Checked && cmbEstado.SelectedIndex != -1)
            {
                query += " AND p.estatus = @estado";
                parametros.Add("estado", cmbEstado.SelectedValue);
            }

            // Filtro por rango de stock
            if (chkFiltrarStock.Checked)
            {
                int min = (int)nudStockMin.Value;
                int max = (int)nudStockMax.Value;
                if (min > max)
                {
                    // Intercambiar si están invertidos
                    int temp = min;
                    min = max;
                    max = temp;
                }
                query += " AND p.stock BETWEEN @stockMin AND @stockMax";
                parametros.Add("stockMin", min);
                parametros.Add("stockMax", max);
            }

            query += " ORDER BY p.nombre_producto;";

            // Ejecutar consulta
            var parametrosArray = Utilbdd.CrearParametros(parametros);
            DataTable dt = Utilbdd.EjecutarConsulta(query, parametrosArray);
            dgvInventario.DataSource = dt;

            // Ocultar columna id_producto
            if (dgvInventario.Columns["id_producto"] != null)
                dgvInventario.Columns["id_producto"].Visible = false;

            // Actualizar etiqueta de resultados
            lblResultados.Text = $"Resultados: {dt.Rows.Count} producto(s)";
        }

        private void DgvInventario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvInventario.Rows.Count) return;

            DataGridViewRow row = dgvInventario.Rows[e.RowIndex];

            int stock = 0;
            int stockMinimo = 0;

            if (row.Cells["stock"].Value != DBNull.Value && row.Cells["stock"].Value != null)
                stock = Convert.ToInt32(row.Cells["stock"].Value);

            if (row.Cells["stock_minimo"].Value != DBNull.Value && row.Cells["stock_minimo"].Value != null)
                stockMinimo = Convert.ToInt32(row.Cells["stock_minimo"].Value);

            int umbralAmbar = (int)(stockMinimo * 1.3);

            if (stock <= stockMinimo)
            {
                row.DefaultCellStyle.BackColor = Color.Red;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
            else if (stock > stockMinimo && stock <= umbralAmbar)
            {
                row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
            else
            {
                row.DefaultCellStyle.BackColor = dgvInventario.DefaultCellStyle.BackColor;
                row.DefaultCellStyle.ForeColor = dgvInventario.DefaultCellStyle.ForeColor;
            }
        }

        private void DgvInventario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvInventario.Rows[e.RowIndex];
            int idProducto = Convert.ToInt32(row.Cells["id_producto"].Value);

            using (var detalle = new DetalleProducto(idProducto))
            {
                detalle.ShowDialog();
            }
            
            AplicarFiltros();
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            BotonesPersonalizados.EstiloBotonPildora(btnBuscar, "#98c1d9", 2, "#98c1d9");
            BotonesPersonalizados.EstiloBotonPildora(btnLimpiarFiltros, "#f4a261", 2, "#f4a261");
            lblResultados.Text = "Resultados: 0 producto(s)";
        }
    }
}