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
                DateTime fechaDesde = dtpDesde.Value.Date; // Solo fecha, sin hora
                DateTime fechaHasta = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1); // Hasta el final del día

                // Consulta TODOS los movimientos del producto (sin filtro de fecha)
                string query = @"
                    SELECT 
                        k.fecha_movimiento,
                        tm.nombre_movimiento AS tipo,
                        k.cantidad,
                        k.costo_unitario,
                        CASE 
                            WHEN tm.nombre_movimiento IN ('COMPRA', 'AJUSTE SUMA') THEN k.cantidad
                            WHEN tm.nombre_movimiento IN ('VENTA', 'AJUSTE RESTA') THEN -k.cantidad
                            ELSE 0
                        END AS cantidad_efectiva
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

                // Crear una nueva tabla con los movimientos filtrados por fecha + saldo acumulado
                DataTable dtFiltrado = new DataTable();
                dtFiltrado.Columns.Add("fecha_movimiento", typeof(DateTime));
                dtFiltrado.Columns.Add("tipo", typeof(string));
                dtFiltrado.Columns.Add("cantidad", typeof(int));
                dtFiltrado.Columns.Add("costo_unitario", typeof(decimal));
                dtFiltrado.Columns.Add("saldo_acumulado", typeof(decimal));

                decimal saldo = 0;
                foreach (DataRow row in dt.Rows)
                {
                    DateTime fechaMov = Convert.ToDateTime(row["fecha_movimiento"]);
                    decimal cantidadEfectiva = Convert.ToDecimal(row["cantidad_efectiva"]);
                    saldo += cantidadEfectiva; // Suma al saldo total (todos los movimientos)

                    // Si el movimiento está en el rango de fechas, lo mostramos
                    if (fechaMov >= fechaDesde && fechaMov <= fechaHasta)
                    {
                        DataRow newRow = dtFiltrado.NewRow();
                        newRow["fecha_movimiento"] = fechaMov;
                        newRow["tipo"] = row["tipo"];
                        newRow["cantidad"] = row["cantidad"];
                        newRow["costo_unitario"] = row["costo_unitario"];
                        newRow["saldo_acumulado"] = saldo; // Saldo acumulado real
                        dtFiltrado.Rows.Add(newRow);
                    }
                }

                // Asignar al DataGridView
                dgvKardex.DataSource = dtFiltrado;

                // Mostrar resumen
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
            var param = Utilbdd.CrearParametros(new System.Collections.Generic.Dictionary<string, object> { { "id", idProducto } });
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