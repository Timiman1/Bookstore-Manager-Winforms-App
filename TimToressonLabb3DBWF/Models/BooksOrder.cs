using System;
using System.Collections.Generic;

#nullable disable

namespace TimToressonLabb3DBWF.Models
{
    public partial class BooksOrder
    {
        public long Isbn13 { get; set; }
        public int OrderId { get; set; }
        public int? Amount { get; set; }

        public virtual Book Isbn13Navigation { get; set; }
        public virtual Order Order { get; set; }
    }
}
