using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace WinFormTest
{
    public partial class Form19 : Form
    {
        public Form19()
        {
            InitializeComponent();
        }

        private void Form19_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string folderPath = @"F:\Test2\又萌又性感 黑长直少女ELSA电眼迷人完美身材蜜桃般凹凸有致";
            string filePath= @"F:\Test2\1.jpg";

            FileSystem.DeleteFile(filePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);


            FileSystem.DeleteDirectory(folderPath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
        }
    }
}
