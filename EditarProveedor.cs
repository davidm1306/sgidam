using MySql.Data.MySqlClient;
using sgidam.Data;
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
    public partial class EditarProveedor : Form
    {
        private string idProveedor;

        public EditarProveedor(string id)
        {
            InitializeComponent();
            idProveedor = id;
            CargarDatos();
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

        private void EditarProveedor_Load(object sender, EventArgs e)
        {
            BotonesPersonalizados.EstiloBotonPildora(btnCancelar, "#bc4749", 2, "#bc4749");
            BotonesPersonalizados.EstiloBotonPildora(btnGuardar, "#98c1d9", 2, "#98c1d9");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del proveedor es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
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
                MessageBox.Show("Proveedor actualizado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el proveedor.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
