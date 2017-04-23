﻿using System;
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
        public Bitmap imageBitmap;
        private ContextMenuStrip picBoxContextMenuStrip;


        private ToolStripMenuItem ImageShowModel;
        private ToolStripMenuItem ZoomMode;
        private ToolStripMenuItem StretchImageModel;
        private ToolStripMenuItem NormalModel;

        private ToolStripMenuItem ImageInfo;
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

            picBoxContextMenuStrip = new ContextMenuStrip();
            picBoxContextMenuStrip.Name = "picBoxContextMenuStrip";

            ImageShowModel = new ToolStripMenuItem();
            ZoomMode = new ToolStripMenuItem();
            StretchImageModel = new ToolStripMenuItem();
            NormalModel = new ToolStripMenuItem();

            ImageInfo = new ToolStripMenuItem();

            picBoxContextMenuStrip.Items.AddRange(
                new ToolStripItem[] {
                ImageShowModel,
                ImageInfo
            });
            ImageShowModel.Name = "ImageShowModel";
            ImageShowModel.Text = "显示模式";
            ImageShowModel.DropDownOpening += new EventHandler(ImageShowModel_DropDownOpening);
            ImageShowModel.DropDownItemClicked += new ToolStripItemClickedEventHandler(ImageShowModelItemClicked);
            ZoomMode.Name = "ZoomMode";
            ZoomMode.Text = "放大";
            StretchImageModel.Name = "StretchImageModel";
            StretchImageModel.Text = "拉伸";
            NormalModel.Name = "NormalModel";
            NormalModel.Text = "正常";

            ImageShowModel.DropDownItems.AddRange(
                new ToolStripItem[] {
                ZoomMode,
                StretchImageModel,
                NormalModel
            });
            ImageInfo.Name = "ImageInfo";
            ImageInfo.Text = "图片信息";

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

        public void SetImagePath(string path)
        {
            imageBitmap = new Bitmap(path);
        }
        private void ShowImage_Load(object sender, EventArgs e)
        {
            //允许键盘
            KeyPreview = true;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;

            SetImagePath("..\\..\\Images\\default.jpg");

            int picWidth = imageBitmap.Width;
            int picHeight = imageBitmap.Height;

            Width = picWidth / 4;
            Height = picHeight / 4;

            imagePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            imagePictureBox.ClientSize = new Size(Width, Height);
            imagePictureBox.Image = imageBitmap;

            Controls.Add(imagePictureBox);
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
                diffPoint.X = currentPoint.X - e.X;
                diffPoint.Y = currentPoint.Y - e.Y;

                movePoint.X = movePoint.X - diffPoint.X;
                movePoint.Y = movePoint.Y - diffPoint.Y;

                imageBitmap = new Bitmap("..\\..\\Images\\default.jpg");
                Graphics gra = imagePictureBox.CreateGraphics();
                gra.Clear(imagePictureBox.BackColor);
                gra.DrawImage(imageBitmap, movePoint.X, movePoint.Y);
                currentPoint.X = e.X;
                currentPoint.Y = e.Y;
                imageBitmap.Dispose();
                gra.Dispose();
            }
        }
        private void picture_DoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Close();
        }
        private void picture_MouseWheel(object sender, MouseEventArgs e)
        {
            double imageProportion = double.Parse(imageBitmap.Width.ToString()) / double.Parse(imageBitmap.Height.ToString());

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

                imagePictureBox.Width = int.Parse(Math.Round((curPicWidth + 28 * imageProportion)).ToString());
                imagePictureBox.Height = int.Parse(Math.Round((curPicHeight + 28.0)).ToString());
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
                case "Zoom": mode = "放大"; break;
                case "StretchImage": mode = "拉伸"; break;
                case "Normal": mode = "正常"; break;
                default: break;
            }
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            foreach (ToolStripMenuItem child in item.DropDownItems)
            {
                child.Checked = child.Text == mode;
            }

        }

        private void ImageShowModelItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem item = e.ClickedItem as ToolStripMenuItem;
            switch (item.Text)
            {
                case "放大": imagePictureBox.SizeMode = PictureBoxSizeMode.Zoom; break;
                case "拉伸": imagePictureBox.SizeMode = PictureBoxSizeMode.StretchImage; break;
                case "正常": imagePictureBox.SizeMode = PictureBoxSizeMode.Normal; break;
                default: break;
            }
        }

    }
}
