using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormTest
{
    public partial class ShowImage : Form
    {
        bool isMaxScreen = false;
        bool isCtrlDown = false;

        public Image showImage;
        private ContextMenuStrip picBoxContextMenuStrip;

        public ShowImage()
        {
            InitializeComponent();         

            imagePictureBox.MouseDown += new MouseEventHandler(picture_MouseDown);
            imagePictureBox.MouseMove += new MouseEventHandler(picture_MouseMove);
            imagePictureBox.MouseDoubleClick += new MouseEventHandler(picture_DoubleClick);
            imagePictureBox.MouseWheel += new MouseEventHandler(picture_MouseWheel);

            KeyDown += new KeyEventHandler(ShowImage_KeyDown);
            KeyPress += new KeyPressEventHandler(ShowImage_KeyPress);
            KeyUp += new KeyEventHandler(ShowImage_KeyUp);
            CreateContextMenuStrip();
        }

        private void ShowImage_Load(object sender, EventArgs e)
        {            
            KeyPreview = true; //允许键盘
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;

            //SetImage("..\\..\\Images\\default.jpg");

            Size = showImage.Size;
            // 窗口中除去标题栏和边框的地方
            imagePictureBox.ClientSize = Size;

            imagePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            imagePictureBox.Image = showImage;

            StartPosition = FormStartPosition.Manual;
            Location = GetStartPoston(showImage.Size);

            Controls.Add(imagePictureBox);
        }


        public void SetImage(string path)
        {
            showImage = Image.FromFile(path);
        }
        public void SetImage(Image image)
        {
            showImage = image;
        }
        private void CreateContextMenuStrip()
        {
            ToolStripMenuItem ImageShowModel;
            ToolStripMenuItem StretchImageModel;
            ToolStripMenuItem AutoSizeModel;
            ToolStripMenuItem ImageInfo;

            picBoxContextMenuStrip = new ContextMenuStrip();
            picBoxContextMenuStrip.Name = "picBoxContextMenuStrip";

            ImageShowModel = new ToolStripMenuItem();
            ImageShowModel.Name = "ImageShowModel";
            ImageShowModel.Text = "显示模式";
            ImageShowModel.DropDownOpening += new EventHandler(ImageShowModel_DropDownOpening);
            ImageShowModel.DropDownItemClicked += new ToolStripItemClickedEventHandler(ImageShowModelItem_Clicked);

            StretchImageModel = new ToolStripMenuItem();
            StretchImageModel.Name = "StretchImageModel";
            StretchImageModel.Text = "图片适应";           

            AutoSizeModel = new ToolStripMenuItem();
            AutoSizeModel.Name = "AutoSizeModel";
            AutoSizeModel.Text = "实际像素";

            ImageInfo = new ToolStripMenuItem();
            ImageInfo.Name = "ImageInfo";
            ImageInfo.Text = "图片信息";

            picBoxContextMenuStrip.Items.AddRange(
                new ToolStripItem[] {
                ImageShowModel,
                ImageInfo
            });                     

            ImageShowModel.DropDownItems.AddRange(
                new ToolStripItem[] {
                StretchImageModel,
                AutoSizeModel,
            });          
        }
        // 窗口在屏幕中居中 优先在第二屏幕居中
        private Point GetStartPoston(Size imgeSize)
        {
            Point startPoint=new Point(0,0);
            if (Screen.AllScreens.Count() > 1)  // 是双屏
            {
                int firstScreenWidth = Screen.AllScreens[0].Bounds.Width;
                int secondScreenWidth = Screen.AllScreens[1].Bounds.Width;
                int secondScreenHeight= Screen.AllScreens[1].Bounds.Height;
                startPoint = new Point()
                {
                    X = firstScreenWidth+(secondScreenWidth - imgeSize.Width) / 2,
                    Y= (secondScreenHeight-imgeSize.Height)/2
                };
            }
            else
            {
                int firstScreenWidth = Screen.AllScreens[0].Bounds.Width;
                int firstScreenHeight = Screen.AllScreens[0].Bounds.Height;
                startPoint = new Point()
                {
                    X = (firstScreenWidth  - imgeSize.Width) / 2,
                    Y = (firstScreenHeight - imgeSize.Height) / 2
                };
            }
            return startPoint;
        }

        private void ShowImage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true)
                isCtrlDown = true;
        }
        private void ShowImage_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar.ToString() == Keys.Control.ToString())

        }
        private void ShowImage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control == false)
                isCtrlDown = false;
        }


        private Point currentPoint, offsetPoint;

        private void picture_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentPoint = PointToScreen(e.Location);
                offsetPoint = new Point(currentPoint.X - Left, currentPoint.Y - Top);
            }
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip = picBoxContextMenuStrip;
            }
        }

        Point diffPoint = new Point(0, 0);
        Point movePoint = new Point(0, 0);
        private void picture_MouseMove(object sender, MouseEventArgs e)
        {

            this.imagePictureBox.Focus();
            if (e.Button == MouseButtons.Left && isMaxScreen == false && isMaxScreen == false)
            {
                Point currentPoint = MousePosition;
                Location = new Point(currentPoint.X - offsetPoint.X, currentPoint.Y - offsetPoint.Y);
            }
            else if (e.Button == MouseButtons.Left && isMaxScreen == true)
            {
                //diffPoint.X = currentPoint.X - e.X;
                //diffPoint.Y = currentPoint.Y - e.Y;

                //movePoint.X = movePoint.X - diffPoint.X;
                //movePoint.Y = movePoint.Y - diffPoint.Y;

                //imageBitmap = new Bitmap("..\\..\\Images\\default.jpg");
                //Graphics gra = imagePictureBox.CreateGraphics();
                //gra.Clear(imagePictureBox.BackColor);
                //gra.DrawImage(imageBitmap, movePoint.X, movePoint.Y);
                //currentPoint.X = e.X;
                //currentPoint.Y = e.Y;
                //imageBitmap.Dispose();
                //gra.Dispose();
            }
        }
        private void picture_DoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Close();
        }
        private void picture_MouseWheel(object sender, MouseEventArgs e)
        {
            double imageProportion = double.Parse(showImage.Width.ToString()) / double.Parse(showImage.Height.ToString());

            //当前的屏幕除任务栏外的工作域大小
            int ScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            int ScreenHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;

            if (e.Delta == 120 && isCtrlDown == true)
            {
                Opacity += 0.1;
                return;
            }
            if (e.Delta == -120 && isCtrlDown == true)
            {
                Opacity -= 0.1;
                return;
            }
            if (e.Delta == 120 && isCtrlDown == false)
            {
                int curPicWidth = imagePictureBox.Width;
                int curPicHeight = imagePictureBox.Height;


                imagePictureBox.Width = int.Parse(Math.Round((curPicWidth + 20.0 * imageProportion)).ToString());
                imagePictureBox.Height = int.Parse(Math.Round((curPicHeight + 20.0)).ToString());
                Width = imagePictureBox.Width;
                Height = imagePictureBox.Height;


                if (Width >= ScreenWidth || Height >= ScreenHeight)
                    isMaxScreen = true;
                return;
            }
            if (e.Delta == -120 && isCtrlDown == false)
            {
                int curPicWidth = imagePictureBox.Width;
                int curPicHeight = imagePictureBox.Height;

                imagePictureBox.Width = int.Parse(Math.Round((curPicWidth - 28 * imageProportion)).ToString());
                imagePictureBox.Height = int.Parse(Math.Round((curPicHeight - 28.0)).ToString());

                Width = imagePictureBox.Width;
                Height = imagePictureBox.Height;
                if (Width < ScreenWidth && Height < ScreenHeight)
                    isMaxScreen = false;
                return;
            }

        }

        private void ImageShowModel_DropDownOpening(object sender, EventArgs e)
        {
            string mode = this.imagePictureBox.SizeMode.ToString();
            switch (mode)
            {
                case "StretchImage": mode = "图片适应"; break;
                case "AutoSize": mode = "实际像素"; break;
                default: break;
            }
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            foreach (ToolStripMenuItem child in item.DropDownItems)
            {
                child.Checked = child.Text == mode;
            }
        }

        private void ImageShowModelItem_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem item = e.ClickedItem as ToolStripMenuItem;
            switch (item.Text)
            {
                case "图片适应": imagePictureBox.SizeMode = PictureBoxSizeMode.StretchImage; break;
                case "实际像素": imagePictureBox.SizeMode = PictureBoxSizeMode.AutoSize; break;
                default: break;
            }
        }

    }
}
