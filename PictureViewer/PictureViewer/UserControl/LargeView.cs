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
    public partial class LargeView : UserControl
    {
        public LargeView()
        {
            InitializeComponent();
            Size = MainConfig.PanelMainSize;

            splitContainer1.SplitterDistance = Size.Height / 5 * 4;

            pictureBoxLarge.Image = null;
            pictureBoxLarge.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLarge.DoubleClick += pictureBox_DoubleClick;

            panelSmallImage.AutoScroll = true;

            ShowSmallImages();
        }
        private void ShowSmallImages()
        {

            string[] pictures = ImageTool.GetAllImagePath(MainConfig.ShowFolderPath);

            int pictureCount = pictures.Length;

            int padding = 2;
            int pictureHeight = panelSmallImage.Height - 17;
            int pictureWidth = pictureHeight * 16 / 9;

            for (int index = 0; index < pictureCount; index++)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Width = pictureWidth;
                pictureBox.Height = pictureHeight;

                //pictureBox.Image = Image.FromFile(pictures[index]);
                pictureBox.Image = ImageTool.LoadImage(pictures[index]);
                pictureBox.Tag = pictures[index];
                //FileStream fs = new FileStream(pictures[cnt], FileMode.Open);
                //Bitmap bm = new Bitmap(fs);
                //fs.Dispose();
                //pictureBox.Image = bm;

                Point pictureLoction = new Point()
                {
                    X = padding * (index + 1) + pictureWidth * index,
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
            string filePath = pictureBox.Tag.ToString();
            //Image image = pictureBox.Image;
            ShowForm newForm = new ShowForm();
            newForm.imgPath = filePath;
            //newForm.SetPictureBoxByImage(image);
            newForm.Show();
        }

    }
}
