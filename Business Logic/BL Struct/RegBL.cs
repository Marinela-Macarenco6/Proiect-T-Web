using Business_Logic.Core;
using Business_Logic.Interfaces;
using Domain.User;

namespace Business_Logic.BL_Struct
{
    public class RegBL : UserApi, IReg
    {
        // Constructor fără parametru 'userLevel'
        public RegBL()
        {
        }

        public string UserRegLogic(UserRegData uRegData)
        {
            return UserRegLogicAction(new RegDataActionDTO
            {
                FullName = uRegData.FullName,
                UserName = uRegData.UserName,
                Email = uRegData.Email,
                Password = uRegData.Password,
                ConfirmPassword = uRegData.ConfirmPassword
            });
        }


        public string RegisterUser(RegDataActionDTO userData)
        {
            return UserRegLogicAction(userData);
        }
    }
}