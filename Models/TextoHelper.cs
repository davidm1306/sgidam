using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgidam.Models
{
    public static class TextoHelper
    {
        
        public static string ToUpper(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return null;

            return texto.Trim().ToUpperInvariant();
        }
    }
}
