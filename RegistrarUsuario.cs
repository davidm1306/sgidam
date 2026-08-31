using sgidam.Data;
using sgidam.Models;
using System;
using System.Windows.Forms;

namespace sgidam
{
    public partial class RegistrarUsuario : Form
    {
        public RegistrarUsuario()
        {
            InitializeComponent();
            CargarCombos();
            ConfigurarEventos();
        }

        private void CargarCombos()
        {
            cmbRol.Items.Clear();
            cmbRol.Items.Add("ADMINISTRADOR");
            cmbRol.Items.Add("VENDEDOR");
            cmbRol.SelectedIndex = 0;
        }

        private void ConfigurarEventos()
        {
            // Cédula: solo números, no permite cero inicial
            txtCedula.KeyPress += Validaciones.SoloNumerosEnteros;
            txtCedula.Leave += TxtCedula_Leave;

            // Nombre y apellido: convertir a mayúsculas, sanitizar y validar longitud
            txtNombreEmpleado.Leave += TxtNombreEmpleado_Leave;
            txtApellido.Leave += TxtApellido_Leave;

            // Nombre de usuario: validar longitud y sanitizar
            txtNombreUsuario.Leave += TxtNombreUsuario_Leave;

            // Confirmar contraseña: validar coincidencia
            txtConfirmPassword.Leave += TxtConfirmPassword_Leave;

            // Tecla Escape para cancelar
            this.KeyPreview = true;
            this.KeyDown += RegistrarUsuario_KeyDown;

            // Sanitización en campos de texto (nombre, apellido, usuario)
            txtNombreEmpleado.Leave += (s, e) => Validaciones.LimpiarYSanitizar(s, e);
            txtApellido.Leave += (s, e) => Validaciones.LimpiarYSanitizar(s, e);
            txtNombreUsuario.Leave += (s, e) => Validaciones.LimpiarYSanitizar(s, e);
        }

        // ---- Validaciones individuales ----

        private void TxtNombreEmpleado_Leave(object sender, EventArgs e)
        {
            // Convertir a mayúsculas
            Validaciones.ConvertirAMayusculas(sender, e);
            // Validar longitud mínima
            string valor = txtNombreEmpleado.Text.Trim();
            if (valor.Length > 0 && valor.Length < 3)
            {
                MessageBox.Show("El nombre del empleado debe tener al menos 3 caracteres.", "Longitud mínima", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreEmpleado.Focus();
            }
        }

        private void TxtApellido_Leave(object sender, EventArgs e)
        {
            Validaciones.ConvertirAMayusculas(sender, e);
            string valor = txtApellido.Text.Trim();
            if (valor.Length > 0 && valor.Length < 3)
            {
                MessageBox.Show("El apellido del empleado debe tener al menos 3 caracteres.", "Longitud mínima", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
            }
        }

        private void TxtCedula_Leave(object sender, EventArgs e)
        {
            string valor = txtCedula.Text.Trim();
            if (string.IsNullOrEmpty(valor))
                return; // No obligatorio en Leave, se validará al guardar

            if (!long.TryParse(valor, out long cedula))
            {
                MessageBox.Show("La cédula debe contener solo números.", "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCedula.Focus();
                return;
            }

            if (cedula < 1000000)
            {
                MessageBox.Show("No se pueden ingresar cédulas tan bajas.", "Rango inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCedula.Focus();
                return;
            }
            if (cedula > 50000000)
            {
                MessageBox.Show("La cédula puede contener solo 7 dígitos o número muy alto.", "Rango inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCedula.Focus();
                return;
            }
        }

        private void TxtNombreUsuario_Leave(object sender, EventArgs e)
        {
            string valor = txtNombreUsuario.Text.Trim();
            if (valor.Length > 0 && valor.Length < 3)
            {
                MessageBox.Show("El nombre de usuario debe tener al menos 3 caracteres.", "Longitud mínima", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreUsuario.Focus();
            }
        }

        private void TxtConfirmPassword_Leave(object sender, EventArgs e)
        {
            // Validar que las contraseñas coincidan y longitud mínima
            string pass = txtPassword.Text;
            string confirm = txtConfirmPassword.Text;

            if (!string.IsNullOrEmpty(confirm))
            {
                if (confirm.Length < 4)
                {
                    MessageBox.Show("La contraseña debe tener al menos 4 caracteres.", "Longitud mínima", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConfirmPassword.Focus();
                    return;
                }
                if (pass != confirm)
                {
                    MessageBox.Show("Las contraseñas no coinciden.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConfirmPassword.Focus();
                    return;
                }
            }
        }

        // ---- Validación completa al guardar ----

        private bool ValidarCampos()
        {
            // Nombre empleado
            if (string.IsNullOrWhiteSpace(txtNombreEmpleado.Text))
            {
                MessageBox.Show("El nombre del empleado es obligatorio.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreEmpleado.Focus();
                return false;
            }
            if (txtNombreEmpleado.Text.Trim().Length < 3)
            {
                MessageBox.Show("El nombre del empleado debe tener al menos 3 caracteres.", "Longitud mínima", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreEmpleado.Focus();
                return false;
            }

            // Apellido
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El apellido del empleado es obligatorio.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }
            if (txtApellido.Text.Trim().Length < 3)
            {
                MessageBox.Show("El apellido del empleado debe tener al menos 3 caracteres.", "Longitud mínima", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }

            // Cédula
            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("La cédula del empleado es obligatoria.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCedula.Focus();
                return false;
            }
            if (!long.TryParse(txtCedula.Text.Trim(), out long cedula))
            {
                MessageBox.Show("La cédula debe contener solo números.", "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCedula.Focus();
                return false;
            }
            if (cedula < 1000000)
            {
                MessageBox.Show("No se pueden ingresar cédulas tan bajas.", "Rango inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCedula.Focus();
                return false;
            }
            if (cedula > 50000000)
            {
                MessageBox.Show("La cédula puede contener solo 7 dígitos o número muy alto.", "Rango inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCedula.Focus();
                return false;
            }

            // Nombre usuario
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                MessageBox.Show("El nombre de usuario es obligatorio.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreUsuario.Focus();
                return false;
            }
            if (txtNombreUsuario.Text.Trim().Length < 3)
            {
                MessageBox.Show("El nombre de usuario debe tener al menos 3 caracteres.", "Longitud mínima", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreUsuario.Focus();
                return false;
            }

            // Contraseña
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("La contraseña es obligatoria.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }
            if (txtPassword.Text.Length < 4)
            {
                MessageBox.Show("La contraseña debe tener al menos 4 caracteres.", "Contraseña débil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            // Confirmar contraseña
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return false;
            }

            // Rol
            if (cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un rol para el usuario.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRol.Focus();
                return false;
            }

            return true;
        }

        // ---- Botones ----

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                Usuario nuevoUsuario = new Usuario
                {
                    id_usuario = int.Parse(txtCedula.Text.Trim()),
                    nombre_usuario = txtNombreUsuario.Text.Trim(),
                    nombre_empleado = txtNombreEmpleado.Text.Trim(),
                    apellido_empleado = txtApellido.Text.Trim(),
                    rol = cmbRol.SelectedItem.ToString(),
                    estatus = 1
                };

                bool exito = Usuario.Registrar(nuevoUsuario, txtPassword.Text);

                if (exito)
                {
                    MessageBox.Show("Usuario registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al registrar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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