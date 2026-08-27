using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using sgidam.Data;
using sgidam.Models;

namespace sgidam
{
    public partial class Devoluciones : Form
    {
        private DataTable _facturasTable;
        private int _idVentaSeleccionada;
        private string _numeroFactura;

        public Devoluciones()
        {
            InitializeComponent();
            ConfigurarColumnasFacturas();
            ConfigurarColumnasDetalles();
            CargarUsuarios();
            ConfigurarEventosFiltros();
            ConfigurarEventosGrid();
            CargarFacturas();
        }

        // Configurar eventos de los filtros
        private void ConfigurarEventosFiltros()
        {
            // CheckBoxes
            chkNumControl.CheckedChanged += Filtro_CheckedChanged;
            chkFechas.CheckedChanged += Filtro_CheckedChanged;
            chkUsuario.CheckedChanged += Filtro_CheckedChanged;

            // TextBox de número de control (solo si el checkbox está marcado)
            txtNumControl.TextChanged += (s, e) => { if (chkNumControl.Checked) CargarFacturas(); };

            // Fechas (solo si el checkbox está marcado)
            dtpDesde.ValueChanged += (s, e) => { if (chkFechas.Checked) CargarFacturas(); };
            dtpHasta.ValueChanged += (s, e) => { if (chkFechas.Checked) CargarFacturas(); };

            // ComboBox de usuario (solo si el checkbox está marcado)
            cmbUsuario.SelectedIndexChanged += (s, e) => { if (chkUsuario.Checked) CargarFacturas(); };

            // Búsqueda en tiempo real (siempre activa)
            txtBuscar.TextChanged += (s, e) => CargarFacturas();
        }

        // Configurar eventos del DataGridView de facturas
        private void ConfigurarEventosGrid()
        {
            // Usamos SelectionChanged en lugar de CellClick para mayor confiabilidad
            dgvFacturas.SelectionChanged += dgvFacturas_SelectionChanged;
        }

        private void CargarUsuarios()
        {
            DataTable dtUsuarios = VentaHelper.ObtenerUsuarios();
            DataRow row = dtUsuarios.NewRow();
            row["id_usuario"] = 0;
            row["nombre_usuario"] = "Todos";
            dtUsuarios.Rows.InsertAt(row, 0);
            cmbUsuario.DataSource = dtUsuarios;
            cmbUsuario.DisplayMember = "nombre_usuario";
            cmbUsuario.ValueMember = "id_usuario";
            cmbUsuario.SelectedValue = 0;
            cmbUsuario.Enabled = false; // Inicialmente deshabilitado
        }

