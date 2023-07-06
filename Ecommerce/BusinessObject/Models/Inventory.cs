using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public string Size { get; set; } = null!;
        public string Color { get; set; } = null!;
        public int Quantity { get; set; }

        public virtual Color ColorNavigation { get; set; } = null!;
        public virtual Size SizeNavigation { get; set; } = null!;
    }
}
