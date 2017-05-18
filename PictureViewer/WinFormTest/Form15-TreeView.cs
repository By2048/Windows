using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinFormTest
{
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            string rootPath = @"F:\Test";  //string rootPath = @"F:\Image\mzitu";


            TreeNode rootNode = new TreeNode("RootNode");
            treeView.Nodes.Add(rootNode);

            LoadTree(rootPath, rootNode);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void LoadTree(string rootPath, TreeNode rootNode)
        {
            DirectoryInfo info = new DirectoryInfo(rootPath);
            
            DirectoryInfo[] subDirs = info.GetDirectories().OrderByDescending(tmp => tmp.CreationTime).ToArray();

            foreach (DirectoryInfo subDir in subDirs)
            {
                //MessageBox.Show(subDir.FullName.ToString());
                TreeNode folderNode = new TreeNode(subDir.Name);
                //treeView.Nodes.Add(folderNode);
                rootNode.Nodes.Add(folderNode);
                DirectoryInfo[] subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0)
                {
                    MessageBox.Show(subDir.FullName.ToString());
                    MessageBox.Show(folderNode.Text);
                    LoadTree(subDir.FullName.ToString(), folderNode);
                }
                FileInfo[] _files = subDir.GetFiles("*.*");
                foreach (FileInfo file in _files)
                {
                    TreeNode fileNode = new TreeNode(file.Name);
                    folderNode.Nodes.Add(fileNode);
                }
            }

            FileInfo[] files = info.GetFiles("*.*");
            foreach (FileInfo file in files)
            {
                TreeNode fileNode = new TreeNode(file.Name);
                rootNode.Nodes.Add(fileNode);
            }

        }

    }
}
