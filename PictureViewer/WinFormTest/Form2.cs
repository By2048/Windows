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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            //this.AutoScrollMinSize = new Size(1980,1080);
            //this.AutoScrollMargin = new Size(5,5);
            //this.AutoScroll = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
             this.ClientSize = new System.Drawing.Size(500, 500);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //当前的屏幕除任务栏外的工作域大小
        //this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
        //this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;

        //当前的屏幕包括任务栏的工作域大小
        //this.Width=System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        //this.Height=System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

        //任务栏大小
        //this.Width=System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width-System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
        //this.Height=System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height-System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;

        //winform实现全屏显示
        //WinForm:
        //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        //this.TopMost = true;  

        private void button2_Click(object sender, EventArgs e)
        {
            //int Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            //int Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;

            //int Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            //int Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

            int Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            int Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;


            MessageBox.Show(Width.ToString() + "\n" + Height.ToString());
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
