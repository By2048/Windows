using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormTest
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
            InitPanel();

            DoubleClick += PicBox_DoubleClick;
        }

        private void Control_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("User control clicked");
            OnDoubleClick(e);
        }

        private void InitPanel()
        {
            int panelInfoHeight = 20;

            panelImage.Size = new Size(Size.Width, Size.Height - panelInfoHeight);
            panelImage.Location = new Point(0, 0);

            panelInfo.Size = new Size(Size.Width, panelInfoHeight);
            panelInfo.Location = new Point(0, Size.Height - panelInfoHeight);

            pictureBox.Size = panelImage.Size;
            pictureBox.Location = new Point(0, 0);

            label.Size = panelInfo.Size;
            label.Location = new Point(0, 0);
            label.Text = "001.jpg";
            label.TextAlign = ContentAlignment.MiddleCenter;

            panelInfo.BackColor = Color.Green;
            panelImage.BackColor = Color.Red;


            pictureBox.DoubleClick += pictureBox_DoubleClick;
            label.DoubleClick += label_DoubleClick;

        }

        private void label_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }

        public void PicBox_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("PicBox_DoubleClick");
        }     
    }
}
