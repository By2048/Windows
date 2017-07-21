using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwitchScreen
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (new MainForm())
            {
                Application.Run();
            }
            //Application.Run(new TestForm());
        }


        //static void Main()
        //{
        //    HideOnStartupApplicationContext context = new HideOnStartupApplicationContext(new MainForm());
        //    Application.Run(context);
        //}
    }
}
