using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace sgidam.Data
{
    public class Utilbdd
    {

        private static readonly string connectionString = "Server=localhost;Port=3307;Database=sgidam;Uid=root;Pwd=;";

        public static string ObtenerCadenaConexion()
        {
            return connectionString;
        }

        public static DataTable EjecutarConsulta(string query, MySqlParameter[] parametros = null)
        {
            DataTable resultado = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                if (parametros != null)
                    cmd.Parameters.AddRange(parametros);

                conn.Open();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(resultado);
                }
            }
            return resultado;
        }

        // 2. Ejecutar INSERT, UPDATE, DELETE (devuelve filas afectadas)
        public static int EjecutarComando(string query, MySqlParameter[] parametros = null)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                if (parametros != null)
                    cmd.Parameters.AddRange(parametros);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // 3. Ejecutar SELECT y devolver un solo valor (COUNT, SUM, etc.)
        public static object EjecutarEscalar(string query, MySqlParameter[] parametros = null)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                if (parametros != null)
                    cmd.Parameters.AddRange(parametros);

                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        // 4. Método auxiliar para crear parámetros fácilmente
        public static MySqlParameter[] CrearParametros(Dictionary<string, object> datos)
        {
            var lista = new List<MySqlParameter>();
            foreach (var item in datos)
            {
                lista.Add(new MySqlParameter($"@{item.Key}", item.Value ?? DBNull.Value));
            }
            return lista.ToArray();
        }
    }
}

