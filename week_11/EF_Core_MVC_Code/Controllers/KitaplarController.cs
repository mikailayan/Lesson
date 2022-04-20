using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EF_Core_MVC_Code.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EF_Core_MVC_Code.Controllers
{
    public class KitaplarController : Controller
    {
        private readonly KutuphaneSabahContext _context;
        public KitaplarController(KutuphaneSabahContext context)
        {
            _context=context;
            //Bu aşamadan sonra yani nesne ilk üretildiği andan itibaren
            //_content değişkeni benim modelimi temsil ediyor olacak.
            //bir daha yani, KutuphaneSabahContenxt'i temsil edecek.
        }
        // GET-Kitap türlerini listele
        public IActionResult Index()
        {
            return View(_context.Kitaplars.ToList());
        }
        public IActionResult Details(string id)
        {
            var secilenKitap= _context.Kitaplars
            .Include(k=> k.Tur)
            .Include(k=> k.YayinEvi)
            .Include(k=> k.Yazar)
            .First(m=>m.Isbn==id);
            return View(secilenKitap);
        }
        public IActionResult Edit(string id)
        {
            var secilenKitap= _context.Kitaplars.Find(id);
            ViewData["Tur"]= new SelectList(_context.Turlers, "Id","TurAd",secilenKitap.TurId);
            ViewData["Yazar"]= new SelectList(_context.Yazarlars, "Id","AdSoyad",secilenKitap.YazarId);
            ViewData["YayinEvi"]= new SelectList(_context.Yayinevleris, "Id","Ad",secilenKitap.YayinEvi);
            return View(secilenKitap);
        }
        [HttpPost]
        public IActionResult Edit(Kitaplar kitap)
        {
            _context.Update(kitap);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
            public IActionResult Create(string id)
        {
            var secilenKitap= _context.Kitaplars.Find(id);
            ViewData["Tur"]= new SelectList(_context.Turlers, "Id","TurAd",secilenKitap.TurId);
            ViewData["Yazar"]= new SelectList(_context.Yazarlars, "Id","AdSoyad",secilenKitap.YazarId);
            ViewData["YayinEvi"]= new SelectList(_context.Yayinevleris, "Id","Ad",secilenKitap.YayinEvi);
            return View(secilenKitap);
        }
        [HttpPost]
        public IActionResult Create(Kitaplar kitap)
        {
            _context.Add(kitap);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}