using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections.Specialized;

namespace PictureViewer
{
    public partial class MainForm : Form
    {
        string folderPath = @"F:\Test\媚眼柔嫩娇滴滴 爆乳萌妹子猫儿蜜糖化身性感女仆被调教";
        Size imageSize = new Size(16 * 10, 9 * 10);

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            panelMain.Controls.Clear();
            ImgSmallView userControl = new ImgSmallView(folderPath, panelMain.Size, imageSize);
            panelMain.Controls.Add(userControl);

            //if (tsbSmallView.Checked)
            //    MessageBox.Show("true");
            //else
            //    MessageBox.Show("false");

            SetTsbChecked();
        }

        private void SetTsbChecked()
        {
            foreach (var item in toolStripMain.Items)
            {
                if (item is ToolStripButton)
                {
                    MessageBox.Show("fwe");
                }
            }
        }
        private void tsbSmallView_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            ImgSmallView userControl= new ImgSmallView(folderPath, panelMain.Size, imageSize);
            panelMain.Controls.Add(userControl);           
        }

        private void tsbLargeView_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            ImgLargeView userControl = new ImgLargeView(folderPath, panelMain.Size);
            panelMain.Controls.Add(userControl);
        }

        private void tsbDetailView_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            ImgDetailView userControl = new ImgDetailView(folderPath, panelMain.Size,imageSize);
            panelMain.Controls.Add(userControl);
        }

        private void tsbListView_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            ImgListView userControl = new ImgListView(folderPath, panelMain.Size);
            panelMain.Controls.Add(userControl);
        }

        private void tsbSize1_Click(object sender, EventArgs e)
        {
            imageSize = new Size(16 * 10, 9 * 10);
        }

        private void tsbSize2_Click(object sender, EventArgs e)
        {
            imageSize = new Size(16 * 15, 9 * 15);
        }

        private void tsbSize3_Click(object sender, EventArgs e)
        {
            imageSize = new Size(16 * 20, 9 * 20);
        }

    }
}
