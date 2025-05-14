using Business_Logic.BL_Struct;
using Business_Logic.Interfaces;
using Domain.User;
using Domain.User.Reg;
using System;
using System.Web.Mvc;

namespace SkillSwaps.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IReg _reg;

        public RegisterController()
        {
            _reg = new RegBL();
        }

        // GET: /Register
        public ActionResult Index()
        {
            return View(new UserRegData());
        }

        [HttpPost]
        public ActionResult Register(UserRegData data)
        {
            if (ModelState.IsValid)
            {
                var dto = new RegDataActionDTO
                {
                    FullName = data.FullName,
                    UserName = data.UserName,
                    Email = data.Email,
                    Password = data.Password,
                    RequestTime = data.RequestTime ?? DateTime.UtcNow.ToLocalTime()

                };

                var result = _reg.UserRegLogicAction(dto);

                if (result.Status)
                {
                    TempData["Success"] = "Utilizatorul a fost înregistrat cu succes!";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", result.Error);
                    return View("Index", data);
                }
            }

            return View("Index", data);
        }
    }
}
