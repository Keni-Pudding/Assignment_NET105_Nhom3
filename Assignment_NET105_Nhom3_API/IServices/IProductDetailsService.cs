using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_Shared.ViewModels;

namespace Assignment_NET105_Nhom3_API.IServices
{
    public interface IProductDetailsService
    {
        public List<ProductDetailsViewModels_Show> GetAllProductDetailsByProductID_View(Guid id);
        public List<ProductDetails> GetAllProductDetails();
        public Task<List<ProductDetails>> GetAllProductDetailsAsync();
        public Task<ProductDetails> GetProductDetailsByIDAsync(Guid ID);
        public Task<ProductDetails> PostProductDetailsAsync(ProductDetails ProductDetails);
        public Task<ProductDetails> PutProductDetailsAsync(ProductDetails ProductDetails);
        public Task<ProductDetails> DeleteProductDetailsAsync(Guid ID);
    }
}
