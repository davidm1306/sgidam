using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace sgidam.Models
{
    public static class Encriptacion
    {
        /// si esto no corre porfa instala esto en el iuta "Install-Package BCrypt.Net-Next" en menú superior y seleccione Herramientas > Administrador de paquetes NuGet > Consola del administrador de paquetes

        public static string GetHash(string password)
        {
           
            string salt = BCrypt.Net.BCrypt.GenerateSalt(10);
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }

      
        public static bool VerifyPassword(string password, string hashFromDatabase)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashFromDatabase);
        }
    }
}