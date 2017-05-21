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
    public partial class SingleView : UserControl
    {
        public SingleView()
        {
            InitializeComponent();
            Size = MainConfig.PanelMainSize;

            pictureBox.Image = Image.FromFile(MainConfig.ShowImagePath);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.DoubleClick += pictureBox_DoubleClick;

        }
        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Image image = pictureBox.Image;
            ShowImage newForm = new ShowImage();
            newForm.SetPictureBoxByImage(image);
            newForm.Show();
        }
    }
}
