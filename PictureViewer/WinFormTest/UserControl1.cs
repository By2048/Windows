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
    public partial class UserControl1 : UserControl
    {
        public UserControl1(string folderPath, int panelWidth, int panelHeight)
        {
            InitializeComponent();

            Width = panelWidth;
            Height = panelHeight;

            panel1.AutoScroll = true;
            //panel1.AutoScrollMinSize = new Size(panelWidth-20,panelHeight-20);

            ShowPictureByFolder(folderPath, panelWidth, panelHeight);
        }

        private void ShowPictureByFolder(string folderPath, int panelWidth, int panelHeight)
        {
            string[] pictures = Directory.GetFiles(folderPath, "*jpg");
            int pictureCount = pictures.Length;

            int columnCount = panelWidth / 100;
            int rowCount = (pictureCount % columnCount == 0) ?
                pictureCount / columnCount :
                (pictureCount / columnCount) + 1;

            int padding = 2;
            int pictureWidth = panelWidth / columnCount - 2 * padding;
            int pictureHeight = pictureWidth * 9 / 16; // 16*9比例

            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    int pictureIndex = row * columnCount + column; // 图片下标
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Width = pictureWidth;
                    pictureBox.Height = pictureHeight;
                    if (pictureIndex >= pictureCount) { return; }
                    pictureBox.Image = Image.FromFile(pictures[pictureIndex]);
                    Point pictureLoction = new Point();
                    pictureLoction.X = padding * (column + 1) + pictureWidth * column;
                    pictureLoction.Y = padding * (row + 1) + pictureHeight * row;
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
            formLarge.Size = new Size(image.Width,image.Height);
            formLarge.BackgroundImage = image;
            formLarge.BackgroundImageLayout = ImageLayout.Zoom;
            formLarge.Show();            
        }
    }
}
