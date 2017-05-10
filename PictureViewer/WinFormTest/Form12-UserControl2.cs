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
    public partial class Form12 : Form
    {
        private ImgLargeView userControl;
        private string folderPath = @"F:\Test\媚眼柔嫩娇滴滴 爆乳萌妹子猫儿蜜糖化身性感女仆被调教";

        public Form12()
        {
            InitializeComponent();
            this.Resize += new System.EventHandler(this.Form12_Resize);
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            LoadUserControl();
        }
        private void Form12_Resize(object sender, EventArgs e)
        {
            panelShowImage.Controls.Remove(userControl);
            userControl.Dispose();
            LoadUserControl();
        }

        private void LoadUserControl()
        {
            userControl = new ImgLargeView(folderPath, panelShowImage.Size);
            panelShowImage.Controls.Add(userControl);
        }

       
    }
}
