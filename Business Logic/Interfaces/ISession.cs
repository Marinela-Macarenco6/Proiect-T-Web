using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.User;

namespace Business_Logic.Interfaces
{
    public interface ISession
    {
        bool ValidateSessionId(string id);
        string AuthUser(UserAuthData data);
    }
}
