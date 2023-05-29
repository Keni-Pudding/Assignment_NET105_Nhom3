namespace Assignment_NET105_Nhom3.Models
{
    public class ComboDetails
    {
        public Guid Id { get; set; }
        public Guid ComboId { get; set; }
        public Guid ProductsDetailsId { get; set; }
        public int Quantity { get; set; }

        public virtual Combos Combos { get; set; }
        public virtual ProductDetails ProductDetails { get; set; }
    }
}
