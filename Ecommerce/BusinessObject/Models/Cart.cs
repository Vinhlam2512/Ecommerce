using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ProductName { get; set; } = null!;
        public string ProductImage { get; set; } = null!;
        public decimal Price { get; set; }
        public string Size { get; set; } = null!;
        public string Color { get; set; } = null!;
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;

        public virtual User User { get; set; } = null!;
    }
}
