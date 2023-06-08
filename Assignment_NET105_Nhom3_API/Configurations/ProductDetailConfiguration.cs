using Assignment_NET105_Nhom3_Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_NET105_Nhom3_API.Configurations
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
