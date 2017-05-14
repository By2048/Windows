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
            MainConfig.ShowFolderPath = @"F:\Test\媚眼柔嫩娇滴滴 爆乳萌妹子猫儿蜜糖化身性感女仆被调教";
            MainConfig.ImageSize=new Size(16 * 10, 9 * 10);
            MainConfig.PanelMainSize = panelMain.Size;

            KeyPreview = true;
            CenterToScreen();
            LoadTreeView();
            SmallView userControl = new SmallView();            
            SetTsbBtnChecked("SmallView");
            panelMain.Controls.Add(userControl);

            //panelMain.BackColor = Color.Red;
            //panelTree.BackColor = Color.Green;
        }

        // 窗体大小变化是刷新UserControl
        private void MainForm_Resize(object sender, EventArgs e)
        {
            LoadTreeView();
            RefreshUserControl();
        }


        // 图片显示模式按钮点击时根据按钮的Name来加载UserControl
        private void tsbBtn_Click(object sender, EventArgs e)
        {
            //string curTsbName = panelMain.Controls[0].Name;
            //MessageBox.Show(curTsbName);
            ToolStripButton btn = (ToolStripButton)sender;
            LoadUserControl(btn.Name);
            SetTsbBtnChecked(btn.Name);
        }

        // 图片大小按钮点击时切换图片大小
        private void tsbSize_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            int proportion = int.Parse(item.Name.Substring(item.Name.Length - 2, 2));
            MainConfig.ImageSize = new Size(16 * proportion, 9 * proportion);
            RefreshUserControl();
        }

        // 按钮点击时设置按钮状态
        private void SetTsbBtnChecked(string btnName)
        {
            foreach (var item in toolStripMain.Items)
            {
                if (item is ToolStripButton)
                {
                    ToolStripButton btn = (ToolStripButton)item;
                    if (btn.Name == btnName)
                        btn.Checked = true;
                    else
                        btn.Checked = false;
                }
                else
                {
                    return;
                }
            }
        }

        // 刷新图片展示窗体的UserControl
        public void RefreshUserControl()
        {
            MainConfig.PanelMainSize = panelMain.Size;
            ToolStripButton curBtn=null;
            foreach (var item in toolStripMain.Items)
            {
                if (item is ToolStripButton)
                {
                    curBtn = (ToolStripButton)item;
                    if (curBtn.Checked == true)
                        break;
                }
            }
            LoadUserControl(curBtn.Name);
        }

        /// <summary>
        /// 加载图片需要展示的模式的UserControl
        /// </summary>
        /// <param name="name">UserControl的Name</param>
        public void LoadUserControl(string name)
        {
            switch (name)
            {
                case "SmallView":
                    panelMain.Controls.Clear();
                    SmallView smallView = new SmallView();
                    panelMain.Controls.Add(smallView);
                    break;
                case "LargeView":
                    panelMain.Controls.Clear();
                    LargeView largeView = new LargeView();
                    panelMain.Controls.Add(largeView);
                    break;
                case "DetailView":
                    panelMain.Controls.Clear();
                    DetailView detailView = new DetailView();
                    panelMain.Controls.Add(detailView);
                    break;
                case "ListView":
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
            TreeView treeView = new TreeView(panelTree.Size);

            treeView.LoadUserControlEvent += new TreeView.LoadUserControl(RefreshUserControl);
            treeView.LoadImageEvent += new TreeView.LoadImage(LoadImage);

            panelTree.Controls.Add(treeView);
        }

        private void LoadImage()
        {
            panelMain.Controls.Clear();
            SingleView singleView = new SingleView();
            panelMain.Controls.Add(singleView);
            //panelMain.BackgroundImage = Image.FromFile(MainConfig.ShowImagePath);
            //panelMain.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            MessageBox.Show(MainConfig.ShowFolderPath);
        }
    }
}
