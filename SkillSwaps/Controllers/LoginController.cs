using Domain.User;
using Business_Logic;
using Business_Logic.Interfaces;
using SkillSwaps.Models.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace SkillSwaps.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession _session;
        public LoginController()
        {
            var bl = new BusinessLogic();
            _session = bl.GetSessionBL();
        }




        // GET: Login
        public ActionResult Index()
        {
            //var sId = "abcd";
            //bool isSessionValid = _session.ValidateSessionId(sId); 
            //if(isSessionValid)
            //{
            //    return RedirectToAction("Login");
            //}
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AuthData data) 
        {
            var uAuthData = new UserAuthData
            { 
                Password = data.Password,
                UserName = data.UserName,
                RequestTime = DateTime.UtcNow
            };
            string sessionKey = _session.AuthUser(uAuthData);

            return View();
        }

    }
}