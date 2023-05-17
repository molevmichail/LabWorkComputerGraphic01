using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Bitmap image;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Создаём диалог для открытия файла
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files| *.png; *.jpg; *.bmp; | All Files (*.*) | *.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
            }
            pictureBox1.Image = image;
            pictureBox1.Refresh();
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //InvertFilter filter = new InvertFilter();
            //Bitmap resultImage = filter.processImage(image);
            //pictureBox1.Image = resultImage;
            //pictureBox1.Refresh();
            Filters filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
                image = newImage;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void Отмена_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильтрГауссаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void чёрнобелыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlackAndWhite();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Sepia();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void увеличениеЯркостиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Brightness();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void насыщенностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Saturation();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильтрСобеляXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SobelFilterX();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильтрСобеляYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SobelFilterY();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Sharpness();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильтрПрюиттаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Sharr();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сужениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Constriction();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void растяжениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Extension();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void градиентToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Gradient();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void медианныйФильтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Median();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void идеальныйОтражательToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Reflector();
            //Reflector filter = new Reflector();
            //Bitmap resultImage = filter.processImage(image);
            //pictureBox1.Image = resultImage;
            //pictureBox1.Refresh();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void серыйМирToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayWorld();
            //GrayWorld filter = new GrayWorld();
            //Bitmap resultImage = filter.processImage(image);
            //pictureBox1.Image = resultImage;
            //pictureBox1.Refresh();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void линейноеРастяжениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new LinearCorrection();
            //LinearCorrection filter = new LinearCorrection();
            //Bitmap resultImage = filter.processImage(image);
            //pictureBox1.Image = resultImage;
            //pictureBox1.Refresh();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void диагональнаяИнверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new DiagInversion();
            backgroundWorker1.RunWorkerAsync(filter);
        }
    }
}
