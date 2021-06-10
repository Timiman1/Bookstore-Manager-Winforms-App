using System;
using System.Collections.Generic;

#nullable disable

namespace TimToressonLabb3DBWF.Models
{
    public partial class VTitlesPerAuthor
    {
        public string Name { get; set; }
        public decimal? Age { get; set; }
        public int? Titles { get; set; }
        public decimal? InventoryValue { get; set; }
    }
}
