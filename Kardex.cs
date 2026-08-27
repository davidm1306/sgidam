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
using sgidam.Models;


namespace sgidam
{
    public partial class Kardex : Form
    {
        public Kardex()
        {
            InitializeComponent();
            CargarProductos();
            ConfigurarColumnasGrid();
        }

        private void CargarProductos()
        {
            DataTable dt = VentaHelper.ObtenerProductos();
            cmbProducto.DataSource = dt;
            cmbProducto.DisplayMember = "nombre_producto";
            cmbProducto.ValueMember = "id_producto";
            cmbProducto.SelectedIndex = -1;
        }

        private void ConfigurarColumnasGrid()
        {
            dgvKardex.AutoGenerateColumns = false;
            dgvKardex.Columns.Clear();

            dgvKardex.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "fecha_movimiento",
                HeaderText = "Fecha",
                DataPropertyName = "fecha_movimiento",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm:ss" },
                Width = 150
            });

            dgvKardex.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "tipo",
                HeaderText = "Tipo",
                DataPropertyName = "tipo",
                Width = 100
            });

            dgvKardex.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "cantidad",
                HeaderText = "Cantidad",
                DataPropertyName = "cantidad",
                Width = 80
            });

            dgvKardex.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "costo_unitario",
                HeaderText = "Costo Unit.",
                DataPropertyName = "costo_unitario",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "$#,##0.00" },
                Width = 100
            });

            dgvKardex.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "saldo_acumulado",
                HeaderText = "Saldo (unidades)",
                DataPropertyName = "saldo_acumulado",
                Width = 100
            });

           
            dgvKardex.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "codigo_lote",
                HeaderText = "Lote",
                DataPropertyName = "codigo_lote",
                Width = 100
            });
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbProducto.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecciona un producto.", "Falta producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idProducto = (int)cmbProducto.SelectedValue;
                DateTime fechaDesde = dtpDesde.Value.Date;
                DateTime fechaHasta = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1);

                
                string query = @"
                    SELECT 
                        k.fecha_movimiento,
                        tm.nombre_movimiento AS tipo,
                        k.cantidad,
                        k.costo_unitario,
                        CASE 
                            WHEN tm.nombre_movimiento IN ('COMPRA', 'AJUSTE SUMA', 'DEVOLUCION') THEN k.cantidad
                            WHEN tm.nombre_movimiento IN ('VENTA', 'AJUSTE RESTA') THEN -k.cantidad
                            ELSE 0
                        END AS cantidad_efectiva,
                        CASE 
                            WHEN tm.nombre_movimiento = 'COMPRA' THEN (SELECT codigo_lote FROM lotes WHERE id_detalle_compra = k.id_detalle_compra LIMIT 1)
                            WHEN tm.nombre_movimiento = 'DEVOLUCION' THEN (SELECT l.codigo_lote FROM devoluciones_detalle dd JOIN lotes l ON dd.id_lote_creado = l.id_lote WHERE dd.id_devolucion = k.id_devolucion LIMIT 1)
                            ELSE NULL
                        END AS codigo_lote
                    FROM kardex k
                    INNER JOIN tipos_movimiento tm ON k.tipo_movimiento = tm.id_tipo
                    WHERE k.id_producto = @idProducto
                    ORDER BY k.fecha_movimiento ASC, k.id_kardex ASC;
                ";

                var parametros = Utilbdd.CrearParametros(new Dictionary<string, object>
                {
                    { "idProducto", idProducto }
                });

                DataTable dt = Utilbdd.EjecutarConsulta(query, parametros);

              
                DataTable dtFiltrado = new DataTable();
                dtFiltrado.Columns.Add("fecha_movimiento", typeof(DateTime));
                dtFiltrado.Columns.Add("tipo", typeof(string));
                dtFiltrado.Columns.Add("cantidad", typeof(int));
                dtFiltrado.Columns.Add("costo_unitario", typeof(decimal));
                dtFiltrado.Columns.Add("saldo_acumulado", typeof(decimal));
                dtFiltrado.Columns.Add("codigo_lote", typeof(string));

                decimal saldo = 0;
                foreach (DataRow row in dt.Rows)
                {
                    DateTime fechaMov = Convert.ToDateTime(row["fecha_movimiento"]);
                    decimal cantidadEfectiva = Convert.ToDecimal(row["cantidad_efectiva"]);
                    saldo += cantidadEfectiva;

                    
                    if (fechaMov >= fechaDesde && fechaMov <= fechaHasta)
                    {
                        DataRow newRow = dtFiltrado.NewRow();
                        newRow["fecha_movimiento"] = fechaMov;
                        newRow["tipo"] = row["tipo"];
                        newRow["cantidad"] = row["cantidad"];
                        newRow["costo_unitario"] = row["costo_unitario"];
                        newRow["saldo_acumulado"] = saldo;
                        newRow["codigo_lote"] = row["codigo_lote"] != DBNull.Value ? row["codigo_lote"].ToString() : "";
                        dtFiltrado.Rows.Add(newRow);
                    }
                }

                dgvKardex.DataSource = dtFiltrado;

                MostrarResumenProducto(idProducto);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar Kardex: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarResumenProducto(int idProducto)
        {
            string query = "SELECT stock, precio_compra FROM productos WHERE id_producto = @id";
            var param = Utilbdd.CrearParametros(new Dictionary<string, object> { { "id", idProducto } });
            DataTable dt = Utilbdd.EjecutarConsulta(query, param);
            if (dt.Rows.Count > 0)
            {
                txtStockActual.Text = dt.Rows[0]["stock"].ToString();
                decimal precio = Convert.ToDecimal(dt.Rows[0]["precio_compra"]);
                txtCostoPromedio.Text = $"${precio.ToString("$#,##0.00")}";
            }
        }

        private void Kardex_Load(object sender, EventArgs e)
        {
            BotonesPersonalizados.EstiloBotonPildora(btnConsultar, "#98c1d9", 2, "#98c1d9");
        }
    }
}