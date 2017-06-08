using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureViewer
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            string imgPath = @"F:\Test\000.jpg";
            PicBox picBox = new PicBox(imgPath, new Size(150, 150));
            Controls.Add(picBox);
        }
    }
}
