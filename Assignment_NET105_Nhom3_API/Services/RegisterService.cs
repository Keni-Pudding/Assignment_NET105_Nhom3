using System.Xml.Linq;

using Assignment_NET105_Nhom3.Models;
using Assignment_NET105_Nhom3_API.DataContext;
using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Assignment_NET105_Nhom3_API.Services
{
	public class RegisterService : IRegisterService
	{
		private readonly MyDbContext context;
		public RegisterService(MyDbContext dbContext)
		{
			context= dbContext;
		}
		public async Task<Response> RegisterAsync(RegisterUser registerUser)
		{
			// check user tồn tại'

			if (await context.Customer.FirstOrDefaultAsync(p => p.UserName == registerUser.Username) != null)
			{
				return new Response
				{
					IsSuccess = true,
					StatusCode = 400,
					Message = "Username đã tồn tại"
				};
			}
			//check email tồn tại
			else if (await context.Customer.FirstOrDefaultAsync(p => p.Email == registerUser.Email) != null)
			{
				return new Response
				{
					IsSuccess = false,
					StatusCode = 400,
					Message = "Email đã tồn tại"
				};
			}
			//check password với confirmpassword
			if (registerUser.Password != registerUser.ConfirmPassword)
			{
				return new Response
				{
					IsSuccess = false,
					StatusCode = 400,
					Message = "password không trùng với confirmpassword"
				};
			}
			//tạo Customer
			Customer newUser = new()
			{
				Id = Guid.NewGuid(),
				Name = registerUser.Name,
				UserName= registerUser.Username,
				Password=registerUser.Password,
				Email= registerUser.Email,
				RoleId=Guid.Parse("9bd49d4b-adde-470f-9c70-29cbb73cb46f"),
				Address="",
				Status=1,
				CustomerCode="",
				NumberPhone="",			
				Sex=false,


			};
			Cart newCart = new()
			{
				UserId = newUser.Id,
				Description = "",
				Status = 1

			};
			//thêm Customer vào db
			if ( context.Customer.AddAsync(newUser).IsCompleted==true && context.Cart.AddAsync(newCart).IsCompleted)
			{
				context.SaveChanges();
				return new Response
				{
					IsSuccess= true,
					StatusCode= 200,
					Message="Đăng kí thành công"
				};
			}
			else
			{
				return new Response
				{
					IsSuccess = false,
					StatusCode = 404,
					Message = "đã có lỗi"
				};
			}

		}
	}
}
