﻿using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }

        public virtual Color Color { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual Size Size { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
