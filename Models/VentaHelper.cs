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

                        string checkFactura = "SELECT COUNT(*) FROM ventas WHERE numero_factura = @numFactura";
                        MySqlCommand cmdCheck = new MySqlCommand(checkFactura, conn, transaction);
                        cmdCheck.Parameters.AddWithValue("@numFactura", venta.NumeroFactura);
                        int count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                        if (count > 0)
                            throw new Exception($"El número de factura {venta.NumeroFactura} ya existe.");

                        string queryCabecera = @"
                        INSERT INTO ventas (
                            fecha_venta, 
                            total_venta, 
                            estatus, 
                            id_usuario,
                            id_cliente,
                            numero_factura,
                            sub_total,
                            impuestos,
                            numero_control
                        ) VALUES (
                            @fecha, 
                            @total, 
                            @estatus, 
                            @usuario,
                            @idCliente,
                            @numFactura,
                            @subTotal,
                            @impuestos,
                            @numControl
                        );
                        SELECT LAST_INSERT_ID();
                    ";
                        MySqlCommand cmdCabecera = new MySqlCommand(queryCabecera, conn, transaction);
                        cmdCabecera.Parameters.AddWithValue("@fecha", venta.FechaVenta);
                        cmdCabecera.Parameters.AddWithValue("@total", venta.TotalVenta);
                        cmdCabecera.Parameters.AddWithValue("@estatus", venta.Estatus ?? 1);
                        cmdCabecera.Parameters.AddWithValue("@usuario", Global.UsuarioSesion.id_usuario);
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


                            ActualizarStockYKardex(conn, transaction, detalle.IdProducto, detalle.Cantidad, idDetalleVenta, venta.FechaVenta);
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

        public static void ActualizarStockYKardex(MySqlConnection conn, MySqlTransaction transaction,
                                            int idProducto, int cantidadVendida, int idDetalleVenta, DateTime fechaVenta)
        {

            string queryNombre = "SELECT nombre_producto FROM productos WHERE id_producto = @id";
            MySqlCommand cmdNombre = new MySqlCommand(queryNombre, conn, transaction);
            cmdNombre.Parameters.AddWithValue("@id", idProducto);
            string nombreProducto = cmdNombre.ExecuteScalar()?.ToString() ?? "Producto";


            string queryLotes = @"
                SELECT id_lote, cantidad_disponible, costo_unitario
                FROM lotes
                WHERE id_producto = @idProducto AND cantidad_disponible > 0
                ORDER BY fecha_entrada ASC
            ";
            MySqlCommand cmdLotes = new MySqlCommand(queryLotes, conn, transaction);
            cmdLotes.Parameters.AddWithValue("@idProducto", idProducto);

            List<LoteDisponible> lotes = new List<LoteDisponible>();
            using (var reader = cmdLotes.ExecuteReader())
            {
                while (reader.Read())
                {
                    lotes.Add(new LoteDisponible
                    {
                        IdLote = reader.GetInt32(0),
                        CantidadDisponible = reader.GetInt32(1),
                        CostoUnitario = reader.GetDecimal(2)
                    });
                }
            }

            if (lotes.Count == 0)
                throw new Exception($"No hay stock disponible del producto '{nombreProducto}'.");

            int cantidadRestante = cantidadVendida;
            decimal costoTotal = 0;
            int cantidadTomada = 0;
            List<ActualizacionLote> actualizaciones = new List<ActualizacionLote>();


            List<VentaLoteUsado> lotesUsados = new List<VentaLoteUsado>();

            foreach (var lote in lotes)
            {
                if (cantidadRestante <= 0) break;

                int tomar = Math.Min(cantidadRestante, lote.CantidadDisponible);
                if (tomar > 0)
                {

                    actualizaciones.Add(new ActualizacionLote
                    {
                        IdLote = lote.IdLote,
                        NuevaCantidad = lote.CantidadDisponible - tomar
                    });


                    lotesUsados.Add(new VentaLoteUsado
                    {
                        IdLote = lote.IdLote,
                        CantidadUsada = tomar
                    });

                    costoTotal += tomar * lote.CostoUnitario;
                    cantidadTomada += tomar;
                    cantidadRestante -= tomar;
                }
            }

            if (cantidadRestante > 0)
                throw new Exception($"Stock insuficiente del producto '{nombreProducto}'. Faltan {cantidadRestante} unidades.");

            decimal costoPromedio = costoTotal / cantidadTomada;

            string updateLote = "UPDATE lotes SET cantidad_disponible = @nuevaCantidad WHERE id_lote = @idLote";
            foreach (var act in actualizaciones)
            {
                MySqlCommand cmdUpdate = new MySqlCommand(updateLote, conn, transaction);
                cmdUpdate.Parameters.AddWithValue("@nuevaCantidad", act.NuevaCantidad);
                cmdUpdate.Parameters.AddWithValue("@idLote", act.IdLote);
                cmdUpdate.ExecuteNonQuery();
            }


            string insertVentaLote = @"
        INSERT INTO venta_lotes (id_detalle_venta, id_lote, cantidad_usada)
        VALUES (@idDetalleVenta, @idLote, @cantidad);
    ";
            foreach (var loteUsado in lotesUsados)
            {
                MySqlCommand cmdVentaLote = new MySqlCommand(insertVentaLote, conn, transaction);
                cmdVentaLote.Parameters.AddWithValue("@idDetalleVenta", idDetalleVenta);
                cmdVentaLote.Parameters.AddWithValue("@idLote", loteUsado.IdLote);
                cmdVentaLote.Parameters.AddWithValue("@cantidad", loteUsado.CantidadUsada);
                cmdVentaLote.ExecuteNonQuery();
            }


            string updateStock = "UPDATE productos SET stock = stock - @cantidad WHERE id_producto = @id AND stock >= @cantidad";
            MySqlCommand cmdStock = new MySqlCommand(updateStock, conn, transaction);
            cmdStock.Parameters.AddWithValue("@cantidad", cantidadVendida);
            cmdStock.Parameters.AddWithValue("@id", idProducto);
            int filasAfectadas = cmdStock.ExecuteNonQuery();
            if (filasAfectadas == 0)
                throw new Exception($"No se pudo actualizar el stock del producto '{nombreProducto}'. Stock insuficiente.");


            string insertKardex = @"
                INSERT INTO kardex (id_producto, id_usuario, tipo_movimiento, cantidad, costo_unitario, fecha_movimiento, id_detalle_venta)
                VALUES (@idProducto, @idUsuario, 2, @cantidad, @costo, @fechaMovimiento, @idDetalleVenta);
            ";
            MySqlCommand cmdKardex = new MySqlCommand(insertKardex, conn, transaction);
            cmdKardex.Parameters.AddWithValue("@idProducto", idProducto);
            cmdKardex.Parameters.AddWithValue("@idUsuario", Global.UsuarioSesion.id_usuario);
            cmdKardex.Parameters.AddWithValue("@cantidad", cantidadVendida);
            cmdKardex.Parameters.AddWithValue("@costo", costoPromedio);
            cmdKardex.Parameters.AddWithValue("@fechaMovimiento", fechaVenta);
            cmdKardex.Parameters.AddWithValue("@idDetalleVenta", idDetalleVenta);
            cmdKardex.ExecuteNonQuery();
        }

        private class VentaLoteUsado
        {
            public int IdLote { get; set; }
            public int CantidadUsada { get; set; }
        }

        private class LoteDisponible
        {
            public int IdLote { get; set; }
            public int CantidadDisponible { get; set; }
            public decimal CostoUnitario { get; set; }
        }

        private class ActualizacionLote
        {
            public int IdLote { get; set; }
            public int NuevaCantidad { get; set; }
        }

        public static DataRow ObtenerClientePorId(string idCliente)
        {
            string query = "SELECT nombre_cliente, direccion_cliente, telefono_cliente FROM clientes WHERE id_cliente = @id";
            var parametros = Utilbdd.CrearParametros(new Dictionary<string, object> { { "id", idCliente } });
            DataTable dt = Utilbdd.EjecutarConsulta(query, parametros);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }



        public static bool InsertarCliente(string id, string nombre, string direccion, string telefono)
        {
            string query = @"INSERT INTO clientes (id_cliente, nombre_cliente, direccion_cliente, telefono_cliente, estatus_cliente)
                     VALUES (@id, @nombre, @direccion, @telefono, 1)";
            var parametros = Utilbdd.CrearParametros(new Dictionary<string, object>
            {
                { "id", id },
                { "nombre", nombre },
                { "direccion", direccion },
                { "telefono", telefono }
            });
            return Utilbdd.EjecutarComando(query, parametros) > 0;
        }

        public static DataTable ObtenerClientes()
        {
            string query = "SELECT id_cliente, nombre_cliente FROM clientes WHERE estatus_cliente = 1 ORDER BY nombre_cliente";
            return Utilbdd.EjecutarConsulta(query);
        }

        public static DataTable ObtenerFacturasConFiltros(int? estatus, string idCliente, string numFactura, string numControl, DateTime fechaDesde, DateTime fechaHasta)
        {
            string query = @"
                SELECT 
                    v.id_venta,
                    v.numero_factura,
                    v.fecha_venta,
                    c.nombre_cliente AS cliente,
                    v.sub_total,
                    v.impuestos,
                    v.total_venta,
                    e.tipo_status AS estatus,
                    v.numero_control,
                    u.nombre_usuario AS usuario
                FROM ventas v
                INNER JOIN clientes c ON v.id_cliente = c.id_cliente
                INNER JOIN estatus e ON v.estatus = e.id_estatus
                INNER JOIN usuarios u ON v.id_usuario = u.id_usuario
                WHERE 1=1
            ";

            var parametros = new Dictionary<string, object>();

            if (estatus.HasValue)
            {
                query += " AND v.estatus = @estatus";
                parametros.Add("estatus", estatus.Value);
            }

            if (!string.IsNullOrEmpty(idCliente))
            {
                query += " AND v.id_cliente = @idCliente";
                parametros.Add("idCliente", idCliente);
            }

            if (!string.IsNullOrEmpty(numFactura))
            {
                query += " AND v.numero_factura LIKE @numFactura";
                parametros.Add("numFactura", $"%{numFactura}%");
            }

            if (!string.IsNullOrEmpty(numControl))
            {
                query += " AND v.numero_control LIKE @numControl";
                parametros.Add("numControl", $"%{numControl}%");
            }

            query += " AND v.fecha_venta BETWEEN @fechaDesde AND @fechaHasta";
            parametros.Add("fechaDesde", fechaDesde);
            parametros.Add("fechaHasta", fechaHasta);

            query += " ORDER BY v.fecha_venta DESC, v.numero_factura DESC";

            var parametrosArray = Utilbdd.CrearParametros(parametros);
            return Utilbdd.EjecutarConsulta(query, parametrosArray);
        }

        public static DataTable ObtenerDetalleFactura(int idVenta)
        {
            string query = @"
                SELECT 
                    v.id_venta,
                    v.numero_factura,
                    v.numero_control,
                    v.fecha_venta,
                    v.sub_total,
                    v.impuestos,
                    v.total_venta,
                    v.estatus,
                    e.tipo_status AS estatus_nombre,
                    v.id_cliente,
                    c.nombre_cliente,
                    c.direccion_cliente,
                    c.telefono_cliente,
                    u.nombre_usuario AS usuario
                FROM ventas v
                INNER JOIN clientes c ON v.id_cliente = c.id_cliente
                INNER JOIN estatus e ON v.estatus = e.id_estatus
                INNER JOIN usuarios u ON v.id_usuario = u.id_usuario
                WHERE v.id_venta = @idVenta
            ";
            var param = Utilbdd.CrearParametros(new Dictionary<string, object> { { "idVenta", idVenta } });
            DataTable dt = Utilbdd.EjecutarConsulta(query, param);
            return dt;
        }

        public static DataTable ObtenerDetallesFactura(int idVenta)
        {
            string query = @"
                SELECT 
                    dv.id_producto,
                    p.nombre_producto,
                    dv.cantidad,
                    dv.precio_unitario_venta,
                    dv.subtotal
                FROM detalles_venta dv
                INNER JOIN productos p ON dv.id_producto = p.id_producto
                WHERE dv.id_venta = @idVenta
            ";
            var param = Utilbdd.CrearParametros(new Dictionary<string, object> { { "idVenta", idVenta } });
            return Utilbdd.EjecutarConsulta(query, param);
        }

        public static DataTable ObtenerDetallesFacturaOriginal(int idVenta)
        {
            string query = @"
                SELECT 
                    dv.id_producto,
                    p.nombre_producto,
                    dv.cantidad,
                    dv.precio_unitario_venta,
                    dv.subtotal
                FROM detalles_venta dv
                INNER JOIN productos p ON dv.id_producto = p.id_producto
                WHERE dv.id_venta = @idVenta
                ORDER BY dv.id_detalle_venta
            ";
            var parametros = Utilbdd.CrearParametros(new Dictionary<string, object> { { "idVenta", idVenta } });
            return Utilbdd.EjecutarConsulta(query, parametros);
        }


        public static DataTable ObtenerDetallesFacturaParaDevolucion(int idVenta)
        {
            string query = @"
                SELECT 
                    dv.id_producto,
                    p.nombre_producto,
                    dv.cantidad AS cantidad_original,
                    dv.precio_unitario_venta AS precio_unitario,
                    dv.subtotal
                FROM detalles_venta dv
                INNER JOIN productos p ON dv.id_producto = p.id_producto
                WHERE dv.id_venta = @idVenta
                ORDER BY dv.id_detalle_venta
            ";
            var parametros = Utilbdd.CrearParametros(new Dictionary<string, object> { { "idVenta", idVenta } });
            return Utilbdd.EjecutarConsulta(query, parametros);
        }

        public static bool ActualizarEstatusFactura(int idVenta, int nuevoEstatus)
        {
            string query = "UPDATE ventas SET estatus = @estatus WHERE id_venta = @idVenta";
            var param = Utilbdd.CrearParametros(new Dictionary<string, object>
            {
                { "estatus", nuevoEstatus },
                { "idVenta", idVenta }
            });
            return Utilbdd.EjecutarComando(query, param) > 0;
        }


        public static DataTable ObtenerFacturaPorBusqueda(string busqueda)
        {
            string query = @"
                SELECT 
                    v.id_venta,
                    v.numero_factura,
                    v.fecha_venta,
                    c.nombre_cliente AS cliente
                FROM ventas v
                INNER JOIN clientes c ON v.id_cliente = c.id_cliente
                WHERE v.estatus = 1 
                AND (v.numero_factura LIKE @busqueda OR c.nombre_cliente LIKE @busqueda)
                ORDER BY v.fecha_venta DESC
                LIMIT 1
            ";
            var parametros = Utilbdd.CrearParametros(new Dictionary<string, object> { { "busqueda", $"%{busqueda}%" } });
            return Utilbdd.EjecutarConsulta(query, parametros);
        }

        public static DataTable ObtenerUsuarios()
        {
            string query = "SELECT id_usuario, nombre_usuario FROM usuarios WHERE estatus = 1 ORDER BY nombre_usuario";
            return Utilbdd.EjecutarConsulta(query);
        }

        public static DataTable ObtenerFacturasParaDevolucion(string busqueda, int? idUsuario, string numControl, DateTime? fechaDesde, DateTime? fechaHasta)
        {
            string query = @"
                SELECT 
                    v.id_venta,
                    v.numero_factura,
                    v.fecha_venta,
                    c.nombre_cliente AS cliente,
                    v.total_venta,
                    v.numero_control,
                    u.nombre_usuario AS usuario
                FROM ventas v
                INNER JOIN clientes c ON v.id_cliente = c.id_cliente
                INNER JOIN usuarios u ON v.id_usuario = u.id_usuario
                WHERE v.estatus = 1
            ";

            var parametros = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(busqueda))
            {
                query += " AND (v.numero_factura LIKE @busqueda OR c.nombre_cliente LIKE @busqueda)";
                parametros.Add("busqueda", $"%{busqueda}%");
            }

            if (idUsuario.HasValue)
            {
                query += " AND v.id_usuario = @idUsuario";
                parametros.Add("idUsuario", idUsuario.Value);
            }

            if (!string.IsNullOrEmpty(numControl))
            {
                query += " AND v.numero_control LIKE @numControl";
                parametros.Add("numControl", $"%{numControl}%");
            }

            if (fechaDesde.HasValue)
            {
                query += " AND v.fecha_venta >= @fechaDesde";
                parametros.Add("fechaDesde", fechaDesde.Value);
            }

            if (fechaHasta.HasValue)
            {
                query += " AND v.fecha_venta <= @fechaHasta";
                parametros.Add("fechaHasta", fechaHasta.Value);
            }

            query += " ORDER BY v.fecha_venta DESC, v.numero_factura DESC";

            var parametrosArray = Utilbdd.CrearParametros(parametros);
            return Utilbdd.EjecutarConsulta(query, parametrosArray);
        }


    }
}