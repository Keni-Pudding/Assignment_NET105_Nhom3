namespace Assignment_NET105_Nhom3_Shared.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public int Status { get; set; }
        public virtual IList<Customer>? Customer { get; set; }
    }
}
