using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using sgidam.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace sgidam.Models
{
    public class Usuario
    {
        
        public int id_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string password { get; set; } 
        public string nombre_empleado { get; set; }
        public string apellido_empleado { get; set; }
        public string rol { get; set; }
        public int? estatus { get; set; }


        public static LoginResult ValidarLogin(string nombreUsuario, string claveTextoPlano)
        {
            
            string query = @"
                SELECT id_usuario, nombre_usuario, nombre_empleado, apellido_empleado, rol, password, estatus
                FROM usuarios
                WHERE nombre_usuario = @usuario
            ";

            var parametros = Utilbdd.CrearParametros(new Dictionary<string, object>
                {
                    { "usuario", nombreUsuario }
                });

            DataTable resultado = Utilbdd.EjecutarConsulta(query, parametros);

            if (resultado.Rows.Count == 0)
            {
                return new LoginResult("Usuario no encontrado.");
            }

            DataRow fila = resultado.Rows[0];
            int estatus = Convert.ToInt32(fila["estatus"]);
            string hashAlmacenado = fila["password"].ToString();

         
            if (estatus != 1)
            {
                return new LoginResult("Usuario inactivo. Contacte al administrador.");
            }

           
            bool esValida = Encriptacion.VerifyPassword(claveTextoPlano, hashAlmacenado);

            if (!esValida)
            {
                return new LoginResult("Contraseña incorrecta.");
            }

            Usuario usuario = new Usuario
            {
                id_usuario = Convert.ToInt32(fila["id_usuario"]),
                nombre_usuario = fila["nombre_usuario"].ToString(),
                nombre_empleado = fila["nombre_empleado"].ToString(),
                apellido_empleado = fila["apellido_empleado"].ToString(),
                rol = fila["rol"].ToString(),
                estatus = estatus
            };

            return new LoginResult(usuario);
        }


        public static bool CambiarPassword(int idUsuario, string nuevaClave)
        {
            string hash = Encriptacion.GetHash(nuevaClave); 

            string query = "UPDATE usuarios SET password = @clave WHERE id_usuario = @id";
            var parametros = Utilbdd.CrearParametros(new Dictionary<string, object>
            {
                { "clave", hash },
                { "id", idUsuario }
            });

            int filas = Utilbdd.EjecutarComando(query, parametros);
            return filas > 0;
        }

        public static DataTable ObtenerEstatus()
        {
            string query = "SELECT id_estatus, tipo_status FROM estatus ORDER BY tipo_status";
            return Utilbdd.EjecutarConsulta(query);
        }


        public static bool Registrar(Usuario nuevoUsuario, string claveTextoPlano)
        {
            string hash = Encriptacion.GetHash(claveTextoPlano);

            string query = @"
                INSERT INTO usuarios (id_usuario, nombre_usuario, password, nombre_empleado, apellido_empleado, rol, estatus)
                VALUES (@id, @usuario, @clave, @nombre, @apellido, @rol, @estatus)
            ";

            var parametros = Utilbdd.CrearParametros(new Dictionary<string, object>
            {
                { "id", nuevoUsuario.id_usuario },           
                { "usuario", nuevoUsuario.nombre_usuario= TextoHelper.ToUpper(nuevoUsuario.nombre_usuario) },
                { "clave", hash },
                { "nombre", nuevoUsuario.nombre_empleado= TextoHelper.ToUpper(nuevoUsuario.nombre_empleado) },
                { "apellido", nuevoUsuario.apellido_empleado= TextoHelper.ToUpper (nuevoUsuario.apellido_empleado)},
                { "rol", nuevoUsuario.rol },
                { "estatus", nuevoUsuario.estatus ?? 1 }
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
                    if (ex.Message.Contains("id_usuario"))
                        throw new Exception("Ya existe un usuario con esa cédula.");
                    else if (ex.Message.Contains("nombre_usuario"))
                        throw new Exception("Ya existe un usuario con ese nombre de usuario.");
                }
                throw;
            }
        }


        
    }
}