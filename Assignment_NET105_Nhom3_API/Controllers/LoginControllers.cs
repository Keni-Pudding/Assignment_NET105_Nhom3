using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_Shared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_NET105_Nhom3_API.Controllers
{
	[Route("api/login")]
	[ApiController]
	public class LoginControllers : ControllerBase
	{
		private readonly ILoginService _loginService;
		public LoginControllers(ILoginService loginService)
		{
			_loginService= loginService;
		}
		[HttpPost("login")]
		[AllowAnonymous]
		public async Task<IActionResult> Login(LoginUser loginUser)
		{
			var result = await _loginService.LoginAsync(loginUser);
			if (result.IsSuccess)
			{
				return Ok(result.Token);
			}
			return StatusCode(result.StatusCode, result.Message);
		}
	}
}
