using System;
using System.Collections.Generic;

#nullable disable

namespace TimToressonLabb3DBWF.Models
{
    public partial class Order
    {
        public Order()
        {
            BooksOrders = new HashSet<BooksOrder>();
        }

        public int Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<BooksOrder> BooksOrders { get; set; }
    }
}
