using sgidam.Data;
using sgidam.Models;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace sgidam
{
    public partial class RegistrarProveedor : Form
    {
        public RegistrarProveedor()
        {
            InitializeComponent();
            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            txtRifNumero.KeyPress += Validaciones.SoloNumerosEnterosConCeroInicial;
            txtTelefono.KeyPress += Validaciones.SoloNumerosEnterosConCeroInicial;

            txtNombre.Leave += (s, e) => Validaciones.ConvertirAMayusculas(s, e);
            txtDireccion.Leave += (s, e) => Validaciones.ConvertirAMayusculas(s, e);
            txtCorreo.Leave += (s, e) => Validaciones.ConvertirAMayusculas(s, e);

            txtNombre.Leave += TxtNombre_Leave;
            txtDireccion.Leave += TxtDireccion_Leave;

            txtTelefono.Leave += TxtTelefono_Leave;

            txtCorreo.Leave += TxtCorreo_Leave;

            this.KeyPreview = true;
            this.KeyDown += RegistrarProveedor_KeyDown;
        }

       

        private void TxtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length > 0 && txtNombre.Text.Length < 3)
            {
                MessageBox.Show("El nombre debe tener al menos 3 caracteres.", "Longitud mínima", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
            }
        }

        private void TxtDireccion_Leave(object sender, EventArgs e)
        {
            if (txtDireccion.Text.Length > 0 && txtDireccion.Text.Length < 3)
            {
                MessageBox.Show("La dirección debe tener al menos 3 caracteres.", "Longitud mínima", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccion.Focus();
            }
        }

        private void TxtTelefono_Leave(object sender, EventArgs e)
        {
            string telefono = txtTelefono.Text.Trim();
            if (!string.IsNullOrEmpty(telefono) && telefono.Length != 11)
            {
                MessageBox.Show("El teléfono debe tener exactamente 11 dígitos.", "Longitud incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
            }
        }

        private void TxtCorreo_Leave(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            if (!string.IsNullOrEmpty(correo) && !Validaciones.EsCorreoValido(correo))
            {
                MessageBox.Show("El correo ingresado no tiene un formato válido (ej: usuario@dominio.com).", "Correo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
            }
        }

        private bool ValidarCampos()
        {
           
            if (cmbTipoRif.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona el tipo de RIF (J, G o V).", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipoRif.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRifNumero.Text))
            {
                MessageBox.Show("El número del RIF es obligatorio.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRifNumero.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del proveedor es obligatorio.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("La dirección es obligatoria.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccion.Focus();
                return false;
            }

            
            if (string.IsNullOrWhiteSpace(txtCorreo.Text) && string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Debe proporcionar al menos un medio de contacto: correo o teléfono.", "Contacto requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return false;
            }

          
            string telefono = txtTelefono.Text.Trim();
            if (!string.IsNullOrEmpty(telefono) && telefono.Length != 11)
            {
                MessageBox.Show("El teléfono debe tener exactamente 11 dígitos.", "Longitud incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }

           
            string correo = txtCorreo.Text.Trim();
            if (!string.IsNullOrEmpty(correo) && !Validaciones.EsCorreoValido(correo))
            {
                MessageBox.Show("El correo ingresado no tiene un formato válido.", "Correo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return false;
            }


            if (cmbTipoRif.SelectedItem?.ToString() == "V")
            {
                if (long.TryParse(txtRifNumero.Text, out long rifNum))
                {
                    if (rifNum < 1000000)
                    {
                        MessageBox.Show("Cédula muy corta. Debe ser mayor a 1,000,000.", "Rango inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRifNumero.Focus();
                        return false;
                    }
                    else if (rifNum > 50000000)
                    {
                        MessageBox.Show("La cédula debe tener máximo 7 dígitos o el número es muy alto.", "Rango inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRifNumero.Focus();
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("El RIF debe contener solo números.", "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRifNumero.Focus();
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
                    Estatus = 1
                };

                bool exito = Proveedor.Registrar(nuevoProveedor);

                if (exito)
                {
                    MessageBox.Show("Proveedor registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al registrar el proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void RegistrarProveedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel)
                return;
        }
    }
}