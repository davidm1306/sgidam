using MySql.Data.MySqlClient;
using sgidam.Data;
using System;
using System.Collections.Generic;
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
    public partial class MostrarProveedores : Form
    {
        public MostrarProveedores()
        {
            InitializeComponent();


            dgvProveedores.AutoGenerateColumns = false;


            this.Load += MostrarProveedores_Load;
            chkOcultarInactivos.CheckedChanged += (s, e) => CargarProveedores();
            btnBuscar.Click += btnBuscar_Click;
            dgvProveedores.SelectionChanged += DgvProveedores_SelectionChanged;
            btnCerrar.Click += btnCerrar_Click;
        }


        private void MostrarProveedores_Load(object sender, EventArgs e)
        {
            ConfigurarColumnas();
            CargarProveedores();
            BotonesPersonalizados.EstiloBotonPildora(btnBuscar, "#98c1d9", 2, "#98c1d9");
            BotonesPersonalizados.EstiloBotonPildora(btnEditar, "#98c1d9", 2, "#98c1d9");
            BotonesPersonalizados.EstiloBotonPildora(btnCerrar, "#bc4749", 2, "#bc4749");

        }

        private void ConfigurarColumnas()
        {
            dgvProveedores.Columns.Clear();


            dgvProveedores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id_proveedor",
                HeaderText = "RIF",
                DataPropertyName = "id_proveedor",
                Width = 120
            });


            dgvProveedores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nombre_proveedor",
                HeaderText = "Nombre",
                DataPropertyName = "nombre_proveedor",
                Width = 200
            });


            dgvProveedores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "correo_proveedor",
                HeaderText = "Correo",
                DataPropertyName = "correo_proveedor",
                Width = 150
            });


            dgvProveedores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "telefono_proveedor",
                HeaderText = "Teléfono",
                DataPropertyName = "telefono_proveedor",
                Width = 120
            });


            dgvProveedores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "direccion_proveedor",
                HeaderText = "Dirección",
                DataPropertyName = "direccion_proveedor",
                Width = 200
            });


            dgvProveedores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "estatus_desc",
                HeaderText = "Estatus",
                DataPropertyName = "estatus_desc",
                Width = 80
            });
        }

        private void CargarProveedores()
        {

            string query = @"
                SELECT 
                    p.id_proveedor,
                    p.nombre_proveedor,
                    p.correo_proveedor,
                    p.telefono_proveedor,
                    p.direccion_proveedor,
                    e.tipo_status AS estatus_desc
                FROM proveedores p
                INNER JOIN estatus e ON p.estatus = e.id_estatus
                WHERE 1=1
            ";

            var parametros = new List<MySqlParameter>();


            if (chkOcultarInactivos.Checked)
            {
                query += " AND p.estatus = @estatusActivo";
                parametros.Add(new MySqlParameter("@estatusActivo", 1));
            }


            string busqueda = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(busqueda) && busqueda != "Buscar por nombre o RIF...")
            {
                query += " AND (p.id_proveedor LIKE @busqueda OR p.nombre_proveedor LIKE @busqueda)";
                parametros.Add(new MySqlParameter("@busqueda", "%" + busqueda + "%"));
            }

            query += " ORDER BY p.nombre_proveedor";


            DataTable dt = Utilbdd.EjecutarConsulta(query, parametros.ToArray());
            dgvProveedores.DataSource = dt;


            if (dt.Rows.Count == 0)
            {
                lstProductos.DataSource = null;
            }
        }

        private void DgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null)
            {
                lstProductos.DataSource = null;
                return;
            }

            string idProveedor = dgvProveedores.CurrentRow.Cells["id_proveedor"].Value?.ToString();
            if (string.IsNullOrEmpty(idProveedor))
            {
                lstProductos.DataSource = null;
                return;
            }

            CargarProductosDelProveedor(idProveedor);
        }

        private void CargarProductosDelProveedor(string idProveedor)
        {
            string query = @"
                SELECT p.nombre_producto
                FROM lista_proveedores lp
                INNER JOIN productos p ON lp.id_producto = p.id_producto
                WHERE lp.id_proveedor = @idProveedor
                ORDER BY p.nombre_producto
            ";

            var param = new MySqlParameter("@idProveedor", idProveedor);
            DataTable dt = Utilbdd.EjecutarConsulta(query, new[] { param });

            
            List<string> productos = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                productos.Add(row["nombre_producto"].ToString());
            }

            lstProductos.DataSource = productos;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un proveedor para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string idProveedor = dgvProveedores.CurrentRow.Cells["id_proveedor"].Value?.ToString();

            if (string.IsNullOrEmpty(idProveedor))
                return;

            
            using (var frmEditar = new EditarProveedor(idProveedor))
            {
                if (frmEditar.ShowDialog() == DialogResult.OK)
                {
                    
                    CargarProveedores();
                    lstProductos.DataSource = null;
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void Refrescar()
        {
            CargarProveedores();
        }
    }
}
