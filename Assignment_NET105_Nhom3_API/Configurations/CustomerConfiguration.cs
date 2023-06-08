using Assignment_NET105_Nhom3_Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Assignment_NET105_Nhom3_API.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.UserName).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x=>x.Password).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x=>x.NumberPhone).HasColumnType("nvarchar(100)").IsRequired();
            builder.HasOne(x=>x.Role).WithMany(p=>p.Customer).HasForeignKey(x=>x.RoleId);
            builder.HasOne(x=>x.Cart).WithOne(p=>p.Customer).HasForeignKey<Customer>(x=>x.Id);

        }
    }
}
