namespace Assignment_NET105_Nhom3_Shared.Models
{
    public class Products
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public Guid CategoryId { get; set; }
        public int Status { get; set; }
        public virtual Category Category { get; set; }
        public virtual IList<ProductDetails> ProductDetails { get; set; }



    }
}
