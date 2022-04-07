using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DersBlogSitesi.Controllers
{
    public class yeniController : Controller
    {
        public IActionResult Index()
        {

            DataTable tablo = new DataTable();
            /* burada veritabanından veya başka kaynaktan verileri datatable'a aktaracağız. */
            ViewData["veriler"] = tablo; // Verileri içeren DataTable nesnemizi ViewData'ya gömüyoruz.
            return View();
            


        }
    }
}
