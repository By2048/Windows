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

            panel1.BackColor = Color.Red;
            panel2.BackColor = Color.Green;

            panel2.Focus();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

    }
}
