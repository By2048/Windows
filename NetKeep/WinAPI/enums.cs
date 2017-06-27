using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAPI
{
    public enum Button
    {
        Left,
        Right,
        Middle
    }
    public enum MouseFlags
    {
        Move = 0x0001,
        LeftDown = 0x0002,
        LeftUp = 0x0004,
        RightDown = 0x0008,
        RightUp = 0x0010,
        Absolute = 0x8000,
        MiddleDown = 0x0020,
        MiddleUp = 0x0040,
        Scroll = 2048
    }
}
