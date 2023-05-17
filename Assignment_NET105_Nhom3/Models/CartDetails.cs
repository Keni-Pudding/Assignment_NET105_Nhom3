﻿namespace Assignment_NET105_Nhom3.Models
{
    public class CartDetails
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual ProductDetails ProductDetails { get; set; }
    }
}
