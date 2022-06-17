using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniShopApp.Business.Abstract;
using MiniShopApp.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiniShopApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View(_productService.GetHomePageProducts());
        }
        public async Task<IActionResult> GetProductsFromRestFullApi()
        {
            var products = new List<Product>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:4200/api/products")) //api istekte bulunma(json bilgi döndürüyor)
                {
                    string contentResponse = await response.Content.ReadAsStringAsync(); //içeriği bana string olarak getir.
                    products = JsonConvert.DeserializeObject<List<Product>>(contentResponse); //contentResponse'u oku ve her birinin içinde product liste olan products a ata.
                }
                
            }
            return View(products);

        }
    }
}
