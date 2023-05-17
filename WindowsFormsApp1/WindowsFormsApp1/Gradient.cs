using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    internal class Gradient : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int MH = 3;
            int MW = 3;
            int[,] mask = new int[3, 3] { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 1, 0 } };
            Color min = Color.FromArgb(255, 255, 255);
            Color max = Color.FromArgb(0, 0, 0);
            for (int j = -MH / 2; j <= MH / 2; j++)
                for (int i = -MW / 2; i <= MW / 2; i++)
                {
                    Color sourceColor = sourceImage.GetPixel(Clamp(x + i, 0, sourceImage.Width - 1), Clamp(y + j, 0, sourceImage.Height - 1));
                    if ((mask[i + MW / 2, j + MH / 2] == 1) && (sourceColor.R < min.R))
                        min = sourceColor;
                    if ((mask[i + MW / 2, j + MH / 2] == 1) && (sourceColor.R > max.R))
                        max = sourceColor;
                }
            Color resultColor = Color.FromArgb(Math.Abs(min.R - max.R), Math.Abs(min.G - max.G), Math.Abs(min.B - max.B));
            return resultColor;
        }
    }
}
