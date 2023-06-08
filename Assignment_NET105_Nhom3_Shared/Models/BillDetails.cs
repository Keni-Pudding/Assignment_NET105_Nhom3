namespace Assignment_NET105_Nhom3_Shared.Models
{
    public class BillDetails
    {
        public Guid Id { get; set; }
        public Guid BillId { get; set; }
        public Guid? ProductDetailsId { get; set; }
        public Guid? ComboId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }


        public virtual Bill Bill { get; set; } 
        public virtual ProductDetails ProductDetails { get; set; }
        public virtual Combos Combos { get; set; }

    }
}
