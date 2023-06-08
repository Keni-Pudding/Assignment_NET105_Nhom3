using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_NET105_Nhom3_API.Controllers
{
    [Route("api/ShowProduct11")]
    [ApiController]
    public class ShowProducts : ControllerBase
    {
        private readonly IShowProductsService _showProductServices;
        public ShowProducts(IShowProductsService _a)
        {
            _showProductServices = _a;
        }
        [HttpGet]
        public async Task<ActionResult<Products>> GetAllProducts() //  Lấy danh sách data
        {
            var lpd = await _showProductServices.GetAllProductAsync();
            return Ok(lpd);
        }
    }
}
