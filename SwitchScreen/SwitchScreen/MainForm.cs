using SwitchScreen.Properties;
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

namespace SwitchScreen
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
                if (notifyIcon.Text == "close")
                {
                    notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("open")));
                    notifyIcon.Text = "open";
                }
                else
                {
                    notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("close")));
                    notifyIcon.Text = "close";
                }
                SwitchScreen();
            }
            if (e.Button == MouseButtons.Right)
            {
                notifyIcon.ContextMenuStrip = CreateContextMenuStrip();       
                notifyIcon.ContextMenuStrip.Show(Control.MousePosition);

                //System.Environment.Exit(0);
            }
        }


        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("DoubleClick");
        }


        #region 屏幕切换 模拟按键
        public void SwitchScreen()
        {
            if (Screen.AllScreens.Count() == 1)
            {
                VirtualKeyDown(VirtualKeyCode.Left_Windows_key);
                VirtualKeyClick(VirtualKeyCode.P_key);

                VirtualKeyUp(VirtualKeyCode.Left_Windows_key);

                Thread.Sleep(500);

                VirtualKeyClick(VirtualKeyCode.UP_ARROW_key);

                VirtualKeyClick(VirtualKeyCode.ENTER_key);
                VirtualKeyClick(VirtualKeyCode.ESC_key);
            }
            else
            {
                VirtualKeyDown(VirtualKeyCode.Left_Windows_key);
                VirtualKeyClick(VirtualKeyCode.P_key);

                VirtualKeyUp(VirtualKeyCode.Left_Windows_key);

                Thread.Sleep(500);

                VirtualKeyClick(VirtualKeyCode.DOWN_ARROW_key);

                VirtualKeyClick(VirtualKeyCode.ENTER_key);
                VirtualKeyClick(VirtualKeyCode.ESC_key);
            }


        }

        public const int KEYEVENTF_EXTENDEDKEY = 0x0001; //Key click flag
        public const int KEYEVENTF_KEYUP = 0x0002; //Key up flag
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bSCan, int dwFlags, int dwExtraInfo);
        [DllImport("user32.dll")]
        private static extern byte MapVirtualKey(byte wCode, int wMap);

        public static void VirtualKeyDown(VirtualKeyCode keyCode)
        {
            var code = (byte)keyCode;
            keybd_event(code, 0, 0, 0);
        }

        public static void VirtualKeyUp(VirtualKeyCode keyCode)
        {
            var code = (byte)keyCode;
            keybd_event(code, 0, KEYEVENTF_KEYUP, 0);
        }

        public static void VirtualKeyClick(VirtualKeyCode keyCode)
        {
            var code = (byte)keyCode;
            keybd_event(code, 0, KEYEVENTF_EXTENDEDKEY, 0);
        }

        #endregion


        public static ContextMenuStrip CreateContextMenuStrip()
        {
            ContextMenuStrip contextMenuStrip;
            ToolStripMenuItem close;

            contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Name = "contextMenuStrip";

            close = new ToolStripMenuItem();
            close.Name = "close";
            close.Text = "关闭";
            close.Click += new EventHandler(close_click);
            contextMenuStrip.Items.Add(close);

            return contextMenuStrip;
        }

        private static void close_click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
