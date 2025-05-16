using Business_Logic.Interfaces;
using Business_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.User.UserActionResp;
using Domain.Enums;
using System.Web.Routing;

namespace SkillSwaps.LogicHelper.Atributes
{
    public class IsAdminAttribute : ActionFilterAttribute
    {
        private readonly IReg _session;
        public IsAdminAttribute()
        {
            var bl = new BusinessLogic();
            _session = bl.GetRegBL();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sessionKey = HttpContext.Current.Request.Cookies["X-KEY"];
            if (sessionKey != null)
            {
                UserResp profile = _session.GetUserByCookie(sessionKey.Value);
                if (profile != null && profile.Role == EURole.Administrator)
                {
                    filterContext.Result = 
                        new RedirectToRouteResult(
                            new RouteValueDictionary(
                                new { controller = "Error", action = "Index" }));
                }
            }

        }
    }
}