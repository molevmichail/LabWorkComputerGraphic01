using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Sharr : MatrixFilter
    {
        public void createSharrKernel()
        {
            int size = 3;
            kernel = new float[size, size];

            kernel[0, 0] = -1;
            kernel[0, 1] = -1;
            kernel[0, 2] = -1;
            kernel[1, 0] = 0;
            kernel[1, 1] = 0;
            kernel[1, 2] = 0;
            kernel[2, 0] = 1;
            kernel[2, 1] = 1;
            kernel[2, 2] = 1;


        }

        public Sharr()
        {
            createSharrKernel();
        }
    }
}
