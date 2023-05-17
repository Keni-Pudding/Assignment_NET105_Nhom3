namespace Assignment_NET105_Nhom3.Models
{
    public class ProductDetails
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid SizeId { get; set; }
        public Guid ColorId { get; set; }
        public  int AvaiableQuatity { get; set; }
        public int Status { get; set; }
        public virtual Size Size { get; set; }
        public virtual Color Color { get; set; }
        public virtual List<BillDetails> BillDetails { get; set; }
        public virtual List<CartDetails> CartDetails { get; set; }
        public virtual Products Products { get; set; }
    }
}
