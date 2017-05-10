using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinFormTest
{
    public partial class Form00 : Form
    {
        public Form00()
        {
            InitializeComponent();
        }

        private void Form00_Load(object sender, EventArgs e)
        {
            CenterToScreen();

            string path = @"F:\Test\002.jpg";
            FileStream fs = new FileStream(path, FileMode.Open);
            Bitmap bt = new Bitmap(fs);

            fs.Dispose();

            pictureBox1.Image = bt;

            //pictureBox1.Load(path);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //pictureBox1.Image.Dispose();
            //pictureBox1.Image = null;
            string path = @"F:\Test\002.jpg";
            File.Delete(path);
        }
    }
}


//FileStream fs = new FileStream(imagePath[pictureIndex], FileMode.Open);
//Bitmap bm = new Bitmap(fs);
//fs.Dispose();
//pictureBox.Image = bm;