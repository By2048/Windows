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
    public partial class Form06 : Form
    {
        public Form06()
        {
            InitializeComponent();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            AllowDrop = true;
        }

        //DragDrop：拖放操作完成时发生。
        //DragEnter：在将对象拖入控件的边界时发生。
        //DragLeave：在将对象拖出控件的边界时发生。
        //DragOver：在将对象拖到控件的边界上发生。
        private void Form6_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string item in files)
                {
                    if (File.Exists(item))
                    {
                        MessageBox.Show(item);
                        MessageBox.Show("文件");
                    }
                    else if (Directory.Exists(item))
                    {
                        MessageBox.Show(item);
                        MessageBox.Show("文件夹");
                    }
                }
            }
        }


        private void Form6_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
        }
    }
}

