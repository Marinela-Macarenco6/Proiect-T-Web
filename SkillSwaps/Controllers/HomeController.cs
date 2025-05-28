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
        public HomeController() 
        {
            var bl = new BusinessLogic();
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
        }
    }
}