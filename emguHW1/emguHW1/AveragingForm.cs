using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace emguHW1
{
    public partial class AveragingForm : Form
    {
        private PictureBox pictureBox;
        private Form1 form;

        public AveragingForm(PictureBox pictureBox, Form1 form)
        {
            InitializeComponent();
            this.pictureBox = pictureBox;
            this.form = form;
        }

        public Image<Bgr, Byte> GetAveraging(Image<Bgr, Byte> sourceImage, int matrixWidthSize, int matrixHeightSize)
        {
            Image<Bgr, Byte> image = new Image<Bgr, Byte>(sourceImage.Width, sourceImage.Height);
            for (int y = 0; y < sourceImage.Height; y++)
            {
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    int n = 0;
                    int[] value = new int[3];
                    int my = y - matrixHeightSize / 2;
                    my = Math.Max(my, 0);
                    int mx = x - matrixWidthSize / 2;
                    mx = Math.Max(mx, 0);
                    for (int i = 0; i < matrixHeightSize && my + i < sourceImage.Height; i++)
                    {
                        for (int j = 0; j < matrixWidthSize && mx + j < sourceImage.Width; j++)
                        {
                            for (int z = 0; z < sourceImage.Data.GetLength(2); z++)
                            {
                                value[z] += sourceImage.Data[my + i, mx + j, z];
                            }
                            n++;
                        }
                    }
                    n = Math.Max(n, 1);
                    for (int z = 0; z < sourceImage.Data.GetLength(2); z++)
                    {
                        image.Data[y, x, z] = (byte)(value[z] / n);
                    }
                }
            }
            return image;
        }

        private void averagingButton_Click(object sender, EventArgs e)
        {
            form.Image = GetAveraging(form.Image, (int)numericUpDown1.Value, (int)numericUpDown2.Value);
            pictureBox.Image = form.Image.ToBitmap();
        }
    }
}
