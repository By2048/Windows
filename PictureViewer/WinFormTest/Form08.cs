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
    public partial class Form08 : Form
    {
        public Form08()
        {
            InitializeComponent();
            InitTreeView();
            string[] drives = System.Environment.GetLogicalDrives();
            foreach(string i in drives)
                MessageBox.Show(i.ToString());
        }


        private void InitTreeView()
        {
            DirectoryInfo dir = new DirectoryInfo(@"F:\test");

            foreach (DirectoryInfo dChild in dir.GetDirectories("*"))
            {
                treeView1.Nodes.Add(dChild.Name.ToString());
            }
            foreach (FileInfo dChild in dir.GetFiles("*"))
            {
                treeView1.Nodes.Add(dChild.Name.ToString());
            }
        }
        public void FindFile(string dirPath) //参数dirPath为指定的目录
        {

            //在指定目录及子目录下查找文件,在listBox1中列出子目录及文件

            DirectoryInfo Dir = new DirectoryInfo(dirPath);
            try
            {
                foreach (DirectoryInfo d in Dir.GetDirectories())//查找子目录
                {
                    FindFile(Dir + d.ToString() + @"\");
                    listBox1.Items.Add(Dir + d.ToString() + @"\"); //listBox1中填加目录名
                }
                foreach (FileInfo f in Dir.GetFiles("*.jpg")) //查找文件
                {
                    listBox1.Items.Add(Dir + f.ToString()); //listBox1中填加文件名
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }
    }
}
