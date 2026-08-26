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
using MySql.Data.MySqlClient;

namespace sgidam
{


    public partial class AdministrarUsuarios : Form
    {
        public AdministrarUsuarios()
        {
            InitializeComponent();
            this.Load += AdministrarUsuarios_Load;

        }

        private void AdministrarUsuarios_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CargarUsuarios();
            BotonesPersonalizados.EstiloBotonPildora(btnCambiarEstatus, "#98c1d9", 2, "#98c1d9");
            BotonesPersonalizados.EstiloBotonPildora(btnCambiarRol, "#98c1d9", 2, "#98c1d9");
        }

        private void ConfigurarDataGridView()
        {
            dgvUsuarios.AutoGenerateColumns = false; // Imprescindible para columnas manuales
            dgvUsuarios.Columns.Clear();


            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "id_usuario";
            colId.HeaderText = "ID";
            colId.DataPropertyName = "id_usuario";
            colId.Visible = false;
            dgvUsuarios.Columns.Add(colId);


            DataGridViewTextBoxColumn colUsuario = new DataGridViewTextBoxColumn();
            colUsuario.Name = "nombre_usuario";
            colUsuario.HeaderText = "Usuario";
            colUsuario.DataPropertyName = "nombre_usuario";
            colUsuario.Width = 120;
            dgvUsuarios.Columns.Add(colUsuario);


            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "nombre_empleado";
            colNombre.HeaderText = "Nombre";
            colNombre.DataPropertyName = "nombre_empleado";
            colNombre.Width = 150;
            dgvUsuarios.Columns.Add(colNombre);


            DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
            colApellido.Name = "apellido_empleado";
            colApellido.HeaderText = "Apellido";
            colApellido.DataPropertyName = "apellido_empleado";
            colApellido.Width = 150;
            dgvUsuarios.Columns.Add(colApellido);


            DataGridViewTextBoxColumn colRol = new DataGridViewTextBoxColumn();
            colRol.Name = "rol";
            colRol.HeaderText = "Rol";
            colRol.DataPropertyName = "rol";
            colRol.Width = 120;
            dgvUsuarios.Columns.Add(colRol);


            DataGridViewTextBoxColumn colEstatus = new DataGridViewTextBoxColumn();
            colEstatus.Name = "estatus";
            colEstatus.HeaderText = "Estatus";
            colEstatus.DataPropertyName = "estatus";
            colEstatus.Width = 100;
            dgvUsuarios.Columns.Add(colEstatus);


            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void CargarUsuarios()
        {
            string query = @"
                SELECT 
                    id_usuario,
                    nombre_usuario,
                    nombre_empleado,
                    apellido_empleado,
                    rol,
                    e.tipo_status AS estatus
                FROM usuarios u
                LEFT JOIN estatus e ON u.estatus = e.id_estatus
                ORDER BY u.nombre_usuario;
            ";

            DataTable dt = Utilbdd.EjecutarConsulta(query);
            dgvUsuarios.DataSource = dt;
        }

        private void btnCambiarEstatus_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null) return;

            int idUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["id_usuario"].Value);
            string estatusActual = dgvUsuarios.CurrentRow.Cells["estatus"].Value.ToString();

            int nuevoEstatus = estatusActual == "ACTIVO" ? 2 : 1;

            string query = "UPDATE usuarios SET estatus = @estatus WHERE id_usuario = @id";
            var parametros = Utilbdd.CrearParametros(new Dictionary<string, object>
            {
                { "estatus", nuevoEstatus },
                { "id", idUsuario }
            });

            int filas = Utilbdd.EjecutarComando(query, parametros);
            if (filas > 0)
            {
                MessageBox.Show("Estado del usuario actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuarios(); // Refrescar
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el estado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCambiarRol_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null) return;

            int idUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["id_usuario"].Value);

            
            string rolActual = dgvUsuarios.CurrentRow.Cells["rol"].Value?.ToString() ?? "";

            
            List<string> roles = new List<string> { "ADMINISTRADOR", "VENDEDOR"};

            string nuevoRol = "";

            using (var dialog = new InputDialog(
                title: "Cambiar rol de usuario",
                prompt: "Seleccione el nuevo rol:",
                options: roles,
                defaultSelected: rolActual))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    nuevoRol = TextoHelper.ToUpper(dialog.Answer);
                }
                else
                    return;
            }

            if (string.IsNullOrWhiteSpace(nuevoRol)) return;

            string query = "UPDATE usuarios SET rol = @rol WHERE id_usuario = @id";
            var parametros = Utilbdd.CrearParametros(new Dictionary<string, object>
            {
                { "rol", nuevoRol },
                { "id", idUsuario }
            });

            int filas = Utilbdd.EjecutarComando(query, parametros);

            if (filas > 0)
            {
                MessageBox.Show("Rol actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuarios();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdministrarUsuarios_Load_1(object sender, EventArgs e)
        {

        }
    }
}
