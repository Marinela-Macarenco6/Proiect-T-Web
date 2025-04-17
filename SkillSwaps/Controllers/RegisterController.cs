using Business_Logic;
using Business_Logic.Interfaces;
using Domain.User;
using SkillSwaps.Models.User;
using SkillSwaps.Models.Reg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkillSwaps.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IReg _reg;
        
        public RegisterController() 
        {
            var bl = new BusinessLogic();
            _reg = bl.GetRegBL();
        }

        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegData data)
        {
            var uRegData = new UserRegData
            {
                Password = data.Password,
                UserName = data.UserName,
                RequestTime = DateTime.UtcNow
            };
            string sessionKey = _reg.UserRegLogic(uRegData);

            return View();
        }

    }
}