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
    public class Marca
    {
        public int IdMarca { get; set; }
        public string NombreMarca { get; set; }

        
        public static DataTable ObtenerTodas()
        {
            string query = "SELECT id_marca, nombre_marca FROM marcas ORDER BY nombre_marca";
            return Utilbdd.EjecutarConsulta(query);
        }

        
        public static bool Registrar(Marca nuevaMarca)
        {
            string query = "INSERT INTO marcas (nombre_marca) VALUES (@nombre)";
            var parametros = Utilbdd.CrearParametros(new Dictionary<string, object>
            {
                { "nombre", nuevaMarca.NombreMarca= TextoHelper.ToUpper(nuevaMarca.NombreMarca) }
            });

            try
            {
                int filas = Utilbdd.EjecutarComando(query, parametros);
                return filas > 0;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) // Duplicate entry
                    throw new Exception("Ya existe una marca con ese nombre.");
                throw;
            }
        }
    }
}