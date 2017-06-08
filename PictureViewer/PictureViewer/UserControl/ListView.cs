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
using System.Collections;

namespace PictureViewer
{
    public partial class ListView : UserControl
    {
        private System.Windows.Forms.ListView listView;
        private ContextMenuStrip picBoxContextMenuStrip;

        public ListView()
        {
            InitializeComponent();
            Size = MainConfig.PanelMainSize;
            splitContainer1.SplitterDistance = Size.Width / 10 * 7;
            splitContainer2.SplitterDistance = Size.Height / 10 * 3;

            pictureBoxLarge.SizeMode = PictureBoxSizeMode.Zoom;
            //panelListView.BackColor = Color.Red;
            //panelLargeImage.BackColor = Color.Green;
            //panelSmallImages.BackColor = Color.Blue;
            panelSmallImage.AutoScroll = true;
            CreateListView();

            CreateContextMenuStrip();

        }

        private void CreateListView()
        {

            string[] pictures = ImageTool.GetAllImagePath(MainConfig.ShowFolderPath);

            listView = new System.Windows.Forms.ListView();
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
                ListViewItem item = new ListViewItem((i + 1).ToString());
                ImageListInfo imageInfo = GetImageInfo(Path.GetFullPath(pictures[i]));
                item.SubItems.Add(imageInfo.FileName);
                item.SubItems.Add(imageInfo.ImageSize.Width.ToString() + " x " + imageInfo.ImageSize.Height.ToString());
                item.SubItems.Add(imageInfo.FileSize.ToString());
                item.SubItems.Add(imageInfo.FillFullName);
                listView.Items.Add(item);
            }

            listView.ColumnClick += new ColumnClickEventHandler(ListView_ColumnClick);
            listView.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(listView_ItemSelectionChanged);
            listView.ItemChecked += new ItemCheckedEventHandler(listView_ItemChecked);

            panelListView.Controls.Add(listView);

            // listview根据列名自动调整列宽
            //listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            listView.ListViewItemSorter = imageListViewSort;
        }

        private void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                string imagePath = listView.SelectedItems[0].SubItems[4].Text;


                FileStream fs = new FileStream(imagePath, FileMode.Open);
                Bitmap bm = new Bitmap(fs);
                fs.Dispose();
                pictureBoxLarge.Image = bm;

