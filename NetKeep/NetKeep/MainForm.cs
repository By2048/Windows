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
using WinAPI;

namespace NetKeep
{
    public partial class MainForm : Form
    {


        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            textBox.Text += " - ";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            KeepLink();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }


        private void KeepLink()
        {
            Internet internet = new Internet();
            bool isLink = internet.IsLink();

            if (isLink == false)
            {
                Cmd cmd = new Cmd();
                //string strReturn1 = cmd.Run("taskkill / t / f / im shanxun.exe");
                //string strReturn2 = cmd.Run("taskkill / t / f / im singleNet.exe");

                //Thread.Sleep(1000);
                string strReturn3 = cmd.Run("start D:\\singleNetDir\\bin\\loader.exe");

                Thread.Sleep(3000);


                Point point1 = new Point(1066, 455);
                Point point2 = new Point(995, 675);

                Mouse mouse = new Mouse();

                mouse.MoveTo(point1);
                mouse.Click(WinAPI.Button.Left);
                Thread.Sleep(500);
                mouse.Click(WinAPI.Button.Left);

                Thread.Sleep(3000);

                mouse.MoveTo(point2);
                mouse.Click(WinAPI.Button.Left);
                Thread.Sleep(2000);
                mouse.Click(WinAPI.Button.Left);

            }
            else
            {
                return;
            }
        }


    }
}
