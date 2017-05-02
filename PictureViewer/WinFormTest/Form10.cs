using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormTest
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            CenterToScreen();

            //for (int i = 0; i < imageList1.Images.Count; i++)
            //{
            //    MessageBox.Show(imageList1.Images[i].ToString());
            //}

            listView1.View = View.LargeIcon;
            listView1.LargeImageList = imageList1;
            imageList1.ColorDepth = ColorDepth.Depth32Bit;

            listView1.BeginUpdate();
            for (int i = 0; i < imageList1.Images.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = i;
                item.Text = "pic" + i;
                listView1.Items.Add(item);
            }
            listView1.EndUpdate();
        }
    }
}
