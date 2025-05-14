using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.UserActionResp
{
    public class UserResp
    {
        public bool Status { get; set; }
        public string Error { get; set; }
        public int UserId { get; set; }
    }
}
