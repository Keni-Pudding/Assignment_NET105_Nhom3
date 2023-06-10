using Assignment_NET105_Nhom3.Models;
using Assignment_NET105_Nhom3_API.Services;
using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace Assignment_NET105_Nhom3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var response = await _httpClient.GetAsync("https://localhost:7007/api/ShowProduct11");
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
            var response = await _httpClient.GetAsync("https://localhost:7007/api/ShowProduct11");
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
        [HttpGet]
        public async Task<IActionResult> Bill()
        {
            var response = await _httpClient.GetAsync($"https://localhost:7007/api/bill/get-all-bill");
            var a = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<BillViewModel_Show> bills = JsonSerializer.Deserialize<List<BillViewModel_Show>>(a, options);
            ViewBag.Bill = bills;
            return View(bills);
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> BillDetails(Guid Id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7007/api/bill/get-all-billdetails/{Id}");
            var a = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<BillDetailsViewModels_Show> billDetails = JsonSerializer.Deserialize<List<BillDetailsViewModels_Show>>(a, options);
            ViewBag.BillDetails = billDetails;
            return View(billDetails);
        }

        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Products()
        {
            return View();
        }

        public async Task<IActionResult> Products1()
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:7007/api/Products/getAllProduct");
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var productsD = JsonSerializer.Deserialize<List<ProductViewModels_Show>>(json, options);
            //List<ProductView> products = productServices.GetAllProductView();
            ViewBag.Products = productsD;
            return View(productsD);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}