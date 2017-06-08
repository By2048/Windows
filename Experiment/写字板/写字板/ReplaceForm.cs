using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 写字板
{
    public partial class ReplaceForm : Form
    {
        public static List<string> hisserach;
        public static List<string> hisdreplace;
        MainForm mainForm;
        private void ReplaceForm_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }
        public ReplaceForm(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void last_Click(object sender, EventArgs e)
        {
            string serachText = this.textBoxFindTextOnly.Text.ToString();
            if (serachText.Length != 0)
                mainForm.SerachBefor(serachText);
            else
                MessageBox.Show("查找字符串不能为空", "提示", MessageBoxButtons.OK);
        }
        private void next_Click(object sender, EventArgs e)
        {
            string serachText = this.textBoxFindTextOnly.Text.ToString();
            if (serachText.Length != 0)
                mainForm.Serach(serachText);
            else
                MessageBox.Show("查找字符串不能为空", "提示", MessageBoxButtons.OK);
        }


        private void replace_Click(object sender, EventArgs e)
        {
            if (textBoxFindText.Text.Length != 0)
                mainForm.Replace(textBoxFindText.Text, textBoxReplaceText.Text);
            else
                MessageBox.Show("替换字符串不能为空", "提示", MessageBoxButtons.OK);
        }

        private void replaceall_Click(object sender, EventArgs e)
        {
            if (textBoxFindText.Text.Length != 0)
                mainForm.ReplaceAll(textBoxFindText.Text, textBoxReplaceText.Text);
            else
                MessageBox.Show("替换字符串不能为空", "提示", MessageBoxButtons.OK);
        }

      
    }
}
