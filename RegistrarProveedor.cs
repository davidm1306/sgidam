using sgidam.Data;
using sgidam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sgidam
{
    public partial class RegistrarProveedor : Form
    {
        public RegistrarProveedor()
        {
            InitializeComponent();
            CargarCombos();
            ConfigurarEventos();
        }

        private void CargarCombos()
        {

            DataTable dtEstatus = Proveedor.ObtenerEstatus();
            cmbEstatus.DataSource = dtEstatus;
            cmbEstatus.DisplayMember = "tipo_status";
            cmbEstatus.ValueMember = "id_estatus";
            cmbEstatus.SelectedIndex = 0;

        }

        private void ConfigurarEventos()
        {

            txtRifNumero.KeyPress += SoloNumeros;
            txtTelefono.KeyPress += SoloNumeros;


            txtNombre.Leave += (s, e) => txtNombre.Text = TextoHelper.ToUpper(txtNombre.Text);
            txtCorreo.Leave += (s, e) => txtCorreo.Text = TextoHelper.ToUpper(txtCorreo.Text);
            txtDireccion.Leave += (s, e) => txtDireccion.Text = TextoHelper.ToUpper(txtDireccion.Text);


            this.KeyPreview = true;
            this.KeyDown += RegistrarProveedor_KeyDown;
        }

        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ValidarCorreo(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(txtCorreo.Text, patron))
                {
                    MessageBox.Show("El correo electrónico no tiene un formato válido (ej: usuario@dominio.com).",
                                    "Formato incorrecto",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    txtCorreo.Focus();
                }
            }
        }

        private bool ValidarCampos()
        {

            if (cmbTipoRif.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona el tipo de RIF (J, G o V).", "Campo requerido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipoRif.Focus();
                return false;
            }


            string rifNum = txtRifNumero.Text.Trim();
            if (string.IsNullOrWhiteSpace(rifNum))
            {
                MessageBox.Show("El número del RIF es obligatorio.", "Campo requerido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRifNumero.Focus();
                return false;
            }


            if (!long.TryParse(rifNum, out _))
            {
                MessageBox.Show("El RIF debe contener solo números.", "Formato inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRifNumero.Focus();
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del proveedor es obligatorio.", "Campo requerido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }


            string telefono = txtTelefono.Text.Trim();
            if (!string.IsNullOrWhiteSpace(telefono))
            {
                if (!long.TryParse(telefono, out _))
                {
                    MessageBox.Show("El teléfono debe contener solo números.", "Formato inválido",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTelefono.Focus();
                    return false;
                }
                if (telefono.Length > 11)
                {
                    MessageBox.Show("El teléfono no puede tener más de 11 dígitos.", "Longitud excedida",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTelefono.Focus();
                    return false;
                }
            }


            string correo = txtCorreo.Text.Trim();
            if (!string.IsNullOrWhiteSpace(correo))
            {
                try
                {
                    var mail = new System.Net.Mail.MailAddress(correo);
                    if (mail.Address != correo)
                        throw new Exception();
                }
                catch
                {
                    MessageBox.Show("El correo ingresado no tiene un formato válido.", "Correo inválido",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCorreo.Focus();
                    return false;
                }
            }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {

                string idCompleto = cmbTipoRif.SelectedItem.ToString() + txtRifNumero.Text.Trim();

                Proveedor nuevoProveedor = new Proveedor
                {
                    IdProveedor = idCompleto,
                    NombreProveedor = txtNombre.Text.Trim(),
                    CorreoProveedor = string.IsNullOrWhiteSpace(txtCorreo.Text) ? null : txtCorreo.Text.Trim(),
                    TelefonoProveedor = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                    DireccionProveedor = string.IsNullOrWhiteSpace(txtDireccion.Text) ? null : txtDireccion.Text.Trim(),
                    Estatus = (int)cmbEstatus.SelectedValue
                };

                bool exito = Proveedor.Registrar(nuevoProveedor);

                if (exito)
                {
                    MessageBox.Show("Proveedor registrado con éxito.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al registrar el proveedor.", "Error",
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

        private void RegistrarProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancelar_Click(sender, e);
        }

        private void RegistrarProveedor_Load(object sender, EventArgs e)
        {
            BotonesPersonalizados.EstiloBotonPildora(btnCancelar, "#bc4749", 2, "#bc4749");
            BotonesPersonalizados.EstiloBotonPildora(btnGuardar, "#98c1d9", 2, "#98c1d9");
        }
    }
}
