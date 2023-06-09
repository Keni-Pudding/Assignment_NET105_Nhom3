using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_API.Services;
using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_Shared.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_NET105_Nhom3_API.Controllers
{
    [Route("api/Cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public readonly ICartService cartService;
        public CartController(ICartService _a)
        {
            cartService =_a;
        }
        [HttpGet("Get")]
        public async Task<ActionResult<Cart>> GetAllCart() //  Lấy danh sách data
        {
            var lpd = await cartService.GetAllCartAsync();
            return Ok(lpd);
        }
        [HttpGet("{ID}")]
        public async Task<ActionResult<Cart>> GetCartByID(Guid ID) // Lấy data theo Id
        {
            var pd = await cartService.GetCartByIDAsync(ID);
            return Ok(pd);
        }
        [HttpPost("Addlist/")]
        public async Task<ActionResult<CartiewModels>> PostCart(CartiewModels pd) // Tạo mới
        {
            Cart c = new Cart();
            c.Description = pd.Description;
            c.UserId = pd.UserId;
            c.Status = pd.Status;
           
            await cartService.PostCartAsync(c);
            return Ok(pd);
        }
        [HttpPut("Put")]
        public async Task<ActionResult<Cart>> PutCartDetails(Cart cd) // Update
        {
            Cart cart = await cartService.GetCartByIDAsync(cd.UserId);
            cart.Status = cd.Status;
            cart.Description = cd.Description;        
            await cartService.PutCartAsync(cart);
            return Ok();
        }

    }
}
