using Assignment_NET105_Nhom3_API.DataContext;
using Assignment_NET105_Nhom3_Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment_NET105_Nhom3_API.Controllers
{
	[Route("api/user")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly MyDbContext context;
		public UserController(MyDbContext dbContext)
		{
			context= dbContext;
		}
		
		[HttpGet("get-use")]
		[Authorize]
		public async Task<IActionResult> GetUser()
		{
			var users = await context.Customer.ToListAsync();
			return Ok(users);
		}
	}
}
