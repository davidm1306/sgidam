using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgidam.Data
{
    public static class DibujarLinea
    {
        public static void LineaRectaInferior(TextBox txt, string hexColorLinea, PaintEventArgs d)
        {
            Color colorLinea = ColorTranslator.FromHtml(hexColorLinea);

            using (Pen pen = new Pen(colorLinea, 2))
            {

                int x1 = txt.Left;
                int x2 = txt.Right;
                int y1 = txt.Bottom + 2;
                int y2 = y1;

                d.Graphics.DrawLine(pen, x1, y1, x2, y2);
            }
        }
    }
}
