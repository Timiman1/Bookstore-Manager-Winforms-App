using System;
using System.Collections.Generic;

#nullable disable

namespace TimToressonLabb3DBWF.Models
{
    public partial class Bookstore
    {
        public Bookstore()
        {
            StockBalances = new HashSet<StockBalances>();
        }

        public int Id { get; set; }
        public string BookstoreName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<StockBalances> StockBalances { get; set; }
    }
}
