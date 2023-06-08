using Assignment_NET105_Nhom3.Models;
using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_NET105_Nhom3_API.Controllers
{
    [Route("api/ProductDetails")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailsService _productDetailsService;
        public ProductDetailsController(IProductDetailsService productDetailsService)
        {
            _productDetailsService = productDetailsService;
        }
        [HttpGet]
        public async Task<ActionResult<ProductDetails>> GetAllProductDetails() //  Lấy danh sách data
        {
            var lpd = await _productDetailsService.GetAllProductDetailsAsync();
            return Ok(lpd);
        }
        [HttpGet("{ID}")]
        public async Task<ActionResult<ProductDetails>> GetProductDetailsByID(Guid ID) // Lấy data theo Id
        {
            var pd = await _productDetailsService.GetProductDetailsByIDAsync(ID);
            return Ok(pd);
        }
        [HttpPost]
        public async Task<ActionResult<ProductDetails>> PostProductDetails(ProductDetails pd) // Tạo mới
        {
            await _productDetailsService.PostProductDetailsAsync(pd);
            return Ok();
        }
        [HttpPut("{ID}")]
        public async Task<ActionResult<ProductDetails>> PutProductDetails(Guid ID, ProductDetails pd) // Update
        {
            await _productDetailsService.PutProductDetailsAsync(ID, pd); return Ok();
        }
        [HttpDelete("{ID}")]
        public async Task<ActionResult<ProductDetails>> DeleteNguoiYeuCu(Guid ID) // Delete theo Id
        {
            await _productDetailsService.DeleteProductDetailsAsync(ID); return Ok();
        }
    }
}
