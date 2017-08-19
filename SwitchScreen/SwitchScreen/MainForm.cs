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
        HotKeys h = new HotKeys();

        Icon iconClose = Icon.FromHandle(new Bitmap("icon\\close.ico").GetHicon());
        Icon iconOpen = Icon.FromHandle(new Bitmap("icon\\open.ico").GetHicon());

        public MainForm()
        {
            InitializeComponent();
            if (Screen.AllScreens.Count() == 1)
            {
                this.notifyIcon.Icon = iconClose;
                this.notifyIcon.Text = "切换到双屏";
                this.notifyIcon.Tag = "Single";
            }
            else
            {
                this.notifyIcon.Icon = iconOpen;
                this.notifyIcon.Text = "切换到单屏";
                this.notifyIcon.Tag = "Multiple";
            }
            h.Regist(this.Handle, (int)HotKeys.HotkeyModifiers.Control + (int)HotKeys.HotkeyModifiers.Shift, Keys.F12, CallBack);
        }

        public void RefreshIcon()
        {
            if (Screen.AllScreens.Count() == 1)
            {
                this.notifyIcon.Icon = iconClose;
                this.notifyIcon.Text = "切换到双屏";
                this.notifyIcon.Tag = "Single";
            }
            else
            {
                this.notifyIcon.Icon = iconOpen;
                this.notifyIcon.Text = "切换到单屏";
                this.notifyIcon.Tag = "Multiple";
            }
        }

        //private void btnUnregist_Click(object sender, EventArgs e)
        //{
        //    h.UnRegist(this.Handle, CallBack);
        //    MessageBox.Show("卸载成功");
        //}

        protected override void WndProc(ref Message m)
        {
            //窗口消息处理函数
            h.ProcessHotKey(m);
            base.WndProc(ref m);
        }



        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                StartSwitch();        
            }
            if (e.Button == MouseButtons.Right)
            {
                // 使用右键菜单关闭 
                //notifyIcon.ContextMenuStrip = CreateContextMenuStrip();
                //Point point = Control.MousePosition;
                //notifyIcon.ContextMenuStrip.Show(point);

                // 直接关闭 
                System.Environment.Exit(0);
            }
        }

        private void StartSwitch()
        {
            if (notifyIcon.Tag.ToString() == "Single")
            {
                this.notifyIcon.Icon = iconOpen;
                notifyIcon.Tag = "Multiple";
                notifyIcon.Text = "切换到单屏";
            }
            else if (notifyIcon.Tag.ToString() == "Multiple")
            {
                this.notifyIcon.Icon = iconClose;
                notifyIcon.Tag = "Single";
                notifyIcon.Text = "切换到双屏";
            }
            SwitchScreen();
        }

        public void CallBack()
        {
            Thread.Sleep(500); // 不加 sleep 出错 ？？？？
            StartSwitch();
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

 
        public const int KEYEVENTF_EXTENDEDKEY = 0x0001; // Key click flag
        public const int KEYEVENTF_KEYUP = 0x0002; // Key up flag

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
            VirtualKeyDown(keyCode);
            Thread.Sleep(200);
            VirtualKeyUp(keyCode);
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
