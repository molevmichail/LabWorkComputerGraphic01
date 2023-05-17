using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    internal class LinearCorrection : Filters
    {
		int maxR = 0, minR = 255;
		int maxG = 0, minG = 255;
		int maxB = 0, minB = 255;

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

		void MinColor(Bitmap sourceImage)
		{
			for (int i = 0; i < sourceImage.Width; i++)
				for (int j = 0; j < sourceImage.Height; j++)
				{
					Color sourceColor = sourceImage.GetPixel(i, j);
					minR = Math.Min(minR, sourceColor.R);
					minG = Math.Min(minG, sourceColor.G);
					minB = Math.Min(minB, sourceColor.B);
				}
		}

		protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
		{
			Color sourceColor = sourceImage.GetPixel(x, y);
			Color resultColor = Color.FromArgb((sourceColor.R - minR) * 255 / (maxR - minR),
				(sourceColor.G - minG) * 255 / (maxG - minG),
				(sourceColor.B - minB) * 255 / (maxB - minB));
			return resultColor;
		}

		public Bitmap processImage(Bitmap sourceImage)
		{
			Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

			MaxColor(sourceImage);

			MinColor(sourceImage);

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
