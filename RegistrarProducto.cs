using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sgidam.Models;
using sgidam.Data;
using System.IO;

namespace sgidam
{
    public partial class RegistrarProducto : Form
    {
        private string _rutaImagenSeleccionada = null;
        public RegistrarProducto()
        {
            InitializeComponent();
            CargarCombos();
            ConfigurarEventos();
            CalcularPrecioVenta();
        }

        private void CargarCombos()
        {

            DataTable dtMarcas = Producto.ObtenerMarcas();
            cmbMarca.DataSource = dtMarcas;
            cmbMarca.DisplayMember = "nombre_marca";
            cmbMarca.ValueMember = "id_marca";
            cmbMarca.SelectedIndex = -1;


            DataTable dtCategorias = Producto.ObtenerCategorias();
            cmbCategoria.DataSource = dtCategorias;
            cmbCategoria.DisplayMember = "nombre_categoria";
            cmbCategoria.ValueMember = "id_categoria";
            cmbCategoria.SelectedIndex = -1;


            DataTable dtEstatus = Producto.ObtenerEstatus();
            cmbEstatus.DataSource = dtEstatus;
            cmbEstatus.DisplayMember = "tipo_status";
            cmbEstatus.ValueMember = "id_estatus";
            cmbEstatus.SelectedIndex = 0;
        }
        private void SoloNumerosYDecimales(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void CalcularPrecioVenta()
        {
            
            if (decimal.TryParse(txtPrecioCompra.Text, out decimal precioCompra) && precioCompra > 0)
            {
                decimal porcentaje = nudPorcentajeUtilidad.Value;
                decimal precioVenta = precioCompra * (1 + porcentaje / 100);
                txtPrecioVenta.Text = precioVenta.ToString("F2"); // Formato con 2 decimales
            }
            else
            {
               
                txtPrecioVenta.Text = "";
            }
        }
        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
           
        }

        private void ConfigurarEventos()
        {

            txtPrecioCompra.KeyPress += SoloNumerosYDecimales;
            txtPrecioVenta.KeyPress += SoloNumerosYDecimales;

            txtPrecioCompra.TextChanged += (s, e) => CalcularPrecioVenta();
            nudPorcentajeUtilidad.ValueChanged += (s, e) => CalcularPrecioVenta();

            this.KeyPreview = true;
            this.KeyDown += FormRegistrarProducto_KeyDown;
        }

        private bool ValidarCampos()
        {

            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text))
            {
                MessageBox.Show("El nombre del producto es obligatorio.", "Campo requerido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreProducto.Focus();
                return false;
            }


            if (!decimal.TryParse(txtPrecioCompra.Text, out decimal precioCompra) || precioCompra <= 0)
            {
                MessageBox.Show("Ingresa un precio de compra válido (mayor a 0).", "Valor inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioCompra.Focus();
                return false;
            }


            if (!decimal.TryParse(txtPrecioVenta.Text, out decimal precioVenta) || precioVenta <= 0)
            {
                MessageBox.Show("Ingresa un precio de venta válido (mayor a 0).", "Valor inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioVenta.Focus();
                return false;
            }


            if (cmbMarca.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecciona una marca (o crea una nueva si no existe).", "Selección requerida",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMarca.Focus();
                return false;
            }


            if (cmbCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecciona una categoría.", "Selección requerida",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategoria.Focus();
                return false;
            }

            return true;
        }



        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void RegistrarProducto_Load(object sender, EventArgs e)
        {
            BotonesPersonalizados.EstiloBotonPildora(btnCancelar, "#bc4749", 2, "#bc4749");
            BotonesPersonalizados.EstiloBotonPildora(btnCargarImagen, "#98c1d9", 2, "#98c1d9");
            BotonesPersonalizados.EstiloBotonPildora(btnGuardar, "#98c1d9", 2, "#98c1d9");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormRegistrarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            if (!ValidarCampos())
                return;

            try
            {
                
                Producto nuevoProducto = new Producto
                {
                    NombreProducto = txtNombreProducto.Text.Trim(),
                    CodigoBarras = string.IsNullOrWhiteSpace(txtCodigoBarras.Text) ? null : txtCodigoBarras.Text.Trim(),
                    IdMarca = (int)cmbMarca.SelectedValue,
                    IdCategoria = (int)cmbCategoria.SelectedValue,
                    PrecioCompra = decimal.Parse(txtPrecioCompra.Text),
                    PrecioVenta = decimal.Parse(txtPrecioVenta.Text),
                    PorcentajeUtilidad = nudPorcentajeUtilidad.Value,
                    Stock = (int)nudStock.Value,
                    StockMinimo = (int)nudStockMinimo.Value,
                    Estatus = (int)cmbEstatus.SelectedValue
                    
                };

                
                bool exito = Producto.RegistrarProducto(nuevoProducto, _rutaImagenSeleccionada);

                if (exito)
                {
                    MessageBox.Show("Producto registrado con éxito.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error inesperado al registrar el producto.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCargarImagen_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Seleccionar imagen del producto";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                         _rutaImagenSeleccionada = openFileDialog.FileName;

                        pbImagen.Image = System.Drawing.Image.FromFile(_rutaImagenSeleccionada);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
