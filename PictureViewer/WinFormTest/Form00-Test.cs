using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinFormTest
{
    public partial class Form00 : Form
    {
        public Form00()
        {
            InitializeComponent();
        }

        private void Form00_Load(object sender, EventArgs e)
        {
            UserControlTest us1 = new UserControlTest();
            us1.delevent += new UserControlTest.deleset(set);
            this.panel1.Controls.Add(us1);
        }

        private void button1_Click(object sender, EventArgs e)
        {         

        }
        public void set(string m)
        {
            textBox1.Text = m;

            UserControlTest2 us1 = new UserControlTest2(textBox1.Text);
            this.panel2.Controls.Add(us1);
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
