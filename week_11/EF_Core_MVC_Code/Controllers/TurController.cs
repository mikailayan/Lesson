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
    }
}