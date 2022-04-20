using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EF_Core_MVC_Code.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EF_Core_MVC_Code.Controllers
{
    public class YayinEvleriController : Controller
    {
        private readonly KutuphaneSabahContext _context;
        public YayinEvleriController(KutuphaneSabahContext context)
        {
            _context=context;
            
        }
           public IActionResult Index()
        {
            return View(_context.Yayinevleris.ToList());
        } 
        public IActionResult Details(int id)
        {
            var ev = _context.Yayinevleris.Find(id);
            return View(ev);
        }
        public IActionResult Edit(int id)
        {
            var ev = _context.Yayinevleris.Find(id);
            return View(ev);
        }

        [HttpPost]
        public IActionResult Edit(Yayinevleri ev)
        {
            _context.Update(ev);
            _context.SaveChanges();
            return RedirectToAction("Index");
           
        }
         public IActionResult Delete(int id)
        {
            var ev = _context.Yayinevleris.Find(id);
            return View(ev);
        }
        [HttpPost]
         public IActionResult Delete(Yayinevleri ev)
        {
            _context.Remove(ev);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create(int id)
        {
            var ev = _context.Yayinevleris.Find(id);
            return View(ev);
        }
        [HttpPost]
        public IActionResult Create(Yayinevleri ev)
        {
            _context.Add(ev);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}