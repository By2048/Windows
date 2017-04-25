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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            MessageBox.Show(path);
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            AllowDrop = true;
        }

        private void Form6_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) 
            { 
                e.Effect = DragDropEffects.Link; 
            } 
            else 
            { 
                e.Effect = DragDropEffects.None; 
            }
        }
    }
}

