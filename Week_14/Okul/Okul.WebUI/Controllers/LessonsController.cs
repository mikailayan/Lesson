using Microsoft.AspNetCore.Mvc;
using Okul.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Okul.WebUI.Controllers
{
    public class LessonsController : Controller
    {
        private readonly ILessonRepository _lessonRepository;
        public LessonsController(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }
        public IActionResult Index()
        {
            return View(_lessonRepository.GetAll());
        }
    }
}
