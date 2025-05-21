using Azure.Identity;
using Business_Logic;
using Business_Logic.BL_Struct;
using Business_Logic.Interfaces;
using Domain.User.EditAcc;
using Domain.User.UserActionResp;
using SkillSwaps.LogicHelper;
using SkillSwaps.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkillSwaps.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IReg _change;
       private readonly ISession _session;

        public AccountController()
        {
            var bl = new BusinessLogic();
            _change = bl.GetRegBL();
            _session = bl.GetSessionBL();
        }


        
        // Get Change Password
        public ActionResult ChangePassword()
        {
            return View(new ChangePswdData());
        }

        //Post Change Password
        [HttpPost]
        public ActionResult ChangePassword(ChangePswdData data)
        {
            var sessionKey = Request.Cookies["X-KEY"];
            if (sessionKey == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var newData = new ChangePasswordData
            {
                UserId = sessionKey.Value,
                OldPassword = data.OldPassword,
                NewPassword = data.NewPassword,
                ConfirmPassword = data.ConfirmPassword,
            };

            bool isChanged = _change.UserChangePassword(newData);

            if (isChanged)
            {
                TempData["Success"] = "Parola a fost schimbata cu succes!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "A aparut o eroare. Te rugam sa incerci din nou.");
                return View(data); // returnezi aceeasi pagina cu datele completate
            }
        }



        //Get Change Username
        public ActionResult ChangeUsername()
        {
            return View(new ChangeUserData());
        }

        //Post Change Username
        [HttpPost]
        public ActionResult ChangeUsername(ChangeUserData data)
        {
            var sessionKey = Request.Cookies["X-KEY"];
            if (sessionKey == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var newData = new ChangeUsernameData
            {
                SessionKey = sessionKey.Value,
                NewUsername = data.NewUsername,
                Password = data.Password
            };

            bool isChanged = _change.UserChangeUsername(newData);

            if (isChanged)
            {
                TempData["Success"] = "Numele de utilizator a fost schimbat cu succes!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "A aparut o eroare. Te rugam sa incerci din nou.");
                return View(data); // returnezi aceeasi pagina cu datele completate
            }

        }

        public ActionResult ChangeGmailAcc()
        {
            return View(new ChangeUserData());
        }


        // LOGOUT
        //[HttpPost]
        //public ActionResult Logout()
        //{
        //    var sessionKey = Request.Cookies["X-KEY"];

        //    if (sessionKey != null)
        //    {
        //        sessionKey.Expires = DateTime.Now.AddDays(-1);
        //        Response.Cookies.Add(sessionKey);

        //        bool success = _session.LogoutUser(sessionKey.Value);

        //        if (!success)
        //        {
        //            Session.Clear();
        //            return RedirectToAction("Error", "Error");
        //        }
        //    }
        //    Session.Clear();

        //    return RedirectToAction("Index", "Home");
        //}
    }
}