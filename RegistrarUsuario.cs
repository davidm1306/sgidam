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
using System.Windows.Forms;

namespace sgidam
{
    public partial class RegistrarUsuario : Form
    {
        public RegistrarUsuario()
        {
            InitializeComponent();
            CargarCombos();
        }

        private void CargarCombos()
        {

            DataTable dtEstatus = Usuario.ObtenerEstatus();
            cmbEstatus.DataSource = dtEstatus;
            cmbEstatus.DisplayMember = "tipo_status";
            cmbEstatus.ValueMember = "id_estatus";
            cmbEstatus.SelectedIndex = 0;


            cmbRol.Items.Clear();
            cmbRol.Items.Add("Administrador");
            cmbRol.Items.Add("Vendedor");
            cmbRol.SelectedIndex = 0;
        }

        private bool ValidarCampos()
        {

            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("La cédula del empleado es obligatoria.", "Campo requerido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCedula.Focus();
                return false;
            }

            if (!long.TryParse(txtCedula.Text.Trim(), out long cedula))
            {
                MessageBox.Show("La cédula debe contener solo números.", "Formato inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCedula.Focus();
                return false;
            }

            if (cedula < 1000000 || cedula > 100000000)
            {
                MessageBox.Show("La cédula debe estar entre 1,000,000 y 100,000,000.", "Rango inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCedula.Focus();
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                MessageBox.Show("El nombre de usuario es obligatorio.", "Campo requerido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreUsuario.Focus();
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Contraseña débil",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }


            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error de validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtNombreEmpleado.Text))
            {
                MessageBox.Show("El nombre del empleado es obligatorio.", "Campo requerido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreEmpleado.Focus();
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El apellido del empleado es obligatorio.", "Campo requerido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }


            if (cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un rol para el usuario.", "Campo requerido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRol.Focus();
                return false;
            }

            return true;
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                Usuario nuevoUsuario = new Usuario
                {
                    id_usuario = int.Parse(txtCedula.Text.Trim()), // Convertir a int
                    nombre_usuario = txtNombreUsuario.Text.Trim(),
                    nombre_empleado = txtNombreEmpleado.Text.Trim(),
                    apellido_empleado = txtApellido.Text.Trim(),
                    rol = cmbRol.SelectedItem.ToString(),
                    estatus = (int)cmbEstatus.SelectedValue
                };

                bool exito = Usuario.Registrar(nuevoUsuario, txtPassword.Text);

                if (exito)
                {
                    MessageBox.Show("Usuario registrado con éxito.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al registrar el usuario.", "Error",
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

        private void RegistrarUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancelar_Click(sender, e);
        }

        private void RegistrarUsuario_Load(object sender, EventArgs e)
        {
            BotonesPersonalizados.EstiloBotonPildora(btnCancelar, "#bc4749", 2, "#bc4749");
            BotonesPersonalizados.EstiloBotonPildora(btnGuardar, "#98c1d9", 2, "#98c1d9");
        }
    }
}
