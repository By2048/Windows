using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormTest
{
    public partial class Form15 : Form
    {


        public Form15()
        {
            InitializeComponent();

            //RootPath rp = new RootPath();
            //rp.Path = @"F:\Test";

        }

        private void Form15_Load(object sender, EventArgs e)
        {
            CenterToScreen();

            panelTree.Controls.Clear();
            TreeView treeView = new TreeView(panelTree.Size);
            panelTree.Controls.Add(treeView);

        }

        private void LoadTreeView()
        {
            panelTree.Controls.Clear();
            TreeView treeView = new TreeView(panelTree.Size);
            panelTree.Controls.Add(treeView);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RootPath.Path = @"F:\Test";
            MessageBox.Show(RootPath.Path);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RootPath.Path = @"F:\Test\mzitu";
            MessageBox.Show(RootPath.Path);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadTreeView();
        }
    }
}
