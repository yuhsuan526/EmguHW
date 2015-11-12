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
    public partial class Form1 : Form
    {
        private Image<Bgr, Byte> My_Image;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Openfile = new OpenFileDialog();
            if (Openfile.ShowDialog() == DialogResult.OK)
            {
                My_Image = new Image<Bgr, byte>(Openfile.FileName);
                pictureBox1.Image = My_Image.ToBitmap();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < My_Image.Data.GetLength(0); y++)
            {
                for (int x = 0; x < My_Image.Data.GetLength(1); x++)
                {
                    int gray = 0;
                    for (int z = 0; z < My_Image.Data.GetLength(2); z++)
                    {
                        gray += My_Image.Data[y, x, z];
                    }
                    gray /= 3;
                    for (int z = 0; z < My_Image.Data.GetLength(2); z++)
                    {
                        My_Image.Data[y, x, z] = (byte)gray;
                    }
                }
            }
            pictureBox1.Image = My_Image.ToBitmap();
        }
    }
}
