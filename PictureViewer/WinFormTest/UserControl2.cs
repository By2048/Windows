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

            panelLargeImage.Size = new Size(Size.Width, Size.Height / 5 * 4-20);
            panelLargeImage.Location = new Point(0, 0);
            panelLargeImage.BackgroundImage = null;
            panelLargeImage.BackgroundImageLayout = ImageLayout.Zoom;
            //panelLargeImage.BackColor = Color.Red;

            panelSmallImage.Size = new Size(Size.Width, Size.Height - panelLargeImage.Height+20);
            panelSmallImage.Location = new Point(0, panelLargeImage.Height+20);
            panelSmallImage.AutoScroll = true;
            //panelSmallImage.BackColor = Color.Green;

            ShowPictureByFolder(folderPath, panelSize);
        }
        private void ShowPictureByFolder(string folderPath, Size panelSize)
        {
            string[] pictures = Directory.GetFiles(folderPath, "*jpg");
            int pictureCount = pictures.Length;

            int padding = 2;
            int pictureHeight = panelSmallImage.Height - 17;
            int pictureWidth = pictureHeight* 16 / 9;

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
                panelSmallImage.Controls.Add(pictureBox);
            }
            panelLargeImage.BackgroundImage= Image.FromFile(pictures[0]);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Image image = pictureBox.Image;
            panelLargeImage.BackgroundImage = image;            
        }
    }
}
