using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assignment_NET105_Nhom3_Shared.ViewModels;

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
        [HttpGet("getAllByProductID")]
        public IActionResult GetAllProductDetails(Guid id) //  Lấy danh sách data
        {
            var result = _productDetailsService.GetAllProductDetailsByProductID_View(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<ProductDetails>> GetAllProductDetailsAsync() //  Lấy danh sách data
        {
            var result = await _productDetailsService.GetAllProductDetailsAsync();
            return Ok(result);
        }
        [HttpGet("getbyID")]
        public async Task<ActionResult<ProductDetails>> GetProductDetailsByID(Guid ID) // Lấy data theo Id
        {
            var result = await _productDetailsService.GetProductDetailsByIDAsync(ID);
            return Ok(result);
        }
        [HttpPost("add-ProductDetails")]
        public async Task<ActionResult<ProductDetails>> PostProductDetails(ProductDetailsViewModels_Add_Up pdvm) // Tạo mới
        {
            ProductDetails pd = new ProductDetails();
            pd.Id = Guid.NewGuid();
            pd.ProductId = pdvm.ProductId;
            pd.SizeId = pdvm.SizeId;
            pd.ColorId = pdvm.ColorId;
            pd.AvaiableQuatity = pdvm.AvaiableQuatity;
            pd.Status = pdvm.Status;
            var result = await _productDetailsService.PostProductDetailsAsync(pd);
            return Ok(result);
        }
        [HttpPut("update-ProductDetails")]
        public async Task<ActionResult<ProductDetails>> PutProductDetails(ProductDetailsViewModels_Add_Up pdvm) // Update
        {
            ProductDetails pd = await _productDetailsService.GetProductDetailsByIDAsync(pdvm.Id);
            pd.ProductId = pdvm.ProductId;
            pd.SizeId = pdvm.SizeId;
            pd.ColorId = pdvm.ColorId;
            pd.AvaiableQuatity = pdvm.AvaiableQuatity;
            pd.Status = pdvm.Status;
            var result = await _productDetailsService.PutProductDetailsAsync(pd); return Ok(result);
        }
        [HttpDelete("delete-ProductDetails")]
        public async Task<ActionResult<ProductDetails>> DeleteProductDetails(Guid ID) // Delete theo Id
        {
            var result = await _productDetailsService.DeleteProductDetailsAsync(ID);
            return Ok(result);
        }
    }
}
