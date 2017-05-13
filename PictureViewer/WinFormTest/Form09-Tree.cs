using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormTest
{
    public partial class Form09 : Form
    {
        public Form09()
        {
            InitializeComponent();
            treeView1.ImageList = imageListIcon;
            LoadTreeView();
            this.treeView1.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
        private void LoadTreeView()
        {
            TreeNode rootNode;
            DirectoryInfo info = new DirectoryInfo(@"F:\Test");
            if (info.Exists)
            {
                ImageTree rootFolder = new ImageTree(info.Name, info.FullName, true);
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = rootFolder;
                rootNode.ImageKey = "folder.png";
                rootNode.SelectedImageKey = "folder-select.png";
                treeView1.Nodes.Add(rootNode);
                rootNode.Expand();
                GetDirectories(info.GetDirectories(), rootNode);
            }
        }

        private void GetDirectories(DirectoryInfo[] subDirs, TreeNode rootNode)
        {
            TreeNode folderNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {

                ImageTree folder = new ImageTree(subDir.Name, subDir.FullName, true);

                folderNode = new TreeNode(folder.Name);
                folderNode.Tag = folder;
                folderNode.ImageKey = "folder.png";
                folderNode.SelectedImageKey = "folder-select.png";

                subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0)
                {
                    GetDirectories(subSubDirs, folderNode);
                }
                rootNode.Nodes.Add(folderNode);

                FileInfo[] files = subDir.GetFiles("*.jpg");
                foreach (FileInfo file in files)
                {
                    ImageTree image = new ImageTree(file.Name, file.FullName, false);
                    TreeNode imgNode = new TreeNode(image.Name);
                    imgNode.Tag = image;
                    imgNode.ImageKey = "img.png";
                    imgNode.SelectedImageKey = "img-select.png";
                    folderNode.Nodes.Add(imgNode);
                }
            }
        }
        void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;

            ImageTree image = (ImageTree)node.Tag;

            if (image.IsFolder == true)
            {
                MessageBox.Show(image.FullPath);

            }
            else
            {
                MessageBox.Show(image.FullPath);

            }

        }
    }
}
