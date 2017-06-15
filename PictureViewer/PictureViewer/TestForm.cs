using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureViewer
{
    public partial class TestForm : Form
    {
        private ManualResetEvent manualReset = new ManualResetEvent(true);
        public TestForm()
        {
            InitializeComponent();
            panelMain.AutoScroll = true;
        }
        private void TestForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowSmallImages();
            //backgroundWorker.CancelAsync();
        }


        
        private void ShowSmallImages()
        {
            Size imageSize = new Size(16 * 10, 9 * 10);
            string[] pictures = ImageTool.GetAllImagePath(@"F:\\Test\\Bing");

            int pictureCount = pictures.Length;

            int padding = 2;
            int columnCount = panelMain.Width / imageSize.Width;
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

                    //MessageBox.Show(pictureBox.Tag.ToString());
                    pictureBox.Location = pictureLoction;                    
                    panelMain.Controls.Add(pictureBox);                    
                    Refresh();
                }
            }
        }

       

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ShowSmallImages();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CollectionTool.CreateJsonFile();
        }
    }
}
