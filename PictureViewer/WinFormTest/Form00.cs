﻿using System;
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
    public partial class Form00 : Form
    {
        public Form00()
        {
            InitializeComponent();
        }

        private void Form00_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            panel1.BackgroundImage = Image.FromFile(@"F:\Test\001.jpg");
            panel1.BackgroundImageLayout = ImageLayout.Zoom;
        }
    }
}
