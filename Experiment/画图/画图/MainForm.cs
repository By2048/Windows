using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace 画图
{
    public partial class MainForm : Form
    {
        Bitmap forPic, backPic;
        Pen pen, rubber; //橡皮
        private string fileName, drawType;
        Boolean isDrawing = false;
        Point startPoint, endPoint, mousePoint;
        Graphics g;
        int x, y;

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            pictureBoxDraw.SizeMode = PictureBoxSizeMode.AutoSize;
            pen = new Pen(Color.Black, 1);
            rubber = new Pen(Color.White, 5);
            drawType = "Line";
            toolStripButtonCurColor.BackColor = Color.Black;
            toolStripComboBoxColor.Items.Clear();
            Array allColor = Enum.GetValues(typeof(KnownColor));
            foreach (KnownColor c in allColor)
            {
                ToolStripDropDown ts = new ToolStripDropDown();
                toolStripComboBoxColor.Items.Add(c.ToString());
            }
            toolStripComboBoxColor.SelectedIndex = toolStripComboBoxColor.FindString(Color.Black.Name);

            for (int i = 1; i <= 10; i = i += 1)
            {
                this.toolStripComboBoxLineThick.Items.Add(i.ToString());
            }
            toolStripComboBoxLineThick.SelectedIndex = 0;

            this.toolStripComboBoxLineStyle.Items.Clear();
            Array allDashStyle = Enum.GetValues(typeof(DashStyle));
            foreach (DashStyle ds in allDashStyle)
            {
                toolStripComboBoxLineStyle.Items.Add(ds.ToString());
            }
            toolStripComboBoxLineStyle.SelectedIndex = 0;
        }
        private void toolStripButtons_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = sender as ToolStripButton;
            drawType = btn.Text;
            ChangeToolStripButtonChecked();
        }
        private void pictureBoxDraw_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.pictureBoxDraw.Image == null)
            {
                forPic = new Bitmap(this.pictureBoxDraw.Width, this.pictureBoxDraw.Height);
                this.pictureBoxDraw.Image = forPic;
                backPic = forPic;
            }
            isDrawing = true;
            startPoint = new Point(e.X, e.Y);
        }
        private void pictureBoxDraw_MouseMove(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
            ChangeToolStripStatusLabel();

            if (isDrawing)
            {
                ChangeToolStripStatusLabel();

                endPoint = new Point(e.X, e.Y);
                forPic = new Bitmap(this.pictureBoxDraw.Width, this.pictureBoxDraw.Height);
                g = Graphics.FromImage(forPic);
                switch (drawType)
                {
                    case "Line":
                        g.DrawLine(pen, startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);
                        break;
                    case "Ellipse":
                        TrimSize();
                        g.DrawEllipse(pen, x, y, Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y));
                        break;
                    case "Rectangle":
                        TrimSize();
                        g.DrawRectangle(pen, new Rectangle(x, y, Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y)));

                        break;
                    case "PenLine":
                        g = Graphics.FromImage(backPic);
                        g.DrawLine(pen, startPoint, e.Location);
                        startPoint = e.Location;
                        break;
                    case "FillRectangle":
                        float rectangleWidth = Math.Abs(e.X - startPoint.X);
                        float rectangleHeigth = Math.Abs(e.Y - startPoint.Y);
                        PointF rectStartPointF = startPoint;
                        if (e.X < startPoint.X)
                        {
                            rectStartPointF.X = e.X;
                        }
                        if (e.Y < startPoint.Y)
                        {
                            rectStartPointF.Y = e.Y;
                        }
                        g.FillRectangle(new SolidBrush(pen.Color), rectStartPointF.X, rectStartPointF.Y, rectangleWidth, rectangleHeigth);
                        break;
                    case "FillEllipse":
                        float ellipseWidth = Math.Abs(e.X - startPoint.X);
                        float ellipseHeigth = Math.Abs(e.Y - startPoint.Y);
                        PointF ellipseStartPointF = startPoint;
                        if (e.X < startPoint.X)
                        {
                            ellipseStartPointF.X = e.X;
                        }
                        if (e.Y < startPoint.Y)
                        {
                            ellipseStartPointF.Y = e.Y;
                        }
                        g.FillEllipse(new SolidBrush(pen.Color), ellipseStartPointF.X, ellipseStartPointF.Y, ellipseWidth, ellipseHeigth);
                        break;
                    default:
                        g = Graphics.FromImage(backPic);
                        g.DrawLine(rubber, startPoint, e.Location);
                        startPoint = e.Location;
                        break;
                }


                this.pictureBoxDraw.Image = forPic;
                this.pictureBoxDraw.BackgroundImage = backPic;
                g.Dispose();
            }
        }
        private void pictureBoxDraw_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                isDrawing = false;
                g = Graphics.FromImage(backPic);
                g.DrawImage(forPic, 0, 0);
                g.Dispose();
            }
        }
        private void toolStripComboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBoxColor.SelectedIndex == -1)
            {
                return;
            }
            pen.Color = Color.FromName(this.toolStripComboBoxColor.SelectedItem.ToString());
            this.toolStripButtonCurColor.BackColor = pen.Color;
        }
        private void toolStripComboBoxLineStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.toolStripComboBoxLineStyle.SelectedIndex == -1)
            {
                return;
            }
            switch (this.toolStripComboBoxLineStyle.SelectedItem.ToString())
            {
                case "Dash":
                    pen.DashStyle = DashStyle.Dash;
                    break;
                case "DashDot":
                    pen.DashStyle = DashStyle.DashDot;
                    break;
                case "DashDotDot":
                    pen.DashStyle = DashStyle.DashDotDot;
                    break;
                case "Dot":
                    pen.DashStyle = DashStyle.Dot;
                    break;
                case "Solid":
                    pen.DashStyle = DashStyle.Solid;
                    break;
                case "Custom":
                    pen.DashStyle = DashStyle.Custom;
                    break;
                default:
                    break;
            }
        }
        private void toolStripComboBoxLineThick_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBoxLineThick.SelectedIndex == -1)
            {
                return;
            }
            pen.Width = float.Parse(toolStripComboBoxLineThick.SelectedItem.ToString());
        }
        private void toolStripButtonMoreColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            pen.Color = colorDialog1.Color;
            toolStripComboBoxColor.SelectedIndex = toolStripComboBoxColor.FindString(colorDialog1.Color.Name);

        }
        private void 新建ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBoxDraw.Width, pictureBoxDraw.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, bmp.Width, bmp.Height);
            g.Dispose();

            g = this.pictureBoxDraw.CreateGraphics();
            g.DrawImage(bmp, 0, 0);
            g.Dispose();
            pictureBoxDraw.Image = bmp;

            forPic = bmp;
            backPic = bmp;

        }
        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void 打开ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPG|*.jpg|Bmp|*.bmp|所有文件|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(dialog.FileName);
                pictureBoxDraw.Image = bmp;
                Width = bmp.Width;
                Height = bmp.Height;

                backPic = forPic = bmp;
                fileName = dialog.FileName;
                Text = fileName;
                dialog.Dispose();
            }
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName != null)
            {
                if (MessageBox.Show("是否要覆盖文件？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Bitmap bmp = new Bitmap(pictureBoxDraw.Width, pictureBoxDraw.Height);
                    Graphics g = Graphics.FromImage(bmp);
                    g.DrawImage(forPic, 0, 0);
                    g.DrawImage(backPic, 0, 0);
                    bmp.Save(fileName);
                }
            }
            else
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "JPG(*.jpg)|*.jpg|BMP(*.bmp)|*.bmp";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bmp = new Bitmap(pictureBoxDraw.Width, pictureBoxDraw.Height);
                    Graphics g = Graphics.FromImage(bmp);
                    g.DrawImage(forPic, 0, 0);
                    g.DrawImage(backPic, 0, 0);
                    fileName = dialog.FileName;
                }
            }
        }
        private void 另存为ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPG(*.jpg)|*.jpg|BMP(*.bmp)|*.bmp";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(pictureBoxDraw.Width, pictureBoxDraw.Height);
                Graphics g = Graphics.FromImage(bmp);
                g.DrawImage(forPic, 0, 0);
                g.DrawImage(backPic, 0, 0);
                fileName = sfd.FileName;
            }
        }
        private void ChangeToolStripButtonChecked()
        {
            //Clear PenLine Ellipse FillEllipse Rectangle FillRectangle Line
            toolStripButtonClear.Checked = toolStripButtonClear.Text == drawType ? true : false;
            toolStripButtonPenLine.Checked = toolStripButtonPenLine.Text == drawType ? true : false;
            toolStripButtonEllipse.Checked = toolStripButtonEllipse.Text == drawType ? true : false;
            toolStripButtonFillEllipse.Checked = toolStripButtonFillEllipse.Text == drawType ? true : false;
            toolStripButtonRectangle.Checked = toolStripButtonRectangle.Text == drawType ? true : false;
            toolStripButtonFillRectangle.Checked = toolStripButtonFillRectangle.Text == drawType ? true : false;
            toolStripButtonLine.Checked = toolStripButtonLine.Text == drawType ? true : false;
        }
        private void ChangeToolStripStatusLabel()
        {
            this.toolStripStatusLabelDrawType.Text = drawType;
            this.toolStripStatusLabelMousePoint.Text = mousePoint.ToString();
        }
        private void TrimSize()
        {
            x = (startPoint.X < endPoint.X) ? startPoint.X : endPoint.X;
            y = (startPoint.Y < endPoint.Y) ? startPoint.Y : endPoint.Y;
        }



    }
}
