using SkillSwaps.DbDataContext;
using SkillSwaps.Domain.Comments;
using SkillSwaps.Models.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkillSwaps.Controllers
{
    public class BlogController : Controller
    {
        private readonly CommentsContext _context;

        public BlogController()
        {
            _context = new CommentsContext();
        }
        // GET: Blog
        public ActionResult Index()
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