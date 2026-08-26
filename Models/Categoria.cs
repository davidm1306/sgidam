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
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }

        public static DataTable ObtenerTodas()
        {
            string query = "SELECT id_categoria, nombre_categoria FROM categorias ORDER BY nombre_categoria";
            return Utilbdd.EjecutarConsulta(query);
        }

        public static bool Registrar(Categoria nuevaCategoria)
        {
            string query = "INSERT INTO categorias (nombre_categoria) VALUES (@nombre)";
            var parametros = Utilbdd.CrearParametros(new Dictionary<string, object>
            {
                { "nombre", nuevaCategoria.NombreCategoria = TextoHelper.ToUpper(nuevaCategoria.NombreCategoria) }
            });

            try
            {
                int filas = Utilbdd.EjecutarComando(query, parametros);
                return filas > 0;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                    throw new Exception("Ya existe una categoría con ese nombre.");
                throw;
            }
        }
    }
}