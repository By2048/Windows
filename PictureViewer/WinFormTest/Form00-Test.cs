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
    public partial class Form00 : Form
    {
        public Form00()
        {
            InitializeComponent();
        }

        private void Form00_Load(object sender, EventArgs e)
        {
            string path = @"F:\Test\16b25.jpg";
            MessageBox.Show(Path.GetDirectoryName(path));
            pictureBox1.BackColor = Color.Red;
            CreateContextMenuStrip();
        }

        private ContextMenuStrip picBoxContextMenuStrip;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip = picBoxContextMenuStrip;
            }
        }
        private void CreateContextMenuStrip()
        {
            ToolStripMenuItem Del;
            ToolStripMenuItem Add;

            picBoxContextMenuStrip = new ContextMenuStrip();
            picBoxContextMenuStrip.Name = "picBoxContextMenuStrip";

            Del = new ToolStripMenuItem();
            Del.Name = "Del";
            Del.Text = "删除";
            Del.Click += new EventHandler(Del_click);


            Add = new ToolStripMenuItem();
            Add.Name = "Add";
            Add.Text = "添加收藏";
            Add.Click += new EventHandler(Add_click);

            picBoxContextMenuStrip.Items.AddRange(
                new ToolStripItem[] {
                Del,
                Add,
            });          
        }

        private void Del_click(object sender, EventArgs e)
        {
            MessageBox.Show("Del");
        }
        private void Add_click(object sender, EventArgs e)
        {
            MessageBox.Show("Add");
        }
      
    }
}
