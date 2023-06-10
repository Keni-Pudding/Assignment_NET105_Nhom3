using Assignment_NET105_Nhom3.Models;
using Assignment_NET105_Nhom3_Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace Assignment_NET105_Nhom3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
     
        HttpClient httpClient = new HttpClient();
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7007/api/ShowProduct11");
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var productsD = JsonSerializer.Deserialize<List<Products>>(json, options);
            ViewBag.ShowProduct = productsD;
            return View(productsD);
        }
        [HttpGet]
        public async Task<IActionResult> ShowProducts()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7007/api/ShowProduct11");
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var productsD = JsonSerializer.Deserialize<List<Products>>(json, options);
            ViewBag.ShowProduct = productsD;
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult Bill()
        {
            return View();
        }
        [HttpGet]
        //public IActionResult Bill()
        //{

        //}

        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Products()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}