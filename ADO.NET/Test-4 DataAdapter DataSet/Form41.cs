using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_4_DataAdapter_DataSet
{
    public partial class Form41 : Form
    {
        public Form41()
        {
            InitializeComponent();
        }

        private void Form41_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“northwindDataSet.Employees”中。您可以根据需要移动或删除它。
            this.employeesTableAdapter.Fill(this.northwindDataSet.Employees);

        }
             
    }
}
