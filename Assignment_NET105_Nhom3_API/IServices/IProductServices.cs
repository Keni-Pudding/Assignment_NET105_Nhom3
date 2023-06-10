using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_Shared.ViewModels;

namespace Assignment_NET105_Nhom3_API.IServices
{
    public interface IProductServices
    {
        public List<ProductViewModels_Show> GetAllProducts_Show();
        public Task<IEnumerable<Products>> GetAllProduct();
        public Task<Products> PostProduct(Products products);
        public Task<Products> PutProduct(Products products);
        public Task<Products> DeleteProduct(Guid Id);
        public Task<Products> GetProductsById(Guid Id);
        public Task<IEnumerable<Products>> GetProductsByName(string Name);
    }
}
