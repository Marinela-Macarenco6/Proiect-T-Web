using Business_Logic.Core;
using Business_Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.BL_Struct
{
   public class SessionBL : UserApi, ISession
    {
        public bool ValidateSessionId(string id)
        {
            return ValidateSessionIdAction(id);
     
        }
        public string AuthUser(UserAuthData data)
        {
            return AuthUserAction(data);
        }
    }
}
