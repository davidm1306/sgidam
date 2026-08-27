using MySql.Data.MySqlClient;
using sgidam.Data;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace sgidam
{
    public partial class EditarProveedor : Form
    {
        private string idProveedor;

        public EditarProveedor(string id)
        {
            InitializeComponent();
            idProveedor = id;
            CargarDatos();
            ConfigurarEventos();
            ConfigurarValidaciones();
        }

        private void ConfigurarEventos()
        {
            // Asignar eventos de validación en tiempo real (opcional pero recomendado)
            txtNombre.Leave += txtNombre_Leave;
            txtDireccion.Leave += txtDireccion_Leave;
            txtTelefono.Leave += txtTelefono_Leave;
            txtTelefono.KeyPress += SoloNumeros;
        }

        private void ConfigurarValidaciones()
        {
            // Inicializar el ComboBox de estatus
            cmbEstatus.Items.Clear();
            cmbEstatus.Items.Add("ACTIVO");
            cmbEstatus.Items.Add("INACTIVO");
            cmbEstatus.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CargarDatos()
        {
            string query = "SELECT * FROM proveedores WHERE id_proveedor = @id";
            var param = new MySqlParameter("@id", idProveedor);
            DataTable dt = Utilbdd.EjecutarConsulta(query, new[] { param });

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtNombre.Text = row["nombre_proveedor"].ToString();
                txtCorreo.Text = row["correo_proveedor"].ToString();
                txtTelefono.Text = row["telefono_proveedor"].ToString();
                txtDireccion.Text = row["direccion_proveedor"].ToString();

                int estatus = Convert.ToInt32(row["estatus"]);
                cmbEstatus.SelectedItem = estatus == 1 ? "ACTIVO" : "INACTIVO";
            }
        }

        // Validación en tiempo real (cuando el campo pierde el foco)
        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim().Length > 0 && txtNombre.Text.Trim().Length < 3)
            {
                MessageBox.Show("El nombre debe tener al menos 3 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
            }
        }

        private void txtDireccion_Leave(object sender, EventArgs e)
        {
            if (txtDireccion.Text.Trim().Length > 0 && txtDireccion.Text.Trim().Length < 3)
            {
                MessageBox.Show("La dirección debe tener al menos 3 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccion.Focus();
            }
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            string telefono = txtTelefono.Text.Trim();
            if (!string.IsNullOrEmpty(telefono))
            {
                if (!Regex.IsMatch(telefono, @"^\d+$"))
                {
                    MessageBox.Show("El teléfono solo debe contener dígitos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTelefono.Focus();
                    return;
                }
                if (telefono.Length != 11)
                {
                    MessageBox.Show("El teléfono debe tener exactamente 11 dígitos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTelefono.Focus();
                }
            }
        }

        // Solo permite dígitos en el campo teléfono
        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void EditarProveedor_Load(object sender, EventArgs e)
        {
            BotonesPersonalizados.EstiloBotonPildora(btnCancelar, "#bc4749", 2, "#bc4749");
            BotonesPersonalizados.EstiloBotonPildora(btnGuardar, "#98c1d9", 2, "#98c1d9");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del proveedor es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }
            if (txtNombre.Text.Trim().Length < 3)
            {
                MessageBox.Show("El nombre debe tener al menos 3 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("La dirección es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccion.Focus();
                return;
            }
            if (txtDireccion.Text.Trim().Length < 3)
            {
                MessageBox.Show("La dirección debe tener al menos 3 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccion.Focus();
                return;
            }

            if (!Regex.IsMatch(txtTelefono.Text.Trim(), @"^\d+$"))
            {
                MessageBox.Show("El teléfono solo debe contener dígitos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }
            if (txtTelefono.Text.Trim().Length != 11)
            {
                MessageBox.Show("El teléfono debe tener exactamente 11 dígitos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }

            
            if (!string.IsNullOrEmpty(txtCorreo.Text))
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(txtCorreo.Text.Trim());
                    if (addr.Address != txtCorreo.Text.Trim())
                        throw new Exception();
                }
                catch
                {
                    MessageBox.Show("El correo electrónico no tiene un formato válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCorreo.Focus();
                    return;
                }
            }

            int estatus = cmbEstatus.SelectedItem?.ToString() == "ACTIVO" ? 1 : 2;

            string query = @"
                UPDATE proveedores SET 
                    nombre_proveedor = @nombre,
                    correo_proveedor = @correo,
                    telefono_proveedor = @telefono,
                    direccion_proveedor = @direccion,
                    estatus = @estatus
                WHERE id_proveedor = @id
            ";

            var parametros = new[]
            {
                new MySqlParameter("@nombre", txtNombre.Text.Trim()),
                new MySqlParameter("@correo", txtCorreo.Text.Trim()),
                new MySqlParameter("@telefono", txtTelefono.Text.Trim()),
                new MySqlParameter("@direccion", txtDireccion.Text.Trim()),
                new MySqlParameter("@estatus", estatus),
                new MySqlParameter("@id", idProveedor)
            };

            int filas = Utilbdd.EjecutarComando(query, parametros);

            if (filas > 0)
            {
                MessageBox.Show("Proveedor actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}