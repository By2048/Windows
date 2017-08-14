using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwitchScreen
{
    public partial class TestForm : Form
    {
        HotKeys h = new HotKeys();
        public TestForm()
        {
            InitializeComponent();


        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            h.Regist(this.Handle, (int)HotKeys.HotkeyModifiers.Control + (int)HotKeys.HotkeyModifiers.Alt, Keys.NumPad1, CallBack);
            MessageBox.Show("注册成功");


            pictureBox1.Image = Image.FromFile("..\\..\\icon\\close.ico");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            h.UnRegist(this.Handle, CallBack);
            MessageBox.Show("卸载成功");
        }
        protected override void WndProc(ref Message m)
        {
            h.ProcessHotKey(m);//快捷键消息处理
            base.WndProc(ref m);
        }
        //按下快捷键时被调用的方法
        public void CallBack()
        {
            MessageBox.Show("快捷键被调用！");
        }

       
    }
}
