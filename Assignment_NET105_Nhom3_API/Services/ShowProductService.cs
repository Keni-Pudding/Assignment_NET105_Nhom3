using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_API.DataContext;
using Assignment_NET105_Nhom3_API.IServices;
using Microsoft.EntityFrameworkCore;

namespace Assignment_NET105_Nhom3_API.Services
{
    public class ShowProductService : IShowProductsService
    {
        private readonly MyDbContext _myDbContext;
        public ShowProductService(MyDbContext _A)
        {
            _myDbContext = _A;
        }

        public async Task<List<Products>> GetAllProductAsync()
        {
            var x = await _myDbContext.Products.ToListAsync();
            return x;
        }
    }
}
