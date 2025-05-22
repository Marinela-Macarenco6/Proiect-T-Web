using Business_Logic;
using Business_Logic.Interfaces;
using Domain.Article;
using SkillSwaps.Models.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkillSwaps.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IProduct _product;

        public CoursesController()
        {
            var bl = new BusinessLogic();
            _product = bl.GetProductBl();
        }

        // GET: Courses  
        public ActionResult Index()
        {
            return View();
        }

        // GET: Add Course  
        public ActionResult AddCourse()
        {
            //De implementat verificarea sesiunii
            //bool isValid = _user.isSessionValid(); 
            return View();
        }
        public ActionResult curs1()
        {
            return View();
        }
        public ActionResult curs2()
        {
            return View();
        }
        public ActionResult curs3()
        {
            return View();
        }
        public ActionResult curs4()
        {
            return View();
        }
        public ActionResult curs5()
        {
            return View();
        }
        public ActionResult curs6()
        {
            return View();
        }

        // POST: Add Course  
        [HttpPost]
        public ActionResult AddCourse(AddCourseData data)
        {
            var courseData = new ArticleDataMain
            {
                Title = data.Title,
                Teacher = data.Teacher,
                Category = data.Category,
                Description = data.Description,
                ArticleImage = data.ArticleImage,
                PublicationDateTime = DateTime.UtcNow,
                EnrolledUsers = 0,
            };

            bool isAdded = _product.AddCourse(courseData);

            if (isAdded)
            {
                TempData["Success"] = "Cursul a fost adaugat cu succes!";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "A aparut o eroare la salvarea cursului. Te rugam sa incerci din nou.");
                return View(data); // returnezi aceeasi pagina cu datele completate
            }
        }
    }
}