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
    public partial class ListaProveedores : Form
    {
        public ListaProveedores()
        {
            InitializeComponent();
            CargarCombos();
            ConfigurarEventos();
        }

        private void CargarCombos()
        {
            
            DataTable dtProveedores = ListaProveedor.ObtenerProveedores();
            cmbProveedor.DataSource = dtProveedores;
            cmbProveedor.DisplayMember = "nombre_proveedor";
            cmbProveedor.ValueMember = "id_proveedor";
            cmbProveedor.SelectedIndex = -1;

            
            DataTable dtProductos = ListaProveedor.ObtenerProductos();
            cmbProducto.DataSource = dtProductos;
            cmbProducto.DisplayMember = "nombre_producto";
            cmbProducto.ValueMember = "id_producto";
            cmbProducto.SelectedIndex = -1;
        }

        private void ConfigurarEventos()
        {
            
            txtPrecio.KeyPress += Validaciones.SoloNumerosYDecimales;
            txtPrecio.Leave += Validaciones.LimpiarYSanitizar;

            this.KeyPreview = true;
            this.KeyDown += ListaProveedores_KeyDown;
        }


        private bool ValidarCampos()
        {

            if (cmbProveedor.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un proveedor.", "Campo requerido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProveedor.Focus();
                return false;
            }


            if (cmbProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un producto.", "Campo requerido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProducto.Focus();
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Ingresa el precio que ofrece el proveedor.", "Campo requerido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Ingresa un precio válido (mayor a 0).", "Valor inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                return false;
            }



            return true;
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {

                ListaProveedor nuevaRelacion = new ListaProveedor
                {
                    IdProveedor = cmbProveedor.SelectedValue.ToString(),
                    IdProducto = (int)cmbProducto.SelectedValue,
                    PrecioProveedor = decimal.Parse(txtPrecio.Text),
                    Estatus = 1
                };

                bool exito = ListaProveedor.Registrar(nuevaRelacion);

                if (exito)
                {
                    MessageBox.Show("Relación proveedor-producto registrada con éxito.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al registrar la relación.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ListaProveedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancelar_Click(sender, e);
        }

        private void ListaProveedores_Load(object sender, EventArgs e)
        {
            BotonesPersonalizados.EstiloBotonPildora(btnCancelar, "#bc4749", 2, "#bc4749");
            BotonesPersonalizados.EstiloBotonPildora(btnGuardar, "#98c1d9", 2, "#98c1d9");
        }
    }
}
