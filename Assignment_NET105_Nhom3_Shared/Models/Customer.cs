namespace Assignment_NET105_Nhom3_Shared.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string? CustomerCode { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? NumberPhone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public bool Sex { get; set; }
        public Guid? RoleId { get; set; }
        public int? Status { get; set; }

        public virtual Role? Role { get; set; }
        public virtual Cart? Cart { get; set; }
        public virtual List<Bill>? Bill { get; set; }
    }
}
