using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    internal class Saturation : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int R = sourceColor.R;
            int G = sourceColor.G;
            int B = sourceColor.B;
            int d = 20;

            if (R <= G && R <= B && d > R)
                d = R;
            else if (G <= R && G <= B && d > G)
                d = G;
            else if (B <= R && B <= G && d > B)
                d = B;


            if (R >= G && R >= B && G >= B)
            {
                if (Math.Abs(R - G) <= Math.Abs(B - G))
                    G += d / 4;
                else
                    G -= d / 4;
                R += d;
                B -= d;
            }
            else if (R >= G && R >= B && B >= G)
            {
                if (Math.Abs(R - B) <= Math.Abs(B - G))
                    B += d / 4;
                else
                    B -= d / 4;
                R += d;
                G -= d;
            }
            else if (G >= R && G >= B && R >= B)
            {
                if (Math.Abs(R - G) <= Math.Abs(B - R))
                    R += d / 4;
                else
                    R -= d / 4;
                G += d;
                B -= d;
            }
            else if (G >= R && G >= B && B >= R)
            {
                if (Math.Abs(B - G) <= Math.Abs(B - R))
                    B += d / 4;
                else
                    B -= d / 4;
                G += d;
                R -= d;
            }
            else if (B >= R && B >= G && R >= G)
            {
                if (Math.Abs(R - B) <= Math.Abs(R - G))
                    R += d / 4;
                else
                    R -= d / 4;
                B += d;
                G -= d;
            }
            else if (B >= R && B >= G && G >= R)
            {
                if (Math.Abs(B - G) <= Math.Abs(R - G))
                    G += d / 4;
                else
                    G -= d / 4;
                B += d;
                R -= d;
            }





            R = Clamp(R, 0, 255);
            G = Clamp(G, 0, 255);
            B = Clamp(B, 0, 255);


            Color resultColor = Color.FromArgb(R, G, B);
            return resultColor;
        }
    }
}
