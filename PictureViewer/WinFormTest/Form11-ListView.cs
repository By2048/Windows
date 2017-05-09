using System;
using System.Collections;
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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        private ListView listView1;
        private void CreateMyListView()
        {
            listView1 = new ListView();
            listView1.Bounds = new Rectangle(new Point(10, 10), new Size(300, 200));

            // Set the view to show details.
            listView1.View = View.Details;
            // Allow the user to edit item text.
            listView1.LabelEdit = true;
            // Allow the user to rearrange columns.
            listView1.AllowColumnReorder = true;
            // Display check boxes.
            listView1.CheckBoxes = true;
            // Select the item and subitems when selection is made.
            listView1.FullRowSelect = true;
            // Display grid lines.
            listView1.GridLines = true;
            // Sort the items in the list in ascending order.
            listView1.Sorting = SortOrder.Ascending;

            // Create three items and three sets of subitems for each item.
            ListViewItem item1 = new ListViewItem("item1", 0);
            item1.Checked = true;
            item1.SubItems.Add("1");
            item1.SubItems.Add("2");
            item1.SubItems.Add("3");
            ListViewItem item2 = new ListViewItem("item2", 1);
            item2.SubItems.Add("4");
            item2.SubItems.Add("5");
            item2.SubItems.Add("6");
            ListViewItem item3 = new ListViewItem("item3", 0);
            item3.Checked = true;
            item3.SubItems.Add("7");
            item3.SubItems.Add("8");
            item3.SubItems.Add("9");
            ListViewItem item4 = new ListViewItem("item4", 0);
            item4.Checked = true;
            item4.SubItems.Add("10");
            item4.SubItems.Add("11");
            item4.SubItems.Add("12");

            // Width of -2 indicates auto-size.
            listView1.Columns.Add("Item Column", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 2", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 3", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 4", -2, HorizontalAlignment.Center);

            listView1.Items.AddRange(new ListViewItem[] { item1, item4, item3 ,item2});

            // Create two ImageList objects.
            ImageList imageListSmall = new ImageList();
            ImageList imageListLarge = new ImageList();

            // Initialize the ImageList objects with bitmaps.
            imageListSmall.Images.Add(Bitmap.FromFile("F:\\Test\\001.jpg"));
            imageListSmall.Images.Add(Bitmap.FromFile("F:\\Test\\002.jpg"));
            imageListLarge.Images.Add(Bitmap.FromFile("F:\\Test\\003.jpg"));
            imageListLarge.Images.Add(Bitmap.FromFile("F:\\Test\\004.jpg"));

            //Assign the ImageList objects to the ListView.
            listView1.LargeImageList = imageListLarge;
            listView1.SmallImageList = imageListSmall;

            listView1.ColumnClick += new ColumnClickEventHandler(ListView_ColumnClick);

            this.Controls.Add(listView1);
        }

        private void ListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            MessageBox.Show(e.Column.ToString());
            listView1.ListViewItemSorter = new ListViewItemComparer(e.Column);
            //listView1.Sort();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            CreateMyListView();
        }
    }
    


}


public class ListViewItemComparer : IComparer
{
    private int column;

    public ListViewItemComparer(int column)
    {
        this.column = column;
    }

    public int Compare(object x, object y)
    {
        int numX, numY;
        bool xIsNum = int.TryParse(((ListViewItem)x).SubItems[column].Text, out numX);
        bool yIsNum = int.TryParse(((ListViewItem)x).SubItems[column].Text, out numY);
        if (xIsNum && yIsNum)
            return numX - numY;
        else
            return String.Compare(((ListViewItem)x).SubItems[column].Text,
                ((ListViewItem)y).SubItems[column].Text);
    }

}