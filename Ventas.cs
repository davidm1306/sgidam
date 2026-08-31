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
        private bool _clienteCargado = false;
        public Ventas()
        {
            InitializeComponent();
            InitializeDataTable();
            CargarCombos();
            ConfigurarEventos();
            CalcularMontos();
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

            DataTable dtProductos = VentaHelper.ObtenerProductos();
            cmbProductoAgregar.DataSource = dtProductos;
            cmbProductoAgregar.DisplayMember = "nombre_producto";
            cmbProductoAgregar.ValueMember = "id_producto";
            cmbProductoAgregar.SelectedIndex = -1;
        }

        private void ConfigurarEventos()
        {
            txtNumDoc.KeyPress += Validaciones.SoloNumerosEnterosConCeroInicial;
            
            txtTelefonoCliente.KeyPress += Validaciones.SoloNumerosEnterosConCeroInicial;

            txtPrecioVentaUnitario.KeyPress += Validaciones.SoloNumerosYDecimales;

            
            txtNombreCliente.Leave += (s, e) => Validaciones.ConvertirAMayusculas(s, e);
            txtDireccionCliente.Leave += (s, e) => Validaciones.ConvertirAMayusculas(s, e);

            this.KeyPreview = true;
            this.KeyDown += (s, e) => { if (e.KeyCode == Keys.Escape) btnCancelar_Click(s, e); };

            _detallesTable.RowChanged += (s, e) => CalcularMontos();
            _detallesTable.RowDeleted += (s, e) => CalcularMontos();
            _detallesTable.TableCleared += (s, e) => CalcularMontos();

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
                CalcularMontos();
            }

        }

        private void CalcularMontos()
        {
            decimal subtotal = 0;
            foreach (DataRow row in _detallesTable.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                    subtotal += Convert.ToDecimal(row["subtotal"]);
            }

            decimal iva = subtotal * 0.16m; // 16%
            decimal total = subtotal + iva;

            txtSubTotal.Text = subtotal.ToString("N2");
            txtImpuestos.Text = iva.ToString("N2");
            txtTotal.Text = total.ToString("N2");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (_detallesTable.Rows.Count == 0)
            {
                MessageBox.Show("Agrega al menos un producto.", "Sin productos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (string.IsNullOrWhiteSpace(txtNumFactura.Text))
            {
                MessageBox.Show("Debes ingresar el número de factura.", "Dato faltante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumFactura.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNumControl.Text))
            {
                MessageBox.Show("Debes ingresar el número de control.", "Dato faltante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumControl.Focus();
                return;
            }


            string numDoc = txtNumDoc.Text.Trim();
            if (string.IsNullOrEmpty(numDoc))
            {
                MessageBox.Show("Debes ingresar el número de documento del cliente.", "Falta cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumDoc.Focus();
                return;
            }
            string tipo = cmbTipoDoc.SelectedItem?.ToString() ?? "V";
            string idCliente = tipo + numDoc;


            if (!_clienteCargado)
            {
                if (txtNombreCliente.Text.Trim().Length < 3)
                {
                    MessageBox.Show("El nombre debe tener al menos 3 caracteres.", "Nombre corto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreCliente.Focus();
                    return;
                }
                if (txtDireccionCliente.Text.Trim().Length < 3)
                {
                    MessageBox.Show("La dirección debe tener al menos 3 caracteres.", "Dirección corta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDireccionCliente.Focus();
                    return;
                }
                if (txtTelefonoCliente.Text.Trim().Length != 11 || !System.Text.RegularExpressions.Regex.IsMatch(txtTelefonoCliente.Text.Trim(), @"^\d+$"))
                {
                    MessageBox.Show("El teléfono debe tener 11 dígitos numéricos (incluyendo el 0 inicial).", "Teléfono inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTelefonoCliente.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtNombreCliente.Text) ||
                    string.IsNullOrWhiteSpace(txtDireccionCliente.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefonoCliente.Text))
                {
                    MessageBox.Show("Completa todos los datos del nuevo cliente.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (dtpFecha.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("La fecha no puede ser futura.", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFecha.Focus();
                return;
            }

            try
            {

                if (!_clienteCargado)
                {
                    bool insertado = VentaHelper.InsertarCliente(
                        idCliente,
                        txtNombreCliente.Text.Trim(),
                        txtDireccionCliente.Text.Trim(),
                        txtTelefonoCliente.Text.Trim()
                    );
                    if (!insertado)
                    {
                        MessageBox.Show("No se pudo registrar el cliente. Verifica que el RIF/C.I. no esté duplicado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }


                Venta venta = new Venta
                {
                    FechaVenta = dtpFecha.Value,
                    IdCliente = idCliente,
                    NumeroFactura = int.Parse(txtNumFactura.Text),
                    NumeroControl = txtNumControl.Text.Trim(),
                    SubTotal = decimal.Parse(txtSubTotal.Text),
                    Impuestos = decimal.Parse(txtImpuestos.Text),
                    TotalVenta = decimal.Parse(txtTotal.Text),
                    Estatus = 1,
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
                    MessageBox.Show("Venta registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dtpFecha.MinDate = new DateTime(2000, 1, 1);
            dtpFecha.MaxDate = DateTime.Now.Date;
            dtpFecha.Value = DateTime.Now.Date;

        }

        private void LimpiarDatosCliente()
        {
            txtNombreCliente.Clear();
            txtDireccionCliente.Clear();
            txtTelefonoCliente.Clear();
            txtNombreCliente.ReadOnly = true;
            txtDireccionCliente.ReadOnly = true;
            txtTelefonoCliente.ReadOnly = true;
            _clienteCargado = false;
        }
        private void txtNumDoc_Leave(object sender, EventArgs e)
        {
            string numDoc = txtNumDoc.Text.Trim();

            
            if (!string.IsNullOrEmpty(numDoc) && !System.Text.RegularExpressions.Regex.IsMatch(numDoc, @"^\d+$"))
            {
                MessageBox.Show("El número de documento solo debe contener dígitos.", "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumDoc.Focus();
                return;
            }

            string tipo = cmbTipoDoc.SelectedItem?.ToString() ?? "V";

            
            if (tipo == "V" && !string.IsNullOrEmpty(numDoc))
            {
                if (!long.TryParse(numDoc, out long numero))
                {
                    MessageBox.Show("Número inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNumDoc.Focus();
                    return;
                }

                if (numero < 1000000)
                {
                    MessageBox.Show("No se pueden ingresar cédulas tan bajas. El mínimo es 1,000,000.",
                                    "Cédula muy corta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNumDoc.Focus();
                    return;
                }

                if (numero > 50000000)
                {
                    MessageBox.Show("La cédula puede contener solo 7 dígitos o el número es muy alto. Máximo 50,000,000.",
                                    "Cédula muy larga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNumDoc.Focus();
                    return;
                }
            }

            string idCompleto = tipo + numDoc;
            if (string.IsNullOrEmpty(numDoc))
            {
                LimpiarDatosCliente();
                return;
            }

            
            DataRow cliente = VentaHelper.ObtenerClientePorId(idCompleto);
            if (cliente != null)
            {
                txtNombreCliente.Text = cliente["nombre_cliente"].ToString();
                txtDireccionCliente.Text = cliente["direccion_cliente"].ToString();
                txtTelefonoCliente.Text = cliente["telefono_cliente"].ToString();
                txtNombreCliente.ReadOnly = true;
                txtDireccionCliente.ReadOnly = true;
                txtTelefonoCliente.ReadOnly = true;
                _clienteCargado = true;
            }
            else
            {
                LimpiarDatosCliente();
                txtNombreCliente.ReadOnly = false;
                txtDireccionCliente.ReadOnly = false;
                txtTelefonoCliente.ReadOnly = false;
                _clienteCargado = false;
                MessageBox.Show("Cliente no encontrado. Completa los datos para registrarlo.", "Nuevo Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNumDoc.Clear();
            LimpiarDatosCliente();
            txtNumDoc.Focus();
        }

        private void txtNumFactura_Leave(object sender, EventArgs e)
        {
            if (!int.TryParse(txtNumFactura.Text, out _))
            {
                MessageBox.Show("El número de factura debe ser un valor numérico.", "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumFactura.Focus();
            }
        }

        private void txtTelefonoCliente_Leave(object sender, EventArgs e)
        {
            string telefono = txtTelefonoCliente.Text.Trim();

            if (string.IsNullOrEmpty(telefono))
                return;

            if (!System.Text.RegularExpressions.Regex.IsMatch(telefono, @"^\d+$"))
            {
                MessageBox.Show("El teléfono solo debe contener dígitos.", "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefonoCliente.Focus();
                return;
            }

            if (telefono.Length != 11)
            {
                MessageBox.Show("El teléfono debe tener exactamente 11 dígitos (incluyendo el 0 inicial si aplica).", "Longitud incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefonoCliente.Focus();
                return;
            }
        }

        private void txtNombreCliente_Leave(object sender, EventArgs e)
        {
            string nombre = txtNombreCliente.Text.Trim();
            if (!string.IsNullOrEmpty(nombre) && nombre.Length < 3)
            {
                MessageBox.Show("El nombre del cliente debe tener al menos 3 caracteres.", "Nombre corto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCliente.Focus();
            }
        }

        private void txtDireccionCliente_Leave(object sender, EventArgs e)
        {
            string direccion = txtDireccionCliente.Text.Trim();
            if (!string.IsNullOrEmpty(direccion) && direccion.Length < 3)
            {
                MessageBox.Show("La dirección debe tener al menos 3 caracteres.", "Dirección corta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccionCliente.Focus();
            }
        }

        private void btnLimpiarCliente_Click(object sender, EventArgs e)
        {
            txtNumDoc.Clear();
            txtNombreCliente.Clear();
            txtDireccionCliente.Clear();
            txtTelefonoCliente.Clear();
            _clienteCargado = false;
            txtNombreCliente.ReadOnly = false;
            txtDireccionCliente.ReadOnly = false;
            txtTelefonoCliente.ReadOnly = false;
            txtNumDoc.Focus();
        }
    }
}
