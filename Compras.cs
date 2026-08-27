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
    public partial class Compras : Form
    {
        private DataTable _detallesTable;

        public Compras()
        {
            InitializeComponent();
            InitializeDataTable();
            CargarCombos();
            ConfigurarEventos();
            CalcularTotal();

            txtCostoUnitario.KeyPress += SoloNumerosYDecimales;
        }


        private void InitializeDataTable()
        {
            _detallesTable = new DataTable();
            _detallesTable.Columns.Add("id_producto", typeof(int));
            _detallesTable.Columns.Add("nombre_producto", typeof(string));
            _detallesTable.Columns.Add("cantidad", typeof(int));
            _detallesTable.Columns.Add("costo_unitario", typeof(decimal));
            _detallesTable.Columns.Add("subtotal", typeof(decimal), "cantidad * costo_unitario");

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
            if (dgvDetalles.Columns["costo_unitario"] != null)
                dgvDetalles.Columns["costo_unitario"].HeaderText = "Costo Unit.";
            if (dgvDetalles.Columns["subtotal"] != null)
                dgvDetalles.Columns["subtotal"].HeaderText = "Subtotal";


            foreach (DataGridViewColumn col in dgvDetalles.Columns)
            {
                if (col.Name != "id_producto")
                    col.ReadOnly = true;
            }

            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.Name = "Editar";
            btnEditar.HeaderText = "Editar";
            btnEditar.Text = "✏️";
            btnEditar.UseColumnTextForButtonValue = true;
            btnEditar.Width = 60;
            dgvDetalles.Columns.Add(btnEditar);

        }


        private void CargarCombos()
        {

            DataTable dtProveedores = CompraHelper.ObtenerProveedores();
            cmbProveedor.DataSource = dtProveedores;
            cmbProveedor.DisplayMember = "nombre_proveedor";
            cmbProveedor.ValueMember = "id_proveedor";
            cmbProveedor.SelectedIndex = -1;

        }


        private void ConfigurarEventos()
        {


            this.KeyPreview = true;
            this.KeyDown += Compras_KeyDown;


            _detallesTable.RowChanged += (s, e) => CalcularTotal();
            _detallesTable.RowDeleted += (s, e) => CalcularTotal();
            _detallesTable.TableCleared += (s, e) => CalcularTotal();

            cmbProductoAgregar.SelectedIndexChanged += cmbProductoAgregar_SelectedIndexChanged;
            cmbProveedor.SelectedIndexChanged += cmbProveedor_SelectedIndexChanged;


        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProveedor.SelectedIndex == -1)
            {

                cmbProductoAgregar.DataSource = null;
                txtCostoUnitario.Text = "";
                return;
            }

            string idProveedor = cmbProveedor.SelectedValue.ToString();
            DataTable dtProductos = CompraHelper.ObtenerProductosPorProveedor(idProveedor);

            cmbProductoAgregar.DataSource = dtProductos;
            cmbProductoAgregar.DisplayMember = "nombre_producto";
            cmbProductoAgregar.ValueMember = "id_producto";
            cmbProductoAgregar.SelectedIndex = -1;
            txtCostoUnitario.Text = "";
        }

        private void cmbProductoAgregar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProveedor.SelectedIndex == -1 || cmbProductoAgregar.SelectedIndex == -1)
            {
                txtCostoUnitario.Text = "";
                lblStockActual.Text = ""; 
                return;
            }

            DataTable dt = cmbProductoAgregar.DataSource as DataTable;
            if (dt == null)
            {
                txtCostoUnitario.Text = "";
                lblStockActual.Text = "";
                return;
            }

            DataRowView rowView = cmbProductoAgregar.SelectedItem as DataRowView;
            if (rowView == null)
            {
                txtCostoUnitario.Text = "";
                lblStockActual.Text = "";
                return;
            }

            decimal precio = Convert.ToDecimal(rowView["precio_proveedor"]);
            txtCostoUnitario.Text = precio.ToString("F2");

            if (cmbProductoAgregar.SelectedIndex != -1)
            {
                int idProducto = (int)cmbProductoAgregar.SelectedValue;
                string queryStock = "SELECT stock FROM productos WHERE id_producto = @id";
                var paramStock = Utilbdd.CrearParametros(new Dictionary<string, object> { { "id", idProducto } });
                DataTable dtStock = Utilbdd.EjecutarConsulta(queryStock, paramStock);
                if (dtStock.Rows.Count > 0)
                {
                    int stock = Convert.ToInt32(dtStock.Rows[0]["stock"]);
                    lblStockActual.Text = $"Stock actual: {stock}";
                }
                else
                {
                    lblStockActual.Text = "Stock actual: 0";
                }

                
                string queryMax = "SELECT costo_historico_maximo FROM productos WHERE id_producto = @id";
                var paramMax = Utilbdd.CrearParametros(new Dictionary<string, object> { { "id", idProducto } });
                DataTable dtMax = Utilbdd.EjecutarConsulta(queryMax, paramMax);
                decimal costoMaximo = 0;
                if (dtMax.Rows.Count > 0 && dtMax.Rows[0]["costo_historico_maximo"] != DBNull.Value)
                {
                    costoMaximo = Convert.ToDecimal(dtMax.Rows[0]["costo_historico_maximo"]);
                    txtCostoUnitario.Text = costoMaximo.ToString("F2");
                }
                else
                {
                    txtCostoUnitario.Text = "";
                }
            }

            if (cmbProductoAgregar.SelectedIndex != -1)
            {
                int idProducto = (int)cmbProductoAgregar.SelectedValue;
                string queryMax = "SELECT costo_historico_maximo FROM productos WHERE id_producto = @id";
                var paramMax = Utilbdd.CrearParametros(new Dictionary<string, object> { { "id", idProducto } });
                DataTable dtMax = Utilbdd.EjecutarConsulta(queryMax, paramMax);
                if (dtMax.Rows.Count > 0 && dtMax.Rows[0]["costo_historico_maximo"] != DBNull.Value)
                {
                    decimal costoMax = Convert.ToDecimal(dtMax.Rows[0]["costo_historico_maximo"]);                    
                }
               
            }
        }

        private void SoloNumerosYDecimales(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
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
            decimal costoUnitario;

            if (!decimal.TryParse(txtCostoUnitario.Text, out costoUnitario) || costoUnitario <= 0)
            {
                MessageBox.Show("Ingresa un costo unitario válido (mayor a 0).", "Valor inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCostoUnitario.Focus();
                return;
            }


            if (_detallesTable.AsEnumerable().Any(r => r.Field<int>("id_producto") == idProducto))
            {
                MessageBox.Show("Este producto ya está agregado. Si deseas modificar la cantidad, elimínalo y vuelve a agregarlo.",
                                "Producto duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string codigoLote = txtCodigoLote.Text.Trim();

            if (string.IsNullOrEmpty(codigoLote))
            {
                codigoLote = $"LOTE-{idProducto}-{DateTime.Now:yyyyMMddHHmmss}";
                txtCodigoLote.Text = codigoLote;
            }



            if (!string.IsNullOrEmpty(codigoLote))
            {
                bool loteDuplicado = _detallesTable.AsEnumerable()
                    .Any(r => r.Field<int>("id_producto") == idProducto &&
                              r.Field<string>("codigo_lote") == codigoLote);
                if (loteDuplicado)
                {
                    MessageBox.Show($"Ya existe el lote '{codigoLote}' para este producto en la compra actual.",
                                    "Lote duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodigoLote.Focus();
                    txtCodigoLote.SelectAll();
                    return;
                }
            }


            DataRow newRow = _detallesTable.NewRow();
            newRow["id_producto"] = idProducto;
            newRow["nombre_producto"] = nombreProducto;
            newRow["cantidad"] = cantidad;
            newRow["costo_unitario"] = costoUnitario;

            if (!_detallesTable.Columns.Contains("codigo_lote"))
            {
                _detallesTable.Columns.Add("codigo_lote", typeof(string));
                // La ocultamos en el DataGridView
                if (dgvDetalles.Columns["codigo_lote"] != null)
                    dgvDetalles.Columns["codigo_lote"].Visible = false;
            }
            newRow["codigo_lote"] = codigoLote;

            _detallesTable.Rows.Add(newRow);


            cmbProductoAgregar.SelectedIndex = -1;
            nudCantidad.Value = 1;
            txtCostoUnitario.Clear();
            txtCodigoLote.Clear();
        }

        private void DgvDetalles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDetalles.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                _detallesTable.Rows[e.RowIndex].Delete();
                CalcularTotal();
            }
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (DataRow row in _detallesTable.Rows)
            {
                total += Convert.ToDecimal(row["Subtotal"]);
            }
            txtTotal.Text = total.ToString("N2");
        }

        private bool ValidarCampos()
        {

            if (cmbProveedor.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un proveedor.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProveedor.Focus();
                return false;
            }


            if (_detallesTable.Rows.Count == 0)
            {
                MessageBox.Show("Agrega al menos un producto a la compra.", "Sin detalles", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            DialogResult resultado = MessageBox.Show("¿Estás seguro de guardar esta compra?", "Confirmar guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.No)
                return;

            try
            {

                Compra nuevaCompra = new Compra
                {
                    IdProveedor = cmbProveedor.SelectedValue.ToString(),
                    FechaCompra = dtpFecha.Value,
                    TotalCompra = decimal.Parse(txtTotal.Text),
                    Estatus = 1,
                    IdUsuario = Global.UsuarioSesion.id_usuario
                };


                foreach (DataRow row in _detallesTable.Rows)
                {

                    string codigoLote = row.Table.Columns.Contains("codigo_lote")
                        ? row["codigo_lote"]?.ToString()
                        : null;

                    nuevaCompra.Detalles.Add(new DetalleCompra
                    {
                        IdProducto = (int)row["id_producto"],
                        Cantidad = (int)row["cantidad"],
                        CostoUnitario = (decimal)row["costo_unitario"],
                        CodigoLote = codigoLote 
                    });
                }


                bool exito = CompraHelper.RegistrarCompra(nuevaCompra);

                if (exito)
                {
                    MessageBox.Show("Compra registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la compra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Compras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancelar_Click(sender, e);
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Compras_Load(object sender, EventArgs e)
        {
            BotonesPersonalizados.EstiloBotonPildora(btnAgregar, "#98c1d9", 2, "#98c1d9");
            BotonesPersonalizados.EstiloBotonPildora(btnCancelar, "#bc4749", 2, "#bc4749");
            BotonesPersonalizados.EstiloBotonPildora(btnEliminar, "#bc4749", 2, "#bc4749");
            BotonesPersonalizados.EstiloBotonPildora(btnGuardar, "#98c1d9", 2, "#98c1d9");
            BotonesPersonalizados.EstiloBotonPildora(btnLimpiar, "#f4a261", 2, "#f4a261");
            BotonesPersonalizados.EstiloBotonPildora(btnVerLotes, "#98c1d9", 2, "#98c1d9");

            dtpFecha.MinDate = new DateTime(2000, 1, 1);
            dtpFecha.MaxDate = DateTime.Now.Date;
            dtpFecha.Value = DateTime.Now.Date;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

            _detallesTable.Clear();


            cmbProveedor.SelectedIndex = -1;
            cmbProductoAgregar.DataSource = null;


            txtCostoUnitario.Clear();
            txtCodigoLote.Clear();
            nudCantidad.Value = 1;
            txtTotal.Text = "0.00";


            dtpFecha.Value = DateTime.Now.Date;


            cmbProveedor.Focus();
        }

        private void btnVerLotes_Click(object sender, EventArgs e)
        {
            if (cmbProductoAgregar.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un producto para ver sus lotes.", "Sin producto",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProducto = (int)cmbProductoAgregar.SelectedValue;
            string query = @"
                SELECT codigo_lote, cantidad_disponible, costo_unitario, fecha_entrada
                FROM lotes
                WHERE id_producto = @idProducto AND cantidad_disponible > 0
                ORDER BY fecha_entrada ASC
            ";
            var param = Utilbdd.CrearParametros(new Dictionary<string, object> { { "idProducto", idProducto } });
            DataTable dt = Utilbdd.EjecutarConsulta(query, param);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No hay lotes disponibles para este producto.", "Sin lotes",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            string mensaje = "Lotes disponibles:\n\n";
            foreach (DataRow row in dt.Rows)
            {
                mensaje += $"Lote: {row["codigo_lote"]} | Stock: {row["cantidad_disponible"]} | Costo: {row["costo_unitario"]:C2}\n";
            }
            MessageBox.Show(mensaje, "Lotes del producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}