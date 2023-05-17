namespace Assignment_NET105_Nhom3.Models
{
    public class BillDetails
    {
        public Guid Id { get; set; }
        public Guid BillId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public virtual Bill Bill { get; set; } 
        public virtual ProductDetails ProductDetails { get; set; }

    }
}
