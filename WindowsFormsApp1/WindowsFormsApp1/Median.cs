using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

/*namespace WindowsFormsApp1
{
    internal class Median : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int size = 3;
            int radius = 1;

            List<int> cR = new List<int>();
            List<int> cG = new List<int>();
            List<int> cB = new List<int>();


            for (int i = -radius; i <= radius; i++)
                for (int j = -radius; j <= radius; j++)
                {
                    Color sourceColor = sourceImage.GetPixel(Clamp(x + i, 0, sourceImage.Width - 1), Clamp(y + j, 0, sourceImage.Height - 1));
                    cR.Add(sourceColor.R);
                    cG.Add(sourceColor.G);
                    cB.Add(sourceColor.B);

                }

            cR.Sort();
            cG.Sort();
            cB.Sort();

            int median = (size * size / 2);

            int cR_ = cR[median];
            int cG_ = cG[median];
            int cB_ = cB[median];

            Color resultColor = Color.FromArgb(cR_, cG_, cB_);
            return resultColor;
        }
    }
}
*/

namespace WindowsFormsApp1
{
    internal class Median : Filters
    {

        //метод для обмена элементов массива
        static void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }

        //метод возвращающий индекс опорного элемента
        static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        //быстрая сортировка
        static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        static int[] QuickSort(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {

            int radiusx = 3;
            int radiusy = 3;
            int cR_, cB_, cG_;
            int N = (2 * radiusx + 1) * (2 * radiusy + 1);
            int[] cR = new int[N];
            int[] cB = new int[N];
            int[] cG = new int[N];
            int k = 0;
            for (int i = -radiusx; i < radiusx; i++)
            {
                for (int j = -radiusy; j < radiusy; j++)
                {
                    int idx = Clamp(x + i, 0, sourceImage.Width - 1);
                    int idy = Clamp(y + j, 0, sourceImage.Height - 1);
                    Color c = sourceImage.GetPixel(idx, idy);
                    cR[k] = c.R;
                    cG[k] = c.G;
                    cB[k] = c.B;
                    k++;

                }
            }
            QuickSort(cR);
            QuickSort(cG);
            QuickSort(cB);
            int n_ = (int)(N / 2);
            cR_ = cR[n_];
            cG_ = cG[n_];
            cB_ = cB[n_];

            return Color.FromArgb(Clamp(cR_, 0, 255), Clamp(cG_, 0, 255), Clamp(cB_, 0, 255));
        }
    }
}
