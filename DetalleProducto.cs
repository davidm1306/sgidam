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
    public partial class DetalleProducto : Form
    {
        private int idProducto;

        public DetalleProducto(int idProducto)
        {
            InitializeComponent();
            this.idProducto = idProducto;
            CargarDetalle();
        }
        private void DetalleProducto_Load(object sender, EventArgs e)
        {
            BotonesPersonalizados.EstiloBotonPildora(btnCerrar, "#bc4749", 2, "#bc4749");
        }

        private void CargarDetalle()
        {
            string query = @"
                SELECT 
                    p.nombre_producto,
                    p.codigo_barras,
                    p.stock,
                    p.stock_minimo,
                    p.precio_compra,
                    p.precio_venta,
                    p.imagen_producto,
                    m.nombre_marca AS marca,
                    c.nombre_categoria AS categoria,
                    e.tipo_status AS estatus
                FROM productos p
                LEFT JOIN marcas m ON p.id_marca = m.id_marca
                LEFT JOIN categorias c ON p.id_categoria = c.id_categoria
                LEFT JOIN estatus e ON p.estatus = e.id_estatus
                WHERE p.id_producto = @idProducto 
            ";

            var parametros = new MySqlParameter[] { new MySqlParameter("@idProducto", idProducto) };
            DataTable dt = Utilbdd.EjecutarConsulta(query, parametros);


            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                lblNombre.Text = row["nombre_producto"].ToString();
                lblCodigo.Text = row["codigo_barras"].ToString();
                lblMarca.Text = row["marca"].ToString();
                lblCategoria.Text = row["categoria"].ToString();
                lblStock.Text = row["stock"].ToString();
                lblStockMinimo.Text = row["stock_minimo"].ToString();
                lblPrecioCompra.Text = Convert.ToDecimal(row["precio_compra"]).ToString("C2");
                lblPrecioVenta.Text = Convert.ToDecimal(row["precio_venta"]).ToString("C2");
                lblEstatus.Text = row["estatus"].ToString();


                string nombreImagen = row["imagen_producto"]?.ToString();
                if (!string.IsNullOrEmpty(nombreImagen))
                {
                    
                    string rutaImagen = Path.Combine(Application.StartupPath, "Images", nombreImagen);
                    if (File.Exists(rutaImagen))
                    {
                        pbImagen.Image = Image.FromFile(rutaImagen);
                    }
                    else
                    {
                        
                        pbImagen.Image = null; 
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encontró el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
