using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PictureViewer
{
    public partial class ImgSmallView : UserControl
    {
        public ImgSmallView(string folderPath, Size panelSize, Size imageSize)
        {
            InitializeComponent();
            Size = panelSize;
            panelMain.AutoScroll = true;
            ShowSmallImages(folderPath, panelSize, imageSize);
        }

        // 缩略图模式 文件路径 窗体大小  需要显示的图片大小
        private void ShowSmallImages(string folderPath, Size panelSize, Size imageSize)
        {
            string[] pictures = Directory.GetFiles(folderPath, "*jpg");
            int pictureCount = pictures.Length;

            int padding = 2;
            int columnCount = panelSize.Width / imageSize.Width;
            int rowCount = (pictureCount % columnCount == 0) ?
                pictureCount / columnCount :
                (pictureCount / columnCount) + 1;

            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    int pictureIndex = row * columnCount + column; // 图片下标
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Size = imageSize;
                    if (pictureIndex >= pictureCount) { return; }
                    pictureBox.Image = Image.FromFile(pictures[pictureIndex]);
                    Point pictureLoction = new Point()
                    {
                        X = pictureBox.Width * column + padding * (column + 1),
                        Y = pictureBox.Height * row + padding * (row + 1)
                    };
                    pictureBox.Location = pictureLoction;
                    pictureBox.DoubleClick += pictureBox_DoubleClick;
                    panelMain.Controls.Add(pictureBox);
                }
            }
        }
        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Image image = pictureBox.Image;
            ShowImage newForm = new ShowImage();
            newForm.SetImage(image);
            newForm.Show();
        }
    }
}
