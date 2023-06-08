using Assignment_NET105_Nhom3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_NET105_Nhom3.Configurations
{
    public class ComboDetailConfigurations : IEntityTypeConfiguration<ComboDetails>
    {
        public void Configure(EntityTypeBuilder<ComboDetails> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.HasOne(x => x.ProductDetails).WithMany(p => p.ComboDetails).HasForeignKey(x => x.ProductsDetailsId);
            builder.HasOne(x => x.Combos).WithMany(p => p.ComboDetails).HasForeignKey(x => x.ComboId);
        }
    }
}
