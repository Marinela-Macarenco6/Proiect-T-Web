using Business_Logic;
using Business_Logic.Interfaces;
using SkillSwaps.LogicHelper.Atributes;
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

        private readonly IReg _change;
        private readonly ISession _session;

        public AdminController()
        {
            var bl = new BusinessLogic();
            _change = bl.GetRegBL();
            _session = bl.GetSessionBL();
        }

        // GET: Admin
        [IsAdmin]
        public ActionResult Index()
        {
            return View();
        }


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


    }
}