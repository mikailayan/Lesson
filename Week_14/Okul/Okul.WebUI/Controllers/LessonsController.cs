using Microsoft.AspNetCore.Mvc;
using Okul.DAL.Abstract;
using Okul.DAL.Entities;
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Lesson lesson)
        {
            _lessonRepository.Add(lesson);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            return View(_lessonRepository.GetSingle(id));
        }

        [HttpPost]
        public IActionResult Edit(Lesson lesson)
        {
            _lessonRepository.Update(lesson);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {

            return View(_lessonRepository.GetSingle(id));
        }
        public IActionResult Delete(int id)
        {
            return View(_lessonRepository.GetSingle(id));
        }
        [HttpPost]
        public IActionResult Delete(Lesson lesson)
        {
            _lessonRepository.Delete(lesson);
            return RedirectToAction("Index");
        }
    }
}
