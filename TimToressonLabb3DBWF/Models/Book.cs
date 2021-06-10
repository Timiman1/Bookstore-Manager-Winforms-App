using System;
using System.Collections.Generic;

#nullable disable

namespace TimToressonLabb3DBWF.Models
{
    public partial class Book
    {
        public Book()
        {
            BooksOrders = new HashSet<BooksOrder>();
            StockBalances = new HashSet<StockBalances>();
        }

        public long Isbn13 { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public decimal Price { get; set; }
        public DateTime PublicationDate { get; set; }
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public virtual ICollection<BooksOrder> BooksOrders { get; set; }
        public virtual ICollection<StockBalances> StockBalances { get; set; }
    }
}
