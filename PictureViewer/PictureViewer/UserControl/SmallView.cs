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
    public partial class SmallView : UserControl
    {
        /// <summary>
        /// 使用MainConfig加载
        /// </summary>
        public SmallView()
        {
            InitializeComponent();
            Size = MainConfig.PanelMainSize;
            panelMain.AutoScroll = true;
            ShowSmallImages();
        }

        /// <summary>
        /// 传入参数加载
        /// </summary>
        /// <param name="path">显示的路径</param>
        /// <param name="panelSize">panel容器的大小</param>
        /// <param name="imageSize">显示的图片大小</param>
        public SmallView(string path, Size panelSize, Size imageSize)
        {
            InitializeComponent();
            Size = panelSize;
            panelMain.AutoScroll = true;
            ShowSmallImages(path, panelSize, imageSize);
        }

        private void SmallView_Load(object sender, EventArgs e)
        {
            ParentForm.KeyDown += new KeyEventHandler(SmallView_KeyDown);
            ParentForm.KeyPress += new KeyPressEventHandler(SmallView_KeyPress);
            ParentForm.KeyUp += new KeyEventHandler(SmallView_KeyUp);
            //CollectionTool
        }

        private void ShowSmallImages(string path, Size panelSize, Size imageSize)
        {
            string[] pictures = ImageTool.GetAllImagePath(path);

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
                    int index = row * columnCount + column; // 图片下标
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Size = imageSize;
                    if (index >= pictureCount) { return; }

                    pictureBox.Image = ImageTool.LoadImage(pictures[index]);
                    pictureBox.Tag = pictures[index];

                    Point pictureLoction = new Point()
                    {
                        X = pictureBox.Width * column + padding * (column + 1),
                        Y = pictureBox.Height * row + padding * (row + 1)
                    };

                    pictureBox.Location = pictureLoction;
                    pictureBox.DoubleClick += pictureBox_DoubleClick;
                    pictureBox.MouseDown += pictureBox_MouseDown;
                    panelMain.Controls.Add(pictureBox);
                }
            }


        }

        private void ShowSmallImages()
        {
            string[] pictures = ImageTool.GetAllImagePath(MainConfig.ShowFolderPath);

            int pictureCount = pictures.Length;

            int padding = 2;
            int columnCount = MainConfig.PanelMainSize.Width / MainConfig.ImageSize.Width;
            int rowCount = (pictureCount % columnCount == 0) ?
                pictureCount / columnCount :
                (pictureCount / columnCount) + 1;

            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    int index = row * columnCount + column; // 图片下标
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Size = MainConfig.ImageSize;
                    if (index >= pictureCount) { return; }

                    //pictureBox.Load(pictures[index]);
                    //pictureBox.Image = Image.FromFile(pictures[index]);
                    //FileStream fs = new FileStream(pictures[index], FileMode.Open);
                    //Bitmap bm = new Bitmap(fs);
                    //fs.Dispose();
                    //pictureBox.Image = bm;

                    pictureBox.Image = ImageTool.LoadImage(pictures[index]);
                    pictureBox.Tag = pictures[index];

                    Point pictureLoction = new Point()
                    {
                        X = pictureBox.Width * column + padding * (column + 1),
                        Y = pictureBox.Height * row + padding * (row + 1)
                    };

                    pictureBox.Location = pictureLoction;
                    pictureBox.DoubleClick += pictureBox_DoubleClick;
                    pictureBox.MouseDown += pictureBox_MouseDown;
                    panelMain.Controls.Add(pictureBox);
                }
            }
        }

        private void SmallView_KeyUp(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("Up");
        }

        private void SmallView_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show("Press");
        }

        private void SmallView_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("Down");
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            string filePath = pictureBox.Tag.ToString();
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip = ImageTool.CreateContextMenuStrip(filePath);
            }
        }

        // 双击显示大图
        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            string filePath = pictureBox.Tag.ToString();
            ShowForm showForm = new ShowForm();
            showForm.imgPath = filePath;
            showForm.Show();
        }


    }
}
