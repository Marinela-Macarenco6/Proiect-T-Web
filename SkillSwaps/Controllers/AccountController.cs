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


        
        // GET: Change Password
        public ActionResult ChangePassword()
        {
            return View(new ChangePswdData());
        }

        // POST: Change Password
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
                ConfirmPassword = data.ConfirmPassword
            };

            var resp = _change.UserChangePassword(newData);

            if (resp.Status)
            {
                TempData["Success"] = "Parola a fost schimbata cu succes!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                            if (resp.Error != null &&
                                (resp.Error.Contains("Sesiunea nu a fost gasita") || resp.Error.Contains("Sesiunea a expirat")))
                            {
                                return RedirectToAction("Index", "Login");
                            }

                            if (resp.Error != null &&
                                (resp.Error.Contains("Parola este incorectă.") || resp.Error.Contains("Utilizatorul nu a fost găsit.")))
                            {
                                ModelState.AddModelError("", "Ați introdus datele greșite.");
                                return View(data);
                            }

                ModelState.AddModelError("", resp.Error ?? "A aparut o eroare. Te rugam sa incerci din nou.");
                return View(data);
            }
        }




        // GET: Change Username
        public ActionResult ChangeUsername()
        {
            return View(new ChangeUserData());
        }

        //POST: Change Username
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

            var resp = _change.UserChangeUsername(newData);

            if (resp.Status)
            {
                TempData["Success"] = "Numele de utilizator a fost schimbat cu succes!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                         if (resp.Error != null &&
                                (resp.Error.Contains("Sesiunea nu a fost gasita") || resp.Error.Contains("Sesiunea a expirat")))
                         {
                             return RedirectToAction("Index", "Login");
                         }

                         if (resp.Error != null &&
                             (resp.Error.Contains("Parola introdusă este incorectă.")))
                         {
                             ModelState.AddModelError("", "Ați introdus o parolă incorectă.");
                             return View(data);
                         }

                if (resp.Error != null &&
                    (resp.Error.Contains("Username indisponibil.")))
                {
                    ModelState.AddModelError("", "Username Indisponibil");
                    return View(data);
                }

                ModelState.AddModelError("", resp.Error ?? "A aparut o eroare. Te rugam sa incerci din nou.");
                return View(data);
            }
        }




        // GET: Change Gmail Account
        public ActionResult ChangeEmailAcc()
        {
            return View(new ChangeEmail());
        }

       // POST: Change Gmail Account
        [HttpPost]
        public ActionResult ChangeEmailAcc(ChangeEmail data)
        {

            var sessionKey = Request.Cookies["X-KEY"];
            if (sessionKey == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var newData = new ChangeEmailData
            {
                SessionKey = sessionKey.Value,
                NewEmail = data.NewEmail,
                Password = data.Password
            };

            var resp = _change.UserChangeEmail(newData);

            if (resp.Status)
            {

                TempData["Success"] = "Emailul utilizatorului a fost schimbat cu succes!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                    if (resp.Error != null &&
                        (resp.Error.Contains("Sesiunea nu a fost gasita") || resp.Error.Contains("Sesiunea a expirat")))
                    {
                        return RedirectToAction("Index", "Login");
                    }

                ModelState.AddModelError("", resp.Error ?? "A aparut o eroare. Te rugam sa incerci din nou.");
                return View(data);
            }

        }








    }
}