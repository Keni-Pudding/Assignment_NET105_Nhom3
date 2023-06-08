using Assignment_NET105_Nhom3.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Assignment_NET105_Nhom3_API.DataContext
{
    public class MyDbContext:DbContext
    {
        public MyDbContext()
        {

        }
        public MyDbContext(DbContextOptions options ):base(options)
        {

        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<BillDetails> BillDetails { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Size> Size { get; set; }
        public DbSet<Combos> Combos { get; set; }
        public DbSet<ComboDetails> ComboDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>().HasOne<Customer>(p => p.Customer).WithOne(p => p.Cart).HasForeignKey<Cart>(p => p.UserId);
            //modelBuilder.Entity<ProductDetails>()
            //.HasMany(c => c.ProductDetailsDeQuy)
            //.WithOne(e => e.Manager)
            //.HasForeignKey(c => c.IdCha)
            //.OnDelete(DeleteBehavior.Restrict);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
