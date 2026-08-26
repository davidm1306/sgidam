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
    public class Proveedor
    {
        public string IdProveedor { get; set; }         
        public string NombreProveedor { get; set; }
        public string CorreoProveedor { get; set; }
        public string TelefonoProveedor { get; set; }
        public string DireccionProveedor { get; set; }
        public int? Estatus { get; set; }

        
        public static DataTable ObtenerEstatus()
        {
            string query = "SELECT id_estatus, tipo_status FROM estatus ORDER BY tipo_status";
            return Utilbdd.EjecutarConsulta(query);
        }

       
        public static bool Registrar(Proveedor nuevoProveedor)
        {
            // Normalizar textos a mayúsculas
            nuevoProveedor.IdProveedor = TextoHelper.ToUpper(nuevoProveedor.IdProveedor);
            nuevoProveedor.NombreProveedor = TextoHelper.ToUpper(nuevoProveedor.NombreProveedor);
            nuevoProveedor.CorreoProveedor = TextoHelper.ToUpper(nuevoProveedor.CorreoProveedor);
            nuevoProveedor.TelefonoProveedor = TextoHelper.ToUpper(nuevoProveedor.TelefonoProveedor);
            nuevoProveedor.DireccionProveedor = TextoHelper.ToUpper(nuevoProveedor.DireccionProveedor);

            string query = @"
                INSERT INTO proveedores 
                    (id_proveedor, nombre_proveedor, correo_proveedor, telefono_proveedor, direccion_proveedor, estatus)
                VALUES 
                    (@id, @nombre, @correo, @telefono, @direccion, @estatus)
            ";

            var parametros = Utilbdd.CrearParametros(new Dictionary<string, object>
            {
                { "id", nuevoProveedor.IdProveedor },
                { "nombre", nuevoProveedor.NombreProveedor },
                { "correo", string.IsNullOrWhiteSpace(nuevoProveedor.CorreoProveedor) ? (object)DBNull.Value : nuevoProveedor.CorreoProveedor },
                { "telefono", string.IsNullOrWhiteSpace(nuevoProveedor.TelefonoProveedor) ? (object)DBNull.Value : nuevoProveedor.TelefonoProveedor },
                { "direccion", string.IsNullOrWhiteSpace(nuevoProveedor.DireccionProveedor) ? (object)DBNull.Value : nuevoProveedor.DireccionProveedor },
                { "estatus", nuevoProveedor.Estatus ?? 1 }
            });

            try
            {
                int filas = Utilbdd.EjecutarComando(query, parametros);
                return filas > 0;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062 && ex.Message.Contains("PRIMARY"))
                {
                    throw new Exception("Ya existe un proveedor con ese RIF (letra + número).");
                }
                throw;
            }
        }
    }
}