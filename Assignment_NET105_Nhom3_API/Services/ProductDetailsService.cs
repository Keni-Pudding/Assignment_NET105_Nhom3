using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_API.DataContext;
using Assignment_NET105_Nhom3_API.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Assignment_NET105_Nhom3_API.Services
{
    public class ProductDetailsService : IProductDetailsService
    {
        private readonly MyDbContext _context;
        public ProductDetailsService(MyDbContext myDbContext)
        {
            _context = myDbContext;
        }
        public ProductDetailsService()
        {
            _context = new MyDbContext();
        }
        public async Task<ProductDetails> DeleteProductDetailsAsync(Guid ID)
        {
            var dl = await _context.ProductDetails.FindAsync(ID);
            if (dl == null) return null; // Trả về null nếu không tìm thấy NYC
            _context.ProductDetails.Remove(dl);
            await _context.SaveChangesAsync();
            return dl;
        }

        public List<ProductDetails> GetAllProductDetails()
        {
            return _context.ProductDetails.ToList();
        }

        public async Task<List<ProductDetails>> GetAllProductDetailsAsync()
        {
            var x = await _context.ProductDetails.ToListAsync();
            return x;
        }

        public async Task<ProductDetails> GetProductDetailsByIDAsync(Guid ID)
        {
            return await _context.ProductDetails.FirstOrDefaultAsync(c => c.Id == ID);
        }

        public async Task<ProductDetails> PostProductDetailsAsync(ProductDetails ProductDetails)
        {
            await _context.ProductDetails.AddAsync(ProductDetails);
            await _context.SaveChangesAsync();
            return ProductDetails;
        }

        public async Task<ProductDetails> PutProductDetailsAsync(Guid ID, ProductDetails ProductDetails)
        {
            //    public Guid Id { get; set; }
            //public Guid? ProductId { get; set; }
            //public Guid? SizeId { get; set; }
            //public Guid? ColorId { get; set; }
            //public int AvaiableQuatity { get; set; }
            //public int Status { get; set; }
            var x = await _context.ProductDetails.FindAsync(ID);
            if (x == null) return null;

            x.Id = ProductDetails.Id;
            x.ProductId = ProductDetails.ProductId;
            x.SizeId = ProductDetails.SizeId;
            x.ColorId = ProductDetails.ColorId;
            x.AvaiableQuatity = ProductDetails.AvaiableQuatity;
            x.Status = ProductDetails.AvaiableQuatity;

            await _context.SaveChangesAsync();
            return x;
        }
    }
}
