﻿using Domain.Article;
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
    public class HomeController : Controller
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
            List<ArticleDataMain> data = _product.GetAllArticleFor();

            var ss = _session.ValidateSessionId("");


            UserData u = new UserData();
            u.Username = "Customer";
            u.Products = new List<string> { "Product #1", "Product #2", "Product #3", "Product #4" };
            return View(u);
        }
    }
}