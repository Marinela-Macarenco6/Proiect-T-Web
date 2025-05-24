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

        // EDIT USER
        [IsAdmin]
        [HttpPost]
        public ActionResult EditUser(UserInfo data)
        {
            // Verifică dacă datele primite sunt nule
            if (data == null)
            {
                // Returnează un răspuns JSON cu succes: false și un mesaj de eroare
                return Json(new { success = false, message = "Datele primite sunt invalide." });
            }

            try
            {
                // Crează un obiect UserDataMain din datele primite
                var userData = new UserDataMain
                {
                    UserId = data.UserId,
                    FullName = data.FullName,
                    UserName = data.UserName,
                    Email = data.Email,
                    // Asigură-te că UserRole poate fi parsat corect în EURole
                    UserRole = (EURole)Enum.Parse(typeof(EURole), data.UserRole)
                };

                // Apelez metoda de editare a utilizatorului din repository
                bool isChanged = _admin.EditUserAcc(userData);

                if (isChanged)
                {
                    // Dacă editarea a avut succes, returnează un JSON cu succes: true
                    return Json(new { success = true, message = "Utilizatorul a fost editat cu succes." });
                }
                else
                {
                    // Dacă editarea a eșuat (ex: nicio modificare, eroare internă în _admin.EditUserAcc), returnează succes: false
                    return Json(new { success = false, message = "A apărut o eroare la editarea utilizatorului. Poate nu s-au făcut modificări sau a intervenit o problemă internă." });
                }
            }
            catch (Exception ex)
            {
                // Prinde orice excepție apărută în timpul procesării (ex: eroare la Enum.Parse, eroare în baza de date)
                // Este recomandat să loghezi această excepție într-un sistem de logare real.
                // Console.WriteLine(ex.Message); // Doar pentru depanare rapidă în dezvoltare

                // Returnează un răspuns JSON cu succes: false și mesajul de eroare al excepției
                return Json(new { success = false, message = "A apărut o eroare neașteptată: " + ex.Message });
            }
        }

        // GET SEARCH USER VIEW
        public ActionResult FindUser()
        {
            return View();
        }

        // SEARCH USER
        [IsAdmin]
        [HttpGet]
        public JsonResult SearchUsers(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return Json(new { success = false, message = "Termenul de căutare nu poate fi gol." }, JsonRequestBehavior.AllowGet); 
            }

            var users = _admin.SearchUser(searchTerm);

            if (users == null || !users.Any())
            {
                return Json(new { success = true, users = new object[0], message = "Nu s-au găsit utilizatori." }, JsonRequestBehavior.AllowGet); 
            }

            var mappedUsers = users.Select(u => new UserInfo
            {
                UserId = u.UserId,
                FullName = u.FullName,
                UserName = u.UserName,
                Email = u.Email,
                RequestTime = u.RequestTime,
                UserRole = u.UserRole.ToString()
            }).ToList();

            return Json(new { success = true, users = mappedUsers }, JsonRequestBehavior.AllowGet);
        }



    }


}
