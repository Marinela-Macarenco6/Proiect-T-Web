using Domain.User;
using Business_Logic.Core;
using Business_Logic.Interfaces;
using Domain.User.UserActionResp;

namespace Business_Logic.BL_Struct
{
    public class SessionBL : UserApi, ISession
    {
        public UserResp AuthUser(UserAuthDTO data)
        {
            return AuthUserAction(data);
        }

        public UserCookieResp GeneratCookieByUser(int id)
        {
            return GeneratCookieByUserAction(id);
        }

       public bool LogoutUser(string sessionKey)
        {
            return LogoutUserAction(sessionKey);
        }

    }
}


