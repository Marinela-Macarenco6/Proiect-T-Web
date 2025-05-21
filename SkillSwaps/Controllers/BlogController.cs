using SkillSwaps.DbDataContext;
using SkillSwaps.Domain.Comments;
using SkillSwaps.Models.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business_Logic.BL_Struct;
using Business_Logic.Interfaces;
using System;

namespace SkillSwaps.Controllers
{
    public class BlogController : Controller
    {
        private readonly CommentsContext _context;
        private readonly IBlogLogic _blogLogic;

        public BlogController()
        {
            _context = new CommentsContext();
            _blogLogic = new BlogBL();
        }
        // GET: Blog
        public ActionResult Index(string searchQuery = "", int pagina = 1)
        {
            int pePagina = 5;

            var evenimente = string.IsNullOrWhiteSpace(searchQuery)
                ? _blogLogic.GetToateEvenimentele()
                : _blogLogic.GetEvenimenteFiltrate(searchQuery);

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

            var toate = _blogLogic.GetToateEvenimentele()
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
            var rezultate = _blogLogic.GetEvenimenteFiltrate(searchQuery);
            ViewBag.SearchQuery = searchQuery;
            return View("SearchResults", rezultate);
        }
        public ActionResult EvNotabil1()
        {
            return View();
        }

        public ActionResult EvNotabil2()
        {
            return View();
        }

        public ActionResult EvNotabil3()
        {
            return View();
        }

        public ActionResult EvNotabil4()
        {
            return View();
        }

        public ActionResult Ev1()
        {
            return View();
        }

        public ActionResult Ev2()
        {
            return View();
        }

        public ActionResult Ev3()
        {
            return View();
        }

        public ActionResult Ev4()
        {
            return View();
        }

        public ActionResult Ev5()
        {
            return View();
        }

        public ActionResult Ev6()
        {
            return View();
        }

        public ActionResult Ev7()
        {

            return View();

        }

        public ActionResult Ev8()
        {
            return View();
        }

        public ActionResult Ev9()
        {
            return View();
        }

        public ActionResult Ev10()
        {
            var comments = _context.Comments.OrderByDescending(c => c.PostedAt).ToList();
            return View(comments);
        }

        public ActionResult Ev11()
        {
            return View();
        }

        public ActionResult Ev12()
        {
            return View();
        }

        public ActionResult Ev13()
        {
            return View();
        }

        public ActionResult Ev14()
        {
            return View();
        }

        public ActionResult Ev15()
        {
            return View();
        }

        public ActionResult Evpag2()
        {
            return View();
        }

        public ActionResult Evpag3()
        {
            return View();
        }
       

    }


}