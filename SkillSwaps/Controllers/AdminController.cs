using Business_Logic;
using Business_Logic.Interfaces;
using Domain.Admin;
using Domain.Enums;
using SkillSwaps.LogicHelper.Atributes;
using SkillSwaps.Models;
using SkillSwaps.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace SkillSwaps.Controllers
{
    public class AdminController : Controller
    {

        private readonly ISession _session;
        private readonly IAdmin _admin;

        public AdminController()
        {
            var bl = new BusinessLogic();
            _session = bl.GetSessionBL();
            _admin = bl.GetAdminBl();
        }

        // GET: Admin
        [IsAdmin]
        public ActionResult Index()
        {
            return View();
        }

        // LOGOUT 
        [HttpPost]
        public ActionResult Logout()
        {
            var sessionKey = Request.Cookies["X-KEY"];

            if (sessionKey != null)
            {
                sessionKey.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(sessionKey);

                bool success = _session.LogoutUser(sessionKey.Value);

                if (!success)
                {
                    Session.Clear();
                    return RedirectToAction("Error", "Error");
                }
            }
            Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        // GET ALL USERS
        [IsAdmin]
        public ActionResult GetAllUsers()
        {
                    var sessionKey = Request.Cookies["X-KEY"];
                    if (sessionKey == null)
                    {
                        return RedirectToAction("Index", "Login");
                    }

            var domainUsers = _admin.GetAllUser();

            var viewModel = domainUsers.Select(u => new UserInfo
            {
                UserId = u.UserId,
                FullName = u.FullName,
                UserName = u.UserName,
                Email = u.Email,
                RequestTime = u.RequestTime,
                UserRole = u.UserRole.ToString()
            }).ToList();

            return View(viewModel);
        }


        // GET ALL ONLINE USERS
        [IsAdmin]
        public ActionResult GetOnlineUsers()
        {
                    var sessionKey = Request.Cookies["X-KEY"];
                    if (sessionKey == null)
                    {
                        return RedirectToAction("Index", "Login");
                    }

            var domainUsers = _admin.GetAllOnlineUser();

            var viewModel = domainUsers.Select(u => new UserInfo
            {
                UserId = u.UserId,
                FullName = u.FullName,
                UserName = u.UserName,
                Email = u.Email,
                RequestTime = u.RequestTime,
                UserRole = u.UserRole.ToString()
            }).ToList();

            return View(viewModel);

        }

        // BAN USER
        [IsAdmin]
        [HttpPost]
        public ActionResult BanUser(UserInfo data)
        {
            var userData = new UserDataMain
            {
                UserId = data.UserId,
            };

            bool banned = _admin.BannUserAcc(userData);

            if (banned)
            {
                TempData["SuccessMessage"] = "Utilizatorul a fost blocat cu succes.";
            }
            else
            {
                TempData["ErrorMessage"] = "A apărut o eroare la blocarea utilizatorului sau utilizatorul este deja blocat.";
            }

            return RedirectToAction("GetAllUsers");
        }


    }
}