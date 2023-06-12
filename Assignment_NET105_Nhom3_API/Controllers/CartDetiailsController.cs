using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_API.Services;
using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_Shared.ViewModels;
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
        [HttpGet("abc")]
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
        [HttpGet("abcc/{IDProductDetails}")]
        public async Task<ActionResult<CartDetails>> GetCartDetailsByIDProductDetails(Guid IDProductDetails) // Lấy data theo Id
        {
            var pd = await cartDetailService.GetCartDetailssByIDProductDetailsAsync(IDProductDetails);
            return Ok(pd);
        }
        [HttpGet("abcc1/IDProductDetails,UserID")]
        public async Task<ActionResult<CartDetails>> GetCartDetailsByIDProductDetailsAndUser(Guid IDProductDetails, Guid UserId) // Lấy data theo Id
        {
            var pd = await cartDetailService.GetCartDetailssByIDProductDetailsandUserAsync(IDProductDetails, UserId);
            return Ok(pd);
        }
        [HttpPost("Add/")]
        public async Task<ActionResult<CartDetailsViewModels>> PostCartDetails(CartDetailsViewModels pd) // Tạo mới
        {
            CartDetails ct = new CartDetails();
            ct.Id = pd.Id;
            ct.UserId = pd.UserId;
            ct.ComboId = pd.ComboId;
            ct.ProductDetailId = pd.ProductDetailId;
            ct.Quantity = pd.Quantity;
            await cartDetailService.PostCartDetailssAsync(ct);
            return Ok(pd);
        }
        [HttpPut("Put")]
        public async Task<ActionResult<CartDetails>> PutCartDetails(CartDetailsViewModels cd) // Update
        {
            CartDetails cartdt = await cartDetailService.GetCartDetailssByIDAsync(cd.Id);
            cartdt.ProductDetailId = cd.ProductDetailId;
            cartdt.UserId = cd.UserId;
            // cartdt.ComboId = cd.ComboId;
            cartdt.Quantity = cd.Quantity;
            await cartDetailService.PutCartDetailssAsync(cartdt);
            return Ok();

        }
        [HttpGet("ShowCartDetails/{Id}")]
        public async Task<IActionResult> GetCartDetailView(Guid Id)
        {           
            var a = await cartDetailService.GetCartDetailView(Id);
            return Ok(a);
        }
        [HttpDelete("{ID}")]
        public async Task<ActionResult<CartDetails>> DeleteCartDetails(Guid ID) // Delete theo Id
        {
            await cartDetailService.DeleteCartDetailssAsync(ID); return Ok();
        }
        [HttpGet("cart_detail_by_user/{UserId}")]
        public async Task<ActionResult> GetCartDetailByUserId(Guid UserId)
        {
            var a =await cartDetailService.GetAllCartDetailsByUsser(UserId);
            return Ok(a);
        }
    }
}
