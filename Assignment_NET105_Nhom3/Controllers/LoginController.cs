using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Assignment_NET105_Nhom3_API.IServices;
using Assignment_NET105_Nhom3_Shared.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using Assignment_NET105_Nhom3_API.DataContext;
using System.Threading.Tasks.Dataflow;
using Assignment_NET105_Nhom3_Shared.Models;

namespace Assignment_NET105_Nhom3.Controllers
{

    public class LoginController : Controller
    {

        private readonly HttpClient _httpClient;
     
        public LoginController(HttpClient httpClient )
        {
            _httpClient = httpClient;
           
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            // Convert registerUser to JSON
            var loginUserJSON = JsonConvert.SerializeObject(loginUser);

            // Convert to string content
            var stringContent = new StringContent(loginUserJSON, Encoding.UTF8, "application/json");

            // Send request POST to register API
            var response = await _httpClient.PostAsync($"https://localhost:7007/api/login/login", stringContent);

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();

                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(token);
                HttpContext.Session.SetString("UserId", jwt.Claims.FirstOrDefault(u => u.Type == "Id").Value);
                HttpContext.Session.SetString("role", jwt.Claims.FirstOrDefault(u => u.Type == "RoleName").Value);

            
            
              
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = await response.Content.ReadAsStringAsync();
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
