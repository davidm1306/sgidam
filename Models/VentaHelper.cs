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
    public static class VentaHelper
    {

        public static DataTable ObtenerEstatus()
        {
            string query = "SELECT id_estatus, tipo_status FROM estatus ORDER BY tipo_status";
            return Utilbdd.EjecutarConsulta(query);
        }


        public static DataTable ObtenerProductos()
        {
            string query = "SELECT id_producto, nombre_producto, precio_venta FROM productos WHERE estatus = 1 ORDER BY nombre_producto";
            return Utilbdd.EjecutarConsulta(query);
        }

      
        public static DataRow ObtenerProductoPorId(int idProducto)
        {
            string query = "SELECT id_producto, nombre_producto, precio_venta FROM productos WHERE id_producto = @id";
            var parametros = Utilbdd.CrearParametros(new Dictionary<string, object> { { "id", idProducto } });
            DataTable dt = Utilbdd.EjecutarConsulta(query, parametros);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        
        public static bool RegistrarVenta(Venta venta)
        {
            if (venta.Detalles == null || venta.Detalles.Count == 0)
                throw new Exception("La venta debe tener al menos un producto.");

            using (MySqlConnection conn = new MySqlConnection(Utilbdd.ObtenerCadenaConexion()))
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        
                        string queryCabecera = @"
                            INSERT INTO ventas (fecha_venta, total_venta, estatus, id_usuario)
                            VALUES (@fecha, @total, @estatus, @usuario);
                            SELECT LAST_INSERT_ID();
                        ";
                        MySqlCommand cmdCabecera = new MySqlCommand(queryCabecera, conn, transaction);
                        cmdCabecera.Parameters.AddWithValue("@fecha", venta.FechaVenta);
                        cmdCabecera.Parameters.AddWithValue("@total", venta.TotalVenta);
                        cmdCabecera.Parameters.AddWithValue("@estatus", venta.Estatus ?? 1);
                        cmdCabecera.Parameters.AddWithValue("@usuario", Global.UsuarioSesion.id_usuario);

                        int idVenta = Convert.ToInt32(cmdCabecera.ExecuteScalar());

                        
                        foreach (var detalle in venta.Detalles)
                        {
                            
                            string queryDetalle = @"
                                INSERT INTO detalles_venta (id_venta, id_producto, cantidad, precio_unitario_venta)
                                VALUES (@idVenta, @idProducto, @cantidad, @precio);
                                SELECT LAST_INSERT_ID();
                            ";
                            MySqlCommand cmdDetalle = new MySqlCommand(queryDetalle, conn, transaction);
                            cmdDetalle.Parameters.AddWithValue("@idVenta", idVenta);
                            cmdDetalle.Parameters.AddWithValue("@idProducto", detalle.IdProducto);
                            cmdDetalle.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                            cmdDetalle.Parameters.AddWithValue("@precio", detalle.PrecioUnitarioVenta);

                            int idDetalleVenta = Convert.ToInt32(cmdDetalle.ExecuteScalar());

                            
                            ActualizarStockYKardex(conn, transaction, detalle.IdProducto, detalle.Cantidad, idDetalleVenta);
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }


        private static void ActualizarStockYKardex(MySqlConnection conn, MySqlTransaction transaction,
                                            int idProducto, int cantidadVendida, int idDetalleVenta)
        {
            // 1. Obtener el nombre y el costo del producto
            string queryDatos = "SELECT nombre_producto, precio_compra FROM productos WHERE id_producto = @id";
            MySqlCommand cmdDatos = new MySqlCommand(queryDatos, conn, transaction);
            cmdDatos.Parameters.AddWithValue("@id", idProducto);

            string nombreProducto = "";
            decimal costoUnitario = 0;

            using (var reader = cmdDatos.ExecuteReader())
            {
                if (!reader.Read())
                    throw new Exception($"No se encontró el producto con ID {idProducto}.");
                nombreProducto = reader.GetString(0);
                costoUnitario = reader.GetDecimal(1);
            }

            // 2. Actualizar stock verificando que haya suficiente
            string updateStock = "UPDATE productos SET stock = stock - @cantidad WHERE id_producto = @id AND stock >= @cantidad";
            MySqlCommand cmdStock = new MySqlCommand(updateStock, conn, transaction);
            cmdStock.Parameters.AddWithValue("@cantidad", cantidadVendida);
            cmdStock.Parameters.AddWithValue("@id", idProducto);

            int filasAfectadas = cmdStock.ExecuteNonQuery();

            if (filasAfectadas == 0)
            {
                // Si no se actualizó, significa que no hay suficiente stock
                throw new Exception($"No se pudo actualizar el stock del producto '{nombreProducto}'. Stock insuficiente.");
            }

            // 3. Insertar en kardex (usando el costoUnitario obtenido)
            string insertKardex = @"
                INSERT INTO kardex (id_producto, id_usuario, tipo_movimiento, cantidad, costo_unitario, fecha_movimiento, id_detalle_venta)
                VALUES (@idProducto, @idUsuario, 2, @cantidad, @costo, NOW(), @idDetalleVenta);
            ";
            MySqlCommand cmdKardex = new MySqlCommand(insertKardex, conn, transaction);
            cmdKardex.Parameters.AddWithValue("@idProducto", idProducto);
            cmdKardex.Parameters.AddWithValue("@idUsuario", Global.UsuarioSesion.id_usuario);
            cmdKardex.Parameters.AddWithValue("@cantidad", cantidadVendida);
            cmdKardex.Parameters.AddWithValue("@costo", costoUnitario);
            cmdKardex.Parameters.AddWithValue("@idDetalleVenta", idDetalleVenta);
            cmdKardex.ExecuteNonQuery();
        }


        private static decimal ObtenerCostoUnitarioProducto(MySqlConnection conn, MySqlTransaction transaction, int idProducto)
        {
            
            string query = "SELECT precio_compra FROM productos WHERE id_producto = @id";
            MySqlCommand cmd = new MySqlCommand(query, conn, transaction);
            cmd.Parameters.AddWithValue("@id", idProducto);
            object result = cmd.ExecuteScalar();
            if (result == DBNull.Value)
                throw new Exception($"No se pudo obtener el costo del producto con ID {idProducto}");
            return Convert.ToDecimal(result);
        }
    }
}