using Domain.Article;
using Business_Logic;
using Business_Logic.Interfaces;
using SkillSwaps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkillSwaps.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IProduct _product;
        private readonly ISession _session;
        public HomeController() 
        {
            var bl = new BusinessLogic();
            _product = bl.GetProductBl();
            _session = bl.GetSessionBL();
        }
        // GET: Home
        public ActionResult Index()
        {
            SessionStatus();

            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return RedirectToAction("Index", "Login");
            }
            return View();


            List<ArticleDataMain> data = _product.GetAllArticleFor();

            UserData u = new UserData();
            u.Username = "Customer";
            u.Products = new List<string> { "Product #1", "Product #2", "Product #3", "Product #4" };
            return View(u);
        }
    }
}