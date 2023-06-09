namespace Assignment_NET105_Nhom3_Shared.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public virtual List<Products>? Products { get; set; }
        public virtual List<Combos>? Combos { get; set; }
    }
}
