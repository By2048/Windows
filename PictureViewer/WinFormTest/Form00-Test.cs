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
            string path = @"F:\Test\16b25.jpg";
            MessageBox.Show(Path.GetDirectoryName(path));
        }

    }
}
