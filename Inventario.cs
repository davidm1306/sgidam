using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sgidam.Data;

namespace sgidam
{
    public partial class Inventario : Form
    {
        public Inventario()
        {
            InitializeComponent();
            CargarInventario("");
            dgvInventario.CellFormatting += DgvInventario_CellFormatting;
            dgvInventario.CellDoubleClick += DgvInventario_CellDoubleClick;
            dgvInventario.AllowUserToAddRows = false;
        }

        private void CargarInventario(string filtro)
        {
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
                WHERE p.nombre_producto LIKE @filtro OR p.codigo_barras LIKE @filtro
                ORDER BY p.nombre_producto;
            ";

            var parametros = Utilbdd.CrearParametros(new Dictionary<string, object>
            {
                { "filtro", $"%{filtro}%" }
            });

            DataTable dt = Utilbdd.EjecutarConsulta(query, parametros);
            dgvInventario.DataSource = dt;


            if (dgvInventario.Columns["id_producto"] != null)
                dgvInventario.Columns["id_producto"].Visible = false;
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

            
            int umbralAmbar = (int)(stockMinimo * 1.3); // 30% por encima del mínimo

            
            if (stock <= stockMinimo)
            {
                
                row.DefaultCellStyle.BackColor = Color.LightCoral;
                row.DefaultCellStyle.ForeColor = Color.Black; // Para legibilidad
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
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnBuscar_Click(sender, e);
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarInventario(txtBuscar.Text.Trim());
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            BotonesPersonalizados.EstiloBotonPildora(btnBuscar, "#98c1d9", 2, "#98c1d9");
        }
    }
}
