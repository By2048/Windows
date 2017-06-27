using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinAPI;

namespace NetKeep
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }


        private void TestForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point point = new Point(2950, 640);

            Mouse mouse = new Mouse();
            mouse.MoveTo(point);
            //Point curPoint = mouse.Location();
            //MessageBox.Show(curPoint.ToString());
            mouse.Click(WinAPI.Button.Left);

        }        

        private void button2_Click(object sender, EventArgs e)
        {
            Internet internet = new Internet();
            bool isLink=internet.IsLink();
            MessageBox.Show(isLink.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cmd cmd = new Cmd();

            string strReturn1 = cmd.Run("taskkill / t / f / im shanxun.exe");
            string strReturn2 = cmd.Run("taskkill / t / f / im singleNet.exe");

            Thread.Sleep(3000);

            string strReturn3 = cmd.Run("start D:\\singleNetDir\\bin\\loader.exe");

        }
    }
}




