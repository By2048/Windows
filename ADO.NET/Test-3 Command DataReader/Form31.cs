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

namespace Test_3_Command_DataReader
{
    public partial class Form31 : Form
    {
        public Form31()
        {
            InitializeComponent();
        }

        private void Form31_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.CenterToScreen();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void show_Click(object sender, EventArgs e)
        {
            this.listID.Items.Clear();
            this.listName.Items.Clear();
            this.listScore.Items.Clear();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Initial catalog=northwind;data source=.;integrated security=true";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select ID,Name,Score from Students";
                SqlDataReader sqlData = cmd.ExecuteReader();
                while (sqlData.Read())
                {
                    this.listID.Items.Add(sqlData.GetString(0));
                    this.listName.Items.Add(sqlData.GetString(1));
                    this.listScore.Items.Add(sqlData.GetValue(2).ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
            }
        }

        private void create_Click(object sender, EventArgs e)
        {
            string strConn, strCreate;
            strConn= "initial catalog = northwind;data source=.;integrated security=true";
            strCreate = "create table Students(ID char(10),Name varchar(20),Score integer)";
            SqlConnection connection = new SqlConnection(strConn);
            connection.Open();            
            SqlCommand cmd = new SqlCommand(strCreate,connection);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                connection.Close();
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            string ID = this.textID.Text.Trim();
            string Name = this.textName.Text.Trim();
            int Score = int.Parse(this.textScore.Text.Trim());
            SqlConnection connection = new SqlConnection();
            try
            {
                string strConn = "initial catalog = northwind;data source=.;integrated security=true";
                string strInsert = string.Format("insert into Students values('{0}','{1}',{2})", ID, Name, Score);
                connection.ConnectionString = strConn;
                connection.Open();
                SqlCommand cmd = new SqlCommand(strInsert, connection);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception error)
            {
                MessageBox.Show(error.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                connection.Close();
            }
        }

        private void del_Click(object sender, EventArgs e)
        {
            string ID = this.textID.Text.ToString();
            if (ID.Length == 0)
            {
                MessageBox.Show("学号不能为空！", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textID.Focus();
                return;
            }
            SqlConnection connection = new SqlConnection();
            try
            {
                string strConn = "initial catalog = northwind;data source=.;integrated security=true";
                string strDel = string.Format("delete from Students where ID ='{0}'", ID);
                connection.ConnectionString = strConn;
                connection.Open();
                SqlCommand cmd = new SqlCommand(strDel, connection);
                int cnt = cmd.ExecuteNonQuery();
                MessageBox.Show(cnt + "条记录被删除", "删除提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception error)
            {
                MessageBox.Show(error.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                connection.Close();
            }
        }

       
    }
}
