using Assignment_NET105_Nhom3_Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_NET105_Nhom3_API.Configurations
{
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetails>
    {
        public void Configure(EntityTypeBuilder<CartDetails> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.Property(x => x.ProductDetailId).IsRequired(false);
            //builder.Property(x => x.ComboId).IsRequired(false);
            builder.HasOne(x => x.Cart).WithMany(p=>p.CartDetails).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.ProductDetails).WithMany(p=>p.CartDetails).HasForeignKey(x => x.ProductDetailId);
            builder.HasOne(x => x.Combos).WithMany(p=>p.CartDetails).HasForeignKey(x => x.ComboId);
            
        }
    }
}
