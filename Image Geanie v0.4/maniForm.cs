using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Image_Geanie_v0._4
{
    public partial class maniForm : Form
    {
        public maniForm()
        {
            InitializeComponent();
        }

        private void imageComparisonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageCompareForm compareForm = new imageCompareForm();
            compareForm.Show();
        }
    }
}
