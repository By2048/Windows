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
    public partial class ImgLargeView : UserControl
    {
        public ImgLargeView(string folderPath, Size panelSize)
        {
            InitializeComponent();
            Size = panelSize;

            splitContainer1.SplitterDistance = Size.Height / 5 * 4;

            pictureBoxLarge.Image = null;
            pictureBoxLarge.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLarge.DoubleClick += pictureBox_DoubleClick;

            panelSmallImage.AutoScroll = true;

            ShowSmallImages(folderPath, panelSize);
        }
        private void ShowSmallImages(string folderPath, Size panelSize)
        {
            string[] pictures = Directory.GetFiles(folderPath, "*jpg");
            int pictureCount = pictures.Length;

            int padding = 2;
            int pictureHeight = panelSmallImage.Height - 17;
            int pictureWidth = pictureHeight * 16 / 9;

            for (int cnt = 0; cnt < pictureCount; cnt++)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Width = pictureWidth;
                pictureBox.Height = pictureHeight;
                pictureBox.Image = Image.FromFile(pictures[cnt]);
                Point pictureLoction = new Point()
                {
                    X = padding * (cnt + 1) + pictureWidth * cnt,
                    Y = 0
                };
                pictureBox.Location = pictureLoction;
                pictureBox.Click += smallPictureBox_Click;
                pictureBox.DoubleClick += pictureBox_DoubleClick;
                panelSmallImage.Controls.Add(pictureBox);
            }
            pictureBoxLarge.Image = Image.FromFile(pictures[0]);
        }

        private void smallPictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Image image = pictureBox.Image;
            pictureBoxLarge.Image= image;
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
