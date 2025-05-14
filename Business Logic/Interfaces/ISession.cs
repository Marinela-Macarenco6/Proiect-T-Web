using Domain.User;
using Domain.User.UserActionResp;

namespace Business_Logic.Interfaces
{
    public interface ISession
    {
        UserCookieResp GeneratCookieByUser(int id);
        UserResp AuthUser(UserAuthDTO data);
    }
}
