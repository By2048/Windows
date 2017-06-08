using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_9_XML
{
    public partial class Form92 : Form
    {
        public Form92()
        {
            InitializeComponent();
        }
        private void Form92_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
        private DataSet dateSet = new DataSet();
        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                dateSet.ReadXml("../../Courses.xml", XmlReadMode.Auto);
                dataGridView.DataSource = dateSet.Tables["Courses"];
                dataGridView.DataSource = dateSet.Tables[0];
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                dateSet.WriteXml("../../Courses2.xml", XmlWriteMode.IgnoreSchema);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

        }
    }
}
