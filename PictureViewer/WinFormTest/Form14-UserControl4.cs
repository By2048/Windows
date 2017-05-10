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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
            this.Resize += new System.EventHandler(this.Form14_Resize);
        }
        private ImgListView userControl;
        private string folderPath = @"F:\Test\媚眼柔嫩娇滴滴 爆乳萌妹子猫儿蜜糖化身性感女仆被调教";

        private void Form14_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            userControl = new ImgListView(folderPath, Size);
            panelImageShow.Controls.Add(userControl);
        }
        private void Form14_Resize(object sender, EventArgs e)
        {
            panelImageShow.Controls.Remove(userControl);
            userControl = new ImgListView(folderPath, Size);
            panelImageShow.Controls.Add(userControl);
        }


    }
}
