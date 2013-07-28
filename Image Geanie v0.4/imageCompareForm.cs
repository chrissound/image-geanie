using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Image_Geanie_v0._4
{
    public partial class imageCompareForm : Form
    {
        string img1src;
        string img2src;

        public imageCompareForm()
        {
            InitializeComponent();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            oFileDialog.ShowDialog();
            img1src = oFileDialog.FileName;
            textBox1.Text = oFileDialog.FileName;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            oFileDialog.ShowDialog();
            img2src = oFileDialog.FileName;
            textBox2.Text = oFileDialog.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            ImageCompare imageCompare = new ImageCompare(img1src, img2src);

            if (imageCompare.error == false)
            {
                double match = imageCompare.compareImages();
                listBox1.Items.Add("Percentage Match: " + match * 100 + "%");

                Bitmap image = imageCompare.getBitmapHistogram();
                Graphics imgG = Graphics.FromImage(image);
                pictureBox1.Image = image;

                listBox1.Items.Add("Lowest Match: " + imageCompare.lowestMatch);
            }
            else
            {
                MessageBox.Show("Files do not exist or are not the same dimensions.");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            int a = 1;
            int b = 3;
            decimal bob = a / Convert.ToDecimal(b);
            MessageBox.Show(Convert.ToString(bob));
        }
    }
}
