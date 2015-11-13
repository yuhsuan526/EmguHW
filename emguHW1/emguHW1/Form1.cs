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
            FoundationForm foundationForm = new FoundationForm(pictureBox1, this);
            foundationForm.TopLevel = false;
            tabControl1.TabPages[0].Controls.Add(foundationForm);
            foundationForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            foundationForm.Dock = DockStyle.Fill;
            foundationForm.Show();

            MosaicForm mosaicForm = new MosaicForm(pictureBox1, this);
            mosaicForm.TopLevel = false;
            tabControl1.TabPages[1].Controls.Add(mosaicForm);
            mosaicForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            mosaicForm.Dock = DockStyle.Fill;
            mosaicForm.Show();

            AveragingForm averagingForm = new AveragingForm(pictureBox1, this);
            averagingForm.TopLevel = false;
            tabControl1.TabPages[2].Controls.Add(averagingForm);
            averagingForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            averagingForm.Dock = DockStyle.Fill;
            averagingForm.Show();
        }

        public Image<Bgr, Byte> Image
        {
            get
            {
                return My_Image;
            }
            set
            {
                My_Image = value;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog Openfile = new OpenFileDialog();
            if (Openfile.ShowDialog() == DialogResult.OK)
            {
                My_Image = new Image<Bgr, byte>(Openfile.FileName);
                pictureBox1.Image = My_Image.ToBitmap();
            }
        }
    }
}
