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


        [HttpGet]
        public async Task<IActionResult> BillDetail(Guid Id)
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


        public async Task<IActionResult> DetailShop(Guid Id)
        {

            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7007/api/Products/Id?Id=" + Id.ToString() + "\r\n");
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var productsD = JsonSerializer.Deserialize<Products>(json, options);
            ViewBag.ShowProduct = productsD;

            //ShowSize and Color
            List<Color> colors = new List<Color>();
            List<Size> sizes = new List<Size>();
            // getall colors
            var response1 = await _httpClient.GetAsync("https://localhost:7007/api/color");
            var json1 = await response1.Content.ReadAsStringAsync();
            var options1 = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var _lstColor = JsonSerializer.Deserialize<List<Color>>(json1, options1);
            // getall productdetails
            var response3 = await _httpClient.GetAsync("https://localhost:7007/api/ProductDetails");
            var json3 = await response3.Content.ReadAsStringAsync();
            var options3 = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var _lstProductDetails = JsonSerializer.Deserialize<List<ProductDetails>>(json3, options3);

            // getall size
            var response2 = await _httpClient.GetAsync("https://localhost:7007/api/Size");
            var json2 = await response2.Content.ReadAsStringAsync();
            var options2 = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var _lstSize = JsonSerializer.Deserialize<List<Size>>(json2, options2);
            var a = _lstProductDetails.Where(x => x.ProductId == Id).ToList();
            int dem = 0;
            int dem1 = 0;
            for (int i = 0; i < a.Count(); i++)
            {
                if (colors.Count() == 0)
                {
                    colors.Add(_lstColor.Where(x => x.Id == a[i].ColorId).FirstOrDefault());
                }
                for (int l = 0; l < colors.Count(); l++)
                {
                    if (colors[l].Id == _lstColor.Where(x => x.Id == a[i].ColorId).FirstOrDefault().Id)
                    {
                        dem = dem + 1;
                    }
                }
                if (dem == 0)
                {

                    colors.Add(_lstColor.Where(x => x.Id == a[i].ColorId).FirstOrDefault());
                    // break;
                }
                dem = 0;
            }
            for (int k = 0; k < a.Count(); k++)
            {
                if (sizes.Count() == 0)
                {
                    sizes.Add(_lstSize.Where(x => x.Id == a[k].SizeId).FirstOrDefault());
                }
                for (int n = 0; n < sizes.Count(); n++)
                {
                    if (sizes[n].Id == _lstSize.Where(x => x.Id == a[k].SizeId).FirstOrDefault().Id)
                    {
                        dem1 = dem1 + 1;
                    }
                }
                if (dem1 == 0)
                {

                    sizes.Add(_lstSize.Where(x => x.Id == a[k].SizeId).FirstOrDefault());
                    // break;
                }
                dem1 = 0;
            }
            ViewBag.color = colors;
            ViewBag.size = sizes;
            return View(productsD);
        }
    }
}