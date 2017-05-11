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
        //string folderPath = @"F:\Test\媚眼柔嫩娇滴滴 爆乳萌妹子猫儿蜜糖化身性感女仆被调教";
        string folderPath = @"D:\Test";
        Size imageSize = new Size(16 * 10, 9 * 10);

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            panelMain.Controls.Clear();
            ImgSmallView userControl = new ImgSmallView(folderPath, panelMain.Size, imageSize);
            panelMain.Controls.Add(userControl);
            panelTree.BackColor = Color.Red;
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

        private void tsbBtn_Click(object sender, EventArgs e)
        {
            ToolStripButton btn=(ToolStripButton) sender;
            switch (btn.Name)
            { 
                case "tsbSmallView":
                    panelMain.Controls.Clear();
                    ImgSmallView smallView = new ImgSmallView(folderPath, panelMain.Size, imageSize);
                    panelMain.Controls.Add(smallView);  
                    break;
                case "tsbLargeView":
                    panelMain.Controls.Clear();
                    ImgLargeView largeView = new ImgLargeView(folderPath, panelMain.Size);
                    panelMain.Controls.Add(largeView);
                    break;
                case "tsbDetailView":
                    panelMain.Controls.Clear();
                    ImgDetailView detailView = new ImgDetailView(folderPath, panelMain.Size, imageSize);
                    panelMain.Controls.Add(detailView);
                    break;
                case "tsbListView":
                    panelMain.Controls.Clear();
                    ImgListView listView = new ImgListView(folderPath, panelMain.Size);
                    panelMain.Controls.Add(listView);
                    break;
                default:
                    break;
            }
            SetTsbBtnChecked(btn.Name);
        }      

        private void tsbSize_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item=(ToolStripMenuItem) sender;
            int proportion=int.Parse(item.Name.Substring(item.Name.Length-2,2));
            imageSize = new Size(16 * proportion, 9 * proportion);           
        }


    }
}
