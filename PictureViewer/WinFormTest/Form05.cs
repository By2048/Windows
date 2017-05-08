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
    public partial class Form05 : Form
    {
        
        private UserControl1 userControl;
        private string folderPath = @"F:\Test\媚眼柔嫩娇滴滴 爆乳萌妹子猫儿蜜糖化身性感女仆被调教";

        public Form05()
        {
            InitializeComponent();
            panPicShow.AutoScroll = false;
        }
        private void Form05_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            LoadUserControl();
        }

        private void Form05_Resize(object sender, EventArgs e)
        {
            panPicShow.Controls.Remove(userControl);
            userControl.Dispose();
            LoadUserControl();
        }

        private void LoadUserControl()
        {
            userControl = new UserControl1(folderPath, panPicShow.Width, panPicShow.Height);
            panPicShow.Controls.Add(userControl);
        }

        //private void btnOk_Click(object sender, EventArgs e)
        //{
        //    FolderBrowserDialog folderDlg = new FolderBrowserDialog(); //新建打开对话框

        //    //folderDlg.SelectedPath = "F:\\照片\\乱七八糟\\贴图"; //设置默认路径
        //    folderDlg.ShowNewFolderButton = false; //取消“新建文件夹”按钮
        //    DialogResult dlgResult = folderDlg.ShowDialog(); //得到所取图片


        //    if (dlgResult == DialogResult.Cancel)
        //    {
        //        return;
        //    }
        //    string path = folderDlg.SelectedPath;

        //    this.txtWay.Text = path;
        //    panPicShow.BackColor = Color.Black;
        //    showPicByFolder(path);

        //}

        //private void panPicShow_DoubleClick(object sender, EventArgs e)
        //{
        //    PictureBox pictureBox = (PictureBox)sender;
        //    Image image = pictureBox.Image;//获取该PictureBox控件中的图像
        //    //FormLarge formLarge = new FormLarge();
        //    //formLarge.BackgroundImage = image;
        //    //formLarge.BackgroundImageLayout = ImageLayout.Zoom;
        //    //formLarge.Show();
        //}


    }
}
