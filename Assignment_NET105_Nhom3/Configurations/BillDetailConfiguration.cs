using Assignment_NET105_Nhom3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_ThangNVPH25980.Configurations
{
    public class BillDetailConfiguration : IEntityTypeConfiguration<BillDetails>
    {
        public void Configure(EntityTypeBuilder<BillDetails> builder)
        {
            builder.ToTable("BillDetails");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductDetailsId).IsRequired(false);
            //builder.Property(x => x.ComboId).IsRequired(false);

            builder.HasOne(x=>x.ProductDetails).WithMany(p=>p.BillDetails).HasForeignKey(c=>c.ProductDetailsId);
            builder.HasOne(x=>x.Bill).WithMany(p=>p.BillDetails).HasForeignKey(c=>c.BillId);
            builder.HasOne(x => x.Combos).WithMany(p => p.BillDetails).HasForeignKey(x => x.ComboId);
        }
    }
}
