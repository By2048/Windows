using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpressionCalculator;

namespace 计算器
{
    public partial class CalcExpress : Form
    {
        public CalcExpress()
        {
            InitializeComponent();
        }
        private Calculator calculator = new Calculator();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                calculator.Expression = this.textBox1.Text.Trim();
                this.textBox2.Text = calculator.ExecuteToString();
            }
            catch (Exception ex)
            {
                this.textBox2.Text = ex.Message;
            }
        }

       

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                button1_Click(null, null);
            }
        }

        private void CalcExpress_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
    }
}
