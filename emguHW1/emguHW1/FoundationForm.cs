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
    public partial class FoundationForm : Form
    {
        private PictureBox pictureBox;
        private Form1 form;

        public FoundationForm(PictureBox pictureBox, Form1 form)
        {
            InitializeComponent();
            this.pictureBox = pictureBox;
            this.form = form;
        }

        public Image<Bgr, Byte> GetGrayScale(Image<Bgr, Byte> sourceImage)
        {
            Image<Bgr, Byte> image = new Image<Bgr, Byte>(sourceImage.Width, sourceImage.Height);
            for (int y = 0; y < sourceImage.Height; y++)
            {
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    int gray = 0;
                    for (int z = 0; z < sourceImage.Data.GetLength(2); z++)
                    {
                        gray += sourceImage.Data[y, x, z];
                    }
                    gray /= 3;
                    for (int z = 0; z < sourceImage.Data.GetLength(2); z++)
                    {
                        image.Data[y, x, z] = (byte)gray;
                    }
                }
            }
            return image;
        }

        public Image<Bgr, Byte> GetThresholding(Image<Bgr, Byte> sourceImage, int threshold)
        {
            Image<Bgr, Byte> image = new Image<Bgr, Byte>(sourceImage.Width, sourceImage.Height);
            for (int y = 0; y < sourceImage.Height; y++)
            {
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    int gray = 0;
                    for (int z = 0; z < sourceImage.Data.GetLength(2); z++)
                    {
                        gray += sourceImage.Data[y, x, z];
                    }
                    gray /= 3;
                    if (gray >= threshold)
                    {
                        for (int z = 0; z < sourceImage.Data.GetLength(2); z++)
                        {
                            image.Data[y, x, z] = (byte)255;
                        }
                    }
                    else
                    {
                        for (int z = 0; z < sourceImage.Data.GetLength(2); z++)
                        {
                            image.Data[y, x, z] = (byte)0;
                        }
                    }
                }
            }
            return image;
        }

        public Image<Bgr, Byte> GetInverse(Image<Bgr, Byte> sourceImage)
        {
            Image<Bgr, Byte> image = new Image<Bgr, Byte>(sourceImage.Width, sourceImage.Height);
            for (int y = 0; y < sourceImage.Height; y++)
            {
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    for (int z = 0; z < sourceImage.Data.GetLength(2); z++)
                    {
                        image.Data[y, x, z] = (byte)(255 - sourceImage.Data[y, x, z]);
                    }
                }
            }
            return image;
        }

        private void grayScaleButton_Click(object sender, EventArgs e)
        {
            pictureBox.Image = GetGrayScale(form.Image).ToBitmap();
        }

        private void InversingButton_Click(object sender, EventArgs e)
        {
            pictureBox.Image = GetInverse(form.Image).ToBitmap();
        }

        private void thresholdingButton_Click(object sender, EventArgs e)
        {
            pictureBox.Image = GetThresholding(form.Image, trackBar1.Value).ToBitmap();
        }

    }
}
