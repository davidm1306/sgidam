using System;
using System.Collections.Generic;
using System.Data;
using sgidam.Data;
using MySql.Data.MySqlClient;

namespace sgidam.Helpers
{
    public static class DashboardHelper
    {
        
        public static DataTable GetResumenGeneral()
        {
            string query = @"
                SELECT 
                    COUNT(*) AS TotalProductos,
                    SUM(CASE WHEN stock <= stock_minimo THEN 1 ELSE 0 END) AS StockCritico,
                    SUM(CASE WHEN stock > stock_minimo AND stock <= stock_minimo * 1.3 THEN 1 ELSE 0 END) AS ProximoCritico,
                    SUM(stock * precio_compra) AS ValorInventario
                FROM productos
                WHERE estatus = 1";
            return Utilbdd.EjecutarConsulta(query);
        }

        
        public static DataTable GetProductosStockCritico()
        {
            string query = @"
                SELECT codigo_barras, nombre_producto, stock, stock_minimo,
                       CASE 
                           WHEN stock <= stock_minimo THEN 'Crítico'
                           WHEN stock <= stock_minimo * 1.3 THEN 'Alerta'
                           ELSE 'Normal'
                       END AS Estado
                FROM productos
                WHERE estatus = 1 AND stock <= stock_minimo * 1.3
                ORDER BY stock ASC";
            return Utilbdd.EjecutarConsulta(query);
        }

        public static DataTable GetTopProductosVendidos(int dias)
        {
            string query = @"
                SELECT p.nombre_producto, SUM(dv.cantidad) AS UnidadesVendidas, SUM(dv.subtotal) AS MontoTotal
                FROM detalles_venta dv
                INNER JOIN productos p ON dv.id_producto = p.id_producto
                INNER JOIN ventas v ON dv.id_venta = v.id_venta
                WHERE v.fecha_venta >= DATE_SUB(NOW(), INTERVAL @dias DAY)
                  AND v.estatus = 1
                GROUP BY dv.id_producto
                ORDER BY UnidadesVendidas DESC
                LIMIT 5";

            
            var parametros = new Dictionary<string, object> { { "@dias", dias } };
            MySqlParameter[] parametrosArray = Utilbdd.CrearParametros(parametros);

            return Utilbdd.EjecutarConsulta(query, parametrosArray);
        }

        
        public static DataTable GetTopClientes(int dias)
        {
            string query = @"
                SELECT c.nombre_cliente, COUNT(v.id_venta) AS NumCompras, SUM(v.total_venta) AS TotalGastado
                FROM ventas v
                INNER JOIN clientes c ON v.id_cliente = c.id_cliente
                WHERE v.fecha_venta >= DATE_SUB(NOW(), INTERVAL @dias DAY)
                  AND v.estatus = 1
                GROUP BY v.id_cliente
                ORDER BY TotalGastado DESC
                LIMIT 5";

            var parametros = new Dictionary<string, object> { { "@dias", dias } };
            MySqlParameter[] parametrosArray = Utilbdd.CrearParametros(parametros);

            return Utilbdd.EjecutarConsulta(query, parametrosArray);
        }

        
        public static DataTable GetVentasHoy()
        {
            string query = @"
                SELECT COUNT(*) AS NumVentas, SUM(total_venta) AS MontoTotal
                FROM ventas
                WHERE DATE(fecha_venta) = CURDATE() AND estatus = 1";
            return Utilbdd.EjecutarConsulta(query);
        }
    }
}