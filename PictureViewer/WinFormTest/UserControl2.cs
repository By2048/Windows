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
    public partial class UserControl2 : UserControl
    {
        public UserControl2(string folderPath, Size panelSize)
        {
            InitializeComponent();
            Size = panelSize;

            splitContainer1.SplitterDistance = Size.Height / 5*4;
            //panelLargeImage.BackColor = Color.Red;
            //panelSmallImages.BackColor = Color.Green;

            panelLargeImage.BackgroundImage = null;
            panelLargeImage.BackgroundImageLayout = ImageLayout.Zoom;

            panelSmallImages.AutoScroll = true;

            ShowPictureByFolder(folderPath, panelSize);
        }
        private void ShowPictureByFolder(string folderPath, Size panelSize)
        {
            string[] pictures = Directory.GetFiles(folderPath, "*jpg");
            int pictureCount = pictures.Length;

            int padding = 2;
            int pictureHeight = panelSmallImages.Height - 17;
            int pictureWidth = pictureHeight * 16 / 9;

            for (int cnt = 0; cnt < pictureCount; cnt++)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Width = pictureWidth;
                pictureBox.Height = pictureHeight;
                pictureBox.Image = Image.FromFile(pictures[cnt]);

                Point pictureLoction = new Point();
                pictureLoction.X = padding * (cnt + 1) + pictureWidth * cnt;
                pictureLoction.Y = 0;
                pictureBox.Location = pictureLoction;
                pictureBox.Click += pictureBox_Click;
                panelSmallImages.Controls.Add(pictureBox);
            }
            panelLargeImage.BackgroundImage = Image.FromFile(pictures[0]);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Image image = pictureBox.Image;
            panelLargeImage.BackgroundImage = image;
        }
    }
}
