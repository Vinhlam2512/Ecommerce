using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ProductName { get; set; } = null!;
        public string Size { get; set; } = null!;
        public string Color { get; set; } = null!;
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }

        public virtual Color ColorNavigation { get; set; } = null!;
        public virtual Size SizeNavigation { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
