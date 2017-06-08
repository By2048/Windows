using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Test_2_Connection
{
    public partial class Form21 : Form
    {
        public Form21()
        {
            InitializeComponent();
        }

        private void Form21_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            this.textUserName.Enabled = false;
            this.textPWD.Enabled = false;
            this.textServerName.Text = ".";
            this.textDBName.Text = "Northwind";
            this.textUserName.Text = "nw-link";
            this.textPWD.Text = "P@ssw0rd";
        }

        private void winLink_CheckedChanged(object sender, EventArgs e)
        {
            this.textUserName.Enabled = false;
            this.textPWD.Enabled = false;
        }

        private void sqlLink_CheckedChanged(object sender, EventArgs e)
        {
            this.textUserName.Enabled = true;
            this.textPWD.Enabled = true;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void link_Click(object sender, EventArgs e)
        {
            if (this.textDBName.TextLength == 0)
            {
                MessageBox.Show("数据库名不能为空！", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textDBName.Focus();
                return;
            }
            string strServerName,strDBName, strUserName, strPDW, strConnString;
            strServerName = this.textServerName.Text.Trim();
            strDBName = textDBName.Text.Trim();
            strUserName = textUserName.Text.Trim();
            strPDW = this.textPWD.Text.Trim();
            if (this.winLink.Checked == true)
            {
                strConnString = "Integrated Security=True; Data Source=" + strServerName +
                    "; initial catalog=" + strDBName;
            }
            else
            {
                if (this.textUserName.TextLength == 0)
                {
                    MessageBox.Show("用户名不能为空！", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.textUserName.Focus();
                    return;                    
                }
                strConnString = "Data Source=" + strServerName + ";initial catalog=" + strDBName + ";uid=" + strUserName + ";pwd=" + strPDW;
            }
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = strConnString;
            try
            {
                sqlCon.Open();
            }
            catch(SqlException error)
            {
                MessageBox.Show(error.Message, "连接提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("成功登录数据库！", "连接提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
