using Assignment_NET105_Nhom3_API.DataContext;
using Assignment_NET105_Nhom3_API.Services;
using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Assignment_NET105_Nhom3.Controllers
{
    public class ManagementController : Controller
    {
        public static Guid IDP;
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
            IDP = id;
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

        [HttpGet]
        public async Task<IActionResult> AddProductDetail()
        {
            var client1 = new HttpClient();
            var response1 = await client1.GetAsync($"https://localhost:7007/api/size");
            var json1 = await response1.Content.ReadAsStringAsync();
            var options1 = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var ls = JsonSerializer.Deserialize<List<Size>>(json1, options1);

            var client2 = new HttpClient();
            var response2 = await client2.GetAsync($"https://localhost:7007/api/color");
            var json2 = await response2.Content.ReadAsStringAsync();
            var options2 = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var lc = JsonSerializer.Deserialize<List<Color>>(json2, options2);

            ViewBag.Sizes = ls;
            ViewBag.Color = lc;

            ViewBag.IDP_Add_PD = IDP;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddProductDetail(ProductDetailsViewModels_Add_Up request)
        {
            HttpClient client = new HttpClient();

            // HTTPMethod = POST ->
            // GAN GIA TRI CHO THUOC TINH
            request.Id = Guid.NewGuid();
            
            var content = System.Text.Json.JsonSerializer.Serialize(request);

            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            // Call API
            var postResult = await client.PostAsync($"https://localhost:7007/api/ProductDetails/add-ProductDetails", bodyContent);


            return Redirect(Url.Content($"https://localhost:7185/Management/ShowListProdcutDetail/{request.ProductId}"));
        }

        [HttpGet]
        [HttpPost]
        public async Task<ActionResult> UpdateProductDetail(Guid id, ProductDetailsViewModels_Add_Up request)
        {
			var client1 = new HttpClient();
			var response1 = await client1.GetAsync($"https://localhost:7007/api/size");
			var json1 = await response1.Content.ReadAsStringAsync();
			var options1 = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
			var ls = JsonSerializer.Deserialize<List<Size>>(json1, options1);

			var client2 = new HttpClient();
			var response2 = await client2.GetAsync($"https://localhost:7007/api/color");
			var json2 = await response2.Content.ReadAsStringAsync();
			var options2 = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
			var lc = JsonSerializer.Deserialize<List<Color>>(json2, options2);

			ViewBag.Sizes = ls;
			ViewBag.Color = lc;
			ViewBag.PD_UP = IDP;
			HttpClient client = new HttpClient();
            // Kiem tra HTTPMethod = GET -> lay du lieu tu GetById -> View()
            if (HttpMethods.IsGet(HttpContext.Request.Method))
            {
                var respone = await client.GetAsync($"https://localhost:7007/api/ProductDetails/getbyID?ID={id}");
                var jsonString = await respone.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var data = JsonSerializer.Deserialize<ProductDetailsViewModels_Add_Up>(jsonString, options);

                return View("UpdateProductDetail", data);
            }

			HttpClient client3 = new HttpClient();
            // Call API

            var content = System.Text.Json.JsonSerializer.Serialize(request);

            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var putResult = await client3.PutAsync($"https://localhost:7007/api/ProductDetails/update-ProductDetails", bodyContent);

            //var putResult = await client3.PutAsJsonAsync($"https://localhost:7007/api/ProductDetails/update-ProductDetails", request);
            // Kiem tra ket qua API tra ve
            if (putResult.IsSuccessStatusCode)
            {
                return Redirect(Url.Content($"https://localhost:7185/Management/ShowListProdcutDetail/{request.ProductId}"));
            }
            return View("UpdateProductDetail", request);
        }
        [HttpGet]
		public async Task<IActionResult> DeleteProductDetails(Guid Id)
        {
			HttpClient client3 = new HttpClient();
			// Call API
			var respone = await client3.GetAsync($"https://localhost:7007/api/ProductDetails/getbyID?ID={Id}");

			var jsonString = await respone.Content.ReadAsStringAsync();

			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
			var data = JsonSerializer.Deserialize<ProductDetailsViewModels_Add_Up>(jsonString, options);
            data.Status = 0;
			HttpClient client4 = new HttpClient();
			var content = JsonSerializer.Serialize(data);

			var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

			var putResult = await client4.PutAsync($"https://localhost:7007/api/ProductDetails/update-ProductDetails", bodyContent);
			if (putResult.IsSuccessStatusCode)
			{
				return Redirect(Url.Content($"https://localhost:7185/Management/ShowListProdcutDetail/{data.ProductId}"));
			}
            return BadRequest();
		}
		[HttpGet]
		public async Task<IActionResult> Details(Guid Id)
        {
			HttpClient client3 = new HttpClient();
            // Call API
            var respone = await client3.GetAsync($"https://localhost:7007/api/ProductDetails/getAllByID?id={Id}");

            string jsonString = await respone.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            var data = JsonSerializer.Deserialize<ProductDetailsViewModels_Show>(jsonString, options);
            //var data = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductDetailsViewModels_Show>(jsonString);

            return View(data);
		}

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            var client1 = new HttpClient();
            var response1 = await client1.GetAsync($"https://localhost:7007/api/Category");
            var json1 = await response1.Content.ReadAsStringAsync();
            var options1 = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var lcate = JsonSerializer.Deserialize<List<Category>>(json1, options1);
            ViewBag.Cate = lcate;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(ProductViewModel request, [Bind] IFormFile ImageFile)
        {
            HttpClient client = new HttpClient();

            // HTTPMethod = POST ->
            // GAN GIA TRI CHO THUOC TINH
            request.Id = Guid.NewGuid();
            if (ImageFile != null && ImageFile.Length > 0)
            {
                // Trỏ tới thư mục wwwroot để lát nữa thực hiện việc copy sang
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", ImageFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    // Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                    ImageFile.CopyTo(stream);
                }
                // Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã đưuọc sao chép
                request.Image = ImageFile.FileName;
            }
            else if (ImageFile == null)
            {
                request.Image = string.Empty;
            }
            var content = System.Text.Json.JsonSerializer.Serialize(request);

            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            // Call API
            var postResult = await client.PostAsync($"https://localhost:7007/api/Products/add", bodyContent);

            if (postResult.IsSuccessStatusCode)
            {
				return Redirect(Url.Content($"https://localhost:7185/Management/ProductList"));
			}
            return BadRequest();
        }
        [HttpGet]
        [HttpPost]
        public async Task<ActionResult> EditProduct(Guid id, ProductViewModel request, [Bind] IFormFile ImageFile)
        {
            var client1 = new HttpClient();
            var response1 = await client1.GetAsync($"https://localhost:7007/api/Category");
            var json1 = await response1.Content.ReadAsStringAsync();
            var options1 = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var lcate = JsonSerializer.Deserialize<List<Category>>(json1, options1);
            ViewBag.Cate = lcate;

            HttpClient client = new HttpClient();
            // Kiem tra HTTPMethod = GET -> lay du lieu tu GetById -> View()
            if (HttpMethods.IsGet(HttpContext.Request.Method))
            {
                var respone = await client.GetAsync($"https://localhost:7007/api/Products/Id?Id={id}");
                var jsonString = await respone.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var data = JsonSerializer.Deserialize<ProductViewModel>(jsonString, options);

                return View("EditProduct", data);
            }

            HttpClient client3 = new HttpClient();
            // Call API

            if (ImageFile != null && ImageFile.Length > 0)
            {
                // Trỏ tới thư mục wwwroot để lát nữa thực hiện việc copy sang
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", ImageFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    // Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                    ImageFile.CopyTo(stream);
                }
                // Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã đưuọc sao chép
                request.Image = ImageFile.FileName;
            }
            else if (ImageFile == null)
            {
                request.Image = "cf7ee2f9-076b-4008-a55e-9af4310a89ac";
            }

            var content = System.Text.Json.JsonSerializer.Serialize(request);

            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var putResult = await client3.PutAsync($"https://localhost:7007/api/Products/update", bodyContent);

            if (putResult.IsSuccessStatusCode)
            {
                return Redirect(Url.Content($"https://localhost:7185/Management/ProductList"));
            }
            return View("EditProduct", request);
        }
    }
}
