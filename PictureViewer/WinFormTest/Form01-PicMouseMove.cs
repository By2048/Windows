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

        bool selected = false;
        Point curPoint = new Point();
        private void Form_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            selected = true;
            curPoint.X = e.X;
            curPoint.Y = e.Y;
        }
        Point diffPoint = new Point(0, 0);
        Point newPoint = new Point(0, 0);

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (selected)
            {
                diffPoint.X = curPoint.X - e.X;
                diffPoint.Y = curPoint.Y - e.Y;

                newPoint.X = newPoint.X - diffPoint.X;
                newPoint.Y = newPoint.Y - diffPoint.Y;

                Bitmap bm = new Bitmap(pictureBox.Image);

                Graphics g = pictureBox.CreateGraphics();
                g.Clear(pictureBox.BackColor);

                int w = bm.Width/2;
                int h = bm.Height/2;

                g.DrawImage(bm, newPoint.X, newPoint.Y,w,h);

                curPoint.X = e.X;
                curPoint.Y = e.Y;

                bm.Dispose();
                g.Dispose();
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            selected = false;
        }

      
    }
}
