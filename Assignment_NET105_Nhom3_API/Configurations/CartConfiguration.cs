using Assignment_NET105_Nhom3_Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_NET105_Nhom3_API.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.Property(x=>x.Description).HasColumnType("nvarchar(100)");
            //builder.HasOne(x => x.Accounts).WithMany(p=>p.Cart).HasForeignKey();

        }
    }
}
