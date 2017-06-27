using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WinAPI
{
    public class Internet
    {
        private const int INTERNET_CONNECTION_MODEM = 1;
        private const int INTERNET_CONNECTION_LAN = 2;

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(ref int connectionDescription, int reservedValue);

        [DllImport("winInet.dll")]
        private static extern bool InternetGetConnectedState(int dwFlag, int dwReserved);

        public bool IsLink()
        {
            System.Int32 dwFlag = new int();
            InternetGetConnectedState(ref dwFlag, 0);
            bool state = InternetGetConnectedState(0, 0);
            if (state == false)
                return false; // 未连网
            else if ((dwFlag & INTERNET_CONNECTION_MODEM) != 0)
                return true; // 采用调治解调器上网
            else if ((dwFlag & INTERNET_CONNECTION_LAN) != 0)
                return false; // 采用网卡上网
            return true;
        }
    }
}