        private void ConfigurarColumnasFacturas()
        {
            dgvFacturas.AutoGenerateColumns = false;
            dgvFacturas.Columns.Clear();
            dgvFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFacturas.MultiSelect = false;
            dgvFacturas.ReadOnly = true;

            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id_venta",
                HeaderText = "ID",
                DataPropertyName = "id_venta",
                Visible = false
            });
            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "numero_factura",
                HeaderText = "N° Factura",
                DataPropertyName = "numero_factura",
                Width = 100
            });
            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "fecha_venta",
                HeaderText = "Fecha",
                DataPropertyName = "fecha_venta",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                Width = 120
            });
            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "cliente",
                HeaderText = "Cliente",
                DataPropertyName = "cliente",
                Width = 200
            });
            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "total_venta",
                HeaderText = "Total",
                DataPropertyName = "total_venta",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "$#,##0.00" },
                Width = 100
            });
            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "numero_control",
                HeaderText = "N° Control",
                DataPropertyName = "numero_control",
                Width = 120
            });
            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "usuario",
                HeaderText = "Usuario",
                DataPropertyName = "usuario",
                Width = 150
            });
        }

        private void ConfigurarColumnasDetalles()
        {
            dgvDetalles.AutoGenerateColumns = false;
            dgvDetalles.Columns.Clear();

            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id_producto",
                HeaderText = "ID Producto",
                DataPropertyName = "id_producto",
                Visible = false
            });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nombre_producto",
                HeaderText = "Producto",
                DataPropertyName = "nombre_producto",
                Width = 200
            });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "cantidad_original",
                HeaderText = "Cantidad Original",
                DataPropertyName = "cantidad_original",
                Width = 100
            });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "cantidad_devuelta",
                HeaderText = "Cantidad a Devolver",
                DataPropertyName = "cantidad_devuelta",
                Width = 120
            });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "precio_unitario",
                HeaderText = "Precio Unit.",
                DataPropertyName = "precio_unitario",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "$#,##0.00" },
                Width = 100
            });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "subtotal",
                HeaderText = "Subtotal",
                DataPropertyName = "subtotal",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "$#,##0.00" },
                Width = 100
            });
        }

        private void CargarFacturas()
        {
            try
            {
                string busqueda = txtBuscar.Text.Trim();
                int? idUsuario = null;
                if (chkUsuario.Checked && cmbUsuario.SelectedValue != null && Convert.ToInt32(cmbUsuario.SelectedValue) != 0)
                    idUsuario = Convert.ToInt32(cmbUsuario.SelectedValue);

                string numControl = null;
                if (chkNumControl.Checked && !string.IsNullOrEmpty(txtNumControl.Text))
                    numControl = txtNumControl.Text.Trim();

                DateTime? fechaDesde = null;
                DateTime? fechaHasta = null;
                if (chkFechas.Checked)
                {
                    fechaDesde = dtpDesde.Value.Date;
                    fechaHasta = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1);
                }

                DataTable dt = VentaHelper.ObtenerFacturasParaDevolucion(busqueda, idUsuario, numControl, fechaDesde, fechaHasta);
                _facturasTable = dt;
                dgvFacturas.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    dgvDetalles.DataSource = null;
                    lblFacturaSeleccionada.Text = "No se encontraron facturas.";
                    lblFacturaInfo.Text = "";
                    _idVentaSeleccionada = 0;
                    return;
                }

                // Seleccionar la primera fila automáticamente (esto disparará SelectionChanged)
                dgvFacturas.ClearSelection();
                dgvFacturas.Rows[0].Selected = true;
                // Nota: SelectionChanged se disparará automáticamente y cargará los detalles
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar facturas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento que se dispara cuando cambia la selección en el grid de facturas
        private void dgvFacturas_SelectionChanged(object sender, EventArgs e)
        {
            // Verificar que haya una fila seleccionada
            if (dgvFacturas.SelectedRows.Count == 0)
                return;

            DataGridViewRow row = dgvFacturas.SelectedRows[0];
            if (row == null || row.IsNewRow) return;

            int idVenta = Convert.ToInt32(row.Cells["id_venta"].Value);
            CargarDetallesFactura(idVenta);
        }

        private void CargarDetallesFactura(int idVenta)
        {
            try
            {
                DataTable dt = VentaHelper.ObtenerDetallesFacturaParaDevolucion(idVenta);
                if (!dt.Columns.Contains("cantidad_devuelta"))
                {
                    dt.Columns.Add("cantidad_devuelta", typeof(int));
                    foreach (DataRow row in dt.Rows)
                    {
                        row["cantidad_devuelta"] = 0;
                    }
                }
                dgvDetalles.DataSource = dt;

                // Configurar la columna cantidad_devuelta como editable
                foreach (DataGridViewColumn col in dgvDetalles.Columns)
                {
                    col.ReadOnly = true;
                    if (col.Name == "cantidad_devuelta")
                        col.ReadOnly = false;
                }

                // Obtener información de la factura
                DataRow facturaRow = _facturasTable.AsEnumerable()
                    .FirstOrDefault(r => Convert.ToInt32(r["id_venta"]) == idVenta);
                if (facturaRow != null)
                {
                    _idVentaSeleccionada = idVenta;
                    _numeroFactura = facturaRow["numero_factura"].ToString();
                    string cliente = facturaRow["cliente"].ToString();
                    decimal total = Convert.ToDecimal(facturaRow["total_venta"]);
                    string fecha = Convert.ToDateTime(facturaRow["fecha_venta"]).ToString("dd/MM/yyyy");
                    lblFacturaInfo.Text = $"Factura N° {_numeroFactura} - Cliente: {cliente} - Fecha: {fecha} - Total: {total:C2}";
                    lblFacturaSeleccionada.Text = $"Factura seleccionada: N° {_numeroFactura}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar detalles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Filtro_CheckedChanged(object sender, EventArgs e)
        {
            // Habilitar/deshabilitar controles según el checkbox
            if (sender == chkNumControl)
                txtNumControl.Enabled = chkNumControl.Checked;
            else if (sender == chkFechas)
            {
                dtpDesde.Enabled = chkFechas.Checked;
                dtpHasta.Enabled = chkFechas.Checked;
            }
            else if (sender == chkUsuario)
                cmbUsuario.Enabled = chkUsuario.Checked;

            // Si el checkbox se desactiva, limpiar los valores para que no afecten la búsqueda
            if (!chkNumControl.Checked) txtNumControl.Clear();
            if (!chkUsuario.Checked) cmbUsuario.SelectedValue = 0;
            // Para fechas, no limpiamos los valores pero el filtro no se aplica si no está marcado

            CargarFacturas();
        }

        // Eventos de los botones
        private void btnBuscar_Click(object sender, EventArgs e) => CargarFacturas();

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            chkNumControl.Checked = false;
            txtNumControl.Clear();
            chkFechas.Checked = false;
            dtpDesde.Value = DateTime.Now.AddDays(-30);
            dtpHasta.Value = DateTime.Now;
            chkUsuario.Checked = false;
            cmbUsuario.SelectedValue = 0;
            CargarFacturas();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (_idVentaSeleccionada == 0)
            {
                MessageBox.Show("Selecciona una factura.", "Sin factura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = (DataTable)dgvDetalles.DataSource;
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("La factura no tiene productos.", "Sin productos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool hayDevolucion = false;
            List<DetalleDevolucion> detallesDevueltos = new List<DetalleDevolucion>();
            List<DetalleVenta> productosNoDevueltos = new List<DetalleVenta>();

            foreach (DataRow row in dt.Rows)
            {
                object valorDevuelta = row["cantidad_devuelta"];
                int cantidadDevuelta = (valorDevuelta == DBNull.Value) ? 0 : Convert.ToInt32(valorDevuelta);
                int cantidadOriginal = Convert.ToInt32(row["cantidad_original"]);
                int idProducto = Convert.ToInt32(row["id_producto"]);
                decimal precioUnitario = Convert.ToDecimal(row["precio_unitario"]);

                if (cantidadDevuelta > 0)
                {
                    if (cantidadDevuelta > cantidadOriginal)
                    {
                        MessageBox.Show($"La cantidad a devolver de {row["nombre_producto"]} ({cantidadDevuelta}) no puede ser mayor que la cantidad original ({cantidadOriginal}).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    hayDevolucion = true;

                    detallesDevueltos.Add(new DetalleDevolucion
                    {
                        IdProducto = idProducto,
                        CantidadDevuelta = cantidadDevuelta,
                        CostoUnitario = 0,
                        PrecioUnitarioVenta = precioUnitario
                    });
                }

                int cantidadNoDevuelta = cantidadOriginal - cantidadDevuelta;
                if (cantidadNoDevuelta > 0)
                {
                    productosNoDevueltos.Add(new DetalleVenta
                    {
                        IdProducto = idProducto,
                        Cantidad = cantidadNoDevuelta,
                        PrecioUnitarioVenta = precioUnitario
                    });
                }
            }

            if (!hayDevolucion)
            {
                MessageBox.Show("Debes especificar al menos un producto con cantidad a devolver > 0.", "Sin devolución", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("¿Estás seguro de procesar esta devolución? Se anulará la factura original y se creará una nueva si hay productos no devueltos.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No)
                return;

            try
            {
                Devolucion devolucion = new Devolucion
                {
                    IdVentaOriginal = _idVentaSeleccionada,
                    FechaDevolucion = DateTime.Now,
                    IdUsuario = Global.UsuarioSesion.id_usuario,
                    Motivo = txtMotivo.Text.Trim(),
                    Detalles = detallesDevueltos
                };

                bool exito = DevolucionHelper.RegistrarDevolucion(devolucion, productosNoDevueltos);

                if (exito)
                {
                    MessageBox.Show("Devolución procesada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la devolución: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Devoluciones_Load(object sender, EventArgs e)
        {
            BotonesPersonalizados.EstiloBotonPildora(btnBuscar, "#98c1d9", 2, "#98c1d9");
            BotonesPersonalizados.EstiloBotonPildora(btnLimpiarFiltros, "#f4a261", 2, "#f4a261");
            BotonesPersonalizados.EstiloBotonPildora(btnProcesar, "#98c1d9", 2, "#98c1d9");
            BotonesPersonalizados.EstiloBotonPildora(btnCancelar, "#bc4749", 2, "#bc4749");
        }
    }
}