using Microsoft.AspNetCore.Mvc;
using MiniShopApp.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShopApp.WebApi.Controllers
{
    [ApiController]
    //https://localhost5000/api/products 
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
          var products = await _productService.GetAll();
            return Ok(products);
        }
    }
}
