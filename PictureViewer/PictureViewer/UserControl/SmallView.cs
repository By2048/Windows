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
        /// 根据传入的窗体大小和图片大小来初始化SmallView
        /// </summary>
        /// <param name="panelSize">窗体中SmallView需要展示的大小</param>
        public SmallView()
        {
            InitializeComponent();
            Size = MainConfig.PanelMainSize;
            panelMain.AutoScroll = true;
            ShowSmallImages();            
        }

        /// <summary>
        /// 加载指定文件夹下的所有图片
        /// </summary>
        /// <param name="folderPath">文件路径</param>
        /// <param name="panelSize">SmallView窗体大小</param>
        /// <param name="imageSize">需要显示的图片大小</param>
        private void ShowSmallImages()
        {

            string[] pictures = ImageTool.GetAllImage(MainConfig.ShowFolderPath);
            //foreach (string pic in pictures)
            //{
            //    MessageBox.Show(pic);
            //}

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
                    pictureBox.Image = Image.FromFile(pictures[index]);
                    pictureBox.Tag = pictures[index];
                    //FileStream fs = new FileStream(pictures[index], FileMode.Open);
                    //Bitmap bm = new Bitmap(fs);
                    //fs.Dispose();
                    //pictureBox.Image = bm;

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

        // 双击显示大图
        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            string filePath = pictureBox.Tag.ToString();
            List<string> allPic= ImageTool.GetAllImage(MainConfig.ShowFolderPath).ToList();

            //foreach(string path in allPic)
            //    MessageBox.Show(path.ToString());

            //Image image = pictureBox.Image;
            ShowImage showForm = new ShowImage();
            //newForm.showImage=image;
            //showForm.SetPictureBoxByImage(image);
            showForm.SetFileParent(filePath, allPic);
            showForm.Show();
        }
     
    }
}
