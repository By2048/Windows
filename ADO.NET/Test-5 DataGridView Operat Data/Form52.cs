using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_5_DataGridView_Operat_Data
{
    public partial class Form52 : Form
    {
        public Form52()
        {
            InitializeComponent();
        }
        IList<Book> books = new List<Book>();
        private void InitData()
        {            
            books.Add(new Book("book-1", "author-1", "publisher-1", 11));
            books.Add(new Book("book-2", "author-2", "publisher-2", 22));
            books.Add(new Book("book-3", "author-3", "publisher-3", 33));
            books.Add(new Book("book-4", "author-4", "publisher-4", 44));
            books.Add(new Book("book-5", "author-5", "publisher-5", 55));
            books.Add(new Book("book-6", "author-6", "publisher-6", 66));
        }
        private void Form52_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            InitData();
            this.dgvBooks.DataSource = books;   
        }
    }
}
