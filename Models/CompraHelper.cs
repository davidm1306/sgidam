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
    public static class CompraHelper
    {

        public static DataTable ObtenerEstatus()
        {
            string query = "SELECT id_estatus, tipo_status FROM estatus ORDER BY tipo_status";
            return Utilbdd.EjecutarConsulta(query);
        }


        public static DataTable ObtenerProveedores()
        {
            string query = "SELECT id_proveedor, nombre_proveedor FROM proveedores WHERE estatus = 1 ORDER BY nombre_proveedor";
            return Utilbdd.EjecutarConsulta(query);
        }

      
        public static DataTable ObtenerProductos()
        {
            string query = "SELECT id_producto, nombre_producto, precio_compra FROM productos WHERE estatus = 1 ORDER BY nombre_producto";
            return Utilbdd.EjecutarConsulta(query);
        }

       
        public static DataRow ObtenerProductoPorId(int idProducto)
        {
            string query = "SELECT id_producto, nombre_producto, precio_compra FROM productos WHERE id_producto = @id";
            var parametros = Utilbdd.CrearParametros(new Dictionary<string, object> { { "id", idProducto } });
            DataTable dt = Utilbdd.EjecutarConsulta(query, parametros);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public static DataTable ObtenerProductosPorProveedor(string idProveedor)
        {
            if (string.IsNullOrEmpty(idProveedor))
                return new DataTable();

            string query = @"
                SELECT 
                    p.id_producto, 
                    p.nombre_producto, 
                    lp.precio_proveedor
                FROM productos p
                INNER JOIN lista_proveedores lp ON p.id_producto = lp.id_producto
                WHERE p.estatus = 1 
                  AND lp.estatus = 1 
                  AND lp.id_proveedor = @idProveedor
                ORDER BY p.nombre_producto
            ";

            var parametros = new MySqlParameter[]
            {
        new MySqlParameter("@idProveedor", idProveedor)
            };

            return Utilbdd.EjecutarConsulta(query, parametros);
        }

        public static bool RegistrarCompra(Compra compra)
        {
            
            if (compra.Detalles == null || compra.Detalles.Count == 0)
                throw new Exception("La compra debe tener al menos un producto.");

            if (string.IsNullOrWhiteSpace(compra.IdProveedor))
                throw new Exception("Debes seleccionar un proveedor.");

            int idUsuario = Global.UsuarioSesion.id_usuario;

            using (MySqlConnection conn = new MySqlConnection(Utilbdd.ObtenerCadenaConexion()))
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        
                        string queryCabecera = @"
                            INSERT INTO compras (id_proveedor, fecha_compra, total_compra, estatus, id_usuario)
                            VALUES (@proveedor, @fecha, @total, @estatus, @usuario);
                            SELECT LAST_INSERT_ID();
                        ";

                        MySqlCommand cmdCabecera = new MySqlCommand(queryCabecera, conn, transaction);
                        cmdCabecera.Parameters.AddWithValue("@proveedor", compra.IdProveedor);
                        cmdCabecera.Parameters.AddWithValue("@fecha", compra.FechaCompra);
                        cmdCabecera.Parameters.AddWithValue("@total", compra.TotalCompra);
                        cmdCabecera.Parameters.AddWithValue("@estatus", compra.Estatus ?? 1);
                        cmdCabecera.Parameters.AddWithValue("@usuario", idUsuario);

                        int idCompra = Convert.ToInt32(cmdCabecera.ExecuteScalar());


                        foreach (var detalle in compra.Detalles)
                        {
                            
                            string queryDetalle = @"
                                INSERT INTO detalles_compra (id_compra, id_producto, cantidad, costo_unitario)
                                VALUES (@idCompra, @idProducto, @cantidad, @costo);
                                SELECT LAST_INSERT_ID();
                            ";
                            MySqlCommand cmdDetalle = new MySqlCommand(queryDetalle, conn, transaction);
                            cmdDetalle.Parameters.AddWithValue("@idCompra", idCompra);
                            cmdDetalle.Parameters.AddWithValue("@idProducto", detalle.IdProducto);
                            cmdDetalle.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                            cmdDetalle.Parameters.AddWithValue("@costo", detalle.CostoUnitario);
                            int idDetalleCompra = Convert.ToInt32(cmdDetalle.ExecuteScalar());

                         
                            string updateStock = "UPDATE productos SET stock = stock + @cantidad WHERE id_producto = @id";
                            MySqlCommand cmdStock = new MySqlCommand(updateStock, conn, transaction);
                            cmdStock.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                            cmdStock.Parameters.AddWithValue("@id", detalle.IdProducto);
                            cmdStock.ExecuteNonQuery();

                        
                            string queryPorcentaje = "SELECT porcentaje_utilidad FROM productos WHERE id_producto = @id";
                            MySqlCommand cmdPorcentaje = new MySqlCommand(queryPorcentaje, conn, transaction);
                            cmdPorcentaje.Parameters.AddWithValue("@id", detalle.IdProducto);
                            object resultadoPorcentaje = cmdPorcentaje.ExecuteScalar();
                            decimal porcentajeUtilidad = resultadoPorcentaje != null ? Convert.ToDecimal(resultadoPorcentaje) : 0;

                          
                            decimal nuevoPrecioVenta = detalle.CostoUnitario * (1 + porcentajeUtilidad / 100);

                            
                            string updatePrecios = "UPDATE productos SET precio_compra = @precioCompra, precio_venta = @precioVenta WHERE id_producto = @id";
                            MySqlCommand cmdPrecios = new MySqlCommand(updatePrecios, conn, transaction);
                            cmdPrecios.Parameters.AddWithValue("@precioCompra", detalle.CostoUnitario);
                            cmdPrecios.Parameters.AddWithValue("@precioVenta", nuevoPrecioVenta);
                            cmdPrecios.Parameters.AddWithValue("@id", detalle.IdProducto);
                            cmdPrecios.ExecuteNonQuery();

                            
                            string insertKardex = @"
                                    INSERT INTO kardex (id_producto, id_usuario, tipo_movimiento, cantidad, costo_unitario, fecha_movimiento, id_detalle_compra)
                                    VALUES (@idProducto, @idUsuario, 1, @cantidad, @costo, NOW(), @idDetalleCompra);
                                ";
                            MySqlCommand cmdKardex = new MySqlCommand(insertKardex, conn, transaction);
                            cmdKardex.Parameters.AddWithValue("@idProducto", detalle.IdProducto);
                            cmdKardex.Parameters.AddWithValue("@idUsuario", idUsuario);
                            cmdKardex.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                            cmdKardex.Parameters.AddWithValue("@costo", detalle.CostoUnitario);
                            cmdKardex.Parameters.AddWithValue("@idDetalleCompra", idDetalleCompra);
                            cmdKardex.ExecuteNonQuery();
                        }


                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Error al registrar la compra: {ex.Message}", ex);
                    }
                }
            }
        }
    }
}
