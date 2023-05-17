using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    internal class Reflector : Filters
    {
		int maxR = 0;
		int maxG = 0;
		int maxB = 0;

		protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
		{
			Color sourceColor = sourceImage.GetPixel(x, y);
			Color resultColor = Color.FromArgb(sourceColor.R * (255 / maxR),
				sourceColor.G * (255 / maxG),
				sourceColor.B * (255 / maxB));
			return resultColor;
		}
		void MaxColor(Bitmap sourceImage)
		{
			for (int i = 0; i < sourceImage.Width; i++)
				for (int j = 0; j < sourceImage.Height; j++)
				{
					Color sourceColor = sourceImage.GetPixel(i, j);
					maxR = Math.Max(maxR, sourceColor.R);
					maxG = Math.Max(maxG, sourceColor.G);
					maxB = Math.Max(maxB, sourceColor.B);
				}
		}
		public Bitmap processImage(Bitmap sourceImage)
		{
			Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

			MaxColor(sourceImage);

			for (int i = 0; i < sourceImage.Width; i++)
			{
				for (int j = 0; j < sourceImage.Height; j++)
				{
					resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
				}
			}

			return resultImage;
		}
	}
}
