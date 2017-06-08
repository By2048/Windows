using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Test_2_Connection
{
    public partial class Form23 : Form
    {
        public Form23()
        {
            InitializeComponent();
        }

        private void Form23_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.textDBName.Text = "northwind";
            this.textUserName.Text = "root";
            this.textPWD.Text = "admin";
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void link_Click(object sender, EventArgs e)
        {
            if (this.textDBName.TextLength == 0)
            {
                MessageBox.Show("数据库文件不能为空！", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textDBName.Focus();
                return;
            }
            string strDBName, strUserName, strPWD;
            strDBName = this.textDBName.Text.Trim();
            strUserName = this.textUserName.Text.Trim();
            strPWD = this.textPWD.Text.Trim();
            if (this.textUserName.TextLength == 0)
            {
                MessageBox.Show("用户名不能为空！", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textUserName.Focus();
                return;
            }
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = String.Format("Persist Security Info=False;database={0};server=localhost;Connect Timeout=30;user id={1}; pwd={2}",strDBName,strUserName,strPWD);
                
            try
            {
                conn.Open();
            }
            catch (System.Exception error)
            {
                MessageBox.Show(error.Message.ToString(), "连接提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("成功登录数据库！", "连接提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
