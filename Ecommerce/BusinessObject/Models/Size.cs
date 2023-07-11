using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Size
    {
        public Size()
        {
            Inventories = new HashSet<Inventory>();
        }

        public int SizeId { get; set; }
        public string SizeName { get; set; } = null!;

        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
