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
    public partial class Ventas : Form
    {
        private DataTable _detallesTable;
        public Ventas()
        {
            InitializeComponent();
            InitializeDataTable();
            CargarCombos();
            ConfigurarEventos();
            CalcularTotal();
        }

        private void InitializeDataTable()
        {
            _detallesTable = new DataTable();
            _detallesTable.Columns.Add("id_producto", typeof(int));
            _detallesTable.Columns.Add("nombre_producto", typeof(string));
            _detallesTable.Columns.Add("cantidad", typeof(int));
            _detallesTable.Columns.Add("precio_unitario", typeof(decimal));
            _detallesTable.Columns.Add("subtotal", typeof(decimal), "cantidad * precio_unitario");

            dgvDetalles.DataSource = _detallesTable;
            ConfigurarColumnasGrid();
        }

        private void ConfigurarColumnasGrid()
        {
            if (dgvDetalles.Columns["id_producto"] != null)
                dgvDetalles.Columns["id_producto"].Visible = false;

            if (dgvDetalles.Columns["nombre_producto"] != null)
                dgvDetalles.Columns["nombre_producto"].HeaderText = "Producto";
            if (dgvDetalles.Columns["cantidad"] != null)
                dgvDetalles.Columns["cantidad"].HeaderText = "Cantidad";
            if (dgvDetalles.Columns["precio_unitario"] != null)
                dgvDetalles.Columns["precio_unitario"].HeaderText = "Precio Unit.";
            if (dgvDetalles.Columns["subtotal"] != null)
                dgvDetalles.Columns["subtotal"].HeaderText = "Subtotal";

            foreach (DataGridViewColumn col in dgvDetalles.Columns)
                col.ReadOnly = true;
        }

        private void CargarCombos()
        {

            DataTable dtEstatus = VentaHelper.ObtenerEstatus();
            cmbEstatus.DataSource = dtEstatus;
            cmbEstatus.DisplayMember = "tipo_status";
            cmbEstatus.ValueMember = "id_estatus";
            cmbEstatus.SelectedIndex = 0;


            DataTable dtProductos = VentaHelper.ObtenerProductos();
            cmbProductoAgregar.DataSource = dtProductos;
            cmbProductoAgregar.DisplayMember = "nombre_producto";
            cmbProductoAgregar.ValueMember = "id_producto";
            cmbProductoAgregar.SelectedIndex = -1;
        }

        private void ConfigurarEventos()
        {
            // Los eventos de botones se asignan en el diseñador, no aquí.
            // Solo eventos adicionales (KeyDown, cambios en tabla).
            this.KeyPreview = true;
            this.KeyDown += (s, e) => { if (e.KeyCode == Keys.Escape) btnCancelar_Click(s, e); };

            _detallesTable.RowChanged += (s, e) => CalcularTotal();
            _detallesTable.RowDeleted += (s, e) => CalcularTotal();
            _detallesTable.TableCleared += (s, e) => CalcularTotal();

            // Cuando el usuario selecciona un producto, autocompletar el precio de venta
            cmbProductoAgregar.SelectedIndexChanged += (s, e) =>
            {
                if (cmbProductoAgregar.SelectedIndex != -1)
                {
                    DataRowView row = (DataRowView)cmbProductoAgregar.SelectedItem;
                    decimal precioVenta = Convert.ToDecimal(row["precio_venta"]);
                    txtPrecioVentaUnitario.Text = precioVenta.ToString("N2");
                }
            };
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            {
                if (cmbProductoAgregar.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecciona un producto.", "Falta producto",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idProducto = (int)cmbProductoAgregar.SelectedValue;
                string nombreProducto = cmbProductoAgregar.Text;
                int cantidad = (int)nudCantidad.Value;
                decimal precioUnitario;

                if (!decimal.TryParse(txtPrecioVentaUnitario.Text, out precioUnitario) || precioUnitario <= 0)
                {
                    MessageBox.Show("Ingresa un precio unitario válido (mayor a 0).", "Valor inválido",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPrecioVentaUnitario.Focus();
                    return;
                }


                int stockDisponible = ObtenerStockProducto(idProducto);
                if (cantidad > stockDisponible)
                {
                    MessageBox.Show($"Stock insuficiente. Disponible: {stockDisponible}", "Stock bajo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudCantidad.Focus();
                    return;
                }


                if (_detallesTable.AsEnumerable().Any(r => r.Field<int>("id_producto") == idProducto))
                {
                    MessageBox.Show("Este producto ya está agregado. Elimínalo si quieres cambiar la cantidad.",
                                    "Producto duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataRow newRow = _detallesTable.NewRow();
                newRow["id_producto"] = idProducto;
                newRow["nombre_producto"] = nombreProducto;
                newRow["cantidad"] = cantidad;
                newRow["precio_unitario"] = precioUnitario;
                _detallesTable.Rows.Add(newRow);


                cmbProductoAgregar.SelectedIndex = -1;
                nudCantidad.Value = 1;
                txtPrecioVentaUnitario.Clear();
            }
        }

        private int ObtenerStockProducto(int idProducto)
        {
            string query = "SELECT stock FROM productos WHERE id_producto = @id";
            var param = Utilbdd.CrearParametros(new Dictionary<string, object> { { "id", idProducto } });
            DataTable dt = Utilbdd.EjecutarConsulta(query, param);
            if (dt.Rows.Count == 0) return 0;
            return Convert.ToInt32(dt.Rows[0]["stock"]);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (dgvDetalles.CurrentRow == null) return;
            int rowIndex = dgvDetalles.CurrentRow.Index;
            if (rowIndex >= 0 && rowIndex < _detallesTable.Rows.Count)
            {
                _detallesTable.Rows[rowIndex].Delete();
                CalcularTotal();
            }

        }

        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (DataRow row in _detallesTable.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                    total += Convert.ToDecimal(row["subtotal"]);
            }
            txtTotal.Text = total.ToString("N2");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            {
                if (_detallesTable.Rows.Count == 0)
                {
                    MessageBox.Show("Agrega al menos un producto.", "Sin productos",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    Venta venta = new Venta
                    {
                        FechaVenta = dtpFecha.Value,
                        TotalVenta = decimal.Parse(txtTotal.Text),
                        Estatus = (int)cmbEstatus.SelectedValue,
                        Detalles = new List<DetalleVenta>()
                    };

                    foreach (DataRow row in _detallesTable.Rows)
                    {
                        if (row.RowState != DataRowState.Deleted)
                        {
                            venta.Detalles.Add(new DetalleVenta
                            {
                                IdProducto = Convert.ToInt32(row["id_producto"]),
                                Cantidad = Convert.ToInt32(row["cantidad"]),
                                PrecioUnitarioVenta = Convert.ToDecimal(row["precio_unitario"])
                            });
                        }
                    }

                    bool exito = VentaHelper.RegistrarVenta(venta);

                    if (exito)
                    {
                        MessageBox.Show("Venta registrada con éxito.", "Éxito",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al registrar la venta.", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            BotonesPersonalizados.EstiloBotonPildora(btnAgregar, "#98c1d9", 2, "#98c1d9");
            BotonesPersonalizados.EstiloBotonPildora(btnCancelar, "#bc4749", 2, "#bc4749");
            BotonesPersonalizados.EstiloBotonPildora(btnEliminar, "#bc4749", 2, "#bc4749");
            BotonesPersonalizados.EstiloBotonPildora(btnGuardar, "#98c1d9", 2, "#98c1d9");

        }
    }
}
