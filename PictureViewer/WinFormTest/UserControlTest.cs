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
    public partial class UserControlTest : UserControl
    {
        public UserControlTest()
        {
            InitializeComponent();
        }
        public delegate void deleset(string n);
        public event deleset delevent;

        private void button1_Click(object sender, EventArgs e)
        {
            delevent(textBox1.Text.ToString());
            textBox1.Text = "";
        }
      
    }
}
