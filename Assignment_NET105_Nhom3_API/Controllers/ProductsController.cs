using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_Shared.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_NET105_Nhom3_API.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _prd;
        public ProductsController(IProductServices prd)
        {
                _prd = prd;
        }
        [HttpGet]
        public async Task<ActionResult<Products>> GetAllPro()
        {
            var pro = await _prd.GetAllProduct();
            return Ok(pro);
        }
        [HttpGet("Id")]
        public async Task<ActionResult<Products>> GetProById(Guid Id)
        {
            var pro = await _prd.GetProductsById(Id);
            return Ok(pro);
        }
        [HttpPost("add")]
        public async Task<ActionResult<Products>> PostPro(ProductViewModel prm)
        {
            Products a = new Products();
            a.Id = Guid.NewGuid();  
            a.Name = prm.Name;  
            a.Image = prm.Image;    
            a.Price = prm.Price;    
            a.CategoryId = prm.CategoryId;  
            a.Status = prm.Status;  
            await _prd.PostProduct(a);
            return Ok(a);
        }
        [HttpPut("update")]
        public async Task<ActionResult<Products>> PutPro(ProductViewModel prm)
        {
            Products a = await _prd.GetProductsById(prm.Id);
            a.Name = prm.Name;
            a.Image = prm.Image;
            a.Price = prm.Price;
            a.CategoryId = prm.CategoryId;
            a.Status = prm.Status;
            await _prd.PutProduct(a);
            return Ok(a);
        }
        [HttpDelete("Id")]
        public async Task<ActionResult<Products>> Delete(Guid Id)
        {
            await _prd.DeleteProduct(Id);
            return Ok();
        }
    }
}
