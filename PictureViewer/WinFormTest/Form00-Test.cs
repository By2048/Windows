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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string path = @"F:\Test\16b34.jpg";
            string path = @"F:\Test";
            if (File.Exists(path))
            {
                MessageBox.Show("File");
            }
            else if (Directory.Exists(path))
            {
                MessageBox.Show("Dir");
            }
            else
            {
                MessageBox.Show("No");
            }
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
