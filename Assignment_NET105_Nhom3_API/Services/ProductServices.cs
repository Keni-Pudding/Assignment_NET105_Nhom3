using Assignment_NET105_Nhom3_API.DataContext;
using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_NET105_Nhom3_API.Services
{
    public class ProductServices : IProductServices
    {
        private readonly MyDbContext _context;
        public ProductServices(MyDbContext context)
        {
            _context = context;
        }
        public async Task<Products> DeleteProduct(Guid Id)
        {
            var x = await _context.Products.FirstOrDefaultAsync(x => x.Id == Id);
            if (x == null) return null;
            _context.Remove(x);
            await _context.SaveChangesAsync();
            return x;
        }

        public async Task<IEnumerable<Products>> GetAllProduct()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Products> GetProductsById(Guid Id)
        {
            return await _context.Products.FindAsync(Id);
        }

        public Task<IEnumerable<Products>> GetProductsByName(string Name)
        {
            throw new NotImplementedException();
        }

        public async Task<Products> PostProduct(Products products)
        {
            _context.Products.Add(products);
            await _context.SaveChangesAsync();
            return products;
        }

        public async Task<Products> PutProduct(Products products)
        {
            var a =  await _context.Products.FindAsync(products.Id);
            if (a == null) return null;
            a.Name = products.Name;
            a.Image = products.Image;   
            a.Price = products.Price;
            a.Status = products.Status; 
            await _context.SaveChangesAsync();
            return a;
        }
    }
}
