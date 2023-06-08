using Assignment_ThangNVPH25980.Models;

namespace Assignment_ThangNVPH25980.IServices
{
    public interface IProductDetailServices
    {
        public bool Add(ProductDetails products);
        public bool Update(ProductDetails products);
        public bool Delete(Guid Id);
        public List<ProductDetails> GetAllProductDetails();
        public ProductDetails GetProductDetailsById(Guid Id);
        public List<ProductDetails> GetProductDetailsByName(string Name);
    }
}
