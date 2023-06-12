using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_API.DataContext;
using Assignment_NET105_Nhom3_API.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Assignment_NET105_Nhom3_Shared.ViewModels;

namespace Assignment_NET105_Nhom3_API.Services
{
    public class ProductDetailsService : IProductDetailsService
    {
        private readonly MyDbContext _context;
        public ProductDetailsService(MyDbContext myDbContext)
        {
            _context = myDbContext;
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
            var x = _context.ProductDetails.ToList();
            return x;
        }

        public async Task<List<ProductDetails>> GetAllProductDetailsAsync()
        {
            var x = await _context.ProductDetails.ToListAsync();
            return x;
        }

        public async Task<ProductDetails> GetProductDetailsByIDAsync(Guid ID)
        {
            var a= await _context.ProductDetails.FirstOrDefaultAsync(c => c.Id == ID);
            return a;
        }

        public async Task<ProductDetails> PostProductDetailsAsync(ProductDetails ProductDetails)
        {
            _context.ProductDetails.Add(ProductDetails);
            await _context.SaveChangesAsync();
            return ProductDetails;
        }

        public async Task<ProductDetails> PutProductDetailsAsync(ProductDetails ProductDetails)
        {
            //    public Guid Id { get; set; }
            //public Guid? ProductId { get; set; }
            //public Guid? SizeId { get; set; }
            //public Guid? ColorId { get; set; }
            //public int AvaiableQuatity { get; set; }
            //public int Status { get; set; }
            var x = await _context.ProductDetails.FindAsync(ProductDetails.Id);
            if (x == null) return null;

            x.ProductId = ProductDetails.ProductId;
            x.SizeId = ProductDetails.SizeId;
            x.ColorId = ProductDetails.ColorId;
            x.AvaiableQuatity = ProductDetails.AvaiableQuatity;
            x.Status = ProductDetails.Status;

            await _context.SaveChangesAsync();
            return x;
        }

        public List<ProductDetailsViewModels_Show> GetAllProductDetailsByProductID_View(Guid id)
        {
            var pd_Show = (from pd in _context.ProductDetails.ToList()
                           join s in _context.Size.ToList() on pd.SizeId equals s.Id
                           join c in _context.Color.ToList() on pd.ColorId equals c.Id
                           join p in _context.Products.ToList() on pd.ProductId equals p.Id
                           join cate in _context.Category.ToList() on p.CategoryId equals cate.Id
                           select new ProductDetailsViewModels_Show()
                           {
                               Id = pd.Id,
                               ProductId = p.Id,
                               ProductName = p.Name,
                               ColorId = c.Id,
                               ColorName = c.Name,
                               SizeId = s.Id,
                               SizeName = s.Name,
                               AvaiableQuatity = pd.AvaiableQuatity,
                               Status = pd.Status,
                               CategoryId = cate.Id,
                               CategoryName = cate.Name,
                               Image = p.Image,
                               Price = p.Price,
                           }).Where(c => c.ProductId == id).ToList();
            return pd_Show;
        }
        public List<ProductDetailsViewModels_Show> GetAllProductDetailsByID_View(Guid id)
        {
            var pd_Show = (from pd in _context.ProductDetails.ToList()
                           join s in _context.Size.ToList() on pd.SizeId equals s.Id
                           join c in _context.Color.ToList() on pd.ColorId equals c.Id
                           join p in _context.Products.ToList() on pd.ProductId equals p.Id
                           join cate in _context.Category.ToList() on p.CategoryId equals cate.Id
                           select new ProductDetailsViewModels_Show()
                           {
                               Id = pd.Id,
                               ProductId = p.Id,
                               ProductName = p.Name,
                               ColorId = c.Id,
                               ColorName = c.Name,
                               SizeId = s.Id,
                               SizeName = s.Name,
                               AvaiableQuatity = pd.AvaiableQuatity,
                               Status = pd.Status,
                               CategoryId = cate.Id,
                               CategoryName = cate.Name,
                               Image = p.Image,
                               Price = p.Price,
                           }).Where(c => c.Id == id).ToList();
            return pd_Show;
        }

        public async Task<List<ProductDetails>> GetAllProductDetailsByBill(Guid Id)
        {
            List<ProductDetails> a = _context.ProductDetails.Where(x => x.Id == Id).ToList();
            return a;
        }
    }
}
