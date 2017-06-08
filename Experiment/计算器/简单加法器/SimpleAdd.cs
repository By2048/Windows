using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 简单加法器
{
    public partial class simpleAdd : Form
    {
        public simpleAdd()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void simpleAdd_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            // 设置文本框不可输入
            textResult.Enabled = false;
        }

        private void calc_Click(object sender, EventArgs e)
        {
            double firstNum, secondNum;
            try
            {
                firstNum = double.Parse(this.textFirstNum.Text);
                secondNum = double.Parse(this.textSecondNum.Text);
            }
            catch
            {
                MessageBox.Show("数据的加数或被加数不合法！");
                this.textFirstNum.Focus();
                return;
            }
            this.textResult.Text = (firstNum + secondNum).ToString();
        }

        private void clean_Click(object sender, EventArgs e)
        {
            textFirstNum.Text = "";
            textSecondNum.Text = "";
            textResult.Text = "";
        }

        private void firstNumPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar!=46 /*.*/ && e.KeyChar!=8/*backspace*/) 
                e.Handled = true;
        }
        
        // 为输入框设置输入条件
        private void secondNumPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 46 && e.KeyChar != 8)
                e.Handled = true;
        }
            
    }
}
