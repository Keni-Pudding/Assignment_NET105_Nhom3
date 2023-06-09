using Assignment_NET105_Nhom3_API.DataContext;
using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_Shared.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<CartDetails> GetCartDetailssByIDAsync(Guid ID)
        {
            return await _myDbContext.CartDetails.FirstOrDefaultAsync(c => c.Id == ID);
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
            x.Quantity = CartDetails.Quantity;
            await _myDbContext.SaveChangesAsync();
            return x;
        }
    }
}
