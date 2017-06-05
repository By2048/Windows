using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureViewer
{
    // 显示一张图片 根据 MainConfig.ShowImagePath
    public partial class SingleView : UserControl
    {
        public SingleView()
        {
            InitializeComponent();
            Size = MainConfig.PanelMainSize;

            pictureBox.Image = ImageTool.LoadImage(MainConfig.ShowImagePath);
            pictureBox.Tag = MainConfig.ShowImagePath;

            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.DoubleClick += pictureBox_DoubleClick;

        }
        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            string filePath = pictureBox.Tag.ToString();
            ShowImage newForm = new ShowImage();
            newForm.picPath = filePath;
            newForm.Show();
        }
    }
}
