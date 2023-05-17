using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    internal class Sepia : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            double Intensity = 0.36 * sourceColor.R + 0.53 * sourceColor.G + 0.11 * sourceColor.B;
            Intensity = Convert.ToInt64(Intensity);
            int d = 20;
            int R = Convert.ToInt32(Intensity + 2 * d);
            int G = Convert.ToInt32(Intensity + 0.5 * d);
            int B = Convert.ToInt32(Intensity - 1 * d);
            R = Clamp(R, 0, 255);
            G = Clamp(G, 0, 255);
            B = Clamp(B, 0, 255);

            Color resultColor = Color.FromArgb(R, G, B);
            return resultColor;
        }
    }
}
