using DatabaseImageProject.Models.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseImageProject.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = new ProductDAL();
            return View(products.GetAll());
        }


    }
}
