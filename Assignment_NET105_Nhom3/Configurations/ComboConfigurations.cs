using Assignment_NET105_Nhom3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_NET105_Nhom3.Configurations
{
    public class ComboConfigurations : IEntityTypeConfiguration<Combos>
    {
        public void Configure(EntityTypeBuilder<Combos> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.Image).HasColumnType("nvarchar(500)");
            builder.HasOne(x => x.Category).WithMany(p => p.Combos).HasForeignKey(x => x.CategoryId);
            

        }
    }
}
