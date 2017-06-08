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

//create table Workers
//(
//    ID char(10) primary key not null,
//    Name char(20),
//    Sex char(2),
//    Birthday datetime,
//    Job char(16), 
//    Department char(30)
//)
//insert into Workers values ('1','name-1','男','2011-10-2','job-1','dep-1')
//insert into Workers values ('2','name-2','女','2011-11-2','job-2','dep-2')
//insert into Workers values ('3','name-3','男','2011-7-2','job-3','dep-3')
//insert into Workers values ('4','name-4','女','2001-10-2','job-4','dep-4')
//insert into Workers values ('5','name-5','男','2010-10-21','job-5','dep-5')


namespace Test_7
{
    public partial class Form71 : Form
    {
        public Form71()
        {
            InitializeComponent();
        }
        private void Form71_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            createDB();
        }
        private void createDB()
        {
            string strConn = "initial catalog = northwind;data source=.;integrated security=true";
            string strCreate = "create table Workers(ID char(10) primary key not null," +
           "Name char(20),Sex char(10),Birthday datetime,Job char(16),Department char(30))";
            SqlConnection connection = new SqlConnection(strConn);
            connection.Open();
            SqlCommand cmd = new SqlCommand(strCreate, connection);
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

        private void save_Click(object sender, EventArgs e)
        {
            string id = textID.Text.ToString();
            string name = textName.Text.ToString();
            string sex = textSex.Text.ToString();
            string birthday = textBirthday.Text.ToString();
            string job = textJob.Text.ToString();
            string department = textDepartment.Text.ToString();
            SqlConnection connection = new SqlConnection();
            try
            {
                string strConn = "initial catalog = northwind;data source=.;integrated security=true";
                string strInsert = string.Format("insert into Workers values('{0}','{1}','{2}','{3}','{4}','{5}')", id, name, sex,birthday,job,department);
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
                MessageBox.Show("插入成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.Close();
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            textID.Text = "";
            textName.Text = "";
            textSex.Text = "";
            textBirthday.Text = "";
            textJob.Text="";
            textDepartment.Text = "";
        }

       
    }
}
