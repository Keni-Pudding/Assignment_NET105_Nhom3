using Assignment_NET105_Nhom3_Shared.ViewModels;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Assignment_NET105_Nhom3.Controllers
{
    public class RegisterController : Controller
    {
        private readonly HttpClient _httpClient;
        public RegisterController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [HttpGet]
        public IActionResult  Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            // Convert registerUser to JSON
            var registerUserJSON = JsonConvert.SerializeObject(registerUser);

            // Convert to string content
            var stringContent = new StringContent(registerUserJSON, Encoding.UTF8, "application/json");

            // Add role to queryString


            // Send request POST to register API
            var response = await _httpClient.PostAsync($"https://localhost:7007/api/register", stringContent);

            ViewBag.Message = await response.Content.ReadAsStringAsync();
            return View();
        }
    }
}
