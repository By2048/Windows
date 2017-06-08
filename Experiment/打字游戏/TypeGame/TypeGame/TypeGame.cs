using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TypeGame
{
    public partial class TypeGame : Form
    {
        Random ran = new Random();
        int cleanNum = 0;
        int errorNum = 0;
        int maxNum = 5;
        int showNum = 0;

        class MyLabel : Label
        {
            int speed;
            TypeGame container;
            Thread a;
            public MyLabel(char ch, int left, int speed, TypeGame container)
            {
                this.speed = speed;
                this.Text = ch.ToString();
                this.container = container;
                this.Width = 50;
                this.Top = 10;
                this.Left = left;
                a = new Thread(new ThreadStart(Run));
                a.Start();
            }

            public void Run()
            {
                while (Top + Height < container.Height)
                {
                    Top++;
                    Thread.Sleep(speed * 1);
                }

                if (Top + Height >= container.Height)
                {
                    container.Error(Text);
                    Thread.CurrentThread.Abort();
                }

            }
            public void StopRuning()
            {
                if (a != null && a.IsAlive)
                    a.Abort();
            }
            ~MyLabel()
            {
                if (a != null && a.IsAlive)
                    a.Abort();
                this.Dispose();
            }
        }
        public TypeGame()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        private void TypeGame_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            timer.Start();
            ShowLab();
        }
private void timer1_Tick(object sender, EventArgs e)
{
    if (showNum <= maxNum)
    {
        int speed = ran.Next(100) + 1;
        int n = ran.Next(52);
        char ch;
        int w = ran.Next(this.Width) - 25;
        if (n < 26)
            ch = (char)('a' + n);
        else
            ch = (char)('A' + n - 26);
        MyLabel lab = new MyLabel(ch, w, speed, this);
        showNum++;
        Controls.Add(lab);
    }

}
        public void Error(string Text)
        {
            errorNum++;
            showNum--;
            foreach (Control control in Controls)
            {
                if (control is MyLabel && control.Text == Text)
                {
                    Controls.Remove(control);
                    ((MyLabel)control).StopRuning();
                }
            }
            ShowLab();
        }
        private void ShowLab()
        {
            label.Text = "Error " + errorNum.ToString() + " Clean " + cleanNum.ToString();
        }
private void TypeGame_KeyPress(object sender, KeyPressEventArgs e)
{
    foreach (Control c in this.Controls)
    {
        if (c is MyLabel && c.Text == e.KeyChar.ToString())
        {
            Controls.Remove(c);
            cleanNum++;
            showNum--;
            ShowLab();
            ((MyLabel)c).StopRuning();
            break;
        }
    }
}

    }
}




