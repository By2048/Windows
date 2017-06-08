using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Test_2_Connection
{
    public partial class Form22 : Form
    {
        public Form22()
        {
            InitializeComponent();
        }
        OpenFileDialog openFileDialog = new OpenFileDialog();
        private void Form22_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            //this.openFileDialog.Filter = "mdb文件(*.mdb)|*.mdb|Access文件(*.accdb)|*.accdb|所有文件(*.*)|*.*";
            this.openFileDialog.Filter = "Access文件(*.accdb)|*.accdb|所有文件(*.*)|*.*";
        }
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void openFile_Click(object sender, EventArgs e)
        {
            this.openFileDialog.ShowDialog();
            this.textFilePath.Text = this.openFileDialog.FileName;
        }

        private void link_Click(object sender, EventArgs e)
        {
            string strConnString, strFilePath;
            strFilePath = this.textFilePath.Text.Trim();
            if (strFilePath.Length == 0)
            {
                MessageBox.Show("数据库文件不能为空！", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textFilePath.Focus();
                return;
            }
            strConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath;
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = strConnString;
            try
            {
                conn.Open();
            }
            catch (System.Data.OleDb.OleDbException error)
            {
                MessageBox.Show(error.Message, "连接提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("成功登录数据库！", "连接提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
