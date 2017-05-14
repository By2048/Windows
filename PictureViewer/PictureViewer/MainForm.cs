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


        string folderPath = @"F:\Test\媚眼柔嫩娇滴滴 爆乳萌妹子猫儿蜜糖化身性感女仆被调教";
        Size imageSize = new Size(16 * 10, 9 * 10);
        public MainForm()
        {
            InitializeComponent();
            Resize += new EventHandler(MainForm_Resize);
            splitContainer.SplitterDistance = Size.Width / 4;
            CheckForIllegalCrossThreadCalls = false;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            string name = panelMain.Controls[0].Name;
            LoadUserControl(name);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MainConfig.ShowFolderPath = @"F:\Test\媚眼柔嫩娇滴滴 爆乳萌妹子猫儿蜜糖化身性感女仆被调教";
            MainConfig.StartTreePath = @"F:\Test";

            KeyPreview = true;
            CenterToScreen();
            LoadTreeView();
            SmallView userControl = new SmallView(panelMain.Size, imageSize);            
            SetTsbBtnChecked("SmallView");
            panelMain.Controls.Add(userControl);
        }


        private void tsbBtn_Click(object sender, EventArgs e)
        {
            //string curTsbName = panelMain.Controls[0].Name;
            //MessageBox.Show(curTsbName);
            ToolStripButton btn = (ToolStripButton)sender;
            LoadUserControl(btn.Name);
            SetTsbBtnChecked(btn.Name);
        }

        private void tsbSize_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            int proportion = int.Parse(item.Name.Substring(item.Name.Length - 2, 2));
            imageSize = new Size(16 * proportion, 9 * proportion);
        }

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

        public void RefreshUserControl()
        {
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

        public void LoadUserControl(string name)
        {
            switch (name)
            {
                case "SmallView":
                    panelMain.Controls.Clear();
                    SmallView smallView = new SmallView(panelMain.Size, imageSize);
                    panelMain.Controls.Add(smallView);
                    break;
                case "LargeView":
                    panelMain.Controls.Clear();
                    LargeView largeView = new LargeView(folderPath, panelMain.Size);
                    panelMain.Controls.Add(largeView);
                    break;
                case "DetailView":
                    panelMain.Controls.Clear();
                    DetailView detailView = new DetailView(folderPath, panelMain.Size, imageSize);
                    panelMain.Controls.Add(detailView);
                    break;
                case "ListView":
                    panelMain.Controls.Clear();
                    ListView listView = new ListView(folderPath, panelMain.Size);
                    panelMain.Controls.Add(listView);
                    break;
                default:
                    break;
            }
        }

        private void LoadTreeView()
        {
            panelTree.Controls.Clear();
            TreeView treeView = new TreeView(panelTree.Size);
            treeView.LoadImagesEvent += new TreeView.LoadImages(RefreshUserControl);
            panelTree.Controls.Add(treeView);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            MessageBox.Show(MainConfig.ShowFolderPath);
        }
    }
}
