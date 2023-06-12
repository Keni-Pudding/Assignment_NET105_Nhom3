using Assignment_NET105_Nhom3_API.DataContext;
using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Assignment_NET105_Nhom3_API.Services
{
    public class CartDetailsService : ICartDetailService
    {
        private readonly MyDbContext _myDbContext;
        public CartDetailsService(MyDbContext _A)
        {
            _myDbContext = _A;
        }
        public async Task<CartDetails> DeleteCartDetailssAsync(Guid ID)
        {
            var cartdetails = await _myDbContext.CartDetails.FindAsync(ID);
            if (cartdetails == null) return null; // Trả về null nếu không tìm thấy cartdetails
            _myDbContext.CartDetails.Remove(cartdetails);
            await _myDbContext.SaveChangesAsync();
            return cartdetails;
        }

        public List<CartDetails> GetAllCartDetailsDetails()
        {
            return _myDbContext.CartDetails.ToList();
        }

        public async Task<List<CartDetails>> GetAllCartDetailssAsync()
        {
            var x = await _myDbContext.CartDetails.ToListAsync();
            return x;
        }

        public async Task<List<CartDetails>> GetAllCartDetailsByUsser(Guid UserId)
        {
            var a= await _myDbContext.CartDetails.Where(x => x.UserId == UserId).ToListAsync();
            return a;
        }

        public async Task<CartDetails> GetCartDetailssByIDAsync(Guid ID)
        {
            return await _myDbContext.CartDetails.FirstOrDefaultAsync(c => c.Id == ID);
        }

        public async Task<CartDetails> GetCartDetailssByIDProductDetailsandUserAsync(Guid ID1, Guid ID2)
        {
            return await _myDbContext.CartDetails.FirstOrDefaultAsync(c => c.ProductDetailId == ID1 && c.UserId==ID2);
        }

        public async Task<CartDetails> GetCartDetailssByIDProductDetailsAsync(Guid ID)
        {
            return await _myDbContext.CartDetails.FirstOrDefaultAsync(c => c.ProductDetailId == ID);
        }

        public async Task<List<CartDetailsViewModels>> GetCartDetailView(Guid UserId)
        {
            var bds = await (from a in _myDbContext.CartDetails
                             join b in _myDbContext.Cart on a.UserId equals b.UserId
                             join c in _myDbContext.ProductDetails on a.ProductDetailId equals c.Id
                             join d in _myDbContext.Products on c.ProductId equals d.Id
                             join e in _myDbContext.Color on c.ColorId equals e.Id
                             join f in _myDbContext.Size on c.SizeId equals f.Id
                             where a.UserId == UserId
                             select new CartDetailsViewModels
                             {
                                 Id = a.Id,
                                 ProductName = d.Name,
                                 SizeName = f.Name,
                                 ColorName = e.Name,
                                 Image = d.Image,
                                 Price = d.Price,
                               //  ComboId = Guid.Parse("1C43986F-8438-4D0E-81CC-7DFE1434DC12"),
                                 Quantity = a.Quantity,
                             }).ToListAsync();
            return bds;
        }

        public async Task<CartDetails> PostCartDetailssAsync(CartDetails CartDetails)
        {
            await _myDbContext.CartDetails.AddAsync(CartDetails);
            await _myDbContext.SaveChangesAsync();
            return CartDetails;

        }

        public async Task<CartDetails> PutCartDetailssAsync(CartDetails CartDetails)
        {
            var x = await _myDbContext.CartDetails.FindAsync(CartDetails.Id);
            if (x == null) return null;
            x.Id = CartDetails.Id;
            x.ProductDetailId = CartDetails.ProductDetailId;
            x.UserId = CartDetails.UserId;
            x.ComboId= CartDetails.ComboId;
            x.Quantity = CartDetails.Quantity;
            await _myDbContext.SaveChangesAsync();
            return x;
        }
    }
}
