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
    public class TurController : Controller
    {
        private readonly KutuphaneSabahContext _context;
        public TurController(KutuphaneSabahContext context)
        {
            _context=context;
            //Bu aşamadan sonra yani nesne ilk üretildiği andan itibaren
            //_content değişkeni benim modelimi temsil ediyor olacak.
            //bir daha yani, KutuphaneSabahContenxt'i temsil edecek.
        }
        // GET-Kitap türlerini listele
        public IActionResult Index()
        {
            return View(_context.Turlers.ToList());
        }
        //Get-Kitap türü detayını göster 
        public IActionResult Details(int id)
        {
            var tur =_context.Turlers.Find(id);
            return View(tur);
        }
        //GET_düzenlenecek kitabın bilgilerini göster
         public IActionResult Edit(int id)
        {
            var tur =_context.Turlers.Find(id);
            return View(tur);
        }
        [HttpPost]
        public IActionResult Edit(Turler tur)
        {
            if (ModelState.IsValid)
            {
            _context.Update(tur); //Bu satır sadece contextimizi güncelledi.
            _context.SaveChanges(); //Veri tabanında güncelle.
            return RedirectToAction("Index"); //Gitmek istediğimiz action
            }
            return View(tur);
        }

        //GET- Silinecek kitap türü sayfasını göster
        public IActionResult Delete(int id)
        {
            var tur =_context.Turlers.Find(id);
            return View(tur);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var silinecekKitapTuru = _context.Turlers.Find(id);
            _context.Turlers.Remove(silinecekKitapTuru);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Turler tur)
        {
            _context.Add(tur);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}