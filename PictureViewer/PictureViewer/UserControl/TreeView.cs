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
        /// <summary>
        /// 初始化TreeView
        /// </summary>
        /// <param name="panelSize">窗体中TreeView需要展示的大小</param>
        public TreeView(Size panelSize)
        {
            InitializeComponent();
            Size = panelSize;
            treeViewImg.Size = panelSize;
            treeViewImg.ImageList = imageListIcon;
            LoadTreeView(MainConfig.StartTreePath);
            treeViewImg.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeViewImg_NodeMouseClick);
        }
        private void LoadTreeView(string rootPath)
        {
            ImageTree userTag = new ImageTree(Path.GetFileName(rootPath), rootPath, NodeType.Folder);
            TreeNode userNode = new TreeNode(Path.GetFileName(rootPath));
            userNode.Tag = userTag;
            userNode.ImageKey = "folder.png";
            userNode.SelectedImageKey = "folder-select.png";
            treeViewImg.Nodes.Add(userNode);
            userNode.Expand();
            LoadTreeView(rootPath, userNode);

            MainConfig.ShowFolderPath = rootPath;
        }

        private void LoadTreeView(string rootPath, TreeNode rootNode)
        {
            DirectoryInfo info = new DirectoryInfo(rootPath);
            DirectoryInfo[] subDirs = info.GetDirectories().OrderByDescending(tmp => tmp.CreationTime).ToArray();

            foreach (DirectoryInfo subDir in subDirs)
            {
                // 子文件中没有文件&&文件夹 跳出循环
                if (subDir.GetDirectories().Length == 0 && ImageTool.GetFilesByDir(subDir).Length == 0)
                {
                    continue;
                }
                ImageTree folder = new ImageTree(subDir.Name, subDir.FullName, NodeType.Folder);
                TreeNode folderNode = new TreeNode(subDir.Name);
                folderNode.Tag = folder;
                folderNode.ImageKey = "folder.png";
                folderNode.SelectedImageKey = "folder-select.png";
                rootNode.Nodes.Add(folderNode);

                DirectoryInfo[] subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0)
                {
                    LoadTreeView(subDir.FullName.ToString(), folderNode);
                }
                FileInfo[] subImgs = ImageTool.GetFilesByDir(subDir);
                if (subImgs.Length != 0)
                {
                    foreach (FileInfo img in subImgs)
                    {
                        ImageTree image = new ImageTree(img.Name, img.FullName, NodeType.Image);
                        TreeNode imgNode = new TreeNode(img.Name);
                        imgNode.Tag = image;
                        imgNode.ImageKey = "img.png";
                        imgNode.SelectedImageKey = "img-select.png";
                        folderNode.Nodes.Add(imgNode);
                    }
                }
            }

            FileInfo[] imgs = ImageTool.GetFilesByDir(info);
            foreach (FileInfo img in imgs)
            {
                ImageTree image = new ImageTree(img.Name, img.FullName, NodeType.Image);
                TreeNode imgNode = new TreeNode(img.Name);
                imgNode.Tag = image;
                imgNode.ImageKey = "img.png";
                imgNode.SelectedImageKey = "img-select.png";
                rootNode.Nodes.Add(imgNode);
            }
        }

        public delegate void LoadUserControl();
        public event LoadUserControl LoadUserControlEvent;

        public delegate void LoadImage();
        public event LoadImage LoadImageEvent;

        private void treeViewImg_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            ImageTree nodeTag = (ImageTree)node.Tag;

            if (nodeTag.NodeType.ToString() == "Folder")
            {
                MainConfig.ShowFolderPath = nodeTag.FullPath;
                LoadUserControlEvent();
            }
            else if (nodeTag.NodeType.ToString() == "Image")
            {
                MainConfig.ShowImagePath = nodeTag.FullPath;
                LoadImageEvent();
            }
            else
            {
                return;
            }
        }

        private void treeViewImg_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
        }

        private void treeViewImg_DragEnter(object sender, DragEventArgs e)
        {
            if (FindNode("拖放文件") == null)
            {
                ImageTree nodeTag = new ImageTree("拖放文件", "", NodeType.NodeTag);
                TreeNode dragNode = new TreeNode("拖放文件");
                dragNode.Tag = nodeTag;
                dragNode.ImageKey = "folder.png";
                dragNode.SelectedImageKey = "folder-select.png";
                treeViewImg.Nodes.Add(dragNode);
            }

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //TreeNode dragNode = treeViewImg.Nodes[1];
                TreeNode dragNode = FindNode("拖放文件");

                string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string filePath in filePaths)
                {
                    if (File.Exists(filePath)) //文件
                    {
                        //MessageBox.Show(Path.GetFileName(filePath));
                        ImageTree image = new ImageTree(Path.GetFileName(filePath), filePath, NodeType.Image);
                        TreeNode imgNode = new TreeNode(Path.GetFileName(filePath));
                        imgNode.Tag = image;
                        imgNode.ImageKey = "img.png";
                        imgNode.SelectedImageKey = "img-select.png";
                        dragNode.Nodes.Add(imgNode);
                    }
                    else if (Directory.Exists(filePath)) //文件夹
                    {
                        ImageTree fodler = new ImageTree(Path.GetFileName(filePath), filePath, NodeType.Folder);
                        TreeNode folderNode = new TreeNode(Path.GetFileName(filePath));
                        folderNode.Tag = fodler;
                        folderNode.ImageKey = "folder.png";
                        folderNode.SelectedImageKey = "folder-select.png";
                        dragNode.Nodes.Add(folderNode);
                    }
                }
                dragNode.Expand();
            }
        }


        public TreeNode FindNode(string nodeText, TreeNode rootNode)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                if (node.Text.Equals(nodeText))
                    return node;
                TreeNode next = FindNode(nodeText, node);
                if (next != null)
                    return next;
            }
            return null;
        }
        public TreeNode FindNode(string nodeText)
        {
            TreeNode itemNode = null;
            foreach (TreeNode node in treeViewImg.Nodes)
            {
                if (node.Text.Equals(nodeText))
                    return node;
                itemNode = FindNode(nodeText, node);
                if (itemNode != null)
                    break;
            }
            return itemNode;
        }



    }
}
