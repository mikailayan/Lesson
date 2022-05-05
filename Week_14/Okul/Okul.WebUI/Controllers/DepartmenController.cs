using Microsoft.AspNetCore.Mvc;
using Okul.DAL.Abstract;
using Okul.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Okul.WebUI.Controllers
{
    public class DepartmenController : Controller
    {
        private readonly IDepartmenRepository _departmenRepository;
        public DepartmenController(IDepartmenRepository departmenRepository)
        {
            _departmenRepository = departmenRepository;
        }
        public IActionResult Index()
        {
            return View(_departmenRepository.GetAll());
        }
        public IActionResult AddDepartmen(Departmen departmen)
        {

            _departmenRepository.Add(departmen);
            return View();
        }
    }
}
