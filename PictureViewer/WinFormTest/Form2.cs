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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            //this.AutoScrollMinSize = new Size(1980,1080);
            //this.AutoScrollMargin = new Size(5,5);
            //this.AutoScroll = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
             this.ClientSize = new System.Drawing.Size(500, 500);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Size = new System.Drawing.Size(700, 700);
            this.pictureBox1.BackColor = Color.Red;
        }
    }
}
