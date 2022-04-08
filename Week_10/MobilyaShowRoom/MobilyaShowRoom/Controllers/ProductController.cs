using Microsoft.AspNetCore.Mvc;
using MobilyaShowRoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilyaShowRoom.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = Repository.AllProducts();
            return View(products);
        }
        public IActionResult GetProductDetail()
        {
            int id = Convert.ToInt32(ControllerContext.RouteData.Values["ID"]);
            // models içerisindeki verilerimizden örneğin 540 ID'li kaydı bulacak kodu yazınız.
            //yani sonuç olarak elimde product tipinden ilgili kayıt olmalı.
            var products = Repository.AllProducts();
            Product resultProduct = null;
            foreach (var product in products)
            {
                if (product.ID==id)
                {
                    resultProduct = product;
                        break;
                }
            }
            ViewBag.Product = resultProduct;
            return View();

        }
    }
}
