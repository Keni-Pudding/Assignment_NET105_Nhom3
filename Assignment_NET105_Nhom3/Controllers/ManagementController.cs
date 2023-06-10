using Assignment_NET105_Nhom3_API.DataContext;
using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Assignment_NET105_Nhom3.Controllers
{
    public class ManagementController : Controller
    {
        private readonly MyDbContext _context;
        public ManagementController()
        {
            _context = new MyDbContext();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ShowListProdcutDetail(Guid id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:7007/api/ProductDetails/getAllByProductID?id={id}");
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var productsD = JsonSerializer.Deserialize<List<ProductDetailsViewModels_Show>>(json, options);

            return View(productsD);
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:7007/api/Products/getAllProduct");
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var productsD = JsonSerializer.Deserialize<List<ProductViewModels_Show>>(json, options);

            return View(productsD);
        }
    }
}
