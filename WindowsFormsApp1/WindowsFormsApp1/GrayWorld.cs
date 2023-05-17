using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    internal class GrayWorld : Filters
    {
		float averageR = 0;
		float averageG = 0;
		float averageB = 0;

		Color AverageBrightness(Bitmap sourceImage)
		{
			for (int i = 0; i < sourceImage.Width; i++)
				for (int j = 0; j < sourceImage.Height; j++)
				{
					Color sourceColor = sourceImage.GetPixel(i, j);
					averageR += sourceColor.R;
					averageG += sourceColor.G;
					averageB += sourceColor.B;
				}
			averageR /= (sourceImage.Width * sourceImage.Height);
			averageG /= (sourceImage.Width * sourceImage.Height);
			averageB /= (sourceImage.Width * sourceImage.Height);


			Color resultColor = Color.FromArgb(Convert.ToInt32(averageR), Convert.ToInt32(averageG), Convert.ToInt32(averageB));
			return resultColor;
		}
		protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
		{
			float Avg = (averageR + averageG + averageB) / 3;
			Color sourceColor = sourceImage.GetPixel(x, y);
			Color resultColor = Color.FromArgb(Clamp(Convert.ToInt32(sourceColor.R * (Avg / averageR)), 0, 255),
				Clamp(Convert.ToInt32(sourceColor.G * (Avg / averageG)), 0, 255),
				Clamp(Convert.ToInt32(sourceColor.B * (Avg / averageB)), 0, 255));
			return resultColor;
		}
		public Bitmap processImage(Bitmap sourceImage)
		{
			Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

			AverageBrightness(sourceImage);

			for (int i = 0; i < sourceImage.Width; i++)
			{
				for (int j = 0; j < sourceImage.Height; j++)
				{
					resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
				}
			}

			return resultImage;
		}

		new public int Clamp(int value, int min, int max)
		{
			if (value < min)
				return min;
			if (value > max)
				return max;
			return value;
		}
	}
}
