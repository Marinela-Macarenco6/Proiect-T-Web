using Domain.User;
using Domain.User.Reg;
using Domain.User.UserActionResp;
using System.Web;

namespace Business_Logic.Interfaces
{
    public interface IReg
    {
        UserResp GetUserByCookie(string sessionKey); 

        //string UserRegLogic(UserRegData uRegData);
        UserRegDataResp UserRegLogicAction(RegDataActionDTO uRegData);
    }
}
