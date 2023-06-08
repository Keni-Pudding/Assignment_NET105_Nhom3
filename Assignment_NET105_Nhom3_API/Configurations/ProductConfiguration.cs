using Assignment_NET105_Nhom3_Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_NET105_Nhom3_API.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(x =>x.Id);
            builder.Property(x => x.Name).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.Image).HasColumnType("nvarchar(500)");          
            builder.HasOne(x=>x.Category).WithMany(p=>p.Products).HasForeignKey(x=>x.CategoryId);
            
        }
    }
}
