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

namespace AM.Windows.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            //DirectoryInfo  path = new DirectoryInfo(@"F:\Test");
            //InitTreeView(path);
            InitTreeView();
            panelImage.BackColor = Color.Red;
        }
        private void InitTreeView()
        {
            string[] drives = Environment.GetLogicalDrives();
            foreach (string drive in drives)
            {
                if (drive == @"C:\")
                    continue;
                DriveInfo driInfo = new DriveInfo(drive);
                if (!driInfo.IsReady)
                    continue;
                //DirectoryInfo rootDir = driInfo.RootDirectory;
                DirectoryInfo rootDir = new DirectoryInfo(@"F:\Test");
                treeViewImage.Nodes.Add(rootDir.Name);
                WalkFileTree(rootDir);
            }

            //foreach (FileInfo info in path.GetFiles("*.*"))
            //{
            //    //if (info.Name.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
            //    //    info.Name.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
            //    //    info.Name.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
            //    //    info.Name.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
            //    //{
            //        treeViewImage.Nodes.Add(info.Name);
            //    //}
            //}            
        }

        private void WalkFileTree(DirectoryInfo root)
        {
            StringCollection log = new StringCollection();
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;
            try
            {
                files = root.GetFiles("*.*");
            }
            catch (UnauthorizedAccessException e)
            {
                log.Add(e.Message);
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                log.Add(e.Message);
            }
            if (files != null)
            {
                foreach (FileInfo file in files)
                {
                    if (file.Name.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                        file.Name.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                        file.Name.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
                        file.Name.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
                    {
                        treeViewImage.Nodes.Add(file.Name);
                    }
                }
                subDirs = root.GetDirectories();
                foreach (DirectoryInfo dir in subDirs)
                {
                    treeViewImage.Nodes.Add(dir.Name);
                    WalkFileTree(dir);
                }
            }
        }
    }
}
