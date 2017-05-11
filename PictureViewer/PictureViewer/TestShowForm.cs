using System;
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
    public partial class TestShowForm : Form
    {
        public TestShowForm()
        {
            InitializeComponent();
        }
        public List<Image> images=new List<Image>();
        private void MainForm_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
                               
            //images.Add(new Image("1", "..\\..\\Images\\1.jpg"));
            //images.Add(new Image("2", "..\\..\\Images\\2.jpg"));
            //images.Add(new Image("3", "..\\..\\Images\\3.jpg"));
            //images.Add(new Image("4", "..\\..\\Images\\4.jpg"));
            //images.Add(new Image("5", "..\\..\\Images\\5.jpg"));
            //images.Add(new Image("6", "..\\..\\Images\\6.jpg"));
            //images.Add(new Image("7", "..\\..\\Images\\7.jpg"));

            StartPosition = FormStartPosition.Manual;
            Location = new Point(700, 700);
            for (int i = 0; i < 7; i++)
            {               
                //ShowImage newForm = new ShowImage();
                //newForm.SetImage(images[i].Path);
                //newForm.StartPosition = FormStartPosition.Manual;
                //newForm.Location = new Point(100 + i * 10, 100 + i * 10);
                //newForm.Text = i.ToString();
                //newForm.Show();
            }

        }
    }
}
