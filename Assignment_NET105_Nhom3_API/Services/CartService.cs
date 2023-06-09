using Assignment_NET105_Nhom3_API.DataContext;
using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_NET105_Nhom3_API.Services
{
    public class CartService : ICartService
    {
        private readonly MyDbContext _myDbContext;      
        public CartService(MyDbContext _A)
        {
            _myDbContext = _A;
        }
        public async Task<Cart> DeleteCartAsync(Guid ID)
        {
            var cart = await _myDbContext.Cart.FindAsync(ID);
            if (cart == null) return null; // Trả về null nếu không tìm thấy cartdetails
            _myDbContext.Cart.Remove(cart);
            await _myDbContext.SaveChangesAsync();
            return cart;
        }

        public List<Cart> GetAllCart()
        {
            return _myDbContext.Cart.ToList();
        }

        public async Task<List<Cart>> GetAllCartAsync()
        {
            var x = await _myDbContext.Cart.ToListAsync();
            return x;
        }

        public async Task<Cart> GetCartByIDAsync(Guid ID)
        {
            return await _myDbContext.Cart.FirstOrDefaultAsync(c => c.UserId ==ID);
        }

        public async Task<Cart> PostCartAsync(Cart Cart)
        {
            await _myDbContext.Cart.AddAsync(Cart);
            await _myDbContext.SaveChangesAsync();
            return Cart;
        }

        public async Task<Cart> PutCartAsync(Cart Cart)
        {
            var x = await _myDbContext.Cart.FindAsync(Cart.UserId);
            if (x == null) return null;
            x.Status = Cart.Status;
            return x;
        }
    }
}
