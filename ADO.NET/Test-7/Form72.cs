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

namespace Test_7
{
    public partial class Form72 : Form
    {
        public Form72()
        {
            InitializeComponent();
        }

        private void Form72_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            string strCon, strSql;
            SqlConnection connection = null;
            SqlDataAdapter dataAdapter;
            DataSet dataSet;
            try
            {
                strSql = "select * from Workers";
                strCon = "initial catalog = northwind; data source =.; integrated security = true";
                connection = new SqlConnection(strCon);
                dataAdapter = new SqlDataAdapter(strSql, connection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Workers");
                this.dgvWorker.DataSource = dataSet.Tables[0];
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            string strCon, strSql;
            SqlConnection connection = null;
            SqlDataAdapter dataAdapter;
            DataSet dataSet;
            string searchName = textSearch.Text.ToString();
            try
            {
                if (searchName != "")
                {
                    strSql = string.Format("select * from Workers where Name='{0}'", searchName);
                    strCon = "initial catalog = northwind; data source =.; integrated security = true";
                    connection = new SqlConnection(strCon);
                    dataAdapter = new SqlDataAdapter(strSql, connection);
                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "Workers");
                    this.dgvWorker.DataSource = dataSet.Tables[0];
                }
                else
                {
                    strSql = string.Format("select * from Workers");
                    strCon = "initial catalog = northwind; data source =.; integrated security = true";
                    connection = new SqlConnection(strCon);
                    dataAdapter = new SqlDataAdapter(strSql, connection);
                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "Workers");
                    this.dgvWorker.DataSource = dataSet.Tables[0];
                }
              
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            Form71 newForm = new Form71();
            newForm.Show();
        }
    }

}
