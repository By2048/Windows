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
    public partial class Form13 : Form
    {
        private string folderPath = @"F:\Test\媚眼柔嫩娇滴滴 爆乳萌妹子猫儿蜜糖化身性感女仆被调教";

        public Form13()
        {
            InitializeComponent();
            this.Resize += new System.EventHandler(this.Form13_Resize);
        }

        private UserControl3 userControl;

        private void Form13_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            userControl = new UserControl3(folderPath,Size);
            panelImageShow.Controls.Add(userControl);
        }

        private void Form13_Resize(object sender, EventArgs e)
        {

            panelImageShow.Controls.Remove(userControl);
            userControl = new UserControl3(folderPath,Size);
            panelImageShow.Controls.Add(userControl);
        }


    }
}
