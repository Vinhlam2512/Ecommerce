using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Color
    {
        public Color()
        {
            Inventories = new HashSet<Inventory>();
        }

        public int ColorId { get; set; }
        public string ColorName { get; set; } = null!;

        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
