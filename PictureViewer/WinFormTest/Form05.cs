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

        public Form05()
        {
            InitializeComponent();
        }
        private void Form05_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            LoadUserControl();
            //ShowPictureByFolder(@"F:\Test\媚眼柔嫩娇滴滴 爆乳萌妹子猫儿蜜糖化身性感女仆被调教");
        }
        //private void ShowPictureByFolder(string folderPath)
        //{

        //    string[] pictures = Directory.GetFiles(folderPath, "*jpg");
        //    int pictureCount = pictures.Length;

        //    int columnCount = panPicShow.Width / 100;
        //    int rowCount = (pictureCount % columnCount == 0) ?
        //        pictureCount / columnCount :
        //        (pictureCount / columnCount) + 1;

        //    int padding = 2;
        //    int pictureWidth = this.panPicShow.Width / columnCount - 2 * padding;
        //    int pictureHeight = pictureWidth * 9 / 16; //16*9比例

        //    for (int row = 0; row < rowCount; row++)
        //    {
        //        for (int column = 0; column < columnCount; column++)
        //        {
        //            int pictureIndex = row * columnCount + column;//图片下标
        //            PictureBox pictureBox = new PictureBox();
        //            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        //            pictureBox.Width = pictureWidth;
        //            pictureBox.Height = pictureHeight;
        //            if (pictureIndex >= pictureCount)
        //            {
        //                return;
        //            }
        //            pictureBox.Image = Image.FromFile(pictures[pictureIndex]);
        //            Point pictureLoction = new Point();
        //            pictureLoction.X = padding * (column + 1) + pictureWidth * column;
        //            pictureLoction.Y = padding * (row + 1) + pictureHeight * row;
        //            pictureBox.Location = pictureLoction;
        //            //pictureBox.DoubleClick += panPicShow_DoubleClick;
        //            panPicShow.Controls.Add(pictureBox);

        //        }
        //    }
        //}

        private void Form05_Resize(object sender, EventArgs e)
        {
            LoadUserControl();
        }

        private UserControl1 userControl;
        private string folderPath = @"F:\Test\媚眼柔嫩娇滴滴 爆乳萌妹子猫儿蜜糖化身性感女仆被调教";
        private void LoadUserControl()
        {
            userControl = new UserControl1(folderPath, panPicShow.Width, panPicShow.Height);
            userControl.Location = new Point(0, 0);
            userControl.Size = new Size(panPicShow.Width, panPicShow.Height);

            //  this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            //| System.Windows.Forms.AnchorStyles.Left)
            //| System.Windows.Forms.AnchorStyles.Right)));
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
