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
using System.Collections.Specialized;

namespace PictureViewer
{

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Resize += new EventHandler(MainForm_Resize);
            splitContainer.SplitterDistance = Size.Width / 4;
            CheckForIllegalCrossThreadCalls = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MainConfig.StartTreePath = @"F:\Test";
            MainConfig.ImageSize=new Size(16 * 10, 9 * 10);
            MainConfig.PanelTreeSize = panelTree.Size;
            MainConfig.PanelMainSize = panelMain.Size;
            MainConfig.ShowView = ShowView.SmallView;

            AllowDrop = true;
            KeyPreview = true;
            CenterToScreen();
            LoadTreeView();
            LoadUserControlByConfig();
            SetTsbBtnCheckedByConfig();
        }

        // 窗体大小变化时刷新 UserControl
        private void MainForm_Resize(object sender, EventArgs e)
        {
            LoadTreeView();
            RefreshUserControlByConfig();
        }

        // 图片显示模式按钮点击时根据按钮的Name来加载UserControl
        private void tsbBtn_Click(object sender, EventArgs e)
        {
            //string curTsbName = panelMain.Controls[0].Name;
            //MessageBox.Show(curTsbName);
            ToolStripButton btn = (ToolStripButton)sender;
            switch (btn.Name)
            {
                case "SmallView":
                    MainConfig.ShowView = ShowView.SmallView;
                    break;
                case "LargeView":
                    MainConfig.ShowView = ShowView.LargeView;
                    break;
                case "DetailView":
                    MainConfig.ShowView = ShowView.DetailView;
                    break;
                case "ListView":
                    MainConfig.ShowView = ShowView.ListView;
                    break;
            }
            LoadUserControlByConfig();
            SetTsbBtnCheckedByConfig();
        }

        // 图片大小按钮点击时切换图片大小
        private void tsbSize_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            int proportion = int.Parse(item.Name.Substring(item.Name.Length - 2, 2));
            MainConfig.ImageSize = new Size(16 * proportion, 9 * proportion);
            RefreshUserControlByConfig();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            MessageBox.Show(MainConfig.ShowFolderPath);
        }

        private void SetTsbBtnCheckedByConfig()
        {
            foreach (var item in toolStripMain.Items)
            {
                if (item is ToolStripButton)
                {
                    ToolStripButton btn = (ToolStripButton)item;
                    if (btn.Name == MainConfig.ShowView.ToString())
                        btn.Checked = true;
                    else
                        btn.Checked = false;
                }
                else
                    continue;
            }
        }

        public void RefreshUserControlByConfig()
        {
            MainConfig.PanelTreeSize = panelTree.Size;
            MainConfig.PanelMainSize = panelMain.Size;
            LoadUserControlByConfig();
        }

        public void LoadUserControlByConfig()
        {
            switch (MainConfig.ShowView)
            {
                case ShowView.SmallView:
                    panelMain.Controls.Clear();
                    SmallView smallView = new SmallView();
                    panelMain.Controls.Add(smallView);
                    break;
                case ShowView.LargeView:
                    panelMain.Controls.Clear();
                    LargeView largeView = new LargeView();
                    panelMain.Controls.Add(largeView);
                    break;
                case ShowView.DetailView:
                    panelMain.Controls.Clear();
                    DetailView detailView = new DetailView();
                    panelMain.Controls.Add(detailView);
                    break;
                case ShowView.ListView:
                    panelMain.Controls.Clear();
                    ListView listView = new ListView();
                    panelMain.Controls.Add(listView);
                    break;
                default:
                    break;
            }
        }

        // 初始化TreeView
        private void LoadTreeView()
        {
            panelTree.Controls.Clear();
            TreeView treeView = new TreeView();

            treeView.LoadUserControlEvent += new TreeView.LoadUserControl(RefreshUserControlByConfig);
            treeView.LoadImageEvent += new TreeView.LoadImage(LoadSingleView);

            panelTree.Controls.Add(treeView);
        }

        private void LoadSingleView()
        {
            panelMain.Controls.Clear();
            SingleView singleView = new SingleView();
            panelMain.Controls.Add(singleView);
            //panelMain.BackgroundImage = Image.FromFile(MainConfig.ShowImagePath);
            //panelMain.BackgroundImageLayout = ImageLayout.Zoom;
        }
       
    }
}
