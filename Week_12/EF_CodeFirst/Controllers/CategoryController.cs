using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EF_CodeFirst.Models.Entities;

namespace Controllers
{
    public class CategoryController : Controller
    {
        private readonly Library6Context _context;
        public CategoryController(Library6Context context)
        {
            _context=context;
        }

        public IActionResult Index()
        {
            return View(_context.Categories.ToList());
        }
        public IActionResult Create(string id)
        {
            var secilencategory = _context.Categories.Find(id);
            return View(secilencategory);
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
         public IActionResult Detail(int id)
        {
            var secilencategory = _context.Categories.Find(id);
            return View(secilencategory);
        }
         public IActionResult Update(int id)
        {
            var secilencategory = _context.Categories.Find(id);
            return View(secilencategory);
        }
        [HttpPost]
        public IActionResult Update(Category category)
        {
            _context.Update(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
         public IActionResult Delete(int id)
        {
            var secilencategory = _context.Categories.Find(id);
            return View(secilencategory);
        }
        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _context.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

    
}