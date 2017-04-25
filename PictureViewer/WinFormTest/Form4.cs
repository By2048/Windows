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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }
        Pen aPen;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            aPen = new Pen(Color.Blue, 6);
            e.Graphics.DrawRectangle(aPen, 0, 0, this.Width, this.Height);

        }
    }
}
