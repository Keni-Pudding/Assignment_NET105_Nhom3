using Assignment_NET105_Nhom3_Shared.Models;

namespace Assignment_NET105_Nhom3_API.IServices
{
    public interface IShowProductsService
    {
        public Task<List<Products>> GetAllProductAsync();
        
    }
}
