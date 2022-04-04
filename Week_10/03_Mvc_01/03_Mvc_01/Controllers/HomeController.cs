using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _03_Mvc_01.Controllers
{
    //Eğer bir classın controller davranuşı sergilemesini yani;
    //gelen bir requesti karşıyalabilir özellik kazanmasını istiyorsak 
    //o clasın Controller sınıfından türetmeliyiz.
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Action Method : Eğer bir metot bir controller içindeyse 
            //buna Action method diyoruz. Hatta çoğu kez sadece Action sözcüğü ile ifade edilebilir.

            //Bu action uygulamamızın anasayfasına girildiğinde tetiklenmiş olacak.
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
    }
}
