using MySql.Data.MySqlClient;
using sgidam.Data;
using System;
using System.Data;
using System.Windows.Forms;

namespace sgidam
{
    public partial class EditarProveedor : Form
    {
        private string idProveedor;
        private string _tipoRif;
        private string _numeroRif;
        private bool _cerrando = false;

        public EditarProveedor(string id)
        {
            InitializeComponent();
            idProveedor = id;
            ExtraerTipoRif();
            CargarDatos();
            ConfigurarEventos();
            ConfigurarValidaciones();
        }

        private void ExtraerTipoRif()
        {
            if (!string.IsNullOrEmpty(idProveedor) && idProveedor.Length > 1)
            {
                _tipoRif = idProveedor.Substring(0, 1).ToUpper();
                _numeroRif = idProveedor.Substring(1);
            }
            else
            {
                _tipoRif = "";
                _numeroRif = "";
            }
        }

        private void CargarDatos()
        {
            string query = "SELECT * FROM proveedores WHERE id_proveedor = @id";
            var param = new MySqlParameter("@id", idProveedor);
            DataTable dt = Utilbdd.EjecutarConsulta(query, new[] { param });

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtNombre.Text = row["nombre_proveedor"]?.ToString() ?? "";
                txtCorreo.Text = row["correo_proveedor"]?.ToString() ?? "";
                txtTelefono.Text = row["telefono_proveedor"]?.ToString() ?? "";
                txtDireccion.Text = row["direccion_proveedor"]?.ToString() ?? "";

                int estatus = Convert.ToInt32(row["estatus"]);
                cmbEstatus.SelectedItem = estatus == 1 ? "ACTIVO" : "INACTIVO";
            }
        }

        private void ConfigurarEventos()
        {
            txtTelefono.KeyPress += Validaciones.SoloNumerosEnterosConCeroInicial;

            txtNombre.Leave += (s, e) => Validaciones.ConvertirAMayusculas(s, e);
            txtDireccion.Leave += (s, e) => Validaciones.ConvertirAMayusculas(s, e);
            txtCorreo.Leave += (s, e) => Validaciones.ConvertirAMayusculas(s, e);

            txtNombre.Leave += TxtNombre_Leave;
            txtDireccion.Leave += TxtDireccion_Leave;
            txtTelefono.Leave += TxtTelefono_Leave;
            txtCorreo.Leave += TxtCorreo_Leave;

            this.KeyPreview = true;
            this.KeyDown += EditarProveedor_KeyDown;
        }

        private void ConfigurarValidaciones()
        {
            cmbEstatus.Items.Clear();
            cmbEstatus.Items.Add("ACTIVO");
            cmbEstatus.Items.Add("INACTIVO");
            cmbEstatus.DropDownStyle = ComboBoxStyle.DropDownList;
            if (cmbEstatus.Items.Count > 0)
                cmbEstatus.SelectedIndex = 0;
        }

        private void TxtNombre_Leave(object sender, EventArgs e)
        {
            if (_cerrando) return;
            if (txtNombre.Text.Trim().Length > 0 && txtNombre.Text.Trim().Length < 3)
            {
                MessageBox.Show("El nombre debe tener al menos 3 caracteres.", "Longitud mínima", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
            }
        }

        private void TxtDireccion_Leave(object sender, EventArgs e)
        {
            if (_cerrando) return;
            if (txtDireccion.Text.Trim().Length > 0 && txtDireccion.Text.Trim().Length < 3)
            {
                MessageBox.Show("La dirección debe tener al menos 3 caracteres.", "Longitud mínima", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccion.Focus();
            }
        }

        private void TxtTelefono_Leave(object sender, EventArgs e)
        {
            if (_cerrando) return;
            string telefono = txtTelefono.Text.Trim();
            if (!string.IsNullOrEmpty(telefono) && telefono.Length != 11)
            {
                MessageBox.Show("El teléfono debe tener exactamente 11 dígitos.", "Longitud incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
            }
        }

        private void TxtCorreo_Leave(object sender, EventArgs e)
        {
            if (_cerrando) return;
            string correo = txtCorreo.Text.Trim();
            if (!string.IsNullOrEmpty(correo) && !Validaciones.EsCorreoValido(correo))
            {
                MessageBox.Show("El correo ingresado no tiene un formato válido (ej: usuario@dominio.com).", "Correo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del proveedor es obligatorio.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            if (txtNombre.Text.Trim().Length < 3)
            {
                MessageBox.Show("El nombre debe tener al menos 3 caracteres.", "Longitud mínima", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("La dirección es obligatoria.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccion.Focus();
                return false;
            }
            if (txtDireccion.Text.Trim().Length < 3)
            {
                MessageBox.Show("La dirección debe tener al menos 3 caracteres.", "Longitud mínima", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


            if (cmbEstatus.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un estatus (ACTIVO o INACTIVO).", "Estatus requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEstatus.Focus();
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
                    new MySqlParameter("@correo", string.IsNullOrWhiteSpace(txtCorreo.Text) ? null : txtCorreo.Text.Trim()),
                    new MySqlParameter("@telefono", string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim()),
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _cerrando = true;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void EditarProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancelar_Click(sender, e);
        }

        private void EditarProveedor_Load(object sender, EventArgs e)
        {
            BotonesPersonalizados.EstiloBotonPildora(btnCancelar, "#bc4749", 2, "#bc4749");
            BotonesPersonalizados.EstiloBotonPildora(btnGuardar, "#98c1d9", 2, "#98c1d9");
        }

    }
}