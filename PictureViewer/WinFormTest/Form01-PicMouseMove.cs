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
    public partial class Form01 : Form
    {
        public Form01()
        {
            InitializeComponent();
        }

        bool wselected = false;
        Point curPoint = new Point();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            wselected = true;
            curPoint.X = e.X;
            curPoint.Y = e.Y;
        }
        Point diffPoint = new Point(0, 0);
        //int driftX = 0, driftY = 0;
        Point movePoint = new Point(0, 0);
        //int mx = 0, my = 0;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (wselected)
            {
                diffPoint.X = curPoint.X - e.X;
                diffPoint.Y = curPoint.Y - e.Y;

                movePoint.X = movePoint.X - diffPoint.X;
                movePoint.Y = movePoint.Y - diffPoint.Y;

                Bitmap bm = new Bitmap(this.pictureBox1.Image);

                Graphics g = pictureBox1.CreateGraphics();
                g.Clear(pictureBox1.BackColor);
                g.DrawImage(bm, movePoint.X, movePoint.Y);

                curPoint.X = e.X;
                curPoint.Y = e.Y;

                bm.Dispose();
                g.Dispose();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            wselected = false;
        }

      
    }
}
