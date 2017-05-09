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
        private void Form11_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            CreateMyListView();
        }

        private ListView listView1;
        private void CreateMyListView()
        {
            listView1 = new ListView();
            listView1.Bounds = new Rectangle(new Point(10, 10), new Size(500, 400));

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
            //listView1.Sorting = SortOrder.Ascending;


            // Width of -2 indicates auto-size.
            listView1.Columns.Add("Column 1", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 2", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Column 3", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 4", -2, HorizontalAlignment.Center);

            listView1.Items.Clear();
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

            listView1.Items.AddRange(new ListViewItem[] { item1, item4, item3, item2 });


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

            listView1.ItemChecked += new ItemCheckedEventHandler(listView1_ItemChecked);

            // listview根据列名自动调整列宽
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            listView1.ListViewItemSorter = listViewItemSort;

            this.Controls.Add(listView1);
        }

        ListViewItemSort listViewItemSort=  new ListViewItemSort();
        private void ListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == listViewItemSort.SortColumnValue)
            {
                // 重新设置此列的排序方法.
                if (listViewItemSort.OrderValue == SortOrder.Ascending)
                {
                    listViewItemSort.OrderValue = SortOrder.Descending;
                }
                else
                {
                    listViewItemSort.OrderValue = SortOrder.Ascending;
                }
            }
            else
            {
                // 设置排序列，默认为正向排序
                listViewItemSort.SortColumnValue = e.Column;
                listViewItemSort.OrderValue = SortOrder.Ascending;
            }
            // 用新的排序方法对ListView排序
            this.listView1.Sort();
        }

        // checkbox的checked为true行变红，false时黑色
        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {

            ListViewItem MyItem = listView1.Items[e.Item.Index];

            foreach (ListViewItem item in this.listView1.Items)
            {
                if (MyItem.Checked)
                {
                    MyItem.ForeColor = Color.Red;
                }
                else
                {
                    MyItem.ForeColor = Color.Black;
                }
            }
        }


        //单击行读取行数据：
        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                MessageBox.Show(this.listView1.SelectedItems[0].SubItems[2].Text);
            }
        }

        //遍历删除listview中checkbox被选中的记录
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.listView1.CheckedItems)
            {
                MessageBox.Show(item.Index.ToString());
                this.listView1.Items.RemoveAt(item.Index);
            }
        }


        // 遍历listview，把上面的数据存到list<T>中
        private void button3_Click(object sender, EventArgs e)
        {
            List<TestInfo> m_CustomerServList = new List<TestInfo>();
            foreach (ListViewItem item in listView1.Items)
            {
                string A, B, C, D;
                A = item.SubItems[0].Text;
                B = item.SubItems[1].Text;
                C = item.SubItems[2].Text;
                D = item.SubItems[2].Text;
                m_CustomerServList.Add(new TestInfo(A, B, C, D));
                //m_CustomerServList.Add(new TestInfo()
                //{ A = item.SubItems[0].Text,
                //    B = item.SubItems[1].Text,
                //    C = item.SubItems[2].Text,
                //    D = item.SubItems[2].Text,
                //});
                MessageBox.Show(item.SubItems[0].Text + "\n" +
                    item.SubItems[1].Text + "\n" +
                    item.SubItems[2].Text + "\n" +
                    item.SubItems[3].Text);
            }
        }

    }



}

public class TestInfo
{
    public string A;
    public string B;
    public string C;
    public string D;
    public TestInfo(string a, string b, string c, string d)
    {
        A = a;
        B = b;
        C = c;
        D = d;
    }
}


public class ListViewItemSort : IComparer
{
    private int SortColumn;
    private SortOrder OrderOfSort;    // 排序方式.  

    public ListViewItemSort()
    {
        SortColumn = 0;
        OrderOfSort = SortOrder.None;
    }

    public ListViewItemSort(int column, SortOrder orderOfSort)
    {
        SortColumn = column;
        OrderOfSort = orderOfSort;
    }

    public int Compare(object x, object y)
    {
        int compareResult;
        int numX, numY;
        ListViewItem listviewX = (ListViewItem)x, listviewY = (ListViewItem)y;

        bool xIsNum = int.TryParse((listviewX).SubItems[SortColumn].Text, out numX);
        bool yIsNum = int.TryParse((listviewY).SubItems[SortColumn].Text, out numY);
        
        //MessageBox.Show(numX.ToString());
        //MessageBox.Show(numY.ToString());
        if (xIsNum && yIsNum)
            compareResult = numX - numY;
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
        set{SortColumn = value;}
        get{return SortColumn;}
    }
 
    public SortOrder OrderValue
    {
        set{OrderOfSort = value;}
        get{return OrderOfSort;}
    }

}