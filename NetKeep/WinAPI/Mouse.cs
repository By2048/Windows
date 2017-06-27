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
using WinAPI;

namespace WinAPI
{
    public class Mouse
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int mouse_event(MouseFlags dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern void SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(ref Point lpPoint);


        public void MoveTo(Point point)
        {
            SetCursorPos(point.X, point.Y);
        }
        public void MoveTo(int x, int y)
        {
            SetCursorPos(x, y);
        }


        public Point Location()
        {
            Point point = new Point();
            GetCursorPos(ref point);
            return point;
        }

        public void Click(Button button)
        {
            switch (button)
            {
                case Button.Left:
                    mouse_event(MouseFlags.Absolute | MouseFlags.LeftDown , 0, 0, 0, 0);
                    Thread.Sleep(500);
                    mouse_event(MouseFlags.Absolute | MouseFlags.LeftUp, 0, 0, 0, 0);
                    break;                
                default:
                    break;
            }
        }

    }
}
