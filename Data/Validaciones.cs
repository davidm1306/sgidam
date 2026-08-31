using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgidam.Data
{
    public static class Validaciones
    {
        public static void SoloNumerosYDecimales(object sender, KeyPressEventArgs e)
        {

            if (char.IsControl(e.KeyChar))
                return;


            if (char.IsDigit(e.KeyChar))
                return;


            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                TextBox txt = sender as TextBox;
                if (txt == null) return;


                if (txt.Text.Contains('.') || txt.Text.Contains(','))
                {
                    e.Handled = true;
                    return;
                }


                string textoAntes = txt.Text.Substring(0, txt.SelectionStart);
                bool hayDigitoAntes = false;
                foreach (char c in textoAntes)
                {
                    if (char.IsDigit(c))
                    {
                        hayDigitoAntes = true;
                        break;
                    }
                }

                if (!hayDigitoAntes)
                {

                    e.Handled = true;
                    return;
                }

                return;
            }


            e.Handled = true;
        }

        public static void SoloNumerosEnteros(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (char.IsDigit(e.KeyChar))
            {
                TextBox txt = sender as TextBox;
                if (txt != null && txt.SelectionStart == 0 && e.KeyChar == '0')
                {
                    e.Handled = true;
                    return;
                }
                return;
            }

            e.Handled = true;
        }

        public static void SoloNumerosEnterosConCeroInicial(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (char.IsDigit(e.KeyChar))
                return;

            e.Handled = true;
        }

        public static void ConvertirAMayusculas(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null) return;

            string textoActual = txt.Text;
            string textoMayus = textoActual.ToUpper();

            if (textoActual != textoMayus)
            {
                int posicion = txt.SelectionStart;
                txt.Text = textoMayus;
                txt.SelectionStart = posicion;
            }
        }

        public static void LimpiarEspacios(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null) return;

            int posicion = txt.SelectionStart;
            string texto = txt.Text;

            texto = texto.Trim();
           
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\s+");
            texto = regex.Replace(texto, " ");

            if (txt.Text != texto)
            {
                txt.Text = texto;
                if (posicion > txt.Text.Length)
                    posicion = txt.Text.Length;
                txt.SelectionStart = posicion;
            }
        }

        
        public static void SanitizarTexto(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null) return;

            string caracteresPeligrosos = "'\"\\;--/*";
            string texto = txt.Text;
            
            foreach (char c in caracteresPeligrosos)
            {
                texto = texto.Replace(c.ToString(), "");
            }
            
            if (txt.Text != texto)
            {
                txt.Text = texto;
            }
        }

       
        public static void LimpiarYSanitizar(object sender, EventArgs e)
        {            
            SanitizarTexto(sender, e);
            LimpiarEspacios(sender, e);
        }
        public static bool EsCorreoValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email && email.Contains('.') && !email.StartsWith(".") && !email.EndsWith(".");
            }
            catch
            {
                return false;
            }
        }
    }
}
