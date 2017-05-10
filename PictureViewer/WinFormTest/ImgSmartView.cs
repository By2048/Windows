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
    public partial class ImgSmartView : UserControl
    {
        public ImgSmartView(string folderPath, Size panelSize, Size imageSize)
        {
            InitializeComponent();
            Size = panelSize;
            panel1.AutoScroll = true;
            ShowPictureByFolder(folderPath, panelSize, imageSize);
        }

        private void ShowPictureByFolder(string folderPath, Size panelSize, Size imageSize)

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
                    panel1.Controls.Add(pictureBox);
                }
            }
        }
        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Image image = pictureBox.Image;
            FormLarge formLarge = new FormLarge();
            formLarge.Size = new Size(image.Width, image.Height);
            formLarge.BackgroundImage = image;
            formLarge.BackgroundImageLayout = ImageLayout.Zoom;
            formLarge.Show();
        }
    }
}
