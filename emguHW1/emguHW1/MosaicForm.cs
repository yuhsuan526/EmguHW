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
    public partial class MosaicForm : Form
    {
        private PictureBox pictureBox;
        private Form1 form;

        public MosaicForm(PictureBox pictureBox, Form1 form)
        {
            InitializeComponent();
            this.pictureBox = pictureBox;
            this.form = form;
        }

        public Image<Bgr, Byte> GetMosaic(Image<Bgr, Byte> sourceImage, int matrixWidthSize, int matrixHeightSize)
        {
            Image<Bgr, Byte> image = new Image<Bgr, Byte>(sourceImage.Width, sourceImage.Height);
            for (int y = 0; y < sourceImage.Height; y += matrixHeightSize)
            {
                for (int x = 0; x < sourceImage.Width; x += matrixWidthSize)
                {
                    int[] value = new int[sourceImage.Data.GetLength(2)];
                    int n = 0;
                    int i;
                    int my = y - matrixHeightSize / 2;
                    my = Math.Max(my, 0);
                    int mx = x - matrixWidthSize / 2;
                    mx = Math.Max(mx, 0);
                    for (i = 0; i < matrixHeightSize && my + i < sourceImage.Height; i++)
                    {
                        int j;
                        for (j = 0; j < matrixWidthSize && mx + j < sourceImage.Width; j++)
                        {
                            for (int z = 0; z < sourceImage.Data.GetLength(2); z++)
                            {
                                value[z] += sourceImage.Data[my + i, mx + j, z];
                            }
                            n++;
                        }
                    }
                    if (n > 0)
                        for (int z = 0; z < sourceImage.Data.GetLength(2); z++)
                        {
                            value[z] /= n;
                        }
                    for (i = 0; i < matrixHeightSize && my + i < sourceImage.Height; i++)
                    {
                        int j;
                        for (j = 0; j < matrixWidthSize && mx + j < sourceImage.Width; j++)
                        {
                            for (int z = 0; z < sourceImage.Data.GetLength(2); z++)
                            {
                                image.Data[my + i, mx + j, z] = (byte)value[z];
                            }
                        }
                    }
                }
            }
            return image;
        }

        private void mosaicButton_Click(object sender, EventArgs e)
        {
            pictureBox.Image = GetMosaic(form.Image, (int)numericUpDown1.Value, (int)numericUpDown2.Value).ToBitmap();
        }
    }
}
