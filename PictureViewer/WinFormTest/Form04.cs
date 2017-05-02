using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Runtime.InteropServices;

namespace WinFormTest
{
    public partial class Form04 : Form
    {
        public Form04()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            Image O_Image = Image.FromStream(WebRequest.Create("http://www.baidu.com/img/baidu_logo.gif").GetResponse().GetResponseStream());
            pictureBox1.Image = O_Image;
            //SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DropSHADOW);
        }
        Pen aPen;
        private void Form4_Paint(object sender, PaintEventArgs e)
        {
            aPen = new Pen(Color.Gray,4);
            e.Graphics.DrawRectangle(aPen, 0, 0, this.Width, this.Height);
        }
        #region 窗体边框阴影效果变量申明
        const int CS_DropSHADOW = 0x20000;
        const int GCL_STYLE = (-26);
        //声明Win32 API
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);
        #endregion
    }
}
