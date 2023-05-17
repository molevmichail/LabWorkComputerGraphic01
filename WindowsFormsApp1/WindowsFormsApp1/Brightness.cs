using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    internal class Brightness : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int d = 20;
            int R = sourceColor.R + d;
            int G = sourceColor.G + d;
            int B = sourceColor.B + d;

            R = Clamp(R, 0, 255);
            G = Clamp(G, 0, 255);
            B = Clamp(B, 0, 255);


            Color resultColor = Color.FromArgb(R, G, B);
            return resultColor;
        }
    }
}
