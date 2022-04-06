using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _07_MVC_Layout_01.Controllers
{
    public class HakkımdaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