                CreateSmallImages();
            }

        }

        private void listView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            foreach (ListViewItem item in listView.Items)
            {
                if (item.Checked)
                {
                    item.ForeColor = Color.Red;
                }
                else
                {
                    item.ForeColor = Color.Black;
                }
            }
            CreateSmallImages();
        }

        private void ListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == imageListViewSort.SortColumnValue)
            {
                // 重新设置此列的排序方法.
                if (imageListViewSort.OrderValue == SortOrder.Ascending)
                    imageListViewSort.OrderValue = SortOrder.Descending;
                else
                    imageListViewSort.OrderValue = SortOrder.Ascending;
            }
            else
            {
                // 设置排序列，默认为正向排序
                imageListViewSort.SortColumnValue = e.Column;
                imageListViewSort.OrderValue = SortOrder.Ascending;
            }
            // 用新的排序方法对ListView排序
            this.listView.Sort();

        }

        ImageListViewSort imageListViewSort = new ImageListViewSort();

        private ImageListInfo GetImageInfo(string imagePath)
        {
            Image image = Image.FromFile(imagePath);
            Size imageSize = image.Size;
            FileInfo fileInfo = new FileInfo(imagePath);
            string fileName = fileInfo.Name;
            string fillFullName = fileInfo.FullName;        // F:\Test\001.jpg
            double fileSize = fileInfo.Length / 1000.0;   // 72.121
            ImageListInfo imageInfo = new ImageListInfo(fileName, imageSize, fileSize, fillFullName);
            image.Dispose();
            return imageInfo;
        }

        private void CreateSmallImages()
        {
            panelSmallImage.Controls.Clear();
            Size panelSize = panelSmallImage.Size;
            List<string> imagePath = new List<string>();
            foreach (ListViewItem item in listView.CheckedItems)
            {
                string path = listView.Items[item.Index].SubItems[4].Text;
                imagePath.Add(path);
            }
            if (imagePath.Count == 0)
                return;

            // 遍历删除 control
            //foreach (Control control in panelSmallImages.Controls)
            //{
            //    PictureBox picBox = (PictureBox)control;
            //    string path = Path.GetFullPath(picBox.ImageLocation);
            //    if (imagePath.Contains(path))
            //        return;
            //    else
            //        panelSmallImages.Controls.Remove(control);
            //}

            int columnCount = 3;
            int rowCount = (imagePath.Count % columnCount == 0) ?
                imagePath.Count / columnCount :
                (imagePath.Count / columnCount) + 1;

            int padding = 2;
            int pictureWidth = panelSize.Width / columnCount - 2 * padding;
            int pictureHeight = pictureWidth * 9 / 16;

            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    int index = row * columnCount + column; // 图片下标
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Width = pictureWidth;
                    pictureBox.Height = pictureHeight;
                    if (index >= imagePath.Count) { return; }

                    //FileStream fs = new FileStream(imagePath[index], FileMode.Open);
                    //Bitmap bm = new Bitmap(fs);
                    //fs.Dispose();
                    //pictureBox.Image = bm;

                    pictureBox.Image = ImageTool.LoadImage(imagePath[index]);
                    pictureBox.Tag = imagePath[index];

                    //pictureBox.Load(imagePath[pictureIndex]);
                    //pictureBox.Image=Image.FromFile(imagePath[pictureIndex]);
                    Point pictureLoction = new Point();
                    pictureLoction.X = padding * (column + 1) + pictureWidth * column;
                    pictureLoction.Y = padding * (row + 1) + pictureHeight * row;
                    pictureBox.Location = pictureLoction;
                    pictureBox.DoubleClick += pictureBox_DoubleClick;
                    panelSmallImage.Controls.Add(pictureBox);
                }
            }
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            string filePath = pictureBox.Tag.ToString();
            //Image image = pictureBox.Image;
            ShowForm newForm = new ShowForm();
            newForm.imgPath = filePath;
            //newForm.SetPictureBoxByImage(image);
            newForm.Show();
        }

        private void CreateContextMenuStrip()
        {
            picBoxContextMenuStrip = new ContextMenuStrip();
            picBoxContextMenuStrip.Name = "picBoxContextMenuStrip";
            ToolStripMenuItem DeleteItem = new ToolStripMenuItem();
            ToolStripMenuItem CollectionItem = new ToolStripMenuItem();
            picBoxContextMenuStrip.Items.AddRange(new ToolStripItem[] { DeleteItem, CollectionItem });

            DeleteItem.Name = "DeleteItem";
            DeleteItem.Text = "删除";
            DeleteItem.Click += new EventHandler(DeleteItem_Clicked);

            CollectionItem.Name = "CollectionItem";
            CollectionItem.Text = "收藏";
            panelSmallImage.ContextMenuStrip = picBoxContextMenuStrip;
        }

        private void DeleteItem_Clicked(object sender, EventArgs e)
        {
            panelSmallImage.Controls.Clear();
            foreach (ListViewItem item in listView.CheckedItems)
            {
                string path = listView.Items[item.Index].SubItems[4].Text;
                File.Delete(path);
                listView.Items.RemoveAt(item.Index);
            }          
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


public class ImageListViewSort : IComparer
{
    private int SortColumn;
    private SortOrder OrderOfSort;    // 排序方式.  

    public ImageListViewSort()
    {
        SortColumn = 0;
        OrderOfSort = SortOrder.None;
    }

    public ImageListViewSort(int column, SortOrder orderOfSort)
    {
        SortColumn = column;
        OrderOfSort = orderOfSort;
    }

    public int Compare(object x, object y)
    {
        int compareResult;
        int intX, intY;
        double doubleX, doubleY;

        ListViewItem listviewX = (ListViewItem)x, listviewY = (ListViewItem)y;

        bool xIsInt = int.TryParse((listviewX).SubItems[SortColumn].Text, out intX);
        bool yIsInt = int.TryParse((listviewY).SubItems[SortColumn].Text, out intY);

        bool xIsDouble = double.TryParse((listviewX).SubItems[SortColumn].Text, out doubleX);
        bool yIsDouble = double.TryParse((listviewY).SubItems[SortColumn].Text, out doubleY);


        if (xIsInt && yIsInt)
            compareResult = intX - intY;
        else if (xIsDouble && yIsDouble)
            compareResult = (doubleX - doubleY) > 0 ? 1 : -1;
        else
            compareResult = String.Compare((listviewX).SubItems[SortColumn].Text, (listviewY).SubItems[SortColumn].Text);

        if (OrderOfSort == SortOrder.Ascending)
            return compareResult;
        else if (OrderOfSort == SortOrder.Descending)
            return (-compareResult);
        else
            return 0;
    }

    public int SortColumnValue
    {
        set { SortColumn = value; }
        get { return SortColumn; }
    }

    public SortOrder OrderValue
    {
        set { OrderOfSort = value; }
        get { return OrderOfSort; }
    }

}


