using MySql.Data.MySqlClient;
using sgidam.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;  

namespace sgidam.Models
{
    public class Producto
    {
        
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string CodigoBarras { get; set; }
        public int? IdMarca { get; set; }
        public int? IdCategoria { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PorcentajeUtilidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public string ImagenProducto { get; set; }
        public int? Estatus { get; set; }
        public decimal? CostoHistoricoMaximo { get; set; }
        public DateTime? FechaActualizacionCosto { get; set; }


        public static DataTable ObtenerMarcas()
        {
            string query = "SELECT id_marca, nombre_marca FROM marcas ORDER BY nombre_marca";
            return Utilbdd.EjecutarConsulta(query);
        }

        public static DataTable ObtenerCategorias()
        {
            string query = "SELECT id_categoria, nombre_categoria FROM categorias ORDER BY nombre_categoria";
            return Utilbdd.EjecutarConsulta(query);
        }

        public static DataTable ObtenerEstatus()
        {
            string query = "SELECT id_estatus, tipo_status FROM estatus ORDER BY tipo_status";
            return Utilbdd.EjecutarConsulta(query);
        }

        
        public static bool RegistrarProducto(Producto nuevoProducto, string rutaImagenOrigen = null)
        {
            
            string nombreArchivoImagen = null;
            if (!string.IsNullOrEmpty(rutaImagenOrigen) && File.Exists(rutaImagenOrigen))
            {
                string directorioDestino = Path.Combine(Application.StartupPath, "Images");
                if (!Directory.Exists(directorioDestino))
                    Directory.CreateDirectory(directorioDestino);

                
                string extension = Path.GetExtension(rutaImagenOrigen);
                nombreArchivoImagen = $"Producto_{DateTime.Now.Ticks}{extension}";
                string rutaDestino = Path.Combine(directorioDestino, nombreArchivoImagen);

                
                File.Copy(rutaImagenOrigen, rutaDestino, true);
            }

            
            nuevoProducto.ImagenProducto = nombreArchivoImagen;


            string query = @"
                INSERT INTO productos (
                    nombre_producto,
                    codigo_barras,
                    id_marca,
                    id_categoria,
                    precio_compra,
                    porcentaje_utilidad,
                    precio_venta,
                    stock,
                    stock_minimo,
                    imagen_producto,
                    estatus,
                    costo_historico_maximo,
                    fecha_actualizacion_costo
                ) VALUES (
                    @nombre,
                    @codigo,
                    @marca,
                    @categoria,
                    @precioCompra,
                    @porcentajeUtilidad,
                    @precioVenta,
                    @stock,
                    @stockMinimo,
                    @imagen,
                    @estatus,
                    @precioCompra,
                    NOW()
                )
            ";

            var parametros = Utilbdd.CrearParametros(new Dictionary<string, object>
            {
                { "nombre", nuevoProducto.NombreProducto = TextoHelper.ToUpper(nuevoProducto.NombreProducto)},
                { "codigo", string.IsNullOrWhiteSpace(nuevoProducto.CodigoBarras) ? (object)DBNull.Value : nuevoProducto.CodigoBarras= TextoHelper.ToUpper(nuevoProducto.CodigoBarras) },
                { "marca", nuevoProducto.IdMarca ?? (object)DBNull.Value },
                { "categoria", nuevoProducto.IdCategoria ?? (object)DBNull.Value },
                { "precioCompra", nuevoProducto.PrecioCompra },
                { "porcentajeUtilidad", nuevoProducto.PorcentajeUtilidad},
                { "precioVenta", nuevoProducto.PrecioVenta },
                { "stock", nuevoProducto.Stock },
                { "stockMinimo", nuevoProducto.StockMinimo },
                { "imagen", nuevoProducto.ImagenProducto ?? (object)DBNull.Value },
                { "estatus", nuevoProducto.Estatus ?? (object)DBNull.Value }
            });

            try
            {
                int filas = Utilbdd.EjecutarComando(query, parametros);
                return filas > 0;
            }
            catch (MySqlException ex)
            {
                
                if (ex.Number == 1062 && ex.Message.Contains("codigo_barras"))
                {
                    throw new Exception("Ya existe un producto con ese código de barras. Por favor, verifica.");
                }
                throw; 
            }
        }

        public static bool ActualizarCostoMaximo(int idProducto, decimal nuevoCostoMaximo, decimal nuevoPorcentajeUtilidad)
        {
            decimal nuevoPrecioVenta = nuevoCostoMaximo * (1 + nuevoPorcentajeUtilidad / 100);

            string query = @"
                UPDATE productos 
                SET costo_historico_maximo = @nuevoCosto,
                    porcentaje_utilidad = @nuevaUtilidad,
                    precio_venta = @nuevoPrecio,
                    fecha_actualizacion_costo = NOW()
                WHERE id_producto = @id
            ";
            var parametros = Utilbdd.CrearParametros(new Dictionary<string, object>
            {
                { "nuevoCosto", nuevoCostoMaximo },
                { "nuevaUtilidad", nuevoPorcentajeUtilidad },
                { "nuevoPrecio", nuevoPrecioVenta },
                { "id", idProducto }
            });
            return Utilbdd.EjecutarComando(query, parametros) > 0;
        }
    }
}