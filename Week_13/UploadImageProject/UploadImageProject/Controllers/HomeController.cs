using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UploadImageProject.Models;

namespace UploadImageProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UploadImage()
        {
            //Birazdan resmin yüklenmesi işlemlerini tamamlayıp, buraya döneceğiz.Döndük.
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/");
            var imageList = Directory.GetFiles(path);
            List<UploadImageModel> uploadImages = new List<UploadImageModel>();
            foreach (var image in imageList)
            {
                FileInfo fileInfo = new FileInfo(image);
                UploadImageModel model = new UploadImageModel();
                model.FullName = image.Substring(image.IndexOf("wwwroot")).Replace("wwwroot/", string.Empty);
                model.FileName = fileInfo.Name;
                model.Size = fileInfo.Length / 1024;
                uploadImages.Add(model);
            }

            return View(uploadImages);
        }
        [HttpPost]
        public IActionResult UploadImage(IFormFile file) //inputların adıyla değişkenin adı aynı oludğu zaman name'i alıyor //IformFile form üzerinden verilere erişmek için
        {
            if (file!=null) //seçimemişken form boş gelmesin diye 
            {
                string imageExtension = Path.GetExtension(file.FileName); //pathı oluşturmak için
                string imageName = Guid.NewGuid() + imageExtension; //resimlerime rastgele isimler vermek için
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{imageName}"); //gönderilen doyanın adını kendim ayarlamak için yapıyorum. eğer istemeseydim file.filename demem yeterli olucaktı.
                var stream = new FileStream(path, FileMode.Create); //copyto stream istiyor flestreamda stream yaratıyor.
                file.CopyTo(stream);
            }
            return RedirectToAction("UploadImage");
        }
    }
}
