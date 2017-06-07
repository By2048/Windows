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
    public partial class Form20 : Form
    {
        public Form20()
        {
            InitializeComponent();
        }

        private void Form20_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            string imgPath = @"F:\Test\001.jpg";
            PicBox picBox = new PicBox(imgPath, new Size(150, 150));
            Controls.Add(picBox);
        }
    }
}
