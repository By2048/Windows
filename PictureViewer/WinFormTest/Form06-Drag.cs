using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormTest
{
    public partial class Form06Drag : Form
    {
        public Form06Drag()
        {
            InitializeComponent();
        }
        //DragDrop：拖放操作完成时发生。
        //DragEnter：在将对象拖入控件的边界时发生。
        //DragLeave：在将对象拖出控件的边界时发生。
        //DragOver：在将对象拖到控件的边界上发生。
        private void Form6_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string path = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
                pictureBox1.Image = (Bitmap)Bitmap.FromFile(path);
            }
            else if (e.Data.GetDataPresent(DataFormats.Text))
            {
                label1.Text = (e.Data.GetData(DataFormats.Text)).ToString();
            }
            //Bitmap bits = (Bitmap)Bitmap.FromFile(e.Data.GetData(DataFormats.Text).ToString());
            //pictureBox1.Image = bits;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            AllowDrop = true;
        }

        private void Form6_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Link;
            }
           
        }
    }
}

