using Assignment_NET105_Nhom3.Models;
using Assignment_NET105_Nhom3_API.Services;
using Assignment_NET105_Nhom3_Shared.Models;
using Assignment_NET105_Nhom3_Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Diagnostics;
using System.Text;
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

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var UserId = HttpContext.Session.GetString("UserId");
            var response = await _httpClient.GetAsync($"https://localhost:7007/api/CartDetailsController/ShowCartDetails/" + UserId.ToString());
            var a = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<CartDetailsViewModels> CartDetails = JsonSerializer.Deserialize<List<CartDetailsViewModels>>(a, options);
            ViewBag.ShowCartDetails = CartDetails;
            return View(CartDetails);
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
        //[HttpGet]
        //public IActionResult Bill()
        //{
        //    return View();
        //}
        [HttpPost]
        public async Task<IActionResult> PayToBill(Bill bill, BillDetails billDetails)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var pro = await _httpClient.GetAsync($"https://localhost:7007/api/Products");

            var cartDt = await _httpClient.GetAsync($"https://localhost:7007/api/CartDetailsController/abc");

            var e = await pro.Content.ReadAsStringAsync();
            var g = await cartDt.Content.ReadAsStringAsync();
            List<Products> lstProduct = JsonSerializer.Deserialize<List<Products>>(e, options);
            List<CartDetails> lstCartDetail = JsonSerializer.Deserialize<List<CartDetails>>(g, options);

            var UserId = HttpContext.Session.GetString("UserId");


            if (UserId == null) RedirectToAction("Login", "Login");
            //Customer a = JsonSerializer.Deserialize<Customer>(UserId);

            Guid id = Guid.NewGuid();


            bill.Id = id;
            bill.UserId = Guid.Parse(UserId);
            bill.CreatedDate = DateTime.Now;
            bill.Status = 1;
            var addBill = JsonSerializer.Serialize(bill);
            var bodyContent = new StringContent(addBill, Encoding.UTF8, "application/json");
            var repos = await _httpClient.PostAsync($"https://localhost:7007/api/bill/add_bill", bodyContent);



            var f = await _httpClient.GetAsync($"https://localhost:7007/api/CartDetailsController/cart_detail_by_user/" + UserId.ToString());
            // lấy ra cart detail theo id
            var ff = await f.Content.ReadAsStringAsync();
            //int dem=ListCartDetail.;

            List<CartDetails> ListCartDetail = JsonSerializer.Deserialize<List<CartDetails>>(ff, options);

            for (int i = 0; i < ListCartDetail.Count(); i++)
            {
                var productDt = await _httpClient.GetAsync($"https://localhost:7007/api/ProductDetails/getAllByProductID/id?=" + ListCartDetail[i].ProductDetailId);
                var h = await productDt.Content.ReadAsStringAsync();
                ProductDetails ProductDetail = JsonSerializer.Deserialize<ProductDetails>(h, options);

                Products product = lstProduct.FirstOrDefault(x => x.Id == ProductDetail.ProductId);
                var cartDetail = lstCartDetail.FirstOrDefault(x => x.ProductDetailId == ProductDetail.Id && x.UserId == Guid.Parse(UserId));

                billDetails.Id = Guid.NewGuid();
                billDetails.BillId = id;
                billDetails.ProductDetailsId = ProductDetail.Id;
                billDetails.Quantity = cartDetail.Quantity;
                billDetails.Price = cartDetail.Quantity * product.Price;
                var addBillDt = JsonSerializer.Serialize(billDetails);
                var bodyContent1 = new StringContent(addBillDt, Encoding.UTF8, "application/json");
                var Repos_addBillDT = await _httpClient.PostAsync($"https://localhost:7007/api/bill/add-billdetails", bodyContent1);

                ProductDetail.AvaiableQuatity = ProductDetail.AvaiableQuatity - cartDetail.Quantity;
                var updateProQuantity = JsonSerializer.Serialize(ProductDetail);
                var bodyContent2 = new StringContent(updateProQuantity, Encoding.UTF8, "application/json");
                var Repos_updateProQuantity = await _httpClient.PutAsync($"https://localhost:7007/api/bill/update-billdetails", bodyContent2);

                var deleteCartDetail = JsonSerializer.Serialize(cartDetail.Id);
                var bodyContent3 = new StringContent(deleteCartDetail, Encoding.UTF8, "application/json");
                var Repos_deleteCartDetail = await _httpClient.DeleteAsync($"https://localhost:7007/api/CartDetailsController/delete-billdetails/Id?={bodyContent3}");



            }
            return View();
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
        [HttpPost]
        public async Task<IActionResult> AddToCart(Guid ProductId, Guid ColorID, Guid SizeID, int quantity, CartDetails addcartDetails, CartDetails addcartDetails1)
        {
            //check xem guest hay không 
            var Rolename = HttpContext.Session.GetString("role");
            if (Rolename == null)
            {
                //check sản phẩm có tồn tại không 
                // lấy list productdetail của product
                var response1 = await _httpClient.GetAsync("https://localhost:7007/api/ProductDetails/getAllByProductID?id=" + ProductId.ToString());
                var json1 = await response1.Content.ReadAsStringAsync();
                var options1 = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var _lstProductDetails = JsonSerializer.Deserialize<List<ProductDetails>>(json1, options1);
                //check sản phẩm có tồn tại không 
                var ProductDetails = _lstProductDetails.Where(x => x.ColorId == ColorID && x.SizeId == SizeID).FirstOrDefault();
                if (ProductDetails == null)
                {
                    return Content("Sản phẩm hết hàng");
                }
                else if (ProductDetails.AvaiableQuatity <= 0)
                {
                    return Content("Sản phẩm hết hàng");
                }
                else
                {
                    // Khi có sản phẩm đó và số lượng còn trên 0 tiến hành add vào giỏ hàng 
                    //check xem số lượng có đủ để bán không 
                    if (ProductDetails.AvaiableQuatity < quantity)
                    {
                        return Content("Sản phẩm không đủ số lượng bạn mong muốn");
                    }
                    //check xem giỏ hàng có sản phẩm hay chưa 
                    var response2 = await _httpClient.GetAsync("https://localhost:7007/api/CartDetailsController/abcc/" + ProductDetails.Id.ToString());
                    var json2 = await response2.Content.ReadAsStringAsync();
                    var options2 = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var CartDetails = new CartDetails();
                    if (json2!="")
                    {
                         CartDetails = JsonSerializer.Deserialize<CartDetails>(json2, options2);
                    }
                    if (json2 == "") //sản phẩm đó còn số lượng đủ bán và sản phẩm chưa có giỏ hàng
                    {
                      
                        HttpClient client = new HttpClient();
                        addcartDetails.Id = Guid.NewGuid();
                        addcartDetails.UserId = Guid.Parse("340287BA-DD62-4AB9-B6C5-5C14C9BC694C"); // id của khách vãng lai
                        addcartDetails.ProductDetailId = ProductDetails.Id;
                        addcartDetails.Quantity = quantity;
                        var content = System.Text.Json.JsonSerializer.Serialize(addcartDetails);

                        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
                        // Call API
                        var postResult = await client.PostAsync($"https://localhost:7007/api/CartDetailsController/Add", bodyContent);
                        return Content("Đã add thành công");
                    }
                    else
                    {
                        HttpClient client = new HttpClient();
                        addcartDetails.Id = CartDetails.Id;
                        addcartDetails.UserId = Guid.Parse("340287BA-DD62-4AB9-B6C5-5C14C9BC694C");
                        addcartDetails.ProductDetailId = ProductDetails.Id;
                        int a = Convert.ToInt32(CartDetails.Quantity);
                        int c = a + quantity;
                        addcartDetails.Quantity = c;/* Convert.ToInt32(quantity);*/
                       // int a = addcartDetails.Quantity;
                        var content = System.Text.Json.JsonSerializer.Serialize(addcartDetails);
                        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
                        // Call API
                        var postResult = await client.PutAsync($"https://localhost:7007/api/CartDetailsController/Put", bodyContent);
                        return Content("Đã add thành công");
                    }    
                }
            }
            else 
            {
                //check sản phẩm có tồn tại không 
                // lấy list productdetail của product
                var response1 = await _httpClient.GetAsync("https://localhost:7007/api/ProductDetails/getAllByProductID?id=" + ProductId.ToString());
                var json1 = await response1.Content.ReadAsStringAsync();
                var options1 = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var _lstProductDetails = JsonSerializer.Deserialize<List<ProductDetails>>(json1, options1);
                //check sản phẩm có tồn tại không 
                var ProductDetails = _lstProductDetails.Where(x => x.ColorId == ColorID && x.SizeId == SizeID).FirstOrDefault();
                if (ProductDetails == null)
                {
                    return Content("Sản phẩm hết hàng");
                }
                else if (ProductDetails.AvaiableQuatity <= 0)
                {
                    return Content("Sản phẩm hết hàng");
                }
                else
                {
                    var UserId = HttpContext.Session.GetString("UserId");
                    // Khi có sản phẩm đó và số lượng còn trên 0 tiến hành add vào giỏ hàng 
                    //check xem số lượng có đủ để bán không 
                    if (ProductDetails.AvaiableQuatity < quantity)
                    {
                        return Content("Sản phẩm không đủ số lượng bạn mong muốn");
                    }
                    //check xem nó có giỏ hàng chưa
                    //check xem giỏ hàng có sản phẩm hay chưa 
                    var response2 = await _httpClient.GetAsync("https://localhost:7007/api/CartDetailsController/abcc1/IDProductDetails,UserID?IDProductDetails="+ProductDetails.Id.ToString()+ "&UserId=" +UserId.ToString());
                    var json2 = await response2.Content.ReadAsStringAsync();
                    var options2 = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var CartDetails = new CartDetails();
                    if (json2 != "")
                    {
                        CartDetails = JsonSerializer.Deserialize<CartDetails>(json2, options2);
                    }
                    if (json2 == "") //sản phẩm đó còn số lượng đủ bán và sản phẩm chưa có giỏ hàng
                    {
                        
                        HttpClient client = new HttpClient();
                        addcartDetails.Id = Guid.NewGuid();
                        addcartDetails.UserId = Guid.Parse(UserId);
                        addcartDetails.ProductDetailId = ProductDetails.Id;
                        addcartDetails.Quantity = quantity;
                        var content = System.Text.Json.JsonSerializer.Serialize(addcartDetails);

                        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
                        // Call API
                        var postResult = await client.PostAsync($"https://localhost:7007/api/CartDetailsController/Add", bodyContent);
                        return Content("Đã add thành công");
                    }
                    else
                    {
                        HttpClient client = new HttpClient();
                        addcartDetails.Id = CartDetails.Id;
                        addcartDetails.UserId = Guid.Parse("340287BA-DD62-4AB9-B6C5-5C14C9BC694C");
                        addcartDetails.ProductDetailId = ProductDetails.Id;
                        int a = Convert.ToInt32(CartDetails);
                        int c = a + quantity;
                        addcartDetails.Quantity = c;/* Convert.ToInt32(quantity);*/
                        // int a = addcartDetails.Quantity;
                        var content = System.Text.Json.JsonSerializer.Serialize(addcartDetails);
                        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
                        // Call API
                        var postResult = await client.PutAsync($"https://localhost:7007/api/CartDetailsController/Put", bodyContent);
                        return Content("Đã add thành công");
                    }
                }
            }
            return RedirectToAction("Index");
            //check sản phẩm có tồn tại không 
            //check xem nó có giỏ hàng hay chưa 
            //check xem giỏ hàng có sản phẩm hay chưa 

            // var Rolename = HttpContext.Session.GetString("role");

        }    
       
        
        
        //[HttpGet]
        //public async Task<IActionResult> Cart()
        //{ 
        //    var UserId  = HttpContext.Session.GetString("UserId");
        //    var response = await _httpClient.GetAsync($"https://localhost:7007/api/CartDetailsController/ShowCartDetails?Id="+UserId.ToString());
        //    var a = await response.Content.ReadAsStringAsync();
        //    var options = new JsonSerializerOptions
        //    {
        //        PropertyNameCaseInsensitive = true
        //    };
        //    List<CartDetailsViewModels> CartDetails = JsonSerializer.Deserialize<List<CartDetailsViewModels>>(a, options);
        //    ViewBag.ShowCartDetails = CartDetails;
        //    return View(CartDetails);
        //}
    }
}