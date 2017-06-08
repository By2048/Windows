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

namespace Test_5_DataGridView_Operat_Data
{
    public partial class Form51 : Form
    {
        public Form51()
        {
            InitializeComponent();
        }

        private void Form51_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            string strCon, strSql;
            SqlConnection connection=null;
            SqlDataAdapter dataAdapter;
            DataSet dataSet;
            try
            {
                strSql = "select * from Customers";
                strCon = "initial catalog = northwind; data source =.; integrated security = true";
                connection = new SqlConnection(strCon);
                dataAdapter = new SqlDataAdapter(strSql, connection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Customers");
                this.dgvCustomers.DataSource = dataSet.Tables[0];
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
    }
}
