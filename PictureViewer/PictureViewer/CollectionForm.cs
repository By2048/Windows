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
            listView.ItemChecked += new ItemCheckedEventHandler(ListView_ItemChecked);

            panelListView.Controls.Add(listView);
        }

        private void ListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem checkItem = listView.Items[e.Item.Index];
            foreach (ListViewItem item in this.listView.Items)
            {
                if (checkItem.Checked)
                    checkItem.ForeColor = Color.Red;
                else
                    checkItem.ForeColor = Color.Black;
            }
        }


        private void CreateSmallView()
        {

        }

    }
}
