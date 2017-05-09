using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinFormTest
{
    public partial class UserControl4 : UserControl
    {
        public UserControl4(string folderPath, Size panelSize)
        {
            InitializeComponent();
            Size = panelSize;
            splitContainer1.SplitterDistance = Size.Width/10*7;
            splitContainer2.SplitterDistance = Size.Height/10*7;

            //panelListView.BackColor = Color.Red;
            //panelSmallImage.BackColor = Color.Green;
            //panelButton.BackColor = Color.Blue;

            CreateListView(folderPath, panelSize);
        }
        private ListView listView;
        private void CreateListView(string folderPath,Size panelSize)
        {
            string[] pictures = Directory.GetFiles(folderPath, "*jpg");

            listView = new ListView();
            listView.Dock = DockStyle.Fill;

            //listView1.LabelEdit = true;
            listView.View = View.Details;
            listView.AllowColumnReorder = true;
            listView.CheckBoxes = true;
            listView.FullRowSelect = true;
            listView.GridLines = true;

            // Width of -2 indicates auto-size.
            listView.Columns.Add("序号", -2, HorizontalAlignment.Left);
            listView.Columns.Add("文件名", 100, HorizontalAlignment.Left);
            listView.Columns.Add("分辨率", -2, HorizontalAlignment.Center);
            listView.Columns.Add("大小", -2, HorizontalAlignment.Center);
            listView.Columns.Add("文件路径", -2, HorizontalAlignment.Left);

            listView.Items.Clear();
            // Create three items and three sets of subitems for each item.

            for (int i = 0; i < pictures.Length; i++)
            {
                ListViewItem item = new ListViewItem((i+1).ToString());
                ImageListInfo imageInfo = GetImageInfo(Path.GetFullPath(pictures[i]));
                item.SubItems.Add(imageInfo.FileName);
                item.SubItems.Add(imageInfo.ImageSize.Width.ToString()+" x "+imageInfo.ImageSize.Height.ToString());
                item.SubItems.Add(imageInfo.FileSize.ToString());
                item.SubItems.Add(imageInfo.FillFullName);
                listView.Items.Add(item);
            }
            panelListView.Controls.Add(listView);
        }

        private ImageListInfo GetImageInfo(string imagePath)
        {
            Image image = Image.FromFile(imagePath);
            Size imageSize = image.Size;
            FileInfo fileInfo = new FileInfo(imagePath);
            string fileName = fileInfo.Name;
            string fillFullName = fileInfo.FullName;        // F:\Test\001.jpg
            double fileSize = fileInfo.Length / 1000.0;   // 72.121
            ImageListInfo imageInfo = new ImageListInfo(fileName,imageSize,fileSize,fillFullName);
            return imageInfo;
        }

        private void CreateSmallImage(string folderPath, Size panelSize)
        {
            //listViewImage.Size = panelSize;
            //listViewImage.View = View.Details;
            ////listView1.LabelEdit = true;
            //listViewImage.AllowColumnReorder = true;
            //listViewImage.CheckBoxes = true;
            //listViewImage.FullRowSelect = true;
            //listViewImage.GridLines = true;
        }

    }
}

public class ImageListInfo
{
    public Size ImageSize;    
    public string FileName;
    public double FileSize;
    public string FillFullName;
    public ImageListInfo(string fileName, Size imageSize, double fileSize, string fillFullName)
    {
        ImageSize = imageSize;
        FileName = fileName;
        FileSize = fileSize;
        FillFullName = fillFullName;
    }
}
