using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.EditAcc
{
    public class ChangeEmailData
    {
        public string NewEmail { get; set; }
        public string Password { get; set; }
        public string SessionKey { get; set; }
    }
}
