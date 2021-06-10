using System;
using System.Collections.Generic;

#nullable disable

namespace TimToressonLabb3DBWF.Models
{
    public partial class StockBalances
    {
        public int BookstoreId { get; set; }
        public long Isbn13 { get; set; }
        public int? Amount { get; set; }

        public virtual Bookstore Bookstore { get; set; }
        public virtual Book Isbn13Navigation { get; set; }
    }
}
