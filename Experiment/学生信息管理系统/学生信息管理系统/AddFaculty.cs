using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 学生信息管理系统
{
    public partial class AddFaculty : Form
    {
        public AddFaculty()
        {
            InitializeComponent();
        }

        private void AddFaculty_Load(object sender, EventArgs e)
        {
            CenterToParent();
            //FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
        }
        public string AddFacultyName = "";
      

        private void butSure_Click(object sender, EventArgs e)
        {
            AddFacultyName = textAddFaculty.Text.Trim();
            DialogResult = DialogResult.OK;
            //this.Close();
        }
    }
    
}
