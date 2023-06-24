using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Color
    {
        public Color()
        {
            Carts = new HashSet<Cart>();
            Inventories = new HashSet<Inventory>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ColorId { get; set; }
        public string ColorName { get; set; } = null!;

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
