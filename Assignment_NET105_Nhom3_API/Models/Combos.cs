namespace Assignment_NET105_Nhom3.Models
{
    public class Combos
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public Guid CategoryId { get; set; }
        public int Status { get; set; }
        public virtual IList<ComboDetails> ComboDetails { get; set; }
        public virtual IList<CartDetails> CartDetails { get; set; }
        public virtual IList<BillDetails> BillDetails { get; set; }

        public virtual Category Category { get; set; }
    }
}
