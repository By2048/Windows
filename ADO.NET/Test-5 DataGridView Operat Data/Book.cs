using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_5_DataGridView_Operat_Data
{
    class Book
    {
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }
        public Book(string bookName, string author, string publisher, decimal price)
        {
            this.BookName = bookName;
            this.Author = author;
            this.Publisher = publisher;
            this.Price = price;
        }
    }
}
