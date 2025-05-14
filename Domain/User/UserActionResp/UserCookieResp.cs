using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Domain.User.UserActionResp
{
    public class UserCookieResp
    {
        public HttpCookie Cookie { get; set; }
        public DateTime ValidUntil { get; set; }
        public int UserId { get; set; }
    }
}