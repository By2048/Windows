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

namespace WinFormTest
{
    public partial class UserControl3 : UserControl
    {
        public UserControl3(string folderPath, Size panelSize)
        {
            InitializeComponent();

            Size = panelSize;

            splitContainer1.SplitterDistance = int.Parse(Math.Round(Size.Width * (0.618)).ToString());
            splitContainer2.SplitterDistance = int.Parse(Math.Round(Size.Height * (1 - 0.618)).ToString());

            panelSmallImages.AutoScroll = true;
            pictureBoxLarge.SizeMode = PictureBoxSizeMode.Zoom;

            ShowPictureByFolder(folderPath, panelSize);


        }

        private void ShowPictureByFolder(string folderPath, Size panelSize)
        {
            string[] pictures = Directory.GetFiles(folderPath, "*jpg");
            int pictureCount = pictures.Length;

            int columnCount = panelSize.Width / 100;
            int rowCount = (pictureCount % columnCount == 0) ?
                pictureCount / columnCount :
                (pictureCount / columnCount) + 1;

            int padding = 2;
            int pictureWidth = panelSize.Width / columnCount - 2 * padding;
            int pictureHeight = pictureWidth * 9 / 16; // 16*9比例

            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    int index = row * columnCount + column;
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Width = pictureWidth;
                    pictureBox.Height = pictureHeight;
                    if (index >= pictureCount) { return; }
                    //pictureBox.Image = Image.FromFile(pictures[pictureIndex]);
                    pictureBox.Load(pictures[index]);
                    Point pictureLoction = new Point();
                    pictureLoction.X = padding * (column + 1) + pictureWidth * column;
                    pictureLoction.Y = padding * (row + 1) + pictureHeight * row;
                    pictureBox.Location = pictureLoction;
                    pictureBox.Click += pictureBox_Click;
                    panelSmallImages.Controls.Add(pictureBox);
                }
            }
            pictureBoxLarge.Load(pictures[0]);
            ShowImageInfo(Path.GetFullPath(pictures[0]));
        }
        private void pictureBox_Click(object sender, EventArgs e)
        {
            //PictureBox selectPicture = (PictureBox)sender;
            PictureBox selectPicture = sender as PictureBox;
            pictureBoxLarge.Load(selectPicture.ImageLocation);
            string selectImagePath = Path.GetFullPath(selectPicture.ImageLocation);
            ShowImageInfo(selectImagePath);
        }

        private void ShowImageInfo(string filePath)
        {
            Image image = Image.FromFile(filePath);
            Size imageSize=image.Size;

            

            FileInfo fileInfo = new FileInfo(filePath);
            string fileName = fileInfo.Name;    // 1.jpg
            string fileDirectoryName = fileInfo.DirectoryName;  // F:\Test
            double fileSize = fileInfo.Length/1000.0;   // 72.121
            //string fileType = path.Split('.').Last();
            string fileType = fileInfo.Extension.Trim('.').ToString(); // jpg
            DateTime createTime = fileInfo.CreationTime;    // 创建时间
            DateTime lastWriteTime = fileInfo.LastWriteTime;   // 修改时间
            DateTime lastAccessTime = fileInfo.LastAccessTime;  // 上次访问时间

            MessageBox.Show(fileDirectoryName.ToString());
        }

    }
}
