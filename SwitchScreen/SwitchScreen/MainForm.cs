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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
            if (System.Windows.Forms.Screen.AllScreens.Count() == 1)
            {
                this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("close")));
                this.notifyIcon.Text = "切换到双屏";
                this.notifyIcon.Tag = "Single";
            }
            else
            {
                this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("open")));
                this.notifyIcon.Text = "切换到单屏";
                this.notifyIcon.Tag = "Multiple";
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
                if (notifyIcon.Tag.ToString() == "Single")
                {
                    notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("open")));
                    notifyIcon.Tag = "Multiple";
                    notifyIcon.Text = "切换到单屏";
                }
                else if(notifyIcon.Tag.ToString() == "Multiple")
                {
                    notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("close")));
                    notifyIcon.Tag = "Single";
                    notifyIcon.Text = "切换到双屏";
                }
                SwitchScreen();
            }
            if (e.Button == MouseButtons.Right)
            {
                //#region 使用右键菜单关闭 
                //notifyIcon.ContextMenuStrip = CreateContextMenuStrip();
                //Point point = Control.MousePosition;
                //notifyIcon.ContextMenuStrip.Show(point);
                //#endregion

                #region 直接关闭 
                System.Environment.Exit(0);
                #endregion
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
