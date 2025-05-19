using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;

namespace Domain.User.EditAcc
{
    public class ChangeUsernameData
    {
        public string SessionKey { get; set; }
        public string NewUsername { get; set; }
        public string Password { get; set; }

    }
}
