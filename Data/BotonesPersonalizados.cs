using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace sgidam.Data
{

    public static class BotonesPersonalizados
    {

        public static void EstiloBotonPildora(Button btn, Color colorBorde, int grosorBorde, Color? colorFondo = null)
        {
            
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = grosorBorde;
            btn.FlatAppearance.BorderColor = colorBorde;

            if (colorFondo.HasValue)
                btn.BackColor = colorFondo.Value;

            int radio = btn.Height / 2;

            if (btn.Width < radio * 2)
                radio = btn.Width / 2;

            if (radio < 2) radio = 2;
            
            GraphicsPath path = new GraphicsPath();

            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radio * 2, radio * 2), 180, 90);
            path.AddArc(new Rectangle(btn.Width - radio * 2, 0, radio * 2, radio * 2), 270, 90);
            path.AddArc(new Rectangle(btn.Width - radio * 2, btn.Height - radio * 2, radio * 2, radio * 2), 0, 90);
            path.AddArc(new Rectangle(0, btn.Height - radio * 2, radio * 2, radio * 2), 90, 90);
            path.CloseFigure();

            btn.Region = new Region(path);
        }


        public static void EstiloBotonPildora(Button btn, string hexColorBorde, int grosorBorde, string hexColorFondo = null)
        {
            Color colorBorde = ColorTranslator.FromHtml(hexColorBorde);
            Color? colorFondo = null;

            if (!string.IsNullOrEmpty(hexColorFondo))
            {
                colorFondo = ColorTranslator.FromHtml(hexColorFondo);
            }

            EstiloBotonPildora(btn, colorBorde, grosorBorde, colorFondo);
        }
    }
}
