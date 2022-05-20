using Microsoft.AspNetCore.Mvc;
using MiniShopApp.Business.Abstract;
using MiniShopApp.Entity;
using MiniShopApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShopApp.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public AdminController(IProductService productService, ICategoryService categoryService )
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductList()
        {
            return View(_productService.GetAll());
        }
        public IActionResult ProductCreate()
        {
            var model = new ProductModel();
            model.SelectedCategories = null;
            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
        }
        [HttpPost]
        public IActionResult ProductCreate(ProductModel model, int[] categoryIds) //ProductCreatede categoryIds yazdığımız için aynısını yazıyoruz
        {
            if (ModelState.IsValid) //kendisine verilen bütün validasyon işlemlerinden doğru geçti mi
            {
                var product = new Product()
                {
                    Name = model.Name,
                    Url = model.Url,
                    Price = model.Price,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl,
                    IsApproved = model.IsApproved,
                    IsHome = model.IsHome
                };
                _productService.Create(product, categoryIds);
                return RedirectToAction("ProductList");
            }

            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
            
            
            
        }
        public IActionResult ProductEdit(int? id)
        {
           
            var entity = _productService.GetByIdWithCategories((int)id);
            var model = new ProductModel()
            {
                ProductId = entity.ProductId,
                Name = entity.Name,
                Url = entity.Url,
                Price = entity.Price,
                Description = entity.Description,
                ImageUrl = entity.ImageUrl,
                IsApproved = entity.IsApproved,
                IsHome = entity.IsHome,
                SelectedCategories = entity.ProductCategories.Select(i => i.Category).ToList()
            };  //edit sayfasında göstermeyi hedeflediğim her şey var. ve ilgili categoryleri de var.
            ViewBag.categories = _categoryService.GetAll();
            return View(model);
        }
        [HttpPost]
        public IActionResult ProductEdit(ProductModel model, int[] categoryIds)
        {
            if (ModelState.IsValid)
            {
                //aslında üçüncü bir parametremiz de olacak. (Create'te de olacak)
                //IFormFile tipinde resim
                var entity = _productService.GetById(model.ProductId); //bunu yazmasazsak aynı kaydın üstüne tekrar tekrar yazar.(1 tane değişmiş olsa bile her şeyi tekrardan yazar.)
                entity.Name = model.Name; //Eğer name değişmiş ise yazdırıyor. change tracker
                entity.Price = model.Price;
                entity.Url = model.Url;
                entity.Description = model.Description;
                entity.IsApproved = model.IsApproved;
                entity.IsHome = model.IsHome;
                entity.ImageUrl = model.ImageUrl;
                _productService.Update(entity, categoryIds);
                return RedirectToAction("ProductList");
            }
            ViewBag.categories = _categoryService.GetAll();
            return View(model);

        }
        [HttpPost]
        public IActionResult ProductDelete(int productId) //ProductList de name'i ne verdiysek buradan da o name i vereceğiz.
        {
            var entity = _productService.GetById(productId);
            _productService.Delete(entity);
            return RedirectToAction("ProductList");
        }
        [HttpPost]
        public IActionResult PasifEt(int id)
        {
            _productService.PasifEt(id);
            return RedirectToAction("ProductList");
        }
        public IActionResult AktifEt(int id)
        {
            _productService.AktifEt(id);
            return RedirectToAction("ProductList");
        }
        
    }
}
