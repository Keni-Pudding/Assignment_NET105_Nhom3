using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_NET105_Nhom3_API.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class RegisterControllers : ControllerBase
    {
        private readonly IRegisterService _registerService;
        public RegisterControllers(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            var result = await _registerService.RegisterAsync(registerUser);
            return StatusCode(result.StatusCode, result.Message);
        }
    }
}
