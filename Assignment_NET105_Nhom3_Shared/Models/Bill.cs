namespace Assignment_NET105_Nhom3_Shared.Models
{
    public class Bill
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int Status { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual IEnumerable<BillDetails>? BillDetails { get; set; }
    }
}
