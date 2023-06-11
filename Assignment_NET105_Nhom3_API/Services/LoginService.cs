using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Assignment_NET105_Nhom3_API.DataContext;
using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Assignment_NET105_Nhom3_API.Services
{
    public class LoginService : ILoginService
    {
        private readonly MyDbContext context;
        private readonly IConfiguration _configuration;
        public LoginService(MyDbContext dbContext, IConfiguration configuration)
        {
            _configuration = configuration;
            context = dbContext;
        }

        public async Task<Response> LoginAsync(LoginUser loginUser)
        {

            //check user tồn tại
            var username = await context.Customer.FirstOrDefaultAsync(p => p.UserName == loginUser.Username);

            if (username != null && await context.Customer.FirstOrDefaultAsync(p => p.Password == loginUser.Password && p.UserName == loginUser.Username) != null)
            {
                // lấy role của user
                var roles = await context.Role.FirstOrDefaultAsync(p => p.Id == username.RoleId);

                var claims = new List<Claim>()
                {

                    new Claim("Id",username.Id.ToString()),
                    new Claim("RoleName",username.Role.RoleName.ToString()),
                    new Claim("Name",username.Name.ToString()),
                    new Claim("Email",username.Email.ToString())


                };
                // tạo JWT
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                //           var token = new JwtSecurityToken(_configuration["JWT:Issuer"]
                //               , _configuration["JWT:Audience"],
                //claims, expires: DateTime.UtcNow.AddDays(1),
                //               signingCredentials: signIn);
                var token = new JwtSecurityToken(
                          claims: claims,
                          expires: DateTime.Now.AddDays(1),
                          signingCredentials: signIn);
                var jwt = new JwtSecurityTokenHandler().WriteToken(token);


                return new Response()
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Message = "Valid user",
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                };
            }
            else
            {

                return new Response()
                {
                    IsSuccess = false,
                    StatusCode = 400,
                    Message = "Invalid user"
                };
            }

        }
    }
}
