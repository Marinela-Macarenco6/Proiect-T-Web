using SkillSwaps.DbDataContext;
using SkillSwaps.Domain.Comments;
using SkillSwaps.Models.Course;
using System;
using Business_Logic.Core;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business_Logic.BL_Struct;
using Business_Logic.Interfaces;
using Business_Logic;

namespace SkillSwaps.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlog _blog;

        public BlogController()
        {
            var bl = new BusinessLogic();
            _blog = bl.GetBlogBl();
        }

        // GET: Blog
        public ActionResult Index(string searchQuery = "", int pagina = 1)
        {
            int pePagina = 5;

            var evenimente = string.IsNullOrWhiteSpace(searchQuery)
                ? _blog.GetToateEvenimentele()
                : _blog.GetEvenimenteFiltrate(searchQuery);

            var total = evenimente.Count;
            var paginat = evenimente.Skip((pagina - 1) * pePagina).Take(pePagina).ToList();

            ViewBag.SearchQuery = searchQuery;
            ViewBag.PaginaCurenta = pagina;
            ViewBag.TotalPagini = (int)Math.Ceiling((double)total / pePagina);

            return View("Index", paginat);
        }

        public ActionResult Categorie(string categorie, int pagina = 1)
        {
            int pePagina = 5;

            var toate = _blog.GetToateEvenimentele()
                .Where(e => e.Categorie == categorie)
                .ToList();

            var paginat = toate
                .Skip((pagina - 1) * pePagina)
                .Take(pePagina)
                .ToList();

            ViewBag.Categorie = categorie;
            ViewBag.TotalPagini = (int)Math.Ceiling((double)toate.Count / pePagina);
            ViewBag.PaginaCurenta = pagina;

            return View("Categorie", paginat);
        }

        public ActionResult Cauta(string searchQuery)
        {
            var rezultate = _blog.GetEvenimenteFiltrate(searchQuery);
            ViewBag.SearchQuery = searchQuery;
            return View("SearchResults", rezultate);
        }

        public ActionResult EvNotabil1() => View();
        public ActionResult EvNotabil2() => View();
        public ActionResult EvNotabil3() => View();
        public ActionResult EvNotabil4() => View();

        public ActionResult Ev1() => View();
        public ActionResult Ev2() => View();
        public ActionResult Ev3() => View();
        public ActionResult Ev4() => View();
        public ActionResult Ev5() => View();
        public ActionResult Ev6() => View();
        public ActionResult Ev7() => View();
        public ActionResult Ev8() => View();
        public ActionResult Ev9() => View();
        public ActionResult Ev10() => View();
        public ActionResult Ev11() => View();
        public ActionResult Ev12() => View();
        public ActionResult Ev13() => View();
        public ActionResult Ev14() => View();
        public ActionResult Ev15() => View();
        public ActionResult Evpag2() => View();
        public ActionResult Evpag3() => View();


        [HttpPost]
        public ActionResult PostBlogComment(CTable comment)
        {
            bool result = _blog.SaveComment(comment);

            if (result)
                return Json(new { success = true, message = "Comentariu postat cu succes!" });
            else
                return new HttpStatusCodeResult(400, "Eroare la postarea comentariului.");
        }
    }
}
