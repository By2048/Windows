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
        public ShowImage()
        {
            InitializeComponent();
            imagePictureBox.MouseDown += new MouseEventHandler(picture_MouseDown);
            imagePictureBox.MouseMove += new MouseEventHandler(picture_MouseMove);
            imagePictureBox.MouseDoubleClick += new MouseEventHandler(picture_DoubleClick);
            imagePictureBox.MouseWheel += new MouseEventHandler(picture_MouseWheel);

            KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShowImage_KeyDown);
            KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ShowImage_KeyPress);
            KeyUp += new System.Windows.Forms.KeyEventHandler(this.ShowImage_KeyUp);
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

        public Bitmap myBitMap = new Bitmap("..\\..\\Images\\default.jpg");
        public void SetBitMap(Image imageInfo)
        {
            myBitMap = new Bitmap(imageInfo.Path);
        }

        private void ShowImage_Load(object sender, EventArgs e)
        {
            //允许键盘
            KeyPreview = true;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;

            int picWidth = myBitMap.Width;
            int picHeight = myBitMap.Height;

            Width = picWidth / 4;
            Height = picHeight / 4;

            imagePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            imagePictureBox.ClientSize = new Size(Width, Height);
            imagePictureBox.Image = myBitMap;
            Controls.Add(imagePictureBox);
        }

        bool isCtrlDown = false;
        private Point offsetPoint;
        private ContextMenuStrip myContextMenuStrip;
        private void picture_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point currentPoint = PointToScreen(e.Location);
                offsetPoint = new Point(currentPoint.X - Left, currentPoint.Y - Top);

            }
            if (e.Button == MouseButtons.Right)
            {
                myContextMenuStrip = new ContextMenuStrip();
                Point showPoint = PointToScreen(e.Location);
                myContextMenuStrip.Opening += new CancelEventHandler(ShowContextMenuStrip);
                ContextMenuStrip = myContextMenuStrip;
            }
        }
        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
            this.imagePictureBox.Focus();
            if (e.Button == MouseButtons.Left)
            {
                Point currentPoint = MousePosition;
                Location = new Point(currentPoint.X - offsetPoint.X, currentPoint.Y - offsetPoint.Y);
            }
        }
        private void picture_DoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Close();
        }
        private void picture_MouseWheel(object sender, MouseEventArgs e)
        {
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
                Width = curPicWidth * 2;
                Height = curPicHeight * 2;
                imagePictureBox.Width = curPicWidth * 2;
                imagePictureBox.Height = curPicHeight * 2;
                return;
            }
            if (e.Delta == -120 && isCtrlDown == false)
            {
                int curPicWidth = imagePictureBox.Width;
                int curPicHeight = imagePictureBox.Height;
                Width = curPicWidth / 2;
                Height = curPicHeight / 2;
                imagePictureBox.Width = curPicWidth / 2;
                imagePictureBox.Height = curPicHeight / 2;
                return;
            }
            
        }
      
        private void ShowContextMenuStrip(object sender, System.ComponentModel.CancelEventArgs e)
        {
            myContextMenuStrip.Items.Add("");
            myContextMenuStrip.Items.Add("-");
            myContextMenuStrip.Items.Add("Apples");
            myContextMenuStrip.Items.Add("Oranges");
            myContextMenuStrip.Items.Add("Pears");
            e.Cancel = false;
        }

    }
}
