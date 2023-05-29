using Assignment_NET105_Nhom3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_ThangNVPH25980.Configurations
{
    public class ProductDetailConfiguration: IEntityTypeConfiguration<ProductDetails>
    {
        public void Configure(EntityTypeBuilder<ProductDetails> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Products).WithMany(p => p.ProductDetails).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Color).WithMany(p => p.ProductDetails).HasForeignKey(x => x.ColorId);
            builder.HasOne(x => x.Size).WithMany(p => p.ProductDetails).HasForeignKey(x => x.SizeId);
        }

    }
}
