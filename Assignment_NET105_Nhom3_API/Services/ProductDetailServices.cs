using Assignment_ThangNVPH25980.IServices;
using Assignment_ThangNVPH25980.Models;

namespace Assignment_ThangNVPH25980.Services
{
    public class ProductDetailServices : IProductDetailServices
    {
        OuteDBContext context;
        public ProductDetailServices()
        {
            context = new OuteDBContext();
        }
        public bool Add(ProductDetails products)
        {
            try
            {
                context.ProductDetails.Add(products);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(Guid Id)
        {
            try
            {
                var p = context.ProductDetails.Find(Id);
                context.ProductDetails.Remove(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ProductDetails> GetAllProductDetails()
        {
            return context.ProductDetails.ToList();
        }

        public ProductDetails GetProductDetailsById(Guid Id)
        {
            return context.ProductDetails.Where(x => x.Id == Id).FirstOrDefault();
        }

        public List<ProductDetails> GetProductDetailsByName(string Name)
        {
            throw new NotImplementedException();
        }

        public bool Update(ProductDetails products)
        {
            try
            {

                var p = context.ProductDetails.Find(products.Id);
                p.ProductId = products.ProductId;
                p.SizeId = products.SizeId;
                p.ColorId = products.ColorId;
                p.Status = products.Status;
                p.AvaiableQuatity = products.AvaiableQuatity;
                context.ProductDetails.Update(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
