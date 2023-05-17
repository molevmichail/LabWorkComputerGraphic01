using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class DiagInversion : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            double koef = 1.0;
            if(sourceImage.Width>=sourceImage.Height)
            {
                koef = sourceImage.Width / sourceImage.Height;
            }
            else
            {
                koef = sourceImage.Height / sourceImage.Width;
            }
            if (x >= y*koef)
            {
                Color sourceColor = sourceImage.GetPixel(x, y);
                Color resultColor = Color.FromArgb(255 - sourceColor.R, 255 - sourceColor.G, 255 - sourceColor.B);
                return resultColor;
            }
            else
            {
                Color sourceColor = sourceImage.GetPixel(x, y);
                Color resultColor = Color.FromArgb(sourceColor.R, sourceColor.G, sourceColor.B);
                return resultColor;
            }
        }
    }
}
