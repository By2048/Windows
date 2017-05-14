using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PictureViewer
{
    public partial class TreeView : UserControl
    {

        public TreeView(Size panelSize)
        {
            InitializeComponent();
            Size = panelSize;
            treeViewImg.ImageList = imageListIcon;
            LoadTreeView(MainConfig.StartTreePath);
            treeViewImg.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeViewImg_NodeMouseClick);
        }
        private void LoadTreeView(string rootPath)
        {
            TreeNode rootNode;
            DirectoryInfo info = new DirectoryInfo(rootPath);
            if (info.Exists)
            {
                ImageTree rootFolder = new ImageTree(info.Name, info.FullName, true);
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = rootFolder;
                rootNode.ImageKey = "folder.png";
                rootNode.SelectedImageKey = "folder-select.png";
                treeViewImg.Nodes.Add(rootNode);
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

        //public delegate void LoadImages(string showPath);
        public delegate void LoadImages();
        public event LoadImages LoadImagesEvent;
        private void treeViewImg_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            ImageTree nodeTag = (ImageTree)node.Tag;
            MainConfig.ShowFolderPath = nodeTag.FullPath;
            //LoadImagesEvent(nodeTag.FullPath);
            LoadImagesEvent();
        }

       
    }
}
