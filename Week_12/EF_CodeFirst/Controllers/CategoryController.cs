using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

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
            return View();
        }
    }

    
}