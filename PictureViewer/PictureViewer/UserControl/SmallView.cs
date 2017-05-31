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
        public SmallView()
        {
            InitializeComponent();
            Size = MainConfig.PanelMainSize;
            panelMain.AutoScroll = true;
            ShowSmallImages();
        }
        private void SmallView_Load(object sender, EventArgs e)
        {
            ParentForm.KeyDown += new KeyEventHandler(SmallView_KeyDown);
            ParentForm.KeyPress += new KeyPressEventHandler(SmallView_KeyPress);
            ParentForm.KeyUp += new KeyEventHandler(SmallView_KeyUp);
        }

        /// <summary>
        /// 加载指定文件夹下的所有图片
        /// </summary>
        /// <param name="folderPath">文件路径</param>
        /// <param name="panelSize">SmallView窗体大小</param>
        /// <param name="imageSize">需要显示的图片大小</param>
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
            //List<string> allPic= ImageTool.GetAllImage(MainConfig.ShowFolderPath).ToList();

            //foreach(string path in allPic)
            //    MessageBox.Show(path.ToString());

            //Image image = pictureBox.Image;
            ShowImage showForm = new ShowImage();
            //newForm.showImage=image;
            //showForm.SetPictureBoxByImage(image);
            showForm.SetFileParent(filePath);
            showForm.Show();
        }

        //private ContextMenuStrip CreateContextMenuStrip(string filePath)
        //{
        //    ContextMenuStrip picContextMenuStrip;
        //    ToolStripMenuItem Del;
        //    ToolStripMenuItem Add;

        //    picContextMenuStrip = new ContextMenuStrip();
        //    picContextMenuStrip.Name = "picContextMenuStrip";

        //    Del = new ToolStripMenuItem();
        //    Del.Name = "Del";
        //    Del.Text = "删除";
        //    Del.Click += new EventHandler(Del_click);
        //    Del.Tag = filePath;

        //    Add = new ToolStripMenuItem();
        //    Add.Name = "Add";
        //    Add.Text = "添加收藏";
        //    Add.Click += new EventHandler(Add_click);
        //    Add.Tag = filePath;

        //    picContextMenuStrip.Items.AddRange(
        //        new ToolStripItem[] {
        //        Del,
        //        Add,
        //    });
        //    return picContextMenuStrip;
        //}
        //private void Del_click(object sender, EventArgs e)
        //{
        //    ToolStripMenuItem item = (ToolStripMenuItem)sender;
        //    string filePath = item.Tag.ToString();
        //    MessageBox.Show(filePath);
        //}
        //private void Add_click(object sender, EventArgs e)
        //{
        //    ToolStripMenuItem item = (ToolStripMenuItem)sender;
        //    string filePath = item.Tag.ToString();
        //    MessageBox.Show(filePath);
        //}

    }
}
