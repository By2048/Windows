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
    public partial class Calclator : Form
    {
        public Calclator()
        {
            InitializeComponent();
        }

        // 初始化时允许用户键盘输入
        private void Calculator_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            CenterToScreen();
        }

        // 计算表达式
        private Calculator calculator = new Calculator();
        private void calcExperss(string textFormulaText)
        {            
            try
            {
                calculator.Expression = textFormulaText.Trim();
                this.textResult.Text = calculator.ExecuteToString();
            }
            catch (Exception ex)
            {
                this.textResult.Text = ex.Message;
            }
        }

        // 获取点击数字按钮的数值
        private void Number_Click(object sender, EventArgs e)
        {
            textFormula.Text += ((Button)sender).Text;
        }
        double firstNum, secondNum;
        bool firstInput = true;
        string operat;
        private void clean_Click(object sender, EventArgs e)
        {
            textFormula.Text = "";
            textResult.Text = "";
            firstNum = 0;
            secondNum = 0;
        }

        private void operat_Click(object sender, EventArgs e)
        {
            textFormula.Text += ((Button)sender).Text;
            if (firstInput == false)
            {
                calcExperss(textFormula.Text.Substring(0,textFormula.Text.Length-1));
            }
            else
            {
                firstInput = false;
            }
        }

        private void calc_Click(object sender, EventArgs e)
        {
            calcExperss(textFormula.Text);
        }

        private void cleanEnter_Click(object sender, EventArgs e)
        {
            this.textFormula.Text = "";
        }


        private void back_Click(object sender, EventArgs e)
        {
            string inPut = this.textFormula.Text;
            if (inPut.Length > 0)
                this.textFormula.Text = inPut.Substring(0, inPut.Length - 1);
        }

        private void square_Click(object sender, EventArgs e)
        {
            double num = double.Parse(this.textFormula.Text);
            this.textResult.Text = Math.Sqrt(num).ToString();
        }

        private void binary_Click(object sender, EventArgs e)
        {
            int num = int.Parse(this.textFormula.Text);
            this.textResult.Text = Convert.ToString(num, 2);
        }

        // 启动一个新的窗口
        private void calcExpress_Click(object sender, EventArgs e)
        {
            CalcExpress newForm = new CalcExpress();
            newForm.ShowDialog();
        }

        // 判断输入是否合法
        private void calc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= (char)Keys.D0 && e.KeyChar <= (char)Keys.D9)   
                this.textFormula.Text += e.KeyChar.ToString();
            if (e.KeyChar == 43) // +
                this.textFormula.Text +="+";
            if (e.KeyChar == 45) // -
                this.textFormula.Text += "-";
            if (e.KeyChar == 42) // *
                this.textFormula.Text += "*";
            if (e.KeyChar == 47) // /
                this.textFormula.Text += "/";
            if (e.KeyChar == 46) // .
                this.textFormula.Text += ".";
            if (e.KeyChar == (char)Keys.Enter)
                calcExperss(textFormula.Text);
        }


  
    }
}
