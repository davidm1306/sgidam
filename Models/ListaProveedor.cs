using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sgidam.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace sgidam.Models
{
    public class ListaProveedor
    {
        public int IdListaProveedor { get; set; }
        public string IdProveedor { get; set; }
        public int IdProducto { get; set; }
        public decimal PrecioProveedor { get; set; }
        public int? Estatus { get; set; }

        
        public static DataTable ObtenerProveedores()
        {
            string query = "SELECT id_proveedor, nombre_proveedor FROM proveedores ORDER BY nombre_proveedor";
            return Utilbdd.EjecutarConsulta(query);
        }

       
        public static DataTable ObtenerProductos()
        {
            string query = "SELECT id_producto, nombre_producto FROM productos ORDER BY nombre_producto";
            return Utilbdd.EjecutarConsulta(query);
        }

        
        public static DataTable ObtenerEstatus()
        {
            string query = "SELECT id_estatus, tipo_status FROM estatus ORDER BY tipo_status";
            return Utilbdd.EjecutarConsulta(query);
        }

        
        public static bool Registrar(ListaProveedor nuevaRelacion)
        {
           
            nuevaRelacion.IdProveedor = TextoHelper.ToUpper(nuevaRelacion.IdProveedor);

            string query = @"
                INSERT INTO lista_proveedores 
                    (id_proveedor, id_producto, precio_proveedor, estatus)
                VALUES 
                    (@idProveedor, @idProducto, @precio, @estatus)
            ";

            var parametros = Utilbdd.CrearParametros(new Dictionary<string, object>
            {
                { "idProveedor", nuevaRelacion.IdProveedor },
                { "idProducto", nuevaRelacion.IdProducto },
                { "precio", nuevaRelacion.PrecioProveedor },
                { "estatus", nuevaRelacion.Estatus ?? 1 }
            });

            try
            {
                int filas = Utilbdd.EjecutarComando(query, parametros);
                return filas > 0;
            }
            catch (MySqlException ex)
            {
                
                if (ex.Number == 1062)
                {
                    throw new Exception("Ya existe un registro para este proveedor y producto. Si deseas actualizar el precio, usa la opción de edición.");
                }
                throw;
            }
        }

        
        public static DataTable ListarRelaciones()
        {
            string query = @"
                SELECT lp.id_lista_proveedor, pv.id_proveedor, pv.nombre_proveedor, 
                       pr.id_producto, pr.nombre_producto, lp.precio_proveedor, e.tipo_status
                FROM lista_proveedores lp
                INNER JOIN proveedores pv ON lp.id_proveedor = pv.id_proveedor
                INNER JOIN productos pr ON lp.id_producto = pr.id_producto
                INNER JOIN estatus e ON lp.estatus = e.id_estatus
                ORDER BY pv.nombre_proveedor, pr.nombre_producto
            ";
            return Utilbdd.EjecutarConsulta(query);
        }
    }
}
