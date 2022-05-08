using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Okul.DAL.Concrete;
using Okul.DAL.Concrete.DAL;
using Okul.DAL.Entities;
using Okul.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Okul.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private StudentDAL model;

        public HomeController(StudentDAL context)
        {
            model = context;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AssignLesson()
        {
            return View(model.GetAll());
        }
        public IActionResult Assign(int id)
        {
            LessonDAL model2=null;
            StudentDAL context=null;
            var entity = context.GetByIdwithLessons(id);
            var model = new StudentModel()
            {
                StudentId = entity.StudentId,
                FirstName = entity.StudentName,
                LastName = entity.StudentSurName,
                DateofBirth = entity.StudentDateOfBirth,
                DateOfRegistration = entity.StudentDateOfRegistration,
                Period = entity.StudentSemester,
                DepartmenId = entity.DepartmenId,
                SelectedLesson = entity.StudentLessons.Select(x => x.Lesson).ToList()
            };
            ViewBag.Lessons = model2.GetAll();
            return View(model);
        }
    }
}
