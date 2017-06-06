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

namespace PictureViewer
{
    public partial class ShowForm : Form
    {
        bool isMaxScreen = false;
        bool isCtrlDown = false;
        bool allowArrowKey = false;

        public string picPath = "";  // 窗体所显示的文件路径  
        List<string> parentFilePath = new List<string>();  // 当前显示路径下的同辈文件

        private ContextMenuStrip picBoxContextMenuStrip;

        public ShowForm()
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
        }

        private void ShowImage_Load(object sender, EventArgs e)
        {
            KeyPreview = true; //允许键盘
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            LoadImage();
        }

        // 加载 curFilePath 的 Image 到 pictureBoxu
        private void LoadImage()
        {
          

            Image image = Image.FromFile(picPath);
            pictureBox.Image = ImageTool.LoadImage(picPath);
            //pictureBox.Image = image;


            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            StartPosition = FormStartPosition.Manual;

            Size = GetImageSize(image);
            pictureBox.Size = Size;
            //Location = GetStartPoston(image.Size);
            Location = GetStartPoston(pictureBox.Size);


            image.Dispose();

            GetParentFile();
        }

        private Size GetImageSize(Image image)
        {
            //当前的屏幕除任务栏外的工作域大小
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            Size imageSize = image.Size;

            if (image.Width > screenWidth || image.Height > screenHeight) // 图片原始分辨率比屏幕大
            {
                double proportion = double.Parse(image.Width.ToString()) / double.Parse(image.Height.ToString());
                if (image.Width > screenWidth && image.Height > screenHeight)   // 过宽 且 过高
                {
                    imageSize = new Size()
                    {
                        Width = image.Width / 2,
                        Height = image.Height / 2
                    };
                }
                if (image.Width > screenWidth && image.Height < screenHeight) // 过宽 不 过高
                {
                    imageSize = new Size()
                    {
                        Height = image.Height-50,
                        Width = int.Parse(Math.Round(image.Height * proportion).ToString())
                    };
                }
                if (image.Width < screenWidth && image.Height > screenHeight) // 不过宽 过高
                {
                    imageSize = new Size()
                    {
                        Width = image.Width-50,
                        Height = int.Parse(Math.Round(image.Width / proportion).ToString())
                    };
                }
            }           
            return imageSize;
        }

        public void GetParentFile()
        {
            parentFilePath = ImageTool.GetAllImagePath(Path.GetDirectoryName(picPath)).ToList();
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
        private Point GetStartPoston(Size picSize)
        {
            Point startPoint = new Point(0, 0);
            if (Screen.AllScreens.Count() > 1)  // 是双屏
            {
                int firstScreenWidth = Screen.AllScreens[0].Bounds.Width;
                int secondScreenWidth = Screen.AllScreens[1].Bounds.Width;
                int secondScreenHeight = Screen.AllScreens[1].Bounds.Height;
                startPoint = new Point()
                {
                    X = firstScreenWidth + (secondScreenWidth - picSize.Width) / 2,
                    Y = (secondScreenHeight - picSize.Height) / 2
                };
            }
            else
            {
                int firstScreenWidth = Screen.AllScreens[0].Bounds.Width;
                int firstScreenHeight = Screen.AllScreens[0].Bounds.Height;
                startPoint = new Point()
                {
                    X = (firstScreenWidth - picSize.Width) / 2,
                    Y = (firstScreenHeight - picSize.Height) / 2
                };
            }
            return startPoint;
        }


        private void SwitchNext()
        {
            //int picPathIndex = parentFilePath.FindIndex(tmp => tmp == picPath);
            int curIndex = parentFilePath.IndexOf(picPath);
            int nextIndex;
            if (curIndex == parentFilePath.Count - 1)
                nextIndex = 0;
            else
                nextIndex = curIndex + 1;

            picPath = parentFilePath[nextIndex];

            LoadImage();
            //SetPictureBoxByPath(parentFilePath[nextIndex]);
        }
        private void SwitchPrevious()
        {
            int curIndex = parentFilePath.IndexOf(picPath);
            int preIndex;
            if (curIndex == 0)
                preIndex = parentFilePath.Count() - 1;
            else
                preIndex = curIndex - 1;

            picPath = parentFilePath[preIndex];

            LoadImage();

            //Image image = Image.FromFile(parentFilePath[preIndex]);
            //SetPictureBoxByImage(image);
            //pictureBox.Image = image;
        }
        private void SwitchTop()
        {
            //Image image;
            int curIndex = parentFilePath.IndexOf(picPath);
            if (curIndex == 0)
                return;
            else
                picPath = parentFilePath[0];
            LoadImage();
            //image = Image.FromFile(parentFilePath[0]);
            //SetPictureBoxByImage(image);

        }
        private void SwitchEnd()
        {
            //Image image;
            int endIndex = parentFilePath.Count - 1;
            int curIndex = parentFilePath.IndexOf(picPath);
            if (curIndex == parentFilePath.Count - 1)
                return;
            else
                picPath = parentFilePath[endIndex];
            LoadImage();
            //image = Image.FromFile(parentFilePath[endIndex]);
            //SetPictureBoxByImage(image);
        }


        private void ShowImage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true)
                isCtrlDown = true;
            if (picPath != null && parentFilePath.Count != 0)
                allowArrowKey = true;
        }
        private void ShowImage_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar.ToString() == Keys.Control.ToString())
        }
        private void ShowImage_KeyUp(object sender, KeyEventArgs e)
        {
            if (allowArrowKey == true && isCtrlDown == false)
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
