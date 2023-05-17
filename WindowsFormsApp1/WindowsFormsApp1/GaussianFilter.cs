﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class GaussianFilter : MatrixFilter
    {
        public void createGaussianKernel(int radius, float sigma)
        {
            //Определяем размер ядра
            int size = 2 * radius + 1;
            //Создаём ядро фильтра
            kernel = new float[size, size];
            //Коэффициент нормировки ядра
            float norm = 0;
            //Рассчитываем ядро линейного фильтра
            for(int i = -radius; i <= radius; i++)
            {
                for(int j =- radius; j <= radius; j++)
                {
                    kernel[i + radius, j + radius] = (float)(Math.Exp(-(i * i + j * j) / (sigma * sigma)));
                    norm += kernel[i + radius, j + radius];
                }
            }
            //Нормируем ядро
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    kernel[i, j] /= norm;
                }
            }
        }
        public GaussianFilter()
        {
            createGaussianKernel(3, 2);
        }
    }
}
