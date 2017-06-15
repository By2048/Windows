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
        public TreeView()
        {
            InitializeComponent();
            treeViewImg.ShowLines = false; 
            Size = MainConfig.PanelTreeSize;
            treeViewImg.Size = MainConfig.PanelTreeSize;
            treeViewImg.ImageList = imageListIcon;
            LoadTreeView(MainConfig.StartTreePath);
            treeViewImg.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeViewImg_NodeMouseClick);
            LoadCollectionTree();

            if (MainConfig.CurNodeText!="")
            {
                TreeNode oldNode = FindNode(MainConfig.CurNodeText);
                oldNode.Expand();
                treeViewImg.SelectedNode = oldNode;
            }
            
        }

        // 初始化 TreeView 根据上一次点击的节点
        public TreeView(string oldNodeText)
        {
            oldNodeText = MainConfig.CurNodeText;
            InitializeComponent();
            treeViewImg.ShowLines = false;
            Size = MainConfig.PanelTreeSize;
            treeViewImg.Size = MainConfig.PanelTreeSize;
            treeViewImg.ImageList = imageListIcon;
            LoadTreeView(MainConfig.StartTreePath);
            treeViewImg.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeViewImg_NodeMouseClick);
            LoadCollectionTree();

            TreeNode oldNode = FindNode(oldNodeText);
            oldNode.Expand();
            treeViewImg.SelectedNode = oldNode;
        }

        private void LoadTreeView(string rootPath)
        {

            ImageTree nodeTag = new ImageTree("图片目录", "", NodeType.NodeTag);
            TreeNode imageNode = new TreeNode("图片目录");
            imageNode.Tag = nodeTag;
            imageNode.ImageKey = "folder.png";
            imageNode.SelectedImageKey = "folder-select.png";
            treeViewImg.Nodes.Add(imageNode);

            ImageTree startTag = new ImageTree(Path.GetFileName(rootPath), rootPath, NodeType.Folder);
            TreeNode startNode = new TreeNode(Path.GetFileName(rootPath));
            startNode.Tag = startTag;
            startNode.ImageKey = "folder.png";
            startNode.SelectedImageKey = "folder-select.png";
            imageNode.Nodes.Add(startNode);
            imageNode.Expand();

            LoadTreeView(rootPath, startNode);

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

        public delegate void LoadToolStripStatusLabel();
        public event LoadToolStripStatusLabel LoadToolStripStatusLabelEvent;

        private void treeViewImg_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            ImageTree nodeTag = (ImageTree)node.Tag;
            if (e.Button == MouseButtons.Left)
            {
                if (nodeTag.NodeType.ToString() == "Folder" || nodeTag.NodeType.ToString()== "Collection")
                {
                    MainConfig.ShowFolderPath = nodeTag.FullPath;
                    MainConfig.CurNodeText=nodeTag.Name;
                    LoadUserControlEvent();
                    LoadToolStripStatusLabelEvent();
                }
                else if (nodeTag.NodeType.ToString() == "Image")
                {
                    MainConfig.ShowImagePath = nodeTag.FullPath;
                    LoadImageEvent();
                    LoadToolStripStatusLabelEvent();
                }
                else
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
                //List<string> _filePath = new List<string>();
                List<string> listFilePath=new List<string>();

                //文件夹优先
                foreach (string filePath in filePaths)
                {
                    if (Directory.Exists(filePath))
                        listFilePath.Add(filePath);
                }
                foreach (string filePath in filePaths)
                {
                    if (File.Exists(filePath))
                        listFilePath.Add(filePath);
                }

                foreach (string filePath in listFilePath)
                {
                    if (Directory.Exists(filePath)) //文件夹
                    {
                        ImageTree fodler = new ImageTree(Path.GetFileName(filePath), filePath, NodeType.Folder);
                        TreeNode folderNode = new TreeNode(Path.GetFileName(filePath));
                        folderNode.Tag = fodler;
                        folderNode.ImageKey = "folder.png";
                        folderNode.SelectedImageKey = "folder-select.png";
                        dragNode.Nodes.Add(folderNode);
                        LoadTreeView(filePath, folderNode);
                    }
                    else if (File.Exists(filePath)) //文件
                    {
                        ImageTree image = new ImageTree(Path.GetFileName(filePath), filePath, NodeType.Image);
                        TreeNode imgNode = new TreeNode(Path.GetFileName(filePath));
                        imgNode.Tag = image;
                        imgNode.ImageKey = "img.png";
                        imgNode.SelectedImageKey = "img-select.png";
                        dragNode.Nodes.Add(imgNode);
                    }
                    else
                        return;                  
                }
                dragNode.Expand();
            }
        }

        private void LoadCollectionTree()
        {
            if (FindNode("我的收藏") == null)
            {
                ImageTree nodeTag = new ImageTree("我的收藏", "", NodeType.NodeTag);
                TreeNode node = new TreeNode("我的收藏");
                node.Tag = nodeTag;
                node.ImageKey = "folder.png";
                node.SelectedImageKey = "folder-select.png";
                treeViewImg.Nodes.Add(node);
            }
            TreeNode collNode = FindNode("我的收藏");
            collNode.Nodes.Clear();
            List<string> allPath = CollectionTool.GetALlPath();
            foreach (string path in allPath)
            {
                if (Directory.Exists(path)) //文件夹
                {
                    ImageTree fodler = new ImageTree(Path.GetFileName(path), path, NodeType.Collection);
                    TreeNode folderNode = new TreeNode(Path.GetFileName(path));
                    folderNode.Tag = fodler;
                    folderNode.ImageKey = "folder.png";
                    folderNode.SelectedImageKey = "folder-select.png";
                    collNode.Nodes.Add(folderNode);
                    LoadTreeView(path, folderNode);
                }
                else if (File.Exists(path)) //文件
                {
                    ImageTree image = new ImageTree(Path.GetFileName(path), path, NodeType.Collection);
                    TreeNode imgNode = new TreeNode(Path.GetFileName(path));
                    imgNode.Tag = image;
                    imgNode.ImageKey = "img.png";
                    imgNode.SelectedImageKey = "img-select.png";
                    collNode.Nodes.Add(imgNode);
                }
                else
                    return;
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

        private void treeViewImg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point clickPoint = new Point(e.X, e.Y);
                TreeNode curNode = treeViewImg.GetNodeAt(clickPoint);
                ImageTree image = (ImageTree)curNode.Tag;
                if (image.NodeType.ToString() == "Folder" || image.NodeType.ToString() == "Image")
                    ContextMenuStrip = CreateContextMenuStrip(curNode);
                else
                    ContextMenuStrip = CreateCollContextMenuStrip(curNode);
            }
        }

        public ContextMenuStrip CreateContextMenuStrip(TreeNode selectNode)
        {
            ContextMenuStrip contextMenuStrip;
            ToolStripMenuItem delete;
            ToolStripMenuItem collection;

            contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Name = "contextMenuStrip";

            delete = new ToolStripMenuItem();
            delete.Name = "Delete";
            delete.Text = "删除";
            delete.Click += new EventHandler(Delete_click);
            delete.Tag = selectNode;

            collection = new ToolStripMenuItem();
            collection.Name = "Collection";
            collection.Text = "添加收藏";
            collection.Click += new EventHandler(Collection_click);
            collection.Tag = selectNode;

            contextMenuStrip.Items.AddRange(
                new ToolStripItem[] {
                delete,
                collection,
            });
            return contextMenuStrip;
        }

        private void Delete_click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            TreeNode node = (TreeNode)item.Tag;
            ImageTree imageTree = (ImageTree)node.Tag;
            string path = imageTree.FullPath;
            treeViewImg.Nodes.Remove(node);
            ImageTool.Delete(path);
        }

        private void Collection_click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            TreeNode node = (TreeNode)item.Tag;
            ImageTree imageTree = (ImageTree)node.Tag;
            string type = imageTree.NodeType.ToString();
            string path = imageTree.FullPath;
            string date = DateTime.Now.ToString();
            Collection coll = new Collection(type, path, date);
            CollectionTool.Add(coll);
            LoadCollectionTree();
        }


        // 创建收藏Node的右键菜单
        public ContextMenuStrip CreateCollContextMenuStrip(TreeNode selectNode)
        {
            ContextMenuStrip contextMenuStrip;
            ToolStripMenuItem delete;

            contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Name = "contextMenuStrip";

            delete = new ToolStripMenuItem();
            delete.Name = "Delete";
            delete.Text = "删除";
            delete.Click += new EventHandler(CollDelete_click);
            delete.Tag = selectNode;


            contextMenuStrip.Items.AddRange(
                new ToolStripItem[] {
                delete,
            });
            return contextMenuStrip;
        }

        private void CollDelete_click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            TreeNode node = (TreeNode)item.Tag;
            ImageTree imageTree = (ImageTree)node.Tag;
            string path = imageTree.FullPath;
            treeViewImg.Nodes.Remove(node);
            CollectionTool.RemoveByPath(path);
        }       

    }
}
