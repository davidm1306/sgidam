using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using sgidam.Data;

namespace sgidam.Models
{
    public static class DevolucionHelper
    {
        public static bool RegistrarDevolucion(Devolucion devolucion, List<DetalleVenta> productosNoDevueltos)
        {
            using (MySqlConnection conn = new MySqlConnection(Utilbdd.ObtenerCadenaConexion()))
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        int idUsuario = devolucion.IdUsuario;

                    
                        string updateEstatus = "UPDATE ventas SET estatus = 3 WHERE id_venta = @idVenta";
                        MySqlCommand cmdUpdate = new MySqlCommand(updateEstatus, conn, transaction);
                        cmdUpdate.Parameters.AddWithValue("@idVenta", devolucion.IdVentaOriginal);
                        cmdUpdate.ExecuteNonQuery();

                    
                        string queryCabecera = @"
                            INSERT INTO devoluciones (id_venta_original, id_venta_nueva, fecha_devolucion, id_usuario, motivo, estatus)
                            VALUES (@idVentaOriginal, NULL, @fecha, @idUsuario, @motivo, 1);
                            SELECT LAST_INSERT_ID();
                        ";
                        MySqlCommand cmdCabecera = new MySqlCommand(queryCabecera, conn, transaction);
                        cmdCabecera.Parameters.AddWithValue("@idVentaOriginal", devolucion.IdVentaOriginal);
                        cmdCabecera.Parameters.AddWithValue("@fecha", devolucion.FechaDevolucion);
                        cmdCabecera.Parameters.AddWithValue("@idUsuario", idUsuario);
                        cmdCabecera.Parameters.AddWithValue("@motivo", devolucion.Motivo ?? (object)DBNull.Value);
                        int idDevolucion = Convert.ToInt32(cmdCabecera.ExecuteScalar());

                       
                        foreach (var detalle in devolucion.Detalles)
                        {
                            
                            string queryLotesVenta = @"
                                SELECT vl.id_lote, vl.cantidad_usada, l.costo_unitario, l.cantidad_disponible
                                FROM venta_lotes vl
                                INNER JOIN lotes l ON vl.id_lote = l.id_lote
                                INNER JOIN detalles_venta dv ON vl.id_detalle_venta = dv.id_detalle_venta
                                WHERE dv.id_venta = @idVentaOriginal 
                                  AND dv.id_producto = @idProducto
                                ORDER BY l.fecha_entrada ASC
                            ";
                            MySqlCommand cmdLotesVenta = new MySqlCommand(queryLotesVenta, conn, transaction);
                            cmdLotesVenta.Parameters.AddWithValue("@idVentaOriginal", devolucion.IdVentaOriginal);
                            cmdLotesVenta.Parameters.AddWithValue("@idProducto", detalle.IdProducto);

                            List<VentaLoteOriginal> lotesOriginales = new List<VentaLoteOriginal>();
                            using (var reader = cmdLotesVenta.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    lotesOriginales.Add(new VentaLoteOriginal
                                    {
                                        IdLote = reader.GetInt32(0),
                                        CantidadUsada = reader.GetInt32(1),
                                        CostoUnitario = reader.GetDecimal(2),
                                        CantidadDisponible = reader.GetInt32(3)
                                    });
                                }
                            }

                            if (lotesOriginales.Count == 0)
                                throw new Exception($"No se encontraron lotes originales para el producto '{detalle.IdProducto}' en la venta {devolucion.IdVentaOriginal}.");

                            
                            int cantidadRestante = detalle.CantidadDevuelta;
                            List<ActualizacionLoteOriginal> actualizaciones = new List<ActualizacionLoteOriginal>();

                            foreach (var loteOrig in lotesOriginales)
                            {
                                if (cantidadRestante <= 0) break;

                                int tomar = Math.Min(cantidadRestante, loteOrig.CantidadUsada);
                                if (tomar > 0)
                                {
                                    actualizaciones.Add(new ActualizacionLoteOriginal
                                    {
                                        IdLote = loteOrig.IdLote,
                                        NuevaCantidad = loteOrig.CantidadDisponible + tomar,
                                        CantidadDevuelta = tomar,
                                        CostoUnitario = loteOrig.CostoUnitario
                                    });
                                    cantidadRestante -= tomar;
                                }
                            }

                            if (cantidadRestante > 0)
                                throw new Exception($"No hay suficiente cantidad en los lotes originales para devolver {cantidadRestante} unidades del producto {detalle.IdProducto}.");

                            
                            string updateLoteOriginal = "UPDATE lotes SET cantidad_disponible = @nuevaCantidad WHERE id_lote = @idLote";
                            foreach (var act in actualizaciones)
                            {
                                MySqlCommand cmdUpdateLote = new MySqlCommand(updateLoteOriginal, conn, transaction);
                                cmdUpdateLote.Parameters.AddWithValue("@nuevaCantidad", act.NuevaCantidad);
                                cmdUpdateLote.Parameters.AddWithValue("@idLote", act.IdLote);
                                cmdUpdateLote.ExecuteNonQuery();
                            }

                            
                            string updateStock = "UPDATE productos SET stock = stock + @cantidad WHERE id_producto = @id";
                            MySqlCommand cmdStock = new MySqlCommand(updateStock, conn, transaction);
                            cmdStock.Parameters.AddWithValue("@cantidad", detalle.CantidadDevuelta);
                            cmdStock.Parameters.AddWithValue("@id", detalle.IdProducto);
                            cmdStock.ExecuteNonQuery();

                            decimal costoKardex = actualizaciones.Count > 0 ? actualizaciones[0].CostoUnitario : 0;
                            string insertKardex = @"
                                INSERT INTO kardex (id_producto, id_usuario, tipo_movimiento, cantidad, costo_unitario, fecha_movimiento, id_devolucion)
                                VALUES (@idProducto, @idUsuario, 5, @cantidad, @costo, NOW(), @idDevolucion);
                            ";
                            MySqlCommand cmdKardex = new MySqlCommand(insertKardex, conn, transaction);
                            cmdKardex.Parameters.AddWithValue("@idProducto", detalle.IdProducto);
                            cmdKardex.Parameters.AddWithValue("@idUsuario", idUsuario);
                            cmdKardex.Parameters.AddWithValue("@cantidad", detalle.CantidadDevuelta);
                            cmdKardex.Parameters.AddWithValue("@costo", costoKardex);
                            cmdKardex.Parameters.AddWithValue("@idDevolucion", idDevolucion);
                            cmdKardex.ExecuteNonQuery();

                           
                            string queryDetalleDev = @"
                                INSERT INTO devoluciones_detalle (id_devolucion, id_producto, cantidad_devuelta, costo_unitario, id_lote_origen, id_lote_creado)
                                VALUES (@idDevolucion, @idProducto, @cantidad, @costo, @idLoteOrigen, NULL);
                            ";
                            MySqlCommand cmdDetalleDev = new MySqlCommand(queryDetalleDev, conn, transaction);
                            cmdDetalleDev.Parameters.AddWithValue("@idDevolucion", idDevolucion);
                            cmdDetalleDev.Parameters.AddWithValue("@idProducto", detalle.IdProducto);
                            cmdDetalleDev.Parameters.AddWithValue("@cantidad", detalle.CantidadDevuelta);
                            cmdDetalleDev.Parameters.AddWithValue("@costo", costoKardex);
                            cmdDetalleDev.Parameters.AddWithValue("@idLoteOrigen", actualizaciones.Count > 0 ? actualizaciones[0].IdLote : (object)DBNull.Value);
                            cmdDetalleDev.ExecuteNonQuery();
                        }

                   
                        if (productosNoDevueltos != null && productosNoDevueltos.Count > 0)
                        {
                           
                            string queryCliente = "SELECT id_cliente FROM ventas WHERE id_venta = @idVenta";
                            MySqlCommand cmdCliente = new MySqlCommand(queryCliente, conn, transaction);
                            cmdCliente.Parameters.AddWithValue("@idVenta", devolucion.IdVentaOriginal);
                            string idCliente = cmdCliente.ExecuteScalar()?.ToString();

                            if (string.IsNullOrEmpty(idCliente))
                                throw new Exception("No se encontró el cliente de la venta original.");

                           
                            Venta nuevaVenta = new Venta
                            {
                                FechaVenta = DateTime.Now,
                                IdCliente = idCliente,
                                Estatus = 1,
                                IdUsuario = idUsuario,
                                Detalles = productosNoDevueltos
                            };

                        
                            decimal subtotal = 0;
                            foreach (var det in productosNoDevueltos)
                            {
                                subtotal += det.Cantidad * det.PrecioUnitarioVenta;
                            }
                            nuevaVenta.SubTotal = subtotal;
                            nuevaVenta.Impuestos = subtotal * 0.16m;
                            nuevaVenta.TotalVenta = subtotal + (nuevaVenta.Impuestos ?? 0);

                            
                            string queryMaxFactura = "SELECT COALESCE(MAX(numero_factura), 0) + 1 FROM ventas";
                            MySqlCommand cmdMax = new MySqlCommand(queryMaxFactura, conn, transaction);
                            nuevaVenta.NumeroFactura = Convert.ToInt32(cmdMax.ExecuteScalar());

                           
                            nuevaVenta.NumeroControl = $"FAC-{DateTime.Now.Year}-{nuevaVenta.NumeroFactura:D6}";

                            int idVentaNueva = InsertarVentaEnTransaccion(conn, transaction, nuevaVenta);

                            
                            string updateDevolucion = "UPDATE devoluciones SET id_venta_nueva = @idVentaNueva WHERE id_devolucion = @idDevolucion";
                            MySqlCommand cmdUpdateDev = new MySqlCommand(updateDevolucion, conn, transaction);
                            cmdUpdateDev.Parameters.AddWithValue("@idVentaNueva", idVentaNueva);
                            cmdUpdateDev.Parameters.AddWithValue("@idDevolucion", idDevolucion);
                            cmdUpdateDev.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Error al registrar la devolución: {ex.Message}", ex);
                    }
                }
            }
        }

       
        private static int InsertarVentaEnTransaccion(MySqlConnection conn, MySqlTransaction transaction, Venta venta)
        {
          
            string queryCabecera = @"
                INSERT INTO ventas (fecha_venta, total_venta, estatus, id_usuario, id_cliente, numero_factura, sub_total, impuestos, numero_control)
                VALUES (@fecha, @total, @estatus, @usuario, @idCliente, @numFactura, @subTotal, @impuestos, @numControl);
                SELECT LAST_INSERT_ID();
            ";
            MySqlCommand cmdCabecera = new MySqlCommand(queryCabecera, conn, transaction);
            cmdCabecera.Parameters.AddWithValue("@fecha", venta.FechaVenta);
            cmdCabecera.Parameters.AddWithValue("@total", venta.TotalVenta);
            cmdCabecera.Parameters.AddWithValue("@estatus", venta.Estatus ?? 1);
            cmdCabecera.Parameters.AddWithValue("@usuario", venta.IdUsuario);
            cmdCabecera.Parameters.AddWithValue("@idCliente", venta.IdCliente ?? (object)DBNull.Value);
            cmdCabecera.Parameters.AddWithValue("@numFactura", venta.NumeroFactura);
            cmdCabecera.Parameters.AddWithValue("@subTotal", venta.SubTotal);
            cmdCabecera.Parameters.AddWithValue("@impuestos", venta.Impuestos ?? (object)DBNull.Value);
            cmdCabecera.Parameters.AddWithValue("@numControl", venta.NumeroControl ?? (object)DBNull.Value);
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

              
                VentaHelper.ActualizarStockYKardex(conn, transaction, detalle.IdProducto, detalle.Cantidad, idDetalleVenta, venta.FechaVenta);
            }

            return idVenta;
        }

        
        private class VentaLoteOriginal
        {
            public int IdLote { get; set; }
            public int CantidadUsada { get; set; }
            public decimal CostoUnitario { get; set; }
            public int CantidadDisponible { get; set; }
        }

        private class ActualizacionLoteOriginal
        {
            public int IdLote { get; set; }
            public int NuevaCantidad { get; set; }
            public int CantidadDevuelta { get; set; }
            public decimal CostoUnitario { get; set; }
        }
    }
}