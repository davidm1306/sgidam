using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgidam.Models
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Usuario Usuario { get; set; }

       
        public LoginResult(Usuario usuario)
        {
            Success = true;
            Message = "Inicio de sesión exitoso.";
            Usuario = usuario;
        }

        
        public LoginResult(string mensaje)
        {
            Success = false;
            Message = mensaje;
            Usuario = null;
        }
    }
}
