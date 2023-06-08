using Assignment_NET105_Nhom3.Models;

namespace Assignment_NET105_Nhom3_API.IServices
{
    public interface ICartDetailService
    {
        public List<CartDetails> GetAllCartDetailsDetails();
        public Task<List<CartDetails>> GetAllCartDetailssAsync();
        public Task<CartDetails> GetCartDetailssByIDAsync(Guid ID);
        public Task<CartDetails> PostCartDetailssAsync(CartDetails CartDetails);
        public Task<CartDetails> PutCartDetailssAsync(CartDetails CartDetails);
        public Task<CartDetails> DeleteCartDetailssAsync(Guid ID);
    }
}
