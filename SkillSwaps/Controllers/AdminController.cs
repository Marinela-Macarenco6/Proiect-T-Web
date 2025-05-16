using SkillSwaps.LogicHelper.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkillSwaps.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [IsAdmin]
        public ActionResult Index()
        {
            return View();
        }
    }
}