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
            var makale = new List<Article>
            {   
                new Article  {ID=1, Header="dawdwa", Content="fwefwe" },
                new Article  {ID=2, Header="dawdwa", Content="fwefwe" },
                new Article  {ID=3, Header="dawdwa", Content="fwefwe" },
                new Article  {ID=4, Header="dawdwa", Content="fwefwe" },
                new Article  {ID=5, Header="dawdwa", Content="fwefwe" },
                new Article  {ID=6, Header="dawdwa", Content="fwefwe" },



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
