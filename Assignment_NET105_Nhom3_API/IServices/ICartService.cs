using Assignment_NET105_Nhom3_Shared.Models;

namespace Assignment_NET105_Nhom3_API.IServices
{
    public interface ICartService
    {
        public List<Cart> GetAllCart();
        public Task<List<Cart>> GetAllCartAsync();
        public Task<Cart> GetCartByIDAsync(Guid ID);
        public Task<Cart> PostCartAsync(Cart Cart);
        public Task<Cart> PutCartAsync(Cart Cart);
        public Task<Cart> DeleteCartAsync(Guid ID);
    }
}
