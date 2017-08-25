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
    public partial class PicBox : UserControl
    {
        /// <summary>
        /// 小图片显示
        /// </summary>
        /// <param name="imgPath">图片路径</param>
        /// <param name="showSize">显示的大小</param>
        public PicBox(string imgPath,Size showSize)
        {
            InitializeComponent();
            Size = showSize;
            InitPanel(imgPath);

            Tag = imgPath;
            DoubleClick += Control_DoubleClick;
        }

        private void Control_DoubleClick(object sender, EventArgs e)
        {
            PicBox picBox = (PicBox)sender;
            string imgPath = picBox.Tag.ToString();
            //MessageBox.Show(imgPath);
            ShowForm form = new ShowForm();
            form.imgPath = imgPath;
            form.Show();

        }
  

        private void InitPanel(string imgPath)
        {
            int panelInfoHeight = 20;

            panelImage.Size = new Size(Size.Width, Size.Height - panelInfoHeight);
            panelImage.Location = new Point(0, 0);

            panelInfo.Size = new Size(Size.Width, panelInfoHeight);
            panelInfo.Location = new Point(0, Size.Height - panelInfoHeight);

            pictureBox.Size = panelImage.Size;
            pictureBox.Location = new Point(0, 0);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            //pictureBox.Image = ImageTool.GetImage(imgPath);
            pictureBox.Image = ImageTool.GetThumbnailsImage(imgPath, MainConfig.ImageSize);
            pictureBox.DoubleClick += pictureBox_DoubleClick;

            label.Size = panelInfo.Size;
            label.Location = new Point(0, 0);
            label.Text = Path.GetFileName(imgPath);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.DoubleClick += label_DoubleClick;

            //panelInfo.BackColor = Color.Green;
            //panelImage.BackColor = Color.Red;
        }

        private void label_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }

        
    }
}
