using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    internal class Constriction : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int MH = 3;
            int MW = 3;
            int d = 1;
            int[,] mask = new int[3, 3] { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 1, 0 } };
            Color min = Color.FromArgb(255, 255, 255);
            for (int j = -MH / 2; j <= MH / 2; j++)
                for (int i = -MW / 2; i <= MW / 2; i++)
                {
                    Color sourceColor = sourceImage.GetPixel(Clamp(x + i, 0, sourceImage.Width - d), Clamp(y + j, 0, sourceImage.Height - d));
                    if ((mask[i + MW / 2, j + MH / 2] == 1) && (sourceColor.R < min.R))
                        min = sourceColor;
                }

            return min;
        }
    }
}
