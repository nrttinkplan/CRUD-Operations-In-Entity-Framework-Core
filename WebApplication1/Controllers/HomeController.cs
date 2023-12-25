using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Diagnostics;
using WebApplication1;

namespace mvc.uygulama.Controllers
{
    public class HomeController : Controller
    {
        private SchoolContext schoolContext;
        public HomeController(SchoolContext sc)
        {
            schoolContext = sc;
        }

        public IActionResult Index()
        {
            List<Teacher> list = schoolContext.Teacher.ToList();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                schoolContext.Teacher.Add(teacher);
                schoolContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        public IActionResult Update(int id)
        {
            return View(schoolContext.Teacher.Where(a => a.Id == id).FirstOrDefault());
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update_Post(Teacher teacher)
        {
            schoolContext.Teacher.Update(teacher);
            schoolContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var teacher = schoolContext.Teacher.Where(a => a.Id == id).FirstOrDefault();
            schoolContext.Teacher.Remove(teacher);
            schoolContext.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}