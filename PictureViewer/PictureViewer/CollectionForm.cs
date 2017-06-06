using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PictureViewer
{
    public partial class CollectionForm : Form
    {
        private System.Windows.Forms.ListView listView;
        private List<CollectionDetail> allCollection;

        public CollectionForm()
        {
            InitializeComponent();
            CreateListView();
        }

        private void CollectionForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            MaximizeBox = false;
        }
        private void CreateListView()
        {
            listView = new System.Windows.Forms.ListView();
            listView.Bounds = new Rectangle(new Point(0, 0), panelListView.Size);


            // Set the view to show details.
            listView.View = View.Details;
            // Allow the user to edit item text.
            listView.LabelEdit = true;
            // Allow the user to rearrange columns.
            listView.AllowColumnReorder = true;
            // Display check boxes.
            listView.CheckBoxes = true;
            // Select the item and subitems when selection is made.
            listView.FullRowSelect = true;
            // Display grid lines.
            listView.GridLines = true;
            // Sort the items in the list in ascending order.
            //listView1.Sorting = SortOrder.Ascending;

            // Width of -2 indicates auto-size.
            listView.Columns.Add("Index", -2, HorizontalAlignment.Center);
            listView.Columns.Add("Id", -2, HorizontalAlignment.Center);
            listView.Columns.Add("Date", -2, HorizontalAlignment.Center);
            listView.Columns.Add("     Path", 100, HorizontalAlignment.Left);
            listView.Columns.Add("Type", -2, HorizontalAlignment.Center);

            listView.Items.Clear();

            allCollection = CollectionTool.GetAllCollection();

            int index = 1;
            foreach (CollectionDetail coll in allCollection)
            {
                ListViewItem item = new ListViewItem(index.ToString());
                item.SubItems.Add(coll.Id);
                item.SubItems.Add(coll.Date);
                item.SubItems.Add(coll.Path);
                item.SubItems.Add(coll.Type);
                listView.Items.Add(item);
                index++;
            }
            listView.ItemChecked += new ItemCheckedEventHandler(listView_ItemChecked);

            listView.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(listView_ItemSelectionChanged);

            listView.MouseDown += new MouseEventHandler(this.listView_MouseDown);

            panelListView.Controls.Add(listView);
        }

        private void listView_MouseDown(object sender, MouseEventArgs e)
        {
            listView.ContextMenuStrip = CreateContextMenuStrip();
        }

        private void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            panelShowView.Controls.Clear();
            if (listView.SelectedItems.Count > 0)
            {
                string path = listView.SelectedItems[0].SubItems[3].Text;
                if (Directory.Exists(path)) // 文件夹
                    CreateSmallView(path);
                else if (File.Exists(path)) // 文件
                    CreateSingleView(path);
            }
        }

        private void listView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem checkItem = listView.Items[e.Item.Index];
            foreach (ListViewItem item in listView.Items)
            {
                if (checkItem.Checked)
                    checkItem.ForeColor = Color.Red;
                else
                    checkItem.ForeColor = Color.Black;
            }
        }

        private void CreateSmallView(string path)
        {
            Size panelSize = panelShowView.Size;
            Size imageSize= new Size(16 * 10, 9 * 10);
            SmallView smallView = new SmallView(path, panelSize, imageSize);
            panelShowView.Controls.Add(smallView);

        }
        private void CreateSingleView(string path)
        {
            Size panelSize = panelShowView.Size;
            SingleView singleView = new SingleView(path,panelSize);
            panelShowView.Controls.Add(singleView);
        }

        public ContextMenuStrip CreateContextMenuStrip()
        {
            ContextMenuStrip contextMenuStrip;
            ToolStripMenuItem delete;

            contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Name = "contextMenuStrip";

            delete = new ToolStripMenuItem();
            delete.Name = "Delete";
            delete.Text = "删除";
            delete.Click += new EventHandler(Delete_click);       

            contextMenuStrip.Items.AddRange(
                new ToolStripItem[] {
                delete,
            });
            return contextMenuStrip;
        }

        private void Delete_click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView.CheckedItems)
            {
                string path = item.SubItems[3].Text;
                CollectionTool.RemoveByPath(path);
                listView.Items.RemoveAt(item.Index);
            }
        }
    }
}
