namespace Assignment_NET105_Nhom3_Shared.Models
{
    public class Cart
    {
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual IList<CartDetails> CartDetails { get; set; }
        
    }
}
