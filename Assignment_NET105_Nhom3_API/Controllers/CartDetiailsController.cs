using Assignment_NET105_Nhom3.Models;
using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_NET105_Nhom3_API.Controllers
{
    [Route("api/CartDetailsController")]
    [ApiController]
    public class CartDetiailsController : ControllerBase
    {
        public readonly ICartDetailService cartDetailService;
        public CartDetiailsController(ICartDetailService _A)
        {
            cartDetailService = _A;
        }
        [HttpGet]
        public async Task<ActionResult<CartDetails>> GetAllCartDetails() //  Lấy danh sách data
        {
            var lpd = await cartDetailService.GetAllCartDetailssAsync();
            return Ok(lpd);
        }
        [HttpGet("{ID}")]
        public async Task<ActionResult<CartDetails>> GetCartDetailsByID(Guid ID) // Lấy data theo Id
        {
            var pd = await cartDetailService.GetCartDetailssByIDAsync(ID);
            return Ok(pd);
        }
        [HttpPost]
        public async Task<ActionResult<CartDetails>> PostCartDetails(CartDetails pd) // Tạo mới
        {
            await cartDetailService.PostCartDetailssAsync(pd);
            return Ok();
        }
        [HttpPut("{ID}")]
        public async Task<ActionResult<CartDetails>> PutCartDetails(Guid ID, CartDetails pd) // Update
        {
            await cartDetailService.PutCartDetailssAsync(pd); return Ok();
        }
        [HttpDelete("{ID}")]
        public async Task<ActionResult<CartDetails>> DeleteCartDetails(Guid ID) // Delete theo Id
        {
            await cartDetailService.DeleteCartDetailssAsync(ID); return Ok();
        }
    }
}
