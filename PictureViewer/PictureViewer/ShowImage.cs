using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureViewer
{
    public partial class ShowImage : Form
    {
        bool isMaxScreen = false;

        bool isCtrlDown = false;

        bool allowArrowKey = false;

        public string curFilePath;  // 当前显示的文件

        public List<string> allFilePath=new List<string>();  // 所有的文件 

        // 加载 curFilePath 的 Image 到 pictureBoxu
        private void LoadImage()
        {
            Image image = Image.FromFile(curFilePath);
            pictureBox.Image = image;

            Size = image.Size;
            pictureBox.ClientSize = Size;  // 窗口中除去标题栏和边框的地方
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            StartPosition = FormStartPosition.Manual;
            Location = GetStartPoston(image.Size);
        }

        public void SetPictureBoxByImage(Image image)
        {
            pictureBox.Image = image;

            Size = image.Size;
            pictureBox.ClientSize = Size;  // 窗口中除去标题栏和边框的地方
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            StartPosition = FormStartPosition.Manual;
            Location = GetStartPoston(image.Size);
        }

        public void SetPictureBoxByPath(string filePath)
        {
            Image image = Image.FromFile(filePath);
            pictureBox.Image = image;
            pictureBox.Tag = filePath;

            Size = image.Size;
            pictureBox.ClientSize = Size;  // 窗口中除去标题栏和边框的地方
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            StartPosition = FormStartPosition.Manual;
            Location = GetStartPoston(image.Size);
        }

        public void SetFileParent(string _curFileParh, List<string> _allFilePath)
        {
            curFilePath = _curFileParh;
            allFilePath = _allFilePath;
        }
        public void SetFileParent(string _curFileParh)
        {
            curFilePath = _curFileParh;
            //allFilePath = null;
        }

        private ContextMenuStrip picBoxContextMenuStrip;

        public ShowImage()
        {
            InitializeComponent();

            pictureBox.MouseDown += new MouseEventHandler(picture_MouseDown);
            pictureBox.MouseMove += new MouseEventHandler(picture_MouseMove);
            pictureBox.MouseDoubleClick += new MouseEventHandler(picture_DoubleClick);
            pictureBox.MouseWheel += new MouseEventHandler(picture_MouseWheel);

            KeyDown += new KeyEventHandler(ShowImage_KeyDown);
            KeyPress += new KeyPressEventHandler(ShowImage_KeyPress);
            KeyUp += new KeyEventHandler(ShowImage_KeyUp);

            CreateContextMenuStrip();

            //LoadImage();
        }

        private void ShowImage_Load(object sender, EventArgs e)
        {
            KeyPreview = true; //允许键盘
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            LoadImage();

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
            Point startPoint = new Point(0, 0);
            if (Screen.AllScreens.Count() > 1)  // 是双屏
            {
                int firstScreenWidth = Screen.AllScreens[0].Bounds.Width;
                int secondScreenWidth = Screen.AllScreens[1].Bounds.Width;
                int secondScreenHeight = Screen.AllScreens[1].Bounds.Height;
                startPoint = new Point()
                {
                    X = firstScreenWidth + (secondScreenWidth - imgeSize.Width) / 2,
                    Y = (secondScreenHeight - imgeSize.Height) / 2
                };
            }
            else
            {
                int firstScreenWidth = Screen.AllScreens[0].Bounds.Width;
                int firstScreenHeight = Screen.AllScreens[0].Bounds.Height;
                startPoint = new Point()
                {
                    X = (firstScreenWidth - imgeSize.Width) / 2,
                    Y = (firstScreenHeight - imgeSize.Height) / 2
                };
            }
            return startPoint;
        }


        private void SwitchNext()
        {
            //int curFilePathIndex = allFilePath.FindIndex(tmp => tmp == curFilePath);
            int curIndex = allFilePath.IndexOf(curFilePath);
            int nextIndex;
            if (curIndex == allFilePath.Count - 1)
                nextIndex = 0;
            else
                nextIndex = curIndex + 1;

            curFilePath = allFilePath[nextIndex];

            LoadImage();
            //SetPictureBoxByPath(allFilePath[nextIndex]);
        }
        private void SwitchPrevious()
        {
            int curIndex = allFilePath.IndexOf(curFilePath);
            int preIndex;
            if (curIndex == 0)
                preIndex = allFilePath.Count() - 1;
            else
                preIndex = curIndex - 1;

            curFilePath = allFilePath[preIndex];

            LoadImage();

            //Image image = Image.FromFile(allFilePath[preIndex]);
            //SetPictureBoxByImage(image);
            //pictureBox.Image = image;
        }

        private void SwitchTop()
        {
            //Image image;
            int curIndex = allFilePath.IndexOf(curFilePath);
            if (curIndex == 0)
                return;
            else
                curFilePath = allFilePath[0];
            LoadImage();
            //image = Image.FromFile(allFilePath[0]);
            //SetPictureBoxByImage(image);

        }
        private void SwitchEnd()
        {
            //Image image;
            int endIndex = allFilePath.Count - 1;
            int curIndex = allFilePath.IndexOf(curFilePath);
            if (curIndex == allFilePath.Count - 1)
                return;
            else
               curFilePath = allFilePath[endIndex];
            LoadImage();
            //image = Image.FromFile(allFilePath[endIndex]);
            //SetPictureBoxByImage(image);
        }



        private void ShowImage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true)
                isCtrlDown = true;
            if (curFilePath != null && allFilePath.Count != 0)
                allowArrowKey = true;
        }
        private void ShowImage_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar.ToString() == Keys.Control.ToString())
        }
        private void ShowImage_KeyUp(object sender, KeyEventArgs e)
        {        
            if (allowArrowKey == true && isCtrlDown==false)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        SwitchPrevious();
                        break;
                    case Keys.Down:
                        SwitchNext();
                        break;
                    case Keys.Left:
                        SwitchPrevious();
                        break;
                    case Keys.Right:
                        SwitchNext();
                        break;
                }
            }
            if (allowArrowKey == true && isCtrlDown == true)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        SwitchTop();
                        break;
                    case Keys.Down:
                        SwitchEnd();
                        break;
                    case Keys.Left:
                        SwitchTop();
                        break;
                    case Keys.Right:
                        SwitchEnd();
                        break;
                }
            }
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

            this.pictureBox.Focus();
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
            Image image = pictureBox.Image;
            double imageProportion = double.Parse(image.Width.ToString()) / double.Parse(image.Height.ToString());

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
                int curPicWidth = pictureBox.Width;
                int curPicHeight = pictureBox.Height;


                pictureBox.Width = int.Parse(Math.Round(curPicWidth + 20.0 * imageProportion).ToString());
                pictureBox.Height = int.Parse(Math.Round(curPicHeight + 20.0).ToString());
                Width = pictureBox.Width;
                Height = pictureBox.Height;

                //MessageBox.Show(Location.ToString());

                Point nextLocation = Location;
                int X = Location.X - (int)(Math.Round(20.0 * imageProportion / 2));
                int Y = Location.Y - (int)(Math.Round(20.0 / 2));
                if (X <= 0 || Y <= 0)
                    return;
                else
                    nextLocation = new Point(X, Y);
                Location = nextLocation;


                if (Width >= ScreenWidth || Height >= ScreenHeight)
                    isMaxScreen = true;
                return;
            }
            if (e.Delta == -120 && isCtrlDown == false)
            {
                int curPicWidth = pictureBox.Width;
                int curPicHeight = pictureBox.Height;

                pictureBox.Width = int.Parse(Math.Round((curPicWidth - 28 * imageProportion)).ToString());
                pictureBox.Height = int.Parse(Math.Round((curPicHeight - 28.0)).ToString());

                Width = pictureBox.Width;
                Height = pictureBox.Height;

                int X = Location.X + (int)(Math.Round(20.0 * imageProportion / 2));
                int Y = Location.Y + (int)(Math.Round(20.0 / 2));
                Location = new Point(X, Y);

                if (Width < ScreenWidth && Height < ScreenHeight)
                    isMaxScreen = false;
                return;
            }

        }

        private void ImageShowModel_DropDownOpening(object sender, EventArgs e)
        {
            string mode = this.pictureBox.SizeMode.ToString();
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
                case "图片适应": pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; break;
                case "实际像素": pictureBox.SizeMode = PictureBoxSizeMode.AutoSize; break;
                default: break;
            }
        }

    }
}
