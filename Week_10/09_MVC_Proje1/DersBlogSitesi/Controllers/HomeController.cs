using DersBlogSitesi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DersBlogSitesi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var makale = new List<Makale>
            {   
                new Makale  {ID=1, Header="dawdwa", Content="fwefwe" },
                new Makale  {ID=2, Header="dawdwa", Content="fwefwe" },
                new Makale  {ID=3, Header="dawdwa", Content="fwefwe" },
                new Makale  {ID=4, Header="dawdwa", Content="fwefwe" },
                new Makale  {ID=5, Header="dawdwa", Content="fwefwe" },
                new Makale  {ID=6, Header="dawdwa", Content="fwefwe" },



            };
            //Model bazlı veri aktarımı
            //return View(makale);

            //ViewBag
            //ViewBag.kemal = makale;
            //return View();

            //ViewData
            //ViewBag.Mesaj = "Anasayfa";
            //ViewData["kemal"] = makale;
            //return View();

            TempData["kemal"] = makale;
            return View();
        }
    }
}
