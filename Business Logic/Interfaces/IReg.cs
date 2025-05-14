using Domain.User;
using Domain.User.Reg;

namespace Business_Logic.Interfaces
{
    public interface IReg
    {
        //string UserRegLogic(UserRegData uRegData);
        UserRegDataResp UserRegLogicAction(RegDataActionDTO uRegData);
    }
}
