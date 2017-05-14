using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormTest
{
    public partial class UserControlTest2 : UserControl
    {

        public UserControlTest2(string str)
        {
            InitializeComponent();


            textBox1.Text = str;

        }
    }
}
