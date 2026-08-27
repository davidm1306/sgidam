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
    public partial class ListaFacturas : Form
    {
        public ListaFacturas()
        {
            InitializeComponent();
            CargarCombos();
            ConfigurarColumnasGrid();
            ConfigurarEventos();
            CargarFacturas(); 
        }

        private void ConfigurarEventos()
        {
            
            chkEstatus.CheckedChanged += (s, e) =>
            {
                cmbEstatus.Enabled = chkEstatus.Checked;
                if (chkEstatus.Checked) CargarFacturas();
            };
            chkCliente.CheckedChanged += (s, e) =>
            {
                cmbCliente.Enabled = chkCliente.Checked;
                if (chkCliente.Checked) CargarFacturas();
            };
            chkFecha.CheckedChanged += (s, e) =>
            {
                dtpDesde.Enabled = chkFecha.Checked;
                dtpHasta.Enabled = chkFecha.Checked;
                if (chkFecha.Checked) CargarFacturas();
            };

            
            cmbEstatus.SelectedIndexChanged += (s, e) => { if (chkEstatus.Checked) CargarFacturas(); };
            cmbCliente.SelectedIndexChanged += (s, e) => { if (chkCliente.Checked) CargarFacturas(); };
            dtpDesde.ValueChanged += (s, e) => { if (chkFecha.Checked) CargarFacturas(); };
            dtpHasta.ValueChanged += (s, e) => { if (chkFecha.Checked) CargarFacturas(); };

            
            txtNumFactura.TextChanged += (s, e) => CargarFacturas();
            txtNumControl.TextChanged += (s, e) => CargarFacturas();
        }

        private void CargarCombos()
        {
            
            DataTable dtEstatus = VentaHelper.ObtenerEstatus();
            dtEstatus.Rows.InsertAt(dtEstatus.NewRow(), 0);
            dtEstatus.Rows[0]["id_estatus"] = 0;
            dtEstatus.Rows[0]["tipo_status"] = "Todos";
            cmbEstatus.DataSource = dtEstatus;
            cmbEstatus.DisplayMember = "tipo_status";
            cmbEstatus.ValueMember = "id_estatus";
            cmbEstatus.SelectedValue = 0;

            
            DataTable dtClientes = VentaHelper.ObtenerClientes();
            dtClientes.Rows.InsertAt(dtClientes.NewRow(), 0);
            dtClientes.Rows[0]["id_cliente"] = "";
            dtClientes.Rows[0]["nombre_cliente"] = "Todos";
            cmbCliente.DataSource = dtClientes;
            cmbCliente.DisplayMember = "nombre_cliente";
            cmbCliente.ValueMember = "id_cliente";
            cmbCliente.SelectedValue = "";

            
            dtpDesde.Value = DateTime.Now.AddDays(-30);
            dtpHasta.Value = DateTime.Now;
        }

        private void ConfigurarColumnasGrid()
        {
            dgvFacturas.AutoGenerateColumns = false;
            dgvFacturas.Columns.Clear();

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
                Name = "sub_total",
                HeaderText = "Subtotal",
                DataPropertyName = "sub_total",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "$#,##0.00" },
                Width = 100
            });
            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "impuestos",
                HeaderText = "IVA",
                DataPropertyName = "impuestos",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "$#,##0.00" },
                Width = 100
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
                Name = "estatus",
                HeaderText = "Estatus",
                DataPropertyName = "estatus",
                Width = 80
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

            
            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id_venta",
                HeaderText = "ID",
                DataPropertyName = "id_venta",
                Visible = false
            });
        }

        private void CargarFacturas()
        {
            
            int? estatus = null;
            if (chkEstatus.Checked && cmbEstatus.SelectedValue != null && Convert.ToInt32(cmbEstatus.SelectedValue) != 0)
                estatus = Convert.ToInt32(cmbEstatus.SelectedValue);

            string idCliente = null;
            if (chkCliente.Checked && cmbCliente.SelectedValue != null && !string.IsNullOrEmpty(cmbCliente.SelectedValue.ToString()))
                idCliente = cmbCliente.SelectedValue.ToString();

            string numFactura = txtNumFactura.Text.Trim();
            string numControl = txtNumControl.Text.Trim();

            DateTime fechaDesde, fechaHasta;
            if (chkFecha.Checked)
            {
                fechaDesde = dtpDesde.Value.Date;
                fechaHasta = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1);
            }
            else
            {
                
                fechaDesde = DateTime.MinValue;
                fechaHasta = DateTime.MaxValue;
            }

            DataTable dt = VentaHelper.ObtenerFacturasConFiltros(estatus, idCliente, numFactura, numControl, fechaDesde, fechaHasta);
            dgvFacturas.DataSource = dt;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarFacturas();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            
            chkEstatus.Checked = false;
            chkCliente.Checked = false;
            chkFecha.Checked = false;
            cmbEstatus.SelectedValue = 0;
            cmbCliente.SelectedValue = "";
            txtNumFactura.Clear();
            txtNumControl.Clear();
            dtpDesde.Value = DateTime.Now.AddDays(-30);
            dtpHasta.Value = DateTime.Now;
            CargarFacturas();
        }

        private void ListaFacturas_Load(object sender, EventArgs e)
        {
            BotonesPersonalizados.EstiloBotonPildora(btnBuscar, "#98c1d9", 2, "#98c1d9");
            BotonesPersonalizados.EstiloBotonPildora(btnLimpiar, "#f4a261", 2, "#f4a261");
        }

        private void dgvFacturas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvFacturas.Rows[e.RowIndex];
            int idVenta = Convert.ToInt32(row.Cells["id_venta"].Value);

            using (var frmDetalle = new DetalleFactura(idVenta))
            {
                if (frmDetalle.ShowDialog() == DialogResult.OK)
                {
                    CargarFacturas();
                }
            }
        }
    }
}