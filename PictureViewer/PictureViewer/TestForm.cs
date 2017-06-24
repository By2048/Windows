using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;


namespace PictureViewer
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            panelMain.AutoScroll = true;
        }
        private void TestForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowSmallImages();            
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

                    //pictureBox.Image = ImageTool.LoadImage(pictures[index]);
                    pictureBox.Image = ImageTool.GetThumbnailsImg(pictures[index], imageSize);
                    pictureBox.Tag = pictures[index];

                    Point pictureLoction = new Point()
                    {
                        X = pictureBox.Width * column + padding * (column + 1),
                        Y = pictureBox.Height * row + padding * (row + 1)
                    };

                    //MessageBox.Show(pictureBox.Tag.ToString());
                    pictureBox.Location = pictureLoction;

                    //Thread t = new Thread(new ParameterizedThreadStart(AddControol));
                    //t.Start();

                    panelMain.Controls.Add(pictureBox);
                    Refresh();
                }
            }
        }      

        private void AddControol(object obj)
        {
            PictureBox picBox = (PictureBox)obj;
            panelMain.Controls.Add(picBox);
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CollectionTool.CreateJsonFile();
        }
    }
}
