﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureViewer
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(CollectionTool.json);
            //MessageBox.Show(CollectionTool.obj.ToString());
            //Collection item = new Collection();
            //CollectionTool.Add(item);
            CollectionTool.RemoveByPath("fwefwe");
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }
}
