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
using Domain.User.UserActionResp;

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

        [HttpGet]
        public ActionResult Index()
        {
            return View(new AuthData());
        }

        public ActionResult Login(AuthData data)
        {
            var uAuthData = new UserAuthDTO
            {
                Password = data.Password,
                UserName = data.UserName,
                UserIp = "localhost"
            };
            var resp = _session.AuthUser(uAuthData);

            if (resp.Status)
            {
                var respCookie = _session.GeneratCookieByUser(resp.UserId);

                var cookie = respCookie.Cookie;

                ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            }
            else
            {
                return RedirectToAction("Error", "Error");
            }
            return RedirectToAction("Index", "Home");

        }

    }
}