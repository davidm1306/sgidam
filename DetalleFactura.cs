using System;
using System.Data;
using System.Windows.Forms;
using sgidam.Data;
using sgidam.Models;
using MySql.Data.MySqlClient;

namespace sgidam
{
    public partial class DetalleFactura : Form
    {
        private int _idVenta;

        
        public DetalleFactura(int idVenta)
        {
            InitializeComponent();
            _idVenta = idVenta;
            CargarEstatus();
            CargarDatosFactura();
            ConfigurarControles();
            ConfigurarEventos();
        }

        private void CargarEstatus()
        {
           
            DataTable dtEstatus = VentaHelper.ObtenerEstatus();
            cmbEstatus.DataSource = dtEstatus;
            cmbEstatus.DisplayMember = "tipo_status";
            cmbEstatus.ValueMember = "id_estatus";
        }

        private void CargarDatosFactura()
        {
            try
            {
                
                string queryCabecera = @"
                    SELECT 
                        v.numero_factura,
                        v.fecha_venta,
                        v.sub_total,
                        v.impuestos,
                        v.total_venta,
                        v.numero_control,
                        v.estatus,
                        c.id_cliente,
                        c.nombre_cliente,
                        c.direccion_cliente,
                        c.telefono_cliente,
                        e.tipo_status AS estatus_nombre
                    FROM ventas v
                    INNER JOIN clientes c ON v.id_cliente = c.id_cliente
                    INNER JOIN estatus e ON v.estatus = e.id_estatus
                    WHERE v.id_venta = @idVenta
                ";
                var paramCabecera = Utilbdd.CrearParametros(new Dictionary<string, object> { { "idVenta", _idVenta } });
                DataTable dtCabecera = Utilbdd.EjecutarConsulta(queryCabecera, paramCabecera);
                if (dtCabecera.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontró la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                DataRow row = dtCabecera.Rows[0];

                
                txtNumFactura.Text = row["numero_factura"].ToString();
                txtFecha.Text = Convert.ToDateTime(row["fecha_venta"]).ToString("dd/MM/yyyy HH:mm");
                txtSubTotal.Text = Convert.ToDecimal(row["sub_total"]).ToString("N2");
                txtImpuestos.Text = Convert.ToDecimal(row["impuestos"]).ToString("N2");
                txtTotal.Text = Convert.ToDecimal(row["total_venta"]).ToString("N2");
                txtNumControl.Text = row["numero_control"].ToString();

                
                cmbTipoDoc.SelectedItem = row["id_cliente"].ToString().Substring(0, 1);
                txtNumDoc.Text = row["id_cliente"].ToString().Substring(1);
                txtNombreCliente.Text = row["nombre_cliente"].ToString();
                txtDireccionCliente.Text = row["direccion_cliente"].ToString();
                txtTelefonoCliente.Text = row["telefono_cliente"].ToString();

                
                int estatusId = Convert.ToInt32(row["estatus"]);
                cmbEstatus.SelectedValue = estatusId;

               
                string queryDetalles = @"
                    SELECT 
                        p.nombre_producto,
                        dv.cantidad,
                        dv.precio_unitario_venta,
                        dv.subtotal
                    FROM detalles_venta dv
                    INNER JOIN productos p ON dv.id_producto = p.id_producto
                    WHERE dv.id_venta = @idVenta
                    ORDER BY dv.id_detalle_venta
                ";
                var paramDetalles = Utilbdd.CrearParametros(new Dictionary<string, object> { { "idVenta", _idVenta } });
                DataTable dtDetalles = Utilbdd.EjecutarConsulta(queryDetalles, paramDetalles);
                dgvDetalles.DataSource = dtDetalles;

                
                ConfigurarColumnasDetalles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void ConfigurarColumnasDetalles()
        {
            dgvDetalles.AutoGenerateColumns = false;
            dgvDetalles.Columns.Clear();

            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nombre_producto",
                HeaderText = "Producto",
                DataPropertyName = "nombre_producto",
                Width = 200
            });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "cantidad",
                HeaderText = "Cantidad",
                DataPropertyName = "cantidad",
                Width = 80
            });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "precio_unitario_venta",
                HeaderText = "Precio Unit.",
                DataPropertyName = "precio_unitario_venta",
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

        private void ConfigurarControles()
        {
            
            txtNumFactura.ReadOnly = true;
            txtFecha.ReadOnly = true;
            txtSubTotal.ReadOnly = true;
            txtImpuestos.ReadOnly = true;
            txtTotal.ReadOnly = true;
            txtNumControl.ReadOnly = true;

            txtNombreCliente.ReadOnly = true;
            txtDireccionCliente.ReadOnly = true;
            txtTelefonoCliente.ReadOnly = true;
            txtNumDoc.ReadOnly = true;
            cmbTipoDoc.Enabled = false;
            

            dgvDetalles.ReadOnly = true;

            cmbEstatus.Enabled = true;
        }

        private void ConfigurarEventos()
        {
            this.btnGuardar.Click += btnGuardar_Click;
            this.btnCancelar.Click += btnCancelar_Click;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el nuevo estatus seleccionado
                if (cmbEstatus.SelectedValue == null)
                {
                    MessageBox.Show("Selecciona un estatus válido.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int nuevoEstatus = Convert.ToInt32(cmbEstatus.SelectedValue);

                // Actualizar en la base de datos
                string query = "UPDATE ventas SET estatus = @estatus WHERE id_venta = @idVenta";
                var parametros = Utilbdd.CrearParametros(new Dictionary<string, object>
                {
                    { "estatus", nuevoEstatus },
                    { "idVenta", _idVenta }
                });
                int filas = Utilbdd.EjecutarComando(query, parametros);

                if (filas > 0)
                {
                    MessageBox.Show("Estatus actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estatus.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void DetalleFactura_Load(object sender, EventArgs e)
        {
            BotonesPersonalizados.EstiloBotonPildora(btnGuardar, "#98c1d9", 2, "#98c1d9");
            BotonesPersonalizados.EstiloBotonPildora(btnCancelar, "#bc4749", 2, "#bc4749");
        }
    }
}