namespace Assignment_NET105_Nhom3_Shared.Models
{
    public class Color
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public virtual List<ProductDetails>? ProductDetails { get; set; }
    }
}
